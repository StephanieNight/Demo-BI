

namespace DataService.Interfaces
{
    public interface IDataService
    {
        public int HandleData(string paragraphs);     
        public void AddWatchlistWord(string word);
    }
}
