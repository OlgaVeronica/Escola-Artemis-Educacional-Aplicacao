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
            ComboBox? estado = cbEstado.SelectedItem as ComboBox;
            DatePicker dataCriacao = (DatePicker)dpDataCriacao.DataContext;
            MessageBox.Show(nomeFantasia + "\n" + cnpj + "\n" + razaoSocial + "\n" + inscricaoEst + "\n" + nomeResp + "\n"
                + telefoneResp + "\n" + telefoneEscola + "\n" + email + "\n" + rua + "\n" + numero + "\n" + bairro + "\n"
                + complemento + "\n" + cep + "\n" + dataCriacao + "\n" + estado);
                
        }
    }
}
