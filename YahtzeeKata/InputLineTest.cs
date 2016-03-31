using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;

namespace YahtzeeKata
{
    [TestClass]
    public class InputLineTest
    {
        [TestMethod]
        public void ExtractDice()
        {
            CollectionAssert.AreEqual(new InputLine("D1 D2 D3").ExtractDice(), new List<int> { 1, 2, 3 });
            CollectionAssert.AreEqual(new InputLine("D2 D4").ExtractDice(), new List<int> { 2, 4 });
        }

    }
}
