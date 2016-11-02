using Microsoft.AspNetCore.Builder;
using Request.Timer.Logger.Options;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Request.Timer.Logger.Extensions
{
    public static class RequestLoggerMiddlewareExtension
    {
        private static int _DEFAULT_WARNING = 3000;
        private static int _DEFAULT_ERROR = 5000;

        public static IApplicationBuilder UseRequestTimerLogger(this IApplicationBuilder builder)
        {
            Constants.WarningMilliseconds = _DEFAULT_WARNING;
            Constants.ErrorMilliseconds = _DEFAULT_ERROR;

            return builder.UseMiddleware<RequestTimerLoggerMiddleware>();
        }

        public static IApplicationBuilder UseRequestTimerLogger(this IApplicationBuilder builder,
            IRequestLoggerOptions options)
        {
            Constants.WarningMilliseconds = options.WarningMilliseconds;
            Constants.ErrorMilliseconds = options.ErrorMilliseconds;
            Constants.LogToFile = options.LogToFile;
            Constants.FilePath = options.FilePath ?? "";

            return builder.UseMiddleware<RequestTimerLoggerMiddleware>();
        }
    }
}
