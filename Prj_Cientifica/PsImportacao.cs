using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Prj_Cientifica
{
   public class PsImportacao
    {

        public void Incluir(VlImportacao obj)
        {
            try
            {

                SqlConnection Cnn = Banco.CriarConexao();
                string inserir = ("Insert into ItemsImportados values(@lote,@nritem,@descricao,@unidade,@qtde,@processo,@idusu,@status,@edital)");
                SqlCommand sql = new SqlCommand(inserir, Cnn);
                sql.Parameters.AddWithValue("@lote", obj.lote);
                sql.Parameters.AddWithValue("@nritem", obj.nritem);
                sql.Parameters.AddWithValue("@descricao", obj.descricao);
                sql.Parameters.AddWithValue("@unidade", obj.unidade);
                sql.Parameters.AddWithValue("@qtde", obj.qtde);
                sql.Parameters.AddWithValue("@processo", obj.processo);
                sql.Parameters.AddWithValue("@idusu", obj.idusu);
                sql.Parameters.AddWithValue("@status", obj.status);
                sql.Parameters.AddWithValue("@edital", obj.edital);

                Cnn.Open();
                sql.ExecuteNonQuery();
                Cnn.Close();

            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }

        }

        public void Alterar(VlImportacao obj)
        {
            try
            {
                SqlConnection Cnn = Banco.CriarConexao();
                string alterar = "Update ItemsImportados set lote=@lote,nritem=@nritem,descricao=@descricao,unidade=@unidade,qtde=@qtde,processo=@processo,@idusu=@idusu,status=@status,edital=@dital Where iditem=@iditem";
                SqlCommand sql = new SqlCommand(alterar, Cnn);
                sql.Parameters.AddWithValue("@iditem", obj.iditem);
                sql.Parameters.AddWithValue("@lote", obj.lote);
                sql.Parameters.AddWithValue("@nritem", obj.nritem);
                sql.Parameters.AddWithValue("@descricao", obj.descricao);
                sql.Parameters.AddWithValue("@unidade", obj.unidade);
                sql.Parameters.AddWithValue("@qtde", obj.qtde);
                sql.Parameters.AddWithValue("@processo", obj.processo);
                sql.Parameters.AddWithValue("@idusu", obj.idusu);
                sql.Parameters.AddWithValue("@status", obj.status);
                sql.Parameters.AddWithValue("@edital", obj.edital);
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
                string delete = "Delete From ItemsImportados Where iditem=" + cod + "";
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
        public void AlterarStatus(VlImportacao obj)
        {
            try
            {
                SqlConnection Cnn = Banco.CriarConexao();
                string alterar = "Update ItemsImportados set status=@status Where iditem=@iditem";
                SqlCommand sql = new SqlCommand(alterar, Cnn);
                sql.Parameters.AddWithValue("@iditem", obj.iditem);
                sql.Parameters.AddWithValue("@status", obj.status);
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
