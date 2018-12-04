using Dailly.Common;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace Dailly.ViewModels.Login
{
    public class LoginViewModel : ViewModels.Base.ViewModelBase
    {
        private string _userID;
        private string _userPassword;
        private string loginEventMessage;
        private ICommand signUpBtn;
        private ICommand loginBtn;

        #region Command
        public ICommand SignUpBtn
        {
            get
            {
                signUpBtn = new RelayCommand(SignUpCommand, null);
                return signUpBtn;
            }
        }

        public ICommand LoginBtn
        {
            get
            {
                loginBtn = new RelayCommand(LoginCommand, null);
                return loginBtn;
            }
        }

        private bool CommandDefualtTrue(object args)
        {
            return true;
        }

        private void SignUpCommand(object args)
        {
            Console.WriteLine("SignUpCommand");
        }

        private void LoginCommand(object param)
        {
            if("admin".Equals(_userID) && "admin".ToString().Equals(_userPassword))
            {
                MainWindow mainWindow = new MainWindow();
                mainWindow.ShowDialog();
                LoginEventMessage = "Login Success.";
            }
            else
            {
                LoginEventMessage = "ID, Password Fail.";
            }
        }
        #endregion

        #region DataBinding Property
        public string UserID
        {
            get
            {
                return _userID;
            }
            set
            {
                _userID = value;
                OnPropertyChanged();
            }
        }
        
        public string UserPassword
        {
            get
            {
                return _userPassword;
            }
            set
            {
                _userPassword = value;
                OnPropertyChanged();
            }
        }

        public string LoginEventMessage
        {
            get
            {
                return loginEventMessage;
            }
            set
            {
                loginEventMessage = value;
                OnPropertyChanged();
            }
        }
        #endregion

    }
}
