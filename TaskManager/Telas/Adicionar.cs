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
    public partial class Adicionar : Form
    {
        private Principal principal;

        public Adicionar(Principal principalParam)
        {
            InitializeComponent();
            principal = principalParam;
        }
                
        private void buttonAdicionar_Click(object sender, EventArgs e)
        {
            AdcionarItem();
        }

        public void AdcionarItem()
        {
            if (textBoxTarefa.Text != "")
            {
                principal.AdicionarItemLista(textBoxTarefa.Text);

                Close();
            }
            else
            {
                MessageBox.Show("Não é possível criar uma tarefa vazia.");
            }
        }
    }
}
