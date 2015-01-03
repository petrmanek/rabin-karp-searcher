using System;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Tests
{
    [TestClass]
    public class MultipleNeedlesSingleResultTests
    {
        [TestMethod]
        public void TestSingleResultShortHaystackShortNeedlesAtStart()
        {
            var needles = new string[] { "kl", "as", "mu" };
            var haystack = "asidoioji";
            var results = Utils.Search(needles, haystack, 2);
            Assert.AreEqual(1, results.Count);
            Assert.AreEqual(0, results.First());
        }

        [TestMethod]
        public void TestSingleResultShortHaystackShortNeedlesInMiddle()
        {
            var needles = new string[] { "do", "kl", "mu" };
            var haystack = "asidoioji";
            var results = Utils.Search(needles, haystack, 2);
            Assert.AreEqual(1, results.Count);
            Assert.AreEqual(3, results.First());
        }

        [TestMethod]
        public void TestSingleResultShortHaystackShortNeedlesAtEnd()
        {
            var needles = new string[] { "mu", "kl", "ji" };
            var haystack = "asidoioji";
            var results = Utils.Search(needles, haystack, 2);
            Assert.AreEqual(1, results.Count);
            Assert.AreEqual(7, results.First());
        }

        [TestMethod]
        public void TestSingleResultLongHaystackShortNeedlesAtStart()
        {
            var needles = new string[] { "mu", "bu", "kl" };
            var haystack = "bujdkomdomaskdmqoioasmcaokxasmdkoqmdoiamcsoamsodkmkqwomkmxsoqmoqkmdoidjciosjcasodjwdmisoa";
            var results = Utils.Search(needles, haystack, 2);
            Assert.AreEqual(1, results.Count);
            Assert.AreEqual(0, results.First());
        }

        [TestMethod]
        public void TestSingleResultLongHaystackShortNeedlesInMiddle()
        {
            var needles = new string[] { "kl", "mu", "bu" };
            var haystack = "asioxjaiofhuisdfhniascuisdnciouhiuwexdibuxdioanfxiuawefxiuoxaweifoaxnaweinxawieufxhnaweui";
            var results = Utils.Search(needles, haystack, 2);
            Assert.AreEqual(1, results.Count);
            Assert.AreEqual(39, results.First());
        }

        [TestMethod]
        public void TestSingleResultLongHaystackShortNeedlesAtEnd()
        {
            var needles = new string[] { "bu", "kl", "mu" };
            var haystack = "asioxjaiofhuisdfhniascuisdnciouhiuwexdiwhxdioanfxiuawefxiuoxaweifoaxnaweinxawieufxhnawebu";
            var results = Utils.Search(needles, haystack, 2);
            Assert.AreEqual(1, results.Count);
            Assert.AreEqual(87, results.First());
        }

        [TestMethod]
        public void TestSingleResultShortHaystackLongNeedlesAtStart()
        {
            var needles = new string[] { "this is a really long needle", "this is a really cute needle", "this is a really cool needle" };
            var haystack = "this is a really long needlekokasmioj";
            var results = Utils.Search(needles, haystack, 28);
            Assert.AreEqual(1, results.Count);
            Assert.AreEqual(0, results.First());
        }

        [TestMethod]
        public void TestSingleResultShortHaystackLongNeedlesInMiddle()
        {
            var needles = new string[] { "this is a really cool needle", "this is a really long needle", "this is a really cute needle" };
            var haystack = "kokathis is a really long needlesmioj";
            var results = Utils.Search(needles, haystack, 28);
            Assert.AreEqual(1, results.Count);
            Assert.AreEqual(4, results.First());
        }

        [TestMethod]
        public void TestSingleResultShortHaystackLongNeedlesAtEnd()
        {
            var needles = new string[] { "this is a really cute needle", "this is a really cool needle", "this is a really long needle" };
            var haystack = "kokasmiojthis is a really long needle";
            var results = Utils.Search(needles, haystack, 28);
            Assert.AreEqual(1, results.Count);
            Assert.AreEqual(9, results.First());
        }

        [TestMethod]
        public void TestSingleResultLongHaystackLongNeedlesAtStart()
        {
            var needles = new string[] { "this is a really long needle", "this is a really cute needle", "this is a really cool needle" };
            var haystack = "this is a really long needleasioxjaiofhuisdfhniascuisdnciouhiuwexdiwhxdioanfxiuawefxiuoxaweifoaxnaweinxawieufxhnaweui";
            var results = Utils.Search(needles, haystack, 28);
            Assert.AreEqual(1, results.Count);
            Assert.AreEqual(0, results.First());
        }

        [TestMethod]
        public void TestSingleResultLongHaystackLongNeedlesInMiddle()
        {
            var needles = new string[] { "this is a really cool needle", "this is a really long needle", "this is a really cute needle" };
            var haystack = "asioxjaiofhuisdfhniascuisdnciouhiuwexdthis is a really long needleiwhxdioanfxiuawefxiuoxaweifoaxnaweinxawieufxhnaweui";
            var results = Utils.Search(needles, haystack, 28);
            Assert.AreEqual(1, results.Count);
            Assert.AreEqual(38, results.First());
        }

        [TestMethod]
        public void TestSingleResultLongHaystackLongNeedlesAtEnd()
        {
            var needles = new string[] { "this is a really long needle", "this is a really cool needle", "this is a really cool needle" };
            var haystack = "asioxjaiofhuisdfhniascuisdnciouhiuwexdiwhxdioanfxiuawefxiuoxaweifoaxnaweinxawieufxhnaweuithis is a really long needle";
            var results = Utils.Search(needles, haystack, 28);
            Assert.AreEqual(1, results.Count);
            Assert.AreEqual(89, results.First());
        }
    }
}
