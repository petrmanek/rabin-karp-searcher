using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RabinKarpSearcher
{
    class Program
    {
        /// <summary>
        /// A simple demonstration of the Rabin-Karp algorithm with Bloom filter.
        /// </summary>
        /// <param name="args">There are no arguments to set.</param>
        static void Main(string[] args)
        {
            // Header
            Console.WriteLine("Rabin-Karp Algorithm Demo 0.1");
            Console.WriteLine("(c) 2014 Petr Mánek, Charles University in Prague.");
            Console.WriteLine();
            
            // Read needle length
            int needleLength = 0;
            while (needleLength <= 0)
            {
                Console.Write("Enter length of needle: ");

                var lenString = Console.ReadLine();
                int.TryParse(lenString, out needleLength);
            }

            // Read needles
            Console.WriteLine("Enter needles on separate lines (use empty line to terminate):");
            var needles = new List<string>();
            string needle;

            while (!string.IsNullOrEmpty(needle = Console.ReadLine()))
            {
                if (needle.Length != needleLength)
                {
                    Console.WriteLine("WARNING: Needle skipped because its length is not equal to {0}.", needleLength);
                    continue;
                }

                if (needles.Contains(needle))
                {
                    Console.WriteLine("WARNING: Needle skipped because it has already been added to the collection.");
                    continue;
                }

                needles.Add(needle);
            }

            // Test Bloom filter
            Console.WriteLine("Got {0} {1}.", needles.Count, needles.Count == 1 ? "needle" : "needles");
            TestNeedleStorage(needles, needleLength);

            // Read haystack
            Console.Write("Enter haystack: ");
            var haystack = Console.ReadLine();

            var searcher = new RabinKarpSearcher<char>(6, new ASCIIHashFunction(101, 6));
            searcher.AddNeedles(needles.Select(n => n.ToCharArray()));

            var result = searcher.Search(haystack.ToList());
            if (result.Any())
            {
                Console.WriteLine("Found {0} {1} in haystack:", result.Count, result.Count == 1 ? "needle" : "needles");

                foreach (int pos in result)
                    Console.WriteLine("{0}\t{1}", pos, haystack.Substring(pos, 6));
            }
            else
            {
                Console.WriteLine("There are no needles in the haystack.");
            }
        }

        private static void TestNeedleStorage(List<string> needles, int needleLength)
        {
            var hashFunction = new ASCIIHashFunction(101, (uint)needleLength);
            var needleHashes = needles.Select(n => hashFunction.Initialize(n.ToList())).Distinct().ToList();
            var needleFilter = new BloomFilter<uint>(needleHashes, BloomFilter<uint>.RecommendedUInt32HashFunction);

            Console.WriteLine("Needle storage is a Bloom filter with optimized parameters:");
            Console.WriteLine("  - bit count: {0}", needleFilter.ArraySize);
            Console.WriteLine("  - hash function count: {0}", needleFilter.HashFunctionCount);
            Console.WriteLine("  - 1/0 ratio: {0}", needleFilter.GetRatio());
            Console.WriteLine("  - error rate: {0}", needleFilter.GetError());
            Console.WriteLine();
        }
    }
}
