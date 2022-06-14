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
    /// Interaction logic for CadastroCurso.xaml
    /// </summary>
    public partial class CadastroCurso : Window
    {

        public CadastroCurso()
        {
            InitializeComponent();
        }

        private void btSalvar_Click(object sender, RoutedEventArgs e)
        {
            Curso _curso = new Curso();
            _curso.NomeCurso = txtNomeCurso.Text;
            _curso.CargaHoraria = txtCargaHoraria.Text;
            _curso.Descricao = txtDescricaoCurso.Text;
            _curso.Turno = cbTurno.Text;
       
            try
            {
                var dao = new CursoDAO();
                dao.Insert(_curso);
                MessageBox.Show("Registro inserido com sucesso!", "PDS - 2º Bimestre", MessageBoxButton.OK, MessageBoxImage.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
    
            ListagemCurso listagem = new ListagemCurso();
            listagem.ShowDialog();

            txtCargaHoraria.Clear();
            txtDescricaoCurso.Clear();
            txtNomeCurso.Clear();
            cbTurno.SelectedIndex = -1;
        }
    }
}
