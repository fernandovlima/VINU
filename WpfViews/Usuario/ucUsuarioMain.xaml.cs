using System.Windows.Controls;
using Models;
using Controllers;
using System.Windows;

namespace WpfViews.Usuario
{
    /// <summary>
    /// Interação lógica para ucUsuarioMain.xam
    /// </summary>
    public partial class ucUsuarioMain : UserControl
    {
        public ucUsuarioMain()
        {
            InitializeComponent();

          //  DGListaUsuarios.ItemsSource = uc.ListAll();

        }

        private void TabControl_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (cadastrarUser != null && cadastrarUser.IsSelected) { }

            if (listarUsers != null && listarUsers.IsSelected)
            {
               
            }

            if (buscarUser != null && buscarUser.IsSelected) { }
        }

    }
}
