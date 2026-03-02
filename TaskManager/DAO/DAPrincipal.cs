using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TaskManager.Model;

namespace TaskManager.DAO
{
    internal class DAPrincipal
    {
        public void CriarTarefa(string sTarefa)
        {
            using (SqlConnection conn = Conexao.GetConnection())
            {
                SqlCommand query = new SqlCommand();

                query.CommandText = ("INSERT INTO Tarefas (Ds_Tarefa) VALUES (@tarefa)");

                query.Connection = conn;

                query.Parameters.AddWithValue("@tarefa", sTarefa);

                query.ExecuteNonQuery();
            }
        }

        public List<Tarefa> CarregaLista()
        {
            List<Tarefa> listaTarefas = new List<Tarefa>();

            using (SqlConnection conn = Conexao.GetConnection())
            {
                SqlCommand query = new SqlCommand();

                query.CommandText = ("SELECT * FROM Tarefas");

                query.Connection = conn;

                using (SqlDataReader reader = query.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        Tarefa tarefa = new Tarefa();

                        tarefa.Id = Convert.ToInt32(reader["Id"]);
                        tarefa.Nome = reader["Ds_Tarefa"].ToString();

                        listaTarefas.Add(tarefa);
                    }
                }

                query.Connection = conn;

                query.ExecuteReader();
            }

            return listaTarefas;
        }

        public void RemoverTarefa(int iIdTarefa)
        {
            using (SqlConnection conn = Conexao.GetConnection())
            {
                SqlCommand query = new SqlCommand();

                query.CommandText = ("DELETE Tarefas WHERE Id = @idtarefa");

                query.Connection = conn;

                query.Parameters.AddWithValue("@idtarefa", iIdTarefa);

                query.ExecuteNonQuery();
            }
        }

        public void EditarTarefa(int iIdTarefa, string sNovoNomeTarefa)
        {
            using (SqlConnection conn = Conexao.GetConnection())
            {
                SqlCommand query = new SqlCommand();

                query.CommandText = ("UPDATE Tarefas SET Ds_Tarefa = @nometarefa WHERE ID = @idtarefa");

                query.Connection = conn;

                query.Parameters.AddWithValue("@idtarefa", iIdTarefa);
                query.Parameters.AddWithValue("@nometarefa", sNovoNomeTarefa);

                query.ExecuteNonQuery();
            }
        }
    }
}
