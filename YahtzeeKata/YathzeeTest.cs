using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;
using Moq;

namespace YahtzeeKata
{
    [TestClass]
    public class YathzeeTest
    {

        [TestMethod]
        public void OutputCorrect()
        {
            Mock<IConsole> console = new Mock<IConsole>(MockBehavior.Strict);
            Mock<IDieRoller> diceRoller = new Mock<IDieRoller>(MockBehavior.Strict);


            console.Setup(x => x.Read()).Returns("D1 D2 D4");

            var printSequence = new Moq.MockSequence();
            console.InSequence(printSequence).Setup(x => x.Write("Category: Ones")).Verifiable();
            console.InSequence(printSequence).Setup(x => x.Write("Dice: D1:2 D2:4 D3:1 D4:6 D5:1")).Verifiable();
            console.InSequence(printSequence).Setup(x => x.Write("[1] Dice to re-run:")).Verifiable();
            console.InSequence(printSequence).Setup(x => x.Write("Dice: D1:1 D2:5 D3:1 D4:2 D5:1")).Verifiable();
            console.InSequence(printSequence).Setup(x => x.Write("[2] Dice to re-run: ")).Verifiable();

            var fakeDieRoller = new FakeDieRoller(new List<int> { 2, 4, 1, 6, 1, 1, 5, 2 });
            

            var yathtzee = new Yathzee(console.Object, fakeDieRoller);

            yathtzee.Play();


            console.VerifyAll();
        }

    }

    public class FakeDieRoller: IDieRoller
    {
        private List<int> dice;
        public FakeDieRoller(List<int> dice)
        {
            this.dice = dice;
            Index = 0;
        }
        private int Index;

        public int Roll()
        {
            var die = dice[Index];
            Index++;
            return die;
        }
    }


    public interface IConsole
    {
        string Read();
        void Write(string message);
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
