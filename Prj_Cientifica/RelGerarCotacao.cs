using Microsoft.Reporting.WinForms;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Drawing.Printing;
using System.IO;
using System.Linq;
using System.Net.Mail;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;


namespace Prj_Cientifica
{
    
    public partial class RelGerarCotacao : Form
    {
        private Font printFont;
        private StreamReader streamToPrint;
        public string nomefor;
        public string nomecliente;
        public string uf;
        public string modalidade;
        public string pregao;
        public string processo;
        public int codlic;
        public string dtabertura;
        public string prazo;
        public int codfor;
        public string vigencia;
        public string idedital;
        public string validade;
        public string analista;


        public RelGerarCotacao(ViewGerarCotacao frm) : this()
        {
            codfor = frm.codfor;
            codlic =  Convert.ToInt32(frm.codlic);

        }

        public RelGerarCotacao()
        {
            InitializeComponent();
        }

     

        private void RelGerarCotacao_Load(object sender, EventArgs e)
        {

            string reg = "Select DISTINCT Modalidade.nome as Modalidade,LancEditais.dtabertura as DtAbertura,LancEditais.vigcontratoata as Vigencia, LancEditais.vlproposta as Vlproposta,LancEditais.prazo as Prazo, Usuarios.nome as Analista, Fornecedor.nome as Fornecedor," +
                "Cliente.nome as Cliente,Cidade.uf as Uf,LancEditais.nprocesso as Processo,LancEditais.idedital as Edital,LancEditais.nlicitacao as Pregao" +
               " From Fornecedor,LancEditais,Cliente,Cidade,Modalidade,usuarios  Where  Cliente.idcliente = LancEditais.idcliente AND Cliente.idcidade= Cidade.idcidade AND  Modalidade.idmodalidade = LancEditais.idmodalidade AND Usuarios.idusu = LancEditais.idusu  AND " +
               "Fornecedor.idfornecedor=" + codfor + "  AND LancEditais.idedital='" + codlic + "'";



            DataTable ds = new DataTable();
            SqlConnection Conn = Banco.CriarConexao();
            Conn.Open();

            if (Conn.State == ConnectionState.Open)
            {
                SqlCommand cmd = new SqlCommand(reg, Conn);
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
            reportViewer1.LocalReport.SetParameters(parameters);


            this.DtGerarCotacao.EnforceConstraints = false;
            this.View_GerarCotacaoTableAdapter.Fill(this.DtGerarCotacao.View_GerarCotacao);

            this.View_GerarCotacaoTableAdapter.FillBy(this.DtGerarCotacao.View_GerarCotacao, codfor,codlic);
            this.reportViewer1.RefreshReport();


            this.reportViewer1.RefreshReport();
           // SendMail(reportViewer1);

        }

        //private void SendMail(ReportViewer reportViewer1)
        //{
        //    Warning[] warnings;
        //    string[] streamids;
        //    string mimeType;
        //    string encoding;
        //    string extension;

        //    byte[] bytes = reportViewer1.LocalReport.Render
        //("PDF", null, out mimeType, out encoding, out extension, out
        //streamids, out warnings);

        //    MemoryStream memoryStream = new MemoryStream(bytes);
        //    memoryStream.Seek(0, SeekOrigin.Begin);

        //    MailMessage message = new MailMessage();
        //    Attachment attachment = new Attachment(memoryStream, "RptRetornoFornecedor.pdf");
        //    message.Attachments.Add(attachment);

        //    message.From = new MailAddress("mzbento@gmail.com");
        //    message.To.Add("mzbento@gmail.com");

        //    message.CC.Add("j.augustocoelho@gmail.com");

        //    message.Subject = "Business Report";
        //    message.IsBodyHtml = true;

        //    message.Body = "Please find Attached Report herewith.";


        //    if (ConfigurationManager.AppSettings["SendMail"].ToString() == "Y")
        //    {
        //        SmtpClient smtp = new SmtpClient("SMTP Server Name");
        //        smtp.Send(message);
        //    }
        //    else
        //    {
        //        //This is for testing.
        //        SmtpClient smtp = new SmtpClient();
        //        smtp.Send(message);
        //    }

        //    memoryStream.Close();
        //    memoryStream.Dispose();
        //}
    }
}


