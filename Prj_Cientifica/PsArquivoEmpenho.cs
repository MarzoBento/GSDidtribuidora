using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Prj_Cientifica
{
    class PsArquivoEmpenho
    {

        public void Incluir(VlArquivoEmpenho obj)
        {
            try
            {

                SqlConnection Cnn = Banco.CriarConexao();
                string inserir = ("Insert into DocumentoEmpenho values(@arq,@nomearq,@idempresa,@edital,@extensao,@dtdocumento,@idusu,@iditemedital,@data,@statusitem,@idedital)");
                SqlCommand sql = new SqlCommand(inserir, Cnn);
                sql.Parameters.AddWithValue("@arq", VlArquivoEmpenho.arq);
                sql.Parameters.AddWithValue("@nomearq", obj.nomearq);
                sql.Parameters.AddWithValue("@idempresa", obj.idempresa);
                sql.Parameters.AddWithValue("@edital", obj.edital);
                sql.Parameters.AddWithValue("@extensao", obj.extensao);
                sql.Parameters.AddWithValue("@dtdocumento", SqlDbType.Date).Value = Convert.ToDateTime(obj.dtdocumento).ToString("yyyy/MM/dd");
                sql.Parameters.AddWithValue("@idusu", obj.idusu);
                sql.Parameters.AddWithValue("@iditemedital", obj.iditemedital);
                sql.Parameters.AddWithValue("@data", SqlDbType.Date).Value = Convert.ToDateTime(obj.data).ToString("yyyy/MM/dd");
                sql.Parameters.AddWithValue("@statusitem", obj.statusitem);
                sql.Parameters.AddWithValue("@idedital", obj.idedital);
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
                string delete = "Delete From DocumentoEmpenho Where iddocempenho=" + cod + "";
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
