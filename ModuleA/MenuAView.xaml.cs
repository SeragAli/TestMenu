using System.Windows;

namespace ModuleA
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MenuAView 
    {
        public MenuAView()
        {
            InitializeComponent();
            this.DataContext = new MenuAViewModel();
        }
    }
}
