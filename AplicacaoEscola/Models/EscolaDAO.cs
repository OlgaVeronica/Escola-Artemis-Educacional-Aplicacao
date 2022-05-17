using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AplicacaoEscola.Database;

namespace AplicacaoEscola.Models
{
    internal class EscolaDAO
    {
        private static Conexao _conn = new Conexao();

        public void Insert(Escola escola)
        {
            try
            {
                
                var comando = _conn.Query();
                comando.CommandText = $"insert into Escola values(null, '{escola.NomeFantasia}', '{escola.RazaoSocial}' , '{escola.Cnpj}', '{escola.InscricaoEst}', '{escola.Tipo}', '{escola.DataCriacao}', " +
                    $"'{escola.NomeResp}', '{escola.TelefoneResp}', '{escola.Email}', '{escola.TelefoneEscola}', '{escola.Rua}', {escola.Numero}, '{escola.Bairro}', '{escola.Complemento}', '{escola.Cep}', '{escola.Cidade}', '{escola.Estado}');";

                var resultado = comando.ExecuteNonQuery();
                //if (resultado > 0)
                    //MessageBox.Show("Registro inserido com sucesso!", "PDS - 2º Bimestre", MessageBoxButton.OK, MessageBoxImage.Information);
            }
            catch (Exception ex)
            {
                //MessageBox.Show(ex.Message);
            }
        }
    }
}
