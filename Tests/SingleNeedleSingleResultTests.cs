using System;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Tests
{
    [TestClass]
    public class SingleNeedleSingleResultTests
    {
        [TestMethod]
        public void TestSingleResultShortHaystackShortNeedleAtStart()
        {
            var needles = new string[] { "as" };
            var haystack = "asidoioji";
            var results = Utils.Search(needles, haystack, 2);
            Assert.AreEqual(1, results.Count);
            Assert.AreEqual(0, results.First());
        }

        [TestMethod]
        public void TestSingleResultShortHaystackShortNeedleInMiddle()
        {
            var needles = new string[] { "do" };
            var haystack = "asidoioji";
            var results = Utils.Search(needles, haystack, 2);
            Assert.AreEqual(1, results.Count);
            Assert.AreEqual(3, results.First());
        }

        [TestMethod]
        public void TestSingleResultShortHaystackShortNeedleAtEnd()
        {
            var needles = new string[] { "ji" };
            var haystack = "asidoioji";
            var results = Utils.Search(needles, haystack, 2);
            Assert.AreEqual(1, results.Count);
            Assert.AreEqual(7, results.First());
        }

        [TestMethod]
        public void TestSingleResultLongHaystackShortNeedleAtStart()
        {
            var needles = new string[] { "bu" };
            var haystack = "bujdkomdomaskdmqoioasmcaokxasmdkoqmdoiamcsoamsodkmkqwomkmxsoqmoqkmdoidjciosjcasodjwdmisoa";
            var results = Utils.Search(needles, haystack, 2);
            Assert.AreEqual(1, results.Count);
            Assert.AreEqual(0, results.First());
        }

        [TestMethod]
        public void TestSingleResultLongHaystackShortNeedleInMiddle()
        {
            var needles = new string[] { "bu" };
            var haystack = "asioxjaiofhuisdfhniascuisdnciouhiuwexdibuxdioanfxiuawefxiuoxaweifoaxnaweinxawieufxhnaweui";
            var results = Utils.Search(needles, haystack, 2);
            Assert.AreEqual(1, results.Count);
            Assert.AreEqual(39, results.First());
        }

        [TestMethod]
        public void TestSingleResultLongHaystackShortNeedleAtEnd()
        {
            var needles = new string[] { "bu" };
            var haystack = "asioxjaiofhuisdfhniascuisdnciouhiuwexdiwhxdioanfxiuawefxiuoxaweifoaxnaweinxawieufxhnawebu";
            var results = Utils.Search(needles, haystack, 2);
            Assert.AreEqual(1, results.Count);
            Assert.AreEqual(87, results.First());
        }

        [TestMethod]
        public void TestSingleResultShortHaystackLongNeedleAtStart()
        {
            var needles = new string[] { "this is a really long needle" };
            var haystack = "this is a really long needlekokasmioj";
            var results = Utils.Search(needles, haystack, 28);
            Assert.AreEqual(1, results.Count);
            Assert.AreEqual(0, results.First());
        }

        [TestMethod]
        public void TestSingleResultShortHaystackLongNeedleInMiddle()
        {
            var needles = new string[] { "this is a really long needle" };
            var haystack = "kokathis is a really long needlesmioj";
            var results = Utils.Search(needles, haystack, 28);
            Assert.AreEqual(1, results.Count);
            Assert.AreEqual(4, results.First());
        }

        [TestMethod]
        public void TestSingleResultShortHaystackLongNeedleAtEnd()
        {
            var needles = new string[] { "this is a really long needle" };
            var haystack = "kokasmiojthis is a really long needle";
            var results = Utils.Search(needles, haystack, 28);
            Assert.AreEqual(1, results.Count);
            Assert.AreEqual(9, results.First());
        }

        [TestMethod]
        public void TestSingleResultLongHaystackLongNeedleAtStart()
        {
            var needles = new string[] { "this is a really long needle" };
            var haystack = "this is a really long needleasioxjaiofhuisdfhniascuisdnciouhiuwexdiwhxdioanfxiuawefxiuoxaweifoaxnaweinxawieufxhnaweui";
            var results = Utils.Search(needles, haystack, 28);
            Assert.AreEqual(1, results.Count);
            Assert.AreEqual(0, results.First());
        }

        [TestMethod]
        public void TestSingleResultLongHaystackLongNeedleInMiddle()
        {
            var needles = new string[] { "this is a really long needle" };
            var haystack = "asioxjaiofhuisdfhniascuisdnciouhiuwexdthis is a really long needleiwhxdioanfxiuawefxiuoxaweifoaxnaweinxawieufxhnaweui";
            var results = Utils.Search(needles, haystack, 28);
            Assert.AreEqual(1, results.Count);
            Assert.AreEqual(38, results.First());
        }

        [TestMethod]
        public void TestSingleResultLongHaystackLongNeedleAtEnd()
        {
            var needles = new string[] { "this is a really long needle" };
            var haystack = "asioxjaiofhuisdfhniascuisdnciouhiuwexdiwhxdioanfxiuawefxiuoxaweifoaxnaweinxawieufxhnaweuithis is a really long needle";
            var results = Utils.Search(needles, haystack, 28);
            Assert.AreEqual(1, results.Count);
            Assert.AreEqual(89, results.First());
        }
    }
}
