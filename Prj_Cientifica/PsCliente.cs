using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Prj_Cientifica
{
   public  class PsCliente
    {

        public void Incluir(VlCliente obj)
        {
            try
            {

                SqlConnection Cnn = Banco.CriarConexao();
                string inserir = ("Insert into Cliente values(@cnpj,@inscestadual,@tipocli,@razao,@nome,@endereco,@bairro,@idcidade,@cep,@fax,@fone,@ramal,@celular,@email," +
                 "@site,@idrepresentante,@obs,@contato,@fonecontato,@ramalcontato,@celcontato,@emailcontato,@contato2,@fonecontato2,@ramalcontato2,@celcontato2,@emailcontato2,@entrega,@dtcadastro,@idempresa,@idusu,@estado,@statuscli)");
                SqlCommand sql = new SqlCommand(inserir, Cnn);
                sql.Parameters.AddWithValue("@cnpj", obj.cnpj);
                sql.Parameters.AddWithValue("@inscestadual", obj.inscestadual);
                sql.Parameters.AddWithValue("@tipocli", obj.tipocli);
                sql.Parameters.AddWithValue("@razao", obj.razao);
                sql.Parameters.AddWithValue("@nome", obj.nome);
                sql.Parameters.AddWithValue("@endereco", obj.endereco);
                sql.Parameters.AddWithValue("@bairro", obj.bairro);
                sql.Parameters.AddWithValue("@idcidade", obj.idcidade);
                sql.Parameters.AddWithValue("@cep", obj.cep);
                sql.Parameters.AddWithValue("@fax", obj.fax);
                sql.Parameters.AddWithValue("@fone", obj.fone);
                sql.Parameters.AddWithValue("@ramal", obj.ramal);
                sql.Parameters.AddWithValue("@celular", obj.celular);
                sql.Parameters.AddWithValue("@email", obj.email);
                sql.Parameters.AddWithValue("@site", obj.site);
                sql.Parameters.AddWithValue("@idrepresentante", obj.idrepresentante);
                sql.Parameters.AddWithValue("@obs", obj.obs);
                sql.Parameters.AddWithValue("@contato", obj.contato);
                sql.Parameters.AddWithValue("@fonecontato", obj.fonecontato);
                sql.Parameters.AddWithValue("@ramalcontato", obj.ramalcontato);
                sql.Parameters.AddWithValue("@celcontato", obj.celcontato);
                sql.Parameters.AddWithValue("@emailcontato", obj.emailcontato);
                sql.Parameters.AddWithValue("@contato2", obj.contato2);
                sql.Parameters.AddWithValue("@fonecontato2", obj.fonecontato2);
                sql.Parameters.AddWithValue("@ramalcontato2", obj.ramalcontato2);
                sql.Parameters.AddWithValue("@celcontato2", obj.celcontato2);
                sql.Parameters.AddWithValue("@emailcontato2", obj.emailcontato2);
                sql.Parameters.AddWithValue("@entrega", obj.entrega);
                sql.Parameters.AddWithValue("@dtcadastro", SqlDbType.Date).Value = Convert.ToDateTime(obj.dtcadastro).ToString("yyyy/MM/dd");
                sql.Parameters.AddWithValue("@idempresa", obj.idempresa);
                sql.Parameters.AddWithValue("@idusu", obj.idusu);
                sql.Parameters.AddWithValue("@estado", obj.estado);
                sql.Parameters.AddWithValue("@statuscli", obj.statuscli);
                Cnn.Open();
                sql.ExecuteNonQuery();
                Cnn.Close();

            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }

        }

        public void Alterar(VlCliente obj)
        {
            try
            {
                SqlConnection Cnn = Banco.CriarConexao();
                string alterar = "Update Cliente set cnpj=@cnpj,inscestadual=@inscestadual,tipocli=@tipocli,razao=@razao,nome=@nome,endereco=@endereco,bairro=@bairro,idcidade=@idcidade,cep=@cep,fax=@fax,fone=@fone,ramal=@ramal," +
                    "celular=@celular,email=@email,site=@site,idrepresentante=@idrepresentante,obs=@obs,contato=@contato,fonecontato=@fonecontato,ramalcontato=@ramalcontato,celcontato=@celcontato,emailcontato=@emailcontato," +
                    "contato2=@contato2,fonecontato2=@fonecontato2,ramalcontato2=@ramalcontato2,celcontato2=@celcontato2,emailcontato2=@emailcontato2,entrega=@entrega,dtcadastro=@dtcadastro,idempresa=@idempresa,idusu=@idusu,estado=@estado,statuscli=@statuscli Where idcliente=@idcliente";
                SqlCommand sql = new SqlCommand(alterar, Cnn);
                sql.Parameters.AddWithValue("@idcliente", obj.idcliente);
                sql.Parameters.AddWithValue("@cnpj", obj.cnpj);
                sql.Parameters.AddWithValue("@inscestadual", obj.inscestadual);
                sql.Parameters.AddWithValue("@tipocli", obj.tipocli);
                sql.Parameters.AddWithValue("@razao", obj.razao);
                sql.Parameters.AddWithValue("@nome", obj.nome);
                sql.Parameters.AddWithValue("@endereco", obj.endereco);
                sql.Parameters.AddWithValue("@bairro", obj.bairro);
                sql.Parameters.AddWithValue("@idcidade", obj.idcidade);
                sql.Parameters.AddWithValue("@cep", obj.cep);
                sql.Parameters.AddWithValue("@fax", obj.fax);
                sql.Parameters.AddWithValue("@fone", obj.fone);
                sql.Parameters.AddWithValue("@ramal", obj.ramal);
                sql.Parameters.AddWithValue("@celular", obj.celular);
                sql.Parameters.AddWithValue("@email", obj.email);
                sql.Parameters.AddWithValue("@site", obj.site);
                sql.Parameters.AddWithValue("@idrepresentante", obj.idrepresentante);
                sql.Parameters.AddWithValue("@obs", obj.obs);
                sql.Parameters.AddWithValue("@contato", obj.contato);
                sql.Parameters.AddWithValue("@fonecontato", obj.fonecontato);
                sql.Parameters.AddWithValue("@ramalcontato", obj.ramalcontato);
                sql.Parameters.AddWithValue("@celcontato", obj.celcontato);
                sql.Parameters.AddWithValue("@emailcontato", obj.emailcontato);
                sql.Parameters.AddWithValue("@contato2", obj.contato2);
                sql.Parameters.AddWithValue("@fonecontato2", obj.fonecontato2);
                sql.Parameters.AddWithValue("@ramalcontato2", obj.ramalcontato2);
                sql.Parameters.AddWithValue("@celcontato2", obj.celcontato2);
                sql.Parameters.AddWithValue("@emailcontato2", obj.emailcontato2);
                sql.Parameters.AddWithValue("@entrega", obj.entrega);
                sql.Parameters.AddWithValue("@dtcadastro", SqlDbType.Date).Value = Convert.ToDateTime(obj.dtcadastro).ToString("yyyy/MM/dd");
                sql.Parameters.AddWithValue("@idempresa", obj.idempresa);
                sql.Parameters.AddWithValue("@idusu", obj.idusu);
                sql.Parameters.AddWithValue("@estado", obj.estado);
                sql.Parameters.AddWithValue("@statuscli", obj.statuscli);
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
                string delete = "Delete From Cliente Where idcliente=" + cod + "";
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
