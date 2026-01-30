using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TaskManager.Telas
{
    public partial class Editar : Form
    {
        private Principal principal;
        private string sTarefa;

        public Editar(Principal principalParam, string sTarefaParam)
        {
            InitializeComponent();

            // Variaveis da classe recebendo valor do construtor
            principal = principalParam;
            sTarefa = sTarefaParam;

            // Exibindo valor no campo de texto
            textBoxTarefaEditada.Text = sTarefa;
        }

        private void buttonEditar_Click(object sender, EventArgs e)
        {
            EditarItem();
        }

        public void EditarItem()
        {
            principal.RemoverItemLista();

            if (textBoxTarefaEditada.Text != "")
            {
                principal.AdicionarItemLista(textBoxTarefaEditada.Text);
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
