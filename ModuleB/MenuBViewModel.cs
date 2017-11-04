using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ModuleB
{
    class MenuBViewModel : INotifyPropertyChanged
    {
        public MenuBViewModel()
        {
            MenuBViewTitle = "Hi I'm View B";
        }

        private string _MenuBViewTitle;

        public string MenuBViewTitle
        {
            get { return _MenuBViewTitle; }
            set
            {
                _MenuBViewTitle = value;
                OnPropertyChanged("MenuBViewTitle");
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;

        protected virtual void OnPropertyChanged(string propertyName)
        {
            PropertyChangedEventHandler handler = PropertyChanged;
            if (handler != null) handler(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
