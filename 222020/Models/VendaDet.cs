using MySql.Data.MySqlClient;
using System;
using System.Windows.Forms;

namespace _222020.Models
{
    public class VendaDet
    {
        public int ID { get; set; }
        public int idVendaCab { get; set; }
        public int idProduto { get; set; }
        public double qtde { get; set; }
        public double valorUnitario { get; set; }

        public void incluir()
        {
            try
            {
                Banco.Conexao.Open();
                Banco.Comando = new MySqlCommand(
                    "INSERT INTO vendaDet (idVendaCab, idProduto, qtde, valorUnitario) " +
                    "VALUES (@idVendaCab, @idProduto, @qtde, @valorUnitario)", Banco.Conexao);
                Banco.Comando.Parameters.AddWithValue("@idVendaCab", idVendaCab);
                Banco.Comando.Parameters.AddWithValue("@idProduto", idProduto);
                Banco.Comando.Parameters.AddWithValue("@qtde", qtde);
                Banco.Comando.Parameters.AddWithValue("@valorUnitario", valorUnitario);
                Banco.Comando.ExecuteNonQuery();
                Banco.Conexao.Close();
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
