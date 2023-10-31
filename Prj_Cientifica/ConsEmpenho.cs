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
    public partial class ConsEmpenho : Form
    {
        public ConsEmpenho()
        {
            InitializeComponent();
        }




        public int codempenho;
        public int idedital;
        public string Edital;
        string strConn;
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
                if (chkedital.Checked == true)
                {

                     strConn = "Select DISTINCT Empenho.idempenho as Codigo, Empenho.nempenho as NºEmpenho,Empenho.edital as Edital,Cliente.nome as Cliente,Empenho.idedital as NrEdital " +
                     " FROM Empenho, Cliente,LancEditais Where Empenho.idedital = LancEditais.idedital AND LancEditais.idcliente = Cliente.idcliente AND Empenho.idedital Like'%" + txtpesquisa.Text + "'";
                }
                else if (this.chkCliente.Checked == true)
                {
                    strConn = "Select DISTINCT Empenho.idempenho as Codigo, Empenho.nempenho as NºEmpenho,Empenho.edital as Edital,Cliente.nome as Cliente,Empenho.idedital as NrEdital " +
                    " FROM Empenho, Cliente,LancEditais Where Empenho.idedital = LancEditais.idedital AND LancEditais.idcliente = Cliente.idcliente AND Cliente.nome Like'%" + txtpesquisa.Text + "%' Order by Cliente.nome asc";

                }


               
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
            DtGConsulta.Columns.Add("NrEdital", "NrEdital");
            DtGConsulta.Columns[0].Visible = false;
            DtGConsulta.Columns[1].Width = 120;
            DtGConsulta.Columns[2].Width = 140;
            DtGConsulta.Columns[3].Width = 600;
            DtGConsulta.Columns[4].Width = 83;


            DtGConsulta.Columns[4].DefaultCellStyle.Alignment = DataGridViewContentAlignment.TopCenter;

            DtGConsulta.Columns[0].DataPropertyName = "Codigo";
            DtGConsulta.Columns[1].DataPropertyName = "NºEmpenho";
            DtGConsulta.Columns[2].DataPropertyName = "Edital";
            DtGConsulta.Columns[3].DataPropertyName = "Cliente";
            DtGConsulta.Columns[4].DataPropertyName = "NrEdital";

            DtGConsulta.Refresh();

        }

        private void btnPesqNumero_Click(object sender, EventArgs e)
        {
          
        }

        private void btnPesqData_Click(object sender, EventArgs e)
        {
            carregarGridPorData();
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



                    string strConn = "Select DISTINCT Empenho.idempenho as Codigo, Empenho.nempenho as NºEmpenho,Empenho.edital as Edital,Cliente.nome as Cliente,Empenho.idedital as NrEdital" +
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
            DtGConsulta.Columns.Add("NrEdital", "NrEdital");
            DtGConsulta.Columns[0].Visible = false;
            DtGConsulta.Columns[1].Width = 120;
            DtGConsulta.Columns[2].Width = 140;
            DtGConsulta.Columns[3].Width = 600;
            DtGConsulta.Columns[4].Width = 60;

            DtGConsulta.Columns[0].DataPropertyName = "Codigo";
            DtGConsulta.Columns[1].DataPropertyName = "NºEmpenho";
            DtGConsulta.Columns[2].DataPropertyName = "Edital";
            DtGConsulta.Columns[3].DataPropertyName = "Cliente";
            DtGConsulta.Columns[4].DataPropertyName = "NrEdital";


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

        private void txtpesquisa_KeyPress(object sender, KeyPressEventArgs e)
        {
            //if ((Keys)e.KeyChar == Keys.Enter)
            //{
            //    this.btnPesqNumero.Focus();
            //}
        }

        private void DtGConsulta_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            codempenho = Convert.ToInt32(DtGConsulta[0, e.RowIndex].Value.ToString());
            idedital = Convert.ToInt32(DtGConsulta[4, e.RowIndex].Value.ToString());
            Edital = Convert.ToString(DtGConsulta[2, e.RowIndex].Value.ToString());
            ViewEmpenho frm = new ViewEmpenho(this);
            frm.Show();
            this.Close();
        }

        private void txtpesquisa_TextChanged(object sender, EventArgs e)
        {
            carregarGridNumeroEmpenho();
        }

        private void BtnSair_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void ConsEmpenho_Load(object sender, EventArgs e)
        {
            chkedital.Checked = true;
        }
    }
}





