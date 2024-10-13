using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace morze
{
    internal class MorseDecoder
    {
        private readonly Dictionary<string, char> morseCode;
        private readonly char shortSignal;
        private readonly char longSignal;

        public MorseDecoder(char shortSignal, char longSignal)
        {
            this.shortSignal = shortSignal;
            this.longSignal = longSignal;

            morseCode = new Dictionary<string, char>
            {
                {".-", 'A'}, {"-...", 'B'}, {"-.-.", 'C'}, {"-..", 'D'}, {".", 'E'},
                {"..-.", 'F'}, {"--.", 'G'}, {"....", 'H'}, {"..", 'I'}, {".---", 'J'},
                {"-.-", 'K'}, {".-..", 'L'}, {"--", 'M'}, {"-.", 'N'}, {"---", 'O'},
                {".--.", 'P'}, {"--.-", 'Q'}, {".-.", 'R'}, {"...", 'S'}, {"-", 'T'},
                {"..-", 'U'}, {"...-", 'V'}, {".--", 'W'}, {"-..-", 'X'}, {"-.--", 'Y'},
                {"--..", 'Z'},
                {"-----", '0'}, {".----", '1'}, {"..---", '2'}, {"...--", '3'}, {"....-", '4'},
                {".....", '5'}, {"-....", '6'}, {"--...", '7'}, {"---..", '8'}, {"----.", '9'}
            };
        }

        public string Decode(string input)
        {
            string[] words = input.Split('/');
            List<string> decodedWords = new List<string>();

            foreach (var word in words)
            {
                string[] characters = word.Trim().Split(' ');
                List<char> decodedChars = new List<char>();

                foreach (var character in characters)
                {
                    string Morse = character.Replace(shortSignal, '.').Replace(longSignal, '-');

                    if (morseCode.ContainsKey(Morse))
                    {
                        decodedChars.Add(morseCode[Morse]);
                    }
                    else
                    {
                        decodedChars.Add('#');
                    }
                }
                decodedWords.Add(new string(decodedChars.ToArray()));
            }
            return string.Join(" ", decodedWords);
        }
    }
}
