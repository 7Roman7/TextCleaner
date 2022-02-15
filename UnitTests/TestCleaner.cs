using Microsoft.VisualStudio.TestTools.UnitTesting;
using TextCleaner.BusinessLogic;
using System;
using System.Collections.Generic;

namespace UnitTests
{
    [TestClass]
    public class TestCleaner
    {
        [TestMethod]
        public void RemoveSpecialSymbol_PowerPoint()
        {
            var result = Cleaner.RemoveSpecialSymbols(">​<", new List<char>() { '​' });

            Assert.AreEqual("><", result);
        }

        [TestMethod]
        public void RemoveSpecialSymbol_AnotherSymbols()
        {
            var result = Cleaner.RemoveSpecialSymbols("111", new List<char>() { '1', '2' });

            Assert.AreEqual("", result);
        }

        [TestMethod]
        public void RemoveStartSpaces_1()
        {
            var strings = new List<string>() 
            {
                "   1",
                "   2"
            };
            var expectedStrings = new List<string>() 
            {
                "1",
                "2"
            };

            Cleaner.RemoveStartSpaces(strings);

            Assert.AreEqual(expectedStrings.Count, strings.Count);
            for (int i = 0; i < expectedStrings.Count; i++)
            {
                Assert.AreEqual(expectedStrings[i], strings[i]);
            }
        }

        [TestMethod]
        public void RemoveStartSpaces_2()
        {
            var strings = new List<string>()
            {
                "   1",
                "      2",
                "      3"
            };
            var expectedStrings = new List<string>()
            {
                "1",
                "   2",
                "   3"
            };
            Cleaner.RemoveStartSpaces(strings);

            Assert.AreEqual(expectedStrings.Count, strings.Count);
            for (int i = 0; i < expectedStrings.Count; i++)
            {
                Assert.AreEqual(expectedStrings[i], strings[i]);
            }
        }

        [TestMethod]
        public void RemoveStartSpaces_3()
        {
            List<string> strings = new List<string>()
            {
                "   1",
                "      2",
                " 3"
            };
            Cleaner.RemoveStartSpaces(strings);

            List<string> expectedStrings = new List<string>()
            {
                "1",
                "   2",
                "3"
            };
            Assert.AreEqual(expectedStrings.Count, strings.Count);
            for (int i = 0; i < expectedStrings.Count; i++)
            {
                Assert.AreEqual(expectedStrings[i], strings[i]);
            }
        }

    }
}
