using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace HomeWork.MVVM
{
    public class CommandVM : ICommand
    {
        public Action action;
        Func<bool> func;

        public CommandVM(Action action, Func<bool> func = null)
        {
            this.action = action;
            this.func = func;
        }

        event EventHandler? ICommand.CanExecuteChanged
        {
            add
            {
                CommandManager.RequerySuggested += value;
            }

            remove
            {
                CommandManager.RequerySuggested -= value;
            }
        }

        bool ICommand.CanExecute(object? parameter)
        {
            return func?.Invoke() ?? true;
        }

        void ICommand.Execute(object? parameter)
        {
            action();
        }
    }
}
