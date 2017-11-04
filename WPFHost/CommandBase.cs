using System;
using System.Windows.Input;

namespace WPFHost
{
    /// <summary>
    /// General class to create type of ICommand
    /// </summary>
    public class CommandBase : ICommand
    {
        #region Implementation of ICommand

        /// <summary>
        /// Defines the method to be called when the command is invoked.
        /// </summary>
        /// <param name="parameter">Data used by the command.  If the command does not require data to be passed, this object can be set to null.</param>
        public void Execute(object parameter)
        {
            if (_action != null)
                _action();
            if (_actionWithParm != null)
                _actionWithParm(parameter);
        }

        /// <summary>
        /// Defines the method that determines whether the command can execute in its current state.
        /// </summary>
        /// <returns>
        /// true if this command can be executed; otherwise, false.
        /// </returns>
        /// <param name="parameter">Data used by the command.  If the command does not require data to be passed, this object can be set to null.</param>
        public bool CanExecute(object parameter)
        {
            return _condition == null || _condition();
        }

        /// <summary>
        /// Occurs when changes occur that affect whether or not the command should execute.
        /// </summary>
        public event EventHandler CanExecuteChanged;
        /// <summary>
        /// Method to call CanExecuteChanged event handler
        /// </summary>
        public void OnCanExecuteChanged()
        {
            if (CanExecuteChanged != null)
                CanExecuteChanged(this, new EventArgs());
        }

        #endregion

        private readonly Action _action;
        private readonly Func<bool> _condition;
        private readonly Action<object> _actionWithParm;

        /// <summary>
        /// Creates new instance
        /// </summary>
        /// <param name="action">The action to be performed</param>
        /// <param name="condition">Condition to enable or disable command</param>
        public CommandBase(Action action, Func<bool> condition)
        {
            _action = action;
            _condition = condition;
        }
        /// <summary>
        /// Creates new instance
        /// </summary>
        /// <param name="action">The action to be performed</param>
        public CommandBase(Action action)
        {
            _action = action;
            _condition = null;
        }

        /// <summary>
        /// Creates new instance
        /// </summary>
        /// <param name="action">The action to be performed</param>
        /// <param name="condition">Condition to enable or disable command</param>
        public CommandBase(Action<object> action, Func<bool> condition)
        {
            _actionWithParm = action;
            _condition = condition;
        }
        /// <summary>
        /// Creates new instance
        /// </summary>
        /// <param name="action">The action to be performed</param>
        public CommandBase(Action<object> action)
        {
            _actionWithParm = action;
            _condition = null;
        }
    }
}