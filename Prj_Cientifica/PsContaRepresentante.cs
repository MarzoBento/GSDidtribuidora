using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Prj_Cientifica
{
   public class PsContaRepresentante
    {

        public void Incluir(VlContaRepresentante obj)
        {
            try
            {

                SqlConnection Cnn = Banco.CriarConexao();
                string inserir = ("Insert into ContaRepresentante values(@idrepresentante,@idbanco,@agencia,@conta,@favorecido)");
                SqlCommand sql = new SqlCommand(inserir, Cnn);
                sql.Parameters.AddWithValue("@idrepresentante", obj.idrepresentante);
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

        public void Alterar(VlContaRepresentante obj)
        {
            try
            {
                SqlConnection Cnn = Banco.CriarConexao();
                string alterar = "Update ContaRepresentante set idrepresentante=@idrepresentante,idbanco=@idbanco,agencia=@agencia,conta=@conta,favorecido=@favorecido Where idcontarep=@idcontarep";
                SqlCommand sql = new SqlCommand(alterar, Cnn);
                sql.Parameters.AddWithValue("@idcontarep", obj.idcontarep);
                sql.Parameters.AddWithValue("@idrepresentante", obj.idrepresentante);
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
                string delete = "Delete From ContaRepresentante Where idcontarep=" + cod + "";
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
