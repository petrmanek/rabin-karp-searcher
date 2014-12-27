using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RabinKarpSearcher
{
    /// <summary>
    /// Implementation of prime-based rolling hash function for ASCII strings.
    /// </summary>
    public sealed class ASCIIHashFunction : IRollingHashFunction<char>
    {
        public uint BasePrime { get; private set; }
        public uint WindowSize { get; private set; }

        /// <summary>
        /// Initializes new ASCII hash function with given parameters.
        /// </summary>
        /// <param name="basePrime">Prime number to base hashes on.</param>
        /// <param name="windowSize">Hash window size for validation purposes.</param>
        public ASCIIHashFunction(uint basePrime, uint windowSize)
        {
            this.BasePrime = basePrime;
            this.WindowSize = windowSize;
        }

        public uint Roll(uint hash, char prev, char next)
        {
            return (BasePrime * (hash - ((uint)Math.Pow(BasePrime, WindowSize - 1) * (uint)prev))) + (uint)Math.Pow(BasePrime, 0) * (uint)next;
        }

        public uint Initialize(IList<char> list)
        {
            if (list.Count != WindowSize)
                throw new ArgumentException("Expected collection of size equal to WindowSize.");

            uint hash = 0;
            for (int i = 0; i < list.Count; ++i)
                hash += (uint)Math.Pow(BasePrime, WindowSize - i - 1) * (uint)list[i];

            return hash;
        }
    }
}
