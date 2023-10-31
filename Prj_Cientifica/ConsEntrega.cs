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
    public partial class ConsEntrega : Form
    {
        public ConsEntrega()
        {
            InitializeComponent();
        }

        public string codempenho;
        public int idedital;
        private void carregarGridNumeroEmpenho()
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
                string strConn = "Select Empenho.idempenho as Codigo, Empenho.nempenho as NºEmpenho,Empenho.edital as Edital,Cliente.nome as Cliente,Empenho.idedital as Nº_Edital" +
                " FROM Empenho, Cliente,LancEditais Where Empenho.idedital = LancEditais.idedital AND LancEditais.idcliente = Cliente.idcliente AND Empenho.idedital Like'%" + txtpesquisa.Text + "%' Order by Cliente.nome";
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
            DtGConsulta.Columns.Add("NºEmpenho", "NºEmpenho");
            DtGConsulta.Columns.Add("Edital", "Edital");
            DtGConsulta.Columns.Add("Cliente", "Cliente");
            DtGConsulta.Columns.Add("Nº_Edital", "Nº_Edital");
            DtGConsulta.Columns[0].Visible = false;
            DtGConsulta.Columns[1].Width = 120;
            DtGConsulta.Columns[2].Width = 120;
            DtGConsulta.Columns[3].Width = 760;
            DtGConsulta.Columns[4].Width = 95;

            DtGConsulta.Columns[4].DefaultCellStyle.Alignment = DataGridViewContentAlignment.TopCenter;

            DtGConsulta.Columns[0].DataPropertyName = "Codigo";
            DtGConsulta.Columns[1].DataPropertyName = "NºEmpenho";
            DtGConsulta.Columns[2].DataPropertyName = "Edital";
            DtGConsulta.Columns[3].DataPropertyName = "Cliente";
            DtGConsulta.Columns[4].DataPropertyName = "Nº_Edital";


            DtGConsulta.Refresh();

        }

        private void btnPesqNumero_Click(object sender, EventArgs e)
        {
           
        }
        private void carregarGridPorData()
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

                if (ValidaCamposData() == true)
                {


                    string dtini = Convert.ToDateTime(mskini.Text).ToString("yyyy-MM-dd");
                    string dtfim = Convert.ToDateTime(mskfim.Text).ToString("yyyy-MM-dd");



                    string strConn = "Select Empenho.idempenho as Codigo, Empenho.nempenho as NºEmpenho,Empenho.edital as Edital,Cliente.nome as Cliente,Empenho.idedital" +
                    " FROM Empenho, Cliente,LancEditais Where Empenho.idedital = LancEditais.idedital AND LancEditais.idcliente = Cliente.idcliente AND Empenho.dtrecimento BETWEEN '" + dtini + "' AND '" + dtfim + "' Order by Cliente.nome";
                    SqlDataAdapter da = new SqlDataAdapter(strConn, Conn);
                    da.Fill(ds);

                }


            }

            this.DtGConsulta.RowsDefaultCellStyle.BackColor = Color.LightBlue;
            this.DtGConsulta.AlternatingRowsDefaultCellStyle.BackColor = Color.Azure;



            DtGConsulta.AutoGenerateColumns = false;
            //exibe os dados no datagridview
            DtGConsulta.DataSource = ds;
            DtGConsulta.Columns.Clear();
            DtGConsulta.Columns.Add("Codigo", "Codigo");
            DtGConsulta.Columns.Add("NºEmpenho", "NºEmpenho");
            DtGConsulta.Columns.Add("Edital", "Edital");
            DtGConsulta.Columns.Add("Cliente", "Cliente");
            DtGConsulta.Columns.Add("Nº_Edital", "Nº_Edital");
            DtGConsulta.Columns[0].Visible = false;
            DtGConsulta.Columns[1].Width = 120;
            DtGConsulta.Columns[2].Width = 120;
            DtGConsulta.Columns[3].Width = 760;
            DtGConsulta.Columns[4].Width = 95;

            DtGConsulta.Columns[4].DefaultCellStyle.Alignment = DataGridViewContentAlignment.TopCenter;

            DtGConsulta.Columns[0].DataPropertyName = "Codigo";
            DtGConsulta.Columns[1].DataPropertyName = "NºEmpenho";
            DtGConsulta.Columns[2].DataPropertyName = "Edital";
            DtGConsulta.Columns[3].DataPropertyName = "Cliente";
            DtGConsulta.Columns[4].DataPropertyName = "Nº_Edital";

            DtGConsulta.Refresh();

        }

        private Boolean ValidaCamposData()
        {


            if (this.mskini.Text == "  /  /")
            {
                MessageBox.Show("informe a Data Inicial!");
                mskini.Focus();
                return false;

            }

            if (this.mskfim.Text == "  /  /")
            {
                MessageBox.Show("informe a data Final!");
                mskfim.Focus();
                return false;

            }


            return true;


        }

        private void btnPesqData_Click(object sender, EventArgs e)
        {
            carregarGridPorData();
        }

        private void txtpesquisa_KeyPress(object sender, KeyPressEventArgs e)
        {
            
        }

        private void mskini_KeyPress(object sender, KeyPressEventArgs e)
        {
            if ((Keys)e.KeyChar == Keys.Enter)
            {
                this.mskfim.Focus();
            }
        }

        private void mskfim_KeyPress(object sender, KeyPressEventArgs e)
        {
            if ((Keys)e.KeyChar == Keys.Enter)
            {
                this.btnPesqData.Focus();
            }
        }

        private void DtGConsulta_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            codempenho = Convert.ToString(DtGConsulta[1, e.RowIndex].Value.ToString());
            idedital = Convert.ToInt32(DtGConsulta[4, e.RowIndex].Value.ToString());
            ViewEntrega frm = new ViewEntrega(this);
            frm.Show();
            this.Close();
        }

        private void BtnSair_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void txtpesquisa_TextChanged(object sender, EventArgs e)
        {
            carregarGridNumeroEmpenho();
        }
    }
}
