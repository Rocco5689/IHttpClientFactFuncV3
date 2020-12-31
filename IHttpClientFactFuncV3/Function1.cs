using System;
using System.IO;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Azure.WebJobs;
using Microsoft.Azure.WebJobs.Extensions.Http;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using System.Net.Http;

namespace IHttpClientFactFuncV3
{
    public class Function1
    {
        // Create the local _customHttpClient of the Interface type ICustomHttpClient
        // _customHttpClient will accept the injected Type ICustomHttpClient and use
        // this client within the scope of this functions execution
        private readonly ICustomHttpClient _customHttpClient;

        public Function1(ICustomHttpClient customHttpClient)
        {
            _customHttpClient = customHttpClient;
        }

        [FunctionName("Function1")]
        public async Task<IActionResult> Run(
            [HttpTrigger(AuthorizationLevel.Anonymous, "get", "post", Route = null)] HttpRequest req,
            ILogger log)
        {
            log.LogInformation("C# HTTP trigger function processed a request.");

            // =================================== BEGIN

            // Using the created _customHttpClient we can call our defined method to implement 
            // the GetStatusCodeAsync() method
            await _customHttpClient.GetStatusCodeAsync();

            // =================================== END

            string name = req.Query["name"];

            string requestBody = await new StreamReader(req.Body).ReadToEndAsync();
            dynamic data = JsonConvert.DeserializeObject(requestBody);
            name = name ?? data?.name;

            string responseMessage = string.IsNullOrEmpty(name)
                ? "This HTTP triggered function executed successfully. Pass a name in the query string or in the request body for a personalized response."
                : $"Hello, {name}. This HTTP triggered function executed successfully.";

            return new OkObjectResult(responseMessage);
        }
    }
}
