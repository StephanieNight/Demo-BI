using BackendAPI.Dtos;
using DataService.Interfaces;
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
        private readonly IDataService _dataService;

        public ParagraphFunction(IDataService dataService)
        {
            _dataService = dataService ?? throw new ArgumentNullException(nameof(dataService));
        }

        [FunctionName("Paragraph")]
        public async Task<IActionResult> Run(
            [HttpTrigger(AuthorizationLevel.Function, "post", Route = null)] HttpRequest req,
            ILogger log)
        {
            log.LogInformation($"C# HTTP trigger function [{nameof(ParagraphFunction)}]processed a request.");

            string requestBody = await new StreamReader(req.Body).ReadToEndAsync();

            ParagraphDTO data = JSONToObject<ParagraphDTO>(requestBody);
            log.LogInformation($"Got Data Length: {data.Paragraph.Length} ");
            try
            {
                var startTimeTicks = DateTime.Now.Ticks;

                var uniquewords = _dataService.GetUniqueWords(data.Paragraph);
                var watchlistwords = _dataService.GetwordsOnWatchList(uniquewords);

                var runtimeInTicks = DateTime.Now.Ticks - startTimeTicks;

                ParagraphResponseDTO response = new ParagraphResponseDTO() { 
                    UniqueWords = uniquewords.Length,
                    WatchlistWords = watchlistwords 
                };

                return new OkObjectResult(response);
            }   
            catch (Exception ex)
            {
                return new BadRequestObjectResult(ex.Message);
            }            
        }
    }
}
