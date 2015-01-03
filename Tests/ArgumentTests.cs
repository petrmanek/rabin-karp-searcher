using System;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using RabinKarpSearcher;

namespace Tests
{
    [TestClass]
    public class ArgumentTests
    {
        [TestMethod, ExpectedException(typeof(ArgumentNullException))]
        public void TestNullHashFunction()
        {
            var needles = new string[] { "bu" };
            var haystack = "Lorem ipsum haystack";

            var searcher = new RabinKarpSearcher<char>(2, null);
            searcher.AddNeedles(needles.Select(n => n.ToCharArray()));

            var results = searcher.Search(haystack.ToList());
        }

        [TestMethod, ExpectedException(typeof(ArgumentOutOfRangeException))]
        public void TestMismatchingNeedleLength()
        {
            var needles = new string[] { "bu" };
            var haystack = "Lorem ipsum haystack";

            var searcher = new RabinKarpSearcher<char>(2, new ASCIIHashFunction(101, 5));
            searcher.AddNeedles(needles.Select(n => n.ToCharArray()));

            var results = searcher.Search(haystack.ToList());
        }

        [TestMethod]
        public void TestNoAddNeedlesCall()
        {
            var needles = new string[] { "bu" };
            var haystack = "Lorem ipsum haystack";

            var searcher = new RabinKarpSearcher<char>(2, new ASCIIHashFunction(101, 2));
            var results = searcher.Search(haystack.ToList());
            Assert.AreEqual(0, results.Count);
        }

        [TestMethod, ExpectedException(typeof(ArgumentNullException))]
        public void TestNullNeedle()
        {
            var needles = new string[] { "bu" };
            var haystack = "Lorem ipsum haystack";

            var searcher = new RabinKarpSearcher<char>(2, new ASCIIHashFunction(101, 2));
            searcher.AddNeedle(null);

            var results = searcher.Search(haystack.ToList());
        }

        [TestMethod, ExpectedException(typeof(ArgumentNullException))]
        public void TestNullNeedleCollection()
        {
            var needles = new string[] { "bu" };
            var haystack = "Lorem ipsum haystack";

            var searcher = new RabinKarpSearcher<char>(2, new ASCIIHashFunction(101, 2));
            searcher.AddNeedles(null);

            var results = searcher.Search(haystack.ToList());
        }

        [TestMethod, ExpectedException(typeof(ArgumentNullException))]
        public void TestNullHaystack()
        {
            var needles = new string[] { "bu" };
            var haystack = "Lorem ipsum haystack";

            var searcher = new RabinKarpSearcher<char>(2, new ASCIIHashFunction(101, 2));
            searcher.AddNeedles(needles.Select(n => n.ToCharArray()));

            var results = searcher.Search(null);
        }

        [TestMethod]
        public void TestEmptyNeedles()
        {
            var needles = new string[] { };
            var haystack = "Lorem ipsum haystack";
            var results = Utils.Search(needles, haystack, 42);
            Assert.AreEqual(0, results.Count);
        }

        [TestMethod]
        public void TestEmptyHaystack()
        {
            var needles = new string[] { "hello" };
            var haystack = string.Empty;
            var results = Utils.Search(needles, haystack, 5);
            Assert.AreEqual(0, results.Count);
        }

        [TestMethod]
        public void TestEmptyNeedlesAndHaystack()
        {
            var needles = new string[] { };
            var haystack = string.Empty;
            var results = Utils.Search(needles, haystack, 42);
            Assert.AreEqual(0, results.Count);
        }

        [TestMethod, ExpectedException(typeof(ArgumentException))]
        public void TestWrongLengthNeedle()
        {
            var needles = new string[] { "hello" };
            var haystack = "Lorem ipsum haystack";
            var results = Utils.Search(needles, haystack, 42);
            Assert.AreEqual(0, results.Count);
        }
    }
}
