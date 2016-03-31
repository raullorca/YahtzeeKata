using System;
using System.Collections.Generic;
using System.Linq;

namespace YahtzeeKata
{
    public class InputLine
    {
        private string content;

        public InputLine(string content)
        {
            this.content = content;
        }

        public List<int> ExtractDice()
        {
            var tokens = content.Split(' ').ToList();
            var dice = tokens.Select(token => int.Parse(token.Substring(1)));
            return dice.ToList();
        }
    }
}