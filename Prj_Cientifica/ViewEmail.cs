using Microsoft.Reporting.Map.WebForms.BingMaps;
using Microsoft.Reporting.WinForms;
using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Net.Mail;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Warning = Microsoft.Reporting.WinForms.Warning;
using DocumentFormat.OpenXml.Packaging;
using DocumentFormat.OpenXml.Wordprocessing;
using System.Xml;
using System.Xml.Linq;

namespace Prj_Cientifica
{
    public partial class ViewEmail : Form
    {
    

        public int codfornecedor;
        public int codlicitacao;
        ReportViewer relatorio;

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
        /// Um array lista contento todos os anexos
        /// </summary>
        ArrayList aAnexosEmail;

        /// <summary>
        /// O construtor padrão
        /// </summary>


        public ViewEmail()
        {
            InitializeComponent();
        }

     


        public ViewEmail(ViewGerarCotacao frm) : this()
        {

            relatorio = frm.relatorio;
            codfornecedor = frm.codfor;
            codlicitacao = frm.UltimoSelecionado;

            ObtenhaSqlParaConsulta();


        }



        private void ObtenhaSqlParaConsulta()
        {
            string reg = "Select DISTINCT Modalidade.nome as Modalidade,LancEditais.dtabertura as DtAbertura,LancEditais.vigcontratoata as Vigencia, LancEditais.vlproposta as Vlproposta,LancEditais.prazo as Prazo, Usuarios.nome as Analista, Fornecedor.nome as Fornecedor," +
              "Cliente.nome as Cliente,Cidade.uf as Uf,LancEditais.nprocesso as Processo,LancEditais.idedital as Edital,LancEditais.nlicitacao as Pregao,Fornecedor.email as Email" +
             " From Fornecedor,LancEditais,Cliente,Cidade,Modalidade,usuarios  Where  Cliente.idcliente = LancEditais.idcliente AND Cliente.idcidade= Cidade.idcidade AND  Modalidade.idmodalidade = LancEditais.idmodalidade AND Usuarios.idusu = LancEditais.idusu  AND " +
             "Fornecedor.idfornecedor=" + this.codfornecedor + "  AND LancEditais.idedital=" + this.codlicitacao + "";

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
                    email = dr["Email"].ToString();

                }
            }

          


            ReportDataSource reportDataSource1 = new ReportDataSource();

            reportDataSource1.Name = "DtCotacaoEmail";
            reportDataSource1.Value = Cotacao_Email();

            this.relatorio.LocalReport.DataSources.Add(reportDataSource1);




            this.relatorio.LocalReport.ReportEmbeddedResource = "Prj_Cientifica.RptCotacaoEmail.rdlc";
            this.relatorio.Name = "reportViewerServer";
            txtEnviarPara.Text = email;
            txtAssuntoTitulo.Text = "Cotação de Produtos" + " - " + nomefor;
            txtMensagem.Text = "<b>Segue em Anexo os Itens para Cotação<br/>" +
                               "" + analista + "<br/>" +
                               "Analista de Licitações<br/>";
                               
            AnexarArquivo();


        }


        private DataTable Cotacao_Email()
        {
            DataTable Dt = new DataTable();
            SqlConnection Cnn = Banco.CriarConexao();
            SqlCommand cmd = new SqlCommand("Select * from View_Cotacao_Email WHERE idfornecedor=" + codfornecedor + " AND idedital=" + codlicitacao, Cnn);
            Cnn.Open();
            SqlDataReader rd = cmd.ExecuteReader();
            Dt.Load(rd);
            return Dt;

        }

        private void AnexarArquivo()
        {

            Warning[] warnings;
            string[] streamids;
            string mimeType;
            string encoding;
            string filenameExtension;

            byte[] bytes = this.relatorio.LocalReport.Render(
                "EXCEL", null, out mimeType, out encoding, out filenameExtension,
                out streamids, out warnings);


            System.IO.File.WriteAllBytes("C:\\Cotações" + "\\" + "COTAÇÃO" + '-'  + nomefor + '-' + pregao + ".xls", bytes);

            txtAnexos.Text = "C:\\Cotações" + "\\" + "COTAÇÃO" + '-' + nomefor + '-' + pregao + ".xls";





            //  System.Diagnostics.Process.Start("cotacao.pdf");

            // Cria o anexo







            //Adiciona a mensagem



        }


        private void btnanexar_Click(object sender, EventArgs e)
        {
            if (ofd.ShowDialog() == DialogResult.OK)
            {
                try
                {
                    string[] arr = ofd.FileNames;
                    aAnexosEmail = new ArrayList();
                    txtAnexos.Text = string.Empty;
                    aAnexosEmail.AddRange(arr);

                    foreach (string s in aAnexosEmail)
                    {
                        txtAnexos.Text += s + "; ";
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, "Error");
                }
            }

        }

    




        private void btnEnviar_Click(object sender, EventArgs e)
        {
            try
            {
                using (SmtpClient smtp = new SmtpClient())
                {

                    using (MailMessage mail = new MailMessage())
                    {


                        smtp.Host = "smtp.gmail.com";
                        smtp.UseDefaultCredentials = false;
                        smtp.Credentials = new System.Net.NetworkCredential("mzbento@gmail.com", "zapdqexsgcpmmaac");
                        smtp.Port = 587;
                        smtp.EnableSsl =  true;

                        mail.From = new MailAddress(txtEnviadoPor.Text);
                      
                        mail.To.Add(txtEnviarPara.Text);

                        mail.Subject = txtAssuntoTitulo.Text;
                        mail.IsBodyHtml = true;
                        mail.Body = txtMensagem.Text;



                        mail.Body = txtMensagem.Text ;
                        
                        mail.Attachments.Add(new Attachment(txtAnexos.Text));

                        smtp.DeliveryMethod = SmtpDeliveryMethod.Network;

                  

                        smtp.Send(mail);


                    }
                }
                MessageBox.Show("Email Enviado com Sucesso!");

            }
            catch (Exception erro)
            {

                throw erro;
            }



        }

      

        /// <summary>
        /// Sai da aplicação
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnCancelar_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
