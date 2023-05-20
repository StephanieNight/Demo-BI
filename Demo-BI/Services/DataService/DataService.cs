using DataAccess;
using DataService.Interfaces;
using Microsoft.Extensions.Logging;

namespace DataService
{
    public class DataService : IDataService
    {
        private readonly BIContext _context;
        private readonly ILogger _logger;
        public DataService(BIContext context, ILogger log)
        {
            _context = context ?? throw new ArgumentNullException(nameof(context));
            _logger = log ?? throw new ArgumentNullException(nameof(log));
        }

        public int HandleData(string paragraphs)
        {
            var words = paragraphs.Split(new char[] { ' ', '\r', '\n' });
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
            _logger.LogInformation($"Runtime : {runtimeInTicks} Ticks");

            return Dictionary.Count;
        }
    }
}
