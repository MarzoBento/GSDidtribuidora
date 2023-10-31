using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Prj_Cientifica
{
    public class PsUsuario
    {

        public void Incluir(VlUsuario obj)
        {
            try
            {

                SqlConnection Cnn = Banco.CriarConexao();
                string inserir = ("Insert into usuarios values(@nome,@email,@login,@senha,@status,@dados)");
                SqlCommand sql = new SqlCommand(inserir, Cnn);
                sql.Parameters.AddWithValue("@nome", obj.nome);
                sql.Parameters.AddWithValue("@email", obj.email);
                sql.Parameters.AddWithValue("@login", obj.login);
                sql.Parameters.AddWithValue("@senha", obj.senha);
                sql.Parameters.AddWithValue("@status", obj.status);
                sql.Parameters.AddWithValue("@dados", obj.dados);
                Cnn.Open();
                sql.ExecuteNonQuery();
                Cnn.Close();

            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }

        }

        public void Alterar(VlUsuario obj)
        {
            try
            {
                SqlConnection Cnn = Banco.CriarConexao();
                string alterar = "Update usuarios set nome=@nome,email=@email,login=@login,senha=@senha,status=@status,dados=@dados Where idusu=@idusu";
                SqlCommand sql = new SqlCommand(alterar, Cnn);
                sql.Parameters.AddWithValue("@idusu", obj.idusu);
                sql.Parameters.AddWithValue("@nome", obj.nome);
                sql.Parameters.AddWithValue("@email", obj.email);
                sql.Parameters.AddWithValue("@login", obj.login);
                sql.Parameters.AddWithValue("@senha", obj.senha);
                sql.Parameters.AddWithValue("@status", obj.status);
                sql.Parameters.AddWithValue("@dados", obj.dados);
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
                string delete = "Delete From usuarios Where idusu=" + cod + "";
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
