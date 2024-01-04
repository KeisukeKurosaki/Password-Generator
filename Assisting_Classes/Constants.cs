using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Password_Generator
{
    static internal class Constants
    {
        // These strings will either be used by themselves or in conjunction with one another

        // Upper-case letters
        public const string kAlphabet = "abcdefghijklmnopqrstuvwxyz";

        // Lower-case letters
        public const string kAlphabetUpper = "ABCDEFGHIJKLMNOPQRSTUVWXYZ";

        // Combined Letters
        public const string kLetters = "abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ";

        // Mathematical and Punctual symbols
        // The symbols " \ were removed (Need to update the list of symbols that are typically allowed for passwords

        public const string kSymbols = ".',:;!?'-_()[]{}+−×÷=<>%&@#$";

        // All numbers
        public const string kNumbers = "12345678901234567890";

        public const int kPasswordLength = 14;

        public const string kErrorMessage = "ERROR: You must pick at least one option...";

        public const string kPasswordPreface = "Created Password: ";
    }
}
