using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TaskManager.DAO;
using TaskManager.Model;

namespace TaskManager.RN
{
    internal class RNPrincipal
    {
        public static void CriarTarefa(string sTarefa)
        {
            SqlConnection conn = null;
            DAPrincipal daPrincipal = null;

            try
            {
                conn = Conexao.GetConnection();
                daPrincipal = new DAPrincipal();

                daPrincipal.CriarTarefa(sTarefa);
            }
            finally
            {
                conn.Close();
            }
        }

        public static List<Tarefa> CarregaLista()
        {
            SqlConnection conn = null;
            DAPrincipal daPrincipal = null;
            List<Tarefa> listaTarefas = new List<Tarefa>();

            try
            {
                conn = Conexao.GetConnection();
                daPrincipal = new DAPrincipal();

                listaTarefas = daPrincipal.CarregaLista();
            }
            finally
            {
                conn.Close();
            }

            return listaTarefas;
        }

        public static void RemoverTarefa(int iIdTarefa)
        {
            SqlConnection conn = null;
            DAPrincipal daPrincipal = null;

            try
            {
                conn = Conexao.GetConnection();
                daPrincipal = new DAPrincipal();

                daPrincipal.RemoverTarefa(iIdTarefa);
            }
            finally
            {
                conn.Close();
            }
        }

        public static void EditarTarefa(int iIdTarefa, string sNovoNomeTarefa)
        {
            SqlConnection conn = null;
            DAPrincipal daPrincipal = null;

            try
            {
                conn = Conexao.GetConnection();
                daPrincipal = new DAPrincipal();

                daPrincipal.EditarTarefa(iIdTarefa, sNovoNomeTarefa);
            }
            finally
            {
                conn.Close();
            }
        }
    }
}
