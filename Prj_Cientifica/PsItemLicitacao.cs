using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Prj_Cientifica
{
   public class PsItemLicitacao
    {

        public void Incluir(VlItemLicitacao obj)
        {
            try
            {

                SqlConnection Cnn = Banco.CriarConexao();
                string inserir = ("Insert into ItemsLicitacao values(@lote,@nritem,@idprincipio,@idunidade,@vlestimado,@qtde,@vltotalestimado,@dtitens,@idusu,@descitem,@statusdesc,@statuscotacao,@idproduto,@idcliente,@nlicitacao,@processo,@idfabricante,@idmarca,@idedital)");
                SqlCommand sql = new SqlCommand(inserir, Cnn);
                sql.Parameters.AddWithValue("@lote", obj.lote);
                sql.Parameters.AddWithValue("@nritem", obj.nritem);
                sql.Parameters.AddWithValue("@idprincipio", obj.idprincipio);
                sql.Parameters.AddWithValue("@idunidade", obj.idunidade);
                sql.Parameters.AddWithValue("@vlestimado", obj.vlestimado);
                sql.Parameters.AddWithValue("@qtde", obj.qtde);
                sql.Parameters.AddWithValue("@vltotalestimado", obj.vltotalestimado);
                sql.Parameters.AddWithValue("@dtitens", SqlDbType.Date).Value = Convert.ToDateTime(obj.dtitens).ToString("yyyy/MM/dd");
                sql.Parameters.AddWithValue("@idusu", obj.idusu);
                sql.Parameters.AddWithValue("@descitem", obj.descitem);
                sql.Parameters.AddWithValue("@statusdesc", obj.statusdesc);
                sql.Parameters.AddWithValue("@statuscotacao", obj.statuscotacao);
                sql.Parameters.AddWithValue("@idproduto", obj.idproduto);
                sql.Parameters.AddWithValue("@idcliente", obj.idcliente);
                sql.Parameters.AddWithValue("@nlicitacao", obj.nlicitacao);
                sql.Parameters.AddWithValue("@processo", obj.processo);
                sql.Parameters.AddWithValue("@idfabricante", obj.idfabricante);
                sql.Parameters.AddWithValue("@idmarca", obj.idmarca);
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
                string delete = "Delete From ItemsLicitacao Where iditemedital=" + cod + "";
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

        public void AlterarCotacao(VlItemLicitacao obj)
        {
            try
            {
                SqlConnection Cnn = Banco.CriarConexao();
                string alterar = "Update ItemsLicitacao set statuscotacao=@statuscotacao,idusu=@idusu Where idproduto=@idproduto AND idedital=@idedital AND idproduto=@idproduto ";
                SqlCommand sql = new SqlCommand(alterar, Cnn);
                sql.Parameters.AddWithValue("@idproduto", obj.idproduto);
                sql.Parameters.AddWithValue("@statuscotacao", obj.statuscotacao);
                sql.Parameters.AddWithValue("@idedital", obj.idedital);
                sql.Parameters.AddWithValue("@idusu", obj.idusu);
               // sql.Parameters.AddWithValue("@idfornecedor", obj.idfornecedor);
                Cnn.Open();
                sql.ExecuteNonQuery();
                Cnn.Close();

            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public void ExluirItemDaCotacao(int item, int forn, string edital )
        {
            try
            {

                SqlConnection Cnn = Banco.CriarConexao();
                string delete = "Delete From RetCotacao Where idproduto=" + item + " And idfornecedor=" + forn + " And idedital='" + edital + "'";
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

        public void Alterar(VlItemLicitacao obj)
        {
            try
            {
                SqlConnection Cnn = Banco.CriarConexao();
                string alterar = "Update ItemsLicitacao set lote=@lote,nritem=@nritem,idprincipio=@idprincipio,idunidade=@idunidade,vlestimado=@vlestimado,qtde=@qtde,vltotalestimado=@vltotalestimado,dtitens=@dtitens,idusu=@idusu,descitem=@descitem," +
                    "statusdesc=@statusdesc,statuscotacao=@statuscotacao,idproduto=@idproduto,idcliente=@idcliente,nlicitacao=@nlicitacao,processo=@processo,idfabricante=@idfabricante,idmarca=@idmarca,idedital=@idedital Where idproduto=@idproduto and idedital=@idedital ";
                SqlCommand sql = new SqlCommand(alterar, Cnn);
                sql.Parameters.AddWithValue("@iditemedital", obj.iditemedital);
                sql.Parameters.AddWithValue("@lote", obj.lote);
                sql.Parameters.AddWithValue("@nritem", obj.nritem);
                sql.Parameters.AddWithValue("@idprincipio", obj.idprincipio);
                sql.Parameters.AddWithValue("@idunidade", obj.idunidade);
                sql.Parameters.AddWithValue("@vlestimado", obj.vlestimado);
                sql.Parameters.AddWithValue("@qtde", obj.qtde);
                sql.Parameters.AddWithValue("@vltotalestimado", obj.vltotalestimado);
                sql.Parameters.AddWithValue("@dtitens", SqlDbType.Date).Value = Convert.ToDateTime(obj.dtitens).ToString("yyyy/MM/dd");
                sql.Parameters.AddWithValue("@idusu", obj.idusu);
                sql.Parameters.AddWithValue("@descitem", obj.descitem);
                sql.Parameters.AddWithValue("@statusdesc", obj.statusdesc);
                sql.Parameters.AddWithValue("@statuscotacao", obj.statuscotacao);
                sql.Parameters.AddWithValue("@idproduto", obj.idproduto);
                sql.Parameters.AddWithValue("@idcliente", obj.idcliente);
                sql.Parameters.AddWithValue("@nlicitacao", obj.nlicitacao);
                sql.Parameters.AddWithValue("@processo", obj.processo);
                sql.Parameters.AddWithValue("@idfabricante", obj.idfabricante);
                sql.Parameters.AddWithValue("@idmarca", obj.idmarca);
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

        public void AlterarMarca(VlItemLicitacao obj)
        {
            try
            {
                SqlConnection Cnn = Banco.CriarConexao();
                string alterar = "Update ItemsLicitacao set idmarca=@idmarca,idusu=@idusu Where iditemedital=@iditemedital AND idedital=@idedital";
                SqlCommand sql = new SqlCommand(alterar, Cnn);
                sql.Parameters.AddWithValue("@iditemedital", obj.iditemedital);
                sql.Parameters.AddWithValue("@nlicitacao", obj.nlicitacao);
                sql.Parameters.AddWithValue("@idmarca", obj.idmarca);
                sql.Parameters.AddWithValue("@idusu", obj.idusu);
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
        public void AlterarMarcaEntrega(VlItemLicitacao obj)
        {
            try
            {
                SqlConnection Cnn = Banco.CriarConexao();
                string alterar = "Update Entrega set idmarca=@idmarca,idusu=@idusu Where iditemedital=@iditemedital AND idedital=@idedital";
                SqlCommand sql = new SqlCommand(alterar, Cnn);
                sql.Parameters.AddWithValue("@iditemedital", obj.iditemedital);
                sql.Parameters.AddWithValue("@idmarca", obj.idmarca);
                sql.Parameters.AddWithValue("@idusu", obj.idusu);
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


        public void AlterarItem(VlItemLicitacao obj)
        {
            try
            {
                SqlConnection Cnn = Banco.CriarConexao();
                string alterar = "Update ItemsLicitacao set idedital=@idedital Where idedital=@idedital ";
                SqlCommand sql = new SqlCommand(alterar, Cnn);
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



    }
}