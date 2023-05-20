using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataService.Interfaces
{
    internal interface IWatchlistHandler
    {
        public string[] GetwordsOnWatchList(string data);
    }
}
