using Microsoft.Reporting.WinForms;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Prj_Cientifica
{
    public partial class RelEmpenho : Form
    {
        public string edital;
        public string razao;
        public string empenho;
        public string notafiscal;
        public string dtrecebimento;
        public string dtlimite;
        public int idedital;
        public string nf;


        public RelEmpenho()
        {
            InitializeComponent();
        }

        public RelEmpenho(ViewEmpenho frm) : this()
        {

            idedital = Convert.ToInt32(frm.editalrel);
            empenho = frm.numeroempenho;
            nf = frm.notafiscal;



        }



        private void RelEmpenho_Load(object sender, EventArgs e)
        {


            string reg = "Select * From  View_Empenho Where idedital =" + idedital + " AND nempenho='" + empenho + "'";

            DataTable ds = new DataTable();
            SqlConnection Conn = Banco.CriarConexao();
            Conn.Open();

            if (Conn.State == ConnectionState.Open)
            {
                SqlCommand cmd = new SqlCommand(reg, Conn);
                SqlDataReader dr = cmd.ExecuteReader();
                if (dr.Read())
                {

                    edital = dr["edital"].ToString();
                    razao = dr["razao"].ToString();
                    empenho = dr["nempenho"].ToString();
                    notafiscal = dr["notafiscal"].ToString();
                    DateTime DtREC = Convert.ToDateTime(dr["dtrecimento"].ToString());
                    dtrecebimento = DtREC.ToString("dd/MM/yyyy");
                    DateTime DtLIM = Convert.ToDateTime(dr["dtlimite"].ToString());
                    dtlimite = DtLIM.ToString("dd/MM/yyyy");
                    idedital =Convert.ToInt32(dr["idedital"].ToString());



                }
            }

            ReportParameter[] parameters = new ReportParameter[6];
            {

                parameters[0] = new ReportParameter("edital", edital);
                parameters[1] = new ReportParameter("razao", razao);
                parameters[2] = new ReportParameter("empenho", empenho);
                parameters[3] = new ReportParameter("notafiscal", nf);
                parameters[4] = new ReportParameter("dtrecebimento", dtrecebimento);
                parameters[5] = new ReportParameter("dtlimite", dtlimite);
               



            };
            reportViewer1.LocalReport.SetParameters(parameters);


            this.DtEmpenho.EnforceConstraints = false;

            this.View_EmpenhoTableAdapter.Fill(this.DtEmpenho.View_Empenho);

            this.View_EmpenhoTableAdapter.FillBy(this.DtEmpenho.View_Empenho, idedital,empenho, nf);

            this.reportViewer1.RefreshReport();

        }

        private void reportViewer1_Load(object sender, EventArgs e)
        {

        }
    }
}
