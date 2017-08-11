# Headervalidator-Middleware
Header Validator validates the header in Hypertext Transfer Protocol
# How to add NuGet package to the solution
Clone the project in the visual studio and then add the NuGet package to the solution.
Build the solution and open the prompt window by navigating to your solution, then type the following command
```dotnet pack``` 
![](https://github.com/daenetCorporation/headervalidator-middleware/blob/master/HeaderValidatorApp/Images/HeaderValidatorPack.png)
It will create the .nupkg files in the debug folder of HeaderValidatorMiddleware. Now just copy these two files to anywhere on your system in a desired folder.
![](https://github.com/daenetCorporation/headervalidator-middleware/blob/master/HeaderValidatorApp/Images/ManageNuget.png)
By clicking right on the references of HeaderValidatorDemoApplication in visual studio, choose the option: "Manage NuGet Packages" and insert the path of the folder where you saved the .nupkg files.
![](https://github.com/daenetCorporation/headervalidator-middleware/blob/master/HeaderValidatorApp/Images/PathofFiles.png)
It will show you the NuGet package of HeaderValidatorMiddleware finally install the NuGet package.
