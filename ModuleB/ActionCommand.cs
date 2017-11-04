using System;
using System.Windows.Input;
using Microsoft.Practices.Prism.Regions;

namespace ModuleB
{
    public class ActionCommand : ICommand
    {
        private IRegionManager _regionManager;
        private const string MainRegion = "MainRegion";
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

            var registeredViews = _regionManager.Regions[MainRegion].Views;
            foreach (var registeredView in registeredViews)
            {
                if (registeredView.GetType() == typeof(MenuBView))
                {
                    _regionManager.Regions[MainRegion].Activate(registeredView);
                    return;
                }
            }

            _regionManager.RegisterViewWithRegion(MainRegion, typeof(MenuBView));

            _regionManager.RequestNavigate(MainRegion, "MenuBView");
        }
    }
}