using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Request.Timer.Logger.Models
{
    internal class RequestLog
    {
        public long RequestTime { get; set; }
        public DateTime Date { get; set; }
        public string Path { get; set; }
        public string RemoteAddress { get; set; }
    }
}
