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
    public partial class ConsMarca : Form
    {
        public ConsMarca()
        {
            InitializeComponent();
        }

        public int codmarca;
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
                string strConn = "Select Marca.idmarca as Codigo, Marca.nome as Marca,Fabricante.nome as Fabricante" +
                " from Marca,Fabricante Where Marca.idfabricante = Fabricante.idfabricante AND Marca.nome  Like'" + txtpesquisa.Text + "%' Order by Marca.nome";
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
            DtGConsulta.Columns.Add("Marca", "Marca");
            DtGConsulta.Columns.Add("Fabricante", "Fabricante");
            DtGConsulta.Columns[0].Width = 80;
            DtGConsulta.Columns[1].Width = 260;
            DtGConsulta.Columns[2].Width = 260;
            DtGConsulta.Columns[0].DataPropertyName = "Codigo";
            DtGConsulta.Columns[1].DataPropertyName = "Marca";
            DtGConsulta.Columns[2].DataPropertyName = "Fabricante";
            DtGConsulta.Refresh();

        }

        private void DtGConsulta_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            codmarca = Convert.ToInt32(DtGConsulta[0, e.RowIndex].Value.ToString());
            ViewMarca frcont = new ViewMarca(this);
            frcont.Show();
            this.Close();
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

        private void button1_Click(object sender, EventArgs e)
        {
            ViewProdutosMaisVendidos vendidos = new ViewProdutosMaisVendidos();
            vendidos.Show();
        }
    }
}
