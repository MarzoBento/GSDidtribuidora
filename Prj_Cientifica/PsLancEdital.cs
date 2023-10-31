using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Prj_Cientifica
{
   public class PsLancEdital
    {

        public void Incluir(VlLancEdital obj)
        {
            try
            {

                SqlConnection Cnn = Banco.CriarConexao();
                string inserir = ("Insert into LancEditais values(@idempresa,@dadosbancario,@idrepresentante,@idcliente,@tipocliente,@idmodalidade,@dtlimite," +
                    "@hora,@dtabertura,@horaabertura,@objeto,@nlicitacao,@nprocesso,@tipoproposta,@respproposta,@icms,@respdoc,@vlproposta,@prazo,@condpagto,@vlprodutos,"+
                    "@vigcontratoata,@ncontratratoata,@dtata,@statuslicitacao,@idusu,@valorlic,@portal,@casasdecimais)");
                SqlCommand sql = new SqlCommand(inserir, Cnn);
                sql.Parameters.AddWithValue("@idempresa", obj.idempresa);
                sql.Parameters.AddWithValue("@dadosbancario", obj.dadosbancario);
                sql.Parameters.AddWithValue("@idrepresentante", obj.idrepresentante);
                sql.Parameters.AddWithValue("@idcliente", obj.idcliente);
                sql.Parameters.AddWithValue("@tipocliente", obj.tipocliente);
                sql.Parameters.AddWithValue("@idmodalidade", obj.idmodalidade);
                sql.Parameters.AddWithValue("@dtlimite", SqlDbType.Date).Value = Convert.ToDateTime(obj.dtlimite).ToString("yyyy/MM/dd");
                sql.Parameters.AddWithValue("@hora", SqlDbType.Time).Value = obj.hora;
                sql.Parameters.AddWithValue("@dtabertura", SqlDbType.Date).Value = Convert.ToDateTime(obj.dtabertura).ToString("yyyy/MM/dd");
                sql.Parameters.AddWithValue("@horaabertura", SqlDbType.Time).Value = obj.horaabertura;
                sql.Parameters.AddWithValue("@objeto", obj.objeto);
                sql.Parameters.AddWithValue("@nlicitacao", obj.nlicitacao);
                sql.Parameters.AddWithValue("@nprocesso", obj.nprocesso);
                sql.Parameters.AddWithValue("@tipoproposta", obj.tipoproposta);
                sql.Parameters.AddWithValue("@respproposta", obj.respproposta);
                sql.Parameters.AddWithValue("@icms", obj.icms);
                sql.Parameters.AddWithValue("@respdoc", obj.respdoc);
                sql.Parameters.AddWithValue("@vlproposta", obj.vlproposta);
                sql.Parameters.AddWithValue("@prazo", obj.prazo);
                sql.Parameters.AddWithValue("@condpagto", obj.condpagto);
                sql.Parameters.AddWithValue("@vlprodutos", obj.vlprodutos);
                sql.Parameters.AddWithValue("@vigcontratoata", obj.vigcontratoata);
                sql.Parameters.AddWithValue("@ncontratratoata", obj.ncontratratoata);
                if (obj.dtata != "  /  /")
                {
                    sql.Parameters.AddWithValue("@dtata", SqlDbType.Date).Value = Convert.ToDateTime(obj.dtata).ToString("yyyy/MM/dd");
                }
                else
                {
                    sql.Parameters.AddWithValue("@dtata", DBNull.Value);
                }
                sql.Parameters.AddWithValue("@statuslicitacao", obj.statuslicitacao);
                sql.Parameters.AddWithValue("@idusu", obj.idusu);
                sql.Parameters.AddWithValue("@valorlic", obj.valorlic);
                sql.Parameters.AddWithValue("@portal", obj.portal);
                sql.Parameters.AddWithValue("@casasdecimais", obj.casasdecinais);
                Cnn.Open();
                sql.ExecuteNonQuery();
                Cnn.Close();

            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }

        }

        public void Alterar(VlLancEdital obj)
        {
            try
            {
                SqlConnection Cnn = Banco.CriarConexao();
                string alterar = "Update LancEditais set idempresa=@idempresa,dadosbancario=@dadosbancario,idrepresentante=@idrepresentante,idcliente=@idcliente,tipocliente=@tipocliente," +
                    "idmodalidade=@idmodalidade,dtlimite=@dtlimite,hora=@hora,dtabertura=@dtabertura,horaabertura=@horaabertura,objeto=@objeto,nlicitacao=@nlicitacao,nprocesso=@nprocesso,tipoproposta=@tipoproposta," +
                    "respproposta=@respproposta,icms=@icms,respdoc=@respdoc,vlproposta=@vlproposta,prazo=@prazo,condpagto=@condpagto,vlprodutos=@vlprodutos,vigcontratoata=@vigcontratoata,ncontratratoata=@ncontratratoata," +
                    "dtata=@dtata,statuslicitacao=@statuslicitacao,idusu=@idusu,valorlic=@valorlic,portal=@portal,casasdecimais=@casasdecimais Where idedital=@idedital";
                SqlCommand sql = new SqlCommand(alterar, Cnn);
                Cnn.Close();
                Cnn.Open();
                sql.Parameters.AddWithValue("@idedital", obj.idedital);
                sql.Parameters.AddWithValue("@idempresa", obj.idempresa);
                sql.Parameters.AddWithValue("@dadosbancario", obj.dadosbancario);
                sql.Parameters.AddWithValue("@idrepresentante", obj.idrepresentante);
                sql.Parameters.AddWithValue("@idcliente", obj.idcliente);
                sql.Parameters.AddWithValue("@tipocliente", obj.tipocliente);
                sql.Parameters.AddWithValue("@idmodalidade", obj.idmodalidade);
                sql.Parameters.AddWithValue("@dtlimite", SqlDbType.Date).Value = Convert.ToDateTime(obj.dtlimite).ToString("yyyy/MM/dd");
                sql.Parameters.AddWithValue("@hora", SqlDbType.Time).Value = obj.hora;
                sql.Parameters.AddWithValue("@dtabertura", SqlDbType.Date).Value = Convert.ToDateTime(obj.dtabertura).ToString("yyyy/MM/dd");
                sql.Parameters.AddWithValue("@horaabertura", SqlDbType.Time).Value = obj.horaabertura;
                sql.Parameters.AddWithValue("@objeto", obj.objeto);
                sql.Parameters.AddWithValue("@nlicitacao", obj.nlicitacao);
                sql.Parameters.AddWithValue("@nprocesso", obj.nprocesso);
                sql.Parameters.AddWithValue("@tipoproposta", obj.tipoproposta);
                sql.Parameters.AddWithValue("@respproposta", obj.respproposta);
                sql.Parameters.AddWithValue("@icms", obj.icms);
                sql.Parameters.AddWithValue("@respdoc", obj.respdoc);
                sql.Parameters.AddWithValue("@vlproposta", obj.vlproposta);
                sql.Parameters.AddWithValue("@prazo", obj.prazo);
                sql.Parameters.AddWithValue("@condpagto", obj.condpagto);
                sql.Parameters.AddWithValue("@vlprodutos", obj.vlprodutos);
                sql.Parameters.AddWithValue("@vigcontratoata", obj.vigcontratoata);
                sql.Parameters.AddWithValue("@ncontratratoata", obj.ncontratratoata);
                if (obj.dtata != "  /  /")
                {
                    sql.Parameters.AddWithValue("@dtata", SqlDbType.Date).Value = Convert.ToDateTime(obj.dtata).ToString("yyyy/MM/dd");
                }
                else
                {
                    sql.Parameters.AddWithValue("@dtata", DBNull.Value);
                }
                sql.Parameters.AddWithValue("@statuslicitacao", obj.statuslicitacao);
                sql.Parameters.AddWithValue("@idusu", obj.idusu);
                sql.Parameters.AddWithValue("@valorlic", obj.valorlic);
                sql.Parameters.AddWithValue("@portal", obj.portal);
                sql.Parameters.AddWithValue("@casasdecimais", obj.casasdecinais);
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
                string delete = "Delete From LancEditais Where idedital=" + cod + "";
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


        public void AlterarStatus(VlLancEdital obj)
        {
            try
            {
                SqlConnection Cnn = Banco.CriarConexao();
                string alterar = "Update LancEditais set statuslicitacao=@statuslicitacao,idusu=@idusu Where nprocesso=@nprocesso";
                SqlCommand sql = new SqlCommand(alterar, Cnn);
                sql.Parameters.AddWithValue("@nprocesso", obj.nprocesso);
                sql.Parameters.AddWithValue("@statuslicitacao", obj.statuslicitacao);
                sql.Parameters.AddWithValue("@idusu", obj.idusu);
                Cnn.Open();
                sql.ExecuteNonQuery();
                Cnn.Close();

            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public void AlterarStatusLicitacao(VlLancEdital obj)
        {
            try
            {
                SqlConnection Cnn = Banco.CriarConexao();
                string alterar = "Update LancEditais set statuslicitacao=@statuslicitacao,idusu=@idusu Where nlicitacao=@nlicitacao";
                SqlCommand sql = new SqlCommand(alterar, Cnn);
                sql.Parameters.AddWithValue("@nlicitacao", obj.nlicitacao);
                sql.Parameters.AddWithValue("@statuslicitacao", obj.statuslicitacao);
                sql.Parameters.AddWithValue("@idusu", obj.idusu);
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
