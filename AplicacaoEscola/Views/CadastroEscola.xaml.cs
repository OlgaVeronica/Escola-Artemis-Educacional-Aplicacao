﻿using System;
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
            _escola.RazaoSocial = txtCnpj.Text;
            _escola.InscricaoEst=txtInscricaoEst.Text;
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
            _escola.DataCriacao = dpDataCriacao.SelectedDate?.ToString("yyyy-MM-dd");
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

            /*
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



            try
            {
                var conexao = new Conexao();
                var comando = conexao.Query();
                comando.CommandText = $"insert into Escola values(null, '{nomeFantasia}', '{razaoSocial}' , '{cnpj}', '{inscricaoEst}', '{tipo}', '{dataCriacao}', " +
                    $"'{nomeResp}', '{telefoneResp}', '{email}', '{telefoneEscola}', '{rua}', {numero}, '{bairro}', '{complemento}', '{cep}', '{cidade}', '{estado}');";

                var resultado = comando.ExecuteNonQuery();
                if (resultado > 0)
                    MessageBox.Show("Registro inserido com sucesso!", "PDS - 2º Bimestre", MessageBoxButton.OK, MessageBoxImage.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }*/
        }
    }
}