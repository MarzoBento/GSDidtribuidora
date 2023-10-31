using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Prj_Cientifica
{
  public  class PsEmpLicitacao
    {
        public void Incluir(VlEmpLicitacao obj)
        {
            try
            {

                SqlConnection Cnn = Banco.CriarConexao();
                string inserir = ("Insert into EmpresaLicitacao values(@nome,@cpfcnpj,@inscestadual,@endereco,@bairro,@cep,@idcidade,@fone,@ramal,@celular,@contato,@fax,@email," +
                 "@nomefantasia,@site,@responsavel,@cpfresp,@rgresp,@data,@tipo,@idusu)");
                SqlCommand sql = new SqlCommand(inserir, Cnn);
                sql.Parameters.AddWithValue("@nome", obj.nome);
                sql.Parameters.AddWithValue("@cpfcnpj", obj.cpfcnpj);
                sql.Parameters.AddWithValue("@inscestadual", obj.inscestadual);
                sql.Parameters.AddWithValue("@endereco", obj.endereco);
                sql.Parameters.AddWithValue("@bairro", obj.bairro);
                sql.Parameters.AddWithValue("@cep", obj.cep);
                sql.Parameters.AddWithValue("@idcidade", obj.idcidade);
                sql.Parameters.AddWithValue("@fone", obj.fone);
                sql.Parameters.AddWithValue("@ramal", obj.ramal);
                sql.Parameters.AddWithValue("@celular", obj.celular);
                sql.Parameters.AddWithValue("@contato", obj.contato);
                sql.Parameters.AddWithValue("@fax", obj.fax);
                sql.Parameters.AddWithValue("@email", obj.email);
                sql.Parameters.AddWithValue("@nomefantasia", obj.nomefantasia);
                sql.Parameters.AddWithValue("@site", obj.site);
                sql.Parameters.AddWithValue("@responsavel", obj.responsavel);
                sql.Parameters.AddWithValue("@cpfresp", obj.cpfresp);
                sql.Parameters.AddWithValue("@rgresp", obj.rgresp);
                sql.Parameters.AddWithValue("@data", SqlDbType.Date).Value = Convert.ToDateTime(obj.data).ToString("yyyy/MM/dd");
                sql.Parameters.AddWithValue("@tipo", obj.tipo);
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

        public void Alterar(VlEmpLicitacao obj)
        {
            try
            {
                SqlConnection Cnn = Banco.CriarConexao();
                string alterar = "Update EmpresaLicitacao set nome=@nome,cpfcnpj=@cpfcnpj,inscestadual=@inscestadual,endereco=@endereco,bairro=@bairro,cep=@cep,idcidade=@idcidade,fone=@fone,ramal=@ramal," +
                    "celular=@celular,contato=@contato,fax=@fax,email=@email,nomefantasia=@nomefantasia,site=@site,responsavel=@responsavel,rgresp=@rgresp,cpfresp=@cpfresp,data=@data,tipo=@tipo,idusu=@idusu Where idempresa=@idempresa";
                SqlCommand sql = new SqlCommand(alterar, Cnn);
                sql.Parameters.AddWithValue("@idempresa", obj.idempresa);
                sql.Parameters.AddWithValue("@nome", obj.nome);
                sql.Parameters.AddWithValue("@cpfcnpj", obj.cpfcnpj);
                sql.Parameters.AddWithValue("@inscestadual", obj.inscestadual);
                sql.Parameters.AddWithValue("@endereco", obj.endereco);
                sql.Parameters.AddWithValue("@bairro", obj.bairro);
                sql.Parameters.AddWithValue("@cep", obj.cep);
                sql.Parameters.AddWithValue("@idcidade", obj.idcidade);
                sql.Parameters.AddWithValue("@fone", obj.fone);
                sql.Parameters.AddWithValue("@ramal", obj.ramal);
                sql.Parameters.AddWithValue("@celular", obj.celular);
                sql.Parameters.AddWithValue("@contato", obj.contato);
                sql.Parameters.AddWithValue("@fax", obj.fax);
                sql.Parameters.AddWithValue("@email", obj.email);
                sql.Parameters.AddWithValue("@nomefantasia", obj.nomefantasia);
                sql.Parameters.AddWithValue("@site", obj.site);
                sql.Parameters.AddWithValue("@responsavel", obj.responsavel);
                sql.Parameters.AddWithValue("@rgresp", obj.rgresp);
                sql.Parameters.AddWithValue("@cpfresp", obj.cpfresp);
                sql.Parameters.AddWithValue("@data", SqlDbType.Date).Value = Convert.ToDateTime(obj.data).ToString("yyyy/MM/dd");
                sql.Parameters.AddWithValue("@tipo", obj.tipo);
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
                string delete = "Delete From EmpresaLicitacao Where idempresa=" + cod + "";
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
