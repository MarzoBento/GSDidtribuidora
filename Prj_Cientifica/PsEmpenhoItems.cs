using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Prj_Cientifica
{
  public  class PsEmpenhoItems
    {

        public void Incluir(VlEmpenhoItems obj)
        {
            try
            {

                SqlConnection Cnn = Banco.CriarConexao();
                string inserir = ("Insert into EmpenhoItems values(@idprincipio,@iditemedital,@idusu,@empenho,@qtde,@item,@preco,@total,@vladitivo,@edital,@idempenho,@idproduto,@nempenho,@lote,@idrealinhamento,@idedital,@notafiscal)");
                SqlCommand sql = new SqlCommand(inserir, Cnn);
                sql.Parameters.AddWithValue("@idprincipio", obj.idprincipio);
                sql.Parameters.AddWithValue("@iditemedital", obj.iditemedital);
                sql.Parameters.AddWithValue("@idusu", obj.idusu);
                sql.Parameters.AddWithValue("@empenho", obj.empenho);
                sql.Parameters.AddWithValue("@qtde", obj.qtde);
                sql.Parameters.AddWithValue("@item", obj.item);
                sql.Parameters.AddWithValue("@preco", obj.preco);
                sql.Parameters.AddWithValue("@total", obj.total);
                sql.Parameters.AddWithValue("@vladitivo", obj.vladitivo);
                sql.Parameters.AddWithValue("@edital", obj.edital);
                sql.Parameters.AddWithValue("@idempenho", obj.idempenho);
                sql.Parameters.AddWithValue("@idproduto", obj.idproduto);
                sql.Parameters.AddWithValue("@nempenho", obj.nempenho);
                sql.Parameters.AddWithValue("@lote", obj.lote);
                sql.Parameters.AddWithValue("@idrealinhamento", obj.idrealinhamento);
                sql.Parameters.AddWithValue("@idedital", obj.idedital);
                sql.Parameters.AddWithValue("@notafiscal", obj.notafiscal);
                Cnn.Open();
                sql.ExecuteNonQuery();
                Cnn.Close();

            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }

        }

        public void Alterar(VlEmpenhoItems obj)
        {
            try
            {
                SqlConnection Cnn = Banco.CriarConexao();
                string alterar = "Update EmpenhoItems set idusu=@idusu,notafiscal=@notafiscal Where idempenhoitems=@idempenhoitems";
                SqlCommand sql = new SqlCommand(alterar, Cnn);
                sql.Parameters.AddWithValue("@idempenhoitems", obj.idempenhoitems);
                sql.Parameters.AddWithValue("@idusu", obj.idusu);
                sql.Parameters.AddWithValue("@notafiscal", obj.notafiscal);
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
                string delete = "Delete From EmpenhoItems Where idempenhoitems=" + cod + "";
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
        private void GravaCodItemEmpenhoTabelaEmpenho(int cod)
        {
            //try
            //{
            //    SqlConnection Cnn = Banco.CriarConexao();
            //    string alterar = "Update Empenho set  Where iditemempenho=@iditemempenho ";
            //    SqlCommand sql = new SqlCommand(alterar, Cnn);
            //    sql.Parameters.AddWithValue("@iditemempenho", obj.iditemempenho);
            //    sql.Parameters.AddWithValue("@idprincipio", obj.idprincipio);
            //    sql.Parameters.AddWithValue("@iditemedital", obj.iditemedital);
            //    sql.Parameters.AddWithValue("@idusu", obj.idusu);
            //    sql.Parameters.AddWithValue("@empenho", obj.empenho);
            //    sql.Parameters.AddWithValue("@qtde", obj.qtde);
            //    sql.Parameters.AddWithValue("@item", obj.item);
            //    sql.Parameters.AddWithValue("@preco", obj.preco);
            //    sql.Parameters.AddWithValue("@total", obj.total);
            //    sql.Parameters.AddWithValue("@aditivo", obj.aditivo);
            //    sql.Parameters.AddWithValue("@vladitivo", obj.vladitivo);
            //    sql.Parameters.AddWithValue("@edital", obj.edital);
            //    Cnn.Open();
            //    sql.ExecuteNonQuery();
            //    Cnn.Close();

            //}
            //catch (Exception ex)
            //{
            //    throw new Exception(ex.Message);
            //}


        }



    }
}
