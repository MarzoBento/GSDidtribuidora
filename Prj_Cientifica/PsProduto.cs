using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Prj_Cientifica
{
    public class PsProduto
    {

        public void Incluir(VlProduto obj)
        {
            try
            {

                SqlConnection Cnn = Banco.CriarConexao();
                string inserir = ("Insert into Produto values(@idprincipio,@nome,@idunidade,@apresentacao,@codca,@registro,@dtvalidade,@idprocedencia,@idfabricante,@precofabrica,@pmvg,@convenioicms,@cap,@idclassificacaofiscal,@dtcadastro,@idusu,@idempresa,@statusprod,@idmarca,@validadeprod)");
                SqlCommand sql = new SqlCommand(inserir, Cnn);
                sql.Parameters.AddWithValue("@idprincipio", obj.idprincipio);
                sql.Parameters.AddWithValue("@nome", obj.nome);
                sql.Parameters.AddWithValue("@idunidade", obj.idunidade);
                sql.Parameters.AddWithValue("@apresentacao", obj.apresentacao);
                sql.Parameters.AddWithValue("@codca", obj.codca);
                sql.Parameters.AddWithValue("@dtproduto", obj.statusprod);
                sql.Parameters.AddWithValue("@registro", obj.registro);
                if (obj.dtvalidade != "")
                {
                    sql.Parameters.AddWithValue("@dtvalidade", SqlDbType.Date).Value = Convert.ToDateTime(obj.dtvalidade).ToString("yyyy/MM/dd");
                }
                else
                {
                    sql.Parameters.AddWithValue("@dtvalidade", DBNull.Value);
                }
                sql.Parameters.AddWithValue("@idprocedencia", obj.idprocedencia);
                sql.Parameters.AddWithValue("@idfabricante", obj.idfabricante);
                sql.Parameters.AddWithValue("@precofabrica", obj.precofabrica);
                sql.Parameters.AddWithValue("@pmvg", obj.pmvg);
                sql.Parameters.AddWithValue("@convenioicms", obj.convenioicms);
                sql.Parameters.AddWithValue("@cap", obj.cap);
                sql.Parameters.AddWithValue("@idclassificacaofiscal", obj.idclassificacaofiscal);
                sql.Parameters.AddWithValue("@dtcadastro", SqlDbType.Date).Value = Convert.ToDateTime(obj.dtcadastro).ToString("yyyy/MM/dd");
                sql.Parameters.AddWithValue("@idusu", obj.idusu);
                sql.Parameters.AddWithValue("@idempresa", obj.idempresa);
                sql.Parameters.AddWithValue("@statusprod", obj.statusprod);
                sql.Parameters.AddWithValue("@idmarca", obj.idmarca);
                sql.Parameters.AddWithValue("@validadeprod", obj.validadeprod);
                Cnn.Open();
                sql.ExecuteNonQuery();
                Cnn.Close();

            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }

        }

        public void Alterar(VlProduto obj)
        {
            try
            {
                SqlConnection Cnn = Banco.CriarConexao();
                string alterar = "Update Produto set idprincipio=@idprincipio,nome=@nome,idunidade=@idunidade,apresentacao=@apresentacao,codca=@codca,registro=@registro,dtvalidade=@dtvalidade,idprocedencia=@idprocedencia," +
                    "idfabricante=@idfabricante,precofabrica=@precofabrica,pmvg=@pmvg,convenioicms=@convenioicms,cap=@cap,idclassificacaofiscal=@idclassificacaofiscal,dtcadastro=@dtcadastro,idusu=@idusu,statusprod=@statusprod,idmarca=@idmarca,validadeprod=@validadeprod Where idproduto=@idproduto";
                SqlCommand sql = new SqlCommand(alterar, Cnn);
                sql.Parameters.AddWithValue("@idproduto", obj.idproduto);
                sql.Parameters.AddWithValue("@idprincipio", obj.idprincipio);
                sql.Parameters.AddWithValue("@nome", obj.nome);
                sql.Parameters.AddWithValue("@idunidade", obj.idunidade);
                sql.Parameters.AddWithValue("@apresentacao", obj.apresentacao);
                sql.Parameters.AddWithValue("@codca", obj.codca);
                sql.Parameters.AddWithValue("@registro", obj.registro);
                if (obj.dtvalidade != "")
                {
                    sql.Parameters.AddWithValue("@dtvalidade", SqlDbType.Date).Value = Convert.ToDateTime(obj.dtvalidade).ToString("yyyy/MM/dd");
                }
                else
                {
                    sql.Parameters.AddWithValue("@dtvalidade", DBNull.Value);
                }
                sql.Parameters.AddWithValue("@idprocedencia", obj.idprocedencia);
                sql.Parameters.AddWithValue("@idfabricante", obj.idfabricante);
                sql.Parameters.AddWithValue("@precofabrica", obj.precofabrica);
                sql.Parameters.AddWithValue("@pmvg", obj.pmvg);
                sql.Parameters.AddWithValue("@convenioicms", obj.convenioicms);
                sql.Parameters.AddWithValue("@cap", obj.cap);
                sql.Parameters.AddWithValue("@idclassificacaofiscal", obj.idclassificacaofiscal);
                sql.Parameters.AddWithValue("@dtcadastro", SqlDbType.Date).Value = Convert.ToDateTime(obj.dtcadastro).ToString("yyyy/MM/dd");
                sql.Parameters.AddWithValue("@idusu", obj.idusu);
                sql.Parameters.AddWithValue("@idempresa", obj.idempresa);
                sql.Parameters.AddWithValue("@statusprod", obj.statusprod);
                sql.Parameters.AddWithValue("@idmarca", obj.idmarca);
                sql.Parameters.AddWithValue("@validadeprod", obj.validadeprod);
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
                string delete = "Delete From Produto Where idproduto=" + cod + "";
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


        public void AlteraStatusProduto(VlProduto obj)
        {
            try
            {
                SqlConnection Cnn = Banco.CriarConexao();
                string alterar = "Update Produto set statusprod=@statusprod Where idproduto=@idproduto";
                SqlCommand sql = new SqlCommand(alterar, Cnn);
                sql.Parameters.AddWithValue("@idproduto", obj.idproduto);
                sql.Parameters.AddWithValue("@statusprod", obj.statusprod);
                Cnn.Open();
                sql.ExecuteNonQuery();
                Cnn.Close();

            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }


        public void AlterarProduto(VlProduto obj)
        {
            try
            {
                SqlConnection Cnn = Banco.CriarConexao();
                string alterar = "Update Produto set idprincipio=@idprincipio,nome=@nome,idunidade=@idunidade,apresentacao=@apresentacao,statusreg=@statusreg,registro=@registro,dtvalidade=@dtvalidade,idprocedencia=@idprocedencia," +
                    "idfabricante=@idfabricante,precofabrica=@precofabrica,pmvg=@pmvg,convenioicms=@convenioicms,cap=@cap,idclassificacaofiscal=@idclassificacaofiscal,dtcadastro=@dtcadastro,idusu=@idusu,processo=@processo,statusprod=@statusprod,idmarca=@idmarca,validadeprod=@validadeprod Where idproduto=@idproduto and ";
                SqlCommand sql = new SqlCommand(alterar, Cnn);
                sql.Parameters.AddWithValue("@idproduto", obj.idproduto);
                sql.Parameters.AddWithValue("@idprincipio", obj.idprincipio);
                sql.Parameters.AddWithValue("@nome", obj.nome);
                sql.Parameters.AddWithValue("@idunidade", obj.idunidade);
                sql.Parameters.AddWithValue("@apresentacao", obj.apresentacao);
                sql.Parameters.AddWithValue("@statusprod", obj.statusprod);
                sql.Parameters.AddWithValue("@registro", obj.registro);
                if (obj.dtvalidade != "")
                {
                    sql.Parameters.AddWithValue("@dtvalidade", SqlDbType.Date).Value = Convert.ToDateTime(obj.dtvalidade).ToString("yyyy/MM/dd");
                }
                else
                {
                    sql.Parameters.AddWithValue("@dtvalidade", DBNull.Value);
                }
                sql.Parameters.AddWithValue("@idprocedencia", obj.idprocedencia);
                sql.Parameters.AddWithValue("@idfabricante", obj.idfabricante);
                sql.Parameters.AddWithValue("@precofabrica", obj.precofabrica);
                sql.Parameters.AddWithValue("@pmvg", obj.pmvg);
                sql.Parameters.AddWithValue("@convenioicms", obj.convenioicms);
                sql.Parameters.AddWithValue("@cap", obj.cap);
                sql.Parameters.AddWithValue("@idclassificacaofiscal", obj.idclassificacaofiscal);
                sql.Parameters.AddWithValue("@dtcadastro", SqlDbType.Date).Value = Convert.ToDateTime(obj.dtcadastro).ToString("yyyy/MM/dd");
                sql.Parameters.AddWithValue("@idusu", obj.idusu);
                sql.Parameters.AddWithValue("@idempresa", obj.idempresa);
                sql.Parameters.AddWithValue("@statusprod", obj.statusprod);
                sql.Parameters.AddWithValue("@idmarca", obj.idmarca);
                sql.Parameters.AddWithValue("@validadeprod", obj.validadeprod);

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
