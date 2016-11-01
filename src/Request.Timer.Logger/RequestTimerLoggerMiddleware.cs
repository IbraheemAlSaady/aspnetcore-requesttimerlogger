using Microsoft.AspNetCore.Http;
using Request.Timer.Logger.Options;
using System;
using System.Diagnostics;

namespace Request.Timer.Logger
{
    public class RequestTimerLoggerMiddleware
    {
        private readonly RequestDelegate _next;

        public RequestTimerLoggerMiddleware(RequestDelegate next)
        {
            this._next = next;
        }

        public async System.Threading.Tasks.Task Invoke(HttpContext context)
        {
            var watcher = new Stopwatch();
            watcher.Start();

            await _next.Invoke(context);

            var requestTime = watcher.ElapsedMilliseconds;

            string log = string.Format("Path: {0}\nIP: {1}\ntime:{2} milliseconds",
                context.Request.Path, context.Request.HttpContext.Connection.RemoteIpAddress,
                requestTime.ToString());

            if (requestTime < Statics.WarningMilliseconds)
                WriteRequest(log);
            else if (requestTime >= Statics.WarningMilliseconds && requestTime < Statics.ErrorMilliseconds)
                WriteWarning(log);
            else
                WriteError(log);
        }

        private void WriteRequest(string log)
        {     
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine($"Request at: {DateTime.Now}");
            Console.ForegroundColor = ConsoleColor.DarkGray;
            Console.WriteLine(log + "\n");
        }

        private void WriteWarning(string log)
        {
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine($"Request at: {DateTime.Now}");
            Console.ForegroundColor = ConsoleColor.DarkGray;
            Console.WriteLine(log + "\n");
        }

        private void WriteError(string log)
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine($"Request at: {DateTime.Now}");
            Console.ForegroundColor = ConsoleColor.DarkGray;
            Console.WriteLine(log + "\n");
        }
    }
}
