using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Prj_Cientifica
{
    public partial class ViewCotarFornecedores : Form
    {

        public int codproduto;
        public ViewCotarFornecedores()
        {
            InitializeComponent();
        }
        public ViewCotarFornecedores(ViewProduto frm) : this()
        {
            codproduto = Convert.ToInt32(frm.codproduto);
            RetornaProduto(codproduto);
            carregarGridItens();


        }



        private void RetornaProduto(Int32 retprod)
        {
            SqlConnection Cnn = Banco.CriarConexao();
            SqlDataAdapter sql = new SqlDataAdapter("Select * from Produto WHERE idproduto=" + retprod + "", Cnn);
            DataTable Dt = new DataTable();
            sql.Fill(Dt);
            try
            {
                this.cboproduto.DataSource = Dt;
                this.cboproduto.DisplayMember = "nome";
                this.cboproduto.ValueMember = "idproduto";
                this.cboproduto.Refresh();




            }
            catch (Exception erro)
            {

                throw erro;
            }
            Cnn.Close();
        }



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
                string strConn = "Select idfornecedor as Codigo, nome as Fornecedor" +
                " from Fornecedor Where nome  Like'" + txtpesquisa.Text + "%' Order by nome";
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
            DtGConsulta.Columns.Add("Fornecedor", "Fornecedor");
            DtGConsulta.Columns[0].Width = 50;
            DtGConsulta.Columns[1].Width = 80;
            DtGConsulta.Columns[2].Width = 610;
            DtGConsulta.Columns[1].DataPropertyName = "Codigo";
            DtGConsulta.Columns[2].DataPropertyName = "Fornecedor";
            DtGConsulta.Refresh();


            carregarGridItens();


        }

        private void txtpesquisa_TextChanged(object sender, EventArgs e)
        {
            carregarGrid();
        }

        private void BtnSair_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void BtnLimpar_Click(object sender, EventArgs e)
        {
            txtpesquisa.Text = "";
            DtGConsulta.DataSource = null;
            DtGConsulta.Refresh();
        }

        public int codprod;
        private void btnCotar_Click(object sender, EventArgs e)
        {

            try
            {

                SalvarDados();


            }
            catch (Exception erro)
            {

                throw erro;
            }

            //  AlteraStatusLicitacao();
            carregarGridItens();
            codprod = Convert.ToInt32(cboproduto.SelectedValue);
            ViewProduto frcont = new ViewProduto(this);
            frcont.Show();
            this.Close();


        }

        public void SalvarDados()
        {
            try
            {
                foreach (DataGridViewRow row in DtGConsulta.Rows)
                {

                    if (bool.Parse(row.Cells[0].EditedFormattedValue.ToString())  == true)
                    {
                        int col1 = Convert.ToInt32(row.Cells[1].Value);
                        int cod = Convert.ToInt32(cboproduto.SelectedValue);


                        SqlConnection Cnn = Banco.CriarConexao();
                        
                            string insert = "INSERT INTO Produto_Fornecedor(idproduto,idfornecedor,idusu) VALUES (@idproduto,@idfornecedor,@idusu)";
                            
                            SqlCommand cmd = new SqlCommand(insert, Cnn);
                            cmd.Parameters.AddWithValue("@idproduto", cod);
                            cmd.Parameters.AddWithValue("@idfornecedor", col1);
                            cmd.Parameters.AddWithValue("@idusu", Banco.idusu);
                            Cnn.Open();
                            cmd.ExecuteNonQuery();
                            Cnn.Close();
                        

                    }
                }
                MessageBox.Show("Dados incluídos com sucesso !!", "Inclusão", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                ex.Message.ToString();
            }

            carregarGridItens();
        }
        public double valor;

        DataGridViewCheckBoxColumn chk = new DataGridViewCheckBoxColumn();

        private void carregarGridItens()
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
                string strConn = "Select DISTINCT Produto_Fornecedor.idprodfornecedor as Codigo, Fornecedor.nome as Fornecedor,Produto.nome as Item " +
                "from Fornecedor, Produto_Fornecedor,Produto " +
               " where Produto_Fornecedor.idfornecedor = Fornecedor.idfornecedor and Produto_Fornecedor.idproduto = Produto.idproduto " +
               "and  Produto.idproduto=" + codproduto + "";


                SqlDataAdapter da = new SqlDataAdapter(strConn, Conn);
                da.Fill(ds);


            }

            this.griditens.RowsDefaultCellStyle.BackColor = Color.LightBlue;
            this.griditens.AlternatingRowsDefaultCellStyle.BackColor = Color.Azure;

            griditens.DataSource = ds;
            griditens.Columns.Clear();
            griditens.Columns.Add(chk);
            chk.HeaderText = "Sel";
            chk.Name = "chk";
            griditens.Columns.Add("Codigo", "Codigo");
            griditens.Columns.Add("Fornecedor", "Fornecedor");
            griditens.Columns.Add("Item", "Item");


            griditens.Columns[0].Width = 50;
            griditens.Columns[1].Width = 80;
            griditens.Columns[2].Width = 305;
            griditens.Columns[3].Width = 305;


            griditens.Columns[1].DataPropertyName = "Codigo";
            griditens.Columns[2].DataPropertyName = "Fornecedor";
            griditens.Columns[3].DataPropertyName = "Item";


            griditens.Refresh();




        }

    }
}
