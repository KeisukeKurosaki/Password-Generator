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
    /*
    *	CLASS           : PasswordViewModel
    *	DESCRIPTION		:
    *		This class is used to act as the view model for the password class and also determine the data-binding 
    *		context for the "InitialPage" of the application. As such, methods and properties will relate to updating
    *		the UI for the user and interacting with the model to conduct business logic.
    */
    public class PasswordViewModel : INotifyPropertyChanged
    {
        // A class of type password is used to help communicate between the model and the viewmodel
        private Password model;

        // Used to implement INotifyPropertyChanged interface for data-binding
        public event PropertyChangedEventHandler PropertyChanged;

        // Used to encapsulate UI interactions relating to the "Create Password" button
        public ICommand UseCreatePasswordButton { get; private set; }

        // Used to encapsulate UI interactions relating to the "Need Help?" button
        public ICommand NavigateToHelpPageCommand { get; }

        // Used to encapsulate UI interactions relating to the "Copy Password" button
        public ICommand CopyToClipBoardCommand { get; private set; }

        // Boolean property used to help with the visibility of an error or password textbox
        public bool _PasswordBoxVisibility { get; set; }

        // String property that is used for the content to be displayed for an error or generated password
        public string _PasswordBoxContent { get; set;}

        // String property used for determining the color of a text in the view
        public string _PasswordBoxColor { get; set;}

        // Boolean property used for the visibility of a copy button 
        public bool _CopyButtonVisibility { get; set; }

        // Boolean property used for a label showing if a password has been copied or not
        public bool _PasswordSavedVisibility { get; set; }

        /*
        *	CONSTRUCTOR     : PasswordViewModel()
        *	DESCRIPTION		:
        *		This constructor instantiates an object of type PasswordViewModel which is responsible for the 
        *		data-binding relating to the "InitialPage" of the application. As such, a model class of type
        *		Password is instantiated, Relay Commands are set in order to bind certain methods to buttons,
        *		and certain properties are set to false to influence visibility levels at the applications startup.
        */
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

        /*
        *	METHOD          : OnPropertyChanged(string propertyName)
        *	DESCRIPTION		:
        *		This method is used to enable data-binding between the view and viewmodel of this specific application.
        *		As such, UI or view elements will be notified if any of the properties are changed that they are bound
        *		to, which will in turn help update the UI for the user to reflect their new values.
        *	PARAMETERS		:
        *		string propertyName        :   The name of the property that will be changed
        *	RETURNS			:
        *		void	                   :   This method does not have any return value
        */
        protected virtual void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        /*
        *	PROPERTY        : NumbersChecked
        *	DESCRIPTION		:
        *		This property is used for determining the state of the checkbox relating to including symbols in the
        *		generated password. This property will be changed if the incoming value is different from the current
        *		value, at which the data-binding will invoke the OnPropertyChanged method.
        */
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

        /*
        *	PROPERTY        : NumbersChecked
        *	DESCRIPTION		:
        *		This property is used for determining the state of the checkbox relating to including latters in the
        *		generated password. This property will be changed if the incoming value is different from the current
        *		value, at which the data-binding will invoke the OnPropertyChanged method.
        */
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

        /*
        *	PROPERTY        : NumbersChecked
        *	DESCRIPTION		:
        *		This property is used for determining the state of the checkbox relating to including numbers in the
        *		generated password. This property will be changed if the incoming value is different from the current
        *		value, at which the data-binding will invoke the OnPropertyChanged method.
        */
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

        /*
        *	PROPERTY        : PasswordBoxVisibility
        *	DESCRIPTION		:
        *		This property is used for the decision to display a textbox or not relating to an error or a newly
        *		generated password. This property will be changed if the incoming value is different from the current
        *		value, at which the data-binding will invoke the OnPropertyChanged method.
        */
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

        /*
        *	PROPERTY        : PasswordBoxContent
        *	DESCRIPTION		:
        *		This property is used for displaying content in a textbox (password / error). This property will be changed 
        *		if the incoming value is different from the current value, at which the data-binding will invoke the 
        *		OnPropertyChanged method.
        */
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

        /*
        *	PROPERTY        : PasswordBoxColor
        *	DESCRIPTION		:
        *		This property is used regarding data-binding relating to the color of the content that will either be
        *		an error message or a generated password. This property will be changed if the incoming value is different
        *		from the current value, at which the data-binding will invoke the OnPropertyChanged method.
        */
        public string PasswordBoxColor
        {
            get { return _PasswordBoxColor; }
            set
            {
                if (_PasswordBoxColor != value)
                {
                    _PasswordBoxColor = value;
                    OnPropertyChanged(nameof(PasswordBoxColor));
                }
            }
        }

        /*
        *	PROPERTY        : CopyVisibility
        *	DESCRIPTION		:
        *		This property is used regarding data-binding relating to the copy button's visibility which should 
        *		not be visibile unless a new password was created. This property will be changed if the incoming 
        *		value is different from the current value, at which the data-binding will invoke the OnPropertyChanged 
        *		method.
        */
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

        /*
        *	PROPERTY        : PasswordSavedVisibility
        *	DESCRIPTION		:
        *		This property is used regarding data-binding relating to the label for displaying if a password 
        *		was saved to a users clipboard. This property will be changed if the incoming value is different
        *		from the current value, at which the data-binding will invoke the OnPropertyChanged method.
        */
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

        /*
        *	METHOD          : InitiatePassword()
        *	DESCRIPTION		:
        *		This method is used in order to begin the process of creating a randomly-generated password. The 
        *		method will first determine if any of the checkboxes have been selected and if so, the password will
        *		be generated using the model's CreatePassword method. Next, the data binding will show the password 
        *		textbox to the user and also activate the visibility of the copying button to copy the password for the 
        *		user. If the user did not select any checkboxes, an error will be shown to them and the visibility of the 
        *		copying button will be removed.
        *	PARAMETERS		:
        *		void            :   Void is used as there are no parameters
        *	RETURNS			:
        *		void	        :   This method does not have any return value
        */
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

        /*
        *	METHOD          : ShowError()
        *	DESCRIPTION		:
        *		This method is used to show an error message to the user, specifically when they select none of the available 
        *		options they can choose to influence the generation of their password. As such, they will be notified of the
        *		error and the color of the text will change alongside its visibility through data-binding.
        *	PARAMETERS		:
        *		void            :   Void is used as there are no parameters
        *	RETURNS			:
        *		void	        :   This method does not have any return value
        */
        private void ShowError()
        {
            PasswordBoxContent = Constants.kErrorMessage;
            PasswordBoxColor = "Red";
            PasswordBoxVisibility = true;
        }

        /*
        *	METHOD          : ShowPassword()
        *	DESCRIPTION		:
        *		This method will be used in order to show the user the randomly generated passowrd that will be 
        *		created. The content of the textbox that contains the data-binding will change to be the generated
        *		password found within the "Password" model of this application. If an error was present, the text will
        *		change to be black instead of red. 
        *	PARAMETERS		:
        *		void            :   Void is used as there are no parameters
        *	RETURNS			:
        *		void	        :   This method does not have any return value
        */
        private void ShowPassword()
        {
            PasswordBoxContent = model.ActualPassword;
            PasswordBoxColor = "Black";
            PasswordBoxVisibility = true;
        }

        /*
        *	METHOD          : NavigateToHelp(object obj)
        *	DESCRIPTION		:
        *		This method will navigate the user to the help page to help them better understand how to use
        *		the passoword generator application. As such, the new instance of the Help page will be created
        *		and the main windows content will show the new page.
        *	PARAMETERS		:
        *		object obj       :   This is the optional parameter used with RelayCommands
        *	RETURNS			:
        *		void	         :   This method does not have any return value
        */
        private void NavigateToHelp(object obj)
        {
            var window = Application.Current.MainWindow;
            window.Content = new HelpPage();
        }

        /*
        *	METHOD          : CopyToClipBoard(object obj)
        *	DESCRIPTION		:
        *		This method will be used to copy the newly created password to the users clipboard. As such, 
        *		they will be able to immediately paste and use the password. However, the user is also free to
        *		copy the password themselves as the password textbox is set to read only (still allows copying
        *		unlike label).
        *	PARAMETERS		:
        *		object obj       :   This is the optional parameter used with RelayCommands
        *	RETURNS			:
        *		void	         :   This method does not have any return value
        */
        private void CopyToClipBoard(object obj)
        {
            Clipboard.SetText(PasswordBoxContent);
            PasswordSavedVisibility = true;
        }
    }
}