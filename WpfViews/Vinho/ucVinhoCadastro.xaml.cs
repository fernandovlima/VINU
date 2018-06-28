using System;
using System.Windows;
using System.Windows.Controls;
using Controllers;
using Models;


namespace WpfViews.Vinho
{
    /// <summary>
    /// Interação lógica para ucVinhoCadastro.xam
    /// </summary>
    public partial class ucVinhoCadastro : UserControl
    {
        WineController wc = new WineController();
        Wine wine = new Wine();

        public ucVinhoCadastro()
        {
            InitializeComponent();
        }

        private void btnCadastrarVinho_Click(object sender, RoutedEventArgs e)
        {

            validaCamposCadastro();

            wine.NomeVinho = txtNomeProduto.Text;
            wine.Valor = Convert.ToDouble(txtValorProduto.Text.Replace("R$ ", ""));
            wine.Score = rbNotaVinho.Value;

            wc.AddNew(wine);

            //Feedback ao usuário após sucesso no cadastro
            MessageBoxResult result = MessageBox.Show("Vinho " + txtNomeProduto.Text + " cadastrado com sucesso!");

            //Limpa os campos para novo cadastro.
            txtNomeProduto.Text = txtValorProduto.Text = "";
            rbNotaVinho.Value = 3;

        }


        private void validaCamposCadastro()
        {
            if (string.IsNullOrEmpty(txtNomeProduto.Text))
                throw new NullReferenceException("O campo nome é obrigatório.");

            if (string.IsNullOrEmpty(txtValorProduto.Text))
                throw new NullReferenceException("O campo login é obrigatório.");

        }
    }

}
