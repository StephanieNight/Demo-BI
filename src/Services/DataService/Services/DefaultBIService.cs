using DataAccess;
using DataService.Interfaces;
using Models;

namespace DataService.Services
{
    public class DefaultBIService : IDataService
    {
        private readonly BIContext _context;
        private readonly IUniqueWordsHandler _uniqueWordsHandler ;
        public DefaultBIService(
            BIContext context,
            IUniqueWordsHandler uniqueWordsHandler
            )
        {
            _context = context ?? throw new ArgumentNullException(nameof(context));
            _uniqueWordsHandler = uniqueWordsHandler ?? throw new ArgumentNullException(nameof(uniqueWordsHandler));
        }

        public void AddWatchlistWord(string word)
        {
            word = word.ToLower();
            if (_context.WatchList.Where(x => x.Word.Equals(word)).ToList().Any() == false)
            {
                var watchListEntity = new WatchListEntity()
                {
                    Word = word
                };
                _context.WatchList.Add(watchListEntity);
                _context.SaveChanges();
            }
        }

        public string[] GetUniqueWords(string paragraphs)
        {
           var result = _uniqueWordsHandler.GetUniqueWords(paragraphs);
           var entity = new Domain.Models.UniqueWordsEntity() { Count = result.Length };
            _context.UniqueWords.Add(entity);
            _context.SaveChanges();

            return result;
        }

        public string[] GetWatchlistWords(string[] words)
        {
            return _context.WatchList.Where(x => words.Contains(x.Word)).Select(x => x.Word).ToArray();
        }
    }
}
