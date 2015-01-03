using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RabinKarpSearcher
{
    /// <summary>
    /// Implementation of Rabin-Karp searching algorithm.
    /// </summary>
    /// <typeparam name="T">Unit from which search needles are comprised.</typeparam>
    public sealed class RabinKarpSearcher<T> : RabinKarpSearcher.ISequenceSearcher<T> where T : IEquatable<T>
    {
        public uint NeedleLength { get; private set; }
        public IRollingHashFunction<T> HashFunction { get; private set; }

        private List<List<T>> Needles { get; set; }

        /// <summary>
        /// Initializes new searcher with given parameters.
        /// </summary>
        /// <param name="needleLength">The uniform length of all needles.</param>
        /// <param name="function">The function used to hash needles.</param>
        public RabinKarpSearcher(uint needleLength, IRollingHashFunction<T> function)
        {
            this.NeedleLength = needleLength;
            this.Needles = new List<List<T>>();
            this.HashFunction = function;
        }

        public void AddNeedle(ICollection<T> needle)
        {
            if (needle == null)
                throw new ArgumentNullException("needle");
            else if (needle.Count != NeedleLength)
                throw new ArgumentException("Expected string of length equal to NeedleLength.");

            Needles.Add(needle.ToList());
        }

        public void AddNeedles(IEnumerable<ICollection<T>> needles)
        {
            if (needles == null)
                throw new ArgumentNullException("needles");

            foreach (var needle in needles)
                AddNeedle(needle);
        }

        public void RemoveNeedle(ICollection<T> needle)
        {
            if (needle == null)
                throw new ArgumentNullException("needle");
            else if (needle.Count != NeedleLength)
                throw new ArgumentException("Expected string of length equal to NeedleLength.");

            Needles.Remove(needle.ToList());
        }

        public void ClearNeedles()
        {
            Needles.Clear();
        }

        public ICollection<int> Search(List<T> haystack)
        {
            return SearchInternal(haystack, false);
        }

        public bool HasAnyOccurences(List<T> haystack)
        {
            return SearchInternal(haystack, true).Count > 0;
        }

        private ICollection<int> SearchInternal(List<T> haystack, bool stopAtFirst)
        {
            if (haystack == null)
                throw new ArgumentNullException("haystack");

            // If the haystack is shorter than needle length, there will surely be no occurences.
            var occurences = new List<int>();
            if (haystack.Count < NeedleLength || !Needles.Any())
                return occurences;

            // Otherwise, create a Bloom filter with needle hashes
            var needles = Needles.Select(n => HashFunction.Initialize(n.ToList())).Distinct().ToList();
            var needleHashes = new BloomFilter<uint>(needles, BloomFilter<uint>.RecommendedUInt32HashFunction);
            var windowHash = HashFunction.Initialize(haystack.Take((int)NeedleLength).ToList());

            // Move window the size of a needle over entire haystack
            for (int i = (int)NeedleLength; i <= haystack.Count; ++i)
            {
                if (needleHashes.Contains(windowHash))
                {
                    // If hashes match, do a deep comparison
                    foreach (var needle in Needles)
                    {
                        // For each needle, compare sequences element by element
                        bool match = true;
                        for (int j = 0; j < NeedleLength; ++j)
                        {
                            if (!needle[j].Equals(haystack[i - (int)NeedleLength + j]))
                            {
                                // Call it off if any of the elements differs
                                match = false;
                                break;
                            }
                        }

                        if (match)
                        {
                            // If the elements match, we've found ourselves a needle
                            occurences.Add(i - (int)NeedleLength);

                            if (stopAtFirst) return occurences;
                            else break;
                        }
                    }
                }

                if (i < haystack.Count)
                {
                    // Roll the hash
                    var prev = haystack[i - (int)NeedleLength];
                    var next = haystack[i];

                    windowHash = HashFunction.Roll(windowHash, prev, next);
                }
            }

            return occurences;
        }
    }
}
