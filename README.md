Integration library for ASP.NET applications
==========================

This library will detect all unhandled exceptions in ASP.NET-based applications and report them to your OneTrueError server (or your account at https://onetrueerror.com).

If you want to get automated handling for one of the ASP.NET derivatives, use the following libraries:

* [ASP.NET MVC5](https://github.com/onetrueerror/onetrueerror.client.aspnet.mvc5)
* [ASP.NET WebApi2](https://github.com/onetrueerror/onetrueerror.client.aspnet.webapi2)


To report exceptions manually in your controller, use `OneTrue.Report(exception)`, OneTrueError will include information about the HttpRequest, QueryString, Form, Session etc when your exception is reported.

# Context collections

This library includes the following context collections for every reported exceptions:

* All in the [core library](https://github.com/onetrueerror/onetrueerror.client)
* Application collection
* Form data
* Http headers
* Query string parameters
* Session data
* Uploaded files

# Getting started

1. Download and install the [OneTrueError server](https://github.com/onetrueerror/onetrueerror.server) or create an account at [OneTrueError.com](https://onetrueerror.com)
2. Install this client library (using nuget `onetrueerror.client.aspnet`)
3. Configure the credentials from your OneTrueError account in your `Global.asax`
4. Add `OneTrue.Configuration.CatchAspNetExceptions()` in your `Global.asax`

Done.
