using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CellphoneKeypad
{
    class Program
    {
        const int MIN_DURATION = 100;
        const int WAIT_DURATION = 500;

        private static Dictionary<Char, Tuple<Char, int>> keypad;

        private static void PopulateKeypad()
        {
            if (keypad == null)
            {
                keypad = new Dictionary<char, Tuple<char, int>>();
                keypad.Add('a', Tuple.Create('2', 1));
                keypad.Add('b', Tuple.Create('2', 2));
                keypad.Add('c', Tuple.Create('2', 3));
                keypad.Add('d', Tuple.Create('3', 1));
                keypad.Add('e', Tuple.Create('3', 2));
                keypad.Add('f', Tuple.Create('3', 3));
                keypad.Add('g', Tuple.Create('4', 1));
                keypad.Add('h', Tuple.Create('4', 2));
                keypad.Add('i', Tuple.Create('4', 3));
                keypad.Add('j', Tuple.Create('5', 1));
                keypad.Add('k', Tuple.Create('5', 2));
                keypad.Add('l', Tuple.Create('5', 3));
                keypad.Add('m', Tuple.Create('6', 1));
                keypad.Add('n', Tuple.Create('6', 2));
                keypad.Add('o', Tuple.Create('6', 3));
                keypad.Add('p', Tuple.Create('7', 1));
                keypad.Add('q', Tuple.Create('7', 2));
                keypad.Add('r', Tuple.Create('7', 3));
                keypad.Add('s', Tuple.Create('7', 4));
                keypad.Add('t', Tuple.Create('8', 1));
                keypad.Add('u', Tuple.Create('8', 2));
                keypad.Add('v', Tuple.Create('8', 3));
                keypad.Add('w', Tuple.Create('9', 1));
                keypad.Add('x', Tuple.Create('9', 2));
                keypad.Add('y', Tuple.Create('9', 3));
                keypad.Add('z', Tuple.Create('9', 4));
                keypad.Add(' ', Tuple.Create('0', 1));
            }
        }

        protected static Tuple<int, String> CalculateMinimumTime(String word)
        {
            int total = 0;
            String sequence = "";
            for (int i = 0; i < word.Length; i++)
            {
                Tuple<Char, int> charInfo = keypad[word[i]];
                int position = charInfo.Item2;
                for (int j = 0; j < position; j++)
                {
                    sequence += charInfo.Item1;
                }
                int clickTime = position * MIN_DURATION;
                if (i != 0)
                {
                    Tuple<Char, int> lastCharInfo = keypad[word[i - 1]];
                    if (lastCharInfo.Item1 == charInfo.Item1)
                        clickTime += WAIT_DURATION;
                }
                total += clickTime;
            }
            return Tuple.Create(total, sequence);
        }

        static void Main(string[] args)
        {
            if (keypad == null)
                PopulateKeypad();

            Tuple<int, String> result = CalculateMinimumTime("global aerospace");
            Console.WriteLine("Minimum time required in milliseconds: {0}", result.Item1);
            Console.WriteLine("Input sequence:                        {0}", result.Item2);
            Console.ReadLine();
        }
    }
}
