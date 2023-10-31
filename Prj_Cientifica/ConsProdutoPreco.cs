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
    public partial class ConsProdutoPreco : Form
    {
        public ConsProdutoPreco()
        {
            InitializeComponent();
        }

        private void BtnSair_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        string strConn;
        public int codproduto;
        DataGridViewCheckBoxColumn chkb = new DataGridViewCheckBoxColumn();
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

                    strConn = "Select Produto.idproduto as Codigo, Produto.nome as Produto " +
                " from Produto Where  Produto.nome  Like'%" + txtpesquisa.Text + "%' Order by Produto.nome";
                }
                else if (chkprincipio.Checked == true)
                {

                    strConn = "Select Produto.idproduto as Codigo, Produto.nome as Produto" +
               " from Produto,PrincipioAtivo Where  Produto.idprincipio = PrincipioAtivo.idprincipio  AND Produto.nome Like'%" + txtpesquisa.Text + "%' Order by Produto.nome";


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
                DtGConsulta.Columns.Add(chkb);
                chkb.HeaderText = "Sel";
                chkb.Name = "chkb";
                DtGConsulta.Columns.Add("Codigo", "Codigo");
                DtGConsulta.Columns.Add("Produto", "Produto");
                DtGConsulta.Columns[0].Width = 50;
                DtGConsulta.Columns[1].Width = 80;
                DtGConsulta.Columns[2].Width = 770;

                DtGConsulta.Columns[1].DataPropertyName = "Codigo";
                DtGConsulta.Columns[2].DataPropertyName = "Produto";
                DtGConsulta.Refresh();





            

        }

        private void DtGConsulta_CellClick(object sender, DataGridViewCellEventArgs e)
        {

            if (e.RowIndex >= 0 && e.ColumnIndex == 0)
            {
                //Loop and uncheck all other CheckBoxes.
                foreach (DataGridViewRow row in DtGConsulta.Rows)
                {
                    if (row.Index == e.RowIndex)
                    {
                        row.Cells["chkb"].Value = !Convert.ToBoolean(row.Cells["chkb"].EditedFormattedValue);
                        codproduto = int.Parse(DtGConsulta.Rows[e.RowIndex].Cells[1].Value.ToString());
                        carregarGridItens(codproduto);
                    }
                    else
                    {
                        row.Cells["chkb"].Value = false;
                    }
                }
            }
        }
        private void carregarGridItens(int codp)
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
                string strConn = "Select DISTINCT Produto_Fornecedor.idfornecedor as Codigo, Fornecedor.nome as Fornecedor,RetCotacao.liquido as Ultimo_Preço,Max(RetCotacao.dtcotacao) Data " +
                "FROM RetCotacao LEFT JOIN  Produto_Fornecedor on  RetCotacao.idfornecedor = Produto_Fornecedor.idfornecedor " +
                "LEFT JOIN Fornecedor on Produto_Fornecedor.idfornecedor = Fornecedor.idfornecedor LEFT JOIN Produto ON Produto_Fornecedor.idproduto =  Produto.idproduto" +
               " WHERE RetCotacao.idproduto =" + codp + " GROUP BY  Produto_Fornecedor.idfornecedor,Fornecedor.nome,RetCotacao.liquido,RetCotacao.dtcotacao";
 


                SqlDataAdapter da = new SqlDataAdapter(strConn, Conn);
                da.Fill(ds);


            }

            this.griditens.RowsDefaultCellStyle.BackColor = Color.LightBlue;
            this.griditens.AlternatingRowsDefaultCellStyle.BackColor = Color.Azure;

            griditens.DataSource = ds;
            griditens.Columns.Clear();
            griditens.Columns.Add("Codigo", "Codigo");
            griditens.Columns.Add("Fornecedor", "Fornecedor");
            griditens.Columns.Add("Ultimo_Preço", "Ultimo_Preço");
            griditens.Columns.Add("Data", "Data");


            griditens.Columns[0].Visible = false;
            griditens.Columns[1].Width = 710;
            griditens.Columns[2].Width = 110;
            griditens.Columns[3].Width = 95;


            griditens.Columns[0].DataPropertyName = "Codigo";
            griditens.Columns[1].DataPropertyName = "Fornecedor";
            griditens.Columns[2].DataPropertyName = "Ultimo_Preço";
            griditens.Columns[3].DataPropertyName = "Data";

            griditens.Columns[2].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            griditens.Columns[2].DefaultCellStyle.Format = "c";

            griditens.Refresh();




        }

        private void txtpesquisa_TextChanged(object sender, EventArgs e)
        {
            carregarGrid();
        }

        private void BtnLimpar_Click(object sender, EventArgs e)
        {
          
            griditens.DataSource = null;
            DtGConsulta.DataSource = null;
            txtpesquisa.Text = "";
            txtpesquisa.Focus();
        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }

        private void ConsProdutoPreco_Load(object sender, EventArgs e)
        {
            this.chkProduto.Checked = true;
        }
    }
}
