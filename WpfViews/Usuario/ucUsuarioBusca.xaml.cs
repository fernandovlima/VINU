using Controllers;
using Models;
using System;
using System.Collections;
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
using System.Windows.Shapes;

namespace WpfViews.Usuario
{
    /// <summary>
    /// Lógica interna para ucUsuarioBusca.xaml
    /// </summary>
    public partial class ucUsuarioBusca : UserControl
    {
        UserController uc = new UserController();



        public ucUsuarioBusca()
        {
            InitializeComponent();
            dgListaBuscaUsuarios.ItemsSource = new List<User>();
        }

        private void btnBuscaUser_Click(object sender, RoutedEventArgs e)
        {
            ICollection<User> result = uc.ListByName(txtBuscaUser.Text);


            if (boxResultado.Visibility == Visibility.Collapsed) boxResultado.Visibility = Visibility.Visible;

            dgListaBuscaUsuarios.ItemsSource = new List<User>();
            dgListaBuscaUsuarios.ItemsSource = result;

        }

        private void dgListaBuscaUsuarios_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            User user = (dgListaBuscaUsuarios.SelectedCells[0].Item != null) ? (User)dgListaBuscaUsuarios.SelectedCells[0].Item : new User();
            if (user.Nome.Length > 0)
            {
                //preenche os campos de visualização do usuário
                txtUsuarioId.Text = "( #" + user.UserID.ToString() + " )";
                txtUsuarioNome.Text = user.Nome;
                txtUsuarioLogin.Text = user.Login;

               

            }
        }
               
    }
}
