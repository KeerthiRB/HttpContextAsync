using BAL.interfaceaccess;
using LoggerProcess;
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
            LogDetails.WrokFlowLog($" BAL : - In Message Class  Get Message Method Called With id : {id}");
            try
            {
                
                LogDetails.Debug($"ID :- {id}");
                LogDetails.Info($" BAL : - In Message Class  Get Message Method Called With id : {id}");
                if (id > 10)
                {
                   throw new Exception("ID is not valid");
                }
            }
            catch (Exception ex)
            {
                LogDetails.Info($" BAL : - In Message Class  Get Message Method Called With id : {id}");
                LogDetails.Error(ex);
            }
            
            return $"Some Value Id Sent :{id}";
            
        }

        public async Task<IEnumerable<string>> GetMessages()
        {
            LogDetails.WrokFlowLog($" BAL : - In Message Class  Get Messages Method Called ");
            LogDetails.Info($" BAL : - In Message Class  Get Messages Method Called ");
            try
            {
                return new string[] { $"value1{DateTime.Now.Ticks.ToString()}", $"value2{DateTime.Now.Ticks.ToString()}" };
            }
            catch(Exception ex)
            {
                LogDetails.Info($" BAL : - In Message Class  Get Messages Method Called ");
                LogDetails.Error(ex);
                throw ex;
            }
            
        }
    }
}
