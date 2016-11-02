using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Request.Timer.Logger
{
    internal static class FileWriter
    {
        internal static void Log(Models.RequestLog log, string path)
        {
            if (Constants.LogToFile && !string.IsNullOrWhiteSpace(Constants.FilePath))
            {
                var bulk = Newtonsoft.Json.JsonConvert.SerializeObject(log, 
                    Newtonsoft.Json.Formatting.Indented);
                try
                {
                    CreateIfNotExist(path);
                    System.IO.File.AppendAllText(path, bulk);
                }
                catch { }
            }
        }
        private static void CreateIfNotExist(string path)
        {
            var directory = System.IO.Path.GetDirectoryName(path);

            if (!System.IO.Directory.Exists(directory))
            {
                System.IO.Directory.CreateDirectory(directory);
                //GrantAccess(directory);
            }
        }
    }
}
