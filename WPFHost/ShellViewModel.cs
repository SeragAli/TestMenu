using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;
using Interfaces;
using MenuConfiguration;
using Microsoft.Practices.Unity;

namespace WPFHost
{
    class ShellViewModel : INotifyPropertyChanged
    {
        private IUnityContainer _unityContainer;

        public ShellViewModel(IUnityContainer unityContainer)
        {
            _unityContainer = unityContainer;
            LoadMenusText = "Load Menus";
        }

        public List<IMainMenuItem> MenuItems
        {
            get { return _menuItems; }
            set
            {
                _menuItems = value;
                OnPropertyChanged("MenuItems");
            }
        }

        private string _loadMenusText;
        private List<IMainMenuItem> _menuItems;

        public string LoadMenusText
        {
            get { return _loadMenusText; }
            set
            {
                _loadMenusText = value;
                OnPropertyChanged("LoadMenusText");
            }
        }


        public ICommand LoadMenusCommand { get { return GetCommandObject(LoadMenusAction, () => true); } }

        private void LoadMenusAction()
        {
            MenuItems = LoadCustomMenus().ToList();
        }

        /// <summary>
        /// Gets menus from configuration dynamically
        /// </summary>
        /// <returns>collection of menus</returns>
        public IEnumerable<IMainMenuItem> LoadCustomMenus()
        {
            var existedItems = _unityContainer.ResolveAll<IMainMenuItem>();
            return LoadMenuItems(existedItems);
        }


        IEnumerable<IMainMenuItem> LoadMenuItems(IEnumerable<IMainMenuItem> menuItems)
        {
            var configurationSection = MenuConfigurationSection.Config;
            var items = configurationSection.MenuItems;
            var menuItemsToFilter = menuItems.ToList();
            var applicationMenuItems = new List<IMainMenuItem>();
            foreach (CustomMenuItem item in items)
            {
                var current = menuItemsToFilter.SingleOrDefault(x => x.Name == item.Name);
                if (current != null)
                {
                    FillCustomMenuItemObject(current, item);
                    applicationMenuItems.Add(current);
                }
                else
                {
                    MessageBox.Show("Can't Load Menu " + item.Name);
                }
            }

            var result = ReformatMenuItems(applicationMenuItems);

            return result;
        }


        private IEnumerable<IMainMenuItem> ReformatMenuItems(List<IMainMenuItem> menuItemsList)
        {
            var formatedMenuItems = new List<IMainMenuItem>();

            var parents = menuItemsList.Where(x => string.IsNullOrEmpty(x.Parent)).OrderBy(x => x.Order);
            foreach (var menuItem in parents)
            {
                CheckForChilds(menuItem, menuItemsList);
                formatedMenuItems.Add(menuItem);
            }

            return formatedMenuItems;
        }

        private static void CheckForChilds(IMainMenuItem menuItem, IEnumerable<IMainMenuItem> menuItemsList)
        {
            var mainMenuItems = menuItemsList as IMainMenuItem[] ?? menuItemsList.ToArray();
            var childs = mainMenuItems.Where(x => x.Parent == menuItem.Name).OrderBy(x => x.Order);
            if (childs.Any())
            {
                foreach (var child in childs)
                {
                    menuItem.Childs.Add(child);
                }
                foreach (var child in childs)
                {
                    CheckForChilds(child, mainMenuItems);
                }
            }

        }

        private void FillCustomMenuItemObject(IMainMenuItem current, CustomMenuItem item)
        {
            current.Text = item.Text;
            current.Order = item.Order;
            current.Active = item.Active;
            current.Parent = item.Parent;
        }

        public event PropertyChangedEventHandler PropertyChanged;

        protected virtual void OnPropertyChanged(string propertyName)
        {
            PropertyChangedEventHandler handler = PropertyChanged;
            if (handler != null) handler(this, new PropertyChangedEventArgs(propertyName));
        }

        /// <summary>
        /// Get object type of ICommand
        /// </summary>
        /// <param name="action">Action to be performed by the command</param>
        /// <param name="condition">Condition to enable or disable the command</param>
        /// <returns>Object type of ICommand</returns>
        private static CommandBase GetCommandObject(Action action, Func<bool> condition)
        {
            return new CommandBase(action, condition);
        }
    }
}
