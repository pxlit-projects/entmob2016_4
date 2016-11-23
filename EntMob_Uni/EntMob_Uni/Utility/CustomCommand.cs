using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace EntMob_Uni.Utility
{
    public class CustomCommand : ICommand
    {
        private Action<Object> execute;
        private Predicate<object> canExecute;

        public CustomCommand(Action<object> execute, Predicate<object> canExecute)
        {
            this.execute = execute;
            this.canExecute = canExecute;
        }

        public event EventHandler CanExecuteChanged;

        /*In WinRT, you must update/raise CanExecuteChanged manually. 
        There is no CommandManager to do this globally.
        You could look at this as a pain in the neck, 
        or a serious performance boost now that CanExecute is not called constantly. 
        It does mean you have to think about cascading property changes 
        where before you did not have to. But this is how it is. */
        public void RaiseCanExecuteChanged()
        {
            if (CanExecuteChanged != null)
                CanExecuteChanged(this, EventArgs.Empty);
        }

        public bool CanExecute(object parameter)
        {
            bool b = canExecute == null ? true : canExecute(parameter);
            return b;
        }

        public void Execute(object parameter)
        {
            execute(parameter);
        }
    }
}
