using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Prj_Cientifica
{
    public class PsPrecoVenda
    {


      

        public void Alterar(VlPrecoVenda obj)
        {
            try
            {
                SqlConnection Cnn = Banco.CriarConexao();
                string alterar = "Update VendaPreco set precocompra=@precocompra,repasse=@repasse,desconto=@desconto,ipi=@ipi,frete=@frete,creditoicms=@creditoicms,icmsvenda=@icmsvenda," +
                    "pis=@pis,comissao=@comissao,custofixo=@custofixo,ml=@ml,fretesaida=@fretesaida,precocusto=@precocusto,idusu=@idusu Where idpreco=@idpreco";
                SqlCommand sql = new SqlCommand(alterar, Cnn);
                sql.Parameters.AddWithValue("@precocompra", obj.precocompra);
                sql.Parameters.AddWithValue("@repasse", obj.repasse);
                sql.Parameters.AddWithValue("@desconto", obj.desconto);
                sql.Parameters.AddWithValue("@ipi", obj.ipi);
                sql.Parameters.AddWithValue("@frete", obj.frete);
                sql.Parameters.AddWithValue("@creditoicms", obj.creditoicms);
                sql.Parameters.AddWithValue("@icmsvenda", obj.icmsvenda);
                sql.Parameters.AddWithValue("@pis", obj.pis);
                sql.Parameters.AddWithValue("@comissao", obj.comissao);
                sql.Parameters.AddWithValue("@custofixo", obj.custofixo);
                sql.Parameters.AddWithValue("@ml", obj.ml);
                sql.Parameters.AddWithValue("@fretesaida", obj.fretesaida);
                sql.Parameters.AddWithValue("@precocusto", obj.precocusto);
                sql.Parameters.AddWithValue("@idusu", obj.idusu);
                sql.Parameters.AddWithValue("@idpreco", obj.idpreco);
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
