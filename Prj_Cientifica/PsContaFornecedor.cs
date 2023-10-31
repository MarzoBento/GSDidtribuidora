using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Prj_Cientifica
{
   public class PsContaFornecedor
    {

        public void Incluir(VlContaFornecedor obj)
        {
            try
            {

                SqlConnection Cnn = Banco.CriarConexao();
                string inserir = ("Insert into ContaFornecedor values(@idfornecedor,@idbanco,@agencia,@conta,@favorecido)");
                SqlCommand sql = new SqlCommand(inserir, Cnn);
                sql.Parameters.AddWithValue("@idfornecedor", obj.idfornecedor);
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

        public void Alterar(VlContaFornecedor obj)
        {
            try
            {
                SqlConnection Cnn = Banco.CriarConexao();
                string alterar = "Update ContaFornecedor set idfornecedor=@idfornecedor,idbanco=@idbanco,agencia=@agencia,conta=@conta,favorecido=@favorecido Where idcontafor=@idcontafor";
                SqlCommand sql = new SqlCommand(alterar, Cnn);
                sql.Parameters.AddWithValue("@idcontafor", obj.idcontafor);
                sql.Parameters.AddWithValue("@idfornecedor", obj.idfornecedor);
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
                string delete = "Delete From ContaFornecedor Where idcontafor=" + cod + "";
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
