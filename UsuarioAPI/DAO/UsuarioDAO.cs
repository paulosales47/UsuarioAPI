using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using UsuarioAPI.Models;

namespace UsuarioAPI.DAO
{
    public class UsuarioDAO : IDAO<UsuarioModel>
    {
        private string _stringConexao { get; set; }

        public UsuarioDAO()
        {
            _stringConexao = ConfigurationManager.ConnectionStrings["CONEXAO_API"].ToString();
        }

        public UsuarioDAO(string stringConexao)
        {
            _stringConexao = stringConexao;
        }

        public IList<UsuarioModel> Busca(UsuarioModel model)
        {
            SqlDataReader reader = null;

            using (SqlConnection connection = new SqlConnection(_stringConexao))
            {
                //CRIAÇÃO DO OBJETO QUE REALIZARÁ O COMANDO NO BANCO DE DADOS
                SqlCommand command = new SqlCommand("PR_S_USUARIO", connection);

                //setando o tipo de artefato que será chamado no banco de dados
                command.CommandType = System.Data.CommandType.StoredProcedure;

                //ADIÇÃO DOS PARÂMETROS DAS PROCEDURES
                if(model.IdUsuario != 0)
                    command.Parameters.Add(new SqlParameter("@ID_USUARIO", model.IdUsuario));

                command.Parameters.Add(new SqlParameter("@NOME", model.Nome));

                try
                {
                    //ABRE CONEXÃO COM BANCO DE DADOS
                    connection.Open();
                    //EXECUTA O COMANDO
                    reader = command.ExecuteReader();

                    return LeituraResposta(reader);
                }
                catch (Exception ex)
                {
                    throw ex;
                }
                finally
                {
                    //VERIFICA SE A CONEXÃO NÃO ESTÁ FECHADA
                    if (connection.State != System.Data.ConnectionState.Closed)
                    {
                        connection.Close();
                    }
                }
            }
        }

        private IList<UsuarioModel> LeituraResposta(SqlDataReader reader)
        {
            var listaUsuario = new List<UsuarioModel>();

            try
            {
                //VERIFICA SE O OBJETO RETORNADO DO BANCO DE DADOS POSSUI DADOS
                if (reader.HasRows)
                {
                    var usuario = new UsuarioModel();

                    //FAZ O LOOP PARA LER OS DADOS RETORNADOS
                    while (reader.Read())
                    {
                        usuario.IdUsuario = int.Parse(reader["ID_USUARIO"].ToString());
                        usuario.Nome = reader["NOME"].ToString();
                        usuario.DtNascimento = DateTime.Parse(reader["DT_NASCIMENTO"].ToString());
                        usuario.Ativo = bool.Parse(reader["ATIVO"].ToString());

                        listaUsuario.Add(usuario);
                    }
                }

                return listaUsuario;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public void Cadastro(UsuarioModel model)
        {
            using (SqlConnection connection = new SqlConnection(_stringConexao))
            {
                //CRIAÇÃO DO OBJETO QUE REALIZARÁ O COMANDO NO BANCO DE DADOS
                SqlCommand command = new SqlCommand("PR_I_USUARIO", connection);

                //setando o tipo de artefato que será chamado no banco de dados
                command.CommandType = System.Data.CommandType.StoredProcedure;

                //ADIÇÃO DOS PARÂMETROS DAS PROCEDURES
                command.Parameters.Add(new SqlParameter("@NOME", model.Nome));
                command.Parameters.Add(new SqlParameter("@DT_NASCIMENTO", model.DtNascimento));
                command.Parameters.Add(new SqlParameter("@ATIVO", model.Ativo));

                try
                {
                    //ABRE CONEXÃO COM BANCO DE DADOS
                    connection.Open();
                    //EXECUTA O COMANDO
                    command.ExecuteNonQuery();
                }
                catch (Exception ex)
                {
                    throw ex;
                }
                finally
                {
                    //VERIFICA SE A CONEXÃO NÃO ESTÁ FECHADA
                    if (connection.State != System.Data.ConnectionState.Closed)
                    {
                        connection.Close();
                    }
                }
            }
        }
    }
}