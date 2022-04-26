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
using MySql.Data.MySqlClient;

namespace AplicacaoEscola
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void btSalvar_Click(object sender, RoutedEventArgs e)
        {
            string nomeFantasia = txtNomeFantasia.Text;
            string cnpj = txtCnpj.Text;
            string razaoSocial = txtRazaoSocial.Text;
            string inscricaoEst = txtInscricaoEst.Text;
            string nomeResp = txtNomeResp.Text;
            string telefoneResp = txtTelefoneResp.Text;
            string telefoneEscola = txtTelefoneEscola.Text;
            string email = txtEmail.Text;
            string rua = txtRua.Text;
            string numero = txtNumero.Text;
            string bairro = txtBairro.Text;
            string complemento = txtComplemento.Text;
            string cep = txtCep.Text;
            string cidade = txtCidade.Text;
            string estado = cbEstado.Text;
            var dataCriacao = dpDataCriacao.SelectedDate?.ToString("yyyy-MM-dd");
            string tipo = rdPublica.IsChecked == true ? "Pública" : "Privada";
            MessageBox.Show(" Nome: " + nomeFantasia +
                            "\n CNPJ: " + cnpj +
                            "\n Razão Social: " + razaoSocial +
                            "\n Inscrição Estadual: " + inscricaoEst +
                            "\n Tipo: " + tipo +
                            "\n Data de Criação: " + dataCriacao +
                            "\n Nome do Responsável: " + nomeResp +
                            "\n Telefone do Responsável: " + telefoneResp +
                            "\n Telefone da Escola: " + telefoneEscola +
                            "\n Email: " + email +
                            "\n Rua: " + rua +
                            "\n Número: " + numero +
                            "\n Bairro: " + bairro +
                            "\n Complemento: " + complemento +
                            "\n CEP: " + cep +
                            "\n Cidade: " + cidade +
                            "\n Estado: " + estado, "PDS - 2º Bimestre", MessageBoxButton.OK, MessageBoxImage.Information);

            var conexao = new MySqlConnection("server=localhost;database=bd_escola_Artemis_Educacional;port=3360;user=root;password=root");

            try
            {
                conexao.Open();
                var comando = conexao.CreateCommand();
                comando.CommandText = $"insert into Escola values(null, '{nomeFantasia}', '{razaoSocial}' , '{cnpj}', '{inscricaoEst}', '{tipo}', '{dataCriacao}', " +
                    $"'{nomeResp}', '{telefoneResp}', '{email}', '{telefoneEscola}', '{rua}', {numero}, '{bairro}', '{complemento}', '{cep}', '{cidade}', '{estado}');";

                var resultado = comando.ExecuteNonQuery();
                if (resultado > 0)
                    MessageBox.Show("Registro inserido com sucesso!", "PDS - 2º Bimestre", MessageBoxButton.OK, MessageBoxImage.Information);
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
    }
}
