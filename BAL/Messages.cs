using BAL.interfaceaccess;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;

namespace BAL
{
    public class Messages : IMessages
    {
        public async Task<string> GetMessage(int id)
        {
            throw new Exception("Un Known");
            return "value";
            
        }

        public async Task<IEnumerable<string>> GetMessages()
        {
            if (HttpContext.Current.Items["MyItem"] != null)
            {
                return (List<string>)HttpContext.Current.Items["MyItem"];
            }
            return new string[] { "value1", "value2" };
        }
    }
}
