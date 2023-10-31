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
    public partial class ConsProduto : Form
    {
        public ConsProduto()
        {
            InitializeComponent();
        }

        public ConsProduto(ViewProduto frm) : this()
        {



        }

        string strConn;
        public int codproduto;
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

                    strConn = "Select Produto.idproduto as Codigo, Produto.nome + ' - ' + Produto.apresentacao + ' - ' + Fabricante.nome   as Produto " +
                " from Produto,Fabricante  Where Produto.idfabricante = Fabricante.idfabricante AND  Produto.nome  Like'" + txtpesquisa.Text + "%' Order by Produto.nome asc";
                }
                else if (chkprincipio.Checked == true)
                {

                    strConn = "Select Produto.idproduto as Codigo, PrincipioAtivo.nome + ' - ' + Produto.apresentacao  + ' - ' + Fabricante.nome  as Produto" +
               " from Produto,PrincipioAtivo,Fabricante Where Produto.idfabricante = Fabricante.idfabricante AND  Produto.idprincipio = PrincipioAtivo.idprincipio  AND PrincipioAtivo.nome Like'" + txtpesquisa.Text + "%' Order by PrincipioAtivo.nome asc";


                }
                else if (this.chkMarca.Checked == true)
                {


                    strConn = "Select Produto.idproduto as Codigo, PrincipioAtivo.nome + ' - ' + Produto.apresentacao  + ' - ' + Fabricante.nome  as Produto, Marca.nome as Marca" +
               " from Produto,PrincipioAtivo,Fabricante,Marca Where Produto.idfabricante = Fabricante.idfabricante AND  Produto.idmarca = Marca.idmarca AND  Produto.idprincipio = PrincipioAtivo.idprincipio  AND  Marca.nome Like'" + txtpesquisa.Text + "%' Order by PrincipioAtivo.nome asc";


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
            DtGConsulta.Columns.Add("Produto", "Produto");
            DtGConsulta.Columns[0].Width = 80;
            DtGConsulta.Columns[1].Width = 838;


            // DtGConsulta.Columns[2].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;

            DtGConsulta.Columns[0].DataPropertyName = "Codigo";
            DtGConsulta.Columns[1].DataPropertyName = "Produto";



            //DtGConsulta.Columns[2].DefaultCellStyle.Format = "c";

            DtGConsulta.Refresh();

        }

        private void DtGConsulta_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            codproduto = Convert.ToInt32(DtGConsulta[0, e.RowIndex].Value.ToString());
            ViewProduto frcont = new ViewProduto(this);
            frcont.Show();
            this.Close();

        }

        private void BtnLimpar_Click(object sender, EventArgs e)
        {
            txtpesquisa.Text = "";
            DtGConsulta.DataSource = null;
            chkprincipio.Checked = true;
            chkProduto.Checked = false;
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

        private void ConsProduto_Load(object sender, EventArgs e)
        {
            chkMarca.Checked = true;
        }

        private void chkprincipio_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void chkProduto_CheckedChanged(object sender, EventArgs e)
        {

        }
    }


}
