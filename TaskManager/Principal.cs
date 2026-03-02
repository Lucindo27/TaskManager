using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using TaskManager.DAO;
using TaskManager.Model;
using TaskManager.RN;
using TaskManager.Telas;

namespace TaskManager
{
    public partial class Principal : Form
    {
        public Principal()
        {
            InitializeComponent();
        }

        private void Principal_Load(object sender, EventArgs e)
        {
            PreencheLista();
        }

        // Evento do botão para adicionar tarefa 
        private void buttonAdd_Click(object sender, EventArgs e)
        {
            ChamarTelaAdicionar();
        }

        // Evento do botão para remover tarefa da lista
        private void buttonRemover_Click(object sender, EventArgs e)
        {
            RemoverItemLista();
        }

        // Evento do botão de editar tarefa
        private void buttonEditar_Click(object sender, EventArgs e)
        {
            ChamarTelaEditar();
        }

        // Chama tela de adicionar tarefa
        public void ChamarTelaAdicionar()
        {
            Adicionar adicionar = new Adicionar(this);
            adicionar.ShowDialog();

            PreencheLista();
        }

        // Remove tarefa da lista
        public void RemoverItemLista()
        {
            // Verifica se alguma tarefa foi selecionada
            if ((Tarefa)checkedListBox.SelectedItem != null)
            {
                // Obtem os dados da tarefa selecionada 
                Tarefa tarefa = (Tarefa)checkedListBox.SelectedItem;

                // Remove a tarefa selecionada
                RNPrincipal.RemoverTarefa(tarefa.Id);

                // Chama o método para atualizar a lista 
                PreencheLista();
            }
            else
            {
                MessageBox.Show("Selecione alguma tarefa para remoção.");
            }
            
        }

        // Chama a tela editar
        public void ChamarTelaEditar()
        {
            // Verifica se alguma tarefa foi selecionada
            if (checkedListBox.SelectedItem != null)
            {
                // Abre a tela editar com a tarefa selecionada
                Editar editar = new Editar(this, (Tarefa)checkedListBox.SelectedItem);
                editar.ShowDialog();

                // Chama o método para preencher a lista com a tarefa atualizada
                PreencheLista();
            }
            else
            {
                MessageBox.Show("Selecione alguma tarefa para edição.");
            }
        }

        // Preenche a lista com os dados atualizados
        public void PreencheLista()
        {
            List<Tarefa> listaTarefas = null;

            // Limpa a lista
            checkedListBox.Items.Clear();

            // Lista recebe tarefas do banco
            listaTarefas = RNPrincipal.CarregaLista();

            // Verifica se há alguma tarefa registrada 
            if (listaTarefas.Count != 0)
            {
                // As tarefas são listadas na tela
                foreach (Tarefa item in listaTarefas)
                {
                    checkedListBox.Items.Add(item);
                }
            }
        }
    }
}
