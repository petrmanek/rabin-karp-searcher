using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Text;
using System.Linq;

namespace Tests
{
    [TestClass]
    public class AutomaticTests
    {
        private Random Random { get; set; }

        private char GetRandomNoiseChar()
        {
            var noiseChars = new char[] { 'a', 'b', 'c' };
            return noiseChars[Random.Next(0, noiseChars.Length)];
        }

        private string GetRandomNoise(int length)
        {
            var builder = new StringBuilder();

            for (int i = 0; i < length; ++i)
                builder.Append(GetRandomNoiseChar());

                return builder.ToString();
        }
        
        [TestInitialize]
        public void Setup()
        {
            Random = new Random(DateTime.Now.Second + DateTime.Now.Year);
        }

        [TestMethod]
        public void TestSingleNeedleNoResult()
        {
            var maxLength = 5000;
            var needleString = "klm";

            for (int length = 5; length < maxLength; ++length)
            {
                var testString = GetRandomNoise(length);

                var results = Utils.Search(new string[] { needleString }, testString, (uint)needleString.Length);
                Assert.AreEqual(0, results.Count);
            }
        }

        [TestMethod]
        public void TestSingleNeedleSingleResult()
        {
            var maxLength = 5000;
            var needleString = "klm";

            for (int length = 5; length < maxLength; ++length)
            {
                var testString = GetRandomNoise(length);
                var needleLocation = Random.Next(0, length - needleString.Length);

                testString = testString.Remove(needleLocation, needleString.Length);
                testString = testString.Insert(needleLocation, needleString);

                var results = Utils.Search(new string[] { needleString }, testString, (uint)needleString.Length);
                Assert.AreEqual(1, results.Count);
                Assert.AreEqual(needleLocation, results.First());
            }
        }
    }
}
