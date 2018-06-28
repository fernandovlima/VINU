using Controllers;
using Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
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

namespace WpfViews.Usuario
{
    /// <summary>
    /// Interação lógica para ucUsuarioLista.xam
    /// </summary>
    public partial class ucUsuarioLista : UserControl, INotifyPropertyChanged
    {

        UserController uc = new UserController();
        int keepID;

        public event PropertyChangedEventHandler PropertyChanged;

        private ICollection<User> _ListaUsers;

        public ICollection<User> ListaUsers
        {
            get
            {
                return _ListaUsers;
            }
            set
            {
                _ListaUsers = value;
                OnPropertyChanged(new PropertyChangedEventArgs("ListaUsers"));
            }
        }
        
        public ucUsuarioLista()
        {
            InitializeComponent();
            ListaUsers = uc.ListAll();
            DGListaUsuarios.ItemsSource = ListaUsers;
        }


        public void OnPropertyChanged(PropertyChangedEventArgs e)
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, e);
            }
        }


        private void DGListaUsuarios_Initialized(object sender, EventArgs e)
        {
            DGListaUsuarios.ItemsSource = uc.ListAll();
        }

        //Ação DELETA USUÁRIO
        private void btnDeletar_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                uc.Delete(keepID);
                atualizaListaUsuarios();

                //Limpa Campos
                limparCamposUpdate();


            }
            catch (Exception ex)
            {

                MessageBox.Show("Erro ao excluir usuário: " + ex);
            }

        }

        //Ação ATUALIZA LISTA
        private void btnAtualizaLista_Click(object sender, RoutedEventArgs e)
        {
            atualizaListaUsuarios();
        }

        //Ação ATUALIZA USUÁRIO
        private void btnUserUpdate_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                //Cria usuário para edião
                User user = uc.SearchById(keepID);
                user.Nome = txtNomeUpdate.Text;
                user.Login = txtLoginUpdate.Text;
                user.Senha = txtPasswordUpdate.Password;
                uc.Edit(user);

                MessageBox.Show("Usuário " + user.Nome + " atualizado!");

                //Limpa Campos
                limparCamposUpdate();

                //Atualiza Lista
                DGListaUsuarios.Items.Refresh();
            }
            catch (Exception ex)
            {

                MessageBox.Show("Erro ao atualizar usuário: " + ex.Message );
            }
            
        }

        private void limparCamposUpdate()
        {
            txtIdUpdate.Text = "";
            txtNomeUpdate.Text = "";
            txtLoginUpdate.Text = "";
            txtPasswordUpdate.Password = "";
        }

        public void atualizaListaUsuarios()
        {
            DGListaUsuarios.ItemsSource = ListaUsers;
            DGListaUsuarios.ItemsSource = uc.ListAll();
            DGListaUsuarios.Items.Refresh();
        }

        private void DGListaUsuarios_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

            //myInt.ToString()
            User user = (DGListaUsuarios.SelectedCells[0].Item != null) ? (User)DGListaUsuarios.SelectedCells[0].Item : new User();
            if (user.Nome.Length > 0)
            {
                keepID = user.UserID;

                //preenche os campos para atualizar usuário
                txtIdUpdate.Text = user.UserID.ToString();
                txtNomeUpdate.Text = user.Nome;
                txtLoginUpdate.Text = user.Login;
                txtPasswordUpdate.Password = user.Senha;

                //ativa botão de atualização
                btnUserUpdate.Foreground = new SolidColorBrush(Colors.White);
                btnUserUpdate.IsEnabled = true;

            }

        }

    }
}
