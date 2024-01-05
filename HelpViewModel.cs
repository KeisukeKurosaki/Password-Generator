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
    public class HelpViewModel
    {
        public ICommand UseReturnButton { get; private set; }

        public HelpViewModel()
        {
            UseReturnButton = new RelayCommand(ReturnToApp);
        }

        private void ReturnToApp(object obj)
        {
            var window = Application.Current.MainWindow;
            window.Content = new InitialPage();
        }
    }
}
