using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Mastermind.Tests
{
    [TestClass]
    public class MastermindTests
    {
        private readonly Menu menu = new Menu();

        [DataTestMethod]
        [DataRow("1111", "1111", "++++")]
        [DataRow("6543", "6543", "++++")]
        [DataRow("4243", "4561", "+ - ")]
        [DataRow("4652", "4123", "+  -")]
        [DataRow("2513", "3215", "--+-")]
        [DataRow("3145", "3146", "+++ ")]

        public void CheckAnswer(string input, string answer, string expected)
        {
            string actual = menu.CheckAnswer(input, answer);
            Assert.AreEqual(expected, actual);
        }
        [DataTestMethod]
        [DataRow("6666", true)]
        [DataRow("    ", false)]
        [DataRow("46a2", false)]
        [DataRow("12345", false)]
        [DataRow("513", false)]
        [DataRow("4215", true)]
        public void CheckForValidNumber(string input, bool expected)
        {
            bool actual = menu.CheckForValidNumber(input);
            Assert.AreEqual(expected, actual);
        }
    }
}
