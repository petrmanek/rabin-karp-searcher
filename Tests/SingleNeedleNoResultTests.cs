using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Tests
{
    [TestClass]
    public class SingleNeedleNoResultTests
    {
        [TestMethod]
        public void TestNoResultsShortHaystackShortNeedle()
        {
            var needles = new string[] { "bu" };
            var haystack = "asidoioji";
            var results = Utils.Search(needles, haystack, 2);
            Assert.AreEqual(0, results.Count);
        }

        [TestMethod]
        public void TestNoResultsLongHaystackShortNeedle()
        {
            var needles = new string[] { "bu" };
            var haystack = "asjdkomdomaskdmqoioasmcaokxasmdkoqmdoiamcsoamsodkmkqwomkmxsoqmoqkmdoidjciosjcasodjwdmisoa";
            var results = Utils.Search(needles, haystack, 2);
            Assert.AreEqual(0, results.Count);
        }

        [TestMethod]
        public void TestNoResultsShortHaystackLongNeedle()
        {
            var needles = new string[] { "this is a really long needle" };
            var haystack = "kokasmioj";
            var results = Utils.Search(needles, haystack, 28);
            Assert.AreEqual(0, results.Count);
        }

        [TestMethod]
        public void TestNoResultsLongHaystackLongNeedle()
        {
            var needles = new string[] { "this is a really long needle" };
            var haystack = "asioxjaiofhuisdfhniascuisdnciouhiuwexdiwhxdioanfxiuawefxiuoxaweifoaxnaweinxawieufxhnaweui";
            var results = Utils.Search(needles, haystack, 28);
            Assert.AreEqual(0, results.Count);
        }
    }
}
