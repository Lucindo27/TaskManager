using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using TaskManager.Model;
using TaskManager.RN;

namespace TaskManager.Telas
{
    public partial class Editar : Form
    {
        private Principal principal;
        private Tarefa tarefa;

        public Editar(Principal principalParam, Tarefa tarefaParam)
        {
            InitializeComponent();

            // Variaveis da classe recebendo valor do construtor
            principal = principalParam;
            tarefa = tarefaParam;

            // Exibindo valor no campo de texto
            textBoxTarefaEditada.Text = tarefa.Nome;
        }

        // Evento do botão para editar a tarefa
        private void buttonEditar_Click(object sender, EventArgs e)
        {
            EditarItem();
        }

        // Método para editar tarefa
        public void EditarItem()
        {
            // Verifica se o campo não está vazio
            if (textBoxTarefaEditada.Text != "")
            {
                RNPrincipal.EditarTarefa(tarefa.Id, textBoxTarefaEditada.Text);
            }
            else
            {
                MessageBox.Show("Não é possivel deixar uma tarefa vazia.");
                return;
            }

            Close();
        }
    }
}
