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
    public partial class Compras : Form
    {
        public Compras()
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

                    strConn = "Select RealinhamentoProposta.idedital as Cod_Edital, (LancEditais.nlicitacao + ' - ' + PrincipioAtivo.nome + '-' + Produto.nome  + ' - ' + Produto.apresentacao  + ' - ' + Marca.nome)  as Produto," +
                         "UnidadeMedida.nome as Unidade, RealinhamentoProposta.qtde as Qtde,RealinhamentoProposta.vlvenda as Preco_Unitario,RealinhamentoProposta.vltotal as Preço_Total, " +
                        "RealinhamentoProposta.margemfinal as Margem,.RealinhamentoProposta.vlcusto as Preço_Custo,RealinhamentoProposta.total AS TotalCusto " +
                        "From Produto, Marca, UnidadeMedida, RealinhamentoProposta, Cliente, LancEditais, PrincipioAtivo WHERE RealinhamentoProposta.idunidade = UnidadeMedida.idunidade AND RealinhamentoProposta.idproduto = Produto.idproduto" +
                        " AND RealinhamentoProposta.idedital = LancEditais.idedital AND LancEditais.idcliente = Cliente.idcliente AND Produto.idprincipio = PrincipioAtivo.idprincipio " +
                        " AND RealinhamentoProposta.idmarca = Marca.idmarca AND  Produto.nome  Like'%" + txtpesquisa.Text + "' Order by Produto.nome asc";
                }
                else if (chkestado.Checked == true)
                {

                    strConn = "Select RealinhamentoProposta.idedital as Cod_Edital, (LancEditais.nlicitacao + ' - ' + PrincipioAtivo.nome + ' - ' + Produto.nome  + ' - ' + Produto.apresentacao  + ' - ' + Marca.nome)  as Produto," +
                         "UnidadeMedida.nome as Unidade, RealinhamentoProposta.qtde as Qtde,RealinhamentoProposta.vlvenda as Preco_Unitario,RealinhamentoProposta.vltotal as Preço_Total, " +
                        "RealinhamentoProposta.margemfinal as Margem,.RealinhamentoProposta.vlcusto as Preço_Custo,RealinhamentoProposta.total AS TotalCusto " +
                        "From Produto, Marca, UnidadeMedida, RealinhamentoProposta, Cliente, LancEditais, PrincipioAtivo WHERE RealinhamentoProposta.idunidade = UnidadeMedida.idunidade AND RealinhamentoProposta.idproduto = Produto.idproduto" +
                        " AND RealinhamentoProposta.idedital = LancEditais.idedital AND LancEditais.idcliente = Cliente.idcliente AND Produto.idprincipio = PrincipioAtivo.idprincipio " +
                        " AND RealinhamentoProposta.idmarca = Marca.idmarca  AND Cliente.Estado Like'%" + txtpesquisa.Text + "' Order by Cliente.Estado asc";


                }
                else if (this.chkMarca.Checked == true)
                {


                    strConn = "Select RealinhamentoProposta.idedital as Cod_Edital, (LancEditais.nlicitacao + ' - ' + PrincipioAtivo.nome + ' - ' + Produto.nome  + ' - ' + Produto.apresentacao  + ' - ' + Marca.nome)  as Produto," +
                         "UnidadeMedida.nome as Unidade, RealinhamentoProposta.qtde as Qtde,RealinhamentoProposta.vlvenda as Preco_Unitario,RealinhamentoProposta.vltotal as Preço_Total, " +
                        "RealinhamentoProposta.margemfinal as Margem,.RealinhamentoProposta.vlcusto as Preço_Custo,RealinhamentoProposta.total AS TotalCusto " +
                        "From Produto, Marca, UnidadeMedida, RealinhamentoProposta, Cliente, LancEditais, PrincipioAtivo WHERE RealinhamentoProposta.idunidade = UnidadeMedida.idunidade AND RealinhamentoProposta.idproduto = Produto.idproduto" +
                        " AND RealinhamentoProposta.idedital = LancEditais.idedital AND LancEditais.idcliente = Cliente.idcliente AND Produto.idprincipio = PrincipioAtivo.idprincipio " +
                        " AND RealinhamentoProposta.idmarca = Marca.idmarca AND Marca.nome Like'%" + txtpesquisa.Text + "' Order by Marca.nome asc";


                }
                else if (this.chkedital.Checked == true)
                {


                    strConn = "Select RealinhamentoProposta.idedital as Cod_Edital, (LancEditais.nlicitacao + ' - ' + PrincipioAtivo.nome + ' - ' + Produto.nome  + ' - ' + Produto.apresentacao  + ' - ' + Marca.nome)  as Produto," +
                         "UnidadeMedida.nome as Unidade, RealinhamentoProposta.qtde as Qtde,RealinhamentoProposta.vlvenda as Preco_Unitario,RealinhamentoProposta.vltotal as Preço_Total, " +
                        "RealinhamentoProposta.margemfinal as Margem,.RealinhamentoProposta.vlcusto as Preço_Custo,RealinhamentoProposta.total AS TotalCusto " +
                        "From Produto, Marca, UnidadeMedida, RealinhamentoProposta, Cliente, LancEditais, PrincipioAtivo WHERE RealinhamentoProposta.idunidade = UnidadeMedida.idunidade AND RealinhamentoProposta.idproduto = Produto.idproduto" +
                        " AND RealinhamentoProposta.idedital = LancEditais.idedital AND LancEditais.idcliente = Cliente.idcliente AND Produto.idprincipio = PrincipioAtivo.idprincipio " +
                        " AND RealinhamentoProposta.idmarca = Marca.idmarca AND  RealinhamentoProposta.idedital Like'%" + txtpesquisa.Text + "' Order by Marca.nome asc";


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
            DtGConsulta.Columns.Add("Cod_Edital", "Cod_Edital");
            DtGConsulta.Columns.Add("Produto", "Produto");
            DtGConsulta.Columns.Add("Unidade", "Unidade");
            DtGConsulta.Columns.Add("Qtde", "Qtde");
            DtGConsulta.Columns.Add("Preco_Unitario", "Preco_Unitario");
            DtGConsulta.Columns.Add("Preço_Total", "Preço_Total");
            DtGConsulta.Columns.Add("Margem", "Margem");
            DtGConsulta.Columns.Add("Preço_Custo", "Preço_Custo");
            DtGConsulta.Columns.Add("TotalCusto", "TotalCusto");

            DtGConsulta.Columns[0].Width = 70;
            DtGConsulta.Columns[1].Width = 500;
            DtGConsulta.Columns[2].Width = 100;
            DtGConsulta.Columns[3].Width = 70;
            DtGConsulta.Columns[4].Width = 70;
            DtGConsulta.Columns[5].Width = 95;
            DtGConsulta.Columns[6].Width = 80;
            DtGConsulta.Columns[7].Width = 70;
            DtGConsulta.Columns[8].Width = 95;

             DtGConsulta.Columns[0].DefaultCellStyle.Alignment = DataGridViewContentAlignment.TopCenter;

            DtGConsulta.Columns[0].DataPropertyName = "Cod_Edital";
            DtGConsulta.Columns[1].DataPropertyName = "Produto";
            DtGConsulta.Columns[2].DataPropertyName = "Unidade";
            DtGConsulta.Columns[3].DataPropertyName = "Qtde";
            DtGConsulta.Columns[4].DataPropertyName = "Preco_Unitario";
            DtGConsulta.Columns[5].DataPropertyName = "Preço_Total";
            DtGConsulta.Columns[6].DataPropertyName = "Margem";
            DtGConsulta.Columns[7].DataPropertyName = "Preço_Custo";
            DtGConsulta.Columns[8].DataPropertyName = "TotalCusto";



            valor = 0;

            foreach (DataGridViewRow linha in DtGConsulta.Rows)
            {

                {

                    valor += Convert.ToDecimal(linha.Cells[5].Value);
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
        public int codedital;
        private void DtGConsulta_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {

            codedital = Convert.ToInt32(DtGConsulta[0, e.RowIndex].Value.ToString());
            RelCompras compras = new RelCompras(this);
            compras.Show();
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

        private void Compras_Load(object sender, EventArgs e)
        {
            this.chkedital.Checked = true;
        }

        private void chkedital_CheckedChanged(object sender, EventArgs e)
        {

        }
    }
}
