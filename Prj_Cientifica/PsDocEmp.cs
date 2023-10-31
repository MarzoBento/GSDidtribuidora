using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Prj_Cientifica
{
   public class PsDocEmp
    {

        public void Incluir(VlDocEmp obj)
        {
            try
            {

                SqlConnection Cnn = Banco.CriarConexao();
                string inserir = ("Insert into DocEmp values(@arq,@nomearq,@idempresa,@iddocumento,@idtipodocumento,@dtemissao,@dtvalidade,@observacao,@extensao,@idusu,@diasvenc)");
                SqlCommand sql = new SqlCommand(inserir, Cnn);
                sql.Parameters.AddWithValue("@arq", VlDocEmp.arq);
                sql.Parameters.AddWithValue("@nomearq", obj.nomearq);
                sql.Parameters.AddWithValue("@idempresa", obj.idempresa);
                sql.Parameters.AddWithValue("@iddocumento", obj.iddocumento);
                sql.Parameters.AddWithValue("@idtipodocumento", obj.idtipodocumento);
                sql.Parameters.AddWithValue("@dtemissao", SqlDbType.Date).Value = Convert.ToDateTime(obj.dtemissao).ToString("yyyy/MM/dd");
                sql.Parameters.AddWithValue("@dtvalidade", SqlDbType.Date).Value = Convert.ToDateTime(obj.dtvalidade).ToString("yyyy/MM/dd");
                sql.Parameters.AddWithValue("@observacao", obj.observacao);
                sql.Parameters.AddWithValue("@extensao", obj.extensao);
                sql.Parameters.AddWithValue("@idusu", obj.idusu);
                sql.Parameters.AddWithValue("@diasvenc", obj.diasvenc);
                Cnn.Open();
                sql.ExecuteNonQuery();
                Cnn.Close();

            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }

        }

        public void Alterar(VlDocEmp obj)
        {
            try
            {
                SqlConnection Cnn = Banco.CriarConexao();
                string alterar = "Update DocEmp set arq=@arq,nomearq=@nomearq,@idempresa=@idempresa,iddocumento=@iddocumento,,@idtipodocumento=@idtipodocumento,dtemissao=@dtemissao,dtvalidade=@dtvalidade,observacao=@observacao,extensao=@extensao,idusu=@idusu,diasvenc=@diasvenc Where iddocemp=@iddocemp";
                SqlCommand sql = new SqlCommand(alterar, Cnn);
                sql.Parameters.AddWithValue("@iddocemp", obj.iddocemp);
                sql.Parameters.AddWithValue("@arq", VlDocEmp.arq);
                sql.Parameters.AddWithValue("@nomearq", obj.nomearq);
                sql.Parameters.AddWithValue("@idempresa", obj.idempresa);
                sql.Parameters.AddWithValue("@iddocumento", obj.iddocumento);
                sql.Parameters.AddWithValue("@idtipodocumento", obj.idtipodocumento);
                sql.Parameters.AddWithValue("@dtemissao", SqlDbType.Date).Value = Convert.ToDateTime(obj.dtemissao).ToString("yyyy/MM/dd");
                sql.Parameters.AddWithValue("@dtvalidade", SqlDbType.Date).Value = Convert.ToDateTime(obj.dtvalidade).ToString("yyyy/MM/dd");
                sql.Parameters.AddWithValue("@observacao", obj.observacao);
                sql.Parameters.AddWithValue("@extensao", obj.extensao);
                sql.Parameters.AddWithValue("@idusu", obj.idusu);
                sql.Parameters.AddWithValue("@diasvenc", obj.diasvenc);
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
                string delete = "Delete From DocEmp Where iddocemp=" + cod + "";
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
