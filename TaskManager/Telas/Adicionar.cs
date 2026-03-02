using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using TaskManager.RN;

namespace TaskManager.Telas
{
    public partial class Adicionar : Form
    {
        private Principal principal;

        public Adicionar(Principal principalParam)
        {
            InitializeComponent();
            principal = principalParam;
        }
             
        // Evento do botão para adicionar uma tarefa
        private void buttonAdicionar_Click(object sender, EventArgs e)
        {
            // Verifica se o campo não está vazio
            if (textBoxTarefa.Text != "")
            {
                RNPrincipal.CriarTarefa(textBoxTarefa.Text);
                Close();
            }
            else
            {
                MessageBox.Show("Não é possivel criar uma tarefa vazia.");
                return;
            }
            
        }        
    }
}
