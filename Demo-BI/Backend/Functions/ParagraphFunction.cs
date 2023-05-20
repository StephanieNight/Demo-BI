using BackendAPI.Dtos;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Azure.WebJobs;
using Microsoft.Azure.WebJobs.Extensions.Http;
using Microsoft.Extensions.Logging;
using System.IO;
using System.Threading.Tasks;

namespace BackendAPI.Functions
{
    public class ParagraphFunction : BaseFunction
    {
        [FunctionName("Paragraph")]
        public async Task<IActionResult> Run(
            [HttpTrigger(AuthorizationLevel.Function, "post", Route = null)] HttpRequest req,
            ILogger log)
        {
            log.LogInformation($"C# HTTP trigger function [{nameof(ParagraphFunction)}]processed a request.");

            string requestBody = await new StreamReader(req.Body).ReadToEndAsync();
            
            ParagraphDTO data = JSONToObject<ParagraphDTO>(requestBody);
            log.LogInformation($"Got Data: {data.Paragraph} ");

            return new OkObjectResult("All Good Bro");
        }
    }
}
