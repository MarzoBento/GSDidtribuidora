﻿using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Prj_Cientifica
{
   public class PsArquivoRealinhamento
    {

        public void Incluir(VlArquivoRealinhamento obj)
        {
            try
            {

                SqlConnection Cnn = Banco.CriarConexao();
                string inserir = ("Insert into DocumentoRealinhamento values(@arq,@nomearq,@idempresa,@edital,@extensao,@dtdocumento,@idusu,@iditemedital,@data,@status,@idedital)");
                SqlCommand sql = new SqlCommand(inserir, Cnn);
                sql.Parameters.AddWithValue("@arq", VlArquivoRealinhamento.arq);
                sql.Parameters.AddWithValue("@nomearq", obj.nomearq);
                sql.Parameters.AddWithValue("@idempresa", obj.idempresa);
                sql.Parameters.AddWithValue("@edital", obj.edital);
                sql.Parameters.AddWithValue("@extensao", obj.extensao);
                sql.Parameters.AddWithValue("@dtdocumento", SqlDbType.Date).Value = Convert.ToDateTime(obj.dtdocumento).ToString("yyyy/MM/dd");
                sql.Parameters.AddWithValue("@idusu", obj.idusu);
                sql.Parameters.AddWithValue("@iditemedital", obj.iditemedital);
                sql.Parameters.AddWithValue("@data", SqlDbType.Date).Value = Convert.ToDateTime(obj.data).ToString("yyyy/MM/dd");
                sql.Parameters.AddWithValue("@status", obj.status);
                sql.Parameters.AddWithValue("@idedital", obj.idedital);
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
                string delete = "Delete From DocumentoRealinhamento Where iddocrealinhamento=" + cod + "";
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
