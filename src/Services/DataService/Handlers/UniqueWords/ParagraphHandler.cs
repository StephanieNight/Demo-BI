using DataService.Interfaces;
using System.Collections.Concurrent;

namespace DataService.Handlers.UniqueWords
{
    public class ParagraphHandler : IUniqueWordsHandler
    {
        public string[] GetUniqueWords(string data)
        {
            var paragraphs = data.Split("\r\n\r\n");

            var Dictionary = new ConcurrentDictionary<string, int>();

            Parallel.For(0, paragraphs.Length, index =>
            {
                var paragraph = paragraphs[index];
                if (String.IsNullOrEmpty(paragraph) == false)
                {
                    var words = paragraph.Split(Constants.Chars);
                    foreach (var word in words)
                    {
                        if (String.IsNullOrEmpty(word) == false)
                        {
                            var lowerword = word.Trim().ToLower();
                            Dictionary.AddOrUpdate(lowerword, 1, (key, oldValue) => oldValue + 1);
                        }
                    }
                }
            });
            return Dictionary.Keys.ToArray();
        }
    }
}