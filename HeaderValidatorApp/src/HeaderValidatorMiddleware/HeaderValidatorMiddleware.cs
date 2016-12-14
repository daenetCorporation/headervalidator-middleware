using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Misp.MessageRouterService
{
    /// <summary>
    /// Extension for using the Header Validator
    /// </summary>
    public static class AppBuilderExtensions
    {
        /// <summary>
        ///
        /// </summary>
        /// <param name="app"></param>
        /// <param name="options"></param>
        public static void UseHeaderValidatorMiddleware(
            this IApplicationBuilder app, HeaderValidatorOptions options = null)
        {
            if (options == null)
                throw new ArgumentException("Specified 'HeaderValidatorOptions' have to be properly configured :(");

            app.UseMiddleware<HeaderValidatorMiddleware>(options);
        }
    }


    /// <summary>
    ///
    /// </summary>
    public class HeaderValidatorMiddleware
    {
        private HeaderValidatorOptions m_Opts;

        private RequestDelegate m_Next;

        /// <summary>
        /// Creates the middleware instance.
        /// </summary>
        /// <param name="next">Nex middleware in chain.</param>
        /// <param name="opts"></param>
        public HeaderValidatorMiddleware(RequestDelegate next, HeaderValidatorOptions opts)
        {
            m_Opts = opts;
            m_Next = next;
        }

        /// <summary>
        /// Setups the authorization settings relevant for Security Manager.
        /// </summary>
        /// <param name="context"></param>
        /// <returns></returns>
        public async Task Invoke(HttpContext context)
        {
            bool isRequestValid = true;

            if (m_Opts.Headers != null)
            {
                foreach (var header in m_Opts.Headers)
                {
                    if (context.Request.Headers.ContainsKey(header.Key))
                    {
                        // if configured header value is null in config, just check if header exists (we already did this before, so just do nothing now)
                        if (!String.IsNullOrEmpty(header.Value))
                        {
                            var headerValue = context.Request.Headers[header.Key];

                            // header does not match required value
                            if (headerValue != header.Value)
                            {
                                isRequestValid = false;
                            }
                        }
                    }
                    else
                    {
                        isRequestValid = false;
                    }
                }
            }

            if (!isRequestValid)
            {
                context.Response.StatusCode = 401;
                await context.Response.WriteAsync("Header Validator - Access denied. Some headers are missing or some header values are incorrect!");
                return;
            }

            await m_Next.Invoke(context);
        }
    }

}
