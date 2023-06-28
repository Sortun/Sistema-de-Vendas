using System;
using System.Data;
using System.Runtime.InteropServices;
using System.Security.Cryptography.X509Certificates;
using System.Windows.Forms;
using MySql.Data.MySqlClient;

namespace _222020
{
    public class Banco
    {
        //Criando as variaveis publicas para a conexão e consulta serão usadas em todo o projeto
        //conection responsavel pela conexão com MySql
        public static MySqlConnection Conexao;

        //Command responsavel pelas instruções SQL a serem executadas
        public static MySqlCommand Comando;

        //Adapter responsavel por inserir dados em um dataTable
        public static MySqlDataAdapter Adaptador;

        //DataTable responsavel por ligar o banco de dados em controles com a prioridade DataSource
        public static DataTable datTabela;


        public static void AbrirConexao()
        {
            try
            {
                //Estabelece os parametros para a conexão com o banco
                Conexao = new MySqlConnection("server=localhost;port=3306;uid=root;pwd=etecjau");

                //Abre a conexão com o banco de dados
                Conexao.Open();
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        public static void FecharConexao()
        {
            try
            { 
                //Fechar conexão com o banco de dados
                Conexao.Close();
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        public static void CriarBanco()
        {
            try
            {
                //chama a função para abertura de conexão com o banco
                AbrirConexao();

                //Informa a instrução SQL
                Comando = new MySqlCommand("CREATE DATABASE IF NOT EXISTS vendas; USE vendas", Conexao);

                //Executa a Querry no MYSQL (Raio do Workbench)
                Comando.ExecuteNonQuery();

                Comando = new MySqlCommand("CREATE TABLE IF NOT EXISTS Cidades " +
                                         "(id integer auto_increment primary key, " +
                                         "nome char(40), " +
                                         "uf char(02))", Conexao);
                Comando.ExecuteNonQuery();

                Comando = new MySqlCommand("CREATE TABLE IF NOT EXISTS Marcas " +
                    "(id integer auto_increment primary key, " +
                    "marca char(20))", Conexao);
                Comando.ExecuteNonQuery();

                Comando = new MySqlCommand("CREATE TABLE IF NOT EXISTS Categorias " +
                    "(id integer auto_increment primary key, " +
                    "categoria char(20))", Conexao);
                Comando.ExecuteNonQuery();

                Comando = new MySqlCommand("CREATE TABLE IF NOT EXISTS Clientes " +
                    "(id integer auto_increment primary key, " +
                    "nome char (40), " +
                    "idCidade integer," +
                    "dataNasc date," +
                    "renda decimal (10,2), " +
                    "cpf char(14), " +
                    "foto varchar(100)," +
                    "venda boolean)", Conexao);
                Comando.ExecuteNonQuery();

                Comando = new MySqlCommand("CREATE TABLE IF NOT EXISTS Produtos " +
                    "(id integer auto_increment primary key," +
                    "descricao char(40)," +
                    "idCategoria integer," +
                    "idMarca integer," +
                    "estoque decimal(10,3), " +
                    "valorVenda decimal(10,2)," +
                    "foto varchar(100))", Conexao);
                Comando.ExecuteNonQuery();

                Comando = new MySqlCommand("CREATE TABLE IF NOT EXISTS VendaCab " +
                    "(id integer auto_increment primary key, " +
                    "idCliente int, " +
                    "data date, " +
                    "total decimal(10,2))", Conexao);
                Comando.ExecuteNonQuery();

                Comando = new MySqlCommand("CREATE TABLE IF NOT EXISTS VendaDet " +
                    "(id integer auto_increment primary key, " +
                    "idVendaCab int, " +
                    "idProduto int, " +
                    "qtde decimal(10,3)," +
                    "valorUnitario decimal(10,2))", Conexao); 
                Comando.ExecuteNonQuery();

             //Chama a Função de fechar a conxão com o banco
             FecharConexao();
            }

            

            catch(Exception e)
            {
                MessageBox.Show(e.Message, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    } 
}

