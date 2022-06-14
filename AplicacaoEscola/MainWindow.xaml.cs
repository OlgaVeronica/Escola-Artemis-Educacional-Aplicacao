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
using AplicacaoEscola.Database;
using AplicacaoEscola.Views;

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

        private void btChamarCadastroEscola_Click(object sender, RoutedEventArgs e)
        {
            CadastroEscola cadastro = new CadastroEscola();
            cadastro.ShowDialog();
            this.Close();
        }

        private void btChamarCadastroCurso_Click(object sender, RoutedEventArgs e)
        {
            CadastroCurso cadastro = new CadastroCurso();
            cadastro.ShowDialog();
            this.Close();
        }
    }
}
