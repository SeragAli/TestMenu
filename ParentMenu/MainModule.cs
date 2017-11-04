using System;
using System.Collections.Generic;
using System.Windows.Input;
using Interfaces;

namespace ParentMenu
{
    /// <summary>
    /// Class that is responsible for creating menu item for booklet Reports
    /// </summary>
    public class MainModule : IMainMenuItem
    {
        public MainModule()
        {
            Childs = new List<IMainMenuItem>();
        }
        /// <summary>
        /// Gets or sets menu item name
        /// </summary>
        public string Name
        {
            get { return "MainModule"; }
        }

        /// <summary>
        /// Gets or sets  menu item text
        /// </summary>
        public string Text { get; set; }

        /// <summary>
        /// Gets or sets menu item order
        /// </summary>
        public int Order { get; set; }

        /// <summary>
        /// Gets or sets value indicating that menu item is active or not
        /// </summary>
        public bool Active { get; set; }

        /// <summary>
        /// Gets or sets menu item parent menu item
        /// </summary>
        public string Parent { get; set; }

        /// <summary>
        /// Gets or sets menu item childs
        /// </summary>
        public List<IMainMenuItem> Childs { get; set; }


        public ICommand MenuAction { get; set; }


    }
}
