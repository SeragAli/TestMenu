using System;
using System.Windows.Input;
using Microsoft.Practices.Prism.Regions;

namespace ModuleB
{
    public class ActionCommand : ICommand
    {
        private IRegionManager _regionManager;
        public ActionCommand(IRegionManager regionManager)
        {
            _regionManager = regionManager;
        }
        public bool CanExecute(object parameter)
        {
            return true;
        }

        public event EventHandler CanExecuteChanged;

        public void Execute(object parameter)
        {
            _regionManager.RegisterViewWithRegion("MainRegion", typeof(MenuBView));

            _regionManager.RequestNavigate("MainRegion", "MenuBView");
        }
    }
}