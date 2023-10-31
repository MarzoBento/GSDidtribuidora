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
    public partial class Mapa_de_Preco_por_Itens : Form
    {
        public Mapa_de_Preco_por_Itens()
        {
            InitializeComponent();
        }

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
                string strConn = " SELECT Produto.idproduto as Cod, Cliente.razao, Cliente.nome AS Cliente, Concorrente.razao AS Concorrente, ItemsLicitacao.nritem, Produto.nome, (Produto.nome + '-' + Produto.apresentacao) AS Item, " + 
                      "Marca.nome AS Marca, MapaPreco.precoinicial, MapaPreco.precoganho as Preço_Ganho, MapaPreco.qtde as Qtde, MapaPreco.precoganho * MapaPreco.qtde AS Preco_Total" +
                     " FROM Cliente INNER JOIN ItemsLicitacao INNER JOIN Produto ON ItemsLicitacao.idproduto = Produto.idproduto INNER JOIN " +
                      " MapaPreco ON ItemsLicitacao.iditemedital = MapaPreco.iditemedital INNER JOIN " +
                      "Concorrente ON MapaPreco.idconcorrente = Concorrente.idconcorrente INNER JOIN " +
                       "Marca ON MapaPreco.idmarca = Marca.idmarca ON Cliente.idcliente = ItemsLicitacao.idcliente " +
                       "WHERE Produto.nome Like '" + txtpesquisa.Text + "%' Order by Produto.nome asc";



                SqlDataAdapter da = new SqlDataAdapter(strConn, Conn);
                da.Fill(ds);


            }

            this.griditens.RowsDefaultCellStyle.BackColor = Color.LightBlue;
            this.griditens.AlternatingRowsDefaultCellStyle.BackColor = Color.Azure;


            griditens.AutoGenerateColumns = false;
            //exibe os dados no datagridview
            griditens.DataSource = ds;
            griditens.Columns.Clear();
            griditens.Columns.Add("Marca", "Marca");
            griditens.Columns.Add("Item", "Item");
            griditens.Columns.Add("Concorrente", "Concorrente");
            griditens.Columns.Add("Cliente", "Cliente");
            griditens.Columns.Add("Preço_Ganho", "Preço_Ganho");
            griditens.Columns.Add("Cod", "Cod");


            griditens.Columns[0].Width = 150;
            griditens.Columns[1].Width = 400;
            griditens.Columns[2].Width = 200;
            griditens.Columns[3].Width = 205;
            griditens.Columns[4].Width = 100;
            griditens.Columns[5].Visible =  false;


            griditens.Columns[3].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            griditens.Columns[3].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft;


            griditens.Columns[0].DataPropertyName = "Marca";
            griditens.Columns[1].DataPropertyName = "Item";
            griditens.Columns[2].DataPropertyName = "Concorrente";
            griditens.Columns[3].DataPropertyName = "Cliente";
            griditens.Columns[4].DataPropertyName = "Preço_Ganho";
            griditens.Columns[5].DataPropertyName = "Cod";


            griditens.Columns[3].DefaultCellStyle.Format = "n2";

            griditens.Refresh();


        }
        public int codproduto;
        private void griditens_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            codproduto = Convert.ToInt32(griditens[5, e.RowIndex].Value.ToString());
            Map_de_Preço_por_Itens compras = new Map_de_Preço_por_Itens(this);
            compras.Show();
            this.Close();
        }

        private void txtpesquisa_TextChanged(object sender, EventArgs e)
        {
            carregarGridItens();
        }

        private void BtnSair_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
