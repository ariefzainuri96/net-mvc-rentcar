# RentCar App

## Integrating tailwind v4

1. open this link -> `https://tailwindcss.com/docs/installation/tailwind-cli`
2. create file input.css inside /wwwroot/css
3. create script for watching any changes for tailwind using below command
    - `npx @tailwindcss/cli -i ./wwwroot/css/input.css -o ./wwwroot/css/site.css --watch`
4. makesure the output is always site.css, because it follow the convention of ASP .NET MVC and we dont have to adjust the existing styling for razor file

## Enable hot reload in browser

1. run this command -> `dotnet add package Microsoft.AspNetCore.Mvc.Razor.RuntimeCompilation --version 3.0.3` you can adjust the version to match with your .net version or remove the definition to use latest version

## Starting new project

1. run this command `dotnet new mvc -n RentCar --framework netcoreapp3.0` the sentence after --framework is for specify the version, remove if you want to use latest installed .net version
2. run this command `dotnet new sln` to create the solution
3. run this command `dotnet sln add RentCar.csproj` to connect the solution to project