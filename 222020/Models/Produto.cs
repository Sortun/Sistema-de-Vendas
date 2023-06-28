using MySql.Data.MySqlClient;
using System;
using System.Data;
using System.Windows.Forms;

namespace _222020.Models
{
    public class Produto
    {
        public int ID { get; set; }
        public string descricao { get; set; }
        public int idCategoria { get; set; }
        public int idMarca { get; set; }
        public string foto { get; set; }
        public double valorVenda { get; set; }
        public double estoque { get; set; }

        public DataTable Consultar()
        {
            try
            {
                Banco.Comando = new MySqlCommand("SELECT p.*, m.marca, c.categoria FROM " +
                    "Produtos p inner join Marcas m on (m.id = p.idMarca) " +
                    "inner join Categorias  c on (c.id = p.idCategoria) " +
                    "where p.descricao like @descricao " +
                    "order by p.descricao", Banco.Conexao);
                Banco.Comando.Parameters.AddWithValue("@descricao", descricao + "%");
                Banco.Adaptador = new MySqlDataAdapter(Banco.Comando);
                Banco.datTabela = new DataTable();
                Banco.Adaptador.Fill(Banco.datTabela);
                return Banco.datTabela;

            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return null;
            }
        }
        public void Incluir()
        {
            try
            {
                Banco.AbrirConexao();
                Banco.Comando = new MySqlCommand(
                    "INSERT INTO Produtos (descricao, idCategoria, idMarca, valorVenda, estoque, foto)" +
                    "VAlUES (@descricao, @idCategoria, @idMarca, @valorVenda, @estoque, @foto)", Banco.Conexao);
                Banco.Comando.Parameters.AddWithValue("@descricao", descricao);
                Banco.Comando.Parameters.AddWithValue("@idCategoria", idCategoria);
                Banco.Comando.Parameters.AddWithValue("@idMarca", idMarca);
                Banco.Comando.Parameters.AddWithValue("@valorVenda", valorVenda);
                Banco.Comando.Parameters.AddWithValue("@estoque", estoque);
                Banco.Comando.Parameters.AddWithValue("@foto", foto);
                Banco.Comando.ExecuteNonQuery();
                Banco.FecharConexao();
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        public void Alterar()
        {
            try
            {
                Banco.AbrirConexao();
                Banco.Comando = new MySqlCommand(
                    "UPDATE Produtos set descricao =@descricao, idCategoria =@idCategoria, idMarca =@idMarca, " +
                    "valorVenda =@valorVenda, estoque =@estoque, foto =@foto where id =@id", Banco.Conexao);
                Banco.Comando.Parameters.AddWithValue("@id", ID);
                Banco.Comando.Parameters.AddWithValue("@descricao", descricao);
                Banco.Comando.Parameters.AddWithValue("@idCategoria", idCategoria);
                Banco.Comando.Parameters.AddWithValue("@idMarca", idMarca);
                Banco.Comando.Parameters.AddWithValue("@valorVenda", valorVenda);
                Banco.Comando.Parameters.AddWithValue("@estoque", estoque);
                Banco.Comando.Parameters.AddWithValue("@foto", foto);
                Banco.Comando.ExecuteNonQuery() ;
                Banco.FecharConexao();
            }
            catch(Exception e)
            {
                MessageBox.Show(e.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        public void Excluir()
        {
            try
            {
                Banco.AbrirConexao();
                Banco.Comando = new MySqlCommand("Delete from Produtos where id =@id", Banco.Conexao);
                Banco.Comando.Parameters.AddWithValue("@id", ID);
                Banco.Comando.ExecuteNonQuery();
                Banco.FecharConexao();
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }

        public void atualizaEstoque(double qtde)
        {
            try
            { 
            Banco.AbrirConexao();
            Banco.Comando = new MySqlCommand(
                "Update produtos set estoque = estoque - @qtde where id = @id", Banco.Conexao);
            Banco.Comando.Parameters.AddWithValue("@qtde", qtde);
            Banco.Comando.Parameters.AddWithValue("@id", ID);
            Banco.Comando.ExecuteNonQuery();
            Banco.FecharConexao();
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
