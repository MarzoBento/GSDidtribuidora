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
    public partial class ViewAdicionaItemsEmpenho : Form
    {
        public string codedital;
        public string processo;
        public int cliente;
        public string dtentrega;
        public string dtrecebimento;
        public string notafiscal;
        public string numeroempenho;
        public int idmarca;
        public string nritem;
        public decimal vlvenda;
        public int iditemedital;
        public decimal vladitivo;
        public int idprincipio;
        public int lote;
        public int idrealinhamento;
        public int idproduto;
        public int qtde;
        public int idedital;
        public string ata;
        public string ndoc;
        public string dtvigencia;
        public int codempenho;


        public ViewAdicionaItemsEmpenho()
        {
            InitializeComponent();
        }

        public ViewAdicionaItemsEmpenho(ViewEmpenho frm) : this()
        {
            idedital = Convert.ToInt32(frm.ideditalempenho);
            numeroempenho = Convert.ToString(frm.numeroempenho);
            cliente = Convert.ToInt32(frm.idcli);
            dtentrega = frm.dtlimite;
            dtrecebimento = frm.dtrecebimento;
            notafiscal = frm.notafiscal;
            ata = frm.ata;
            ndoc = frm.ndoc;
            dtvigencia = frm.dtvigencia;
            codempenho = frm.codempenho;

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
               string strConn = "Select DISTINCT Produto.idproduto as codproduto,PrincipioAtivo.idprincipio as codprincipio, Marca.idmarca as codmarca, ItemsLicitacao.nritem as Nritem,ItemsLicitacao.lote as Lote, RealinhamentoProposta.vlvenda,PrincipioAtivo.nome as PrincipioAtivo, " +
                     "RealinhamentoProposta.iditemedital,Produto.nome + '-' + Produto.apresentacao as Produto,RealinhamentoProposta.vladitivo,RealinhamentoProposta.idrealinhamento,RealinhamentoProposta.iditemedital,RealinhamentoProposta.vladitivo,RealinhamentoProposta.qtde as Qtde,Marca.nome as Marca, LancEditais.idedital,  LancEditais.nlicitacao" +
                 " FROM RealinhamentoProposta LEFT JOIN EmpenhoItems ON RealinhamentoProposta.idrealinhamento = EmpenhoItems.idrealinhamento,Produto,LancEditais,ItemsLicitacao,PrincipioAtivo,Marca " +
                 "WHERE LancEditais.idedital = ItemsLicitacao.idedital and ItemsLicitacao.idproduto = Produto.idproduto  AND ItemsLicitacao.iditemedital = RealinhamentoProposta.iditemedital AND RealinhamentoProposta.idmarca = Marca.idmarca " +
                 "AND ItemsLicitacao.idprincipio = PrincipioAtivo.idprincipio AND Produto.statusprod='ATIVO' AND LancEditais.idedital=" + idedital + " AND PrincipioAtivo.nome  Like'" + txtpesquisa.Text + "%' Order by PrincipioAtivo.nome";
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
            DtGConsulta.Columns.Add("codproduto", "codproduto");
            DtGConsulta.Columns.Add("codprincipio", "codprincipio");
            DtGConsulta.Columns.Add("codmarca", "codmarca");
            DtGConsulta.Columns.Add("PrincipioAtivo", "PrincipioAtivo");
            DtGConsulta.Columns.Add("Produto", "Produto");
            DtGConsulta.Columns.Add("Marca", "Marca");
            DtGConsulta.Columns.Add("iditemedital", "iditemedital");
            DtGConsulta.Columns.Add("idrealinhamento", "idrealinhamento");
            DtGConsulta.Columns.Add("vladitivo", "vladitivo");
            DtGConsulta.Columns.Add("Nritem", "Nritem");
            DtGConsulta.Columns.Add("Lote", "Lote");
            DtGConsulta.Columns.Add("Qtde", "Qtde");
            DtGConsulta.Columns.Add("vlvenda", "vlvenda");
            DtGConsulta.Columns.Add("idedital", "idedital");
            DtGConsulta.Columns.Add("nlicitacao", "nlicitacao");


            DtGConsulta.Columns[0].Width = 50;
            DtGConsulta.Columns[1].Visible = false;
            DtGConsulta.Columns[2].Visible = false;
            DtGConsulta.Columns[3].Visible = false;
            DtGConsulta.Columns[4].Width = 450;
            DtGConsulta.Columns[5].Width = 497;
            DtGConsulta.Columns[6].Width = 200;
            DtGConsulta.Columns[7].Visible = false;
            DtGConsulta.Columns[8].Visible = false;
            DtGConsulta.Columns[9].Visible = false;
            DtGConsulta.Columns[10].Width = 70;
            DtGConsulta.Columns[11].Width = 70;
            DtGConsulta.Columns[12].Width = 70;
            DtGConsulta.Columns[13].Visible = false;
            DtGConsulta.Columns[14].Visible = false;
            DtGConsulta.Columns[15].Visible = false;

            DtGConsulta.Columns[1].DataPropertyName = "codproduto";
            DtGConsulta.Columns[2].DataPropertyName = "codprincipio";
            DtGConsulta.Columns[3].DataPropertyName = "codmarca";
            DtGConsulta.Columns[4].DataPropertyName = "PrincipioAtivo";
            DtGConsulta.Columns[5].DataPropertyName = "Produto";
            DtGConsulta.Columns[6].DataPropertyName = "Marca";
            DtGConsulta.Columns[7].DataPropertyName = "iditemedital";
            DtGConsulta.Columns[8].DataPropertyName = "idrealinhamento";
            DtGConsulta.Columns[9].DataPropertyName = "vladitivo";
            DtGConsulta.Columns[10].DataPropertyName = "Nritem";
            DtGConsulta.Columns[11].DataPropertyName = "Lote";
            DtGConsulta.Columns[12].DataPropertyName = "Qtde";
            DtGConsulta.Columns[13].DataPropertyName = "vlvenda";
            DtGConsulta.Columns[14].DataPropertyName = "idedital";
            DtGConsulta.Columns[15].DataPropertyName = "nlicitacao";



            DtGConsulta.Columns[10].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            DtGConsulta.Columns[10].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
            DtGConsulta.Columns[11].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            DtGConsulta.Columns[11].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
            DtGConsulta.Columns[12].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            DtGConsulta.Columns[12].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;


            DtGConsulta.Refresh();


            // carregarGridItens();


        }

        private void DtGConsulta_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if ((e.RowIndex != -1 && e.ColumnIndex == 0))
            {

                if (bool.Parse(DtGConsulta.Rows[e.RowIndex].Cells[0].EditedFormattedValue.ToString()))
                {
                    idproduto = int.Parse(DtGConsulta.Rows[e.RowIndex].Cells[1].Value.ToString());
                    idprincipio = int.Parse(DtGConsulta.Rows[e.RowIndex].Cells[2].Value.ToString());
                    idmarca = int.Parse(DtGConsulta.Rows[e.RowIndex].Cells[3].Value.ToString());
                    nritem = DtGConsulta.Rows[e.RowIndex].Cells[10].Value.ToString();
                    iditemedital = int.Parse(DtGConsulta.Rows[e.RowIndex].Cells[7].Value.ToString());
                    vladitivo = Convert.ToDecimal(DtGConsulta.Rows[e.RowIndex].Cells[9].Value.ToString());
                    lote = int.Parse(DtGConsulta.Rows[e.RowIndex].Cells[11].Value.ToString());
                    idrealinhamento =int.Parse(DtGConsulta.Rows[e.RowIndex].Cells[8].Value.ToString());
                    qtde = int.Parse(DtGConsulta.Rows[e.RowIndex].Cells[12].Value.ToString());
                    vlvenda = Convert.ToDecimal(DtGConsulta.Rows[e.RowIndex].Cells[13].Value.ToString());
                    idedital = int.Parse(DtGConsulta.Rows[e.RowIndex].Cells[14].Value.ToString());
                   codedital = DtGConsulta.Rows[e.RowIndex].Cells[15].Value.ToString();
                    ViewEmpenho add = new ViewEmpenho(this);
                    this.Close();
                    add.Show();


                }
            }





        }

        private void txtpesquisa_TextChanged(object sender, EventArgs e)
        {
            carregarGrid();
        }

        private void BtnSair_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void BtnAdd_Click(object sender, EventArgs e)
        {
            DtGConsulta.DataSource = null;
            txtpesquisa.Text = "";
            txtpesquisa.Focus();
        }
    }
}
