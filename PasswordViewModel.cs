using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Password_Generator
{
    public class PasswordViewModel : INotifyPropertyChanged
    {
        private Password model;

        public event PropertyChangedEventHandler PropertyChanged;

        protected virtual void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        public PasswordViewModel()
        {
            model = new Password();
        }

        public bool SymbolsChecked
        {
            get { return model.SymbolsChecked; }
            set
            {
                if (model.LettersChecked != value)
                {
                    model.LettersChecked = value;
                    OnPropertyChanged(nameof(SymbolsChecked));
                }
            }
        }

        public bool LettersChecked
        {
            get { return model.LettersChecked;}
            set
            {
                if (model.LettersChecked != value)
                {
                    model.LettersChecked = value;
                    OnPropertyChanged(nameof(LettersChecked));
                }
            }
        }

        public bool NumbersChecked
        {
            get { return model.NumbersChecked; }
            set
            {
                if (model.NumbersChecked != value)
                {
                    model.NumbersChecked = value;
                    OnPropertyChanged(nameof(NumbersChecked));
                }
            }
        }
    }
}
