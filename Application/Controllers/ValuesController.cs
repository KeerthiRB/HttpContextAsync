using BAL.interfaceaccess;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http;
using System.Web;
using LoggerProcess;

namespace Application.Controllers
{
    public class ValuesController : ApiController
    {
        readonly IMessages _messages = null;
        public ValuesController(IMessages messages)
        {
            _messages = messages;
        }
        // GET api/values
        public async Task<IEnumerable<string>> Get()
        {
            LogDetails.WrokFlowLog($" Controller : - In Message Class  Get Messages Method Called ");
            return await _messages.GetMessages();
        }

        // GET api/values/5
        public async Task<string> Get(int id)
        {
            LogDetails.WrokFlowLog($" Controller : - In Message Class  Get Message Method Called ID: {id}");
            return await _messages.GetMessage(id);
        }

        // POST api/values
        public async Task Post([FromBody]string value)
        {
        }

        // PUT api/values/5
        public async Task Put(int id, [FromBody]string value)
        {
        }

        // DELETE api/values/5
        public async Task Delete(int id)
        {
        }
    }
}
