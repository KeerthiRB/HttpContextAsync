using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Web;

namespace LoggerProcess
{
   
    public static class SaveLogs
    {
        public static void Save()
        {
            StringBuilder sb = new StringBuilder();
            if (HttpContext.Current.Items["Debug"] != null)
            {
                sb.Append(HttpContext.Current.Items["Debug"].ToString());
            }
            if (HttpContext.Current.Items["Error"] != null)
            {
                sb.Append(HttpContext.Current.Items["Error"].ToString());
            }
            if (HttpContext.Current.Items["Info"] != null)
            {
                sb.Append(HttpContext.Current.Items["Info"].ToString());
            }
            if (HttpContext.Current.Items["WorkFlowLog"] != null)
            {
                sb.Append(HttpContext.Current.Items["WorkFlowLog"].ToString());
            }
            WriteLog(sb.ToString());
            
        }
        static ReaderWriterLock locker = new ReaderWriterLock();
        private static void WriteLog(string text)
        {
            try
            {
                locker.AcquireWriterLock(int.MaxValue); //You might wanna change timeout value 
                System.IO.File.AppendAllLines(Path.Combine(Path.GetDirectoryName(System.Reflection.Assembly.GetExecutingAssembly().GetName().CodeBase).Replace("file:\\", ""), "AppLog.txt"), new[] { text });
            }
            finally
            {
                locker.ReleaseWriterLock();
            }
        }
    }
}
