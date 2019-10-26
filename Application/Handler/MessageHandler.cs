using LoggerProcess;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;
using System.Web;

namespace Application.Handler
{
    public class MessageHandler1: DelegatingHandler
    {
        protected async override Task<HttpResponseMessage> SendAsync(
        HttpRequestMessage request, CancellationToken cancellationToken)
        {
            LogDetails.WrokFlowLog("Request Started");
            LogDetails.WrokFlowLog("IP :-"+HttpContext.Current.Request.ServerVariables["REMOTE_ADDR"]);
            LogDetails.WrokFlowLog("User :-" + System.Web.HttpContext.Current.User.Identity.Name);
            LogDetails.WrokFlowLog("Request Content :" + request.ToString());
            // Call the inner handler.
            var response = await base.SendAsync(request, cancellationToken);

            LogDetails.WrokFlowLog("Response : "+response.ToString());
            LogDetails.WrokFlowLog("Response Content: " + JsonConvert.SerializeObject(response.Content));
            
            LogDetails.WrokFlowLog("Request Completed");
            SaveLogs.Save();
            return response;
        }
    }
}