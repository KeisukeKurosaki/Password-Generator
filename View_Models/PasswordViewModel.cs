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

        public ICommand UseCreatePasswordButton { get; private set; }

        public ICommand NavigateToHelpPageCommand { get; }

        public bool _LabelVisibility { get; set; }

        public string _LabelContent { get; set;}

        public string _LabelColor { get; set;}

        public bool _CopyVisibility { get; set; }



        protected virtual void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        public PasswordViewModel()
        {
            model = new Password();
            UseCreatePasswordButton = new RelayCommand(InitiatePassword);
            NavigateToHelpPageCommand = new RelayCommand(NavigateToHelp);
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

        public bool ErrorLabelVisibility
        {
            get { return _LabelVisibility; }
            set
            {
                if (_LabelVisibility != value)
                {
                    _LabelVisibility = value;
                    OnPropertyChanged(nameof(ErrorLabelVisibility));
                }
            }
        }

        public string LabelContent
        {
            get { return _LabelContent; }
            set
            {
                if (_LabelContent != value)
                {
                    _LabelContent = value;
                    OnPropertyChanged(nameof(LabelContent));
                }
            }
        }

        public string LabelColor
        {
            get { return _LabelColor; }
            set
            {
                if (_LabelColor != value)
                {
                    _LabelColor = value;
                    OnPropertyChanged(nameof(LabelColor));
                }

            }
        }

        public bool CopyVisibility
        {
            get { return _CopyVisibility; }
            set
            {
                if (_CopyVisibility != value)
                {
                    _CopyVisibility = value;
                    OnPropertyChanged(nameof(CopyVisibility));
                }
            }
        }
        
        private void InitiatePassword(object obj)
        {
            if (SymbolsChecked ||  LettersChecked || NumbersChecked) 
            {
                model.CreatePassword(SymbolsChecked, LettersChecked, NumbersChecked);
                ShowPassword();
                //MessageBox.Show(model.ActualPassword);
            }
            else
            {
                ShowError();
            }
        }

        private void ShowError()
        {
            LabelContent = Constants.kErrorMessage;
            LabelColor = "Red";
        }

        private void ShowPassword()
        {
            LabelContent = model.ActualPassword;
            LabelColor = "Black";
        }

        private void NavigateToHelp(object obg)
        {
            var window = Application.Current.MainWindow;
            window.Content = new HelpPage();
        }
    }
}
