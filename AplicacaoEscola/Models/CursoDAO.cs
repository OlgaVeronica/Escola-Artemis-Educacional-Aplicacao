﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AplicacaoEscola.Helpers;
using AplicacaoEscola.Database;
using MySql.Data.MySqlClient;

namespace AplicacaoEscola.Models
{
    internal class CursoDAO
    {
        private static Conexao _conn = new Conexao();

        public void Insert(Curso curso)
        {
            try
            {
                var comando = _conn.Query();
                comando.CommandText = $"insert into Curso values(null, @nomeCurso, @cargaHoraria, @descricao, @turno, @escola_id);";

                comando.Parameters.AddWithValue("@nomeCurso", curso.NomeCurso);
                comando.Parameters.AddWithValue("@cargaHoraria", curso.CargaHoraria);
                comando.Parameters.AddWithValue("@descricao", curso.Descricao);
                comando.Parameters.AddWithValue("@turno", curso.Turno);
                comando.Parameters.AddWithValue("@escola_id", curso.Escola.Id);
                var resultado = comando.ExecuteNonQuery();
                if (resultado == 0)
                {
                    throw new Exception("Ocorreram erros ao salvar as informações");
                }
            }
            catch (Exception)
            {
                throw;
            }
        }

        public void Update(Curso curso)
        {
            try
            {
                var comando = _conn.Query();
                comando.CommandText = $"update Curso set nome_curso_cur = @nomeCurso, carga_horaria_cur = @cargaHoraria, descricao_cur = @descricao, turno_cur = @turno where id_cur = @id;";

                comando.Parameters.AddWithValue("@nomeCurso", curso.NomeCurso);
                comando.Parameters.AddWithValue("@cargaHoraria", curso.CargaHoraria);
                comando.Parameters.AddWithValue("@descricao", curso.Descricao);
                comando.Parameters.AddWithValue("@turno", curso.Turno);
                comando.Parameters.AddWithValue("@id", curso.Id);

                var resultado = comando.ExecuteNonQuery();
                if (resultado == 0)
                {
                    throw new Exception("Ocorreram erros ao salvar as informações");
                }
            }
            catch (Exception)
            {
                throw;
            }
        }

        public void Delete(Curso curso)
        {
            try
            {
                Conexao conn = new Conexao();
                var comando = conn.Query();

                comando.CommandText = "delete from curso where id_cur = @id";

                comando.Parameters.AddWithValue("@id", curso.Id);
                var resultado = comando.ExecuteNonQuery();

                if (resultado == 0)
                {
                    throw new Exception("Erro ao Apagar os dados do Banco de dados");
                }
            }
            catch (Exception)
            {
                throw;
            }
        }
        public List<Curso> List()
        {
            try
            {
                var lista = new List<Curso>();
                var comando = _conn.Query();

                comando.CommandText = "select curso.*, escola.nome_fantasia_esc from curso, escola where(curso.id_esc_fk = escola.id_esc)";

                MySqlDataReader reader = comando.ExecuteReader();

                while (reader.Read())
                {
                    var curso = new Curso();

                    curso.Id = reader.GetInt32("id_cur");
                    curso.NomeCurso = DAOHelper.GetString(reader, "nome_curso_cur");
                    curso.CargaHoraria = DAOHelper.GetString(reader, "carga_horaria_cur");
                    curso.Descricao = DAOHelper.GetString(reader, "descricao_cur");
                    curso.Turno = DAOHelper.GetString(reader, "turno_cur");
                    curso.Escola = new Escola();
                    curso.Escola.Id = DAOHelper.GetInt(reader,"id_esc_fk");
                    curso.Escola.NomeFantasia = DAOHelper.GetString(reader, "nome_fantasia_esc");
                    lista.Add(curso);
                }
                reader.Close();
                return lista;
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}
