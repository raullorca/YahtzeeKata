using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;

namespace YahtzeeKata
{
    [TestClass]
    public class UnitTest1
    {

        [TestMethod]
        public void TestMethod1()
        {
            Moq.Mock<ConsoleFake> read = new Moq.Mock<ConsoleFake>();
            read.Setup(x => x.Read()).Returns("D1 D2 D4");


            var console = new ConsoleFake();

            var yathtzee = new Yathzee(console);

            yathtzee.Play();
            
            Assert.AreEqual(console.atLine(0), "Category: Ones");
            Assert.AreEqual(console.atLine(1), "Dice: D1:2 D2:4 D3:1 D4:6 D5:1");
            Assert.AreEqual(console.atLine(2), "[1] Dice to re-run:");
            Assert.AreEqual(console.atLine(3), "Dice: D1:1 D2:5 D3:1 D4:2 D5:1");
            Assert.AreEqual(console.atLine(4), "[2] Dice to re-run: ");
         }
    }

    public class ConsoleFake
    {
        public int contador { get; set; }
        public ConsoleFake()
        {
            Lines = new List<string>();
            contador = 0;
        }
        public List<string> Lines { get; set; }

        public string atLine(int pos)
        {
            return Lines[pos];
        }
        public void print(string line)
        {
            Lines.Add(line);
        }

        public string Read()
        {
            string[] retorn = { "D1 D2 D4", "D2 D4" };
            var value = retorn[contador];
            contador++;
            return value;
        }

       
    }
}
