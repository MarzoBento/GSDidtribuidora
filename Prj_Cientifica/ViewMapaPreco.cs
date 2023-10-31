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
    public partial class ViewMapaPreco : Form
    {
        public ViewMapaPreco()
        {
            InitializeComponent();
        }

      

        private void carregarGridPesquisa()
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
                string strConn = "Select DISTINCT top 5 (ItemsLicitacao.nlicitacao  + ' - ' +  Cliente.razao) as Cliente,Produto.nome as Descricao, UnidadeMedida.nome as Unidade,ItemsLicitacao.qtde as Qtde, Concorrente.nome as Concorrente, MapaPreco.precoinicial as VlInicial,MIN(MapaPreco.precoganho) as VlGanho," +
                    "MAX(RealinhamentoProposta.dtrealinhamento) AS Data" +
                " from ItemsLicitacao LEFT JOIN MapaPreco ON ItemsLicitacao.iditemedital = MapaPreco.iditemedital LEFT JOIN Concorrente ON MapaPreco.idconcorrente = Concorrente.idconcorrente, " +
                "LancEditais,Cliente,Produto,UnidadeMedida,RealinhamentoProposta  WHERE RealinhamentoProposta.idproduto = Produto.idproduto AND Produto.idproduto =  ItemsLicitacao.idproduto AND UnidadeMedida.idunidade = ItemsLicitacao.idunidade AND ItemsLicitacao.nlicitacao = LancEditais.nlicitacao AND Cliente.idcliente = LancEditais.idcliente AND  Produto.nome Like'%" + txtpesquisa.Text + "%' GROUP BY  Produto.nome," +
                "UnidadeMedida.nome,ItemsLicitacao.qtde, Concorrente.nome , MapaPreco.precoinicial,Cliente.razao,ItemsLicitacao.nlicitacao ";


                SqlDataAdapter da = new SqlDataAdapter(strConn, Conn);
                da.Fill(ds);


            }

            this.griditens.RowsDefaultCellStyle.BackColor = Color.LightBlue;
            this.griditens.AlternatingRowsDefaultCellStyle.BackColor = Color.Azure;


            griditens.AutoGenerateColumns = false;
            //exibe os dados no datagridview
            griditens.DataSource = ds;
            griditens.Columns.Clear();

            griditens.Columns.Add("Cliente", "Cliente");
            griditens.Columns.Add("Descricao", "Descricao");
            griditens.Columns.Add("Qtde", "Qtde");
            griditens.Columns.Add("Unidade", "Unidade");
            griditens.Columns.Add("Concorrente", "Concorrente");
            griditens.Columns.Add("VlInicial", "VlInicial");
            griditens.Columns.Add("VlGanho", "VlGanho");
            griditens.Columns.Add("Data", "Data");


            griditens.Columns[0].Width = 300;
            griditens.Columns[1].Width = 320;
            griditens.Columns[2].Width = 70;
            griditens.Columns[3].Width = 85;
            griditens.Columns[4].Width = 240;
            griditens.Columns[5].Width = 90;
            griditens.Columns[6].Width = 90;
            griditens.Columns[7].Width = 85;


            //griditens.Columns[1].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft;
            //griditens.Columns[5].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft;
            //griditens.Columns[4].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft;


            griditens.Columns[0].DataPropertyName = "Cliente";
            griditens.Columns[1].DataPropertyName = "Descricao";
            griditens.Columns[2].DataPropertyName = "Qtde";
            griditens.Columns[3].DataPropertyName = "Unidade";
            griditens.Columns[4].DataPropertyName = "Concorrente";
            griditens.Columns[5].DataPropertyName = "VlInicial";
            griditens.Columns[6].DataPropertyName = "VlGanho";
            griditens.Columns[7].DataPropertyName = "Data";


            //int total = 0;

            //foreach (DataGridViewRow linha in griditens.Rows)
            //{
            //    total = total + 1;
            //}

            //ladtotal.Text = Convert.ToString(total);


            griditens.Refresh();


        }

        private void txtpesquisa_TextChanged(object sender, EventArgs e)
        {
            carregarGridPesquisa();
        }

        private void BtnSair_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void BtnNovo_Click(object sender, EventArgs e)
        {
            txtpesquisa.Text = "";
            griditens.DataSource = null;
        }
    }
}
