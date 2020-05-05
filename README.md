# Sign in with Apple using ASP.NET Core (MVC & Razor Pages)

In 2019 Apple announced and released 'Sign in with Apple' at their Worldwide Developer Conference (WWDC).  'Sign in with Apple' is the fast, easy way for people to sign in to apps or websites using the Apple IDs they already have.  In doing so Apple joined many other OpenID and OAuth identity providers including Facebook, Google, Microsoft, Amazon and others.  Business and data platform Statista estimates that 20 percent of all smartphones sold worldwide in 2019 were an Apple iPhone.  Apple has consistently been Samsung’s closest competitor, maintaining the position of second most popular smartphone vendor in the world since 2012.  Providing authentication from external identity providers is of great value to your app or website as it simplifies access and increases usage.  With just a click or two, new users are able to sign in and begin using your app or website without creating a new username and password.  

In this repository I have provided sample projects for implementing 'Sign in with Apple' using both ASP.NET Core MVC and Razor Pages.  

## Features
- Retrieve and display the Id, First Name, Last Name, Full Name and Email Address of the Apple ID user
- Supports both Apple Face ID authentication and Apple ID username and password authentication
- Supports Apple ID Multi-Factor Authentication (MFA)
- Handle the initial Apple ID sign in and all subsequent sign ins as the data response is slightly different
- Redirect the user back to your website using the Redirect Url

## Preview Images
![Sign In With Apple](https://mastorageacct.blob.core.windows.net/ma-host-prod-iamnickpinheiro-web/github/images/aspnet-sign-in-with-apple-1.png "Sign In With Apple Button")
![Sign In With Apple](https://mastorageacct.blob.core.windows.net/ma-host-prod-iamnickpinheiro-web/github/images/aspnet-sign-in-with-apple-2.png?v=1 "Sign In With Apple Consent")
![Sign In With Apple](https://mastorageacct.blob.core.windows.net/ma-host-prod-iamnickpinheiro-web/github/images/aspnet-sign-in-with-apple-3.png "Sign In With Apple Response")

## Live Demo Sites on Microsoft Azure 
ASP.NET Core MVC  
https://aspnet-apple-web-mvc.azurewebsites.net

ASP.NET Core Razor Pages  
https://aspnet-apple-web-razor.azurewebsites.net

## Subscribe for Updates
Subscribe for notifications of updates and new features:  
https://www.iamnickpinheiro.com/#subscribe

## Resources
Introducing Sign In with Apple (WWDC Video)  
https://developer.apple.com/videos/play/wwdc2019/706

Incorporating Sign in with Apple into Other Platforms  
https://developer.apple.com/documentation/sign_in_with_apple/sign_in_with_apple_js/incorporating_sign_in_with_apple_into_other_platforms

Apple ID | Manage your Apple account  
https://appleid.apple.com

## License
Sign in with Apple using ASP.NET Core (MVC & Razor Pages) is licensed under the MIT license. See the LICENSE file for more details.
