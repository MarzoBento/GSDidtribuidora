using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Prj_Cientifica
{
   public class PsTipoDocumento
    {

        public void Incluir(VlTipoDocumento obj)
        {
            try
            {

                SqlConnection Cnn = Banco.CriarConexao();
                string inserir = ("Insert into TipoDocumento values(@nome,@obs,@idusu)");
                SqlCommand sql = new SqlCommand(inserir, Cnn);
                sql.Parameters.AddWithValue("@nome", obj.nome);
                sql.Parameters.AddWithValue("@obs", obj.obs);
                sql.Parameters.AddWithValue("@idusu", obj.idusu);

                Cnn.Open();
                sql.ExecuteNonQuery();
                Cnn.Close();

            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }

        }

        public void Alterar(VlTipoDocumento obj)
        {
            try
            {
                SqlConnection Cnn = Banco.CriarConexao();
                string alterar = "Update TipoDocumento set nome=@nome,obs=@obs,@idusu=@idusu Where idtipodocumento=@idtipodocumento";
                SqlCommand sql = new SqlCommand(alterar, Cnn);
                sql.Parameters.AddWithValue("@idtipodocumento", obj.idtipodocumento);
                sql.Parameters.AddWithValue("@nome", obj.nome);
                sql.Parameters.AddWithValue("@obs", obj.obs);
                sql.Parameters.AddWithValue("@idusu", obj.idusu);
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
                string delete = "Delete From TipoDocumento Where idtipodocumento=" + cod + "";
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
