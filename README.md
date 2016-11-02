# Request Timer Logger

Request Timer Logger is a console logger that will check and write the time each request took to be processed with the option of logging the request info into a file.

##Installation

```Nuget
Install-Package Request.Timer.Logger
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
            ILoggerFactory loggerFactory, IRequestLoggerOptions loggerOptions)
{
    app.UseRequestTimerLogger(); // using the default options
    
    //SetTimerLoggerOptions(loggerOptions);
    //app.UseRequestTimerLogger(loggerOptions); passing the options of the logger
}
private void SetTimerLoggerOptions(IRequestLoggerOptions options)
{
   options.WarningMilliseconds = 1000;
   options.ErrorMilliseconds = 3000;
   options.LogToFile = true;
   options.FilePath = "C:/Logging/defaultapp.log";
}
```
### Request Timer Logger Options
1. **WarningMilliseconds**: it will show a yellow message in the console if the request time took more than the value provided in this porperty (Default "3000")
2. **ErrorMilliseconds**: it will show a red message in the console if the request time took more than the value provided in this property (Default "5000").
3. **LogToFile**: a flag to check whether the information should be logged to a file or not (Default "false").
4. **FilePath**: the file path where the request infromation should be logged (Default "empty").

## Contact
Feel free to drop me an email at ibraheem.al-saady@outlook.com
