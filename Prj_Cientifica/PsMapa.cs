using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Prj_Cientifica
{
   public class PsMapa
    {

        public void Incluir(VlMapa obj)
        {
            try
            {

                SqlConnection Cnn = Banco.CriarConexao();
                string inserir = ("Insert into MapaPreco values(@edital,@iditemedital,@idconcorrente,@precoinicial,@precoganho,@idmarca,@dtmapa,@idusu,@idempresa,@qtde,@idedital)");
                SqlCommand sql = new SqlCommand(inserir, Cnn);
                sql.Parameters.AddWithValue("@edital", obj.edital);
                sql.Parameters.AddWithValue("@iditemedital", obj.iditemedital);
                sql.Parameters.AddWithValue("@idconcorrente", obj.idconcorrente);
                sql.Parameters.AddWithValue("@precoinicial", obj.precoinicial);
                sql.Parameters.AddWithValue("@precoganho", obj.precoganho);
                sql.Parameters.AddWithValue("@idmarca", obj.idmarca);
                sql.Parameters.AddWithValue("@dtmapa", SqlDbType.Date).Value = Convert.ToDateTime(obj.dtmapa).ToString("yyyy/MM/dd");
                sql.Parameters.AddWithValue("@idusu", obj.idusu);
                sql.Parameters.AddWithValue("@idempresa", obj.idempresa);
                sql.Parameters.AddWithValue("@qtde", obj.qtde);
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





        public void Alterar(VlMapa obj)
        {
            try
            {
                SqlConnection Cnn = Banco.CriarConexao();
                string alterar = "Update MapaPreco set edital=@edital,iditemedital=@iditemedital,idconcorrente=@idconcorrente,precoinicial=@precoinicial,precoganho=@precoganho,idmarca=@idmarca,dtmapa=@dtmapa," +
                    "idusu=@idusu,qtde=@qtde,idedital=@idedital Where iditemedital=@iditemedital AND edital=@edital";
                SqlCommand sql = new SqlCommand(alterar, Cnn);
                sql.Parameters.AddWithValue("@idmapa", obj.idmapa);
                sql.Parameters.AddWithValue("@edital", obj.edital);
                sql.Parameters.AddWithValue("@iditemedital", obj.iditemedital);
                sql.Parameters.AddWithValue("@idconcorrente", obj.idconcorrente);
                sql.Parameters.AddWithValue("@precoinicial", obj.precoinicial);
                sql.Parameters.AddWithValue("@precoganho", obj.precoganho);
                sql.Parameters.AddWithValue("@idmarca", obj.idmarca);
                sql.Parameters.AddWithValue("@dtmapa", obj.dtmapa);
                sql.Parameters.AddWithValue("@idusu", obj.idusu);
                sql.Parameters.AddWithValue("@qtde", obj.qtde);
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
                string delete = "Delete From MapaPreco Where idmapa=" + cod + "";
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
