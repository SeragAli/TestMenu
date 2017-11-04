using Interfaces;
using Microsoft.Practices.Prism.Modularity;
using Microsoft.Practices.Unity;

namespace ModuleB
{
    public class Module : IModule
    {
        private IUnityContainer _unityContainer;
        public Module(IUnityContainer unityContainer)
        {
            _unityContainer = unityContainer;
        }
        public void Initialize()
        {
            _unityContainer.RegisterType<IMainMenuItem, MenuB>("MenuB");
        }
    }
}
