using DataService.Interfaces;

namespace DataService.Handlers.UniqueWords
{
    public class SequentialHandler : IUniqueWordsHandler
    {
        public string[] GetUniqueWords(string data)
        {
            var words = data.Split(Constants.Chars);
            var Dictionary = new Dictionary<string, int>();

            foreach (var word in words)
            {
                var lowerword = word.Trim().ToLower();
                if (Dictionary.ContainsKey(lowerword))
                {
                    Dictionary[lowerword]++;
                }
                else
                {
                    Dictionary.Add(lowerword, 1);
                }
            }
            return Dictionary.Keys.ToArray();   
        }
    }
}