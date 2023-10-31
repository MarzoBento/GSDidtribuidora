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
    public partial class ViewPrecoItens : Form
    {
        public string nomeFor = "ViewPrecoItens";

        public ViewPrecoItens()
        {
            InitializeComponent();
        }
        public ViewPrecoItens(ConsGerarCotacao frm) : this()
        {
            Convert.ToString(frm.codedital);
            RetronarCarregarLicitacao(Convert.ToString(frm.codedital));
            carregarGridItens();



        }

        private void RetronarCarregarLicitacao(string edital)
        {
            SqlConnection Cnn = Banco.CriarConexao();
            SqlDataAdapter sql = new SqlDataAdapter("Select LancEditais.nlicitacao,(CAST(LancEditais.nlicitacao AS VARCHAR(10))) + '               ' + (Modalidade.nome + '                    ' +  LancEditais.nlicitacao + '                        ' + " +
                "LancEditais.nprocesso + '                       ' + CONVERT(CHAR,LancEditais.dtabertura,103)) + '  ' + Cliente.nome as Licitacao  from LancEditais,Modalidade,Cliente " +
                " WHERE LancEditais.idmodalidade = Modalidade.idmodalidade and LancEditais.idcliente =  Cliente.idcliente AND LancEditais.nlicitacao='" + edital + "'", Cnn);
            DataSet Dt = new DataSet();
            sql.Fill(Dt);
            BindingSource bs = new BindingSource();
            bs.DataSource = Dt;
            bs.DataMember = Dt.Tables[0].TableName;

            try
            {
                this.cboprocesso.DataSource = bs;
                this.cboprocesso.DisplayMember = "Licitacao";
                this.cboprocesso.ValueMember = "nlicitacao";
                this.cboprocesso.SelectedIndex = cboprocesso.Items.Count - 1;



            }
            catch (Exception erro)
            {

                throw erro;
            }
            Cnn.Close();
        }

        private void cboprocesso_Click(object sender, EventArgs e)
        {
            //CarregarProcesso();
        }


        DataGridViewCheckBoxColumn chkb = new DataGridViewCheckBoxColumn();

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
                string strConn = "Select DISTINCT Concorrente.idconcorrente as Cod, Concorrente.nome as Concorrente ,sum(MapaPreco.precoganho * MapaPreco.qtde) as Valor_Produtos_Ganhos " +
                " FROM MapaPreco, Concorrente WHERE MapaPreco.idconcorrente = Concorrente.idconcorrente AND MapaPreco.edital='" + cboprocesso.SelectedValue + "'GROUP BY  Concorrente.idconcorrente , Concorrente.nome";
               


                SqlDataAdapter da = new SqlDataAdapter(strConn, Conn);
                da.Fill(ds);


            }

            this.griditens.RowsDefaultCellStyle.BackColor = Color.LightBlue;
            this.griditens.AlternatingRowsDefaultCellStyle.BackColor = Color.Azure;


            griditens.AutoGenerateColumns = false;
            //exibe os dados no datagridview
            griditens.DataSource = ds;
            griditens.Columns.Clear();
            griditens.Columns.Add(chkb);
            chkb.HeaderText = "Sel";
            chkb.Name = "chkb";
            griditens.Columns.Add("Cod", "Cod");
            griditens.Columns.Add("Concorrente", "Concorrente");
            griditens.Columns.Add("Valor_Produtos_Ganhos", "Valor_Produtos_Ganhos");

            griditens.Columns[0].Width = 50;
            griditens.Columns[1].Width = 50;
            griditens.Columns[2].Width = 805;
            griditens.Columns[3].Width = 150;

            griditens.Columns[3].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;


            griditens.Columns[1].DataPropertyName = "Cod";
            griditens.Columns[2].DataPropertyName = "Concorrente";
            griditens.Columns[3].DataPropertyName = "Valor_Produtos_Ganhos";


            griditens.Columns[3].DefaultCellStyle.Format = "n2";

            griditens.Refresh();


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
                string strConn = "Select DISTINCT Concorrente.idconcorrente as Cod, Concorrente.nome as Concorrente ,sum(MapaPreco.precoganho * MapaPreco.qtde) as Valor_Produtos_Ganhos " +
                " FROM MapaPreco, Concorrente WHERE MapaPreco.idconcorrente = Concorrente.idconcorrente AND Concorrente.nome Like'%" + txtpesquisa.Text + "%' GROUP BY  Concorrente.idconcorrente , Concorrente.nome";



                SqlDataAdapter da = new SqlDataAdapter(strConn, Conn);
                da.Fill(ds);


            }

            this.griditens.RowsDefaultCellStyle.BackColor = Color.LightBlue;
            this.griditens.AlternatingRowsDefaultCellStyle.BackColor = Color.Azure;


            griditens.AutoGenerateColumns = false;
            //exibe os dados no datagridview
            griditens.DataSource = ds;
            griditens.Columns.Clear();
            griditens.Columns.Add(chkb);
            chkb.HeaderText = "Sel";
            chkb.Name = "chkb";
            griditens.Columns.Add("Cod", "Cod");
            griditens.Columns.Add("Concorrente", "Concorrente");
            griditens.Columns.Add("Valor_Produtos_Ganhos", "Valor_Produtos_Ganhos");

            griditens.Columns[0].Width = 50;
            griditens.Columns[1].Width = 50;
            griditens.Columns[2].Width = 805;
            griditens.Columns[3].Width = 150;

            griditens.Columns[3].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;


            griditens.Columns[1].DataPropertyName = "Cod";
            griditens.Columns[2].DataPropertyName = "Concorrente";
            griditens.Columns[3].DataPropertyName = "Valor_Produtos_Ganhos";


            griditens.Columns[3].DefaultCellStyle.Format = "n2";

            griditens.Refresh();


        }


        private void carregarGridPesquisa( int codconcorrente)
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
                string strConn = "Select ItemsLicitacao.nritem as NºItem,ItemsLicitacao.lote as Lote,Produto.nome as Descricao,UnidadeMedida.nome as Unidade, MapaPreco.precoganho as Preço," +
                    "ItemsLicitacao.qtde as Qtde,(MapaPreco.precoganho * ItemsLicitacao.qtde ) as VlTotal " +
                " from ItemsLicitacao INNER JOIN MapaPreco ON ItemsLicitacao.iditemedital = MapaPreco.iditemedital INNER JOIN Concorrente ON MapaPreco.idconcorrente = Concorrente.idconcorrente,Produto,UnidadeMedida " +
                " WHERE MapaPreco.precoganho = (SELECT MIN( MapaPreco.precoganho) FROM MapaPreco where MapaPreco.idconcorrente=" + codconcorrente + " AND ItemsLicitacao.iditemedital = MapaPreco.iditemedital)" +
                " AND Produto.idproduto = ItemsLicitacao.idproduto AND ItemsLicitacao.idunidade = UnidadeMedida.idunidade   GROUP BY ItemsLicitacao.nritem ,ItemsLicitacao.lote," +
                " Produto.nome ,UnidadeMedida.nome, MapaPreco.precoganho,ItemsLicitacao.qtde";


                SqlDataAdapter da = new SqlDataAdapter(strConn, Conn);
                da.Fill(ds);


            }

            this.griditensultimo.RowsDefaultCellStyle.BackColor = Color.LightBlue;
            this.griditensultimo.AlternatingRowsDefaultCellStyle.BackColor = Color.Azure;


            griditensultimo.AutoGenerateColumns = false;
            //exibe os dados no datagridview
            griditensultimo.DataSource = ds;
            griditensultimo.Columns.Clear();
            griditensultimo.Columns.Add("NºItem", "NºItem");
            griditensultimo.Columns.Add("Lote", "Lote");
            griditensultimo.Columns.Add("Descricao", "Descricao");
            griditensultimo.Columns.Add("Unidade", "Unidade");
            griditensultimo.Columns.Add("Preço", "Preço");
            griditensultimo.Columns.Add("Qtde", "Qtde");
            griditensultimo.Columns.Add("VlTotal", "VlTotal");

         
            griditensultimo.Columns[0].Width = 60;
            griditensultimo.Columns[1].Width = 60;
            griditensultimo.Columns[2].Width = 480;
            griditensultimo.Columns[3].Width = 170;
            griditensultimo.Columns[4].Width = 90;
            griditensultimo.Columns[5].Width = 90;
            griditensultimo.Columns[6].Width = 100;


            griditensultimo.Columns[4].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight ;
            griditensultimo.Columns[5].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            griditensultimo.Columns[6].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;

            griditensultimo.Columns[4].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleRight;
            griditensultimo.Columns[5].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
            griditensultimo.Columns[6].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleRight;


            griditensultimo.Columns[0].DataPropertyName = "NºItem";
            griditensultimo.Columns[1].DataPropertyName = "Lote";
            griditensultimo.Columns[2].DataPropertyName = "Descricao";
            griditensultimo.Columns[3].DataPropertyName = "Unidade";
            griditensultimo.Columns[4].DataPropertyName = "Preço";
            griditensultimo.Columns[5].DataPropertyName = "Qtde";
            griditensultimo.Columns[6].DataPropertyName = "VlTotal";


            griditensultimo.Columns[6].DefaultCellStyle.Format = "n2";

        }

        private void btnPesquisar_Click(object sender, EventArgs e)
        {
            ConsGerarCotacao frmconv = new ConsGerarCotacao(this);
            this.Close();
            frmconv.Show();
            //if (cboprocesso.Text != "")
            //{
            //    carregarGridItens();
            //}
            //else
            //{
            //    MessageBox.Show("Informe o Nº do Edital !");
            //}
        }

        private void griditens_CellClick(object sender, DataGridViewCellEventArgs e)
        {

            if (e.RowIndex >= 0 && e.ColumnIndex == 0)
            {

                int codii = Convert.ToInt32(griditens.CurrentRow.Cells[1].Value);
                carregarGridPesquisa(codii);
                //Loop and uncheck all other CheckBoxes.
                foreach (DataGridViewRow row in griditens.Rows)
                {

                    if (row.Index == e.RowIndex)
                    {
                        row.Cells["chkb"].Value = !Convert.ToBoolean(row.Cells["chkb"].EditedFormattedValue);

                    }
                    else
                    {
                        row.Cells["chkb"].Value = false;
                    }
                }
            }


        }

        private void BtnSair_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void BtnNovo_Click(object sender, EventArgs e)
        {
          // cboprocesso.SelectedIndex = -1;
            griditens.DataSource = null;
            griditensultimo.DataSource = null;

        }

        private void txtpesquisa_TextChanged(object sender, EventArgs e)
        {
            carregarGridPesquisa();
        }

        private void button1_Click(object sender, EventArgs e)
        {
         
        }
    }
}
