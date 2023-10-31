using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Prj_Cientifica
{
    public partial class ViewRetornoFornecedores : Form
    {
        public static string TipoGravacao;
        public static int UltimoSelecionado;
        public int casas;

        public string nomeFor = "ViewRetornoFornecedores";
        public ViewRetornoFornecedores()
        {
            InitializeComponent();
        }


        public ViewRetornoFornecedores(ConsGerarCotacao frm) : this()
        {
            UltimoSelecionado = Convert.ToInt32(frm.codedital);
            RetReg();


        }


        private void RetReg()
        {
            string reg = "Select DISTINCT ItemsLicitacao.iditemedital as Cod,ItemsLicitacao.nritem as NºItem,ItemsLicitacao.lote as Lote,CONVERT(varchar(10),ItemsLicitacao.nritem) + ' - ' + PrincipioAtivo.nome as PrincipioAtivo, UnidadeMedida.nome as Unidade,ItemsLicitacao.qtde as Qtde, " +
                    "RetCotacao.preco as Preco,RetCotacao.desconto as Desconto, RetCotacao.repasse as Repasse, RetCotacao.Ipi as Ipi, RetCotacao.frete as Frete, RetCotacao.liquido as Liquido,RetCotacao.vltotal as VlTotal,RetCotacao.idedital as Edital,LancEditais.casasdecimais " +
                " from ItemsLicitacao LEFT JOIN RetCotacao ON ItemsLicitacao.iditemedital = RetCotacao.iditemedital ,UnidadeMedida,PrincipioAtivo,Produto,Fornecedor,LancEditais Where LancEditais.idedital = ItemsLicitacao.idedital AND " +
                "Produto.idprincipio = PrincipioAtivo.idprincipio AND ItemsLicitacao.idprincipio = PrincipioAtivo.idprincipio AND ItemsLicitacao.idunidade = UnidadeMedida.idunidade AND " +
                "Produto.idproduto = ItemsLicitacao.idproduto  AND LancEditais.idedital=" + UltimoSelecionado + " Order by ItemsLicitacao.nritem ";

            DataTable ds = new DataTable();
            SqlConnection Conn = Banco.CriarConexao();
            Conn.Open();

            if (Conn.State == ConnectionState.Open)
            {
                SqlCommand cmd = new SqlCommand(reg, Conn);
                SqlDataReader dr = cmd.ExecuteReader();
                if (dr.Read())
                {

                    if (!String.IsNullOrEmpty(dr["casasdecimais"].ToString()))
                    {

                        casas = Convert.ToInt32(dr["casasdecimais"].ToString());


                        if (casas == 2)
                        {
                            rbt2casas.Checked = true;
                        }
                        else if (casas == 3)
                        {

                            rbt3casas.Checked = true;
                        }
                        else if (casas == 4)
                        {

                            rbt4casas.Checked = true;
                        }
                        else if (casas == 5)
                        {

                            rbt5casas.Checked = true;
                        }
                        else if (casas == 6)
                        {

                            rbt6casas.Checked = true;
                        }
                    }

                    RetronarCarregarLicitacao(UltimoSelecionado);
                    carregarGridItensTodo();

                }
            }
        }

        private void RetronarCarregarLicitacao(int retgercot)
        {
            SqlConnection Cnn = Banco.CriarConexao();
            SqlDataAdapter sql = new SqlDataAdapter("Select LancEditais.idedital,LancEditais.nlicitacao,(CAST(LancEditais.nlicitacao AS VARCHAR(10))) + '               ' + (Modalidade.nome + '                    ' +  LancEditais.nlicitacao + '                        ' + " +
                "LancEditais.nprocesso + '                       ' + CONVERT(CHAR,LancEditais.dtabertura,103) + '          ' + Cliente.nome) as Licitacao  from LancEditais,Modalidade,Cliente " +
                " WHERE LancEditais.idmodalidade = Modalidade.idmodalidade and LancEditais.idcliente =  Cliente.idcliente and LancEditais.idedital=" + retgercot + "", Cnn);
            DataSet Dt = new DataSet();
            sql.Fill(Dt);
            BindingSource bs = new BindingSource();
            bs.DataSource = Dt;
            bs.DataMember = Dt.Tables[0].TableName;

            try
            {
                this.cbolicitacao.DataSource = bs;
                this.cbolicitacao.DisplayMember = "Licitacao";
                this.cbolicitacao.ValueMember = "idedital";
                this.cbolicitacao.SelectedIndex = cbolicitacao.Items.Count - 1;




            }
            catch (Exception erro)
            {

                throw erro;
            }
            Cnn.Close();
        }



        private void CarregarLicitacao()
        {
            SqlConnection Cnn = Banco.CriarConexao();
            SqlDataAdapter sql = new SqlDataAdapter("Select LancEditais.idedital,LancEditais.nlicitacao,(CAST(LancEditais.nlicitacao AS VARCHAR(10))) + '               ' + (Modalidade.nome + '                    ' +  LancEditais.nlicitacao + '                        ' + " +
                "LancEditais.nprocesso + '                       ' + CONVERT(CHAR,LancEditais.dtabertura,103) + '          ' + Cliente.nome) as Licitacao  from LancEditais,Modalidade,Cliente " +
                " WHERE LancEditais.idmodalidade = Modalidade.idmodalidade and LancEditais.idcliente =  Cliente.idcliente ", Cnn);
            DataSet Dt = new DataSet();
            sql.Fill(Dt);
            BindingSource bs = new BindingSource();
            bs.DataSource = Dt;
            bs.DataMember = Dt.Tables[0].TableName;

            try
            {
                this.cbolicitacao.DataSource = bs;
                this.cbolicitacao.DisplayMember = "Licitacao";
                this.cbolicitacao.ValueMember = "idedital";
                this.cbolicitacao.SelectedIndex = cbolicitacao.Items.Count - 1;



            }
            catch (Exception erro)
            {

                throw erro;
            }
            Cnn.Close();
        }


        private void chkFornecedor_CheckedChanged(object sender, EventArgs e)
        {
            if (chkFornecedor.Checked == true)
            {
                cbofornecedor.Enabled = true;
                txtnritem.Enabled = false;
                cbofornecedor.Focus();
                txtnritem.Text = "";

            }

        }
        public Decimal valor;
        DataGridViewCheckBoxColumn chkb = new DataGridViewCheckBoxColumn();
        private void carregarGridItensFor(int codfor)
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
                string strConn = "Select DISTINCT  ItemsLicitacao.iditemedital as Cod,ItemsLicitacao.nritem as NºItem,ItemsLicitacao.lote as Lote,CONVERT(varchar(10),ItemsLicitacao.nritem) + ' - ' + Produto.nome + ' - ' + Produto.Apresentacao + ' - ' + Fornecedor.nome as Item_Apresentação, UnidadeMedida.nome as Unidade,ItemsLicitacao.qtde as Qtde, " +
                    "RetCotacao.preco as Preco,RetCotacao.desconto as Desconto, RetCotacao.repasse as Repasse, RetCotacao.Ipi as Ipi, RetCotacao.frete as Frete, RetCotacao.liquido as Liquido,RetCotacao.vltotal as VlTotal," +
                    "RetCotacao.idproduto as codprod,RetCotacao.idfornecedor, Fornecedor.nome as Fornecedor, LancEditais.nlicitacao  " +
                " from ItemsLicitacao LEFT JOIN RetCotacao ON ItemsLicitacao.iditemedital = RetCotacao.iditemedital ,UnidadeMedida,PrincipioAtivo,Produto,Fornecedor,LancEditais,Produto_Fornecedor   " +
                "Where Produto_Fornecedor.idfornecedor = Fornecedor.idfornecedor And  LancEditais.idedital = ItemsLicitacao.idedital AND Produto.idprincipio = PrincipioAtivo.idprincipio AND  " +
                "ItemsLicitacao.idproduto = Produto.idproduto AND ItemsLicitacao.idunidade = UnidadeMedida.idunidade AND  RetCotacao.idfornecedor = Fornecedor.idfornecedor AND " +
                "ItemsLicitacao.idproduto = Produto.idproduto AND RetCotacao.idfornecedor=" + codfor + "  AND ItemsLicitacao.idedital=" + cbolicitacao.SelectedValue + " Order by ItemsLicitacao.nritem";


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
            griditens.Columns.Add("NºItem", "NºItem");
            griditens.Columns.Add("Item_Apresentação", "Item_Apresentação");
            griditens.Columns.Add("Qtde", "Qtde");
            griditens.Columns.Add("Preco", "Preco");
            griditens.Columns.Add("Unidade", "Unidade");
            griditens.Columns.Add("Desconto", "Desconto");
            griditens.Columns.Add("Repasse", "Repasse");
            griditens.Columns.Add("Ipi", "Ipi");
            griditens.Columns.Add("Frete", "Frete");
            griditens.Columns.Add("Liquido", "Liquido");
            griditens.Columns.Add("VlTotal", "VlTotal");
            griditens.Columns.Add("codprod", "codprod");
            griditens.Columns.Add("idfornecedor", "idfornecedor");
            griditens.Columns.Add("Fornecedor", "Fornecedor");
            griditens.Columns.Add("nlicitacao", "nlicitacao");


            griditens.Columns[0].Width = 50;
            griditens.Columns[1].Visible = false;
            griditens.Columns[2].Width = 60;
            griditens.Columns[3].Width = 400;
            griditens.Columns[4].Width = 70;
            griditens.Columns[5].Width = 82;
            griditens.Columns[6].Width = 120;
            griditens.Columns[7].Width = 75;
            griditens.Columns[8].Width = 80;
            griditens.Columns[9].Width = 75;
            griditens.Columns[10].Width = 75;
            griditens.Columns[11].Width = 80;
            griditens.Columns[12].Width = 118;
            griditens.Columns[13].Visible = false;
            griditens.Columns[14].Visible = false;
            griditens.Columns[15].Visible = false;
            griditens.Columns[16].Visible = false;

            griditens.Columns[1].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft;
            griditens.Columns[5].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft;
            griditens.Columns[4].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft;
            griditens.Columns[10].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            griditens.Columns[11].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            griditens.Columns[12].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;

            griditens.Columns[1].DataPropertyName = "Cod";
            griditens.Columns[2].DataPropertyName = "NºItem";
            griditens.Columns[3].DataPropertyName = "Item_Apresentação";
            griditens.Columns[4].DataPropertyName = "Qtde";
            griditens.Columns[5].DataPropertyName = "Preco";
            griditens.Columns[6].DataPropertyName = "Unidade";
            griditens.Columns[7].DataPropertyName = "Desconto";
            griditens.Columns[8].DataPropertyName = "Repasse";
            griditens.Columns[9].DataPropertyName = "Ipi";
            griditens.Columns[10].DataPropertyName = "Frete";
            griditens.Columns[11].DataPropertyName = "Liquido";
            griditens.Columns[12].DataPropertyName = "VlTotal";
            griditens.Columns[13].DataPropertyName = "codprod";
            griditens.Columns[14].DataPropertyName = "idfornecedor";
            griditens.Columns[15].DataPropertyName = "Fornecedor";
            griditens.Columns[16].DataPropertyName = "nlicitacao";


            griditens.Columns[7].DefaultCellStyle.Format = "#.00\\%";
            griditens.Columns[8].DefaultCellStyle.Format = "#.00\\%";
            griditens.Columns[9].DefaultCellStyle.Format = "#.00\\%";
            griditens.Columns[10].DefaultCellStyle.Format = "#.00\\%";

            //griditens.Columns[11].DefaultCellStyle.Format = "c";
            griditens.Columns[12].DefaultCellStyle.Format = "c";




            foreach (DataGridViewRow linha in griditens.Rows)
            {
                if ((linha.Cells[4].Value.ToString() == ""))
                {

                    linha.Cells[4].Value = 0;
                }
                else if ((linha.Cells[5].Value.ToString() == ""))
                {

                    linha.Cells[5].Value = 0;

                }
                else if ((linha.Cells[7].Value.ToString() == ""))
                {

                    linha.Cells[7].Value = 0;

                }
                else if ((linha.Cells[8].Value.ToString() == ""))
                {

                    linha.Cells[8].Value = 0;

                }
                else if ((linha.Cells[9].Value.ToString() == ""))
                {

                    linha.Cells[9].Value = 0;

                }
                else if ((linha.Cells[10].Value.ToString() == ""))
                {

                    linha.Cells[10].Value = 0;

                }
                else if ((linha.Cells[11].Value.ToString() == ""))
                {

                    linha.Cells[11].Value = 0;

                }
                else if ((linha.Cells[12].Value.ToString() == ""))
                {

                    linha.Cells[12].Value = 0;

                }

            }

            if (casas == 2)
            {


                griditens.Columns[7].DefaultCellStyle.Format = "#.00\\%";
                griditens.Columns[8].DefaultCellStyle.Format = "#.00\\%";
                griditens.Columns[9].DefaultCellStyle.Format = "#.00\\%";
                griditens.Columns[10].DefaultCellStyle.Format = "#.00\\%";
                griditens.Columns[11].DefaultCellStyle.Format = "n2";
                griditens.Columns[12].DefaultCellStyle.Format = "n2";
                griditens.Columns[5].DefaultCellStyle.Format = "n2";
            }
            else if (casas == 3)
            {


                griditens.Columns[7].DefaultCellStyle.Format = "#.00\\%";
                griditens.Columns[8].DefaultCellStyle.Format = "#.00\\%";
                griditens.Columns[9].DefaultCellStyle.Format = "#.00\\%";
                griditens.Columns[10].DefaultCellStyle.Format = "#.00\\%";
                griditens.Columns[11].DefaultCellStyle.Format = "n3";
                griditens.Columns[12].DefaultCellStyle.Format = "n2";
                griditens.Columns[5].DefaultCellStyle.Format = "n3";



            }
            else if (casas == 4)
            {

                griditens.Columns[7].DefaultCellStyle.Format = "#.00\\%";
                griditens.Columns[8].DefaultCellStyle.Format = "#.00\\%";
                griditens.Columns[9].DefaultCellStyle.Format = "#.00\\%";
                griditens.Columns[10].DefaultCellStyle.Format = "#.00\\%";
                griditens.Columns[11].DefaultCellStyle.Format = "n4";
                griditens.Columns[12].DefaultCellStyle.Format = "n2";
                griditens.Columns[5].DefaultCellStyle.Format = "n4";




            }
            else if (casas == 5)
            {

                griditens.Columns[7].DefaultCellStyle.Format = "#.00\\%";
                griditens.Columns[8].DefaultCellStyle.Format = "#.00\\%";
                griditens.Columns[9].DefaultCellStyle.Format = "#.00\\%";
                griditens.Columns[10].DefaultCellStyle.Format = "#.00\\%";
                griditens.Columns[11].DefaultCellStyle.Format = "n5";
                griditens.Columns[12].DefaultCellStyle.Format = "n2";
                griditens.Columns[5].DefaultCellStyle.Format = "n5";




            }
            else if (casas == 6)
            {

                griditens.Columns[7].DefaultCellStyle.Format = "#.00\\%";
                griditens.Columns[8].DefaultCellStyle.Format = "#.00\\%";
                griditens.Columns[9].DefaultCellStyle.Format = "#.00\\%";
                griditens.Columns[10].DefaultCellStyle.Format = "#.00\\%";
                griditens.Columns[11].DefaultCellStyle.Format = "n6";
                griditens.Columns[12].DefaultCellStyle.Format = "n2";
                griditens.Columns[5].DefaultCellStyle.Format = "n6";




            }


            valor = 0;

            foreach (DataGridViewRow linha in griditens.Rows)
            {
                if ((linha.Cells[12].Value != DBNull.Value))
                {

                    valor += Convert.ToDecimal(linha.Cells[12].Value);
                }

            }


            Decimal valort = valor;
            string convertido = String.Format("{0:N2}", valort);
            labTotal.Text = convertido;

            Int32 total = 0;

            foreach (DataGridViewRow linhatotal in griditens.Rows)
            {
                total = total + 1;
            }

            this.txttotalitens.Text = Convert.ToString(total);



            griditens.Refresh();


        }

        private void carregarGridItensTodo()
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
                string strConn = "Select DISTINCT ItemsLicitacao.iditemedital as Cod,ItemsLicitacao.nritem as NºItem,ItemsLicitacao.lote as Lote,CONVERT(varchar(10),ItemsLicitacao.nritem) + ' - ' + Produto.nome + ' - ' + Produto.Apresentacao + ' - ' + Fornecedor.nome as Item_Apresentação, UnidadeMedida.nome as Unidade,ItemsLicitacao.qtde as Qtde, " +
                    "RetCotacao.preco as Preco,RetCotacao.desconto as Desconto, RetCotacao.repasse as Repasse, RetCotacao.Ipi as Ipi, RetCotacao.frete as Frete, RetCotacao.liquido as Liquido,RetCotacao.vltotal as VlTotal,RetCotacao.idproduto as codprod,RetCotacao.idfornecedor," +
                    "Fornecedor.nome as Fornecedor,LancEditais.nlicitacao" +
                " from ItemsLicitacao LEFT JOIN RetCotacao ON ItemsLicitacao.iditemedital = RetCotacao.iditemedital ,UnidadeMedida,PrincipioAtivo,Produto,Fornecedor,LancEditais Where LancEditais.idedital = ItemsLicitacao.idedital AND " +
                "Produto.idprincipio = PrincipioAtivo.idprincipio AND ItemsLicitacao.idprincipio = PrincipioAtivo.idprincipio AND ItemsLicitacao.idunidade = UnidadeMedida.idunidade AND RetCotacao.idfornecedor = Fornecedor.idfornecedor AND " +
                "Produto.idproduto = ItemsLicitacao.idproduto  AND LancEditais.idedital=" + UltimoSelecionado + " Order by ItemsLicitacao.nritem ";


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
            griditens.Columns.Add("NºItem", "NºItem");
            griditens.Columns.Add("Item_Apresentação", "Item_Apresentação");
            griditens.Columns.Add("Qtde", "Qtde");
            griditens.Columns.Add("Preco", "Preco");
            griditens.Columns.Add("Unidade", "Unidade");
            griditens.Columns.Add("Desconto", "Desconto");
            griditens.Columns.Add("Repasse", "Repasse");
            griditens.Columns.Add("Ipi", "Ipi");
            griditens.Columns.Add("Frete", "Frete");
            griditens.Columns.Add("Liquido", "Liquido");
            griditens.Columns.Add("VlTotal", "VlTotal");
            griditens.Columns.Add("codprod", "codprod");
            griditens.Columns.Add("idfornecedor", "idfornecedor");
            griditens.Columns.Add("Fornecedor", "Fornecedor");
            griditens.Columns.Add("nlicitacao", "nlicitacao");



            griditens.Columns[0].Width = 50;
            griditens.Columns[1].Visible = false;
            griditens.Columns[2].Width = 60;
            griditens.Columns[3].Width = 400;
            griditens.Columns[4].Width = 70;
            griditens.Columns[5].Width = 82;
            griditens.Columns[6].Width = 120;
            griditens.Columns[7].Width = 75;
            griditens.Columns[8].Width = 80;
            griditens.Columns[9].Width = 75;
            griditens.Columns[10].Width = 75;
            griditens.Columns[11].Width = 80;
            griditens.Columns[12].Width = 118;
            griditens.Columns[13].Visible = false;
            griditens.Columns[14].Visible = false;
            griditens.Columns[15].Visible = false;
            griditens.Columns[16].Visible = false;


            griditens.Columns[1].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft;
            griditens.Columns[5].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft;
            griditens.Columns[4].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft;
            griditens.Columns[10].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            griditens.Columns[11].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            griditens.Columns[12].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;

            griditens.Columns[1].DataPropertyName = "Cod";
            griditens.Columns[2].DataPropertyName = "NºItem";
            griditens.Columns[3].DataPropertyName = "Item_Apresentação";
            griditens.Columns[4].DataPropertyName = "Qtde";
            griditens.Columns[5].DataPropertyName = "Preco";
            griditens.Columns[6].DataPropertyName = "Unidade";
            griditens.Columns[7].DataPropertyName = "Desconto";
            griditens.Columns[8].DataPropertyName = "Repasse";
            griditens.Columns[9].DataPropertyName = "Ipi";
            griditens.Columns[10].DataPropertyName = "Frete";
            griditens.Columns[11].DataPropertyName = "Liquido";
            griditens.Columns[12].DataPropertyName = "VlTotal";
            griditens.Columns[13].DataPropertyName = "codprod";
            griditens.Columns[14].DataPropertyName = "idfornecedor";
            griditens.Columns[15].DataPropertyName = "Fornecedor";
            griditens.Columns[16].DataPropertyName = "nlicitacao";


            foreach (DataGridViewRow linha in griditens.Rows)
            {


                if ((linha.Cells[4].Value.ToString() == ""))
                {

                    linha.Cells[4].Value = 0;
                }
                if (String.IsNullOrEmpty((linha.Cells[5].Value.ToString())))
                {


                    linha.Cells[5].Value = 0;

                }
                if (String.IsNullOrEmpty((linha.Cells[7].Value.ToString())))
                {

                    linha.Cells[7].Value = 0;

                }
                if (String.IsNullOrEmpty((linha.Cells[8].Value.ToString())))
                {

                    linha.Cells[8].Value = 0;

                }
                if (String.IsNullOrEmpty((linha.Cells[9].Value.ToString())))
                {

                    linha.Cells[9].Value = 0;

                }
                if (String.IsNullOrEmpty((linha.Cells[10].Value.ToString())))
                {

                    linha.Cells[10].Value = 0;

                }
                if (String.IsNullOrEmpty((linha.Cells[11].Value.ToString())))
                {

                    linha.Cells[11].Value = 0;

                }
                if (String.IsNullOrEmpty((linha.Cells[12].Value.ToString())))
                {

                    linha.Cells[12].Value = 0;

                }

            }

            if (casas == 2)
            {


                griditens.Columns[7].DefaultCellStyle.Format = "#.00\\%";
                griditens.Columns[8].DefaultCellStyle.Format = "#.00\\%";
                griditens.Columns[9].DefaultCellStyle.Format = "#.00\\%";
                griditens.Columns[10].DefaultCellStyle.Format = "#.00\\%";
                griditens.Columns[11].DefaultCellStyle.Format = "n2";
                griditens.Columns[12].DefaultCellStyle.Format = "n2";
                griditens.Columns[5].DefaultCellStyle.Format = "n2";
            }
            else if (casas == 3)
            {


                griditens.Columns[7].DefaultCellStyle.Format = "#.00\\%";
                griditens.Columns[8].DefaultCellStyle.Format = "#.00\\%";
                griditens.Columns[9].DefaultCellStyle.Format = "#.00\\%";
                griditens.Columns[10].DefaultCellStyle.Format = "#.00\\%";
                griditens.Columns[11].DefaultCellStyle.Format = "n3";
                griditens.Columns[12].DefaultCellStyle.Format = "n2";
                griditens.Columns[5].DefaultCellStyle.Format = "n3";



            }
            else if (casas == 4)
            {

                griditens.Columns[7].DefaultCellStyle.Format = "#.00\\%";
                griditens.Columns[8].DefaultCellStyle.Format = "#.00\\%";
                griditens.Columns[9].DefaultCellStyle.Format = "#.00\\%";
                griditens.Columns[10].DefaultCellStyle.Format = "#.00\\%";
                griditens.Columns[11].DefaultCellStyle.Format = "n4";
                griditens.Columns[12].DefaultCellStyle.Format = "n2";
                griditens.Columns[5].DefaultCellStyle.Format = "n4";




            }
            else if (casas == 5)
            {

                griditens.Columns[7].DefaultCellStyle.Format = "#.00\\%";
                griditens.Columns[8].DefaultCellStyle.Format = "#.00\\%";
                griditens.Columns[9].DefaultCellStyle.Format = "#.00\\%";
                griditens.Columns[10].DefaultCellStyle.Format = "#.00\\%";
                griditens.Columns[11].DefaultCellStyle.Format = "n5";
                griditens.Columns[12].DefaultCellStyle.Format = "n2";
                griditens.Columns[5].DefaultCellStyle.Format = "n5";




            }
            else if (casas == 6)
            {

                griditens.Columns[7].DefaultCellStyle.Format = "#.00\\%";
                griditens.Columns[8].DefaultCellStyle.Format = "#.00\\%";
                griditens.Columns[9].DefaultCellStyle.Format = "#.00\\%";
                griditens.Columns[10].DefaultCellStyle.Format = "#.00\\%";
                griditens.Columns[11].DefaultCellStyle.Format = "n6";
                griditens.Columns[12].DefaultCellStyle.Format = "n2";
                griditens.Columns[5].DefaultCellStyle.Format = "n6";




            }





            valor = 0;

            foreach (DataGridViewRow linha in griditens.Rows)
            {
                if ((linha.Cells[12].Value != DBNull.Value))
                {

                    valor += Convert.ToDecimal(linha.Cells[12].Value);
                }

            }


            Decimal valort = valor;
            string convertido = String.Format("{0:N2}", valort);
            labTotal.Text = convertido;




            Int32 total = 0;

            foreach (DataGridViewRow linhatotal in griditens.Rows)
            {
                total = total + 1;
            }

            this.txttotalitens.Text = Convert.ToString(total);


            griditens.Refresh();


        }



        private void cbolicitacao_Click(object sender, EventArgs e)
        {
            CarregarLicitacao();
        }

        private void chkItem_CheckedChanged(object sender, EventArgs e)
        {
            if (chkItem.Checked == true)
            {
                cbofornecedor.Enabled = false;
                txtnritem.Enabled = true;
                txtnritem.Focus();
                cbofornecedor.SelectedIndex = -1;

            }
        }



        private void CarregarFornecedor()
        {
            SqlConnection Cnn = Banco.CriarConexao();
            SqlDataAdapter sql = new SqlDataAdapter("Select DISTINCT Fornecedor.idfornecedor ,Fornecedor.nome  from ItemsLicitacao,Fornecedor,LancEditais,Produto_Fornecedor " +
                " WHERE Produto_Fornecedor.idfornecedor = Fornecedor.idfornecedor  and LancEditais.idedital=" + cbolicitacao.SelectedValue + "  Order by Fornecedor.nome ASC ", Cnn);
            DataSet Dt = new DataSet();
            sql.Fill(Dt);
            BindingSource bs = new BindingSource();
            bs.DataSource = Dt;
            bs.DataMember = Dt.Tables[0].TableName;

            try
            {
                this.cbofornecedor.DataSource = bs;
                this.cbofornecedor.DisplayMember = "nome";
                this.cbofornecedor.ValueMember = "idfornecedor";
                this.cbofornecedor.SelectedIndex = cbofornecedor.Items.Count - 1;



            }
            catch (Exception erro)
            {

                throw erro;
            }
            Cnn.Close();
        }

        private void cbofornecedor_Click(object sender, EventArgs e)
        {
            CarregarFornecedor();
        }

        private void cbofornecedor_SelectionChangeCommitted(object sender, EventArgs e)
        {
            carregarGridItensFor(Convert.ToInt32(cbofornecedor.SelectedValue));
        }

        private void griditens_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {
            if ((e.ColumnIndex == 5 && e.RowIndex != -1))
            {

                string valida5 = griditens.CurrentRow.Cells[5].Value.ToString();
                if (valida5 == "")
                {
                    griditens.CurrentRow.Cells[5].Value = 0;
                }

                double cell5 = Convert.ToDouble(griditens.CurrentRow.Cells[5].Value.ToString());
                double cell11 = Convert.ToDouble(griditens.CurrentRow.Cells[5].Value.ToString());
                double cell4 = Convert.ToDouble(griditens.CurrentRow.Cells[4].Value.ToString());
           



                string valida7 = griditens.CurrentRow.Cells[7].Value.ToString();
                if (valida7 == "")
                {
                    griditens.CurrentRow.Cells[7].Value = 0;
                }
                double desc = Convert.ToDouble(griditens.CurrentRow.Cells[7].Value);

                string valida8 = griditens.CurrentRow.Cells[8].Value.ToString();
                if (valida8 == "")
                {
                    griditens.CurrentRow.Cells[8].Value = 0;
                }
                double repasse = Convert.ToDouble(griditens.CurrentRow.Cells[8].Value);

                string valida9 = griditens.CurrentRow.Cells[9].Value.ToString();
                if (valida9 == "")
                {
                    griditens.CurrentRow.Cells[9].Value = 0;
                }

                double ipi = Convert.ToDouble(griditens.CurrentRow.Cells[9].Value);

                string valida10 = griditens.CurrentRow.Cells[10].Value.ToString();
                if (valida10 == "")
                {
                    griditens.CurrentRow.Cells[10].Value = 0;
                }
                double frete = Convert.ToDouble(griditens.CurrentRow.Cells[10].Value);
                string valida11 = griditens.CurrentRow.Cells[11].Value.ToString();
                if (valida11 == "")
                {
                    griditens.CurrentRow.Cells[11].Value = 0;
                }
               

                if (repasse.ToString() == "")
                {
                    repasse = 0;
                }
                if (ipi.ToString() == "")
                {
                    ipi = 0;
                }
                if (frete.ToString() == "")
                {
                    frete = 0;
                }
                if (cell11.ToString() == "")
                {
                    cell11 = 0;
                }


                if (cell4.ToString() != "" && cell5.ToString() != "")
                {

                    double freteliquido = cell5 * (frete / 100);
                    double fretenormal = cell4 * cell5 * (frete / 100);
                    double ipiliquido = cell5 * (ipi / 100);
                    double ipinormal = cell4 * cell5 * (ipi / 100);
                    double desliquido = cell5 * (desc / 100);
                    double repliquido = cell5 * (repasse / 100);
                    double desconto = cell4 * cell5 * (desc / 100);
                    double rep = cell4 * cell5 * (repasse / 100);



                    griditens.CurrentRow.Cells[11].Value = (Convert.ToDouble(griditens.CurrentRow.Cells[5].Value.ToString()) - desliquido - repliquido + ipiliquido + freteliquido);

                    griditens.CurrentRow.Cells[12].Value = (cell4 * cell5) - desconto - rep + ipinormal + fretenormal;




                    casasDecimais(Convert.ToDecimal(griditens.CurrentRow.Cells[12].Value));
                    // Convert.ToDouble(griditens.CurrentRow.Cells[11].Value.ToString());
                    //  casasDecimais(Convert.ToDecimal(griditens.CurrentRow.Cells[5].Value));
                    //SalvarDados();
                    //GravaTabelaPrecoVenda();
                    //GravaProposta();

                    valor = 0;

                    foreach (DataGridViewRow linha in griditens.Rows)
                    {
                        if ((linha.Cells[12].Value != DBNull.Value))
                        {

                            valor += Convert.ToDecimal(linha.Cells[12].Value);
                        }

                    }


                    Decimal valort = valor;
                    string convertido = String.Format("{0:N2}", Math.Round(valort, 2));
                    labTotal.Text = convertido;





                }
            }
            if ((e.RowIndex != -1 && e.ColumnIndex == 7))
            {

                string valida5 = griditens.CurrentRow.Cells[5].Value.ToString();
                if (valida5 == "")
                {
                    griditens.CurrentRow.Cells[5].Value = 0;
                }

                decimal cell5 = Convert.ToDecimal(griditens.CurrentRow.Cells[5].Value);
                decimal cell4 = Convert.ToDecimal(griditens.CurrentRow.Cells[4].Value);
                decimal desc = Convert.ToDecimal(griditens.CurrentRow.Cells[7].Value);
                string valida8 = griditens.CurrentRow.Cells[8].Value.ToString();
                if (valida8 == "")
                {
                    griditens.CurrentRow.Cells[8].Value = 0;
                }
                decimal repasse = Convert.ToDecimal(griditens.CurrentRow.Cells[8].Value);

                string valida9 = griditens.CurrentRow.Cells[9].Value.ToString();
                if (valida9 == "")
                {
                    griditens.CurrentRow.Cells[9].Value = 0;
                }
                decimal ipi = Convert.ToDecimal(griditens.CurrentRow.Cells[9].Value);
                string valida10 = griditens.CurrentRow.Cells[10].Value.ToString();
                if (valida10 == "")
                {
                    griditens.CurrentRow.Cells[10].Value = 0;
                }
                decimal frete = Convert.ToDecimal(griditens.CurrentRow.Cells[10].Value);
                string valida11 = griditens.CurrentRow.Cells[11].Value.ToString();
                if (valida8 == "")
                {
                    griditens.CurrentRow.Cells[11].Value = 0;
                }
                decimal cell11 = Convert.ToDecimal(griditens.CurrentRow.Cells[11].Value);

                if (repasse.ToString() == "")
                {
                    repasse = 0;
                }
                if (ipi.ToString() == "")
                {
                    ipi = 0;
                }
                if (frete.ToString() == "")
                {
                    frete = 0;
                }
                if (cell11.ToString() == "")
                {
                    cell11 = 0;
                }
                if (cell4.ToString() != "" && cell5.ToString() != "" && desc.ToString() != "")
                {


                    decimal freteliquido = cell5 * (frete / 100);
                    decimal fretenormal = cell4 * cell5 * (frete / 100);
                    decimal ipiliquido = cell5 * (ipi / 100);
                    decimal ipinormal = cell4 * cell5 * (ipi / 100);
                    decimal desliquido = cell5 * (desc / 100);
                    decimal repliquido = cell5 * (repasse / 100);
                    decimal desconto = cell4 * cell5 * (desc / 100);
                    decimal rep = cell4 * cell5 * (repasse / 100);

                    griditens.CurrentRow.Cells[11].Value = cell5 - desliquido - repliquido + ipiliquido + freteliquido;
                    griditens.CurrentRow.Cells[12].Value = (cell4 * cell5) - desconto - rep + ipinormal + fretenormal;



                    casasDecimais(Convert.ToDecimal(griditens.CurrentRow.Cells[12].Value));
                    // casasDecimais(Convert.ToDecimal(griditens.CurrentRow.Cells[11].Value));

                    valor = 0;

                    foreach (DataGridViewRow linha in griditens.Rows)
                    {
                        if ((linha.Cells[12].Value != DBNull.Value))
                        {

                            valor += Convert.ToDecimal(linha.Cells[12].Value);
                        }

                    }


                    Decimal valort = valor;
                    string convertido = String.Format("{0:N2}", Math.Round(valort, 2));
                    labTotal.Text = convertido;




                }
            }

            if ((e.RowIndex != -1 && e.ColumnIndex == 8))
            {

                string valida5 = griditens.CurrentRow.Cells[5].Value.ToString();
                if (valida5 == "")
                {
                    griditens.CurrentRow.Cells[5].Value = 0;
                }

                decimal cell5 = Convert.ToDecimal(griditens.CurrentRow.Cells[5].Value);
                decimal cell4 = Convert.ToDecimal(griditens.CurrentRow.Cells[4].Value);
                decimal desc = Convert.ToDecimal(griditens.CurrentRow.Cells[7].Value);

                string valida8 = griditens.CurrentRow.Cells[8].Value.ToString();
                if (valida8 == "")
                {
                    griditens.CurrentRow.Cells[8].Value = 0;
                }
                decimal repasse = Convert.ToDecimal(griditens.CurrentRow.Cells[8].Value);

                string valida9 = griditens.CurrentRow.Cells[9].Value.ToString();
                if (valida9 == "")
                {
                    griditens.CurrentRow.Cells[9].Value = 0;
                }
                decimal ipi = Convert.ToDecimal(griditens.CurrentRow.Cells[9].Value);
                string valida10 = griditens.CurrentRow.Cells[10].Value.ToString();
                if (valida10 == "")
                {
                    griditens.CurrentRow.Cells[10].Value = 0;
                }
                decimal frete = Convert.ToDecimal(griditens.CurrentRow.Cells[10].Value);
                string valida11 = griditens.CurrentRow.Cells[11].Value.ToString();
                if (valida8 == "")
                {
                    griditens.CurrentRow.Cells[11].Value = 0;
                }
                decimal cell11 = Convert.ToDecimal(griditens.CurrentRow.Cells[11].Value);

                if (repasse.ToString() == "")
                {
                    repasse = 0;
                }
                if (ipi.ToString() == "")
                {
                    ipi = 0;
                }
                if (frete.ToString() == "")
                {
                    frete = 0;
                }
                if (cell11.ToString() == "")
                {
                    cell11 = 0;
                }




                //decimal cell5 = Convert.ToDecimal(griditens.CurrentRow.Cells[5].Value);
                //decimal cell4 = Convert.ToDecimal(griditens.CurrentRow.Cells[4].Value);
                //decimal cell8 = Convert.ToDecimal(griditens.CurrentRow.Cells[8].Value);

                if (cell4.ToString() != "" && cell5.ToString() != "" && repasse.ToString() != "")
                {

                    decimal freteliquido = cell5 * (frete / 100);
                    decimal fretenormal = cell4 * cell5 * (frete / 100);
                    decimal ipiliquido = cell5 * (ipi / 100);
                    decimal ipinormal = cell4 * cell5 * (ipi / 100);
                    decimal desliquido = cell5 * (desc / 100);
                    decimal repliquido = cell5 * (repasse / 100);
                    decimal desconto = cell4 * cell5 * (desc / 100);
                    decimal rep = cell4 * cell5 * (repasse / 100);

                    //griditens.CurrentRow.Cells[11].Value = cell5 - desliquido - repliquido + ipiliquido + freteliquido;
                    griditens.CurrentRow.Cells[12].Value = (cell4 * cell5) - desconto - rep + ipinormal + fretenormal;




                    casasDecimais(Convert.ToDecimal(griditens.CurrentRow.Cells[12].Value));
                    casasDecimais(Convert.ToDecimal(griditens.CurrentRow.Cells[11].Value));

                    valor = 0;

                    foreach (DataGridViewRow linha in griditens.Rows)
                    {
                        if ((linha.Cells[12].Value != DBNull.Value))
                        {

                            valor += Convert.ToDecimal(linha.Cells[12].Value);
                        }

                    }


                    Decimal valort = valor;
                    string convertido = String.Format("{0:N2}", Math.Round(valort, 2));
                    labTotal.Text = convertido;




                }
            }
            if ((e.RowIndex != -1 && e.ColumnIndex == 9))
            {
                string valida5 = griditens.CurrentRow.Cells[5].Value.ToString();
                if (valida5 == "")
                {
                    griditens.CurrentRow.Cells[5].Value = 0;
                }

                decimal cell5 = Convert.ToDecimal(griditens.CurrentRow.Cells[5].Value);
                decimal cell4 = Convert.ToDecimal(griditens.CurrentRow.Cells[4].Value);
                decimal cell9 = Convert.ToDecimal(griditens.CurrentRow.Cells[9].Value);
                decimal desc = Convert.ToDecimal(griditens.CurrentRow.Cells[7].Value);

                string valida8 = griditens.CurrentRow.Cells[8].Value.ToString();
                if (valida8 == "")
                {
                    griditens.CurrentRow.Cells[8].Value = 0;
                }
                decimal repasse = Convert.ToDecimal(griditens.CurrentRow.Cells[8].Value);

                string valida9 = griditens.CurrentRow.Cells[9].Value.ToString();
                if (valida9 == "")
                {
                    griditens.CurrentRow.Cells[9].Value = 0;
                }
                decimal ipi = Convert.ToDecimal(griditens.CurrentRow.Cells[9].Value);
                string valida10 = griditens.CurrentRow.Cells[10].Value.ToString();
                if (valida10 == "")
                {
                    griditens.CurrentRow.Cells[10].Value = 0;
                }
                decimal frete = Convert.ToDecimal(griditens.CurrentRow.Cells[10].Value);
                string valida11 = griditens.CurrentRow.Cells[11].Value.ToString();
                if (valida8 == "")
                {
                    griditens.CurrentRow.Cells[11].Value = 0;
                }
                decimal cell11 = Convert.ToDecimal(griditens.CurrentRow.Cells[11].Value);

                if (repasse.ToString() == "")
                {
                    repasse = 0;
                }
                if (ipi.ToString() == "")
                {
                    ipi = 0;
                }
                if (frete.ToString() == "")
                {
                    frete = 0;
                }
                if (cell11.ToString() == "")
                {
                    cell11 = 0;
                }



                if (cell4.ToString() != "" && cell5.ToString() != "" && cell9.ToString() != "")
                {

                    decimal freteliquido = cell5 * (frete / 100);
                    decimal fretenormal = cell4 * cell5 * (frete / 100);
                    decimal ipiliquido = cell5 * (ipi / 100);
                    decimal ipinormal = cell4 * cell5 * (ipi / 100);
                    decimal desliquido = cell5 * (desc / 100);
                    decimal repliquido = cell5 * (repasse / 100);
                    decimal desconto = cell4 * cell5 * (desc / 100);
                    decimal rep = cell4 * cell5 * (repasse / 100);

                    griditens.CurrentRow.Cells[11].Value = cell5 - desliquido - repliquido + ipiliquido + freteliquido;
                    griditens.CurrentRow.Cells[12].Value = (cell4 * cell5) - desconto - rep + ipinormal + fretenormal;



                    casasDecimais(Convert.ToDecimal(griditens.CurrentRow.Cells[12].Value));
                    ///casasDecimais(Convert.ToDecimal(griditens.CurrentRow.Cells[11].Value));


                    valor = 0;


                    foreach (DataGridViewRow linha in griditens.Rows)
                    {
                        if ((linha.Cells[12].Value != DBNull.Value))
                        {

                            valor += Convert.ToDecimal(linha.Cells[12].Value);
                        }

                    }


                    Decimal valort = valor;
                    string convertido = String.Format("{0:N2}", Math.Round(valort, 2));
                    labTotal.Text = convertido;




                }
            }

            if ((e.RowIndex != -1 && e.ColumnIndex == 10))
            {

                string valida5 = griditens.CurrentRow.Cells[5].Value.ToString();
                if (valida5 == "")
                {
                    griditens.CurrentRow.Cells[5].Value = 0;
                }

                string valida10 = griditens.CurrentRow.Cells[10].Value.ToString();

                if (valida10 == "")
                {
                    griditens.CurrentRow.Cells[5].Value = 0;
                }

                decimal cell5 = Convert.ToDecimal(griditens.CurrentRow.Cells[5].Value);
                decimal cell4 = Convert.ToDecimal(griditens.CurrentRow.Cells[4].Value);
                decimal cell10 = Convert.ToDecimal(griditens.CurrentRow.Cells[10].Value);
                decimal desc = Convert.ToDecimal(griditens.CurrentRow.Cells[7].Value);

                string valida8 = griditens.CurrentRow.Cells[8].Value.ToString();
                if (valida8 == "")
                {
                    griditens.CurrentRow.Cells[8].Value = 0;
                }
                decimal repasse = Convert.ToDecimal(griditens.CurrentRow.Cells[8].Value);

                string valida9 = griditens.CurrentRow.Cells[9].Value.ToString();
                if (valida9 == "")
                {
                    griditens.CurrentRow.Cells[9].Value = 0;
                }
                decimal ipi = Convert.ToDecimal(griditens.CurrentRow.Cells[9].Value);

                string valida100 = griditens.CurrentRow.Cells[10].Value.ToString();
                if (valida100 == "")
                {
                    griditens.CurrentRow.Cells[10].Value = 0;
                }
                decimal frete = Convert.ToDecimal(griditens.CurrentRow.Cells[10].Value);
                string valida11 = griditens.CurrentRow.Cells[11].Value.ToString();
                if (valida8 == "")
                {
                    griditens.CurrentRow.Cells[11].Value = 0;
                }
                decimal cell11 = Convert.ToDecimal(griditens.CurrentRow.Cells[11].Value);

                if (repasse.ToString() == "")
                {
                    repasse = 0;
                }
                if (ipi.ToString() == "")
                {
                    ipi = 0;
                }
                if (frete.ToString() == "")
                {
                    frete = 0;
                }
                if (cell11.ToString() == "")
                {
                    cell11 = 0;
                }


                if (cell4.ToString() != "" && cell5.ToString() != "" && cell10.ToString() != "")
                {

                    decimal freteliquido = cell5 * (frete / 100);
                    decimal fretenormal = cell4 * cell5 * (frete / 100);
                    decimal ipiliquido = cell5 * (ipi / 100);
                    decimal ipinormal = cell4 * cell5 * (ipi / 100);
                    decimal desliquido = cell5 * (desc / 100);
                    decimal repliquido = cell5 * (repasse / 100);
                    decimal desconto = cell4 * cell5 * (desc / 100);
                    decimal rep = cell4 * cell5 * (repasse / 100);

                    griditens.CurrentRow.Cells[11].Value = cell5 - desliquido - repliquido + ipiliquido + freteliquido;
                    griditens.CurrentRow.Cells[12].Value = (cell4 * cell5) - desconto - rep + ipinormal + fretenormal;



                    valor = 0;

                    foreach (DataGridViewRow linha in griditens.Rows)
                    {
                        if ((linha.Cells[12].Value != DBNull.Value))
                        {

                            valor += Convert.ToDecimal(linha.Cells[12].Value);
                        }

                    }


                    Decimal valort = valor;
                    string convertido = String.Format("{0:N2}", Math.Round(valort, 2));
                    labTotal.Text = convertido;




                }
            }


        }
        public int casasDecimais(decimal d)
        {
            int res = 0;
            while (d != (long)d)
            {
                res++;
                d = d * 10;
            }
            return res;
        }


        public void SalvarDados()
        {
            try
            {

                foreach (DataGridViewRow row in griditens.Rows)
                {

                    if (bool.Parse(row.Cells[0].EditedFormattedValue.ToString()) == true)
                    {
                        int edital = Convert.ToInt32(cbolicitacao.SelectedValue);
                        int col1 = Convert.ToInt32(row.Cells[1].Value);
                        decimal col4 = Convert.ToDecimal(row.Cells[4].Value);
                        decimal col5 = Convert.ToDecimal(row.Cells[5].Value);
                        decimal col7 = Convert.ToDecimal(row.Cells[7].Value);
                        decimal col8 = Convert.ToDecimal(row.Cells[8].Value);
                        decimal col9 = Convert.ToDecimal(row.Cells[9].Value);
                        decimal col10 = Convert.ToDecimal(row.Cells[10].Value);
                        double col11 = Convert.ToDouble(row.Cells[11].Value);
                        decimal col12 = Convert.ToDecimal(row.Cells[12].Value);
                        int col13 = Convert.ToInt32(row.Cells[13].Value);
                        int idfor = Convert.ToInt32(row.Cells[14].Value);

                        SqlConnection Cnn = Banco.CriarConexao();

                        string insert = "INSERT INTO RetCotacao(iditemedital,qtde,preco,desconto,repasse,ipi,frete,liquido,vltotal,idusu,idedital,idfornecedor,dtcotacao,idproduto,casasdecimais) VALUES (@iditemedital,@qtde,@preco,@desconto,@repasse,@ipi,@frete,@liquido,@vltotal,@idusu,@idedital,@idfornecedor,@dtcotacao,@idproduto)";

                        SqlCommand cmd = new SqlCommand(insert, Cnn);
                        cmd.Parameters.AddWithValue("@iditemedital", col1);
                        cmd.Parameters.AddWithValue("@qtde", col4);
                        cmd.Parameters.AddWithValue("@preco", col5);
                        cmd.Parameters.AddWithValue("@desconto", col7);
                        cmd.Parameters.AddWithValue("@repasse", col8);
                        cmd.Parameters.AddWithValue("@ipi", col9);
                        cmd.Parameters.AddWithValue("@frete", col10);
                        cmd.Parameters.AddWithValue("@liquido", col11);
                        cmd.Parameters.AddWithValue("@vltotal", col12);
                        cmd.Parameters.AddWithValue("@idusu", Banco.idusu);
                        cmd.Parameters.AddWithValue("@idedital", edital);
                        cmd.Parameters.AddWithValue("@idfornecedor", idfor);
                        cmd.Parameters.AddWithValue("@dtcotacao", SqlDbType.Date).Value = DateTime.Now.ToString("yyyy/MM/dd");
                        cmd.Parameters.AddWithValue("@idproduto", col13);
                        // cmd.Parameters.AddWithValue("@casasdecimais", casas);
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
        }

        public void AlterarDados(int itemedital, int qtde, decimal preco, decimal desconto, decimal repasse, decimal ipi, decimal frete, decimal liquido, decimal vltotal, string edital, int idfornecedor, int idproduto, int idedital)
        {
            try
            {

                SqlConnection Cnn = Banco.CriarConexao();

                string update = "UPDATE RetCotacao SET qtde=@qtde,preco=@preco,desconto=@desconto,repasse=@repasse,ipi=@ipi,frete=@frete,liquido=@liquido,vltotal=@vltotal" +
                    ",idusu=@idusu,idedital=@idedital,dtcotacao=@dtcotacao,idproduto=@idproduto WHERE iditemedital=@iditemedital and idfornecedor=@idfornecedor and idedital=@idedital";

                SqlCommand cmd = new SqlCommand(update, Cnn);
                cmd.Parameters.AddWithValue("@iditemedital", itemedital);
                cmd.Parameters.AddWithValue("@qtde", qtde);
                cmd.Parameters.AddWithValue("@preco", preco);
                cmd.Parameters.AddWithValue("@desconto", desconto);
                cmd.Parameters.AddWithValue("@repasse", repasse);
                cmd.Parameters.AddWithValue("@ipi", ipi);
                cmd.Parameters.AddWithValue("@frete", frete);
                cmd.Parameters.AddWithValue("@liquido", liquido);
                cmd.Parameters.AddWithValue("@vltotal", vltotal);
                cmd.Parameters.AddWithValue("@idusu", Banco.idusu);
                cmd.Parameters.AddWithValue("@idedital", idedital);
                cmd.Parameters.AddWithValue("@edital", edital);
                cmd.Parameters.AddWithValue("@idfornecedor", idfornecedor);
                cmd.Parameters.AddWithValue("@dtcotacao", SqlDbType.Date).Value = DateTime.Now.ToString("yyyy/MM/dd");
                cmd.Parameters.AddWithValue("@idproduto", idproduto);
                // cmd.Parameters.AddWithValue("@casasdecimais", casasdecimais);
                Cnn.Open();
                cmd.ExecuteNonQuery();
                Cnn.Close();



                //MessageBox.Show("Dados Alterados com sucesso !!", "Inclusão", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                ex.Message.ToString();
            }
        }
        public void SalvarDadosTabelaPrecoVenda(int itemedital, int qtd, double pcompra, int codf, double preco, string edital)
        {



            int idedital = Convert.ToInt32(cbolicitacao.SelectedValue);



            SqlConnection Cnn = Banco.CriarConexao();

            string insert = "INSERT INTO VendaPreco(iditemedital,nlicitacao,qtde,precocompra,repasse,desconto,ipi,frete,creditoicms,icmsvenda,pis,comissao,custofixo,ml,fretesaida,precocusto,idusu,idfornecedor,imprenda,contsocial,idedital) " +
                " VALUES (@iditemedital,@nlicitacao,@qtde,@precocompra,@repasse,@desconto,@ipi,@frete,@creditoicms,@icmsvenda,@pis,@comissao,@custofixo,@ml,@fretesaida,@precocusto,@idusu,@idfornecedor,@imprenda,@contsocial,@idedital)";

            SqlCommand cmd = new SqlCommand(insert, Cnn);
            cmd.Parameters.AddWithValue("@iditemedital", itemedital);
            cmd.Parameters.AddWithValue("@nlicitacao", edital);
            cmd.Parameters.AddWithValue("@qtde", qtd);
            cmd.Parameters.AddWithValue("@precocompra", 0);
            cmd.Parameters.AddWithValue("@repasse", 0);
            cmd.Parameters.AddWithValue("@desconto", 0);
            cmd.Parameters.AddWithValue("@ipi", 0);
            cmd.Parameters.AddWithValue("@frete", 0);
            cmd.Parameters.AddWithValue("@creditoicms", 0);
            cmd.Parameters.AddWithValue("@icmsvenda", 0);
            cmd.Parameters.AddWithValue("@pis", 0);
            cmd.Parameters.AddWithValue("@comissao", 0);
            cmd.Parameters.AddWithValue("@custofixo", 0);
            cmd.Parameters.AddWithValue("@ml", 0);
            cmd.Parameters.AddWithValue("@fretesaida", 0);
            cmd.Parameters.AddWithValue("@precocusto", pcompra);
            cmd.Parameters.AddWithValue("@idusu", Banco.idusu);
            cmd.Parameters.AddWithValue("@idfornecedor", codf);
            cmd.Parameters.AddWithValue("@imprenda", 0);
            cmd.Parameters.AddWithValue("@contsocial", 0);
            cmd.Parameters.AddWithValue("@idedital", idedital);
            Cnn.Open();
            cmd.ExecuteNonQuery();
            Cnn.Close();

        }





        private void GravaTabelaPrecoVenda()
        {
            try


            {

                foreach (DataGridViewRow row in griditens.Rows)
                {

                    if (bool.Parse(row.Cells[0].EditedFormattedValue.ToString()) == true)
                    {
                        int col1 = Convert.ToInt32(row.Cells[1].Value);
                        int codforn = Convert.ToInt32((row.Cells[14].Value));
                        string edital = Convert.ToString((row.Cells[16].Value));
                        int qtd = Convert.ToInt32((row.Cells[4].Value));
                        double pcompra = Convert.ToDouble(row.Cells[11].Value);
                        int idedital = Convert.ToInt32(cbolicitacao.SelectedValue);

                        codret = col1;

                        if (VerificaRegistroExisteTabelaPrecoVenda(codret, codforn, idedital) == true)
                        {


                            SalvarDadosTabelaPrecoVenda(col1, qtd, pcompra, codforn, 0, edital);
                        }
                        else
                        {


                            AlterarDadosTabelaPrecoVenda();

                        }
                    }
                }
            }
            catch (Exception erro)
            {

                throw erro;
            }

        }


        private Boolean VerificaRegistroExisteTabelaPrecoVenda(int cod, int cofrn, int idedital)
        {

            SqlConnection Cnn = Banco.CriarConexao();
            string obter = ("Select * From VendaPreco Where iditemedital = " + cod + " AND idfornecedor=" + cofrn + " AND idedital='" + idedital + "'");
            SqlCommand sql = new SqlCommand(obter, Cnn);
            Cnn.Open();
            SqlDataReader dr = sql.ExecuteReader();
            if (dr.Read())
            {

                return false;
            }
            return true;
        }

        public void AlterarDadosTabelaPrecoVenda()
        {
            try
            {
                foreach (DataGridViewRow row in griditens.Rows)
                {

                    if (bool.Parse(row.Cells[0].EditedFormattedValue.ToString()) == true)
                    {
                        string edital = Convert.ToString(row.Cells[16].Value);
                        int idedital = Convert.ToInt32(cbolicitacao.SelectedValue);
                        int itemedital = Convert.ToInt32(row.Cells[1].Value);
                        int qtd = Convert.ToInt32(row.Cells[4].Value);
                        decimal pcusto = 0;
                        if (casas == 2)
                        {
                            string pcompra = String.Format("{0:N2}", Convert.ToDecimal(row.Cells[11].Value), 2);
                            pcusto = decimal.Parse(pcompra);
                        }
                        if (casas == 3)
                        {
                            string pcompra = String.Format("{0:N3}", Convert.ToDecimal(row.Cells[11].Value), 3);
                            pcusto = decimal.Parse(pcompra);
                        }
                        if (casas == 4)
                        {
                            string pcompra = String.Format("{0:N4}", Convert.ToDecimal(row.Cells[11].Value), 4);
                            pcusto = decimal.Parse(pcompra);
                        }
                        if (casas == 5)
                        {
                            string pcompra = String.Format("{0:N5}", Convert.ToDecimal(row.Cells[11].Value), 5);
                            pcusto = decimal.Parse(pcompra);
                        }
                        if (casas == 6)
                        {
                            string pcompra = String.Format("{0:N6}", Convert.ToDecimal(row.Cells[11].Value), 6);
                            pcusto = decimal.Parse(pcompra);
                        }



                        int codf = Convert.ToInt32(row.Cells[14].Value);



                        SqlConnection Cnn = Banco.CriarConexao();

                        string update = "UPDATE VendaPreco SET nlicitacao=@nlicitacao,qtde=@qtde,precocompra=@precocompra,repasse=@repasse,desconto=@desconto,ipi=@ipi,frete=@frete,creditoicms=@creditoicms,icmsvenda=@icmsvenda," +
                            "pis=@pis,comissao=@comissao,custofixo=@custofixo,ml=@ml,fretesaida=@fretesaida,precocusto=@precocusto,idusu=@idusu,idfornecedor=@idfornecedor,imprenda=@imprenda,contsocial=@contsocial,idedital=@idedital WHERE idfornecedor=@idfornecedor and iditemedital=@iditemedital and idedital=@idedital";
                        SqlCommand cmd = new SqlCommand(update, Cnn);
                        cmd.Parameters.AddWithValue("@iditemedital", itemedital);
                        cmd.Parameters.AddWithValue("@nlicitacao", edital);
                        cmd.Parameters.AddWithValue("@qtde", qtd);
                        cmd.Parameters.AddWithValue("@precocompra", 0);
                        cmd.Parameters.AddWithValue("@repasse", 0);
                        cmd.Parameters.AddWithValue("@desconto", 0);
                        cmd.Parameters.AddWithValue("@ipi", 0);
                        cmd.Parameters.AddWithValue("@frete", 0);
                        cmd.Parameters.AddWithValue("@creditoicms", 0);
                        cmd.Parameters.AddWithValue("@icmsvenda", 0);
                        cmd.Parameters.AddWithValue("@pis", 0);
                        cmd.Parameters.AddWithValue("@comissao", 0);
                        cmd.Parameters.AddWithValue("@custofixo", 0);
                        cmd.Parameters.AddWithValue("@ml", 0);
                        cmd.Parameters.AddWithValue("@fretesaida", 0);
                        cmd.Parameters.AddWithValue("@precocusto", pcusto);
                        cmd.Parameters.AddWithValue("@idusu", Banco.idusu);
                        cmd.Parameters.AddWithValue("@idfornecedor", codf);
                        cmd.Parameters.AddWithValue("@imprenda", 0);
                        cmd.Parameters.AddWithValue("@contsocial", 0);
                        cmd.Parameters.AddWithValue("@idedital", idedital);
                        Cnn.Open();
                        cmd.ExecuteNonQuery();
                        Cnn.Close();

                    }
                }
                //MessageBox.Show("Dados Alterados com sucesso !!", "Inclusão", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                ex.Message.ToString();
            }
        }

        private void griditens_CellValidating(object sender, DataGridViewCellValidatingEventArgs e)
        {

        }

        private void btnSalvar_Click(object sender, EventArgs e)
        {
            try


            {
                //if (!cbofornecedor.SelectedIndex.Equals(-1))
                //{

                foreach (DataGridViewRow row in griditens.Rows)
                {


                    if (bool.Parse(row.Cells[0].EditedFormattedValue.ToString()) == true)
                    {



                        int col1 = Convert.ToInt32(row.Cells[1].Value);
                        int forcod = Convert.ToInt32(row.Cells[14].Value);
                        string nforn = row.Cells[15].Value.ToString();



                        string edital = Convert.ToString(row.Cells[16].Value);
                        int idedital = Convert.ToInt32(cbolicitacao.SelectedValue);
                        int itemedital = Convert.ToInt32(row.Cells[1].Value);
                        int qtde = Convert.ToInt32(row.Cells[4].Value);

                        decimal desconto = Convert.ToDecimal(row.Cells[7].Value);
                        decimal repasse = Convert.ToDecimal(row.Cells[8].Value);
                        decimal ipi = Convert.ToDecimal(row.Cells[9].Value);
                        decimal frete = Convert.ToDecimal(row.Cells[10].Value);

                        int idfornecedor = Convert.ToInt32(row.Cells[14].Value);
                        int idproduto = Convert.ToInt32(row.Cells[13].Value);

                        decimal preco = 0;
                        decimal liquido = 0;
                        decimal vltotal = 0;

                        if (casas == 2)
                        {
                            string vlpreco = String.Format("{0:N2}", Convert.ToDecimal(row.Cells[5].Value), 2);
                            preco = Convert.ToDecimal(vlpreco);
                            string vlliquido = String.Format("{0:N2}", Convert.ToDecimal(row.Cells[11].Value), 2);
                            liquido = Convert.ToDecimal(vlliquido);
                            string total = String.Format("{0:N2}", Convert.ToDecimal(row.Cells[12].Value), 2);
                            vltotal = Convert.ToDecimal(total);

                        }
                        else if (casas == 3)
                        {

                            string vlpreco = String.Format("{0:N3}", Convert.ToDecimal(row.Cells[5].Value), 3);
                            preco = Convert.ToDecimal(vlpreco);
                            string vlliquido = String.Format("{0:N3}", Convert.ToDecimal(row.Cells[11].Value), 3);
                            liquido = Convert.ToDecimal(vlliquido);
                            string total = String.Format("{0:N2}", Convert.ToDecimal(row.Cells[12].Value), 2);
                            vltotal = Convert.ToDecimal(total);


                        }
                        else if (casas == 4)
                        {

                            string vlpreco = String.Format("{0:N4}", Convert.ToDecimal(row.Cells[5].Value), 4);
                            preco = Convert.ToDecimal(vlpreco);
                            string vlliquido = String.Format("{0:N4}", Convert.ToDecimal(row.Cells[11].Value), 4);
                            liquido = Convert.ToDecimal(vlliquido);
                            string total = String.Format("{0:N2}", Convert.ToDecimal(row.Cells[12].Value), 2);
                            vltotal = Convert.ToDecimal(total);


                        }
                        else if (casas == 5)
                        {

                            string vlpreco = String.Format("{0:N5}", Convert.ToDecimal(row.Cells[5].Value), 4);
                            preco = Convert.ToDecimal(vlpreco);
                            string vlliquido = String.Format("{0:N5}", Convert.ToDecimal(row.Cells[11].Value), 4);
                            liquido = Convert.ToDecimal(vlliquido);
                            string total = String.Format("{0:N2}", Convert.ToDecimal(row.Cells[12].Value), 2);
                            vltotal = Convert.ToDecimal(total);


                        }
                        else if (casas == 6)
                        {

                            string vlpreco = String.Format("{0:N6}", Convert.ToDecimal(row.Cells[5].Value), 4);
                            preco = Convert.ToDecimal(vlpreco);
                            string vlliquido = String.Format("{0:N6}", Convert.ToDecimal(row.Cells[11].Value), 4);
                            liquido = Convert.ToDecimal(vlliquido);
                            string total = String.Format("{0:N2}", Convert.ToDecimal(row.Cells[12].Value), 2);
                            vltotal = Convert.ToDecimal(total);


                        }



                        codret = col1;

                        if (VerificaRegistroExiste(codret, forcod, idedital) == true)
                        {

                            SalvarDados();
                        }
                        else
                        {


                            AlterarDados(itemedital, qtde, preco, desconto, repasse, ipi, frete, liquido, vltotal, edital, idfornecedor, idproduto, idedital);

                        }
                    }

                }
                //}
                //else
                //{
                //    MessageBox.Show("Favor Informar o nome do Fornecedor!");
                //    chkFornecedor.Checked = true;

                //}
            }
            catch (Exception erro)
            {

                throw erro;
            }

            AlteraStatusLicitacao();
            GravaTabelaPrecoVenda();
            GravaProposta();

        }


        private void GravaProposta()
        {


            try
            {

                foreach (DataGridViewRow row in griditens.Rows)
                {

                    if (bool.Parse(row.Cells[0].EditedFormattedValue.ToString()) == true)
                    {
                        int iditem = Convert.ToInt32(row.Cells[1].Value);
                        int codf = Convert.ToInt32(row.Cells[14].Value);
                        int idedital = Convert.ToInt32(cbolicitacao.SelectedValue);
                        double precovenda = Convert.ToDouble(row.Cells[11].Value);
                        string edital = Convert.ToString(row.Cells[16].Value);

                        if (VerificaRegistroExisteProposta(iditem, idedital) == true)


                        {
                            SqlConnection Cnn = Banco.CriarConexao();

                            string insert = "INSERT INTO Proposta(iditemedital,selecionado,cotado,idusu,ganho,margemfinal,precovenda,casasdecimais,idfornecedor,edital,precominimo,minimototal,idedital) VALUES " +
                                    "(@iditemedital,@selecionado,@cotado,@idusu,@ganho,@margemfinal,@precovenda,@casasdecimais,@idfornecedor,@edital,@precominimo,@minimototal,@idedital)";
                            SqlCommand cmd = new SqlCommand(insert, Cnn);
                            cmd.Parameters.AddWithValue("@iditemedital", iditem);
                            cmd.Parameters.AddWithValue("@selecionado", "SIM");
                            cmd.Parameters.AddWithValue("@cotado", "SIM");
                            cmd.Parameters.AddWithValue("@idusu", Banco.idusu);
                            cmd.Parameters.AddWithValue("@ganho", 1);
                            cmd.Parameters.AddWithValue("@margemfinal", 0);
                            cmd.Parameters.AddWithValue("@precovenda", 0);
                            cmd.Parameters.AddWithValue("@casasdecimais", casas);
                            cmd.Parameters.AddWithValue("@idfornecedor", codf);
                            cmd.Parameters.AddWithValue("@edital", edital);
                            cmd.Parameters.AddWithValue("@precominimo", 0);
                            cmd.Parameters.AddWithValue("@minimototal", 0);
                            cmd.Parameters.AddWithValue("@idedital", idedital);
                            Cnn.Open();
                            cmd.ExecuteNonQuery();
                            Cnn.Close();

                        }

                        else

                        {
                            SqlConnection Cnn = Banco.CriarConexao();

                            string update = "UPDATE Proposta SET selecionado=@selecionado,cotado=@cotado,idusu=@idusu,ganho=@ganho,margemfinal=@margemfinal,precovenda=@precovenda,casasdecimais=@casasdecimais," +
                                    "idfornecedor=@idfornecedor,idedital=@idedital,precominimo=@precominimo,minimototal=@minimototal WHERE iditemedital=@iditemedital and idedital=@idedital";

                            SqlCommand cmd = new SqlCommand(update, Cnn);
                            cmd.Parameters.AddWithValue("@iditemedital", iditem);
                            cmd.Parameters.AddWithValue("@selecionado", "SIM");
                            cmd.Parameters.AddWithValue("@cotado", "SIM");
                            cmd.Parameters.AddWithValue("@idusu", Banco.idusu);
                            cmd.Parameters.AddWithValue("@ganho", 1);
                            cmd.Parameters.AddWithValue("@margemfinal", 0);
                            cmd.Parameters.AddWithValue("@precovenda", 0);
                            cmd.Parameters.AddWithValue("@casasdecimais", casas);
                            cmd.Parameters.AddWithValue("@idfornecedor", codf);
                            cmd.Parameters.AddWithValue("@edital", edital);
                            cmd.Parameters.AddWithValue("@precominimo", 0);
                            cmd.Parameters.AddWithValue("@minimototal", 0);
                            cmd.Parameters.AddWithValue("@idedital", idedital);
                            Cnn.Open();
                            cmd.ExecuteNonQuery();
                            Cnn.Close();



                        }


                    }
                }
                //  MessageBox.Show("Dados incluídos com sucesso !!", "Inclusão", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                ex.Message.ToString();
            }
        }

        private Boolean VerificaRegistroExisteProposta(int cod, int editall)
        {

            SqlConnection Cnn = Banco.CriarConexao();
            string obter = ("Select * From Proposta Where iditemedital = " + cod + " AND idedital='" + editall + "'");
            SqlCommand sql = new SqlCommand(obter, Cnn);
            Cnn.Open();
            SqlDataReader dr = sql.ExecuteReader();
            if (dr.Read())
            {

                return false;
            }
            return true;


        }

        private void AlteraStatusLicitacao()
        {

            VlLancEdital obj = new VlLancEdital();


            obj.nlicitacao = Convert.ToString(cbolicitacao.SelectedValue);
            obj.statuslicitacao = 4;
            obj.idusu = Banco.idusu;


            try
            {
                PsLancEdital DAOLicitacao = new PsLancEdital();

                DAOLicitacao.AlterarStatusLicitacao(obj);


            }

            catch (Exception erro)
            {

                throw erro;
            }
        }


        private Boolean VerificaRegistroExiste(int cod, int fcod, int idedital)
        {

            SqlConnection Cnn = Banco.CriarConexao();
            string obter = ("Select * From RetCotacao Where iditemedital = " + cod + " And idfornecedor=" + fcod + " AND idedital=" + idedital + "");
            SqlCommand sql = new SqlCommand(obter, Cnn);
            Cnn.Open();
            SqlDataReader dr = sql.ExecuteReader();
            if (dr.Read())
            {

                return false;
            }
            return true;
        }

        public int codret;
        private void griditens_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0 && e.ColumnIndex == 0)
            {
                //Loop and uncheck all other CheckBoxes.
                foreach (DataGridViewRow row in griditens.Rows)
                {
                    if (row.Index == e.RowIndex)
                    {
                        row.Cells["chkb"].Value = !Convert.ToBoolean(row.Cells["chkb"].EditedFormattedValue);
                        codret = int.Parse(griditens.Rows[e.RowIndex].Cells[1].Value.ToString());

                    }
                    else
                    {
                        row.Cells["chkb"].Value = false;
                    }
                }
            }
        }

        private void txtnritem_KeyPress(object sender, KeyPressEventArgs e)
        {

            //if ((Keys)e.KeyChar == Keys.Enter)
            //{
            //    if (txtnritem.Text != "")
            //    {

            //    }


            //}

        }
        private void carregarGridItensNrItem()
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
                string strConn = "Select DISTINCT  ItemsLicitacao.iditemedital as Cod,ItemsLicitacao.nritem as NºItem,ItemsLicitacao.lote as Lote,CONVERT(varchar(10),ItemsLicitacao.nritem) + ' - ' + Produto.nome + ' - ' + Produto.apresentacao  + ' - ' + Fornecedor.nome as Item_Apresentação, UnidadeMedida.nome as Unidade,ItemsLicitacao.qtde as Qtde, " +
                    "RetCotacao.preco as Preco,RetCotacao.desconto as Desconto, RetCotacao.repasse as Repasse, RetCotacao.Ipi as Ipi, RetCotacao.frete as Frete, RetCotacao.liquido as Liquido,RetCotacao.vltotal as VlTotal," +
                    "Fornecedor.nome as Fornecedor,RetCotacao.idproduto as codprod,RetCotacao.idfornecedor,ItemsLicitacao.nlicitacao" +
                " from ItemsLicitacao LEFT JOIN RetCotacao ON ItemsLicitacao.iditemedital = RetCotacao.iditemedital ,UnidadeMedida,PrincipioAtivo,Produto,Fornecedor,LancEditais " +
                "Where  ItemsLicitacao.idunidade = UnidadeMedida.idunidade AND Produto.idproduto = RetCotacao.idproduto AND RetCotacao.idfornecedor = Fornecedor.idfornecedor AND " +
                "Produto.idproduto = ItemsLicitacao.idproduto AND Produto.nome Like'" + txtnritem.Text + "%'  AND ItemsLicitacao.idedital=" + cbolicitacao.SelectedValue + " Order by ItemsLicitacao.nritem ";


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
            griditens.Columns.Add("NºItem", "NºItem");
            griditens.Columns.Add("Item_Apresentação", "Item_Apresentação");
            griditens.Columns.Add("Qtde", "Qtde");
            griditens.Columns.Add("Preco", "Preco");
            griditens.Columns.Add("Unidade", "Unidade");
            griditens.Columns.Add("Desconto", "Desconto");
            griditens.Columns.Add("Repasse", "Repasse");
            griditens.Columns.Add("Ipi", "Ipi");
            griditens.Columns.Add("Frete", "Frete");
            griditens.Columns.Add("Liquido", "Liquido");
            griditens.Columns.Add("VlTotal", "VlTotal");
            griditens.Columns.Add("Fornecedor", "Fornecedor");
            griditens.Columns.Add("idfornecedor", "idfornecedor");
            griditens.Columns.Add("codprod", "codprod");
            griditens.Columns.Add("nlicitacao", "nlicitacao");


            griditens.Columns[0].Width = 50;
            griditens.Columns[1].Visible = false;
            griditens.Columns[2].Width = 60;
            griditens.Columns[3].Width = 400;
            griditens.Columns[4].Width = 70;
            griditens.Columns[5].Width = 82;
            griditens.Columns[6].Width = 120;
            griditens.Columns[7].Width = 75;
            griditens.Columns[8].Width = 80;
            griditens.Columns[9].Width = 75;
            griditens.Columns[10].Width = 75;
            griditens.Columns[11].Width = 80;
            griditens.Columns[12].Width = 118;
            griditens.Columns[13].Visible = false;
            griditens.Columns[14].Visible = false;
            griditens.Columns[15].Visible = false;
            griditens.Columns[16].Visible = false;

            griditens.Columns[1].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft;
            griditens.Columns[5].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft;
            griditens.Columns[4].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft;
            griditens.Columns[10].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            griditens.Columns[11].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            griditens.Columns[12].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;

            griditens.Columns[1].DataPropertyName = "Cod";
            griditens.Columns[2].DataPropertyName = "NºItem";
            griditens.Columns[3].DataPropertyName = "Item_Apresentação";
            griditens.Columns[4].DataPropertyName = "Qtde";
            griditens.Columns[5].DataPropertyName = "Preco";
            griditens.Columns[6].DataPropertyName = "Unidade";
            griditens.Columns[7].DataPropertyName = "Desconto";
            griditens.Columns[8].DataPropertyName = "Repasse";
            griditens.Columns[9].DataPropertyName = "Ipi";
            griditens.Columns[10].DataPropertyName = "Frete";
            griditens.Columns[11].DataPropertyName = "Liquido";
            griditens.Columns[12].DataPropertyName = "VlTotal";
            griditens.Columns[13].DataPropertyName = "codprod";
            griditens.Columns[14].DataPropertyName = "idfornecedor";
            griditens.Columns[15].DataPropertyName = "Fornecedor";
            griditens.Columns[16].DataPropertyName = "nlicitacao";




            griditens.Columns[7].DefaultCellStyle.Format = "#.00\\%";
            griditens.Columns[8].DefaultCellStyle.Format = "#.00\\%";
            griditens.Columns[9].DefaultCellStyle.Format = "#.00\\%";
            griditens.Columns[10].DefaultCellStyle.Format = "#.00\\%";

            // griditens.Columns[11].DefaultCellStyle.Format = "c";
            griditens.Columns[12].DefaultCellStyle.Format = "c";
            //griditens.Columns[5].DefaultCellStyle.Format = "c";




            foreach (DataGridViewRow linha in griditens.Rows)
            {
                if ((linha.Cells[4].Value.ToString() == ""))
                {

                    linha.Cells[4].Value = 0;
                }
                else if ((linha.Cells[5].Value.ToString() == ""))
                {

                    linha.Cells[5].Value = 0;

                }
                else if ((linha.Cells[7].Value.ToString() == ""))
                {

                    linha.Cells[7].Value = 0;

                }
                else if ((linha.Cells[8].Value.ToString() == ""))
                {

                    linha.Cells[8].Value = 0;

                }
                else if ((linha.Cells[9].Value.ToString() == ""))
                {

                    linha.Cells[9].Value = 0;

                }
                else if ((linha.Cells[10].Value.ToString() == ""))
                {

                    linha.Cells[10].Value = 0;

                }
                else if ((linha.Cells[11].Value.ToString() == ""))
                {

                    linha.Cells[11].Value = 0;

                }
                else if ((linha.Cells[12].Value.ToString() == ""))
                {

                    linha.Cells[12].Value = 0;

                }

            }


            if (casas == 2)
            {


                griditens.Columns[7].DefaultCellStyle.Format = "#.00\\%";
                griditens.Columns[8].DefaultCellStyle.Format = "#.00\\%";
                griditens.Columns[9].DefaultCellStyle.Format = "#.00\\%";
                griditens.Columns[10].DefaultCellStyle.Format = "#.00\\%";
                griditens.Columns[11].DefaultCellStyle.Format = "n2";
                griditens.Columns[12].DefaultCellStyle.Format = "n2";
                griditens.Columns[5].DefaultCellStyle.Format = "n2";
            }
            else if (casas == 3)
            {


                griditens.Columns[7].DefaultCellStyle.Format = "#.00\\%";
                griditens.Columns[8].DefaultCellStyle.Format = "#.00\\%";
                griditens.Columns[9].DefaultCellStyle.Format = "#.00\\%";
                griditens.Columns[10].DefaultCellStyle.Format = "#.00\\%";
                griditens.Columns[11].DefaultCellStyle.Format = "n3";
                griditens.Columns[12].DefaultCellStyle.Format = "n2";
                griditens.Columns[5].DefaultCellStyle.Format = "n3";



            }
            else if (casas == 4)
            {

                griditens.Columns[7].DefaultCellStyle.Format = "#.00\\%";
                griditens.Columns[8].DefaultCellStyle.Format = "#.00\\%";
                griditens.Columns[9].DefaultCellStyle.Format = "#.00\\%";
                griditens.Columns[10].DefaultCellStyle.Format = "#.00\\%";
                griditens.Columns[11].DefaultCellStyle.Format = "n4";
                griditens.Columns[12].DefaultCellStyle.Format = "n2";
                griditens.Columns[5].DefaultCellStyle.Format = "n4";




            }
            else if (casas == 5)
            {

                griditens.Columns[7].DefaultCellStyle.Format = "#.00\\%";
                griditens.Columns[8].DefaultCellStyle.Format = "#.00\\%";
                griditens.Columns[9].DefaultCellStyle.Format = "#.00\\%";
                griditens.Columns[10].DefaultCellStyle.Format = "#.00\\%";
                griditens.Columns[11].DefaultCellStyle.Format = "n5";
                griditens.Columns[12].DefaultCellStyle.Format = "n2";
                griditens.Columns[5].DefaultCellStyle.Format = "n5";




            }
            else if (casas == 6)
            {

                griditens.Columns[7].DefaultCellStyle.Format = "#.00\\%";
                griditens.Columns[8].DefaultCellStyle.Format = "#.00\\%";
                griditens.Columns[9].DefaultCellStyle.Format = "#.00\\%";
                griditens.Columns[10].DefaultCellStyle.Format = "#.00\\%";
                griditens.Columns[11].DefaultCellStyle.Format = "n6";
                griditens.Columns[12].DefaultCellStyle.Format = "n2";
                griditens.Columns[5].DefaultCellStyle.Format = "n6";




            }


            valor = 0;

            foreach (DataGridViewRow linha in griditens.Rows)
            {
                if ((linha.Cells[12].Value != DBNull.Value))
                {

                    valor += Convert.ToDecimal(linha.Cells[12].Value);
                }

            }


            Decimal valort = valor;
            string convertido = String.Format("{0:N2}", Math.Round(valort, 2));
            labTotal.Text = convertido;




            Int32 total = 0;

            foreach (DataGridViewRow linhatotal in griditens.Rows)
            {
                total = total + 1;
            }

            this.txttotalitens.Text = Convert.ToString(total);



            griditens.Refresh();


        }

        private void btnPesquisar_Click(object sender, EventArgs e)
        {
            ConsGerarCotacao frmconv = new ConsGerarCotacao(this);
            this.Close();
            frmconv.Show();
        }
        public string codlic;
        private void BtnGerarForn_Click(object sender, EventArgs e)
        {
            codlic = Convert.ToString(cbolicitacao.SelectedValue);

            RelRetFornecedor obj = new RelRetFornecedor(this);
            obj.Show();
        }

        private void chkTodos_CheckedChanged(object sender, EventArgs e)
        {
            foreach (DataGridViewRow row in griditens.Rows)
            {
                DataGridViewCheckBoxCell chk = (DataGridViewCheckBoxCell)row.Cells[0];
                chk.Value = !(chk.Value == null ? false : (bool)chk.Value); //because chk.Value is initialy null
            }
        }

        private void txtnritem_TextChanged(object sender, EventArgs e)
        {
            carregarGridItensNrItem();
        }

        private void btnSair_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void rbt2casas_CheckedChanged(object sender, EventArgs e)
        {
            casas = 2;
            carregarGridItensTodo();
        }

        private void rbt3casas_CheckedChanged(object sender, EventArgs e)
        {
            casas = 3;
            carregarGridItensTodo();
        }

        private void rbt4casas_CheckedChanged(object sender, EventArgs e)
        {
            casas = 4;
            carregarGridItensTodo();
        }

        private void CarregaCasasDecimais()
        {

            if (!String.IsNullOrEmpty(cbolicitacao.Text))
            {

                string reg = "Select casasdecimais From LancEditais WHERE LancEditais.idedital=" + cbolicitacao.SelectedValue + "";


                DataTable ds = new DataTable();
                SqlConnection Conn = Banco.CriarConexao();
                Conn.Open();

                if (Conn.State == ConnectionState.Open)
                {
                    SqlCommand cmd = new SqlCommand(reg, Conn);
                    SqlDataReader dr = cmd.ExecuteReader();
                    if (dr.Read())
                    {



                        if (!String.IsNullOrEmpty(dr["casasdecimais"].ToString()))
                        {

                            casas = Convert.ToInt32(dr["casasdecimais"].ToString());


                            if (casas == 2)
                            {
                                rbt2casas.Checked = true;
                            }
                            else if (casas == 3)
                            {

                                rbt3casas.Checked = true;
                            }
                            else if (casas == 4)
                            {

                                rbt4casas.Checked = true;
                            }
                            else if (casas == 5)
                            {

                                rbt5casas.Checked = true;
                            }
                            else if (casas == 6)
                            {

                                rbt6casas.Checked = true;
                            }
                        }

                    }
                }


            }
        }

        private void ViewRetornoFornecedores_Load(object sender, EventArgs e)
        {
            CarregaCasasDecimais();
        }

        private void griditens_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
          
        }

        private void labTotal_Click(object sender, EventArgs e)
        {

        }

        private void label10_Click(object sender, EventArgs e)
        {

        }

        private void panel3_Paint(object sender, PaintEventArgs e)
        {

        }
    }

}
