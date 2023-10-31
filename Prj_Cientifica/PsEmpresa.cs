using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Prj_Cientifica
{
   public class PsEmpresa
    {

        public void Incluir(VlEmpresa obj)
        {
            try
            {

                SqlConnection Cnn = Banco.CriarConexao();
                string inserir = ("Insert into Empresa values(@nome,@cpfcnpj,@inscestadual,@endereco,@bairro,@cep,@idcidade,@fone,@ramal,@celular,@contato,@fax,@email,@data)");
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
                sql.Parameters.AddWithValue("@data", SqlDbType.Date).Value = Convert.ToDateTime(obj.data).ToString("yyyy/MM/dd");
                Cnn.Open();
                sql.ExecuteNonQuery();
                Cnn.Close();

            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }

        }

        public void Alterar(VlEmpresa obj)
        {
            try
            {
                SqlConnection Cnn = Banco.CriarConexao();
                string alterar = "Update Empresa set nome=@nome,cpfcnpj=@cpfcnpj,inscestadual=@inscestadual,endereco=@endereco,bairro=@bairro,cep=@cep,idcidade=@idcidade,fone=@fone,ramal=@ramal," +
                    "celular=@celular,contato=@contato,fax=@fax,email=@email,data=@data Where idempresa=@idempresa";
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
                sql.Parameters.AddWithValue("@data", SqlDbType.Date).Value = Convert.ToDateTime(obj.data).ToString("yyyy/MM/dd");
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
                string delete = "Delete From Empresa Where idempresa=" + cod + "";
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
