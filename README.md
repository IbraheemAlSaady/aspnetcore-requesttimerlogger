# Request Timer Logger

Request Timer Logger is a console logger that will check and write the time each request took to be processed.

##Installation

```Nuget
Install-Package Request.Timer.Logger -Pre
```

## How to use

Inside the Startup class of your project, in the ConfigureServices method. inject the IRequestLoggerOptions as a Singleton

```C#
public void ConfigureServices(IServiceCollection services)
{
   // Add framework services.
   services.AddApplicationInsightsTelemetry(Configuration);
   services.AddSingleton<IRequestLoggerOptions, RequestLoggerOptions>();
   services.AddMvc();
}
```
Request Timer Logger comes with default options, however you can override them.

```C#
 public void Configure(IApplicationBuilder app, IHostingEnvironment env, 
            ILoggerFactory loggerFactory, IRequestLoggerOptions requestLogger)
{
    app.UseRequestTimerLogger();
    
    //requestLogger.WarningMilliseconds = 1000;
    //requestLogger.ErrorMilliseconds = 3000;
    //app.UseRequestTimerLogger(requestLogger); you can also pass the options
}
```

## Contact
Feel free to drop me an email at ibraheem.al-saady@outlook.com
