using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Azure.WebJobs;
using Microsoft.Azure.WebJobs.Extensions.Http;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Threading.Tasks;

namespace WebhookAF
{
    public static class ContactChange
    {
        [FunctionName("ContactChange")]
        //[return: ServiceBus("outputqueue", Connection = "RootManageSharedAccessKey")]
        public static async Task<IActionResult> Run(
            [HttpTrigger(AuthorizationLevel.Function, "get", "post", Route = null)] HttpRequest req,
              ILogger log)
        {
        log.LogInformation($"Webhook was triggered!");

        // Grab the validationToken URL parameter
        string code = req.Query["code"];
        log.LogInformation($"code: {code}");

        log.LogInformation($"Dataverse triggered our webhook...great :-)");
        var content = await new StreamReader(req.Body).ReadToEndAsync();
        log.LogInformation($"Received following payload: {content}");

        // if we get here we assume the request was well received
        return (ActionResult)new OkObjectResult($"Compeleted");
        //return (ActionResult)new ObjectResult($"{content}");
        }
    }
}
