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

            string log = string.Format("IP: {0}\nPath: {1}\nIP: {2}\ntime:{3} milliseconds",
                context.Request.HttpContext.Connection.RemoteIpAddress.ToString(),
                context.Request.Path, context.Request.HttpContext.Connection.RemoteIpAddress,
                requestTime.ToString());

            var date = DateTime.Now;

            if (requestTime < Constants.WarningMilliseconds)
                WriteRequest(log, date);
            else if (requestTime >= Constants.WarningMilliseconds && requestTime < Constants.ErrorMilliseconds)
                WriteWarning(log, date);
            else
                WriteError(log, date);

            WriteToFile(context.Request.Path, 
                context.Request.HttpContext.Connection.RemoteIpAddress.ToString(), 
                date, 
                requestTime);
        }

        private void WriteRequest(string log, DateTime date)
        {
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine($"Request at: {date}");
            Console.ForegroundColor = ConsoleColor.DarkGray;
            Console.WriteLine(log + "\n");
        }

        private void WriteWarning(string log, DateTime date)
        {
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine($"Request at: {date}");
            Console.ForegroundColor = ConsoleColor.DarkGray;
            Console.WriteLine(log + "\n");
        }

        private void WriteError(string log, DateTime date)
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine($"Request at: {date}");
            Console.ForegroundColor = ConsoleColor.DarkGray;
            Console.WriteLine(log + "\n");
        }

        private void WriteToFile(string path, string remoteAddress, DateTime date, long time)
        {
            if (Constants.LogToFile && !string.IsNullOrWhiteSpace(Constants.FilePath))
                FileWriter.Log(new Models.RequestLog()
                {
                    Path = path,
                    RemoteAddress = remoteAddress,
                    Date = date,
                    RequestTime = time
                }, Constants.FilePath);
        }
    }
}
