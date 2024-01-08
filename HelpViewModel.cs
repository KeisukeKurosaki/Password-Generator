using System;
using System.Windows;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using System.Windows.Navigation;

namespace Password_Generator
{
    /*
    *	CLASS           : HelpViewModel
    *	DESCRIPTION		:
    *		This class is used in order to act as the viewmodel for the Help page. As of now, there is only 
    *		one data-binded button that will allow users to return to the main page of the application. However, 
    *		this is intended as the help page is meant to be simple and straight forward. Only one Relay command is
    *		used for now.
    */
    public class HelpViewModel
    {

        // Used to encapsulate UI interactions relating to the "Return To The Password Generator" button
        public ICommand UseReturnButton { get; private set; }

        /*
        *	CONSTRUCTOR     : HelpViewModel()
        *	DESCRIPTION		:
        *		This constructor instantiates an object of type HelpViewModel which is responsible for the 
        *		data-binding relating to the Help page that will be displayed to users if they wish to read 
        *		more about how the application operates. As of right now, there is only one button used in the 
        *		data-binding for this particular view, that being the return button, which is utilized with the
        *		UseReturnButton relay command.
        */
        public HelpViewModel()
        {
            UseReturnButton = new RelayCommand(ReturnToApp);
        }

        /*
        *	METHOD          : ReturnToApp(object obj)
        *	DESCRIPTION		:
        *		This method is used to return the user to the password generator's main application page to allow
        *		them to continue generating new passwords. As such, the data-binding relates to changing the view
        *		of the main window of the application to instead display the contents of the main page, instead of 
        *		the help page.
        *	PARAMETERS		:
        *		object obj        :   This is the optional parameter used with RelayCommands
        *	RETURNS			:
        *		void	          :   This method does not have any return value
        */
        private void ReturnToApp(object obj)
        {
            var window = Application.Current.MainWindow;
            window.Content = new InitialPage();
        }
    }
}
