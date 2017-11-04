using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Interfaces;
using Microsoft.Practices.Prism.Regions;

namespace ModuleA
{
    /// <summary>
    /// Class that is responsible for creating menu item for MenuA
    /// </summary>
    public class MenuA : IMainMenuItem
    {
        private ActionCommand _command;
        private readonly IRegionManager _regionManager;

        /// <summary>
        /// Creates new instance of MenuA
        /// </summary>
        /// <param name="regionManager"></param>
        public MenuA(IRegionManager regionManager)
        {
            _regionManager = regionManager;
            _command = new ActionCommand(_regionManager);
            Childs = new List<IMainMenuItem>();
        }

        /// <summary>
        /// Gets or sets menu item name
        /// </summary>
        public string Name
        {
            get { return "MenuA"; }
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
        /// Gets or sets action performed when menu item is selected
        /// </summary>
        public System.Windows.Input.ICommand MenuAction
        {
            get { return _command; }
            set { _command = (ActionCommand)value; }
        }

        /// <summary>
        /// Gets or sets menu item childs
        /// </summary>
        public List<IMainMenuItem> Childs { get; set; }

    }
}
