using RabinKarpSearcher;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tests
{
    public static class Utils
    {
        public static ICollection<int> Search(IEnumerable<string> needles, string haystack, uint len)
        {
            var searcher = new RabinKarpSearcher<char>(len, new ASCIIHashFunction(101, len));
            searcher.AddNeedles(needles.Select(n => n.ToCharArray()));

            return searcher.Search(haystack.ToList());
        }
    }
}
