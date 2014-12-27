using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RabinKarpSearcher
{
    /// <summary>
    /// Represents a rolling hash function.
    /// </summary>
    /// <typeparam name="T">A type of unit the hash rolls over.</typeparam>
    public interface IRollingHashFunction<T>
    {
        /// <summary>
        /// Computes hash for collection of elements.
        /// </summary>
        /// <param name="list">The elements to compute hash for.</param>
        /// <returns>The hash of the given collection.</returns>
        uint Initialize(IList<T> list);

        /// <summary>
        /// Rolls any given hash forward one element.
        /// </summary>
        /// <param name="hash">The hash to start from.</param>
        /// <param name="prev">The element to remove.</param>
        /// <param name="next">The element to append.</param>
        /// <returns>The hash of collection without the first element and with 'next' appended at the end.</returns>
        uint Roll(uint hash, T prev, T next);
    }
}
