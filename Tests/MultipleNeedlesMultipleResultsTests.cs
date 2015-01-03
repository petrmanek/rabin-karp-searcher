using System;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Tests
{
    [TestClass]
    public class MultipleNeedlesMultipleResultsTests
    {
        [TestMethod]
        public void TestMultipleResultsShortHaystackShortNeedles()
        {
            var needles = new string[] { "kl", "as", "mu" };
            var haystack = "asimuiokl";
            var results = Utils.Search(needles, haystack, 2);
            Assert.AreEqual(3, results.Count);
            Assert.AreEqual(0, results.ElementAt(0));
            Assert.AreEqual(3, results.ElementAt(1));
            Assert.AreEqual(7, results.ElementAt(2));
        }

        [TestMethod]
        public void TestMultipleResultsLongHaystackShortNeedles()
        {
            var needles = new string[] { "mu", "bu", "kl" };
            var haystack = "bujdkomdomaskdmqoioasklaokxasmdkoqmuoiamcsoamsodkmkqwmukmxsoqmoqkmdoidjciosjcasodjwdmismu";
            var results = Utils.Search(needles, haystack, 2);
            Assert.AreEqual(5, results.Count);
            Assert.AreEqual(0, results.ElementAt(0));
            Assert.AreEqual(21, results.ElementAt(1));
            Assert.AreEqual(34, results.ElementAt(2));
            Assert.AreEqual(53, results.ElementAt(3));
            Assert.AreEqual(87, results.ElementAt(4));
        }

        [TestMethod]
        public void TestMultipleResultsShortHaystackLongNeedles()
        {
            var needles = new string[] { "this is a really long needle", "this is a really cute needle", "this is a really cool needle" };
            var haystack = "this is a really long needlekokathis is a really cool needlesmiojthis is a really cute needle";
            var results = Utils.Search(needles, haystack, 28);
            Assert.AreEqual(3, results.Count);
            Assert.AreEqual(0, results.ElementAt(0));
            Assert.AreEqual(32, results.ElementAt(1));
            Assert.AreEqual(65, results.ElementAt(2));
        }

        [TestMethod]
        public void TestMultipleResultsLongHaystackLongNeedles()
        {
            var needles = new string[] { "this is a really long needle", "this is a really cute needle", "this is a really cool needle" };
            var haystack = "this is a really long needlekasdklfmwkjfjghfasdklfmwkjfjghfasdklfmwkjfjghfokathis is a really cool needlesmiojklfmwkjfjghfasdklfmwklfmwkjfjghfasdklfmwklfmwkjfjghfasdklfmwthis is a really cute needle";
            var results = Utils.Search(needles, haystack, 28);
            Assert.AreEqual(3, results.Count);
            Assert.AreEqual(0, results.ElementAt(0));
            Assert.AreEqual(77, results.ElementAt(1));
            Assert.AreEqual(170, results.ElementAt(2));
        }
    }
}
