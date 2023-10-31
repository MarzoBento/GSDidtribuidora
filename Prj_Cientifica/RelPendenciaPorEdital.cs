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
    public partial class RelPendenciaPorEdital : Form
    {


        public string edital;
        public string cliente;
        public int idedital;

        public RelPendenciaPorEdital()
        {
            InitializeComponent();
        }

        public RelPendenciaPorEdital(ViewPendencias frm) : this()
        {

            edital = Convert.ToString(frm.editalrel);
            idedital = frm.idedital;
           


        }

        private void RelPendenciaPorEdital_Load(object sender, EventArgs e)
        {


            string reg = "Select * from View_Pendencias Where edital = '" + edital + "'";

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
                    cliente = dr["Cliente"].ToString();

                }
            }

            ReportParameter[] parameters = new ReportParameter[2];
            {

                parameters[0] = new ReportParameter("edital", edital);
                parameters[1] = new ReportParameter("Cliente", cliente);


            };
            reportViewer1.LocalReport.SetParameters(parameters);

            this.DtPendenciasPorEdital.EnforceConstraints = false;

            this.View_PendenciasPorEditalTableAdapter.Fill(this.DtPendenciasPorEdital.View_Pendencias);

            this.View_PendenciasPorEditalTableAdapter.FillBy(this.DtPendenciasPorEdital.View_Pendencias, idedital);

            this.reportViewer1.RefreshReport();


          
          
        }




    }
}
