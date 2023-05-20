

namespace DataService.Interfaces
{
    public interface IDataService
    {
        public string[] GetUniqueWords(string paragraphs);
        public string[] GetWatchlistWords(string[] words);
        public void AddWatchlistWord(string word);
    }
}
