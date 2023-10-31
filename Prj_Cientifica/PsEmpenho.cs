using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Data.SqlTypes;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Prj_Cientifica
{
   public class PsEmpenho
    {


        public void Incluir(VlEmpenho obj)
        {
            try
            {

                SqlConnection Cnn = Banco.CriarConexao();
                string inserir = ("Insert into Empenho values(@edital,@idusu,@dtrecimento,@dtlimite,@nempenho,@obs,@idedital,@ata,@dtvigencia)");
                SqlCommand sql = new SqlCommand(inserir, Cnn);
                sql.Parameters.AddWithValue("@edital", obj.edital);
                sql.Parameters.AddWithValue("@idusu", obj.idusu);
                sql.Parameters.AddWithValue("@dtrecimento", SqlDbType.Date).Value = SqlDateTime.Null;
                sql.Parameters.AddWithValue("@dtlimite", SqlDbType.Date).Value = SqlDateTime.Null;
                sql.Parameters.AddWithValue("@nempenho", obj.nempenho);
                sql.Parameters.AddWithValue("@obs", obj.obs);
                sql.Parameters.AddWithValue("@idedital", obj.idedital);
                sql.Parameters.AddWithValue("@ata", obj.ata);
                sql.Parameters.AddWithValue("@dtvigencia", SqlDbType.Date).Value = SqlDateTime.Null;

                Cnn.Open();
                sql.ExecuteNonQuery();
                Cnn.Close();

            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }

        }

        public void Alterar(VlEmpenho obj)
        {
            try
            {
                SqlConnection Cnn = Banco.CriarConexao();
                string alterar = "Update Empenho set idusu=@idusu,dtrecimento=@dtrecimento,dtlimite=@dtlimite,nempenho=@nempenho,obs=@obs," +
                    "ata=@ata,dtvigencia=@dtvigencia Where idedital=@idedital AND idempenho=@idempenho";
                SqlCommand sql = new SqlCommand(alterar, Cnn);
                sql.Parameters.AddWithValue("@idedital", obj.idedital);
                sql.Parameters.AddWithValue("@idusu", obj.idusu);
                sql.Parameters.AddWithValue("@dtrecimento", SqlDbType.Date).Value = SqlDateTime.Null;
                sql.Parameters.AddWithValue("@dtlimite", SqlDbType.Date).Value = SqlDateTime.Null;
                sql.Parameters.AddWithValue("@nempenho", obj.nempenho);
                sql.Parameters.AddWithValue("@obs", obj.obs);
                sql.Parameters.AddWithValue("@ata", obj.ata);
                sql.Parameters.AddWithValue("@dtvigencia", SqlDbType.Date).Value = SqlDateTime.Null;
                Cnn.Open();
                sql.ExecuteNonQuery();
                Cnn.Close();

            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
        public void Exluir(int cod)
        {
            try
            {

                SqlConnection Cnn = Banco.CriarConexao();
                string delete = "Delete From Empenho Where idempenho=" + cod + "";
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

        public void ExluirEmpenhoItens(int cod)
        {
            try
            {

                SqlConnection Cnn = Banco.CriarConexao();
                string delete = "Delete From EmpenhoItems Where idempenho=" + cod + "";
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
