using DataService.Interfaces;

namespace DataService.Handlers.UniqueWords
{
    public class SequentialHandler : IUniqueWordsHandler
    {
        public string[] GetUniqueWords(string data)
        {
            var words = data.Split(new char[] { ' ', '\r', '\n' });
            var Dictionary = new Dictionary<string, int>();

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
            return Dictionary.Keys.ToArray();   
        }
    }
}