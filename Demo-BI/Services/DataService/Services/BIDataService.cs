using DataAccess;
using DataService.Interfaces;
using Models;

namespace DataService.Services
{
    public class BIDataService : IDataService
    {
        private readonly BIContext _context;
        public BIDataService(BIContext context)
        {
            _context = context ?? throw new ArgumentNullException(nameof(context));
        }

        public void AddWatchlistWord(string word)
        {
            if (_context.WatchList.Select(x => x.Word.Equals(word)).ToList().Any() == false)
            {
                var watchListEntity = new WatchListEntity()
                {
                    Word = word
                };
                _context.WatchList.Add(watchListEntity);
                _context.SaveChanges();
            }
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
            var result = new Domain.Models.UniqueWordsEntity() { Count = Dictionary.Count };
            _context.UniqueWords.Add(result);
            _context.SaveChanges();

            Console.WriteLine($"Runtime : {runtimeInTicks} Ticks");

            return result.Count;
        }
    }
}
