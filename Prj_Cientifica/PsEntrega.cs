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
   public class PsEntrega
    {
        public void Incluir(VlEntrega obj)
        {
            try
            {

                SqlConnection Cnn = Banco.CriarConexao();
                string inserir = ("Insert into Entrega values(@iditemedital,@edital,@idusu,@idprincipio,@idproduto,@dtentrega,@nempenho,@aditivoedital,@nfsaida,@qtde,@preco,@total," +
                    "@idempenho,@iditemempenho,@idmarca,@idedital,@idrepresentante,@comissao,@vlcomissao)");
                SqlCommand sql = new SqlCommand(inserir, Cnn);
                sql.Parameters.AddWithValue("@iditemedital", obj.iditemedital);
                sql.Parameters.AddWithValue("@edital", obj.edital);
                sql.Parameters.AddWithValue("@idusu", obj.idusu);
                sql.Parameters.AddWithValue("@idprincipio", obj.idprincipio);
                sql.Parameters.AddWithValue("@idproduto", obj.idproduto);
                sql.Parameters.AddWithValue("@dtentrega", SqlDbType.Date).Value = SqlDateTime.Null;
                sql.Parameters.AddWithValue("@nempenho", obj.nempenho);
                sql.Parameters.AddWithValue("@aditivoedital", obj.aditivoedital);
                sql.Parameters.AddWithValue("@nfsaida", obj.nfsaida);
                sql.Parameters.AddWithValue("@qtde", obj.qtde);
                sql.Parameters.AddWithValue("@preco", obj.preco);
                sql.Parameters.AddWithValue("@total", obj.total);
                sql.Parameters.AddWithValue("@idempenho", obj.idempenho);
                sql.Parameters.AddWithValue("@iditemempenho", obj.iditemempenho);
                sql.Parameters.AddWithValue("@idmarca", obj.idmarca);
                sql.Parameters.AddWithValue("@idedital", obj.idedital);
                sql.Parameters.AddWithValue("@idrepresentante", obj.idrepresentante);
                sql.Parameters.AddWithValue("@comissao", obj.comissao);
                sql.Parameters.AddWithValue("@vlcomissao", obj.vlcomissao);
                Cnn.Open();
                sql.ExecuteNonQuery();
                Cnn.Close();

            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }

        }

        public void Alterar(VlEntrega obj)
        {
            try
            {
                SqlConnection Cnn = Banco.CriarConexao();
                string alterar = "Update Entrega set idusu=@idusu,dtentrega=@dtentrega,qtde=@qtde,idmarca=@idmarca Where iditemedital=@iditemedital AND identrega=@identrega";
                SqlCommand sql = new SqlCommand(alterar, Cnn);
                sql.Parameters.AddWithValue("@identrega", obj.identrega);
                sql.Parameters.AddWithValue("@iditemedital", obj.iditemedital);
                sql.Parameters.AddWithValue("@idusu", obj.idusu);
                sql.Parameters.AddWithValue("@dtentrega", SqlDbType.Date).Value = SqlDateTime.Null;
                sql.Parameters.AddWithValue("@qtde", obj.qtde);
                sql.Parameters.AddWithValue("@idmarca", obj.idmarca);
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
                string delete = "Delete From Entrega Where identrega=" + cod + "";
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

        public void AlterarPorEmpenho(VlEntrega obj)
        {
            try
            {
                SqlConnection Cnn = Banco.CriarConexao();
                string alterar = "Update Entrega set idusu=@idusu,nfsaida=@nfsaida Where iditemempenho=@iditemempenho";
                SqlCommand sql = new SqlCommand(alterar, Cnn);
                sql.Parameters.AddWithValue("@iditemempenho", obj.iditemempenho);
                sql.Parameters.AddWithValue("@nfsaida", obj.nfsaida);
                sql.Parameters.AddWithValue("@idusu", Banco.idusu);
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
