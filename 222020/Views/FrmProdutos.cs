using System;
using System.Data;
using System.Windows.Forms;
using _222020.Models;
using System.Collections.Generic;
using MySql.Data.MySqlClient;
using System.Linq;


namespace _222020.Views
{
    public partial class FrmProdutos : Form
    {
        Produto p;
        Categoria c;
        Marca m;
        public FrmProdutos()
        {
            InitializeComponent();
        }

        void limpaControles()
        {
            txtID.Clear();
            txtVenda.Clear();
            txtPesquisa.Clear();
            txtEstoque.Clear();
            txtDescricao.Clear();
            picFoto.ImageLocation = "";
            cboCategorias.SelectedIndex = -1;
            cboMarcas.SelectedIndex = -1;
        }

        void carregaGrid(string pesquisa)
        {
            p = new Produto()
            {
                descricao = pesquisa
            };
            dgvProdutos.DataSource = p.Consultar();
        }
        private void FrmProdutos_Load(object sender, EventArgs e)
        {
            c = new Categoria();
            cboCategorias.DataSource = c.Consultar();
            cboCategorias.DisplayMember = "categoria";
            cboCategorias.ValueMember = "id";

            m = new Marca();
            cboMarcas.DataSource = m.Consultar();
            cboMarcas.DisplayMember = "marca";
            cboMarcas.ValueMember = "id";

            limpaControles();
            carregaGrid("");

            dgvProdutos.Columns["idCategoria"].Visible = false;
            dgvProdutos.Columns["idMarca"].Visible = false;
            dgvProdutos.Columns["foto"].Visible = false;
        }
        private void picFoto_Click(object sender, EventArgs e)
        {
            ofdArquivo.InitialDirectory = "D:/fotos/clientes/"; //MUDAR CAMINHO QUANDO FOR PARA PC
            ofdArquivo.FileName = "";
            ofdArquivo.ShowDialog();
            picFoto.ImageLocation = ofdArquivo.FileName;
        }

        private void btnIncluir_Click(object sender, EventArgs e)
        {
            if (txtDescricao.Text == "") return;
            p = new Produto()
            {
                descricao = txtDescricao.Text,
                idCategoria = (int)cboCategorias.SelectedValue,
                idMarca = (int)cboMarcas.SelectedValue,
                foto = picFoto.ImageLocation,
                estoque = double.Parse(txtEstoque.Text),
                valorVenda = double.Parse(txtVenda.Text)

            };
            p.Incluir();
            limpaControles();
            carregaGrid("");
        }

        private void dgvProdutos_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (dgvProdutos.Rows.Count > 0)
            {
                txtID.Text = dgvProdutos.CurrentRow.Cells["id"].Value.ToString();
                txtDescricao.Text = dgvProdutos.CurrentRow.Cells["descricao"].Value.ToString();
                cboCategorias.Text = dgvProdutos.CurrentRow.Cells["categoria"].Value.ToString();
                cboMarcas.Text = dgvProdutos.CurrentRow.Cells["marca"].Value.ToString();
                txtVenda.Text = dgvProdutos.CurrentRow.Cells["valorVenda"].Value.ToString();
                txtEstoque.Text = dgvProdutos.CurrentRow.Cells["estoque"].Value.ToString();
                picFoto.ImageLocation = dgvProdutos.CurrentRow.Cells["foto"].Value.ToString();
            }
        }

        private void btnAlterar_Click(object sender, EventArgs e)
        {
            if (txtID.Text == String.Empty) return;
            {
                p = new Produto()
                {
                    ID = int.Parse(txtID.Text),
                    descricao = txtDescricao.Text,
                    idCategoria = (int)cboCategorias.SelectedValue,
                    idMarca = (int)cboMarcas.SelectedValue,
                    valorVenda = double.Parse(txtVenda.Text),
                    estoque = double.Parse(txtEstoque.Text),
                    foto = picFoto.ImageLocation

                };
                p.Alterar();
                limpaControles();
                carregaGrid("");
            }
        }
        private void btnExcluir_Click(object sender, EventArgs e)
        {
            if (txtID.Text == "") return;
            if(MessageBox.Show("Deseja excluir a Produto?", "Exclusão",
                MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                p = new Produto()
                {
                    ID = int.Parse(txtID.Text)
                };
                p.Excluir();
                limpaControles();
                carregaGrid("");
            }
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            limpaControles();
            carregaGrid("");
        }

        private void btnFechar_Click(object sender, EventArgs e)
        {
            Close();
        }
        private void btnConsultar_Click(object sender, EventArgs e)
        {
            carregaGrid(txtPesquisa.Text);
        }
    }
}