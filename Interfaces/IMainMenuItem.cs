using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace Interfaces
{
    /// <summary>
    /// Run time menu item interface
    /// </summary>
    public interface IMainMenuItem
    {
        /// <summary>
        /// Menu item name
        /// </summary>
        string Name { get; }
        /// <summary>
        /// Menu item text
        /// </summary>
        string Text { get; set; }
        /// <summary>
        /// Menu item order
        /// </summary>
        int Order { get; set; }
        /// <summary>
        /// Determine if menu item enabled or not
        /// </summary>
        bool Active { get; set; }
        /// <summary>
        /// Determine the parent menu item
        /// </summary>
        string Parent { get; set; }
        /// <summary>
        /// Detemine a list of childs
        /// </summary>
        List<IMainMenuItem> Childs { get; set; }
        /// <summary>
        /// Determine the action done when menu item clicked
        /// </summary>
        ICommand MenuAction { get; set; }
    }
}
