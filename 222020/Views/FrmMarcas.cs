using System;
using System.Windows.Forms;
using _222020.Models;

namespace _222020.Views
{
    public partial class FrmMarcas : Form
    {
        Marca c; 
        public FrmMarcas()
        {
            InitializeComponent();
        }
        void limpaControles()
        {
            txtID.Clear();
            txtMarca.Clear();
            txtPesquisa.Clear();
        }

        void carregarGrid(string pesquisa)
        {
            c = new Marca()
            {
                marca = pesquisa
            };
            dgvMarca.DataSource = c.Consultar();
        }

        private void FrmMarcas_Load(object sender, EventArgs e)
        {
            limpaControles();
            carregarGrid("");
        }

        private void btnIncluir_Click(object sender, EventArgs e)
        {
            if (txtMarca.Text == string.Empty) return;

            c = new Marca()
            {
                marca = txtMarca.Text
            };
            c.Incluir();

            limpaControles();
            carregarGrid("");
        }

        private void dgvMarca_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            txtID.Text = dgvMarca.CurrentRow.Cells["id"].Value.ToString();
            txtMarca.Text = dgvMarca.CurrentRow.Cells["marca"].Value.ToString();
        }
        private void btnAlterar_Click(object sender, EventArgs e)
        {
            if (txtID.Text == String.Empty) return;
            c = new Marca()
            {
                id = int.Parse(txtID.Text),
                marca = txtMarca.Text
            };
            c.Alterar();
            limpaControles();
            carregarGrid("");
        }

        private void btnExcluir_Click(object sender, EventArgs e)
        {
            if (txtID.Text == "") return;
            if (MessageBox.Show("Deseja excluir a Marca?", "Exclusão",
                MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                c = new Marca()
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
