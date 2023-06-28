using _222020.Models;
using System;
using System.Windows.Forms;


namespace _222020.Views
{
    public partial class FrmCategoria : Form
    {
        Categoria c;
        public FrmCategoria()
        {
            InitializeComponent();
        }
        void limpaControles()
        {
            txtID.Clear();
            txtCategoria.Clear();
            txtPesquisa.Clear();
        }

        void carregarGrid(string pesquisa)
        {
            c = new Categoria()
            {
                categoria = pesquisa
            };
            dgvCategoria.DataSource = c.Consultar();
        }
        private void FrmCategoria_Load(object sender, EventArgs e)
        {
            limpaControles();
            carregarGrid("");
        }

        private void dgvCategoria_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            txtID.Text = dgvCategoria.CurrentRow.Cells["id"].Value.ToString();
            txtCategoria.Text = dgvCategoria.CurrentRow.Cells["categoria"].Value.ToString();
        }

        private void btnIncluir_Click(object sender, EventArgs e)
        {
            if (txtCategoria.Text == string.Empty) return;

            c = new Categoria()
            {
                categoria = txtCategoria.Text
            };
            c.Incluir();

            limpaControles();
            carregarGrid("");
        }

        private void btnAlterar_Click(object sender, EventArgs e)
        {
            if (txtID.Text == String.Empty) return;
            c = new Categoria()
            {
                id = int.Parse(txtID.Text),
                categoria = txtCategoria.Text
            };
            c.Alterar();
            limpaControles();
            carregarGrid("");
        }

        private void btnExcluir_Click(object sender, EventArgs e)
        {
            if (txtID.Text == "") return;
            if (MessageBox.Show("Deseja excluir a Categoria?", "Exclusão",
                MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                c = new Categoria()
                {
                    id = int.Parse(txtID.Text)
                };
                c.Excluir();
                limpaControles();
                carregarGrid("");
            }
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            limpaControles();
            carregarGrid("");
        }

        private void btnFechar_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void btnConsultar_Click(object sender, EventArgs e)
        {
            carregarGrid(txtPesquisa.Text);
        }
    }
}
