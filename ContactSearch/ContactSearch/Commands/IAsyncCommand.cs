using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace ContactSearch.Commands
{
    /// <summary>
    /// The IAsyncCommand interface.
    /// </summary>
    /// <seealso cref="System.Windows.Input.ICommand" />
    public interface IAsyncCommand : ICommand
    {
        /// <summary>
        /// Executes the asynchronous.
        /// </summary>
        /// <param name="parameter">The parameter.</param>
        /// <returns></returns>
        Task ExecuteAsync(object parameter);
    }
}
