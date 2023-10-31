using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Prj_Cientifica
{
   public class PsImprimeProposta
    {

        public void Alterar(VlImprimeProposta obj)
        {
            try
            {
                SqlConnection Cnn = Banco.CriarConexao();
                string alterar = "Update Proposta set selecionado=@selecionado Where idproposta=@idproposta";
                SqlCommand sql = new SqlCommand(alterar, Cnn);
                sql.Parameters.AddWithValue("@idproposta", obj.idproposta);
                sql.Parameters.AddWithValue("@selecionado", obj.imprimir);
                Cnn.Open();
                sql.ExecuteNonQuery();
                Cnn.Close();

            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public void AlterarRealinhamento(VlImprimeProposta obj)
        {
            try
            {
                SqlConnection Cnn = Banco.CriarConexao();
                string alterar = "Update RealinhamentoProposta set imprimir=@imprimir Where idproposta=@idproposta";
                SqlCommand sql = new SqlCommand(alterar, Cnn);
                sql.Parameters.AddWithValue("@idproposta", obj.idproposta);
                sql.Parameters.AddWithValue("@imprimir", obj.imprimir);
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
