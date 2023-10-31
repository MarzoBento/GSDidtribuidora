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
    public partial class ConsPrincipio : Form
    {
        public ConsPrincipio()
        {
            InitializeComponent();
        }


        string nomeform;

        public ConsPrincipio(ViewLancamentoEditais frma) : this()
        {
            nomeform = Convert.ToString(frma.nomeform);

        }

        public int codprincipio;
        public Int32 cod;
        private void carregarGrid()
        {
            DataTable ds = new DataTable();
            SqlConnection Conn = Banco.CriarConexao();
            try
            {
                Conn.Open();
            }

            catch (System.Exception e)
            {
                throw e;
            }


            if (Conn.State == ConnectionState.Open)
            {
                string strConn = "Select idprincipio as Codigo, nome as Correlatos" +
                " from PrincipioAtivo Where nome  Like'" + txtpesquisa.Text + "%' Order by nome";
                SqlDataAdapter da = new SqlDataAdapter(strConn, Conn);
                da.Fill(ds);


            }

            this.DtGConsulta.RowsDefaultCellStyle.BackColor = Color.LightBlue;
            this.DtGConsulta.AlternatingRowsDefaultCellStyle.BackColor = Color.Azure;



            DtGConsulta.AutoGenerateColumns = false;
            //exibe os dados no datagridview
            DtGConsulta.DataSource = ds;
            DtGConsulta.Columns.Clear();
            DtGConsulta.Columns.Add("Codigo", "Codigo");
            DtGConsulta.Columns.Add("Correlatos", "Correlatos");
            DtGConsulta.Columns[0].Width = 80;
            DtGConsulta.Columns[1].Width = 530;
            DtGConsulta.Columns[0].DataPropertyName = "Codigo";
            DtGConsulta.Columns[1].DataPropertyName = "Correlatos";
            DtGConsulta.Refresh();

        }


        private void ConsPrincipio_Load(object sender, EventArgs e)
        {

        }

        private void DtGConsulta_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {


            if (nomeform == "ViewLancamentoEditais")
            {
                cod = Convert.ToInt32(DtGConsulta[0, e.RowIndex].Value.ToString());
                ViewLancamentoEditais frm = new ViewLancamentoEditais(this);
                frm.Show();
                frm.Close();
              
              
              


            }
            else
            {
                codprincipio = Convert.ToInt32(DtGConsulta[0, e.RowIndex].Value.ToString());
                ViewPrincipioAtivo frcont = new ViewPrincipioAtivo(this);
                frcont.Show();
                this.Close();
            }
        }

        private void BtnLimpar_Click(object sender, EventArgs e)
        {
            txtpesquisa.Text = "";
            DtGConsulta.DataSource = null;
            DtGConsulta.Refresh();
        }

        private void BtnSair_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void txtpesquisa_TextChanged(object sender, EventArgs e)
        {
            carregarGrid();
        }
    }
}
