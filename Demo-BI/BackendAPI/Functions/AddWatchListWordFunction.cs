using System;
using System.IO;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Azure.WebJobs;
using Microsoft.Azure.WebJobs.Extensions.Http;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using DataService.Interfaces;
using BackendAPI.Dtos;

namespace BackendAPI.Functions
{
    public class AddWatchListWordFunction : BaseFunction
    {
        private readonly IDataService _dataService;

        public AddWatchListWordFunction(IDataService dataService)
        {
            _dataService = dataService ?? throw new ArgumentNullException(nameof(dataService));
        }

        [FunctionName("AddWatchList")]
        public async Task<IActionResult> Run(
            [HttpTrigger(AuthorizationLevel.Function, "post", Route = null)] HttpRequest req,
            ILogger log)
        {
            log.LogInformation($"C# HTTP trigger function [{nameof(ParagraphFunction)}]processed a request.");

            string requestBody = await new StreamReader(req.Body).ReadToEndAsync();
            var data = JSONToObject<WatchlistItemDTO>(requestBody);
            try 
            { 
                _dataService.AddWatchlistWord(data.Word); 
                return new OkObjectResult("Watchlist item added.");
            }
            catch (Exception ex)
            {
                return new BadRequestObjectResult(ex.Message);
            }
        }
    }
}
