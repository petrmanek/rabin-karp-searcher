using System;
namespace RabinKarpSearcher
{
    /// <summary>
    /// Represents a generic sequential search utility for lists.
    /// </summary>
    /// <typeparam name="T">The type of units from which search needles are composed.</typeparam>
    interface ISequenceSearcher<T>
     where T : IEquatable<T>
    {
        /// <summary>
        /// The uniform size of all needle sequences.
        /// </summary>
        uint NeedleLength { get; }

        /// <summary>
        /// Adds a needle for searching.
        /// </summary>
        /// <param name="needle">Sequence of elements to search for.</param>
        void AddNeedle(System.Collections.Generic.ICollection<T> needle);

        /// <summary>
        /// Adds many needles.
        /// </summary>
        /// <param name="needles">Collection of needles</param>
        void AddNeedles(System.Collections.Generic.IEnumerable<System.Collections.Generic.ICollection<T>> needles);

        /// <summary>
        /// Removes all needles.
        /// </summary>
        void ClearNeedles();

        /// <summary>
        /// Searches the haystack and breaks at the first occurence of a needle or the end.
        /// </summary>
        /// <param name="haystack">The haystack to search.</param>
        /// <returns>True if there is any needle inside the haystack.</returns>
        bool HasAnyOccurences(System.Collections.Generic.List<T> haystack);

        /// <summary>
        /// Removes a specific needle from the search.
        /// </summary>
        /// <param name="needle">The needle to remove.</param>
        void RemoveNeedle(System.Collections.Generic.ICollection<T> needle);

        /// <summary>
        /// Searches for the needles in the haystack.
        /// </summary>
        /// <param name="haystack">A big collection to search for needles.</param>
        /// <returns>Starting indices of found needles.</returns>
        System.Collections.Generic.ICollection<int> Search(System.Collections.Generic.List<T> haystack);
    }
}
