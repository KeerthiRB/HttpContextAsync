using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;

namespace LoggerProcess
{
    public static class LogDetails
    {
        public static void Debug(object mesObject)
        {
            Log("Debug", mesObject);
        }

        public static void Error(object mesObject)
        {
            Log("Error", mesObject);
        }

        public static void Info(object mesObject)
        {
            Log("Info", mesObject);
        }

        public static void WrokFlowLog(object mesObject)
        {
            Log("WorkFlowLog", mesObject);
        }

        private static void Log(string logLevel,object mesObject)
        {
            if (HttpContext.Current.Items[logLevel] == null)
            {
                HttpContext.Current.Items[logLevel] = $"[@{logLevel}] {Environment.NewLine}";
            }
            HttpContext.Current.Items[logLevel] = $"{HttpContext.Current.Items[logLevel].ToString()}{DateTime.Now.ToString()}{Environment.NewLine}{ JsonConvert.SerializeObject(mesObject)}{ Environment.NewLine}";
        }
        
    }
}
