using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Tournir;

namespace TournirTest
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void callIsPowOfTwo_returnTrue()
        {
            int input = 16;
            bool output = true;

            bool answ = Program.IsPowOfTwo(input);

            Assert.IsTrue(answ == output);
        }

        [TestMethod]
        public void callIsPowOfTwo_returnFalse()
        {
            int input = 15;
            bool output = true;

            bool answ = Program.IsPowOfTwo(input);

            Assert.IsFalse(answ == output);
        }

        [TestMethod]
        public void callParseOnPare_returnTrue()
        {
            string input = "Misha Dasha Koly Lera Dima Anton Igor Vova";
            string output = "Misha Dasha,Koly Lera,Dima Anton,Igor Vova";

            string answ = Program.ParseOnPare(input);

            Assert.IsTrue(output == answ);
        }
    }
}
