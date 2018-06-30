using Controllers;
using Models;
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

namespace WpfViews.Usuario
{
    /// <summary>
    /// Interação lógica para ucUsuarioCadastro.xam
    /// </summary>
    public partial class ucUsuarioCadastro : UserControl
    {

        UserController uc = new UserController();

        public ucUsuarioCadastro()
        {
            InitializeComponent();
        }

        private void btnCadastrarUsuario_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                validaCamposCadastro(); //Valida se os campos de cadastro foram preenchidos

                User user = new User();
                user.Nome = txtNome.Text;
                user.Login = txtLogin.Text;
                user.Senha = txtSenha.Text;
                uc.AddNew(user);

                //Feedback ao usuário após sucesso no cadastro
                MessageBoxResult result = MessageBox.Show("Usuário " + txtNome.Text + " cadastrado com sucesso!");                

                //Limpa os campos para novo cadastro.
                txtNome.Text = txtLogin.Text = txtSenha.Text = "";

                //atualiza lista
                ucUsuarioLista lista = new ucUsuarioLista();
                lista.atualizaListaUsuarios();
            }

            catch (Exception ex)
            {
                MessageBox.Show("Erro ao salvar (" + ex.Message + ")");
            }
        }

        private void validaCamposCadastro()
        {
            if (string.IsNullOrEmpty(txtNome.Text))
                throw new NullReferenceException("O campo nome é obrigatório.");

            if (string.IsNullOrEmpty(txtLogin.Text))
                throw new NullReferenceException("O campo login é obrigatório.");

            if (string.IsNullOrEmpty(txtSenha.Text))
                throw new NullReferenceException("O campo senha é obrigatório.");
        }
    }
}
