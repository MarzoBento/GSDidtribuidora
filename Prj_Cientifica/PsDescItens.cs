using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Prj_Cientifica
{
   public class PsDescItens
    {

        public void Alterar(VlDescItens obj)
        {
            try
            {
                SqlConnection Cnn = Banco.CriarConexao();
                string alterar = "Update ItemsLicitacao set descitem=@descitem,statusdesc=@statusdesc Where iditemedital=@iditemedital";
                SqlCommand sql = new SqlCommand(alterar, Cnn);
                sql.Parameters.AddWithValue("@iditemedital", obj.iditemedital);
                sql.Parameters.AddWithValue("@descitem", obj.descitem);
                sql.Parameters.AddWithValue("@statusdesc", obj.statusdesc);
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
