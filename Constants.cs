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

        public const string kLetters = "abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ";

        // Mathematical and Punctual symbols
        public const string kSymbols = ".',:;!?\"'-_()[]{}+−×÷=<>%&@#$\\";

        // All numbers
        public const string kNumbers = "1234567890";

        public const int kPasswordLength = 12;
    }
}
