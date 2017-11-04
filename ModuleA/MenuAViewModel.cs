using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ModuleA
{
    class MenuAViewModel : INotifyPropertyChanged
    {
        public MenuAViewModel()
        {
            MenuAViewTitle = "Hi I'm View A";
        }

        private string _menuAViewTitle;

        public string MenuAViewTitle
        {
            get { return _menuAViewTitle; }
            set
            {
                _menuAViewTitle = value;
                OnPropertyChanged("MenuAViewTitle");
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
