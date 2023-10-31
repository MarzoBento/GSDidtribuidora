using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Prj_Cientifica
{
   public class PsPropostaDocEmp
    {

        public void Incluir(VlDocPropostaEmp obj)
        {
            try
            {

                SqlConnection Cnn = Banco.CriarConexao();
                string inserir = ("Insert into DocPropostaEmp values(@idempresa,@idtipodoc,@idedital,@arq,@nomearq,@extensao,@dtarquivo,@idusu)");
                SqlCommand sql = new SqlCommand(inserir, Cnn);
                sql.Parameters.AddWithValue("@idempresa", obj.idempresa);
                sql.Parameters.AddWithValue("@idtipodoc", obj.idtipodoc);
                sql.Parameters.AddWithValue("@idedital", obj.idedital);
                sql.Parameters.AddWithValue("@arq", VlDocPropostaEmp.arq);
                sql.Parameters.AddWithValue("@nomearq", obj.nomearq);
                sql.Parameters.AddWithValue("@extensao", obj.extensao);
                sql.Parameters.AddWithValue("@dtarquivo", SqlDbType.Date).Value = Convert.ToDateTime(obj.dtarquivo).ToString("yyyy/MM/dd");
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

        //public void Alterar(VlHabilitacaoDocEmpresa obj)
        //{
        //    try
        //    {
        //        SqlConnection Cnn = Banco.CriarConexao();
        //        string alterar = "Update DocHabilitacaoEmp set idempresa=@idempresa,idtipodoc=@idtipodoc,idedital=@idedital,conta=@conta,favorecido=@favorecido Where iddocempresa=@iddocempresa";
        //        SqlCommand sql = new SqlCommand(alterar, Cnn);
        //        sql.Parameters.AddWithValue("@iddocempresa", obj.iddocempresa);
        //        sql.Parameters.AddWithValue("@idempresa", obj.idempresa);
        //        sql.Parameters.AddWithValue("@idtipodoc", obj.idtipodoc);
        //        sql.Parameters.AddWithValue("@idedital", obj.idedital);
        //        sql.Parameters.AddWithValue("@arq", VlHabilitacaoDocEmpresa.arq);
        //        sql.Parameters.AddWithValue("@nomearq", obj.nomearq);
        //        sql.Parameters.AddWithValue("@extensao", obj.extensao);
        //        sql.Parameters.AddWithValue("@dtarquivo", SqlDbType.Date).Value = Convert.ToDateTime(obj.dtarquivo).ToString("yyyy/MM/dd");
        //        Cnn.Open();
        //        sql.ExecuteNonQuery();
        //        Cnn.Close();

        //    }
        //    catch (Exception ex)
        //    {
        //        throw new Exception(ex.Message);
        //    }
        //}
        public void Exluir(Int32 cod)
        {
            try
            {

                SqlConnection Cnn = Banco.CriarConexao();
                string delete = "Delete From DocPropostaEmp Where iddocempresaprop=" + cod + "";
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
