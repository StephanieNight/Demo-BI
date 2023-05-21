using DataAccess;
using DataService.Handlers.UniqueWords;
using Models;

namespace DataService.Services.BIServices
{
    public class HashedBIService : BaseService
    {
        public HashedBIService(BIContext context) : base(context, new ParagraphHandler()) { }

        public override string[] GetUniqueWords(string paragraphs)
        {
            var hash = paragraphs.GetHashCode();
            var databaseResult = _context.HashedUniqueWords.Where(x => x.Hash == hash).Select(x => x.Words).FirstOrDefault();
            if (databaseResult != null)
            {
                return databaseResult.Split(',');
            }

            var result = _uniqueWordsHandler.GetUniqueWords(paragraphs);
            var entity = new HashedUniqueWordsEntitiy()
            {
                Count = result.Length,
                Hash = hash,
                Words = string.Join(',', result)
            };

            _context.HashedUniqueWords.Add(entity);
            _context.SaveChanges();

            return result;
        }
    }
}