using DataService.Interfaces;
using System.Collections.Concurrent;
using System.Reflection.Metadata.Ecma335;

namespace DataService.Handlers.UniqueWords
{
    public class ParallelHandler : IUniqueWordsHandler
    {
        public string[] GetUniqueWords(string data)
        {
            var words = data.Split(Constants.Chars);
            var Dictionary = new ConcurrentDictionary<string, int>();

            Parallel.For(0, words.Length, index =>
            {
                var word = words[index];
                if (String.IsNullOrEmpty(word) == false)
                {
                    if (Dictionary.ContainsKey(word))
                    {
                        Dictionary[word]++;
                    }
                    else
                    {
                        Dictionary.AddOrUpdate(word, 1, (key, oldValue) => oldValue + 1);
                    }
                }
            });
            return Dictionary.Keys.ToArray();
        }
    }
}