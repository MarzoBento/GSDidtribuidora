
using Microsoft.Reporting.Map.WebForms.BingMaps;
using Microsoft.Reporting.WinForms;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Warning = Microsoft.Reporting.WinForms.Warning;

namespace Prj_Cientifica
{
    public class ServicoRelatorioCotacao
    {
        private int CodigoDoFornecedor;
        private int CodigoDaLicitacao;
        private ReportViewer relatorio;

        private string nomefor;
        private string nomecliente;
        private string uf;
        private string modalidade;
        private string pregao;
        private string processo;
        private string codlic;
        private string dtabertura;
        private string prazo;
        private int codfor;
        private string vigencia;
        private string idedital;
        private string validade;
        private string analista;
        public string email;

        /// <summary>
        /// Construtor
        /// </summary>
        /// <param name="CodigoDoFornecedor"></param>
        /// <param name="CodigoDaLicitacao"></param>
        /// <param name="relatorio"></param>
        public ServicoRelatorioCotacao(int CodigoDoFornecedor, int CodigoDaLicitacao, ReportViewer relatorio)
        {
            this.CodigoDoFornecedor = CodigoDoFornecedor;
            this.CodigoDaLicitacao = CodigoDaLicitacao;
            this.relatorio = relatorio;
        }

        /// <summary>
        /// Obtenha a consulta
        /// </summary>
        /// <returns></returns>
        private string ObtenhaSqlParaConsulta()
        {
            return "Select DISTINCT Modalidade.nome as Modalidade,LancEditais.dtabertura as DtAbertura,LancEditais.vigcontratoata as Vigencia, LancEditais.vlproposta as Vlproposta,LancEditais.prazo as Prazo, Usuarios.nome as Analista, Fornecedor.nome as Fornecedor," +
              "Cliente.nome as Cliente,Cidade.uf as Uf,LancEditais.nprocesso as Processo,LancEditais.idedital as Edital,LancEditais.nlicitacao as Pregao,Fornecedor.email as Email" +
             " From Fornecedor,LancEditais,Cliente,Cidade,Modalidade,usuarios  Where  Cliente.idcliente = LancEditais.idcliente AND Cliente.idcidade= Cidade.idcidade AND  Modalidade.idmodalidade = LancEditais.idmodalidade AND Usuarios.idusu = LancEditais.idusu  AND " +
             "Fornecedor.idfornecedor=" + this.CodigoDoFornecedor + "  AND LancEditais.idedital=" + this.CodigoDaLicitacao + "";

        }

        public void PreparaRelatorioComOsParametros()
        {


            DataTable ds = new DataTable();
            SqlConnection Conn = Banco.CriarConexao();
            Conn.Open();

            if (Conn.State == ConnectionState.Open)
            {
                SqlCommand cmd = new SqlCommand(ObtenhaSqlParaConsulta(), Conn);
                SqlDataReader dr = cmd.ExecuteReader();
                if (dr.Read())
                {
                    nomefor = dr["Fornecedor"].ToString();
                    nomecliente = dr["Cliente"].ToString();
                    uf = dr["Uf"].ToString();
                    modalidade = dr["Modalidade"].ToString();
                    processo = dr["Processo"].ToString();
                    DateTime DtP = Convert.ToDateTime(dr["DtAbertura"].ToString());
                    dtabertura = DtP.ToString("dd/MM/yyyy");
                    validade = dr["Vlproposta"].ToString();
                    prazo = dr["Prazo"].ToString();
                    vigencia = dr["Vigencia"].ToString();
                    idedital = dr["Edital"].ToString();
                    analista = dr["Analista"].ToString();
                    pregao = dr["Pregao"].ToString();
                    email = dr["Email"].ToString();

                }
            }

            ReportParameter[] parameters = new ReportParameter[12];
            {
                parameters[0] = new ReportParameter("Fornecedor", nomefor);
                parameters[1] = new ReportParameter("Cliente", nomecliente);
                parameters[2] = new ReportParameter("Uf", uf);
                parameters[3] = new ReportParameter("Modalidade", modalidade);
                parameters[4] = new ReportParameter("Pregao", pregao);
                parameters[5] = new ReportParameter("Processo", processo);
                parameters[6] = new ReportParameter("Dtabertura", dtabertura);
                parameters[7] = new ReportParameter("Dtvalidade", validade);
                parameters[8] = new ReportParameter("Prazo", prazo);
                parameters[9] = new ReportParameter("Vigencia", vigencia);
                parameters[10] = new ReportParameter("idedital", idedital);
                parameters[11] = new ReportParameter("usuario", analista);

            };


            ReportDataSource reportDataSource1 = new ReportDataSource();

            reportDataSource1.Name = "DtCotacaoEmail";
            reportDataSource1.Value = Cotacao_Email();

            this.relatorio.LocalReport.DataSources.Add(reportDataSource1);




            this.relatorio.LocalReport.ReportEmbeddedResource = "Prj_Cientifica.RptCotacaoEmail.rdlc";
            this.relatorio.Name = "reportViewerServer";
           // this.relatorio.LocalReport.SetParameters(parameters);


        }

        private DataTable Cotacao_Email()
        {
            DataTable Dt = new DataTable();
            SqlConnection Cnn = Banco.CriarConexao();
            SqlCommand cmd = new SqlCommand("Select * from View_Cotacao_Email WHERE idfornecedor=" + CodigoDoFornecedor + " AND idedital=" + CodigoDaLicitacao, Cnn);
            Cnn.Open();
            SqlDataReader rd = cmd.ExecuteReader();
            Dt.Load(rd);
            return Dt;

        }



      
        



    }
}
