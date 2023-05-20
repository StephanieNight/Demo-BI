using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataService.Interfaces
{
    public interface IDataHandler
    {
        public int GetUniqueWordCount(string data);
        public string[] GetwordsOnWatchList(string data);
    }
}
