using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text.RegularExpressions;
using System.Windows;
using System.Windows.Controls;
using Controllers;
using MaterialDesignThemes.Wpf;
using Models;


namespace WpfViews.Vinho
{
    /// <summary>
    /// Interação lógica para ucVinhoCadastro.xam
    /// </summary>
    public partial class ucVinhoCadastro : UserControl, INotifyPropertyChanged
    {
        WineController wc = new WineController();
        Wine wine = new Wine();
        String tituloArea = "Cadastrar novo Vinho";
        IEnumerable<Wine> result = new List<Wine>();

        public event PropertyChangedEventHandler PropertyChanged;

        private ICollection<Wine> _ListaWine;
        public ICollection<Wine> ListaWine
        {
            get
            {
                return _ListaWine;
            }
            set
            {
                _ListaWine = value;
                OnPropertyChanged(new PropertyChangedEventArgs("ListaWine"));
            }
        }

        public void OnPropertyChanged(PropertyChangedEventArgs e)
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, e);
            }
        }


        public ucVinhoCadastro()
        {
            InitializeComponent();
            ListaWine = wc.ListAll();
            dgListaVinhos.ItemsSource = ListaWine;
            dgListaVinhos.CanUserResizeColumns = true;

            txtTitulo.Text = tituloArea;

        }

        private void btnCadastrarVinho_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                txtTitulo.Text = tituloArea;

                validaCamposCadastro();

                if (wc.SearchById(wine.VinhoID) == null)
                {
                    //envia o objeto Wine padrão da classe. Esse objeto é inicializado no início da classe
                    preencheDadosVinho(wine, true);

                    wc.AddNew(wine);


                    //Feedback ao usuário após sucesso no cadastro
                    MessageBoxResult result = MessageBox.Show("Vinho " + txtNomeProduto.Text + " cadastrado com sucesso!");

                }
                else
                {
                    //Remove a seleção da linha na tabela
                    dgListaVinhos.UnselectAllCells();
                }
                //Limpa os campos para novo cadastro.
                limpaCampos();

                //Atualiza Lista
                atualizaListaVinhos();

                //Reseta Botões
                resetaBotoes();
            }
            catch (Exception ex)
            {

                MessageBox.Show("Erro ao cadastrar: " + ex.Message);
            }
           

        }

        private void btnAtualizarVinho_Click(object sender, RoutedEventArgs e)
        {
            try
            {

                dgListaVinhos.UnselectAllCells(); //remove a seleção da linha na tabela

                // busca Vinho
                wine = wc.SearchById(Int32.Parse(txtVinhoId.Text));

                //envia para atualizar dados de acordo com os campos
                preencheDadosVinho(wine, false);

                wc.Edit(wine);

                atualizaListaVinhos();
                limpaCampos();
                resetaBotoes();

            }
            catch (Exception ex)
            {

                MessageBox.Show("Erro ao atualizar: " + ex.Message);
            }           

        }


        private void btnDeletarVinho_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                dgListaVinhos.UnselectAllCells(); //Tira a seleção da linha na tabela

                wc.Delete(wine.VinhoID);

                atualizaListaVinhos();

                limpaCampos();


                resetaBotoes();

            }
            catch (Exception ex)
            {

                MessageBox.Show("Erro ao excluir: " + ex.Message);
            }

        }

        //Agrega o R$ ao campo quando focado
        private void txtValorProduto_GotFocus(object sender, RoutedEventArgs e)
        {
            addCurrencyIcon();
        }
        //Agrega o R$ ao campo quando perde o foco
        private void txtValorProduto_LostFocus(object sender, RoutedEventArgs e)
        {
            addCurrencyIcon();

        }
        //Adiciona R$ ao campo de valor 
        private void addCurrencyIcon()
        {
            txtValorProduto.Text = txtValorProduto.Text.Replace("R$ ", "");
            txtValorProduto.Text = "R$ " + txtValorProduto.Text;
        }

        private void validaCamposCadastro()
        {
            if (string.IsNullOrEmpty(txtNomeProduto.Text))
                throw new NullReferenceException("O campo nome é obrigatório.");

            if (string.IsNullOrEmpty(txtValorProduto.Text))
                throw new NullReferenceException("O campo login é obrigatório.");

        }

        private void limpaCampos()
        {
            txtNomeProduto.Text = txtValorProduto.Text = txtVinhoId.Text = "";
            rbNotaVinho.Value = 3;
            wine = new Wine();
        }

        private void preencheDadosVinho(Wine w, Boolean novo)
        {
            if (!novo)
            {
                w.VinhoID = Int32.Parse(txtVinhoId.Text);

            }
            w.NomeVinho = txtNomeProduto.Text;
            w.Valor = Double.Parse(txtValorProduto.Text.Replace("R$ ", ""));
            w.Score = rbNotaVinho.Value;
        }

        private void atualizaListaVinhos()
        {
            dgListaVinhos.ItemsSource = ListaWine;
            dgListaVinhos.ItemsSource = wc.ListAll();
            dgListaVinhos.Items.Refresh();
        }

        private void resetaBotoes()
        {
            txtTitulo.Text = tituloArea;
            btnCadastrarVinho.Content = "Novo";
            btnAtualizarVinho.Visibility = Visibility.Hidden;
            btnDeletarVinho.Visibility = Visibility.Hidden;
        }

        private void dgListaVinhos_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            //Wine tmp = (Wine)dgListaVinhos.SelectedCells[0].Item;
            Wine tmp = (Wine)dgListaVinhos.SelectedItem;

            if (tmp != null)
            {
                wine = tmp;

                //preenche os campos para atualizar o vinho
                txtVinhoId.Text = wine.VinhoID.ToString();
                txtNomeProduto.Text = wine.NomeVinho;
                txtValorProduto.Text = "R$ " + wine.Valor.ToString();
                rbNotaVinho.Value = (int)wine.Score;

                txtTitulo.Text = "Atualizar " + wine.NomeVinho;
                btnCadastrarVinho.Content = "Novo Vinho";
                btnAtualizarVinho.Visibility = Visibility.Visible;
                btnDeletarVinho.Visibility = Visibility.Visible;

            }
            

        }

        //Busca por Vinho

        private void btnBuscaVinho_Click(object sender, RoutedEventArgs e)
        {
            ICollection<Wine> result = wc.ListByName(txtBuscaVinho.Text);
            dgListaVinhos.ItemsSource = new List<Wine>();
            dgListaVinhos.ItemsSource = result;
        }

        private void txtBuscaVinho_KeyDown(object sender, System.Windows.Input.KeyEventArgs e)
        {
            
        }

        private void txtBuscaVinho_TextChanged(object sender, TextChangedEventArgs e)
        {
            string produtoBusca = txtBuscaVinho.Text;

            switch (produtoBusca.Length)
            {
                case 0:
                case 1:

                    dgListaVinhos.ItemsSource = new List<Wine>();
                    dgListaVinhos.ItemsSource = result = wc.ListByName(produtoBusca);
                    break;

                default:

                    IEnumerable<Wine> buscaFiltro = from w in result
                                                        where w.NomeVinho.ToLower().Contains(produtoBusca.ToLower())
                                                        select w;

                   // dgListaVinhos.ItemsSource = new List<Wine>();
                    dgListaVinhos.ItemsSource = buscaFiltro;

                    break;
            }
            
        }
    }

}
