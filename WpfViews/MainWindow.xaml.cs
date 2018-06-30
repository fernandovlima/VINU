using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace WpfViews
{
    /// <summary>
    /// Interação lógica para MainWindow.xam
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            //  usersTab.Content = Application.LoadComponent(new Uri("assemlyName;component/WelcomeView.xaml", UriKind.Relative));
            ucWelcome1.botaoUsuarioClick += new EventHandler(btnUsuarioClick);
            ucWelcome1.botaoVinhoClick += new EventHandler(btnVinhoClick);
        }

        private void TabControl_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (welcomeTab != null && welcomeTab.IsSelected) { }
                // do your staff
            if (usersTab != null && usersTab.IsSelected) { }
                    // do your staff
            if (vinhosTab != null && vinhosTab.IsSelected) { }
            // do your staff
        }

        public void btnUsuarioClick(object sender, EventArgs e)
        {
            tcBemVindo.SelectedIndex = 1;
        }

        public void btnVinhoClick(object sender, EventArgs e)
        {
            tcBemVindo.SelectedIndex = 2;
        }

    }
}
