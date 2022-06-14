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
using AplicacaoEscola.Models;

namespace AplicacaoEscola.Views
{
    /// <summary>
    /// Interaction logic for ListagemEscola.xaml
    /// </summary>
    public partial class ListagemEscola : Window
    {
        public ListagemEscola()
        {
            InitializeComponent();
            Loaded += ListagemEscola_Loaded;
        }

        private void ListagemEscola_Loaded(object sender, RoutedEventArgs e)
        {
            CarregarLista();
        }

        private void Button_Atualizar_Click(object sender, RoutedEventArgs e)
        {

        }
        private void Button_Remover_Click(object sender, RoutedEventArgs e)
        {
            var escolaSelecionada = dataGridEscola.SelectedItem as Escola;

            var resultado = MessageBox.Show($"Deseja realmente excluir \"{escolaSelecionada}\" dos registros?", "Confirmação de Exclusão",
                MessageBoxButton.YesNo, MessageBoxImage.Warning);

            try
            {
                if (resultado == MessageBoxResult.Yes)
                {
                    var dao = new EscolaDAO();
                    dao.Delete(escolaSelecionada);

                    MessageBox.Show("Registro Removido com Sucesso!");
                }
                CarregarLista();


            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        private void CarregarLista()
        {
            try
            {
                var dao = new EscolaDAO();
                List<Escola> listaEscolas = dao.List();

                dataGridEscola.ItemsSource = listaEscolas;

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

    }
}
