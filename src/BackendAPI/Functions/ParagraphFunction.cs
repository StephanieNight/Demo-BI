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
        private readonly ILoggingService _loggingService;

        public ParagraphFunction(IDataService dataService, ILoggingService loggingService)
        {
            _dataService = dataService ?? throw new ArgumentNullException(nameof(dataService));
            _loggingService = loggingService ?? throw new ArgumentNullException(nameof(loggingService));
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
                // Create new stopwatch.
                var stopwatch = System.Diagnostics.Stopwatch.StartNew();

                var uniquewords = _dataService.GetUniqueWords(data.Paragraph);
                var watchlistwords = _dataService.GetwordsOnWatchList(uniquewords);

                // Stop timing.
                stopwatch.Stop();

                log.LogInformation($"runtime : {stopwatch.ElapsedMilliseconds} ms");

                _loggingService.Log(_dataService.GetType().Name, data.Paragraph.Length, stopwatch.ElapsedMilliseconds);

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
