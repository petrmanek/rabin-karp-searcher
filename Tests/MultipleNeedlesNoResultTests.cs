using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Tests
{
    [TestClass]
    public class MultipleNeedlesNoResultTests
    {
        [TestMethod]
        public void TestNoResultsShortHaystackShortNeedles()
        {
            var needles = new string[] { "bu", "kl", "mu" };
            var haystack = "asidoioji";
            var results = Utils.Search(needles, haystack, 2);
            Assert.AreEqual(0, results.Count);
        }

        [TestMethod]
        public void TestNoResultsLongHaystackShortNeedles()
        {
            var needles = new string[] { "bu", "kl", "mu" };
            var haystack = "asjdkomdomaskdmqoioasmcaokxasmdkoqmdoiamcsoamsodkmkqwomkmxsoqmoqkmdoidjciosjcasodjwdmisoa";
            var results = Utils.Search(needles, haystack, 2);
            Assert.AreEqual(0, results.Count);
        }

        [TestMethod]
        public void TestNoResultsShortHaystackLongNeedles()
        {
            var needles = new string[] { "this is a really long needle", "this is a really cute needle", "this is a really cool needle" };
            var haystack = "kokasmioj";
            var results = Utils.Search(needles, haystack, 28);
            Assert.AreEqual(0, results.Count);
        }

        [TestMethod]
        public void TestNoResultsLongHaystackLongNeedles()
        {
            var needles = new string[] { "this is a really long needle", "this is a really cute needle", "this is a really cool needle" };
            var haystack = "asioxjaiofhuisdfhniascuisdnciouhiuwexdiwhxdioanfxiuawefxiuoxaweifoaxnaweinxawieufxhnaweui";
            var results = Utils.Search(needles, haystack, 28);
            Assert.AreEqual(0, results.Count);
        }
    }
}
