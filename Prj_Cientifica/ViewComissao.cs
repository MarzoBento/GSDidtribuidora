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
    public partial class ViewComissao : Form
    {

        public string dtini;
        public string dtfim;
        public int codrep;
        public int status;

        public ViewComissao()
        {
            InitializeComponent();
        }


        public int codempenho;
        public int idedital;
        public string Edital;
        string strConn;

        private void carregarGridNomeRepresentante()
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


                     dtini = Convert.ToDateTime(mskini.Text).ToString("yyyy-MM-dd");
                     dtfim = Convert.ToDateTime(mskfim.Text).ToString("yyyy-MM-dd");

                    strConn = "Select DISTINCT Cliente.nome AS Cliente,Representante.nomerep AS Representante,Entrega.preco as Vl_Unit,Entrega.qtde as Qtde,.Entrega.total as Vl_total,Entrega.comissao as Comissão,Entrega.vlcomissao as Vl_Comissão,Representante.idrepresentante as idrepresentante  " +
                    " FROM Entrega, Cliente,Representante,Empenho Where Empenho.idcliente = Cliente.idcliente AND Entrega.idempenho = Empenho.idempenho AND Representante.idrepresentante = Entrega.idrepresentante AND " +
                    "Representante.nomerep Like'%" + txtpesquisa.Text + "' AND  Entrega.dtentrega BETWEEN '" + dtini + "' AND '" + dtfim + "' ";

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
            DtGConsulta.Columns.Add("Cliente", "Cliente");
            DtGConsulta.Columns.Add("Representante", "Representante");
            DtGConsulta.Columns.Add("Vl_Unit", "Vl_Unit");
            DtGConsulta.Columns.Add("Qtde", "Qtde");
            DtGConsulta.Columns.Add("Vl_total", "Vl_total");
            DtGConsulta.Columns.Add("Comissão", "Comissão");
            DtGConsulta.Columns.Add("Vl_Comissão", "Vl_Comissão");
            DtGConsulta.Columns.Add("idrepresentante", "idrepresentante");


            DtGConsulta.Columns[0].Width = 240;
            DtGConsulta.Columns[1].Width = 240;
            DtGConsulta.Columns[2].Width = 80;
            DtGConsulta.Columns[3].Width = 60;
            DtGConsulta.Columns[4].Width = 100;
            DtGConsulta.Columns[5].Width = 78;
            DtGConsulta.Columns[6].Width = 100;
            DtGConsulta.Columns[7].Visible = false;



            DtGConsulta.Columns[3].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            DtGConsulta.Columns[2].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            DtGConsulta.Columns[4].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            DtGConsulta.Columns[6].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;

            DtGConsulta.Columns[4].DefaultCellStyle.Format = "n2";
            DtGConsulta.Columns[5].DefaultCellStyle.Format = "#.00\\%";

            DtGConsulta.Columns[0].DataPropertyName = "Cliente";
            DtGConsulta.Columns[1].DataPropertyName = "Representante";
            DtGConsulta.Columns[2].DataPropertyName = "Vl_Unit";
            DtGConsulta.Columns[3].DataPropertyName = "Qtde";
            DtGConsulta.Columns[4].DataPropertyName = "Vl_total";
            DtGConsulta.Columns[5].DataPropertyName = "Comissão";
            DtGConsulta.Columns[6].DataPropertyName = "Vl_Comissão";
            DtGConsulta.Columns[7].DataPropertyName = "idrepresentante";


            valor = 0;

            foreach (DataGridViewRow linha in DtGConsulta.Rows)
            {
                if ((linha.Cells[6].Value != DBNull.Value))
                {

                    valor += Convert.ToDouble(linha.Cells[6].Value);
                }

            }


            double valort = valor;
            string convertido = String.Format("{0:N2}", Math.Round(valort, 2));
            labTotal.Text = convertido;


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
        public double valor;
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


                     dtini = Convert.ToDateTime(mskini.Text).ToString("yyyy-MM-dd");
                     dtfim = Convert.ToDateTime(mskfim.Text).ToString("yyyy-MM-dd");


                    strConn = "Select DISTINCT Cliente.nome AS Cliente,Representante.nomerep AS Representante,Entrega.preco as Vl_Unit,Entrega.qtde as Qtde,.Entrega.total as Vl_total,Entrega.comissao as Comissão,Entrega.vlcomissao as Vl_Comissão,Representante.idrepresentante as idrepresentante  " +
                    " FROM Entrega, Cliente,Representante,Empenho Where Empenho.idcliente = Cliente.idcliente AND Entrega.idempenho = Empenho.idempenho AND Representante.idrepresentante = Entrega.idrepresentante AND " +
                    " Entrega.dtentrega BETWEEN '" + dtini + "' AND '" + dtfim + "' Order by Representante.nomerep ";
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
            DtGConsulta.Columns.Add("Cliente", "Cliente");
            DtGConsulta.Columns.Add("Representante", "Representante");
            DtGConsulta.Columns.Add("Vl_Unit", "Vl_Unit");
            DtGConsulta.Columns.Add("Qtde", "Qtde");
            DtGConsulta.Columns.Add("Vl_total", "Vl_total");
            DtGConsulta.Columns.Add("Comissão", "Comissão");
            DtGConsulta.Columns.Add("Vl_Comissão", "Vl_Comissão");
            DtGConsulta.Columns.Add("idrepresentante", "idrepresentante");

            DtGConsulta.Columns[0].Width = 240;
            DtGConsulta.Columns[1].Width = 240;
            DtGConsulta.Columns[2].Width = 80;
            DtGConsulta.Columns[3].Width = 60;
            DtGConsulta.Columns[4].Width = 100;
            DtGConsulta.Columns[5].Width = 78;
            DtGConsulta.Columns[6].Width = 100;
            DtGConsulta.Columns[7].Visible = false;


            DtGConsulta.Columns[3].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            DtGConsulta.Columns[2].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            DtGConsulta.Columns[4].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            DtGConsulta.Columns[6].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;

            DtGConsulta.Columns[4].DefaultCellStyle.Format = "n2";
            DtGConsulta.Columns[5].DefaultCellStyle.Format = "#.00\\%";

            DtGConsulta.Columns[0].DataPropertyName = "Cliente";
            DtGConsulta.Columns[1].DataPropertyName = "Representante";
            DtGConsulta.Columns[2].DataPropertyName = "Vl_Unit";
            DtGConsulta.Columns[3].DataPropertyName = "Qtde";
            DtGConsulta.Columns[4].DataPropertyName = "Vl_total";
            DtGConsulta.Columns[5].DataPropertyName = "Comissão";
            DtGConsulta.Columns[6].DataPropertyName = "Vl_Comissão";
            DtGConsulta.Columns[7].DataPropertyName = "idrepresentante";




            valor = 0;

            foreach (DataGridViewRow linha in DtGConsulta.Rows)
            {
                if ((linha.Cells[6].Value != DBNull.Value))
                {

                    valor += Convert.ToDouble(linha.Cells[6].Value);
                }

            }


            double valort = valor;
            string convertido = String.Format("{0:N2}", Math.Round(valort, 2));
            labTotal.Text = convertido;


            DtGConsulta.Refresh();


        }

        private void btnPesqData_Click(object sender, EventArgs e)
        {
            carregarGridPorData();
        }

        private void txtpesquisa_TextChanged(object sender, EventArgs e)
        {
            carregarGridNomeRepresentante();
        }

        private void chkTodos_CheckedChanged(object sender, EventArgs e)
        {
            carregarGridPorData();
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
                this.txtpesquisa.Focus();
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            status = 1;
            RelComissao comissao= new RelComissao(this);
            comissao.Show();
        }

        private void DtGConsulta_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            status = 2;
            codrep = Convert.ToInt32(DtGConsulta[7, e.RowIndex].Value.ToString());
            RelComissao comissao = new RelComissao(this);
            comissao.Show();
        }

        private void BtnSair_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void BtnLimpar_Click(object sender, EventArgs e)
        {
            DtGConsulta.DataSource = null;
            txtpesquisa.Text = "";
            mskini.Text = "";
            mskfim.Text = "";
            chkTodos.Checked = false;
            mskini.Focus();
            

        }
    }
}
