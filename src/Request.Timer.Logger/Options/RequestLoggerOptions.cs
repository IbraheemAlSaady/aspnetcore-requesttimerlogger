using Request.Timer.Logger.Options;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Request.Timer.Logger.Options
{
    public class RequestLoggerOptions : IRequestLoggerOptions
    {
        public int WarningMilliseconds { get; set; }
        public int ErrorMilliseconds { get; set; }
    }
}
