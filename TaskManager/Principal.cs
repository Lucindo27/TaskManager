using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using TaskManager.Telas;

namespace TaskManager
{
    public partial class Principal : Form
    {
        public Principal()
        {
            InitializeComponent();
        }

        private void buttonAdd_Click(object sender, EventArgs e)
        {
            ChamarTelaAdicionar();
        }

        private void buttonRemover_Click(object sender, EventArgs e)
        {
            RemoverItemLista();
        }

        private void buttonEditar_Click(object sender, EventArgs e)
        {
            ChamarTelaEditar();
        }

        public void ChamarTelaAdicionar()
        {
            Adicionar adicionar = new Adicionar(this);
            adicionar.ShowDialog();
        }

        public void RemoverItemLista()
        {
            checkedListBox.Items.Remove(checkedListBox.SelectedItem);
        }

        public void AdicionarItemLista(string sTarefa)
        {
            checkedListBox.Items.Add(sTarefa);
        }

        public void ChamarTelaEditar()
        {
            if (checkedListBox.SelectedItem != null)
            {
                Editar editar = new Editar(this, checkedListBox.SelectedItem.ToString());
                editar.ShowDialog();
            }
            else
            {
                MessageBox.Show("Selecione algum item para edição.");
            }
        }
    }
}
