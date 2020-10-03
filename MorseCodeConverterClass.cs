using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Runtime;

namespace MorseCodeWPF
{
    class MorseCodeConverterClass
    {
        //TO DO: Š a CH mají stejný znak... - ve skutečnosti chci asi Š a S aby měli stejný znak 
        //ISO měna 
        //Když zadaný znak není
        //Věty


        private char dot; // nemit public

        private char dash;

        private char letterSplitter;

        private string wordSplitter;

        public Char Dot { get; private set; }
        public Char Dash { get; private set; }

        public Char LetterSeparator { get; private set; }

        public String WordSeparator { get; private set; }


        public Dictionary<char, char[]> Morse { get; private set; }


        public MorseCodeConverterClass(char dot, char dash, char letterSeparator, string wordSeparator)
        {
            this.dash = dash;
            this.dot = dot;
            this.letterSplitter = letterSeparator;
            this.wordSplitter = wordSeparator;
            Dot = dot;
            Dash = dash;
            LetterSeparator = letterSeparator;
            WordSeparator = wordSeparator;

            Morse = new Dictionary<char, char[]>  {
                { 'A' ,  new char[] {dot, dash }  },
                { 'Á' ,  new char[] {dot, dash }  },
                { 'B' ,  new char[] {dash, dot,  dot, dot }  },
                { 'C' ,  new char[] {dash, dot, dash, dot } },
                { 'Č' ,  new char[] {dash, dot,  dash, dot } },
                { 'D' ,  new char[] {dash, dot, dot } },
                { 'Ď' ,  new char[] {dash, dot, dot } },
                { 'E' ,  new char[] {dot }  },
                { 'É' ,  new char[] {dot }  },
                { 'Ě' ,  new char[] {dot }  },
                { 'F' ,  new char[] {dot, dot, dash, dot }  },
                { 'G' ,  new char[] {dash, dash, dot }  },
                { 'H' ,  new char[] {dot, dot, dot, dot }  },
                { 'I' ,  new char[] {dot , dot } },
                { 'Í' ,  new char[] {dot , dot } },
                { 'J' ,  new char[] {dot , dash , dash , dash } },
                { 'K' ,  new char[] {dash , dot , dash } },
                { 'L' ,  new char[] {dot , dash , dot , dot } },
                { 'M' ,  new char[] {dash , dash }  },
                { 'N' ,  new char[] {dash , dot } },
                { 'O' ,  new char[] {dash , dash , dash } },
                { 'Ó' ,  new char[] {dash , dash , dash } },
                { 'P' ,  new char[] {dot , dash , dash , dot } },
                { 'Q' ,  new char[] {dash , dash , dot , dash }  },
                { 'R' ,  new char[] {dot , dash , dot } },
                { 'Ř' ,  new char[] {dot , dash , dot } },
                { 'S' ,  new char[] {dot , dot , dot } },
                { 'Š' ,  new char[] {dot , dot , dot } },
                { 'T' ,  new char[] {dash } },
                { 'Ť' ,  new char[] {dash } },
                { 'U' ,  new char[] {dot , dot , dash }  },
                { 'Ú' ,  new char[] {dot , dot , dash }  },
                { 'Ů' ,  new char[] {dot , dot , dash }  },
                { 'V' ,  new char[] {dot , dot , dot , dash } },
                { 'W' ,  new char[] {dot , dash , dash } },
                { 'X' , new char[] { dash , dot , dot , dash } },
                { 'Y' ,  new char[] {dash , dot , dash , dash } },
                { 'Ý' ,  new char[] {dash , dot , dash , dash } },
                { 'Z' ,  new char[] {dash , dash , dot , dot }  },
                { 'Ž' ,  new char[] {dash , dash , dot , dot }  },
                { '0' ,  new char[] {dash , dash , dash , dash , dash } },
                { '1' ,  new char[] {dot , dash , dash , dash , dash } },
                { '2' ,  new char[] {dot , dot , dash , dash , dash }  },
                { '3' ,  new char[] {dot , dot , dot , dash , dash } },
                { '4' ,  new char[] {dot , dot , dot , dot , dash } },
                { '5' ,  new char[] {dot , dot , dot , dot , dot }  },
                { '6' ,  new char[] {dash , dot , dot , dot , dot }  },
                { '7' ,  new char[] {dash , dash , dot , dot , dot }  },
                { '8' ,  new char[] {dash , dash , dash , dot , dot }  },
                { '9' ,  new char[] {dash , dash , dash , dash , dot }  },
                {'Ä', new char[] {dot , dash , dot , dash } },
                {'Ë', new char[] {dot , dot , dash , dot , dot}  }, //..–..
                {'Ö', new char[] {dash , dash , dash , dot } }, //---.
                {'Ü', new char[] {dot , dot , dash , dash } }, //..--
                {'.', new char[] {dot , dash , dot , dash , dot , dash}  },//.-.-.-
                {',', new char[] {dash , dash , dot , dot , dash , dash } }, //--..--
                {'?', new char[] {dot , dot , dash , dash , dot , dot } },//..--..
                {'!', new char[] {dash , dash , dot , dot , dash } },//--..-
                {';', new char[] {dash , dot , dash , dot , dash , dot}  }, // -.-.-.
                {':', new char[] {dash , dash , dash , dot , dot , dot}  },// ---...
                {'=', new char[] {dash , dash , dot , dot , dot } }, //--...
                {')', new char[] {dash , dot , dash , dash , dot , dash}  },// -.--.-
                {'"', new char[] {dot , dash , dot , dot , dash , dot}  }, //.- ..-.
                {'-', new char[] {dash , dot , dot , dot , dot , dash}  }, //  -....-
                {'_', new char[] {dot , dot , dash , dash , dot , dash}  },//..--.-
                {'@', new char[] {dot , dash , dash , dot , dash , dot}  },//.--.-.
                //{',', new char[] {dot , dash , dot , dash , dot}  },//.-.-.
                {'/', new char[] {dash, dot, dot, dash, dot } },// -..-.
                {'\'', new char[] { dot, dash, dash, dash, dot} },//.----.                

            };

            

        }

        /// <summary>
        /// Method to convert the Morse code to words
        /// </summary>
        /// <param name="codeToConvert">string in morse code to be converted</param>
        /// <returns>string - letters form the Morse Code</returns>
        public string MorseToText(string codeToConvert)
        {            
            string convertedCode = string.Empty; //There is no text at the beginning 
            string[] wordsInTheCode = codeToConvert.Split(new[] { WordSeparator }, StringSplitOptions.RemoveEmptyEntries); //Separate the words in string array
            
            foreach (string s in wordsInTheCode)
            {
                string[] lettersInTheCode = s.Split(LetterSeparator); //Separate the letters, save each letter as string Array; 1 letter is 1 string in the array
                foreach (string t in lettersInTheCode)
                {
                    char[] letterInTheCode = t.ToCharArray(); //Each letter must be coneverted to char array
                    
                    string pismenko = Morse.FirstOrDefault(x => letterInTheCode.SequenceEqual(x.Value)).Key.ToString(); //find the letter for the particular char array of dots and dashes in the dictionary
                    convertedCode += pismenko; //add the letter to thy result
                }
                convertedCode += ' '; //There is a whitespace after each word
            }

            return convertedCode; //return the result
        }

        /// <summary>
        /// Convert the text to the Morse code
        /// </summary>
        /// <param name="textToConvert">Text to be converted</param>
        /// <returns>String in Morse code</returns>
        public string TextToMorse(string textToConvert)
        {
            textToConvert = textToConvert.ToUpper(); //Upper characters are in the dictionary             
            string morseCode = string.Empty; //There is no converted text at the beginning
            foreach (char c in textToConvert)
            {
                if (c == Dot || c == Dash || c == LetterSeparator)
                {
                    //zde by to chtělo vyvolat událost...
                }

                else if (char.IsWhiteSpace(c))
                {
                    if (morseCode.Last<char>().Equals(LetterSeparator))
                    {
                        string a = morseCode.Remove(morseCode.Length - 1, 1);
                        morseCode = a;
                    }
                    morseCode += WordSeparator;
                }
                else
                {
                    if (Morse.TryGetValue(c, out char[] value))
                    {
                        foreach (char k in value)
                        {
                            morseCode += k;
                        }
                        morseCode += LetterSeparator;
                    }
                }

            
            } 

            return morseCode;
        }
    }
}



