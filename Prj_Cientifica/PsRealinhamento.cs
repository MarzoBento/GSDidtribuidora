using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Prj_Cientifica
{
   public class PsRealinhamento
    {

        public void Incluir(VlRealinhamento obj)
        {
            try
            {

                SqlConnection Cnn = Banco.CriarConexao();
                string inserir = ("Insert into RealinhamentoProposta values(@iditemedital,@qtde,@vlcusto,@vlvenda,@vltotal,@idusu,@idunidade,@idmarca,@margemfinal,@total," +
                    "@entrada,@totalg,@minimounit,@minimototal,@obs,@idproposta,@aditivo,@vladitivo,@imprimir,@dtrealinhamento,@idproduto,@edital,@idedital,@ganhou)");
                SqlCommand sql = new SqlCommand(inserir, Cnn);
                sql.Parameters.AddWithValue("@iditemedital", obj.iditemedital);
                sql.Parameters.AddWithValue("@qtde", obj.qtde);
                sql.Parameters.AddWithValue("@vlcusto", obj.vlcusto);
                sql.Parameters.AddWithValue("@vlvenda", obj.vlvenda);
                sql.Parameters.AddWithValue("@vltotal", obj.vltotal);
                sql.Parameters.AddWithValue("@idusu", obj.idusu);
                sql.Parameters.AddWithValue("@idunidade", obj.idunidade);
                sql.Parameters.AddWithValue("@idmarca", obj.idmarca);
                sql.Parameters.AddWithValue("@margemfinal", obj.margemfinal);
                sql.Parameters.AddWithValue("@total", obj.total);
                sql.Parameters.AddWithValue("@entrada", obj.entrada);
                sql.Parameters.AddWithValue("@totalg", obj.totalg);
                sql.Parameters.AddWithValue("@minimounit", obj.minimounit);
                sql.Parameters.AddWithValue("@minimototal", obj.minimototal);
                sql.Parameters.AddWithValue("@obs", obj.obs);
                sql.Parameters.AddWithValue("@idproposta", obj.idproposta);
                sql.Parameters.AddWithValue("@aditivo", obj.aditivo);
                sql.Parameters.AddWithValue("@vladitivo", obj.vladitivo);
                sql.Parameters.AddWithValue("@imprimir", obj.imprimir);
                sql.Parameters.AddWithValue("@dtrealinhamento", SqlDbType.Date).Value = Convert.ToDateTime(obj.dtrealinhamento).ToString("yyyy/MM/dd");
                sql.Parameters.AddWithValue("@idproduto", obj.idproduto);
                sql.Parameters.AddWithValue("@edital", obj.edital);
                sql.Parameters.AddWithValue("@idedital", obj.idedital);
                sql.Parameters.AddWithValue("@ganhou", obj.ganhou);
                Cnn.Open();
                sql.ExecuteNonQuery();
                Cnn.Close();

            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }

        }

        public void Alterar(VlRealinhamento obj)
        {
            try
            {
                SqlConnection Cnn = Banco.CriarConexao();
                string alterar = "Update RealinhamentoProposta set iditemedital=@iditemedital,qtde=@qtde,vlvenda=@vlvenda,vltotal=@vltotal,idusu=@idusu,vladitivo=@vladitivo,vlcusto=@vlcusto," +
                    "imprimir=@imprimir,dtrealinhamento=@dtrealinhamento,idproduto=@idproduto,minimounit=@minimounit,minimototal=@minimototal,edital=@edital,idedital=@idedital,entrada=@entrada,totalg=@tatalg,ganhou=@ganhou Where idrealinhamento=@idrealinhamento";
                SqlCommand sql = new SqlCommand(alterar, Cnn);
                sql.Parameters.AddWithValue("@idrealinhamento", obj.idrealinhamento);
                sql.Parameters.AddWithValue("@iditemedital", obj.iditemedital);
                sql.Parameters.AddWithValue("@qtde", obj.qtde);
                sql.Parameters.AddWithValue("@vlvenda", obj.vlvenda);
                sql.Parameters.AddWithValue("@vltotal", obj.vltotal);
                sql.Parameters.AddWithValue("@idusu", obj.idusu);
                sql.Parameters.AddWithValue("@aditivo", obj.aditivo);
                sql.Parameters.AddWithValue("@vladitivo", obj.vladitivo);
                sql.Parameters.AddWithValue("@vlcusto", obj.vlcusto);
                sql.Parameters.AddWithValue("@imprimir", obj.imprimir);
                sql.Parameters.AddWithValue("@dtrealinhamento", SqlDbType.Date).Value = Convert.ToDateTime(obj.dtrealinhamento).ToString("yyyy/MM/dd");
                sql.Parameters.AddWithValue("@idproduto", obj.idproduto);
                sql.Parameters.AddWithValue("@minimounit", obj.minimounit);
                sql.Parameters.AddWithValue("@minimototal", obj.minimototal);
                sql.Parameters.AddWithValue("@edital", obj.edital);
                sql.Parameters.AddWithValue("@idedital", obj.idedital);
                sql.Parameters.AddWithValue("@entrada", obj.entrada);
                sql.Parameters.AddWithValue("@totalg", obj.totalg);
                sql.Parameters.AddWithValue("@ganhou", obj.ganhou);
                Cnn.Open();
                sql.ExecuteNonQuery();
                Cnn.Close();

            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public void AlterarPelaProposta(VlRealinhamento obj)
        {
            try
            {
                SqlConnection Cnn = Banco.CriarConexao();
                string alterar = "Update RealinhamentoProposta set qtde=@qtde,vlcusto=@vlcusto,margemfinal=@margemfinal,vlvenda=@vlvenda,vltotal=@vltotal,@idusu=@idusu,aditivo=@aditivo," +
                    "vladitivo=@vladitivo,idmarca=@idmarca,imprimir=@imprimir,dtrealinhamento=@dtrealinhamento,idproduto=@idproduto,minimounit=@minimounit,minimototal=@minimototal,edital=@edital,idedital=@idedital,entrada=@entrada,totalg=@totalg,ganhou=@ganhou," +
                    " total=@total Where idproposta=@idproposta and iditemedital=@iditemedital";
                SqlCommand sql = new SqlCommand(alterar, Cnn);
                sql.Parameters.AddWithValue("@idproposta", obj.idproposta);
                sql.Parameters.AddWithValue("@iditemedital", obj.iditemedital);
                sql.Parameters.AddWithValue("@qtde", obj.qtde);
                sql.Parameters.AddWithValue("@vlcusto", obj.vlcusto);
                sql.Parameters.AddWithValue("@margemfinal", obj.margemfinal);
                sql.Parameters.AddWithValue("@vlvenda", obj.vlvenda);
                sql.Parameters.AddWithValue("@vltotal", obj.vltotal);
                sql.Parameters.AddWithValue("@idusu", obj.idusu);
                sql.Parameters.AddWithValue("@aditivo", obj.aditivo);
                sql.Parameters.AddWithValue("@vladitivo", obj.vladitivo);
                sql.Parameters.AddWithValue("@idmarca", obj.idmarca);
                sql.Parameters.AddWithValue("@imprimir", obj.imprimir);
                sql.Parameters.AddWithValue("@dtrealinhamento", SqlDbType.Date).Value = Convert.ToDateTime(obj.dtrealinhamento).ToString("yyyy/MM/dd");
                sql.Parameters.AddWithValue("@idproduto", obj.idproduto);
                sql.Parameters.AddWithValue("@minimounit", obj.minimounit);
                sql.Parameters.AddWithValue("@minimototal", obj.minimototal);
                sql.Parameters.AddWithValue("@edital", obj.edital);
                sql.Parameters.AddWithValue("@idedital", obj.idedital);
                sql.Parameters.AddWithValue("@entrada", obj.entrada);
                sql.Parameters.AddWithValue("@totalg", obj.totalg);
                sql.Parameters.AddWithValue("@ganhou", obj.ganhou);
                sql.Parameters.AddWithValue("@total", obj.total);
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
                string delete = "Delete From RealinhamentoProposta Where idrealinhamento=" + cod + "";
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
