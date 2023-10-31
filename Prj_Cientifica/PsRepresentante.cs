using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Prj_Cientifica
{
   public class PsRepresentante
    {

        public void Incluir(VlRepresentante obj)
        {
            try
            {

                SqlConnection Cnn = Banco.CriarConexao();
                string inserir = ("Insert into Representante values(@cnpj,@inscestadual,@cpf,@rg,@razao,@nomerep,@endereco,@bairro,@idcidade,@cep,@fone,@ramal,@celular,@fax,@email," +
                 "@site,@comissao,@idregiao,@obs,@dtcadastro,@contato,@celcontato,@fonecontato,@funcao,@obscontato,@emailcontato,@idempresa,@idusu)");
                SqlCommand sql = new SqlCommand(inserir, Cnn);
                sql.Parameters.AddWithValue("@cnpj", obj.cnpj);
                sql.Parameters.AddWithValue("@inscestadual", obj.inscestadual);
                sql.Parameters.AddWithValue("@cpf", obj.cpf);
                sql.Parameters.AddWithValue("@rg", obj.rg);
                sql.Parameters.AddWithValue("@razao", obj.razao);
                sql.Parameters.AddWithValue("@nomerep", obj.nomerep);
                sql.Parameters.AddWithValue("@endereco", obj.endereco);
                sql.Parameters.AddWithValue("@bairro", obj.bairro);
                sql.Parameters.AddWithValue("@idcidade", obj.idcidade);
                sql.Parameters.AddWithValue("@cep", obj.cep);
                sql.Parameters.AddWithValue("@fone", obj.fone);
                sql.Parameters.AddWithValue("@ramal", obj.ramal);
                sql.Parameters.AddWithValue("@celular", obj.celular);
                sql.Parameters.AddWithValue("@fax", obj.fax);
                sql.Parameters.AddWithValue("@email", obj.email);
                sql.Parameters.AddWithValue("@site", obj.site);
                sql.Parameters.AddWithValue("@comissao", obj.comissao);
                sql.Parameters.AddWithValue("@idregiao", obj.idregiao);
                sql.Parameters.AddWithValue("@obs", obj.obs);
                sql.Parameters.AddWithValue("@dtcadastro", SqlDbType.Date).Value = Convert.ToDateTime(obj.dtcadastro).ToString("yyyy/MM/dd");
                sql.Parameters.AddWithValue("@contato", obj.contato);
                sql.Parameters.AddWithValue("@celcontato", obj.celcontato);
                sql.Parameters.AddWithValue("@fonecontato", obj.fonecontato);
                sql.Parameters.AddWithValue("@funcao", obj.funcao);
                sql.Parameters.AddWithValue("@obscontato", obj.obscontato);
                sql.Parameters.AddWithValue("@emailcontato", obj.emailcontato);
                sql.Parameters.AddWithValue("@idempresa", obj.idempresa);
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

        public void Alterar(VlRepresentante obj)
        {
            try
            {
                SqlConnection Cnn = Banco.CriarConexao();
                string alterar = "Update Representante set cnpj=@cnpj,inscestadual=@inscestadual,cpf=@cpf,rg=@rg,razao=@razao,nomerep=@nomerep,endereco=@endereco,bairro=@bairro,idcidade=@idcidade,cep=@cep,fone=@fone,ramal=@ramal," +
                    "celular=@celular,fax=@fax,email=@email,site=@site,comissao=@comissao,idregiao=@idregiao,obs=@obs,dtcadastro=@dtcadastro,contato=@contato,celcontato=@celcontato," +
                    "fonecontato=@fonecontato,funcao=@funcao,obscontato=@obscontato,emailcontato=@emailcontato,idempresa=@idempresa,idusu=@idusu Where idrepresentante=@idrepresentante";
                SqlCommand sql = new SqlCommand(alterar, Cnn);
                sql.Parameters.AddWithValue("@idrepresentante", obj.idrepresentante);
                sql.Parameters.AddWithValue("@cnpj", obj.cnpj);
                sql.Parameters.AddWithValue("@inscestadual", obj.inscestadual);
                sql.Parameters.AddWithValue("@cpf", obj.cpf);
                sql.Parameters.AddWithValue("@rg", obj.rg);
                sql.Parameters.AddWithValue("@razao", obj.razao);
                sql.Parameters.AddWithValue("@nomerep", obj.nomerep);
                sql.Parameters.AddWithValue("@endereco", obj.endereco);
                sql.Parameters.AddWithValue("@bairro", obj.bairro);
                sql.Parameters.AddWithValue("@idcidade", obj.idcidade);
                sql.Parameters.AddWithValue("@cep", obj.cep);
                sql.Parameters.AddWithValue("@fone", obj.fone);
                sql.Parameters.AddWithValue("@ramal", obj.ramal);
                sql.Parameters.AddWithValue("@celular", obj.celular);
                sql.Parameters.AddWithValue("@fax", obj.fax);
                sql.Parameters.AddWithValue("@email", obj.email);
                sql.Parameters.AddWithValue("@site", obj.site);
                sql.Parameters.AddWithValue("@comissao", obj.comissao);
                sql.Parameters.AddWithValue("@idregiao", obj.idregiao);
                sql.Parameters.AddWithValue("@obs", obj.obs);
                sql.Parameters.AddWithValue("@dtcadastro", SqlDbType.Date).Value = Convert.ToDateTime(obj.dtcadastro).ToString("yyyy/MM/dd");
                sql.Parameters.AddWithValue("@contato", obj.contato);
                sql.Parameters.AddWithValue("@celcontato", obj.celcontato);
                sql.Parameters.AddWithValue("@fonecontato", obj.fonecontato);
                sql.Parameters.AddWithValue("@funcao", obj.funcao);
                sql.Parameters.AddWithValue("@obscontato", obj.obscontato);
                sql.Parameters.AddWithValue("@emailcontato", obj.emailcontato);
                sql.Parameters.AddWithValue("@idempresa", obj.idempresa);
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

        public void Exluir(Int32 cod)
        {
            try
            {

                SqlConnection Cnn = Banco.CriarConexao();
                string delete = "Delete From Representante Where idrepresentante=" + cod + "";
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
