using System;
using System.Threading.Tasks;

namespace ContactSearch.Commands
{
    /// <summary>
    /// The AsyncCommand command class.
    /// </summary>
    /// <seealso cref="ContactSearch.Commands.AsyncCommandBase" />
    public class AsyncCommand : AsyncCommandBase
    {
        #region Fields

        /// <summary>
        /// The can execute.
        /// </summary>
        private readonly Predicate<object> canExecute;

        /// <summary>
        /// The command
        /// </summary>
        private readonly Func<Task> command;

        #endregion Fields

        #region Constructors

        /// <summary>
        /// Initializes a new instance of the <see cref="AsyncCommand"/> class.
        /// </summary>
        /// <param name="command">The command.</param>
        public AsyncCommand(Func<Task> command) : this(command, DefaultCanExecute)
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="AsyncCommand"/> class.
        /// </summary>
        /// <param name="command">The command.</param>
        /// <param name="canExecute">The can execute.</param>
        public AsyncCommand(Func<Task> command, Predicate<object> canExecute)
        {
            this.command = command;
            this.canExecute = canExecute;
        }

        #endregion Constructors

        #region Methods

        #region ICommand Implementation

        /// <summary>
        /// Determines whether this instance can execute the specified parameter.
        /// </summary>
        /// <param name="parameter">The parameter.</param>
        /// <returns></returns>
        public override bool CanExecute(object parameter)
        {
            return canExecute != null && canExecute(parameter);
        }

        /// <summary>
        /// Executes the asynchronous.
        /// </summary>
        /// <param name="parameter">The parameter.</param>
        /// <returns></returns>
        public override Task ExecuteAsync(object parameter)
        {
            return command();
        }

        #endregion ICommand Implementation

        #region Privates

        /// <summary>
        /// Defaults the can execute.
        /// </summary>
        /// <param name="parameter">The parameter.</param>
        /// <returns></returns>
        private static bool DefaultCanExecute(object parameter)
        {
            return true;
        }

        #endregion Privates

        #endregion Methods
    }
}
