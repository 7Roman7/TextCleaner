using Microsoft.VisualStudio.TestTools.UnitTesting;
using TextCleaner.ViewModel;
using System;

namespace UnitTests
{
    [TestClass]
    public class TestMainVM
    {
        [TestMethod]
        public void TestConvertText1()
        {
            var main = new MainVM();

            main.TextBefore = 
                "123\r\n" +
                "123";

            string expected =
                "123\r\n" +
                "123";

            main.ConvertTextCommand.Execute(null);

            Assert.AreEqual(expected, main.TextAfter);
        }

        [TestMethod]
        public void TestConvertText2()
        {
            var main = new MainVM();

            main.TextBefore =
                " 123\r\n" +
                "  123\r\n" +
                "123\r\n";

            string expected =
                "123\r\n" +
                " 123\r\n" +
                "123";

            main.ConvertTextCommand.Execute(null);

            Assert.AreEqual(expected, main.TextAfter);
        }

        [TestMethod]
        public void TestConvertText3()
        {
            var main = new MainVM();
            main.TextBefore =">​<";
            string expected ="><";
            main.ConvertTextCommand.Execute(null);

            Assert.AreEqual(expected, main.TextAfter);
        }
    }
}
