using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Password_Generator
{
    internal class Password
    {
        public string usableCharacters { get; set; }

        public bool lettersChecked { get; set; }

        public bool symbolsChecked { get; set; }

        public bool numbersChecked { get; set; }
    }
}
