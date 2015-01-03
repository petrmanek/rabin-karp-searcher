using System;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Tests
{
    [TestClass]
    public class SingleNeedleMultipleResultTests
    {
        [TestMethod]
        public void TestMultipleResultsShortHaystackShortNeedle()
        {
            var needles = new string[] { "as" };
            var haystack = "asidasoas";
            var results = Utils.Search(needles, haystack, 2);
            Assert.AreEqual(3, results.Count);
            Assert.AreEqual(0, results.ElementAt(0));
            Assert.AreEqual(4, results.ElementAt(1));
            Assert.AreEqual(7, results.ElementAt(2));
        }

        [TestMethod]
        public void TestMultipleResultsLongHaystackShortNeedle()
        {
            var needles = new string[] { "bu" };
            var haystack = "bujdkomdomaskdmqoioasmcaokxasmdbuqmdoiamcsoamsodkmkqwombuxsoqmoqkmdoidjciosjcasodjwdmisbu";
            var results = Utils.Search(needles, haystack, 2);
            Assert.AreEqual(4, results.Count);
            Assert.AreEqual(0, results.ElementAt(0));
            Assert.AreEqual(31, results.ElementAt(1));
            Assert.AreEqual(55, results.ElementAt(2));
            Assert.AreEqual(87, results.ElementAt(3));
        }

        [TestMethod]
        public void TestMultipleResultsShortHaystackLongNeedle()
        {
            var needles = new string[] { "this is a really long needle" };
            var haystack = "this is a really long needlekokasmiojthis is a really long needle";
            var results = Utils.Search(needles, haystack, 28);
            Assert.AreEqual(2, results.Count);
            Assert.AreEqual(0, results.ElementAt(0));
            Assert.AreEqual(37, results.ElementAt(1));
        }

        [TestMethod]
        public void TestMultipleResultsLongHaystackLongNeedle()
        {
            var needles = new string[] { "this is a really long needle" };
            var haystack = "this is a really long needleasioxjaiofhuisdfhniathis is a really long needlescuisdnciouhiuwexdiwhxdioanfxiuawefxiuoxaweifoaxnaweinxawieufxhnaweuithis is a really long needle";
            var results = Utils.Search(needles, haystack, 28);
            Assert.AreEqual(3, results.Count);
            Assert.AreEqual(0, results.ElementAt(0));
            Assert.AreEqual(48, results.ElementAt(1));
            Assert.AreEqual(145, results.ElementAt(2));
        }
    }
}
