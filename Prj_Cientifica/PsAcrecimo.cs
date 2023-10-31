using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Prj_Cientifica
{
   public class PsAcrecimo
    {

        public void Alterar(Acrescimo obj)
        {
            try
            {
                SqlConnection Cnn = Banco.CriarConexao();
                string alterar = "Update Proposta set precovenda=@precovenda,precominimo=@precominimo,minimototal=@minimototal Where idproposta=@idproposta and iditemedital=@iditemedital";
                SqlCommand sql = new SqlCommand(alterar, Cnn);
                sql.Parameters.AddWithValue("@precovenda", obj.precovenda);
                sql.Parameters.AddWithValue("@idproposta", obj.idproposta);
                sql.Parameters.AddWithValue("@iditemedital", obj.iditemedital);
                sql.Parameters.AddWithValue("@precominimo", obj.precominimo);
                sql.Parameters.AddWithValue("@minimototal", obj.minimototal);


                Cnn.Open();
                sql.ExecuteNonQuery();
                Cnn.Close();

            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }



        public void Incluir(Acrescimo obj)
        {
            try
            {

                SqlConnection Cnn = Banco.CriarConexao();
                string inserir = ("Insert into Acrescimo values(@iditemedital,@idproposta,@vlacrescimo,@precovenda,@idusu,@vlaumentado,@vlinicial,@idedital)");
                SqlCommand sql = new SqlCommand(inserir, Cnn);
                sql.Parameters.AddWithValue("@iditemedital", obj.iditemedital);
                sql.Parameters.AddWithValue("@idproposta", obj.idproposta);
                sql.Parameters.AddWithValue("@vlacrescimo", obj.acrecimo);
                sql.Parameters.AddWithValue("@precovenda", obj.precovenda);
                sql.Parameters.AddWithValue("@idusu", Banco.idusu);
                sql.Parameters.AddWithValue("@vlaumentado", obj.vlaumentado);
                sql.Parameters.AddWithValue("@vlinicial", obj.vlinicial);
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

        public void AlterarAcrescimo(Acrescimo obj)
        {
            try
            {
                SqlConnection Cnn = Banco.CriarConexao();
                string alterar = "Update Acrescimo set vlacrescimo=@vlacrescimo, precovenda=@precovenda,vlaumentado=@vlaumentado,idedital=@idedital Where idproposta=@idproposta and iditemedital=@iditemedital";
                SqlCommand sql = new SqlCommand(alterar, Cnn);
                sql.Parameters.AddWithValue("@vlacrescimo", obj.acrecimo);
                sql.Parameters.AddWithValue("@precovenda", obj.precovenda);
                sql.Parameters.AddWithValue("@idproposta", obj.idproposta);
                sql.Parameters.AddWithValue("@iditemedital", obj.iditemedital);
                sql.Parameters.AddWithValue("@vlaumentado", obj.vlaumentado);
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

        public void Exluir(int codp, int codi)
        {
            try
            {

                SqlConnection Cnn = Banco.CriarConexao();
                string delete = "Delete From Acrescimo  Where idproposta=" + codp + "AND iditemedital=" + codi;
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

        public void VoltaValorInicial(VlProposta obj)
        {

            try
            {
                SqlConnection Cnx = Banco.CriarConexao();
                string alterar = "Update Proposta set precovenda=@precovenda,precominimo=@precominimo, minimototal=@minimototal WHERE idproposta=@idproposta and iditemedital=@iditemedital";
                SqlCommand sql = new SqlCommand(alterar, Cnx);
                sql.Parameters.AddWithValue("@precovenda", obj.precovenda);
                sql.Parameters.AddWithValue("@idproposta", obj.idproposta);
                sql.Parameters.AddWithValue("@iditemedital", obj.iditemedital);
                sql.Parameters.AddWithValue("@precominimo", obj.precominimo);
                sql.Parameters.AddWithValue("@minimototal", obj.minimototal);
                Cnx.Open();
                sql.ExecuteNonQuery();
                Cnx.Close();

            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }

        }




    }
}
