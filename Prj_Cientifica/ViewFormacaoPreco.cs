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
    public partial class ViewFormacaoPreco : Form
    {

        public static string TipoGravacao;
        public static int UltimoSelecionado;

        public string nlicitacao;
        public int coditemlic;
        public string nomeprod;
        public decimal precocompra;
        public int codfornecedor;
        public int nomefor;

        public string nomeFor = "ViewFormacaoPreco";

        public ViewFormacaoPreco()
        {
            InitializeComponent();
        }


        public ViewFormacaoPreco(ConsGerarCotacao frm) : this()
        {
            UltimoSelecionado = Convert.ToInt32(frm.codedital);
            RetReg();


        }



        private void RetornaFornecedor(Int32 retfor)
        {
            SqlConnection Cnn = Banco.CriarConexao();
            SqlDataAdapter sql = new SqlDataAdapter("Select * from Fornecedor WHERE idfornecedor=" + retfor + "", Cnn);
            DataTable Dt = new DataTable();
            sql.Fill(Dt);
            try
            {
                this.cbofornecedor.DataSource = Dt;
                this.cbofornecedor.DisplayMember = "nome";
                this.cbofornecedor.ValueMember = "idfornecedor";
                this.cbofornecedor.Refresh();


                txtrepasse.Enabled = true;
                txtdesconto.Enabled = true;
                txtipi.Enabled = true;
                txtfrete.Enabled = true;
                txtcreditoicms.Enabled = true;
                txticmsvenda.Enabled = true;
                txtpis.Enabled = true;
                txtcomissao.Enabled = true;
                txtcustofixo.Enabled = true;
                txtml.Enabled = true;
                txtimprenda.Enabled = true;
                txtcontSocial.Enabled = true;
                txtcreditoicms.Enabled = true;
                txtnritem.Enabled = true;
                labTotal.Enabled = true;
                txtfrete.Enabled = true;
                txtfretesaida.Enabled = true;





            }
            catch (Exception erro)
            {

                throw erro;
            }
            Cnn.Close();
        }


        private void RetRegCmd(int codfor, int codpreco)
        {

            if (codfor != 0)
            {

                string reg = "Select DISTINCT ItemsLicitacao.iditemedital as Cod,ItemsLicitacao.nritem as NºItem,ItemsLicitacao.lote as Lote,PrincipioAtivo.nome as PrincipioAtivo, UnidadeMedida.nome as Unidade,ItemsLicitacao.qtde as Qtde, " +
                        "RetCotacao.preco as Preco,RetCotacao.desconto as Desconto, RetCotacao.repasse as Repasse, RetCotacao.Ipi as Ipi, RetCotacao.frete as Frete, RetCotacao.liquido as Liquido,RetCotacao.vltotal as VlTotal," +
                        "VendaPreco.repasse as prepasse,VendaPreco.desconto as pdesconto,VendaPreco.ipi as pipi,VendaPreco.frete as pfrete,VendaPreco.creditoicms as pcreditoicms,VendaPreco.icmsvenda as picmsvenda,VendaPreco.pis as ppis,VendaPreco.comissao as pcomissao,VendaPreco.custofixo as pcustofixo, " +
                        "VendaPreco.ml as pml,VendaPreco.fretesaida as pfretesaida,VendaPreco.imprenda as imprenda, VendaPreco.contsocial as contsocial,ItemsLicitacao.nlicitacao " +
                    " from ItemsLicitacao LEFT JOIN RetCotacao ON ItemsLicitacao.iditemedital = RetCotacao.iditemedital  LEFT JOIN VendaPreco ON ItemsLicitacao.iditemedital = VendaPreco.iditemedital ,UnidadeMedida,PrincipioAtivo,Produto,Fornecedor,LancEditais Where LancEditais.idedital = ItemsLicitacao.idedital AND " +
                    "Produto.idprincipio = PrincipioAtivo.idprincipio AND ItemsLicitacao.idprincipio = PrincipioAtivo.idprincipio AND ItemsLicitacao.idunidade = UnidadeMedida.idunidade AND " +
                    "Produto.idproduto = ItemsLicitacao.idproduto  AND ItemsLicitacao.idedital=" + cbolicitacao.SelectedValue + " AND VendaPreco.idfornecedor=" + cbofornecedor.SelectedValue + " AND VendaPreco.iditemedital=" + codpreco + "";

                DataTable ds = new DataTable();
                SqlConnection Conn = Banco.CriarConexao();
                Conn.Open();

                if (Conn.State == ConnectionState.Open)
                {
                    SqlCommand cmd = new SqlCommand(reg, Conn);
                    SqlDataReader dr = cmd.ExecuteReader();
                    if (dr.Read())
                    {
                        //if (!String.IsNullOrEmpty(dr["prepasse"].ToString()))
                        //{
                        txtrepasse.Text = dr["prepasse"].ToString();
                        //}
                        //else
                        //{
                        //    txtrepasse.Text = "0";
                        ////}
                        //if (!String.IsNullOrEmpty(dr["pdesconto"].ToString()))
                        //{
                        txtdesconto.Text = dr["pdesconto"].ToString();
                        //}
                        //else
                        //{
                        //    txtdesconto.Text = "0";
                        //}
                        //if (!String.IsNullOrEmpty(dr["pipi"].ToString()))
                        //{
                        txtipi.Text = dr["pipi"].ToString();
                        // }
                        //else
                        //{
                        //    txtipi.Text = "0";
                        //}
                        //if (!String.IsNullOrEmpty(dr["pfrete"].ToString()))
                        //{
                        txtfrete.Text = dr["pfrete"].ToString();
                        // }
                        //else
                        //{
                        //    txtfrete.Text = "0";
                        //}
                        //if (!String.IsNullOrEmpty(dr["pcreditoicms"].ToString()))
                        //{
                        txtcreditoicms.Text = dr["pcreditoicms"].ToString();
                        // }
                        //else
                        //{
                        //    txtcreditoicms.Text = "0";
                        //}
                        //if (!String.IsNullOrEmpty(dr["picmsvenda"].ToString()))
                        //{
                        txticmsvenda.Text = dr["picmsvenda"].ToString();
                        //}
                        //else
                        //{
                        //    txticmsvenda.Text = "0";
                        //}
                        //if (!String.IsNullOrEmpty(dr["ppis"].ToString()))
                        //{
                        txtpis.Text = dr["ppis"].ToString();
                        //}
                        //else
                        //{
                        //    txtpis.Text = "0";
                        //}

                        //if (!String.IsNullOrEmpty(dr["pcomissao"].ToString()))
                        //{
                        txtcomissao.Text = dr["pcomissao"].ToString();
                        //}
                        //else
                        //{
                        //    txtcomissao.Text = "0";
                        //}
                        //if (!String.IsNullOrEmpty(dr["pcustofixo"].ToString()))
                        //{

                        txtcustofixo.Text = dr["pcustofixo"].ToString();
                        //}
                        //else
                        //{
                        //    txtcustofixo.Text = "0";
                        //}
                        //if (!String.IsNullOrEmpty(dr["pml"].ToString()))
                        //{
                        txtml.Text = dr["pml"].ToString();
                        //}
                        //else
                        //{
                        //    txtml.Text = "0";
                        //}
                        //if (!String.IsNullOrEmpty(dr["pfretesaida"].ToString()))
                        //{
                        txtfretesaida.Text = dr["pfretesaida"].ToString();
                        //}
                        //else
                        //{
                        //    txtml.Text = "";
                        //}
                        //if (!String.IsNullOrEmpty(dr["imprenda"].ToString()))
                        //{
                        txtimprenda.Text = dr["imprenda"].ToString();
                        //}
                        //else
                        //{
                        //    txtimprenda.Text = "";
                        //}
                        //if (!String.IsNullOrEmpty(dr["contsocial"].ToString()))
                        //{
                        this.txtcontSocial.Text = dr["contsocial"].ToString();
                        //}
                        //else
                        //{
                        //    txtcontSocial.Text = "";
                        //}
                        //if (!String.IsNullOrEmpty(dr["pcreditoicms"].ToString()))
                        //{
                        txtcreditoicms.Text = dr["pcreditoicms"].ToString();
                        //}
                        //else
                        //{
                        //    txtcreditoicms.Text = "0";
                        //}
                        //if (!String.IsNullOrEmpty(dr["picmsvenda"].ToString()))
                        // {
                        txticmsvenda.Text = dr["picmsvenda"].ToString();
                        //}
                        //else
                        //{
                        //    txticmsvenda.Text = "0";
                        //}


                        RetronarCarregarLicitacao(Convert.ToInt32(cbolicitacao.SelectedValue));
                        //CarregarFornecedor();


                    }
                }
            }
        }



        private void RetReg()
        {
            string reg = "Select DISTINCT ItemsLicitacao.iditemedital as Cod,ItemsLicitacao.nritem as NºItem,ItemsLicitacao.lote as Lote,PrincipioAtivo.nome as PrincipioAtivo, UnidadeMedida.nome as Unidade,ItemsLicitacao.qtde as Qtde, " +
                    "RetCotacao.preco as Preco,RetCotacao.desconto as Desconto, RetCotacao.repasse as Repasse, RetCotacao.Ipi as Ipi, RetCotacao.frete as Frete, RetCotacao.liquido as Liquido,RetCotacao.vltotal as VlTotal," +
                    "VendaPreco.repasse as prepasse,VendaPreco.desconto as pdesconto,VendaPreco.ipi as pipi,VendaPreco.frete as pfrete,VendaPreco.pis as ppis,VendaPreco.comissao as pcomissao,VendaPreco.custofixo as pcustofixo, " +
                    "VendaPreco.ml as pml,VendaPreco.fretesaida as pfretesaida,VendaPreco.imprenda as imprenda, VendaPreco.contsocial as contsocial,VendaPreco.creditoicms as pcreditoicms,VendaPreco.icmsvenda as picmsvenda,ItemsLicitacao.nlicitacao " +
                " from ItemsLicitacao LEFT JOIN RetCotacao ON ItemsLicitacao.iditemedital = RetCotacao.iditemedital  INNER JOIN VendaPreco ON ItemsLicitacao.iditemedital = VendaPreco.iditemedital ,UnidadeMedida,PrincipioAtivo,Produto,Fornecedor,LancEditais Where LancEditais.idedital = ItemsLicitacao.idedital AND " +
                "Produto.idprincipio = PrincipioAtivo.idprincipio AND ItemsLicitacao.idprincipio = PrincipioAtivo.idprincipio AND ItemsLicitacao.idunidade = UnidadeMedida.idunidade AND " +
                "Produto.idproduto = ItemsLicitacao.idproduto  AND VendaPreco.idedital=" + UltimoSelecionado + "";

            DataTable ds = new DataTable();
            SqlConnection Conn = Banco.CriarConexao();
            Conn.Open();

            if (Conn.State == ConnectionState.Open)
            {
                SqlCommand cmd = new SqlCommand(reg, Conn);
                SqlDataReader dr = cmd.ExecuteReader();
                if (dr.Read())
                {
                    if (!String.IsNullOrEmpty(dr["prepasse"].ToString()))
                    {
                        txtrepasse.Text = dr["prepasse"].ToString();
                    }
                    //else
                    //{
                    //    txtrepasse.Text = "0";
                    //}
                    if (!String.IsNullOrEmpty(dr["pdesconto"].ToString()))
                    {
                        txtdesconto.Text = dr["pdesconto"].ToString();
                    }
                    //else
                    //{
                    //    txtdesconto.Text = "0";
                    //}
                    if (!String.IsNullOrEmpty(dr["pipi"].ToString()))
                    {
                        txtipi.Text = dr["pipi"].ToString();
                    }
                    //else
                    //{
                    //    txtipi.Text = "0";
                    //}
                    if (!String.IsNullOrEmpty(dr["pfrete"].ToString()))
                    {
                        txtfrete.Text = dr["pfrete"].ToString();
                    }
                    //else
                    //{
                    //    txtfrete.Text = "0";
                    //}
                    if (!String.IsNullOrEmpty(dr["ppis"].ToString()))
                    {
                        txtpis.Text = dr["ppis"].ToString();
                    }
                    //else
                    //{
                    //    txtpis.Text = "0";
                    //}

                    if (!String.IsNullOrEmpty(dr["pcomissao"].ToString()))
                    {
                        txtcomissao.Text = dr["pcomissao"].ToString();
                    }
                    //else
                    //{
                    //    txtcomissao.Text = "0";
                    //}
                    if (!String.IsNullOrEmpty(dr["pcustofixo"].ToString()))
                    {

                        txtcustofixo.Text = dr["pcustofixo"].ToString();
                    }
                    //else
                    //{
                    //    txtcustofixo.Text = "0";
                    //}
                    if (!String.IsNullOrEmpty(dr["pml"].ToString()))
                    {
                        txtml.Text = dr["pml"].ToString();
                    }
                    //else
                    //{
                    //    txtml.Text = "0";
                    //}
                    if (!String.IsNullOrEmpty(dr["pfretesaida"].ToString()))
                    {
                        txtfretesaida.Text = dr["pfretesaida"].ToString();
                    }
                    //else
                    //{
                    //    txtfretesaida.Text = "";
                    //}
                    if (!String.IsNullOrEmpty(dr["imprenda"].ToString()))
                    {
                        txtimprenda.Text = dr["imprenda"].ToString();
                    }
                    //else
                    //{
                    //    txtimprenda.Text = "";
                    //}
                    if (!String.IsNullOrEmpty(dr["contsocial"].ToString()))
                    {
                        this.txtcontSocial.Text = dr["contsocial"].ToString();
                    }
                    //else
                    //{
                    //    txtcontSocial.Text = "";
                    //}
                    if (!String.IsNullOrEmpty(dr["pcreditoicms"].ToString()))
                    {
                        txtcreditoicms.Text = dr["pcreditoicms"].ToString();
                    }
                    //else
                    //{
                    //    txtcreditoicms.Text = "0";
                    //}
                    if (!String.IsNullOrEmpty(dr["picmsvenda"].ToString()))
                    {
                        txticmsvenda.Text = dr["picmsvenda"].ToString();
                    }
                    //else
                    //{
                    //    txticmsvenda.Text = "0";
                    //}

                    RetronarCarregarLicitacao(UltimoSelecionado);
                    carregarGridItensTodo();
                    Conn.Close();


                }
            }
        }

        private void RetronarCarregarLicitacao(int retgercot)
        {
            SqlConnection Cnn = Banco.CriarConexao();
            SqlDataAdapter sql = new SqlDataAdapter("Select  LancEditais.idedital,LancEditais.nlicitacao,(CAST(LancEditais.nlicitacao AS VARCHAR(10))) + '               ' + (Modalidade.nome + '                    ' +  LancEditais.nlicitacao + '                        ' + " +
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

        public double valor;
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
                string strConn = "Select DISTINCT ItemsLicitacao.iditemedital as Cod,ItemsLicitacao.nritem as NºItem,ItemsLicitacao.lote as Lote,Produto.nome as PrincipioAtivo, UnidadeMedida.nome as Unidade,ItemsLicitacao.qtde as Qtde, " +
                    "RetCotacao.preco as Preco,RetCotacao.desconto as Dsc, RetCotacao.repasse as Repasse, RetCotacao.Ipi as Ipi, RetCotacao.frete as Frete, RetCotacao.liquido as Custo,VendaPreco.precocusto as Venda,(ItemsLicitacao.qtde * VendaPreco.precocusto) as VlTotal, RetCotacao.idfornecedor,VendaPreco.idpreco as CodPreco, Fornecedor.idfornecedor as Codfor,ItemsLicitacao.nlicitacao" +
                " from ItemsLicitacao INNER JOIN RetCotacao ON ItemsLicitacao.iditemedital = RetCotacao.iditemedital INNER JOIN VendaPreco ON ItemsLicitacao.iditemedital = VendaPreco.iditemedital ,UnidadeMedida,PrincipioAtivo,Produto,Fornecedor,LancEditais,Produto_Fornecedor Where LancEditais.idedital = ItemsLicitacao.idedital AND " +
                "Produto.idprincipio = PrincipioAtivo.idprincipio AND ItemsLicitacao.idprincipio = PrincipioAtivo.idprincipio AND ItemsLicitacao.idunidade = UnidadeMedida.idunidade AND Produto_Fornecedor.idfornecedor = Fornecedor.idfornecedor AND   VendaPreco.idfornecedor = RetCotacao.idfornecedor and " +
                "Produto.idproduto = ItemsLicitacao.idproduto AND  Produto_Fornecedor.idproduto = Produto.idproduto AND  RetCotacao.idfornecedor = Fornecedor.idfornecedor AND VendaPreco.idfornecedor=" + codfor + " AND   RetCotacao.idfornecedor=" + codfor + "  AND ItemsLicitacao.idedital=" + cbolicitacao.SelectedValue + "";


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
            griditens.Columns.Add("PrincipioAtivo", "PrincipioAtivo");
            griditens.Columns.Add("Qtde", "Qtde");
            griditens.Columns.Add("Preco", "Preco");
            griditens.Columns.Add("Unidade", "Unidade");
            griditens.Columns.Add("Dsc", "Dsc");
            griditens.Columns.Add("Repasse", "Repasse");
            griditens.Columns.Add("Ipi", "Ipi");
            griditens.Columns.Add("Frete", "Frete");
            griditens.Columns.Add("Custo", "Custo");
            griditens.Columns.Add("Venda", "Venda");
            griditens.Columns.Add("VlTotal", "VlTotal");
            griditens.Columns.Add("CodPreco", "CodPreco");
            griditens.Columns.Add("Codfor", "Codfor");
            griditens.Columns.Add("nlicitacao", "nlicitacao");


            griditens.Columns[0].Width = 50;
            griditens.Columns[1].Width = 50;
            griditens.Columns[2].Width = 80;
            griditens.Columns[3].Width = 350;
            griditens.Columns[4].Width = 70;
            griditens.Columns[5].Width = 82;
            griditens.Columns[6].Width = 150;
            griditens.Columns[7].Width = 40;
            griditens.Columns[8].Width = 80;
            griditens.Columns[9].Width = 40;
            griditens.Columns[10].Width = 60;
            griditens.Columns[11].Width = 80;
            griditens.Columns[12].Width = 85;
            griditens.Columns[13].Width = 118;
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
            griditens.Columns[3].DataPropertyName = "PrincipioAtivo";
            griditens.Columns[4].DataPropertyName = "Qtde";
            griditens.Columns[5].DataPropertyName = "Preco";
            griditens.Columns[6].DataPropertyName = "Unidade";
            griditens.Columns[7].DataPropertyName = "Dsc";
            griditens.Columns[8].DataPropertyName = "Repasse";
            griditens.Columns[9].DataPropertyName = "Ipi";
            griditens.Columns[10].DataPropertyName = "Frete";
            griditens.Columns[11].DataPropertyName = "Custo";
            griditens.Columns[12].DataPropertyName = "Venda";
            griditens.Columns[13].DataPropertyName = "VlTotal";
            griditens.Columns[14].DataPropertyName = "CodPreco";
            griditens.Columns[15].DataPropertyName = "Codfor";
            griditens.Columns[16].DataPropertyName = "nlicitacao";


            griditens.Columns[7].DefaultCellStyle.Format = "#.00\\%";
            griditens.Columns[8].DefaultCellStyle.Format = "#.00\\%";
            griditens.Columns[9].DefaultCellStyle.Format = "#.00\\%";
            griditens.Columns[10].DefaultCellStyle.Format = "#.00\\%";

            griditens.Columns[11].DefaultCellStyle.Format = "c";
            //griditens.Columns[12].DefaultCellStyle.Format = "c";
            griditens.Columns[13].DefaultCellStyle.Format = "c";
            griditens.Columns[5].DefaultCellStyle.Format = "c";



            valor = 0;

            foreach (DataGridViewRow linha in griditens.Rows)
            {
                if ((linha.Cells[13].Value != DBNull.Value))
                {

                    valor += Convert.ToDouble(linha.Cells[13].Value);
                }

            }


            double valort = valor;
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
                string strConn = "Select DISTINCT ItemsLicitacao.iditemedital as Cod,ItemsLicitacao.nritem as NºItem,ItemsLicitacao.lote as Lote,Produto.nome as PrincipioAtivo, UnidadeMedida.nome as Unidade,ItemsLicitacao.qtde as Qtde, " +
                    "RetCotacao.preco as Preco,RetCotacao.desconto as Dsc, RetCotacao.repasse as Repasse, RetCotacao.Ipi as Ipi, RetCotacao.frete as Frete, RetCotacao.liquido as Custo,VendaPreco.precocusto as Venda,(ItemsLicitacao.qtde * VendaPreco.precocusto) as VlTotal,VendaPreco.idpreco as CodPreco,Fornecedor.idfornecedor as Codfor,ItemsLicitacao.nlicitacao" +
                " from ItemsLicitacao LEFT JOIN RetCotacao ON ItemsLicitacao.iditemedital = RetCotacao.iditemedital  INNER JOIN VendaPreco ON ItemsLicitacao.iditemedital = VendaPreco.iditemedital ,UnidadeMedida,PrincipioAtivo,Produto,Fornecedor,LancEditais Where LancEditais.idedital = ItemsLicitacao.idedital AND " +
                "Produto.idprincipio = PrincipioAtivo.idprincipio AND ItemsLicitacao.idprincipio = PrincipioAtivo.idprincipio AND ItemsLicitacao.idunidade = UnidadeMedida.idunidade AND " +
                "Produto.idproduto = ItemsLicitacao.idproduto AND Fornecedor.idfornecedor = RetCotacao.idfornecedor  AND VendaPreco.idedital=" + UltimoSelecionado + "";


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
            griditens.Columns.Add("PrincipioAtivo", "PrincipioAtivo");
            griditens.Columns.Add("Qtde", "Qtde");
            griditens.Columns.Add("Preco", "Preco");
            griditens.Columns.Add("Unidade", "Unidade");
            griditens.Columns.Add("Dsc", "Dsc");
            griditens.Columns.Add("Repasse", "Repasse");
            griditens.Columns.Add("Ipi", "Ipi");
            griditens.Columns.Add("Frete", "Frete");
            griditens.Columns.Add("Custo", "Custo");
            griditens.Columns.Add("Venda", "Venda");
            griditens.Columns.Add("VlTotal", "VlTotal");
            griditens.Columns.Add("CodPreco", "CodPreco");
            griditens.Columns.Add("Codfor", "Codfor");
            griditens.Columns.Add("nlicitacao", "nlicitacao");




            griditens.Columns[0].Width = 50;
            griditens.Columns[1].Width = 50;
            griditens.Columns[2].Width = 80;
            griditens.Columns[3].Width = 350;
            griditens.Columns[4].Width = 70;
            griditens.Columns[5].Width = 82;
            griditens.Columns[6].Width = 150;
            griditens.Columns[7].Width = 40;
            griditens.Columns[8].Width = 80;
            griditens.Columns[9].Width = 40;
            griditens.Columns[10].Width = 60;
            griditens.Columns[11].Width = 80;
            griditens.Columns[12].Width = 85;
            griditens.Columns[13].Width = 118;
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
            griditens.Columns[3].DataPropertyName = "PrincipioAtivo";
            griditens.Columns[4].DataPropertyName = "Qtde";
            griditens.Columns[5].DataPropertyName = "Preco";
            griditens.Columns[6].DataPropertyName = "Unidade";
            griditens.Columns[7].DataPropertyName = "Dsc";
            griditens.Columns[8].DataPropertyName = "Repasse";
            griditens.Columns[9].DataPropertyName = "Ipi";
            griditens.Columns[10].DataPropertyName = "Frete";
            griditens.Columns[11].DataPropertyName = "Custo";
            griditens.Columns[12].DataPropertyName = "Venda";
            griditens.Columns[13].DataPropertyName = "VlTotal";
            griditens.Columns[14].DataPropertyName = "CodPreco";
            griditens.Columns[15].DataPropertyName = "Codfor";
            griditens.Columns[16].DataPropertyName = "nlicitacao";


            griditens.Columns[7].DefaultCellStyle.Format = "#.00\\%";
            griditens.Columns[8].DefaultCellStyle.Format = "#.00\\%";
            griditens.Columns[9].DefaultCellStyle.Format = "#.00\\%";
            griditens.Columns[10].DefaultCellStyle.Format = "#.00\\%";

            griditens.Columns[11].DefaultCellStyle.Format = "c";
            // griditens.Columns[12].DefaultCellStyle.Format = "c";
            griditens.Columns[13].DefaultCellStyle.Format = "c";
            griditens.Columns[5].DefaultCellStyle.Format = "c";


            valor = 0;

            foreach (DataGridViewRow linha in griditens.Rows)
            {
                if ((linha.Cells[13].Value != DBNull.Value))
                {

                    valor += Convert.ToDouble(linha.Cells[13].Value);
                }

            }


            double valort = valor;
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
            SqlDataAdapter sql = new SqlDataAdapter("Select DISTINCT Fornecedor.idfornecedor ,Fornecedor.nome  from ItemsLicitacao,Fornecedor,LancEditais, Produto_Fornecedor " +
                " WHERE Produto_Fornecedor.idfornecedor = Fornecedor.idfornecedor and LancEditais.edital=" + cbolicitacao.SelectedValue + "  Order by Fornecedor.nome ASC ", Cnn);
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

        private void retTributacao(int codpreco)
        {

            string reg = "Select VendaPreco.repasse as prepasse,VendaPreco.desconto as pdesconto,VendaPreco.ipi as pipi,VendaPreco.frete as pfrete,VendaPreco.creditoicms as pcreditoicms,VendaPreco.icmsvenda as picmsvenda, VendaPreco.pis as ppis,VendaPreco.comissao as pcomissao,VendaPreco.custofixo as pcustofixo, " +
                  "VendaPreco.ml as pml,VendaPreco.fretesaida as pfretesaida,VendaPreco.imprenda as imprenda,VendaPreco.contsocial as contsocial  " +
              " from ItemsLicitacao LEFT JOIN RetCotacao ON ItemsLicitacao.iditemedital = RetCotacao.iditemedital  LEFT JOIN VendaPreco ON ItemsLicitacao.iditemedital = VendaPreco.iditemedital ,UnidadeMedida,PrincipioAtivo,Produto,Fornecedor,LancEditais Where LancEditais.idedital = ItemsLicitacao.idedital AND " +
              "Produto.idprincipio = PrincipioAtivo.idprincipio AND ItemsLicitacao.idprincipio = PrincipioAtivo.idprincipio AND ItemsLicitacao.idunidade = UnidadeMedida.idunidade AND " +
              "Produto.idproduto = ItemsLicitacao.idproduto  AND VendaPreco.iditemedital=" + codpreco + "";

            DataTable ds = new DataTable();
            SqlConnection Conn = Banco.CriarConexao();
            Conn.Open();

            if (Conn.State == ConnectionState.Open)
            {
                SqlCommand cmd = new SqlCommand(reg, Conn);
                SqlDataReader dr = cmd.ExecuteReader();
                if (dr.Read())
                {

                    // if (!String.IsNullOrEmpty(dr["prepasse"].ToString()))
                    //{
                    txtrepasse.Text = dr["prepasse"].ToString();
                    //}
                    //else
                    //{
                    //    txtrepasse.Text = "0";
                    //}
                    //if (!String.IsNullOrEmpty(dr["pdesconto"].ToString()))
                    //{
                    txtdesconto.Text = dr["pdesconto"].ToString();
                    //}
                    //else
                    //{
                    //    txtdesconto.Text = "0";
                    //}
                    //if (!String.IsNullOrEmpty(dr["pipi"].ToString()))
                    //{
                    txtipi.Text = dr["pipi"].ToString();
                    //}
                    //else
                    //{
                    //    txtipi.Text = "0";
                    //}
                    //if (!String.IsNullOrEmpty(dr["pfrete"].ToString()))
                    //{
                    txtfrete.Text = dr["pfrete"].ToString();
                    //}
                    //else
                    //{
                    //    txtfrete.Text = "0";
                    //}
                    //if (!String.IsNullOrEmpty(dr["pcreditoicms"].ToString()))
                    //{
                    txtcreditoicms.Text = dr["pcreditoicms"].ToString();
                    //}
                    //else
                    //{
                    //    txtcreditoicms.Text = "0";
                    //}
                    //if (!String.IsNullOrEmpty(dr["picmsvenda"].ToString()))
                    //{
                    txticmsvenda.Text = dr["picmsvenda"].ToString();
                    //}
                    //else
                    //{
                    //    txticmsvenda.Text = "0";
                    //}
                    //if (!String.IsNullOrEmpty(dr["ppis"].ToString()))
                    //{
                    txtpis.Text = dr["ppis"].ToString();
                    // }
                    //else
                    //{
                    //    txtpis.Text = "0";
                    ////}
                    //if (!String.IsNullOrEmpty(dr["pcomissao"].ToString()))
                    //{
                    txtcomissao.Text = dr["pcomissao"].ToString();
                    //}
                    //else
                    //{
                    //    txtcomissao.Text = "0";
                    //}
                    //if (!String.IsNullOrEmpty(dr["pcustofixo"].ToString()))
                    //{

                    txtcustofixo.Text = dr["pcustofixo"].ToString();
                    // }
                    //else
                    //{
                    //    txtcustofixo.Text = "0";
                    //}
                    //if (!String.IsNullOrEmpty(dr["pml"].ToString()))
                    //{
                    txtml.Text = dr["pml"].ToString();
                    // }
                    //else
                    //{
                    //    txtml.Text = "0";
                    //}
                    //if (!String.IsNullOrEmpty(dr["pfretesaida"].ToString()))
                    //{
                    txtfretesaida.Text = dr["pfretesaida"].ToString();
                    //}
                    //else
                    //{
                    //    txtfretesaida.Text = "0";
                    //}
                    //if (!String.IsNullOrEmpty(dr["pcreditoicms"].ToString()))
                    //{
                    this.txtcreditoicms.Text = dr["pcreditoicms"].ToString();
                    //}
                    //else
                    //{
                    //    txtcreditoicms.Text = "0";
                    //}
                    //if (!String.IsNullOrEmpty(dr["picmsvenda"].ToString()))
                    //{
                    this.txticmsvenda.Text = dr["picmsvenda"].ToString();
                    //}
                    //else
                    //{
                    //    txticmsvenda.Text = "0";
                    //}
                    //if (!String.IsNullOrEmpty(dr["imprenda"].ToString()))
                    //{
                    txtimprenda.Text = dr["imprenda"].ToString();
                    //}
                    //else
                    //{
                    //    txtimprenda.Text = "0";
                    //}
                    //if (!String.IsNullOrEmpty(dr["contsocial"].ToString()))
                    //{
                    this.txtcontSocial.Text = dr["contsocial"].ToString();
                    //}
                    //else
                    //{
                    //    txtcontSocial.Text = "0";
                    //}
                    Conn.Close();
                }
            }
        }

        private void cbofornecedor_SelectionChangeCommitted(object sender, EventArgs e)
        {
            carregarGridItensFor(Convert.ToInt32(cbofornecedor.SelectedValue));

            rbt2casas.Checked = true;
            RetornaFornecedor(Convert.ToInt32(cbofornecedor.SelectedValue));


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

                double cell5 = Convert.ToDouble(griditens.CurrentRow.Cells[5].Value);
                double cell4 = Convert.ToDouble(griditens.CurrentRow.Cells[4].Value);



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
                double cell11 = Convert.ToDouble(griditens.CurrentRow.Cells[11].Value);

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

                    griditens.CurrentRow.Cells[11].Value = cell5 - desliquido - repliquido + ipiliquido + freteliquido;
                    griditens.CurrentRow.Cells[12].Value = (cell4 * cell5) - desconto - rep + ipinormal + fretenormal;


                    casasDecimais(Convert.ToDouble(griditens.CurrentRow.Cells[12].Value));
                    casasDecimais(Convert.ToDouble(griditens.CurrentRow.Cells[11].Value));
                    casasDecimais(Convert.ToDouble(griditens.CurrentRow.Cells[5].Value));

                    valor = 0;

                    foreach (DataGridViewRow linha in griditens.Rows)
                    {
                        if ((linha.Cells[12].Value != DBNull.Value))
                        {

                            valor += Convert.ToDouble(linha.Cells[12].Value);
                        }

                    }


                    double valort = valor;
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

                double cell5 = Convert.ToDouble(griditens.CurrentRow.Cells[5].Value);
                double cell4 = Convert.ToDouble(griditens.CurrentRow.Cells[4].Value);
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
                if (valida8 == "")
                {
                    griditens.CurrentRow.Cells[11].Value = 0;
                }
                double cell11 = Convert.ToDouble(griditens.CurrentRow.Cells[11].Value);

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


                    double freteliquido = cell5 * (frete / 100);
                    double fretenormal = cell4 * cell5 * (frete / 100);
                    double ipiliquido = cell5 * (ipi / 100);
                    double ipinormal = cell4 * cell5 * (ipi / 100);
                    double desliquido = cell5 * (desc / 100);
                    double repliquido = cell5 * (repasse / 100);
                    double desconto = cell4 * cell5 * (desc / 100);
                    double rep = cell4 * cell5 * (repasse / 100);

                    griditens.CurrentRow.Cells[11].Value = cell5 - desliquido - repliquido + ipiliquido + freteliquido;
                    griditens.CurrentRow.Cells[12].Value = (cell4 * cell5) - desconto - rep + ipinormal + fretenormal;



                    casasDecimais(Convert.ToDouble(griditens.CurrentRow.Cells[12].Value));
                    casasDecimais(Convert.ToDouble(griditens.CurrentRow.Cells[11].Value));

                    valor = 0;

                    foreach (DataGridViewRow linha in griditens.Rows)
                    {
                        if ((linha.Cells[12].Value != DBNull.Value))
                        {

                            valor += Convert.ToDouble(linha.Cells[12].Value);
                        }

                    }


                    double valort = valor;
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

                double cell5 = Convert.ToDouble(griditens.CurrentRow.Cells[5].Value);
                double cell4 = Convert.ToDouble(griditens.CurrentRow.Cells[4].Value);
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
                if (valida8 == "")
                {
                    griditens.CurrentRow.Cells[11].Value = 0;
                }
                double cell11 = Convert.ToDouble(griditens.CurrentRow.Cells[11].Value);

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

                    double freteliquido = cell5 * (frete / 100);
                    double fretenormal = cell4 * cell5 * (frete / 100);
                    double ipiliquido = cell5 * (ipi / 100);
                    double ipinormal = cell4 * cell5 * (ipi / 100);
                    double desliquido = cell5 * (desc / 100);
                    double repliquido = cell5 * (repasse / 100);
                    double desconto = cell4 * cell5 * (desc / 100);
                    double rep = cell4 * cell5 * (repasse / 100);

                    griditens.CurrentRow.Cells[11].Value = cell5 - desliquido - repliquido + ipiliquido + freteliquido;
                    griditens.CurrentRow.Cells[12].Value = (cell4 * cell5) - desconto - rep + ipinormal + fretenormal;




                    casasDecimais(Convert.ToDouble(griditens.CurrentRow.Cells[12].Value));
                    casasDecimais(Convert.ToDouble(griditens.CurrentRow.Cells[11].Value));

                    valor = 0;

                    foreach (DataGridViewRow linha in griditens.Rows)
                    {
                        if ((linha.Cells[12].Value != DBNull.Value))
                        {

                            valor += Convert.ToDouble(linha.Cells[12].Value);
                        }

                    }


                    double valort = valor;
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

                double cell5 = Convert.ToDouble(griditens.CurrentRow.Cells[5].Value);
                double cell4 = Convert.ToDouble(griditens.CurrentRow.Cells[4].Value);
                double cell9 = Convert.ToDouble(griditens.CurrentRow.Cells[9].Value);
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
                if (valida8 == "")
                {
                    griditens.CurrentRow.Cells[11].Value = 0;
                }
                double cell11 = Convert.ToDouble(griditens.CurrentRow.Cells[11].Value);

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

                    double freteliquido = cell5 * (frete / 100);
                    double fretenormal = cell4 * cell5 * (frete / 100);
                    double ipiliquido = cell5 * (ipi / 100);
                    double ipinormal = cell4 * cell5 * (ipi / 100);
                    double desliquido = cell5 * (desc / 100);
                    double repliquido = cell5 * (repasse / 100);
                    double desconto = cell4 * cell5 * (desc / 100);
                    double rep = cell4 * cell5 * (repasse / 100);

                    griditens.CurrentRow.Cells[11].Value = cell5 - desliquido - repliquido + ipiliquido + freteliquido;
                    griditens.CurrentRow.Cells[12].Value = (cell4 * cell5) - desconto - rep + ipinormal + fretenormal;



                    casasDecimais(Convert.ToDouble(griditens.CurrentRow.Cells[12].Value));
                    casasDecimais(Convert.ToDouble(griditens.CurrentRow.Cells[11].Value));


                    valor = 0;


                    foreach (DataGridViewRow linha in griditens.Rows)
                    {
                        if ((linha.Cells[12].Value != DBNull.Value))
                        {

                            valor += Convert.ToDouble(linha.Cells[12].Value);
                        }

                    }


                    double valort = valor;
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

                double cell5 = Convert.ToDouble(griditens.CurrentRow.Cells[5].Value);
                double cell4 = Convert.ToDouble(griditens.CurrentRow.Cells[4].Value);
                double cell10 = Convert.ToDouble(griditens.CurrentRow.Cells[10].Value);
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

                string valida100 = griditens.CurrentRow.Cells[10].Value.ToString();
                if (valida100 == "")
                {
                    griditens.CurrentRow.Cells[10].Value = 0;
                }
                double frete = Convert.ToDouble(griditens.CurrentRow.Cells[10].Value);
                string valida11 = griditens.CurrentRow.Cells[11].Value.ToString();
                if (valida8 == "")
                {
                    griditens.CurrentRow.Cells[11].Value = 0;
                }
                double cell11 = Convert.ToDouble(griditens.CurrentRow.Cells[11].Value);

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

                    double freteliquido = cell5 * (frete / 100);
                    double fretenormal = cell4 * cell5 * (frete / 100);
                    double ipiliquido = cell5 * (ipi / 100);
                    double ipinormal = cell4 * cell5 * (ipi / 100);
                    double desliquido = cell5 * (desc / 100);
                    double repliquido = cell5 * (repasse / 100);
                    double desconto = cell4 * cell5 * (desc / 100);
                    double rep = cell4 * cell5 * (repasse / 100);

                    griditens.CurrentRow.Cells[11].Value = cell5 - desliquido - repliquido + ipiliquido + freteliquido;
                    griditens.CurrentRow.Cells[12].Value = (cell4 * cell5) - desconto - rep + ipinormal + fretenormal;



                    valor = 0;

                    foreach (DataGridViewRow linha in griditens.Rows)
                    {
                        if ((linha.Cells[12].Value != DBNull.Value))
                        {

                            valor += Convert.ToDouble(linha.Cells[12].Value);
                        }

                    }


                    double valort = valor;
                    string convertido = String.Format("{0:N2}", Math.Round(valort, 2));
                    labTotal.Text = convertido;




                }
            }

        }
        public int casasDecimais(double d)
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
                        string edital = Convert.ToString(row.Cells[16].Value);
                        int itemedital = Convert.ToInt32(row.Cells[1].Value);
                        int qtd = Convert.ToInt32(row.Cells[4].Value);
                        double pcompra = Convert.ToInt32(row.Cells[5].Value);
                        double rpasse = Convert.ToDouble(txtrepasse.Text);
                        double desc = Convert.ToDouble(txtdesconto.Text);
                        double ipii = Convert.ToDouble(txtipi.Text);
                        double fretee = Convert.ToDouble(txtfrete.Text);
                        double creditoicms = Convert.ToDouble(this.txtcreditoicms.Text);
                        double icmsvenda = Convert.ToDouble(this.txticmsvenda.Text);
                        double pis = Convert.ToDouble(this.txtpis.Text);
                        double comissao = Convert.ToDouble(this.txtcomissao.Text);
                        double custofixo = Convert.ToDouble(this.txtcustofixo.Text);
                        double ml = Convert.ToDouble(this.txtml.Text);
                        double fretesaida = Convert.ToDouble(this.txtfretesaida.Text);
                        double imprenda = Convert.ToDouble(this.txtimprenda.Text);
                        double contsocial = Convert.ToDouble(this.txtcontSocial.Text);
                        int codf = Convert.ToInt32(cbofornecedor.SelectedValue);
                        double precocusto = 0;
                        if (rbt2casas.Checked == true)
                        {

                            string vlcusto = String.Format("{0:N2}", Math.Round(Convert.ToDouble(row.Cells[12].Value), 2));
                            precocusto = Convert.ToDouble(vlcusto);
                        }
                        else if (rbt4casas.Checked == true)
                        {
                            string vlcusto = String.Format("{0:N4}", (Convert.ToDouble(row.Cells[12].Value)));
                            precocusto = Convert.ToDouble(vlcusto);

                        }
                        int idedital = Convert.ToInt32(cbolicitacao.SelectedValue);

                        SqlConnection Cnn = Banco.CriarConexao();

                        string insert = "INSERT INTO VendaPreco(iditemedital,nlicitacao,qtde,precocompra,repasse,desconto,ipi,frete,creditoicms,icmsvenda,pis,comissao,custofixo,ml,fretesaida,precocusto,idusu,idfornecedo,imprenda,contsocial,idedital) " +
                            " VALUES (@iditemedital,@nlicitacao,@qtde,@precocompra,@repasse,@desconto,@ipi,@frete,@creditoicms,@icmsvenda,@pis,@comissao,@custofixo,@ml,@fretesaida,@precocusto,@idusu,@idfornecedor,@imprenda,@contsocial,@idedital)";

                        SqlCommand cmd = new SqlCommand(insert, Cnn);
                        cmd.Parameters.AddWithValue("@iditemedital", itemedital);
                        cmd.Parameters.AddWithValue("@nlicitacao", edital);
                        cmd.Parameters.AddWithValue("@qtde", qtd);
                        cmd.Parameters.AddWithValue("@precocompra", pcompra);
                        cmd.Parameters.AddWithValue("@repasse", rpasse);
                        cmd.Parameters.AddWithValue("@desconto", desc);
                        cmd.Parameters.AddWithValue("@ipi", ipii);
                        cmd.Parameters.AddWithValue("@frete", fretee);
                        cmd.Parameters.AddWithValue("@creditoicms", creditoicms);
                        cmd.Parameters.AddWithValue("@icmsvenda", icmsvenda);
                        cmd.Parameters.AddWithValue("@pis", pis);
                        cmd.Parameters.AddWithValue("@comissao", comissao);
                        cmd.Parameters.AddWithValue("@custofixo", custofixo);
                        cmd.Parameters.AddWithValue("@ml", ml);
                        cmd.Parameters.AddWithValue("@fretesaida", fretesaida);
                        cmd.Parameters.AddWithValue("@precocusto", precocusto);
                        cmd.Parameters.AddWithValue("@idusu", Banco.idusu);
                        cmd.Parameters.AddWithValue("@idfornecedor", codf);
                        cmd.Parameters.AddWithValue("@imprenda", imprenda);
                        cmd.Parameters.AddWithValue("@contsocial", contsocial);
                        cmd.Parameters.AddWithValue("@idedital", idedital);
                        Cnn.Open();
                        cmd.ExecuteNonQuery();
                        Cnn.Close();

                    }
                }
                //MessageBox.Show("Dados incluídos com sucesso !!", "Inclusão", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                ex.Message.ToString();
            }
        }

        public void AlterarDados(int iditemedital, string nlicitacao, int qtde, double precocompra, double repasse, double desconto, double ipi, double frete, double creditoicms, double icmsvenda, double pis, double comissao, double custofixo, double ml, double fretesaida, double precocusto, int idusu, int idfornecedor, double imprenda, double contsocial, int codpreco, int idedital)
        {



            SqlConnection Cnn = Banco.CriarConexao();

            string update = "UPDATE VendaPreco SET precocompra=@precocompra,repasse=@repasse,desconto=@desconto,ipi=@ipi,frete=@frete,creditoicms=@creditoicms,icmsvenda=@icmsvenda," +
                "pis=@pis,comissao=@comissao,custofixo=@custofixo,ml=@ml,fretesaida=@fretesaida,precocusto=@precocusto,idusu=@idusu,imprenda=@imprenda,contsocial=@contsocial,idfornecedor=@idfornecedor,idedital=@idedital WHERE idpreco=" + codpreco + "";
            SqlCommand cmd = new SqlCommand(update, Cnn);
            cmd.Parameters.AddWithValue("@precocompra", precocompra);
            cmd.Parameters.AddWithValue("@repasse", repasse);
            cmd.Parameters.AddWithValue("@desconto", desconto);
            cmd.Parameters.AddWithValue("@ipi", ipi);
            cmd.Parameters.AddWithValue("@frete", frete);
            cmd.Parameters.AddWithValue("@creditoicms", creditoicms);
            cmd.Parameters.AddWithValue("@icmsvenda", icmsvenda);
            cmd.Parameters.AddWithValue("@pis", pis);
            cmd.Parameters.AddWithValue("@comissao", comissao);
            cmd.Parameters.AddWithValue("@custofixo", custofixo);
            cmd.Parameters.AddWithValue("@ml", ml);
            cmd.Parameters.AddWithValue("@fretesaida", fretesaida);
            cmd.Parameters.AddWithValue("@precocusto", precocusto);
            cmd.Parameters.AddWithValue("@idusu", Banco.idusu);
            cmd.Parameters.AddWithValue("@idfornecedor", idfornecedor);
            cmd.Parameters.AddWithValue("@imprenda", imprenda);
            cmd.Parameters.AddWithValue("@contsocial", contsocial);
            cmd.Parameters.AddWithValue("@idedital", idedital);

            Cnn.Open();
            cmd.ExecuteNonQuery();
            Cnn.Close();



        }

        private void btnSalvar_Click(object sender, EventArgs e)
        {


        }


        private void FormarPreco()
        {

            try


            {

                foreach (DataGridViewRow row in griditens.Rows)
                {

                    if (bool.Parse(row.Cells[0].EditedFormattedValue.ToString()) == true)
                    {

                        int idedital = Convert.ToInt32(cbolicitacao.SelectedValue);
                        int itemedital = Convert.ToInt32(row.Cells[1].Value);
                        int qtd = Convert.ToInt32(row.Cells[4].Value);
                        double pcompra = Convert.ToDouble(row.Cells[5].Value);
                        double rpasse = Convert.ToDouble(txtrepasse.Text);
                        double desc = Convert.ToDouble(txtdesconto.Text);
                        double ipii = Convert.ToDouble(txtipi.Text);
                        double fretee = Convert.ToDouble(txtfrete.Text);
                        double creditoicms = Convert.ToDouble(this.txtcreditoicms.Text);
                        double icmsvenda = Convert.ToDouble(this.txticmsvenda.Text);
                        double pis = Convert.ToDouble(this.txtpis.Text);
                        double comissao = Convert.ToDouble(this.txtcomissao.Text);
                        double custofixo = Convert.ToDouble(this.txtcustofixo.Text);
                        double ml = Convert.ToDouble(this.txtml.Text);
                        double fretesaida = Convert.ToDouble(this.txtfretesaida.Text);
                        double precocusto = Convert.ToDouble(row.Cells[11].Value); 
                        int codf = Convert.ToInt32(row.Cells[15].Value);
                        double imprenda = Convert.ToDouble(this.txtimprenda.Text);
                        double contsocial = Convert.ToDouble(this.txtcontSocial.Text);
                        int codpreco = Convert.ToInt32(row.Cells[14].Value);
                        string edital = Convert.ToString(row.Cells[16].Value);
                        if (rbt2casas.Checked == true)
                        {

                            string vlcusto = String.Format("{0:N2}", Math.Round(Convert.ToDouble(row.Cells[12].Value), 2));
                            double vlc = Convert.ToDouble(vlcusto);
                            precocusto = Math.Round(vlc, 2);

                        }
                        else if (rbt4casas.Checked == true)
                        {
                            string vlcusto = String.Format("{0:N4}", Math.Abs(Convert.ToDouble(row.Cells[12].Value)));
                            double vlc = Convert.ToDouble(vlcusto);
                            precocusto = Math.Abs(vlc);



                        }

                        AlterarDados(itemedital, edital, qtd, pcompra, rpasse, desc, ipii, fretee, creditoicms, icmsvenda, pis, comissao, custofixo, ml, fretesaida, precocusto, Banco.idusu, codf, imprenda, contsocial,codpreco, idedital);

                    }
                }
            }
            catch (Exception erro)
            {

                throw erro;
            }

            GrvavaFornecedorProposta();


        }


        private void GrvavaFornecedorProposta()
        {


            try
            {

                foreach (DataGridViewRow row in griditens.Rows)
                {

                    if (bool.Parse(row.Cells[0].EditedFormattedValue.ToString()) == true)
                    {
                        int iditem = Convert.ToInt32(row.Cells[1].Value);
                        int codf = Convert.ToInt32(row.Cells[15].Value);
                        int idedital = Convert.ToInt32(cbolicitacao.SelectedValue);
                        double precovenda = Convert.ToDouble(row.Cells[5].Value);
                        string edital = Convert.ToString(row.Cells[16].Value);

                        if (VerificaRegistroExisteProposta(iditem, idedital) == true)


                        {
                            SqlConnection Cnn = Banco.CriarConexao();

                            string insert = "INSERT INTO Proposta(iditemedital,selecionado,cotado,idusu,ganho,margemfinal,precovenda,casasdecimais,idfornecedor,edital,idedital) VALUES " +
                                    "(@iditemedital,@selecionado,@cotado,@idusu,@ganho,@margemfinal,@precovenda,@casasdecimais,@idfornecedor,@edital,@idedital)";
                            SqlCommand cmd = new SqlCommand(insert, Cnn);
                            cmd.Parameters.AddWithValue("@iditemedital", iditem);
                            cmd.Parameters.AddWithValue("@selecionado", "NAO");
                            cmd.Parameters.AddWithValue("@cotado", "SIM");
                            cmd.Parameters.AddWithValue("@idusu", Banco.idusu);
                            cmd.Parameters.AddWithValue("@ganho", 1);
                            cmd.Parameters.AddWithValue("@margemfinal", 0);
                            cmd.Parameters.AddWithValue("@precovenda", 0);
                            cmd.Parameters.AddWithValue("@casasdecimais", 2);
                            cmd.Parameters.AddWithValue("@idfornecedor", codf);
                            cmd.Parameters.AddWithValue("@edital", edital);
                            cmd.Parameters.AddWithValue("@idedital", idedital);
                            Cnn.Open();
                            cmd.ExecuteNonQuery();
                            Cnn.Close();

                        }

                        else

                        {
                            SqlConnection Cnn = Banco.CriarConexao();

                            string update = "UPDATE Proposta SET selecionado=@selecionado,cotado=@cotado,idusu=@idusu,ganho=@ganho,margemfinal=@margemfinal,precovenda=@precovenda," +
                                    "casasdecimais=@casasdecimais,idfornecedor=@idfornecedor,idedital=@idedital WHERE iditemedital=@iditemedital and idedital=@idedital";

                            SqlCommand cmd = new SqlCommand(update, Cnn);
                            cmd.Parameters.AddWithValue("@iditemedital", iditem);
                            cmd.Parameters.AddWithValue("@selecionado", "NAO");
                            cmd.Parameters.AddWithValue("@cotado", "SIM");
                            cmd.Parameters.AddWithValue("@idusu", Banco.idusu);
                            cmd.Parameters.AddWithValue("@ganho", 1);
                            cmd.Parameters.AddWithValue("@margemfinal", 0);
                            cmd.Parameters.AddWithValue("@precovenda", 0);
                            cmd.Parameters.AddWithValue("@casasdecimais", 2);
                            cmd.Parameters.AddWithValue("@idfornecedor", codf);
                            cmd.Parameters.AddWithValue("@edital", edital);
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


        private Boolean VerificaRegistroExiste(int cod)
        {

            SqlConnection Cnn = Banco.CriarConexao();
            string obter = ("Select * From VendaPreco Where idpreco = " + cod + "");
            SqlCommand sql = new SqlCommand(obter, Cnn);
            Cnn.Open();
            SqlDataReader dr = sql.ExecuteReader();
            if (dr.Read())
            {

                return false;
            }
            return true;


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
                        retTributacao(codret);
                        RetRegCmd(Convert.ToInt32(cbofornecedor.SelectedValue), codret);


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
            if ((Keys)e.KeyChar == Keys.Enter)
            {
                if (txtnritem.Text != "")
                {
                    carregarGridItensNrItem(txtnritem.Text);
                }


            }

        }
        private void carregarGridItensNrItem(string Nritem)
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
                string strConn = "Select DISTINCT ItemsLicitacao.iditemedital as Cod,ItemsLicitacao.nritem as NºItem,ItemsLicitacao.lote as Lote,Produto.nome as PrincipioAtivo, UnidadeMedida.nome as Unidade,ItemsLicitacao.qtde as Qtde, " +
                    "RetCotacao.preco as Preco,RetCotacao.desconto as Dsc, RetCotacao.repasse as Repasse, RetCotacao.Ipi as Ipi, RetCotacao.frete as Frete, RetCotacao.liquido as Custo,VendaPreco.precocusto as Venda, (ItemsLicitacao.qtde * VendaPreco.precocusto) as VlTotal,VendaPreco.idpreco as CodPreco, Fornecedor.idfornecedor as Codfor" +
                " from ItemsLicitacao LEFT JOIN RetCotacao ON ItemsLicitacao.iditemedital = RetCotacao.iditemedital  LEFT JOIN VendaPreco ON ItemsLicitacao.iditemedital = VendaPreco.iditemedital,UnidadeMedida,PrincipioAtivo,Produto,Fornecedor,LancEditais Where LancEditais.idedital = ItemsLicitacao.idedital AND  Produto.idprincipio = PrincipioAtivo.idprincipio AND ItemsLicitacao.idprincipio = PrincipioAtivo.idprincipio AND ItemsLicitacao.idunidade = UnidadeMedida.idunidade AND " +
                "Produto.idproduto = ItemsLicitacao.idproduto  AND Fornecedor.idfornecedor = RetCotacao.idfornecedor AND ItemsLicitacao.nritem='" + Nritem + "'  AND ItemsLicitacao.idedital=" + cbolicitacao.SelectedValue + "";


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
            griditens.Columns.Add("PrincipioAtivo", "PrincipioAtivo");
            griditens.Columns.Add("Qtde", "Qtde");
            griditens.Columns.Add("Preco", "Preco");
            griditens.Columns.Add("Unidade", "Unidade");
            griditens.Columns.Add("Dsc", "Dsc");
            griditens.Columns.Add("Repasse", "Repasse");
            griditens.Columns.Add("Ipi", "Ipi");
            griditens.Columns.Add("Frete", "Frete");
            griditens.Columns.Add("Custo", "Custo");
            griditens.Columns.Add("Venda", "Venda");
            griditens.Columns.Add("VlTotal", "VlTotal");
            griditens.Columns.Add("CodPreco", "CodPreco");
            griditens.Columns.Add("Codfor", "Codfor");


            griditens.Columns[0].Width = 50;
            griditens.Columns[1].Width = 50;
            griditens.Columns[2].Width = 80;
            griditens.Columns[3].Width = 350;
            griditens.Columns[4].Width = 70;
            griditens.Columns[5].Width = 82;
            griditens.Columns[6].Width = 150;
            griditens.Columns[7].Width = 40;
            griditens.Columns[8].Width = 80;
            griditens.Columns[9].Width = 40;
            griditens.Columns[10].Width = 60;
            griditens.Columns[11].Width = 80;
            griditens.Columns[12].Width = 85;
            griditens.Columns[13].Width = 118;
            griditens.Columns[14].Visible = false;
            griditens.Columns[15].Visible = false;


            griditens.Columns[1].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft;
            griditens.Columns[5].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft;
            griditens.Columns[4].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft;
            griditens.Columns[10].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            griditens.Columns[11].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            griditens.Columns[12].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;

            griditens.Columns[1].DataPropertyName = "Cod";
            griditens.Columns[2].DataPropertyName = "NºItem";
            griditens.Columns[3].DataPropertyName = "PrincipioAtivo";
            griditens.Columns[4].DataPropertyName = "Qtde";
            griditens.Columns[5].DataPropertyName = "Preco";
            griditens.Columns[6].DataPropertyName = "Unidade";
            griditens.Columns[7].DataPropertyName = "Dsc";
            griditens.Columns[8].DataPropertyName = "Repasse";
            griditens.Columns[9].DataPropertyName = "Ipi";
            griditens.Columns[10].DataPropertyName = "Frete";
            griditens.Columns[11].DataPropertyName = "Custo";
            griditens.Columns[12].DataPropertyName = "Venda";
            griditens.Columns[13].DataPropertyName = "VlTotal";
            griditens.Columns[14].DataPropertyName = "CodPreco";
            griditens.Columns[15].DataPropertyName = "Codfor";


            griditens.Columns[7].DefaultCellStyle.Format = "#.00\\%";
            griditens.Columns[8].DefaultCellStyle.Format = "#.00\\%";
            griditens.Columns[9].DefaultCellStyle.Format = "#.00\\%";
            griditens.Columns[10].DefaultCellStyle.Format = "#.00\\%";

            griditens.Columns[11].DefaultCellStyle.Format = "c";
            // griditens.Columns[12].DefaultCellStyle.Format = "c";
            griditens.Columns[13].DefaultCellStyle.Format = "c";
            griditens.Columns[5].DefaultCellStyle.Format = "c";


            valor = 0;

            foreach (DataGridViewRow linha in griditens.Rows)
            {
                if ((linha.Cells[13].Value != DBNull.Value))
                {

                    valor += Convert.ToDouble(linha.Cells[13].Value);
                }

            }


            double valort = valor;
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

        }

        private void btnFormarPreco_Click(object sender, EventArgs e)
        {

            foreach (DataGridViewRow rows in griditens.Rows)
            { // passar por todas as linhas do dg
                var cel = rows.Cells[0] as DataGridViewCheckBoxCell; //pegar a celula que tem o checkbox


                bool aChecked = (null != cel && null != cel.Value && true == (bool)cel.Value);
                if (aChecked)
                { //ver


                    {
                        //if (!cbofornecedor.SelectedIndex.Equals(-1))
                        //{

                        double cell11 = 0;
                        double repasse = 0;
                        double desconto = 0;
                        double ipi = 0;
                        double frete = 0;
                        double creditoicms = 0;
                        double icmsvenda = 0;
                        double pis = 0;
                        double comissao = 0;
                        double custofixo = 0;
                        double ml = 0;
                        double fretesaida = 0;
                        double calculacusto = 0;
                        double imprenda = 0;
                        double consocial = 0;

                        foreach (DataGridViewRow row in griditens.Rows)
                        { // passar por todas as linhas do dg
                            var cell = row.Cells[0] as DataGridViewCheckBoxCell; //pegar a celula que tem o checkbox


                            bool bChecked = (null != cell && null != cell.Value && true == (bool)cell.Value);
                            if (bChecked)
                            { //verificar se está marcado



                                cell11 = Convert.ToDouble(row.Cells[11].Value);
                                repasse = Convert.ToDouble(row.Cells[11].Value) * (Convert.ToDouble(txtrepasse.Text) / 100);
                                desconto = Convert.ToDouble(row.Cells[11].Value) * (Convert.ToDouble(txtdesconto.Text) / 100);
                                ipi = Convert.ToDouble(row.Cells[11].Value) * (Convert.ToDouble(txtipi.Text) / 100);
                                frete = Convert.ToDouble(row.Cells[11].Value) * (Convert.ToDouble(txtfrete.Text) / 100);
                                creditoicms = Convert.ToDouble(row.Cells[11].Value) * (Convert.ToDouble(this.txtcreditoicms.Text) / 100);
                                icmsvenda = Convert.ToDouble(row.Cells[11].Value) * (Convert.ToDouble(this.txticmsvenda.Text) / 100);
                                pis = Convert.ToDouble(row.Cells[11].Value) * (Convert.ToDouble(this.txtpis.Text) / 100);
                                // cofins = Convert.ToDouble(row.Cells[11].Value) * (Convert.ToDouble(this.txtcofins.Text) / 100);
                                comissao = Convert.ToDouble(row.Cells[11].Value) * (Convert.ToDouble(this.txtcomissao.Text) / 100);
                                custofixo = Convert.ToDouble(row.Cells[11].Value) * (Convert.ToDouble(this.txtcustofixo.Text) / 100);
                                ml = Convert.ToDouble(row.Cells[11].Value) * (Convert.ToDouble(this.txtml.Text) / 100);
                                fretesaida = Convert.ToDouble(row.Cells[11].Value) * (Convert.ToDouble(this.txtfretesaida.Text) / 100);
                                imprenda = Convert.ToDouble(row.Cells[11].Value) * (Convert.ToDouble(this.txtimprenda.Text) / 100);
                                consocial = Convert.ToDouble(row.Cells[11].Value) * (Convert.ToDouble(this.txtcontSocial.Text) / 100);

                                calculacusto = (cell11 + repasse + desconto + ipi + frete + creditoicms + icmsvenda + pis + comissao + custofixo + ml + fretesaida + imprenda + consocial);


                                row.Cells[12].Value = calculacusto;

                                row.Cells[13].Value = Convert.ToDouble(row.Cells[12].Value) * Convert.ToDouble(row.Cells[4].Value);

                            }



                        }

                        valor = 0;
                        foreach (DataGridViewRow linha in griditens.Rows)
                        {
                            if ((linha.Cells[13].Value != DBNull.Value))
                            {

                                valor += Convert.ToDouble(linha.Cells[13].Value);
                            }

                        }


                        double valort = valor;
                        string convertido = String.Format("{0:N2}", Math.Round(valort, 2));
                        labTotal.Text = convertido;


                        griditens.Refresh();

                        FormarPreco();
                        //}
                        //else
                        //{
                        //    MessageBox.Show("Favor Informar o nome do Fornecedor!");
                        //    chkFornecedor.Checked = true;

                        //}
                    }
                }
                //else
                //{
                //    MessageBox.Show("Favor Selecionar o Item!");

                //}
            }

        }

        private void chkTodos_CheckedChanged(object sender, EventArgs e)
        {
            foreach (DataGridViewRow row in griditens.Rows)
            {
                DataGridViewCheckBoxCell chkb = (DataGridViewCheckBoxCell)row.Cells[0];
                chkb.Value = !(chkb.Value == null ? false : (bool)chkb.Value); //because chk.Value is initialy null
            }
        }

        private void label22_Click(object sender, EventArgs e)
        {

        }

        private void txtrepasse_KeyPress(object sender, KeyPressEventArgs e)
        {
            ((TextBox)sender).SelectionStart = 0;
            ((TextBox)sender).SelectAll();
            if ((Keys)e.KeyChar == Keys.Enter)
            {

                double repasse = Convert.ToDouble(this.txtrepasse.Text);
                this.txtrepasse.Text = String.Format("{0:N2}", Math.Round(repasse, 2));


                this.txtdesconto.Focus();
            }
        }

        private void txtdesconto_KeyPress(object sender, KeyPressEventArgs e)
        {
            if ((Keys)e.KeyChar == Keys.Enter)
            {

                double desconto = Convert.ToDouble(this.txtdesconto.Text);
                this.txtdesconto.Text = String.Format("{0:N2}", Math.Round(desconto, 2));


                this.txtipi.Focus();
            }
        }

        private void txtipi_KeyPress(object sender, KeyPressEventArgs e)
        {
            if ((Keys)e.KeyChar == Keys.Enter)
            {

                double ipi = Convert.ToDouble(this.txtipi.Text);
                this.txtipi.Text = String.Format("{0:N2}", Math.Round(ipi, 2));


                this.txtfrete.Focus();
            }
        }

        private void txtfrete_KeyPress(object sender, KeyPressEventArgs e)
        {
            if ((Keys)e.KeyChar == Keys.Enter)
            {

                double frete = Convert.ToDouble(this.txtfrete.Text);
                this.txtfrete.Text = String.Format("{0:N2}", Math.Round(frete, 2));


                this.txtcreditoicms.Focus();
            }
        }

        private void txtcreditoicms_KeyPress(object sender, KeyPressEventArgs e)
        {
            if ((Keys)e.KeyChar == Keys.Enter)
            {

                double creditoicms = Convert.ToDouble(this.txtcreditoicms.Text);
                this.txtcreditoicms.Text = String.Format("{0:N2}", Math.Round(creditoicms, 2));


                this.txticmsvenda.Focus();
            }
        }

        private void txticmsvenda_KeyPress(object sender, KeyPressEventArgs e)
        {
            if ((Keys)e.KeyChar == Keys.Enter)
            {

                double icmsvenda = Convert.ToDouble(this.txticmsvenda.Text);
                this.txticmsvenda.Text = String.Format("{0:N2}", Math.Round(icmsvenda, 2));


                this.txtpis.Focus();
            }
        }

        private void txtpis_KeyPress(object sender, KeyPressEventArgs e)
        {
            if ((Keys)e.KeyChar == Keys.Enter)
            {

                double pis = Convert.ToDouble(this.txtpis.Text);
                this.txtpis.Text = String.Format("{0:N2}", Math.Round(pis, 2));


                this.txtcomissao.Focus();
            }
        }



        private void txtcomissao_KeyPress(object sender, KeyPressEventArgs e)
        {
            if ((Keys)e.KeyChar == Keys.Enter)
            {

                double comissao = Convert.ToDouble(this.txtcomissao.Text);
                this.txtcomissao.Text = String.Format("{0:N2}", Math.Round(comissao, 2));


                this.txtcustofixo.Focus();
            }
        }

        private void txtcustofixo_KeyPress(object sender, KeyPressEventArgs e)
        {
            if ((Keys)e.KeyChar == Keys.Enter)
            {

                double custofixo = Convert.ToDouble(this.txtcustofixo.Text);
                this.txtcustofixo.Text = String.Format("{0:N2}", Math.Round(custofixo, 2));


                this.txtml.Focus();
            }
        }

        private void txtml_KeyPress(object sender, KeyPressEventArgs e)
        {
            if ((Keys)e.KeyChar == Keys.Enter)
            {

                double ml = Convert.ToDouble(this.txtml.Text);
                this.txtml.Text = String.Format("{0:N2}", Math.Round(ml, 2));


                this.txtfretesaida.Focus();
            }
        }

        private void txtfretesaida_KeyPress(object sender, KeyPressEventArgs e)
        {
            if ((Keys)e.KeyChar == Keys.Enter)
            {

                double fretesaida = Convert.ToDouble(this.txtfretesaida.Text);
                this.txtfretesaida.Text = String.Format("{0:N2}", Math.Round(fretesaida, 2));


                this.txtimprenda.Focus();
            }
        }

        private void rbt2casas_CheckedChanged(object sender, EventArgs e)
        {
            carregarGrid2CasasDecimais();

        }
        private void carregarGrid2CasasDecimais()
        {


            this.griditens.RowsDefaultCellStyle.BackColor = Color.LightBlue;
            this.griditens.AlternatingRowsDefaultCellStyle.BackColor = Color.Azure;


            griditens.AutoGenerateColumns = false;
            //exibe os dados no datagridview


            griditens.Columns[1].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft;
            griditens.Columns[5].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft;
            griditens.Columns[4].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft;
            griditens.Columns[10].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            griditens.Columns[11].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            griditens.Columns[12].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;


            griditens.Columns[7].DefaultCellStyle.Format = "#.00\\%";
            griditens.Columns[8].DefaultCellStyle.Format = "#.00\\%";
            griditens.Columns[9].DefaultCellStyle.Format = "#.00\\%";
            griditens.Columns[10].DefaultCellStyle.Format = "#.00\\%";

            griditens.Columns[11].DefaultCellStyle.Format = "n2";
            griditens.Columns[12].DefaultCellStyle.Format = "n2";
            griditens.Columns[13].DefaultCellStyle.Format = "n2";
            griditens.Columns[5].DefaultCellStyle.Format = "n2";


            valor = 0;

            foreach (DataGridViewRow linha in griditens.Rows)
            {
                if ((linha.Cells[13].Value != DBNull.Value))
                {

                    valor += Convert.ToDouble(linha.Cells[13].Value);
                }

            }


            double valort = valor;
            string convertido = String.Format("{0:N2}", Math.Round(valort, 2));
            labTotal.Text = convertido;


            griditens.Refresh();


        }
        private void carregarGrid4CasasDecimais()
        {



            this.griditens.RowsDefaultCellStyle.BackColor = Color.LightBlue;
            this.griditens.AlternatingRowsDefaultCellStyle.BackColor = Color.Azure;


            griditens.AutoGenerateColumns = false;
            //exibe os dados no datagridview


            griditens.Columns[1].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft;
            griditens.Columns[5].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft;
            griditens.Columns[4].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft;
            griditens.Columns[10].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            griditens.Columns[11].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            griditens.Columns[12].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;


            griditens.Columns[7].DefaultCellStyle.Format = "#.00\\%";
            griditens.Columns[8].DefaultCellStyle.Format = "#.00\\%";
            griditens.Columns[9].DefaultCellStyle.Format = "#.00\\%";
            griditens.Columns[10].DefaultCellStyle.Format = "#.00\\%";

            griditens.Columns[11].DefaultCellStyle.Format = "n4";
            griditens.Columns[12].DefaultCellStyle.Format = "n4";
            griditens.Columns[13].DefaultCellStyle.Format = "n4";
            griditens.Columns[5].DefaultCellStyle.Format = "n4";


            valor = 0;

            foreach (DataGridViewRow linha in griditens.Rows)
            {
                if ((linha.Cells[13].Value != DBNull.Value))
                {

                    valor += Convert.ToDouble(linha.Cells[13].Value);
                }

            }


            double valort = valor;
            string convertido = String.Format("{0:N4}", Math.Round(valort, 4));
            labTotal.Text = convertido;


            griditens.Refresh();


        }

        private void rbt4casas_CheckedChanged(object sender, EventArgs e)
        {
            carregarGrid4CasasDecimais();
        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }

        private void ViewFormacaoPreco_Load(object sender, EventArgs e)
        {


        }

        private void rbt3casas_CheckedChanged(object sender, EventArgs e)
        {
            this.griditens.RowsDefaultCellStyle.BackColor = Color.LightBlue;
            this.griditens.AlternatingRowsDefaultCellStyle.BackColor = Color.Azure;


            griditens.AutoGenerateColumns = false;
            //exibe os dados no datagridview


            griditens.Columns[1].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft;
            griditens.Columns[5].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft;
            griditens.Columns[4].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft;
            griditens.Columns[10].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            griditens.Columns[11].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            griditens.Columns[12].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;


            griditens.Columns[7].DefaultCellStyle.Format = "#.00\\%";
            griditens.Columns[8].DefaultCellStyle.Format = "#.00\\%";
            griditens.Columns[9].DefaultCellStyle.Format = "#.00\\%";
            griditens.Columns[10].DefaultCellStyle.Format = "#.00\\%";

            griditens.Columns[11].DefaultCellStyle.Format = "n3";
            griditens.Columns[12].DefaultCellStyle.Format = "n3";
            griditens.Columns[13].DefaultCellStyle.Format = "n3";
            griditens.Columns[5].DefaultCellStyle.Format = "n3";


            valor = 0;

            foreach (DataGridViewRow linha in griditens.Rows)
            {
                if ((linha.Cells[13].Value != DBNull.Value))
                {

                    valor += Convert.ToDouble(linha.Cells[13].Value);
                }

            }


            double valort = valor;
            string convertido = String.Format("{0:N3}", Math.Round(valort, 3));
            labTotal.Text = convertido;


            griditens.Refresh();
        }

        private void txtimprenda_KeyPress(object sender, KeyPressEventArgs e)
        {
            if ((Keys)e.KeyChar == Keys.Enter)
            {

                double imprenda = Convert.ToDouble(this.txtimprenda.Text);
                this.txtimprenda.Text = String.Format("{0:N2}", Math.Round(imprenda, 2));


                this.txtcontSocial.Focus();
            }
        }

        private void txtcontSocial_KeyPress(object sender, KeyPressEventArgs e)
        {
            if ((Keys)e.KeyChar == Keys.Enter)
            {

                double contsocial = Convert.ToDouble(this.txtcontSocial.Text);
                this.txtcontSocial.Text = String.Format("{0:N2}", Math.Round(contsocial, 2));


                this.btnFormarPreco.Focus();
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            ConsProdutoPreco frmc = new ConsProdutoPreco();
            frmc.Show();
        }

        private void btnSair_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void Limpacampos()
        {
            txtrepasse.Text = "0";
            txtdesconto.Text = "0";
            txtipi.Text = "0";
            txtfrete.Text = "0";
            txtcreditoicms.Text = "0";
            txticmsvenda.Text = "0";
            txtpis.Text = "0";
            txtcomissao.Text = "0";
            txtcustofixo.Text = "0";
            txtml.Text = "0";
            txtimprenda.Text = "0";
            txtcontSocial.Text = "0";
            txtcreditoicms.Text = "0";
            cbofornecedor.SelectedIndex = -1;
            cbolicitacao.SelectedIndex = -1;
            txtnritem.Text = "";
            labTotal.Text = "0";
            griditens.DataSource = null;
            txtfrete.Text = "0";
            cbolicitacao.Focus();

        }

        private void button2_Click(object sender, EventArgs e)
        {
            Limpacampos();
        }

        private void txtrepasse_MouseClick(object sender, MouseEventArgs e)
        {
            ((TextBox)sender).SelectionStart = 0;
            ((TextBox)sender).SelectAll();
        }
    }
}
