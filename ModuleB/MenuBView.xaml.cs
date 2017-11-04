using System.Windows;

namespace ModuleB
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MenuBView 
    {
        public MenuBView()
        {
            InitializeComponent();
            this.DataContext = new MenuBViewModel();
        }
    }
}
