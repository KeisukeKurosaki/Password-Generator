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

        public ICommand CopyToClipBoardCommand { get; private set; }

        public bool _PasswordBoxVisibility { get; set; }

        public string _PasswordBoxContent { get; set;}

        public string _LabelColor { get; set;}

        public bool _CopyButtonVisibility { get; set; }

        public bool _PasswordSavedVisibility { get; set; }

        protected virtual void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        public PasswordViewModel()
        {
            model = new Password();
            UseCreatePasswordButton = new RelayCommand(InitiatePassword);
            NavigateToHelpPageCommand = new RelayCommand(NavigateToHelp);
            CopyToClipBoardCommand = new RelayCommand(CopyToClipBoard);
            _CopyButtonVisibility = false;
            _PasswordSavedVisibility = false;
            _PasswordBoxVisibility = false;
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

        public bool PasswordBoxVisibility
        {
            get { return _PasswordBoxVisibility; }
            set
            {
                if (_PasswordBoxVisibility != value)
                {
                    _PasswordBoxVisibility = value;
                    OnPropertyChanged(nameof(PasswordBoxVisibility));
                }
            }
        }

        public string PasswordBoxContent
        {
            get { return _PasswordBoxContent; }
            set
            {
                if (_PasswordBoxContent != value)
                {
                    _PasswordBoxContent = value;
                    OnPropertyChanged(nameof(PasswordBoxContent));
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
            get { return _CopyButtonVisibility; }
            set
            {
                if (_CopyButtonVisibility != value)
                {
                    _CopyButtonVisibility = value;
                    OnPropertyChanged(nameof(CopyVisibility));
                }
            }
        }

        public bool PasswordSavedVisibility
        {
            get { return _PasswordSavedVisibility; }
            set
            {
                if (_PasswordSavedVisibility != value) 
                {
                    _PasswordSavedVisibility = value;
                    OnPropertyChanged(nameof(PasswordSavedVisibility));
                }
            }
        }
        
        private void InitiatePassword(object obj)
        {
            if (SymbolsChecked ||  LettersChecked || NumbersChecked) 
            {
                model.CreatePassword(SymbolsChecked, LettersChecked, NumbersChecked);
                ShowPassword();
                CopyVisibility = true;
                PasswordSavedVisibility = false;
            }
            else
            {
                ShowError();
                CopyVisibility = false;
                PasswordSavedVisibility = false;
            }
        }

        private void ShowError()
        {
            PasswordBoxContent = Constants.kErrorMessage;
            LabelColor = "Red";
            PasswordBoxVisibility = true;
        }

        private void ShowPassword()
        {
            PasswordBoxContent = model.ActualPassword;
            LabelColor = "Black";
            PasswordBoxVisibility = true;
        }

        private void NavigateToHelp(object obj)
        {
            var window = Application.Current.MainWindow;
            window.Content = new HelpPage();
        }

        private void CopyToClipBoard(object obj)
        {
            Clipboard.SetText(PasswordBoxContent);
            PasswordSavedVisibility = true;
        }
    }
}
