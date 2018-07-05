using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Linq;
using ConsoleBigramParsing2;

namespace UnitTestBigramParsing2
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void TestValueOfResults()
        {
            var sut = new HistogramService();
            var testFile = "../../../TextFiles/TextFile1.txt";
            var results = sut.ProcessFile(testFile).Take(1).Select(d => d.Value).First();

            Assert.AreEqual(2, results);
        }

        [TestMethod]
        public void TestLengthOfResults()
        {
            var sut = new HistogramService();
            var testFile = "../../../TextFiles/TextFile1.txt";
            var results = sut.ProcessFile(testFile).Count;

            Assert.AreEqual(12, results);
        }

    }
}
