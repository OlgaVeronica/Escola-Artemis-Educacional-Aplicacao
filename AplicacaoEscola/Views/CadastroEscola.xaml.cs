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
using System.Windows.Shapes;
using MySql.Data.MySqlClient;
using AplicacaoEscola.Database;
using AplicacaoEscola.Models;

namespace AplicacaoEscola.Views
{
    /// <summary>
    /// Lógica interna para CadastroEscola.xaml
    /// </summary>
    public partial class CadastroEscola : Window
    {
        private Escola _escola = new Escola();
       
        public CadastroEscola()
        {
            InitializeComponent();
        }

        private void btSalvar_Click(object sender, RoutedEventArgs e)
        {
            _escola.NomeFantasia = txtNomeFantasia.Text;
            _escola.Cnpj = txtCnpj.Text;
            _escola.RazaoSocial = txtRazaoSocial.Text;
            _escola.InscricaoEst = txtInscricaoEst.Text;
            _escola.NomeResp = txtNomeResp.Text;
            _escola.TelefoneResp = txtTelefoneResp.Text;
            _escola.TelefoneEscola = txtTelefoneEscola.Text;
            _escola.Email = txtEmail.Text;
            _escola.Rua = txtRua.Text;
            _escola.Numero = Convert.ToInt32(txtNumero.Text);
            _escola.Bairro = txtBairro.Text;
            _escola.Complemento = txtComplemento.Text;
            _escola.Cep= txtCep.Text;
            _escola.Cidade = txtCidade.Text;
            _escola.Estado = cbEstado.Text;
            _escola.DataCriacao = dpDataCriacao.SelectedDate;
            bool rdTipo = rdPublica.IsChecked == true;
            _escola.SetTipo(rdTipo);
            try
            {
                var dao = new EscolaDAO();
                dao.Insert(_escola);
                MessageBox.Show("Registro inserido com sucesso!", "PDS - 2º Bimestre", MessageBoxButton.OK, MessageBoxImage.Information);
            } catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            txtNomeFantasia.Clear();
            txtCnpj.Clear();
            txtRazaoSocial.Clear();
            txtInscricaoEst.Clear();
            txtNomeResp.Clear();
            txtTelefoneResp.Clear();
            txtTelefoneEscola.Clear();
            txtEmail.Clear();
            txtRua.Clear();
            txtNumero.Clear();
            txtBairro.Clear();
            txtComplemento.Clear();
            txtCep.Clear();
            txtCidade.Clear();
            cbEstado.SelectedIndex = -1;
            dpDataCriacao.SelectedDate = null;
            rdPrivada.IsChecked = false;
            rdPublica.IsChecked = false;

            ListagemEscola listagem = new ListagemEscola();
            listagem.ShowDialog();
        }
    }
}
