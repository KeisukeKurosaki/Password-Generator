using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;

namespace Password_Generator
{
    /*
    *	CLASS           : Password
    *	DESCRIPTION		:
    *		This class is used to act as the model for the page that will be generating the random passwords
    *		for the user on the "InitialPage". This model will act in tandem alongside the PasswordViewModel class
    *		in order to help with the business logic of generating passwords depending on the choices the user will be
    *		making with the UI.
    */
    internal class Password
    {
        // Used to hold the randomly generated password
        public string ActualPassword { get; set; }

        // Used to determine if letters are checked by the user through data binding
        public bool LettersChecked { get; set; }

        // Used to determine if symbols are checked by the user through data binding
        public bool SymbolsChecked { get; set; }

        // Used to determine if symbols are checked by the user through data binding
        public bool NumbersChecked { get; set; }

        /*
        *	METHOD          : CreatePassword(bool symbols, bool letters, bool numbers)
        *	DESCRIPTION		:
        *		This method is used in order to select and determine which options should be included in the 
        *		generation of a new password. As such, a bit mask will be used to navigate through the separate
        *		options of which possibilities should be included in the string that will be randomized and ultimately 
        *		generate the password. Each separate switch case statement is a different combination of the options 
        *		available for generating a unique password depending on the properties that affect the string that is
        *		used to determine which characters are chosen.
        *	PARAMETERS		:
        *		void               :   Void is used as there are no parameters for this method
        *	RETURNS			:
        *		void	           :   This method does not have any return value
        */
        public void CreatePassword()
        {
            string randomizationString;

            int bitmask = (SymbolsChecked ? 1 : 0) | (LettersChecked ? 2 : 0) | (NumbersChecked ? 4 : 0);

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

        /*
        *	METHOD          : Randomize(string potentialOptions, int passwordLength)
        *	DESCRIPTION		:
        *		This method is used in order to randomize a string using the Fisher-Yates shuffle algorithm. This 
        *		will be the method that will randomly generate new passwords depending on which options the user 
        *		has selected (symbols, letters, numbers) to be included. Utilizing this algorithm helps in creating
        *		a new password that is unbiased in the selection of the characters, letters, or symbols to be included.
        *	PARAMETERS		:
        *		string potentialOptions      :   The string containing the potential letters, symbols, or numbers
        *		int passwordLength           :   The length of the password that will be made      
        *	RETURNS			:
        *		void	                     :   This method does not have any return value
        */
        public void Randomize(string potentialOptions, int passwordLength)
        {
            Random rng = new Random();

            // Take the string containing a combination or single option of letters, numbers, and symbols and convert it to a char[]
            char[] chars = potentialOptions.ToCharArray();

            // Shuffle the characters using Fisher-Yates (Knuth) Shuffle algorithm
            for (int i = chars.Length - 1; i > 0; i--)
            {
                int j = rng.Next(i + 1);
                char temp = chars[i];
                chars[i] = chars[j];
                chars[j] = temp;
            }

            // Take the specified length of characters from the shuffled array and store them in a string
            string randomizedString = new string(chars, 0, passwordLength);

            // Store the randomly generated password in the ActualPassword property of the model class
            ActualPassword = randomizedString;
        }
    }
}
