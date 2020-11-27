Integration library for ASP.NET applications
============================================

[![VSTS](https://1tcompany.visualstudio.com/_apis/public/build/definitions/75570083-b1ef-4e78-88e2-5db4982f756c/14/badge)]() [![NuGet](https://img.shields.io/nuget/dt/codeRR.Client.AspNet.svg?style=flat-square)]()

This library will detect all unhandled exceptions in ASP.NET-based applications.

If you want to get automated exception handling for one of the ASP.NET-based libraries, use the following packages:

* [ASP.NET MVC5](https://github.com/coderrio/coderr.client.aspnet.mvc5)
* [ASP.NET WebApi2](https://github.com/coderrio/coderr.client.aspnet.webapi2)
* [ASP.NET Core MVC](https://www.nuget.org/coderrio/Coderr.Client.AspNetCore.Mvc/)

# Reporting the first error

First, follow [this guide](https://coderr.io/documentation/getting-started/).

Then activate this library:

```csharp
public class Global : System.Web.HttpApplication
{

	protected void Application_Start(object sender, EventArgs e)
	{
		//replace with your server URL and your appkey/SharedSecret.
		var uri = new Uri("https://report.coderr.io/");
		Err.Configuration.Credentials(uri,
			"yourAppKey",
			"yourSharedSecret");


		Err.Configuration.CatchAspNetExceptions();
	}
}
```

# Manually reporting exceptions

All unhandled exceptions are reported automatically by this library. 
But sometimes you need to deal with exceptions yourself. 

```csharp
public void UpdatePost(int uid, ForumPost post)
{
	try
	{
		_service.Update(uid, post);
	}
	catch (Exception ex)
	{
		Err.Report(ex, new{ UserId = uid, ForumPost = post });
	}
}
```


# Context collections

This library includes the following context collections for every reported exceptions:

* All in the [core library](https://github.com/coderrio/coderr.client)
* Application collection
* Form data
* Http headers
* Query string parameters
* Session data
* Uploaded files

# More information

* [Questions/Help](http://discuss.coderr.io)
* [Documentation](https://coderr.io/documentation/client/libraries/aspnet/)
