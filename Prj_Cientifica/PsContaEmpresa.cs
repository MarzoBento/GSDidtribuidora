using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Prj_Cientifica
{
   public class PsContaEmpresa
    {

        public void Incluir(VlContaEmpresa obj)
        {
            try
            {

                SqlConnection Cnn = Banco.CriarConexao();
                string inserir = ("Insert into ContaEmpresa values(@idempresa,@idbanco,@agencia,@conta,@favorecido)");
                SqlCommand sql = new SqlCommand(inserir, Cnn);
                sql.Parameters.AddWithValue("@idempresa", obj.idempresa);
                sql.Parameters.AddWithValue("@idbanco", obj.idbanco);
                sql.Parameters.AddWithValue("@agencia", obj.agencia);
                sql.Parameters.AddWithValue("@conta", obj.conta);
                sql.Parameters.AddWithValue("@favorecido", obj.favorecido);
                Cnn.Open();
                sql.ExecuteNonQuery();
                Cnn.Close();

            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }

        }

        public void Alterar(VlContaEmpresa obj)
        {
            try
            {
                SqlConnection Cnn = Banco.CriarConexao();
                string alterar = "Update ContaEmpresa set idempresa=@idempresa,idbanco=@idbanco,agencia=@agencia,conta=@conta,favorecido=@favorecido Where idconta=@idconta";
                SqlCommand sql = new SqlCommand(alterar, Cnn);
                sql.Parameters.AddWithValue("@idconta", obj.idconta);
                sql.Parameters.AddWithValue("@idempresa", obj.idempresa);
                sql.Parameters.AddWithValue("@idbanco", obj.idbanco);
                sql.Parameters.AddWithValue("@agencia", obj.agencia);
                sql.Parameters.AddWithValue("@conta", obj.conta);
                sql.Parameters.AddWithValue("@favorecido", obj.favorecido);
                Cnn.Open();
                sql.ExecuteNonQuery();
                Cnn.Close();

            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
        public void Exluir(Int32 cod)
        {
            try
            {

                SqlConnection Cnn = Banco.CriarConexao();
                string delete = "Delete From ContaEmpresa Where idconta=" + cod + "";
                SqlCommand sql = new SqlCommand(delete, Cnn);
                Cnn.Open();
                sql.ExecuteNonQuery();
                Cnn.Close();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }


    }
}
