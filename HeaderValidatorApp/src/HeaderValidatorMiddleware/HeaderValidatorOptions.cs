using System.Collections.Generic;

namespace Misp.MessageRouterService
{
    /// <summary>
    /// Options of HeaderValidator
    /// </summary>
    public class HeaderValidatorOptions
    {
        /// <summary>
        /// Headers to check, if value of Key is null check only if header exists
        /// </summary>
        public Dictionary<string, string> Headers { get; set; }
    }
}