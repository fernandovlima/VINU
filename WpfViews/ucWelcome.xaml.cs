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
    /// Interação lógica para ucWelcome.xam
    /// </summary>
    public partial class ucWelcome : UserControl
    {
        public event EventHandler botaoUsuarioClick, botaoVinhoClick;

        public ucWelcome()
        {
            InitializeComponent();

            
        }

        private void btnUsuarios_Click(object sender, RoutedEventArgs e)
        {
            if (botaoUsuarioClick != null)
                botaoUsuarioClick(this, new EventArgs());
        }

        private void btnVinhos_Click(object sender, RoutedEventArgs e)
        {
            if (botaoVinhoClick != null)
                botaoVinhoClick(this, new EventArgs());
        }

    }
}
