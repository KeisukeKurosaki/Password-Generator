using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;

namespace Password_Generator
{
    public class PasswordViewModel : INotifyPropertyChanged
    {
        private Password model;

        public event PropertyChangedEventHandler PropertyChanged;

        public ICommand UseCreatePasswordButton {get; private set;}

        protected virtual void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        public PasswordViewModel()
        {
            model = new Password();
            UseCreatePasswordButton = new RelayCommand(InitiatePassword);
        }

        public bool SymbolsChecked
        {
            get { return model.SymbolsChecked; }
            set
            {
                if (model.SymbolsChecked != value)
                {
                    model.SymbolsChecked = value;
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
        
        private void InitiatePassword(object parameter)
        {
            if (SymbolsChecked ||  LettersChecked || NumbersChecked) 
            {
                model.CreatePassword(SymbolsChecked, LettersChecked, NumbersChecked);
                MessageBox.Show(model.ActualPassword);
            }
            else
            {
                // Show Error
            }
        }

    }
}
