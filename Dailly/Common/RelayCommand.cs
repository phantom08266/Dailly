using System;
using System.Windows.Controls;
using System.Windows.Input;

namespace Dailly.Common
{
    public class RelayCommand : ICommand
    {
        public event EventHandler CanExecuteChanged;
        private Action<object> _exCute;
        private Func<object, bool> _canExcute;

        public RelayCommand(Action<object> exCute, Func<object, bool> canExcute)
        {
            this._exCute = exCute;
            this._canExcute = canExcute;
        }

        public bool CanExecute(object parameter)
        {
            Console.WriteLine("CanExecute");
            return this._canExcute == null || this._canExcute(parameter);
        }

        public void Execute(object parameter)
        {
            Console.WriteLine("Execute");
            this._exCute(parameter);
        }
    }
}
