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

        /// <summary>
        /// a flag to check whether the information should be logged to a file
        /// </summary>
        bool LogToFile { get; set; }

        /// <summary>
        /// the file path where the information should be logged
        /// </summary>
        string FilePath { get; set; }


    }
}
