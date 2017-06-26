# README #

.Net Core API for various purposes 

### What is this repository for? ###

* This Repository is built on .Net Core framework with a hope that I and Simpson can practice latest technologies and discuss on different Code Architecture. Ultimate target is to find the best code architecture which can be easy to scaled and fit in different business requirements. In the end, it's toy for me and Simpson to play with :) 

### How do I get set up? ###

#Setting up .Net Core working environment (On Windows)
* Install visual studio 2017
https://www.microsoft.com/net/core#windowsvs2017

* Install .Net CLI tool (download .net core sdk)
download in this website https://www.microsoft.com/net/core#windowscmd 

* 

#Setting up Angular2 (on Windows)
https://fullstackmark.com/post/9/get-started-with-angular-2-and-aspnet-core-in-visual-studio-code

* Upgrade Node Js using Npm (Node v7.x)
Uninstall current Node and go to this website and download latest version https://nodejs.org/en/download/. Run 'node -v' after installing, the output should be 6.4.10

> _node -v_

*upgrade npm version
>_npm install npm@latest -g_
>_npm -v_

*install angular/cli
>_npm install -g @angular/cli_ 

>_ng -v_

#Setting up Angular2 (on Mac)
https://fullstackmark.com/post/9/get-started-with-angular-2-and-aspnet-core-in-visual-studio-code

* Upgrade Node Js using Npm (Node v7.x)

> _sudo npm cache clean -f_

> _sudo npm install -g n_

> _sudo n stable_ or _sudo n 6.0.10_ (for a desired version)

> _node --v_ -> to check version

* install npm v3.10.10
* Install angular-cli
> _sudo npm install -g @@angular/cli_

* Go to a folder then create a new project using "ng new" the "--style" argument tells the generator we want the app to pre-compile our css using sass with scss syntax.

> _ng new mvcDemoUi --style=scss_

* install boostrap 4 alpha in the app directory

> _cd mvcDemoUi_

> _npm install bootstrap@next --save 

> _code ._  -> to open VS code

#Setup Backend using .Net Core On MAC

* Create new sybolic link

> _ln -s /usr/local/share/dotnet/dotnet /usr/local/bin/_

* go to a folder, create a new mvc/web/api project

> _dotnet new mvc_   ->to create new MVC project

> _dotnet new webapi_  ->to create new webapi project

* Restore package

> _dotnet restore_

* Run 

> _donet run_ -> this will launch and navigate to http://localhost:5000

* Create a class library

https://github.com/dotnet/core/issues/222 
> _dotnet new -t lib_
* Data Migration command 
> _dotnet ef migrations add initial_
> _dotnet ef database update_

if using Package Management Console
> _Add-Migration -Name Initial -Context contextName_
> _Update-Database_

* More "dotnet commands"
>  _-n|--name         The name for the output being created. If no name is specified, the name of the current directory is used._
>  _-o|--output       Location to place the generated output._
>  _-h|--help         Displays help for this command._
>  _-all|--show-all   Shows all templates_



Templates                 Short Name      Language      Tags
----------------------------------------------------------------------
Console Application       console         [C#], F#      Common/Console
Class library             classlib        [C#], F#      Common/Library
Unit Test Project         mstest          [C#], F#      Test/MSTest
xUnit Test Project        xunit           [C#], F#      Test/xUnit
ASP.NET Core Empty        web             [C#]          Web/Empty
ASP.NET Core Web App      mvc             [C#], F#      Web/MVC
ASP.NET Core Web API      webapi          [C#]          Web/WebAPI
Solution File             sln                           Solution

Examples:
    >> _dotnet new mvc --auth None --framework netcoreapp1.1_
    >> _dotnet new web --framework netcoreapp1.1_
    >> _dotnet new --help_
	
PS C:\Users\hvu\Dropbox (SCOPEMED)\HungVu\Samples\dotNetCore\mvcDemo2>


* Summary of set up
* Configuration
* Dependencies
* Database configuration
* How to run tests
* Deployment instructions

### Contribution guidelines ###

* Writing tests
* Code review
* Other guidelines

### Who do I talk to? ###

* Repo owner or admin
* Other community or team contact