using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Prj_Cientifica
{
    public class Banco
    {



        public static string Nomeusu;
        public static Int32 idusu;
        public static string tipousuario;
        public static string nomeempresa;
        public static int idemp;
        public static string menu;
        public static string submenu;
        public static bool status;
        public static string login;
        public static string senha;


         public static string computerName = "Desenvolvimento";
        //public static string computerName = "Marzo";
        //public static string computerName = "servidor";
        // public static string computerName = "mssql03.redehost.com.br,5003";
        private string Cnx = @"Data Source=" + computerName + ";Initial Catalog=Dainers; Integrated Security=false;User ID=sa;Password=Bento@#72; pooling=false";
        public DataSet RetornaDataSet(string Sql)
        {
            computerName = SystemInformation.ComputerName;
            SqlConnection conn = new SqlConnection(Cnx);
            SqlDataAdapter adp = new SqlDataAdapter(Sql, Cnx);
            DataSet ds = new DataSet();
            adp.Fill(ds);
            conn.Close();
            return ds;
        }
        public static SqlConnection CriarConexao()
        {

            computerName = "Desenvolvimento";
            //computerName = "developer03";
            // computerName = "ADM";
            //computerName = "mssql03.redehost.com.br,5003";
            // computerName = "srv-licitacao";

            SqlConnection Cnx = null;
            try
            {

                Cnx = new SqlConnection(@"Data Source=" + computerName + ";Initial Catalog=GSDistribuidora; Integrated Security=false;User ID=sa;Password=bento@72; pooling=false");
               // Cnx = new SqlConnection(@"Data Source=" + computerName + ";Initial Catalog=GSDistribuidora; Integrated Security=false;User ID=sa;Password=Bento@#72; pooling=false");
            }
            catch (Exception ex)
            {
                MessageBox.Show("Não foi Possível Conectar no Banco de dados Verifique a Iternet!");
            }
            return Cnx;
        }
        public static SqlConnection CriarConexao2()
        {
            // computerName = "master";
            // computerName = "RECEPCAO";
            // computerName = "Marzo";
            //computerName = "servidor";
            // computerName = "mssql03.redehost.com.br,5003";

            SqlConnection Cnx = null;
            try
            {

                Cnx = new SqlConnection(@"Data Source=" + computerName + ";Initial Catalog=Dainers; Integrated Security=false;User ID=sa;Password=Bento@#72; pooling=false");

            }
            catch (Exception ex)
            {
                MessageBox.Show("Não foi Possível Conectar no Banco de dados Verifique a Iternet!");
            }
            return Cnx;
        }



    }
}
