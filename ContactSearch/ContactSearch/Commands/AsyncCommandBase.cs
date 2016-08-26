using System;
using System.Threading.Tasks;
using System.Windows.Input;

namespace ContactSearch.Commands
{
    /// <summary>
    /// The AsyncCommandBase class.
    /// This is the base for all asynch commands.
    /// </summary>
    /// <seealso cref="ContactSearch.Commands.IAsyncCommand" />
    public abstract class AsyncCommandBase : IAsyncCommand
    {
        #region Properties

        /// <summary>
        /// Defines the method that determines whether the command can execute in its current state.
        /// </summary>
        /// <param name="parameter">Data used by the command.  If the command does not require data to be passed, this object can be set to null.</param>
        /// <returns>
        /// true if this command can be executed; otherwise, false.
        /// </returns>
        public abstract bool CanExecute(object parameter);

        /// <summary>
        /// Executes the asynchronous.
        /// </summary>
        /// <param name="parameter">The parameter.</param>
        /// <returns>The task.</returns>
        public abstract Task ExecuteAsync(object parameter);

        #endregion Properties

        #region Methods

        /// <summary>
        /// Defines the method to be called when the command is invoked.
        /// </summary>
        /// <param name="parameter">Data used by the command.  If the command does not require data to be passed, this object can be set to null.</param>
        public async void Execute(object parameter)
        {
            await ExecuteAsync(parameter);
        }

        /// <summary>
        /// Occurs when changes occur that affect whether or not the command should execute.
        /// </summary>
        public event EventHandler CanExecuteChanged
        {
            add { CommandManager.RequerySuggested += value; }
            remove { CommandManager.RequerySuggested -= value; }
        }

        /// <summary>
        /// Raises the can execute changed.
        /// </summary>
        protected void RaiseCanExecuteChanged()
        {
            CommandManager.InvalidateRequerySuggested();
        }
        #endregion Methods
    }
}
