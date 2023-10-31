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
    public partial class ConsItensGanho : Form
    {

        public string Produto;
        public string Fornecedor;
        public string OrgaoG;
        public int idproduto;
        public int idfornecedor;
        public int idcliente;
        public string UF;
        public int opcao;
        public string totalitens;
        public string totalproduto;

        public ConsItensGanho()
        {
            InitializeComponent();
        }

        Decimal valor;
        string strConn;
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

                if (this.chkProduto.Checked == true)
                {
                    opcao = 1;

                    strConn = "Select * FROM View_Ganhou  WHERE Produto  Like'" + txtpesquisa.Text + "%' AND Ganhou='SIM' Order by Produto asc";
                }
                else if (this.chkFornecedor.Checked == true)
                {
                    opcao = 2;

                    strConn = "Select * FROM View_Ganhou WHERE  Fornecedor Like'" + txtpesquisa.Text + "%' AND Ganhou='SIM' Order by Fornecedor asc";


                }
                else if (this.chkorgao.Checked == true)
                {
                    opcao = 3;

                    strConn = "Select * FROM View_Ganhou WHERE  Orgao Like'" + txtpesquisa.Text + "%' AND Ganhou='SIM' Order by Orgao asc";


                }
                else if (cmbuf.Text != "")
                { 

                    opcao = 4;

                    strConn = "Select * FROM View_Ganhou  WHERE uf ='" + cmbuf.Text + "' AND Ganhou='SIM' Order by uf  asc";
               

                }

                else if (this.chktodos.Checked == true)
                {

                    opcao = 5;

                    strConn = "Select * FROM View_Ganhou  WHERE  Ganhou='SIM' Order by uf  asc";


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
            DtGConsulta.Columns.Add("NEdital", "NEdital");
            DtGConsulta.Columns.Add("Edital", "Edital");
            DtGConsulta.Columns.Add("Produto", "Produto");
            DtGConsulta.Columns.Add("Orgao", "Orgao");
            DtGConsulta.Columns.Add("UF", "UF");
            DtGConsulta.Columns.Add("Vl_Venda", "Vl_Venda");
            DtGConsulta.Columns.Add("Qtde", "Qtde");
            DtGConsulta.Columns.Add("Vl_Total", "Vl_Total");
            DtGConsulta.Columns.Add("Vl_Custo", "Vl_Custo");
            DtGConsulta.Columns.Add("Ganhou", "Ganhou");
            DtGConsulta.Columns.Add("Fornecedor", "Fornecedor");
            DtGConsulta.Columns.Add("idproduto", "idproduto");
            DtGConsulta.Columns.Add("idfornecedor", "idfornecedor");
            DtGConsulta.Columns.Add("idcliente", "idcliente");
            DtGConsulta.Columns.Add("DtVigencia", "DtVigencia");

            DtGConsulta.Columns[0].Width = 60;
            DtGConsulta.Columns[1].Width = 110;
            DtGConsulta.Columns[2].Width = 250;
            DtGConsulta.Columns[3].Width = 250;
            DtGConsulta.Columns[4].Width = 60;
            DtGConsulta.Columns[5].Width = 75;
            DtGConsulta.Columns[6].Width = 75;
            DtGConsulta.Columns[7].Width = 75;
            DtGConsulta.Columns[8].Width = 80;
            DtGConsulta.Columns[9].Width = 80;
            DtGConsulta.Columns[10].Width = 250;
            DtGConsulta.Columns[11].Visible = false;
            DtGConsulta.Columns[12].Visible = false;
            DtGConsulta.Columns[13].Visible = false;
            DtGConsulta.Columns[14].Width = 110;


            DtGConsulta.Columns[0].DefaultCellStyle.Alignment = DataGridViewContentAlignment.TopCenter;

            DtGConsulta.Columns[0].DataPropertyName = "NEdital";
            DtGConsulta.Columns[1].DataPropertyName = "Edital";
            DtGConsulta.Columns[2].DataPropertyName = "Produto";
            DtGConsulta.Columns[3].DataPropertyName = "Orgao";
            DtGConsulta.Columns[4].DataPropertyName = "UF";
            DtGConsulta.Columns[5].DataPropertyName = "Vl_Venda";
            DtGConsulta.Columns[6].DataPropertyName = "Qtde";
            DtGConsulta.Columns[7].DataPropertyName = "Vl_Total";
            DtGConsulta.Columns[8].DataPropertyName = "Vl_Custo";
            DtGConsulta.Columns[9].DataPropertyName = "Ganhou";
            DtGConsulta.Columns[10].DataPropertyName = "Fornecedor";
            DtGConsulta.Columns[11].DataPropertyName = "idproduto";
            DtGConsulta.Columns[12].DataPropertyName = "idfornecedor";
            DtGConsulta.Columns[13].DataPropertyName = "idcliente";
            DtGConsulta.Columns[14].DataPropertyName = "DtVigencia";



            valor = 0;

            foreach (DataGridViewRow linha in DtGConsulta.Rows)
            {

                {

                    valor += Convert.ToDecimal(linha.Cells[7].Value);
                }

            }


            decimal valort = valor;
            string convertido = String.Format("{0:N2}", Math.Round(valort, 2));
            labTotal.Text = convertido;
           

            Int32 total = 0;

            foreach (DataGridViewRow linhatotal in DtGConsulta.Rows)
            {
                total = total + 1;
            }

            this.txttotalitens.Text = Convert.ToString(total);




            //DtGConsulta.Columns[2].DefaultCellStyle.Format = "c";

            DtGConsulta.Refresh();

            Conn.Close();

        }

        private void cmbuf_SelectionChangeCommitted(object sender, EventArgs e)
        {

          


        }

        private void BuscaPorEstado()
        {

          


        }

        private void DtGConsulta_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {

            idproduto= Convert.ToInt32(DtGConsulta[11, e.RowIndex].Value.ToString());
            idfornecedor = Convert.ToInt32(DtGConsulta[12, e.RowIndex].Value.ToString());
            idcliente = Convert.ToInt32(DtGConsulta[13, e.RowIndex].Value.ToString());
            UF = cmbuf.Text;
            totalitens = txttotalitens.Text;
            totalproduto = labTotal.Text;
            RelItensGanho frcont = new RelItensGanho(this);
            frcont.Show();
            this.Close();


        }

        private void btnImprimir_Click(object sender, EventArgs e)
        {
         

        }

        private void txtpesquisa_TextChanged(object sender, EventArgs e)
        {
            carregarGrid();
        }

        private void BtnImprimir_Click_1(object sender, EventArgs e)
        {
           
        }

        private void button1_Click(object sender, EventArgs e)
        {
            carregarGrid();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            carregarGrid();
        }

        private void BtnLimpar_Click(object sender, EventArgs e)
        {
            chkFornecedor.Checked = false;
            chkorgao.Checked = false;
            chkProduto.Checked = false;
            chktodos.Checked = false;
            cmbuf.Text = "";
            txttotalitens.Text = "";
            txtpesquisa.Text = "";
            txtpesquisa.Focus();
        }
    }
}
