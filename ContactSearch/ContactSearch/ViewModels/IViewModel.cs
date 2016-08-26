using ContactSearch.ScreenControllers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ContactSearch.ViewModels
{
    /// <summary>
    /// The generic IViewModel interface.
    /// All view models should implement this.
    /// </summary>
    /// <typeparam name="T"></typeparam>
    interface IViewModel<T> where T : IScreenController
    {
        /// <summary>
        /// Gets the controller.
        /// </summary>
        /// <value>
        /// The controller.
        /// </value>
        T Controller { get; }
    }
}
