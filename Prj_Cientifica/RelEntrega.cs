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
    public partial class RelEntrega : Form
    {

        public string edital;
        public string razao;
        public string empenho;
        public string notafiscal;
        public string dtrecebimento;
        public string dtlimite;
        public int idedital;
        public int statusimpressao;
        public string nfsaida;

        public RelEntrega()
        {
            InitializeComponent();
        }

        public RelEntrega(ViewEntrega frm) : this()
        {

            idedital = Convert.ToInt32(frm.editalrel);
            empenho = frm.numeroempenho;
            nfsaida = frm.nfsaida;
            statusimpressao = frm.statusimpressao;


        }

        private void RelEntrega_Load(object sender, EventArgs e)
        {

            string reg = "Select * From  View_Entrega Where idedital =" + idedital + " AND nempenho='" + empenho + "'";

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
                    notafiscal = dr["nfsaida"].ToString();
                    DateTime DtREC = Convert.ToDateTime(dr["dtrecimento"].ToString());
                    dtrecebimento = DtREC.ToString("dd/MM/yyyy");
                    DateTime DtLIM = Convert.ToDateTime(dr["dtlimite"].ToString());
                    dtlimite = DtLIM.ToString("dd/MM/yyyy");



                }
            }

            ReportParameter[] parameters = new ReportParameter[6];
            {

                parameters[0] = new ReportParameter("edital", edital);
                parameters[1] = new ReportParameter("razao", razao);
                parameters[2] = new ReportParameter("empenho", empenho);
                parameters[3] = new ReportParameter("notafiscal", notafiscal);
                parameters[4] = new ReportParameter("dtrecebimento", dtrecebimento);
                parameters[5] = new ReportParameter("dtlimite", dtlimite);




            };
            reportViewer1.LocalReport.SetParameters(parameters);


            this.DtEntrega.EnforceConstraints = false;

            this.View_EntregaTableAdapter.Fill(this.DtEntrega.View_Entrega);

            if (statusimpressao == 1)
            {

                this.View_EntregaTableAdapter.FillBy(this.DtEntrega.View_Entrega, empenho, idedital);
            }
            else if (statusimpressao == 2)
            {
                this.View_EntregaTableAdapter.FillBy1(this.DtEntrega.View_Entrega, empenho, idedital, nfsaida);

            }

                this.reportViewer1.RefreshReport();


        }
    }
}
