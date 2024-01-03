using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;

namespace Password_Generator
{
    internal class Password
    {
        public string ActualPassword { get; set; }

        public bool LettersChecked { get; set; }

        public bool SymbolsChecked { get; set; }

        public bool NumbersChecked { get; set; }

        public void CreatePassword(bool symbols, bool letters, bool numbers)
        {
            string randomizationString;

            int bitmask = (symbols ? 1 : 0) | (letters ? 2 : 0) | (numbers ? 4 : 0);

            switch (bitmask)
            {
                case 1: // Only Symbols selected

                    randomizationString = Constants.kSymbols;
                    Randomize(randomizationString, Constants.kPasswordLength);
                    break;
                case 2: // Only Letters selected

                    randomizationString = Constants.kLetters;
                    Randomize(randomizationString, Constants.kPasswordLength);
                    break;
                case 3: // Symbols and Letters selected

                    randomizationString = Constants.kSymbols + Constants.kLetters;
                    Randomize(randomizationString, Constants.kPasswordLength);
                    break;
                case 4: // Only Numbers selected

                    randomizationString = Constants.kNumbers;
                    Randomize(randomizationString, Constants.kPasswordLength);


                    break;
                case 5: // Symbols and Numbers selected

                    randomizationString = Constants.kSymbols + Constants.kNumbers;
                    Randomize(randomizationString, Constants.kPasswordLength);

                    break;
                case 6: // Letters and Numbers selected

                    randomizationString = Constants.kLetters + Constants.kNumbers;
                    Randomize(randomizationString, Constants.kPasswordLength);

                    break;
                case 7: // Symbols, Letters, and Numbers selected

                    randomizationString = Constants.kLetters + Constants.kNumbers + Constants.kSymbols;
                    Randomize(randomizationString, Constants.kPasswordLength);

                    break;
            }
        }

        public void Randomize(string potentialOptions, int passwordLength)
        {
            Random rng = new Random();

            char[] chars = potentialOptions.ToCharArray();

            // Shuffle the characters using Fisher-Yates (Knuth) Shuffle algorithm
            for (int i = chars.Length - 1; i > 0; i--)
            {
                int j = rng.Next(i + 1);
                char temp = chars[i];
                chars[i] = chars[j];
                chars[j] = temp;
            }

            // Take the specified length of characters from the shuffled array
            string randomizedString = new string(chars, 0, passwordLength);

            ActualPassword = randomizedString;
        }
    }
}
