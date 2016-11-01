using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Request.Timer.Logger.Options
{
    public interface IRequestLoggerOptions
    {

        /// <summary>
        /// show a warning message on the console when request time exceeds the value
        /// </summary>
        int WarningMilliseconds { get; set; }

        /// <summary>
        /// show an error message on the console when request time exceeds the value
        /// </summary>
        int ErrorMilliseconds { get; set; }
    }
}
