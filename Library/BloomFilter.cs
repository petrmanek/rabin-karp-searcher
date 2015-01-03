using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RabinKarpSearcher
{
    public sealed class BloomFilter<T>
    {
        private int TrueBits { get; set; }
        private BitArray Bits { get; set; }

        /// <summary>
        /// Number of added to into the filter.
        /// </summary>
        public int Count { get; private set; }

        /// <summary>
        /// Number of bits in the filter.
        /// </summary>
        public int ArraySize { get; private set; }

        /// <summary>
        /// Number of hash functions.
        /// </summary>
        public int HashFunctionCount { get; private set; }

        /// <summary>
        /// Hash function used for double hashing.
        /// </summary>
        public HashFunction SecondaryHashFunction { get; private set; }

        /// <summary>
        /// Initializes new filter with optimal parameters and populates it with given collection.
        /// </summary>
        /// <param name="items">The items to populate the filter with.</param>
        public BloomFilter(ICollection<T> items, HashFunction function)
            : this(items.Count, function)
        {
            AddRange(items);
        }

        /// <summary>
        /// Initializes new filter with optimal error rate for the given capacity.
        /// </summary>
        /// <param name="capacity"></param>
        public BloomFilter(int capacity, HashFunction function)
            : this(capacity, GetOptimalError(capacity), function)
        { }

        /// <summary>
        /// Initializes new filter with optimal size and hash functions for the given capacity and error rate.
        /// </summary>
        /// <param name="capacity">The expected number of elements in the filter.</param>
        /// <param name="error">The desired probability of false positives.</param>
        public BloomFilter(int capacity, double error, HashFunction function)
            : this(GetOptimalArraySize(capacity, error), GetOptimalHashFunctions(capacity, error), function)
        { }

        /// <summary>
        /// Initializes new filter with raw arguments.
        /// </summary>
        /// <param name="arraySize">The number of bits (referred to as m).</param>
        /// <param name="hashFunctionCount">The number of hash functions (referred to as k).</param>
        public BloomFilter(int arraySize, int hashFunctionCount, HashFunction function)
        {
            this.Count = 0;
            this.TrueBits = 0;

            this.Bits = new BitArray(arraySize);
            this.ArraySize = arraySize;
            this.HashFunctionCount = hashFunctionCount;

            this.SecondaryHashFunction = function;
        }

        #region "Cited Code - Estimates and Optimalizations"
        private static double GetOptimalError(int capacity)
        {
            // Starobinski, David; Trachtenberg, Ari; Agarwal, Sachin (2003), "Efficient PDA Synchronization", IEEE Transactions on Mobile Computing 2 (1): 40, doi:10.1109/TMC.2003.1195150
            return 1.0 / (double)capacity;
        }

        private static int GetOptimalArraySize(int capacity, double error)
        {
            // Starobinski, David; Trachtenberg, Ari; Agarwal, Sachin (2003), "Efficient PDA Synchronization", IEEE Transactions on Mobile Computing 2 (1): 40, doi:10.1109/TMC.2003.1195150
            return (int)Math.Ceiling(capacity * Math.Log(error, (1.0 / Math.Pow(2, Math.Log(2.0)))));
        }

        private static int GetOptimalHashFunctions(int capacity, double error)
        {
            // Starobinski, David; Trachtenberg, Ari; Agarwal, Sachin (2003), "Efficient PDA Synchronization", IEEE Transactions on Mobile Computing 2 (1): 40, doi:10.1109/TMC.2003.1195150
            return (int)Math.Round(Math.Log(2.0) * GetOptimalArraySize(capacity, error) / capacity);
        }

        private int ComputeDoubleHash(int primary, int secondary, int offset)
        {
            // Dillinger-Manolios Formula
            int hash = (primary + offset * secondary) % ArraySize;
            return (int)Math.Abs(hash);
        }

        /// <summary>
        /// Computes current probability of false positives.
        /// </summary>
        /// <returns>Zero means no false positives at all, one means false positives all the time.</returns>
        public double GetError()
        {
            // Mitzenmacher, Michael; Upfal, Eli (2005), Probability and computing: Randomized algorithms and probabilistic analysis, Cambridge University Press, pp. 107–112, ISBN 9780521835404
            return Math.Pow(1.0 - Math.Pow(1.0 - 1.0 / (double)ArraySize, (double)HashFunctionCount * (double)Count), (double)HashFunctionCount);
        }

        public delegate int HashFunction(T input);

        /// <summary>
        /// Recommended hash function for UInt32.
        /// </summary>
        /// <param name="x">UInt32 to hash.</param>
        /// <returns>Hash of the argument.</returns>
        public static int RecommendedUInt32HashFunction(uint x)
        {
            // Integer hash function from http://www.concentric.net/~Ttwang/tech/inthash.htm
            unchecked
            {
                x = ~x + (x << 15); // x = (x << 15) - x- 1, as (~x) + y is equivalent to y - x - 1 in two's complement representation
                x = x ^ (x >> 12);
                x = x + (x << 2);
                x = x ^ (x >> 4);
                x = x * 2057; // x = (x + (x << 3)) + (x<< 11);
                x = x ^ (x >> 16);
                return (int)x;
            }
        }
        #endregion

        /// <summary>
        /// Adds the item into the filter.
        /// </summary>
        /// <param name="item">The item to add.</param>
        public void Add(T item)
        {
            // Item added
            ++Count;

            // Compute hashes
            int primary = item.GetHashCode();
            int secondary = SecondaryHashFunction(item);

            // Flip the bits
            for (int i = 0; i < HashFunctionCount; ++i)
            {
                int hash = ComputeDoubleHash(primary, secondary, i);

                if (!Bits[hash]) ++TrueBits;
                Bits[hash] = true;
            }
        }

        /// <summary>
        /// Convenience method to add many items at once.
        /// </summary>
        /// <param name="items">The items to add.</param>
        public void AddRange(IEnumerable<T> items)
        {
            foreach (var item in items)
                Add(item);
        }

        /// <summary>
        /// Checks whether the item is contained in the filter.
        /// </summary>
        /// <param name="item">The item to check.</param>
        /// <returns>False if the item is definitely not in the filter. True if the item might be in the filter.</returns>
        public bool Contains(T item)
        {
            // Compute hashes
            int primary = item.GetHashCode();
            int secondary = SecondaryHashFunction(item);

            for (int i = 0; i < HashFunctionCount; i++)
            {
                int hash = ComputeDoubleHash(primary, secondary, i);

                // At least one zero means the item is definitely not in the filter
                if (!Bits[hash])
                    return false;
            }

            // All ones means the item might be in the filter
            return true;
        }

        /// <summary>
        /// The 'truthiness' of the filter.
        /// </summary>
        /// <returns>Ratio of bits with value 1 to the number of bits in the filter.</returns>
        public double GetRatio()
        {
            return (double)TrueBits / (double)ArraySize;
        }
    }
}
