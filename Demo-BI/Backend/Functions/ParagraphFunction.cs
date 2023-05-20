using BackendAPI.Dtos;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Azure.WebJobs;
using Microsoft.Azure.WebJobs.Extensions.Http;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
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
            log.LogInformation($"Got Data Length: {data.Paragraph.Length} ");

            var words = data.Paragraph.Split(new char[] { ' ', '\r', '\n' });
            var Dictionary = new Dictionary<string, int>();
            var startTimeTicks = DateTime.Now.Ticks;
            foreach (var word in words)
            {
                if (Dictionary.ContainsKey(word))
                {
                    Dictionary[word]++;
                }
                else
                { 
                    Dictionary.Add(word, 1); 
                }
            }
            var runtimeInTicks = DateTime.Now.Ticks - startTimeTicks;
            log.LogInformation($"Runtime : {runtimeInTicks} Ticks");

            ParagraphResponseDTO response = new ParagraphResponseDTO() { UniqueWords = Dictionary.Count };

            return new OkObjectResult(response);
        }
    }
}
