using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Prj_Cientifica
{
    public class PsDecrescimo
    {
        public void Alterar(Decrescimos obj)
        {
            try
            {
                SqlConnection Cnn = Banco.CriarConexao();
                string alterar = "Update Proposta set precominimo=@precominimo,minimototal=@minimototal Where idproposta=@idproposta and iditemedital=@iditemedital";
                SqlCommand sql = new SqlCommand(alterar, Cnn);
                sql.Parameters.AddWithValue("@precominimo", obj.precovenda);
                sql.Parameters.AddWithValue("@minimototal", obj.minimototal);
                sql.Parameters.AddWithValue("@idproposta", obj.idproposta);
                sql.Parameters.AddWithValue("@iditemedital", obj.iditemedital);
              
                Cnn.Open();
                sql.ExecuteNonQuery();
                Cnn.Close();

            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }



        public void Incluir(Decrescimos obj)
        {
            try
            {

                SqlConnection Cnn = Banco.CriarConexao();
                string inserir = ("Insert into Decrescimos values(@iditemedital,@idproposta,@vldecrescimo,@precovenda,@idusu,@vldiminuido,@vlinicial)");
                SqlCommand sql = new SqlCommand(inserir, Cnn);
                sql.Parameters.AddWithValue("@iditemedital", obj.iditemedital);
                sql.Parameters.AddWithValue("@idproposta", obj.idproposta);
                sql.Parameters.AddWithValue("@vldecrescimo", obj.decrecimo);
                sql.Parameters.AddWithValue("@precovenda", obj.precovenda);
                sql.Parameters.AddWithValue("@idusu", Banco.idusu);
                sql.Parameters.AddWithValue("@vldiminuido", obj.vldiminuido);
                sql.Parameters.AddWithValue("@vlinicial", obj.vlinicial);
                Cnn.Open();
                sql.ExecuteNonQuery();
                Cnn.Close();

            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }

        }
        public void AlterarDecrescimo(Decrescimos obj)
        {
            try
            {
                SqlConnection Cnn = Banco.CriarConexao();
                string alterar = "Update Decrescimos set vldecrescimo=@vldecrescimo, precovenda=@precovenda,vldiminuido=@vldiminuido Where idproposta=@idproposta and iditemedital=@iditemedital";
                SqlCommand sql = new SqlCommand(alterar, Cnn);
                sql.Parameters.AddWithValue("@vldecrescimo", obj.decrecimo);
                sql.Parameters.AddWithValue("@precovenda", obj.precovenda);
                sql.Parameters.AddWithValue("@idproposta", obj.idproposta);
                sql.Parameters.AddWithValue("@iditemedital", obj.iditemedital);
                sql.Parameters.AddWithValue("@vldiminuido", obj.vldiminuido);
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
                string delete = "Delete From Decrescimos Where idproposta=" + codp + "AND iditemedital=" + codi;
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
                string alterar = "Update Proposta set precominimo=@precominimo,minimototal=@minimototal WHERE idproposta=@idproposta and iditemedital=@iditemedital";
                SqlCommand sql = new SqlCommand(alterar, Cnx);
                sql.Parameters.AddWithValue("@precominimo", obj.precominimo);
                sql.Parameters.AddWithValue("@minimototal", obj.minimototal);
                sql.Parameters.AddWithValue("@idproposta", obj.idproposta);
                sql.Parameters.AddWithValue("@iditemedital", obj.iditemedital);
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
