using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Password_Generator
{
    internal class Password
    {
        public string ActualPassword { get; set; }

        public bool LettersChecked { get; set; }

        public bool SymbolsChecked { get; set; }

        public bool NumbersChecked { get; set; }
    }
}
