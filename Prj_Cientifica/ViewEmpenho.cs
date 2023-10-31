using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO.Compression;
using System.Windows.Forms;
using System.Configuration;

namespace Prj_Cientifica
{
    public partial class ViewEmpenho : Form
    {
        public static int codselecionado;
        public int casas;
        public int iditemedt;
        public int coditemempenho;
        public int codempenho;
        public int ideditalempenho;
        public int editalrel;
        public string numeroempenho;
        public string codedital;
        public string notafiscal;
        public string dtrecebimento;
        public string dtlimite;
        public int idcli;
        public int idedital;
        public string ata;
        public string ndoc;
        public string dtvigencia;


        public ViewEmpenho()
        {
            InitializeComponent();

        }

        public ViewEmpenho(ConsEmpenho frm) : this()
        {
            codselecionado = frm.codempenho;
            idedital = frm.idedital;
            codedital = frm.Edital;

            RetReg(codselecionado);

        }


        public ViewEmpenho(ConsNovoEmpenho frm) : this()
        {
            codedital = frm.Edital;
            idedital = frm.idedital;

            RetRegNovo(idedital);

        }

        public ViewEmpenho(ViewAdicionaItemsEmpenho frm) : this()
        {
            RetornarCarregarLicitacaoItems(Convert.ToInt32(frm.idedital));
            txtempenho.Text = Convert.ToString(frm.numeroempenho);
            RetornaCliente(Convert.ToInt32(frm.idedital));
            mskdtrec.Text = frm.dtrecebimento;
            mskdtentrega.Text = frm.dtentrega;
            txtnfiscal.Text = frm.notafiscal;
            codedital = frm.codedital;
            txtatacontrato.Text = frm.ata;
            mskvigencia.Text = frm.dtvigencia;

            this.txtitem.Text = frm.nritem; ;
            decimal pcompra = frm.vlvenda;
            this.txtpreco.Text = String.Format("{0:N2}", pcompra, 2);
            iditemedt = frm.iditemedital;
            //AditivoItem = Convert.ToInt32(dr["vladitivo";
            principioID = frm.idprincipio;
            lote = Convert.ToString(frm.lote);
            realinhamentoID = frm.idrealinhamento;
            editalitemID = frm.iditemedital;
            marcaID = frm.idmarca;
            produtoID = frm.idproduto;
            RetornaPrincipio(produtoID);
            labqtdetotal.Text = Convert.ToString(frm.vlvenda);
            labqtdetotal.Text = Convert.ToString(frm.qtde);
            CarregaGridNumeroEmpenho(txtempenho.Text);
            cboempenho.Text = "SIM";
            codempenho = frm.codempenho;
            txtcodigo.Text = Convert.ToString(codempenho);




        }



        private void RetReg(int codsel)
        {

            string reg = "Select Empenho.*, EmpenhoItems.iditemedital, EmpenhoItems.notafiscal FROM  Empenho LEFT JOIN EmpenhoItems ON  Empenho.idempenho = EmpenhoItems.idempenho  Where  Empenho.idempenho=" + codsel + "";
            DataTable ds = new DataTable();
            SqlConnection Conn = Banco.CriarConexao();
            Conn.Open();

            if (Conn.State == ConnectionState.Open)
            {
                SqlCommand cmd = new SqlCommand(reg, Conn);
                SqlDataReader dr = cmd.ExecuteReader();
                if (dr.Read())
                {
                    txtcodigo.Text = dr["idempenho"].ToString();
                    txtempenho.Text = dr["nempenho"].ToString();
                    //txtnfiscal.Text = dr["notafiscal"].ToString();
                    mskdtrec.Text = dr["dtrecimento"].ToString();
                    mskdtentrega.Text = dr["dtlimite"].ToString();
                    this.txtobs.Text = dr["obs"].ToString();
                    this.txtatacontrato.Text = dr["ata"].ToString();
                    this.mskvigencia.Text = dr["dtvigencia"].ToString();
                    if (dr["notafiscal"].ToString() != "")
                    {
                        this.txtnfiscal.Text = dr["notafiscal"].ToString();
                    }
                    else
                    {
                        this.txtnfiscal.Text = "";
                    }
                    RetronarCarregarLicitacaoNumeroEmpenho(Convert.ToInt32(dr["idedital"].ToString()));
                    RetornaStatusCasasNumeroEmpenho(Convert.ToInt32(dr["idedital"].ToString()));
                    CarregaGridNumeroEmpenho(dr["nempenho"].ToString());
                    RetornaCliente(Convert.ToInt32(dr["idedital"].ToString()));
                    if (!String.IsNullOrEmpty(dr["idedital"].ToString()))
                    {
                        int codidedital = Convert.ToInt32(dr["idedital"].ToString());
                        CarregaGridArquivos();
                    }

                }
            }

        }


        private void RetRegNovo(int edt)
        {

            string reg = "Select LancEditais.idedital as idedital FROM  LancEditais LEFT JOIN Empenho ON  LancEditais.idedital = Empenho.idedital  Where  LancEditais.idedital=" + edt + "";
            DataTable ds = new DataTable();
            SqlConnection Conn = Banco.CriarConexao();
            Conn.Open();

            if (Conn.State == ConnectionState.Open)
            {
                SqlCommand cmd = new SqlCommand(reg, Conn);
                SqlDataReader dr = cmd.ExecuteReader();
                if (dr.Read())
                {


                    RetronarCarregarLicitacaoNumeroEmpenho(Convert.ToInt32(dr["idedital"].ToString()));
                    RetornaStatusCasasNumeroEmpenho(Convert.ToInt32(dr["idedital"].ToString()));
                    RetornaCliente(Convert.ToInt32(dr["idedital"].ToString()));


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


        private void RetornarCarregarLicitacaoItems(int idedital)
        {
            SqlConnection Cnn = Banco.CriarConexao();
            SqlDataAdapter sql = new SqlDataAdapter("Select LancEditais.idedital,LancEditais.nlicitacao,(CAST(LancEditais.nlicitacao AS VARCHAR(10))) + '               ' + (Modalidade.nome + '                    ' +  LancEditais.nlicitacao + '                        ' + " +
                "LancEditais.nprocesso + '                       ' + CONVERT(CHAR,LancEditais.dtabertura,103) + '          ' + Cliente.nome) as Licitacao  from LancEditais,Modalidade,Cliente " +
                " WHERE LancEditais.idmodalidade = Modalidade.idmodalidade and LancEditais.idcliente =  Cliente.idcliente and LancEditais.idedital=" + idedital + "", Cnn);
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
            SqlDataAdapter sql = new SqlDataAdapter("Select  LancEditais.idedital,LancEditais.nlicitacao,(CAST(LancEditais.nlicitacao AS VARCHAR(10))) + '               ' + (Modalidade.nome + '                    ' +  LancEditais.nlicitacao + '                        ' + " +
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


        private void RetronarCarregarLicitacaoNumeroEmpenho(int retedt)
        {
            SqlConnection Cnn = Banco.CriarConexao();
            SqlDataAdapter sql = new SqlDataAdapter("Select  LancEditais.idedital,LancEditais.nlicitacao,(CAST(LancEditais.nlicitacao AS VARCHAR(10))) + '               ' + (Modalidade.nome + '                    ' +  LancEditais.nlicitacao + '                        ' + " +
                "LancEditais.nprocesso + '                       ' + CONVERT(CHAR,LancEditais.dtabertura,103) + '          ' + Cliente.nome) as Licitacao  from LancEditais,Modalidade,Cliente " +
                " WHERE LancEditais.idmodalidade = Modalidade.idmodalidade and LancEditais.idcliente =  Cliente.idcliente and LancEditais.idedital='" + retedt + "'", Cnn);
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



        private void cbolicitacao_Click(object sender, EventArgs e)
        {
            CarregarLicitacao();
        }

        private void cbolicitacao_SelectionChangeCommitted(object sender, EventArgs e)
        {
            SqlConnection Cnn = Banco.CriarConexao();
            SqlDataAdapter sql = new SqlDataAdapter("Select * from LancEditais,Cliente " +
                " WHERE LancEditais.idcliente = Cliente.idcliente And LancEditais.idedital=" + cbolicitacao.SelectedValue + "", Cnn);
            DataSet Dt = new DataSet();
            sql.Fill(Dt);
            BindingSource bs = new BindingSource();
            bs.DataSource = Dt;
            bs.DataMember = Dt.Tables[0].TableName;

            try
            {
                this.cbocliente.DataSource = bs;
                this.cbocliente.DisplayMember = "nome";
                this.cbocliente.ValueMember = "idcliente";
                // this.cbocliente.SelectedIndex = cbolicitacao.Items.Count - 1;



            }
            catch (Exception erro)
            {

                throw erro;
            }
            Cnn.Close();

            RetornaStatusCasas();
            // carregarGridItens();
            //CarregaGridArquivos();
            //RetornaEmpenho();

        }


        private void CarregarPrincipioAtivo()
        {
            SqlConnection Cnn = Banco.CriarConexao();
            SqlDataAdapter sql = new SqlDataAdapter("Select DISTINCT Produto.nome, Produto.idproduto FROM Produto,LancEditais,ItemsLicitacao,RealinhamentoProposta " +
           "WHERE LancEditais.idedital = ItemsLicitacao.idedital and ItemsLicitacao.idproduto = Produto.idproduto  AND ItemsLicitacao.iditemedital = RealinhamentoProposta.iditemedital", Cnn);
            DataSet Dt = new DataSet();
            sql.Fill(Dt, "Produto");
            DataRow dr = Dt.Tables["Produto"].NewRow();
            dr[0] = "";
            Dt.Tables["Produto"].Rows.Add(dr);
            try
            {

                this.cboprincipio.DisplayMember = "nome";
                this.cboprincipio.ValueMember = "idproduto";
                this.cboprincipio.DataSource = Dt.Tables["Produto"];
                this.cboprincipio.SelectedIndex = cboprincipio.Items.Count - 1;



            }
            catch (Exception erro)
            {

                throw erro;
            }
            Cnn.Close();
        }
        private void RetornaPrincipio(Int32 retprincipio)
        {
            SqlConnection Cnn = Banco.CriarConexao();
            SqlDataAdapter sql = new SqlDataAdapter("Select Produto.nome, Produto.idproduto FROM Produto,LancEditais,ItemsLicitacao,RealinhamentoProposta " +
                "WHERE LancEditais.idedital = ItemsLicitacao.idedital and ItemsLicitacao.idproduto = Produto.idproduto  AND ItemsLicitacao.iditemedital = RealinhamentoProposta.iditemedital " +
                "AND Produto.idproduto=" + retprincipio + "", Cnn);
            DataTable Dt = new DataTable();
            sql.Fill(Dt);
            try
            {
                this.cboprincipio.DataSource = Dt;
                this.cboprincipio.DisplayMember = "nome";
                this.cboprincipio.ValueMember = "idproduto";
                this.cboprincipio.Refresh();




            }
            catch (Exception erro)
            {

                throw erro;
            }
            Cnn.Close();
        }

        private void RetornaEmpenho()
        {

            string reg = "Select * FROM Empenho  Where Empenho.idedital=" + cbolicitacao.SelectedValue + "";
            DataTable ds = new DataTable();
            SqlConnection Conn = Banco.CriarConexao();
            Conn.Open();

            if (Conn.State == ConnectionState.Open)
            {
                SqlCommand cmd = new SqlCommand(reg, Conn);
                SqlDataReader dr = cmd.ExecuteReader();
                if (dr.Read())
                {


                    txtempenho.Text = dr["nempenho"].ToString();
                    txtnfiscal.Text = dr["notafiscal"].ToString();
                    mskdtrec.Text = dr["dtrecimento"].ToString();
                    mskdtentrega.Text = dr["dtlimite"].ToString();
                    this.txtobs.Text = dr["obs"].ToString();
                    // txtdescitem.Text = dr["descitem"].ToString();



                }
            }



        }


        private void RetUltimoEmpenho()
        {

            string reg = "Select Max(idempenho) as idempenho FROM Empenho Where  Empenho.idedital=" + cbolicitacao.SelectedValue + "";
            DataTable ds = new DataTable();
            SqlConnection Conn = Banco.CriarConexao();
            Conn.Open();

            if (Conn.State == ConnectionState.Open)
            {
                SqlCommand cmd = new SqlCommand(reg, Conn);
                SqlDataReader dr = cmd.ExecuteReader();
                if (dr.Read())
                {

                    codempenho = Convert.ToInt32(dr["idempenho"].ToString());


                }
            }


        }


        private void RetornaStatusCasas()
        {
            string reg = "Select casasdecimais FROM ItemsLicitacao INNER JOIN Proposta ON ItemsLicitacao.iditemedital = Proposta.iditemedital Where ItemsLicitacao.idedital=" + cbolicitacao.SelectedValue + "";
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



                    }
                }
            }


        }


        private void RetornaStatusCasasNumeroEmpenho(int edt)
        {
            string reg = "Select casasdecimais FROM ItemsLicitacao INNER JOIN Proposta ON ItemsLicitacao.iditemedital = Proposta.iditemedital Where ItemsLicitacao.idedital=" + edt + "";
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



                    }
                }
            }


        }

        private void RetornaCliente(int edt)
        {
            SqlConnection Cnn = Banco.CriarConexao();
            SqlDataAdapter sql = new SqlDataAdapter("Select * from LancEditais,Cliente " +
                " WHERE LancEditais.idcliente = Cliente.idcliente And LancEditais.idedital=" + edt + "", Cnn);
            DataSet Dt = new DataSet();
            sql.Fill(Dt);
            BindingSource bs = new BindingSource();
            bs.DataSource = Dt;
            bs.DataMember = Dt.Tables[0].TableName;

            try
            {
                this.cbocliente.DataSource = bs;
                this.cbocliente.DisplayMember = "nome";
                this.cbocliente.ValueMember = "idcliente";
                this.cbocliente.SelectedIndex = cbolicitacao.Items.Count - 1;



            }
            catch (Exception erro)
            {

                throw erro;
            }
            Cnn.Close();

        }

        private Boolean ValidaCampos()
        {
            if (this.txtempenho.Text == "")
            {
                MessageBox.Show("Informe o Nº do Empenho");
                txtempenho.Focus();
                return false;

            }

            if (this.txtnfiscal.Text == "")
            {
                MessageBox.Show("Informe a Nota Fiscal");
                txtnfiscal.Focus();
                return false;

            }
            if (this.mskdtrec.Text != "  /  /")
            {
                MessageBox.Show("Informe a Data de Recebimento");
                mskdtrec.Focus();
                return false;
            }

            if (this.mskdtentrega.Text != "  /  /")
            {
                MessageBox.Show("Informe a Data de Entrega");
                mskdtentrega.Focus();
                return false;
            }



            return true;


        }


        private Boolean ValidaCamposAdicionaEmpenho()
        {


            if (this.cbolicitacao.Text == "")
            {
                MessageBox.Show("Informe os dados da Licitação!");
                cbolicitacao.Focus();
                return false;

            }


            if (this.cboprincipio.Text == "")
            {
                MessageBox.Show("Informe o Principio Ativo");
                cboprincipio.Focus();
                return false;

            }

            if (this.cboempenho.Text == "")
            {
                MessageBox.Show("Informe o Empenho");
                cboempenho.Focus();
                return false;

            }

            if (this.txtquantidade.Text == "")
            {
                MessageBox.Show("Informe a Quantidade");
                txtquantidade.Focus();
                return false;

            }

            if (this.txtempenho.Text == "")
            {
                MessageBox.Show("Informe o Nº do Empenho");
                txtempenho.Focus();
                return false;

            }

            //if (this.txtnfiscal.Text == "")
            //{
            //    MessageBox.Show("Informe a Nota Fiscal");
            //    txtnfiscal.Focus();
            //    return false;

            //}
            if (this.mskdtrec.Text == "  /  /")
            {
                MessageBox.Show("Informe a Data de Recebimento");
                mskdtrec.Focus();
                return false;
            }

            if (this.mskdtentrega.Text == "  /  /")
            {
                MessageBox.Show("Informe a Data de Entrega");
                mskdtentrega.Focus();
                return false;
            }

            //if (this.mskdtdoc.Text == "  /  /")
            //{
            //    MessageBox.Show("Informe a Data de Empenho");
            //    mskdtdoc.Focus();
            //    return false;
            //}


            return true;


        }

        private void btnSair_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void cbolicitacao_KeyPress(object sender, KeyPressEventArgs e)
        {
            if ((Keys)e.KeyChar == Keys.Enter)
            {
                this.txtempenho.Focus();
            }
        }

        private void txtempenho_KeyPress(object sender, KeyPressEventArgs e)
        {
            if ((Keys)e.KeyChar == Keys.Enter)
            {
                BuscaNumeroEmpenho();

                this.txtnfiscal.Focus();
            }
        }

        private void BuscaNumeroEmpenho()
        {
            string reg = "Select Empenho.*, EmpenhoItems.iditemedital,EmpenhoItems.notafiscal FROM Empenho,EmpenhoItems Where Empenho.idempenho = EmpenhoItems.idempenho AND EmpenhoItems.nempenho='" + txtempenho.Text + "'";
            DataTable ds = new DataTable();
            SqlConnection Conn = Banco.CriarConexao();
            Conn.Open();

            if (Conn.State == ConnectionState.Open)
            {
                SqlCommand cmd = new SqlCommand(reg, Conn);
                SqlDataReader dr = cmd.ExecuteReader();
                if (dr.Read())
                {

                    txtempenho.Text = dr["nempenho"].ToString();
                    txtnfiscal.Text = dr["notafiscal"].ToString();
                    mskdtrec.Text = dr["dtrecimento"].ToString();
                    mskdtentrega.Text = dr["dtlimite"].ToString();
                    this.txtobs.Text = dr["obs"].ToString();
                    RetronarCarregarLicitacaoNumeroEmpenho(Convert.ToInt32(dr["idedital"].ToString()));
                    RetornaStatusCasasNumeroEmpenho(Convert.ToInt32(dr["idedital"].ToString()));
                    CarregaGridNumeroEmpenho(dr["nempenho"].ToString());
                    RetornaCliente(Convert.ToInt32(dr["idedital"].ToString()));
                    int codidedt = Convert.ToInt32(dr["iditemedital"]);
                    CarregaGridArquivos();

                }
            }



        }

        private void CarregaGridNumeroEmpenho(string numeroEmpenho)
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





                string strConn = "select DISTINCT RealinhamentoProposta.iditemedital as itemedital,Produto.nome + ' - ' + Produto.apresentacao  as Descrição,Marca.nome as Marca,EmpenhoItems.item as Item,EmpenhoItems.lote as Lote," +
                                "EmpenhoItems.empenho as Empenho,RealinhamentoProposta.vlvenda as Preço, EmpenhoItems.qtde as QdtEmpenho,EmpenhoItems.total as Total," +
                                "RealinhamentoProposta.Qtde as QtdEdital,EmpenhoItems.idempenhoitems,RealinhamentoProposta.vladitivo as Aditivo,Marca.idmarca, EmpenhoItems.idempenho,EmpenhoItems.notafiscal," +
                                 "(RealinhamentoProposta.Qtde) - (Select  Sum(EmpenhoItems.qtde) From EmpenhoItems LEFT JOIN Empenho ON Empenho.idempenho = EmpenhoItems.idempenho where RealinhamentoProposta.iditemedital = EmpenhoItems.iditemedital AND  EmpenhoItems.idedital =  " + cbolicitacao.SelectedValue + " AND EmpenhoItems.nempenho='" + txtempenho.Text + "')  as Pendente, " +
                                "EmpenhoItems.vladitivo as Aditivo,(Select sum(Entrega.qtde) from Entrega LEFT JOIN  Empenho ON Entrega.idempenho = Empenho.idempenho WHERE EmpenhoItems.iditemedital = Entrega.iditemedital AND Empenho.idedital = " + cbolicitacao.SelectedValue + " AND EmpenhoItems.nempenho='" + txtempenho.Text + "') as Entregues," +
                                "Produto.idproduto,PrincipioAtivo.idprincipio,(RealinhamentoProposta.Qtde) as Qtde_Edital " +
                                "From EmpenhoItems INNER JOIN Empenho ON EmpenhoItems.idempenho = Empenho.idempenho INNER JOIN  RealinhamentoProposta ON EmpenhoItems.idrealinhamento = RealinhamentoProposta.idrealinhamento " +
                                 "INNER JOIN Entrega ON  EmpenhoItems.idempenho = Entrega.idempenho,PrincipioAtivo,Produto,Marca  WHERE " +
                                  "Produto.idprincipio = PrincipioAtivo.idprincipio AND RealinhamentoProposta.idmarca = Marca.idmarca AND EmpenhoItems.idprincipio = PrincipioAtivo.idprincipio AND " +
                                 "  Produto.idproduto = EmpenhoItems.idproduto  AND EmpenhoItems.idedital = " + cbolicitacao.SelectedValue + " AND EmpenhoItems.nempenho='" + txtempenho.Text + "'";


                SqlDataAdapter da = new SqlDataAdapter(strConn, Conn);
                da.Fill(ds);


            }

            this.griditens.RowsDefaultCellStyle.BackColor = Color.LightBlue;
            this.griditens.AlternatingRowsDefaultCellStyle.BackColor = Color.Azure;

            var column = new DataGridViewComboBoxColumn();

            griditens.AutoGenerateColumns = false;
            //exibe os dados no datagridview
            griditens.DataSource = ds;
            griditens.Columns.Clear();
            griditens.Columns.Add(chkb);
            chkb.HeaderText = "Sel";
            chkb.Name = "chkb";
            griditens.Columns.Add("itemedital", "itemedital");
            griditens.Columns.Add("Descrição", "Descrição");
            griditens.Columns.Add("Marca", "Marca");
            griditens.Columns.Add("Item", "Item");
            griditens.Columns.Add("Lote", "Lote");


            DataTable data = new DataTable();

            data.Columns.Add(new DataColumn("Value", typeof(string)));
            data.Columns.Add(new DataColumn("Description", typeof(string)));

            data.Rows.Add("SIM", "SIM");
            data.Rows.Add("NAO", "NAO");
            column.DataSource = data;
            column.HeaderText = "Empenho";
            column.ValueMember = "Value";
            column.DisplayMember = "Description";
            griditens.Columns.Insert(6, column);


            griditens.Columns.Add("Preço", "Preço");
            griditens.Columns.Add("QdtEmpenho", "QdtEmpenho");
            griditens.Columns.Add("Total", "Total");


            griditens.Columns.Add("Pendente", "Pendente");
            griditens.Columns.Add("Aditivo", "Aditivo");
            griditens.Columns.Add("QtdEdital", "QtdEdital");
            griditens.Columns.Add("Entregues", "Entregues");
            griditens.Columns.Add("idproduto", "idproduto");
            griditens.Columns.Add("idprincipio", "idprincipio");
            griditens.Columns.Add("idempenhoitems", "idempenhoitems");
            griditens.Columns.Add("idmarca", "idmarca");
            griditens.Columns.Add("idempenho", "idempenho");
            griditens.Columns.Add("QtdEdital", "QtdEdital");
            griditens.Columns.Add("notafiscal", "notafiscal");


            griditens.Columns[0].Width = 50;
            griditens.Columns[1].Visible = false;
            griditens.Columns[2].Width = 200;
            griditens.Columns[3].Width = 140;
            griditens.Columns[4].Width = 50;
            griditens.Columns[5].Width = 53;
            griditens.Columns[7].Width = 75;
            griditens.Columns[8].Width = 80;
            griditens.Columns[9].Width = 80;
            griditens.Columns[10].Width = 70;
            griditens.Columns[11].Width = 70;
            griditens.Columns[12].Width = 75;
            griditens.Columns[13].Width = 80;
            griditens.Columns[14].Visible = false;
            griditens.Columns[15].Visible = false;
            griditens.Columns[16].Visible = false;
            griditens.Columns[17].Visible = false;
            griditens.Columns[18].Visible = false;
            griditens.Columns[19].Visible = false;
            griditens.Columns[20].Width = 110;

            griditens.Columns[7].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            griditens.Columns[8].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            griditens.Columns[8].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
            griditens.Columns[9].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            griditens.Columns[9].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
            griditens.Columns[4].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            griditens.Columns[5].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
            griditens.Columns[5].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            griditens.Columns[5].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
            griditens.Columns[10].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            griditens.Columns[10].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
            griditens.Columns[11].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            griditens.Columns[11].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
            griditens.Columns[12].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            griditens.Columns[12].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
            griditens.Columns[13].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            griditens.Columns[13].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;

            griditens.Columns[1].DataPropertyName = "itemedital";
            griditens.Columns[2].DataPropertyName = "Descrição";
            griditens.Columns[3].DataPropertyName = "Marca";
            griditens.Columns[4].DataPropertyName = "Item";
            griditens.Columns[5].DataPropertyName = "Lote";
            griditens.Columns[6].DataPropertyName = "Empenho";
            griditens.Columns[7].DataPropertyName = "Preço";
            griditens.Columns[8].DataPropertyName = "QdtEmpenho";
            griditens.Columns[9].DataPropertyName = "Total";
            griditens.Columns[10].DataPropertyName = "Pendente";
            griditens.Columns[11].DataPropertyName = "Aditivo";
            griditens.Columns[12].DataPropertyName = "QtdEdital";
            griditens.Columns[13].DataPropertyName = "Entregues";
            griditens.Columns[14].DataPropertyName = "idproduto";
            griditens.Columns[15].DataPropertyName = "idprincipio";
            griditens.Columns[16].DataPropertyName = "idempenhoitems";
            griditens.Columns[17].DataPropertyName = "idmarca";
            griditens.Columns[18].DataPropertyName = "idempenho";
            griditens.Columns[19].DataPropertyName = "QtdEdital";
            griditens.Columns[20].DataPropertyName = "notafiscal";


            griditens.Columns[7].ReadOnly = true;
            griditens.Columns[3].ReadOnly = true;
            griditens.Columns[4].ReadOnly = true;
            griditens.Columns[5].ReadOnly = true;
            griditens.Columns[9].ReadOnly = true;
            griditens.Columns[10].ReadOnly = true;
            griditens.Columns[8].ReadOnly = true;
            griditens.Columns[11].ReadOnly = true;
            griditens.Columns[13].ReadOnly = true;
            griditens.Columns[12].ReadOnly = true;

            DataGridViewButtonColumn btn = new DataGridViewButtonColumn();
            griditens.Columns.Add(btn);
            btn.HeaderText = "Excluir";
            btn.Text = "Excluir";
            btn.Name = "btn";
            btn.Width = 60;
            btn.UseColumnTextForButtonValue = true;
            btn.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft;


            if (casas == 2)
            {

                griditens.Columns[7].DefaultCellStyle.Format = "n2";
                // griditens.Columns[10].DefaultCellStyle.Format = "#.00\\%";
                griditens.Columns[9].DefaultCellStyle.Format = "n2";



            }
            else if (casas == 3)
            {

                griditens.Columns[7].DefaultCellStyle.Format = "n3";
                // griditens.Columns[10].DefaultCellStyle.Format = "#.00\\%";
                griditens.Columns[9].DefaultCellStyle.Format = "n3";

            }
            else if (casas == 4)
            {

                griditens.Columns[7].DefaultCellStyle.Format = "n4";
                //  griditens.Columns[10].DefaultCellStyle.Format = "#.00\\%";
                griditens.Columns[9].DefaultCellStyle.Format = "n4";

            }

            valor = 0;

            foreach (DataGridViewRow linha in griditens.Rows)
            {
                if ((linha.Cells[9].Value != DBNull.Value))
                {

                    valor += Convert.ToDouble(linha.Cells[9].Value);
                }

            }


            double valort = valor;
            string convertido = String.Format("{0:N3}", Math.Round(valort, 4));
            labTotal.Text = convertido;


            griditens.Refresh();


        }

        private void txtnfiscal_KeyPress(object sender, KeyPressEventArgs e)
        {
            if ((Keys)e.KeyChar == Keys.Enter)
            {
                this.mskdtrec.Focus();
            }
        }

        private void mskdtrec_KeyPress(object sender, KeyPressEventArgs e)
        {
            if ((Keys)e.KeyChar == Keys.Enter)
            {
                this.mskdtentrega.Focus();
            }
        }

        private void mskdtentrega_KeyPress(object sender, KeyPressEventArgs e)
        {
            if ((Keys)e.KeyChar == Keys.Enter)
            {
                this.txtempenho.Focus();
            }
        }

        public double valor;
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



                string strConn = "select DISTINCT ItemsLicitacao.iditemedital as itemedital,Produto.nome + ' - ' + Produto.apresentacao  as Descrição,Marca.nome as Marca,ItemsLicitacao.nritem as Item,ItemsLicitacao.lote as Lote," +
                                  "EmpenhoItems.empenho as Empenho,RealinhamentoProposta.vlvenda as Preço, EmpenhoItems.qtde as Qdte,EmpenhoItems.total as Total," +
                                  "(RealinhamentoProposta.Qtde) as QtdEdital,EmpenhoItems.idempenhoitems,RealinhamentoProposta.vladitivo as Aditivo,Marca.idmarca, EmpenhoItems.idempenho,EmpenhoItems.notafiscal," +
                                   "(RealinhamentoProposta.Qtde) - (Select  Sum(EmpenhoItems.qtde) From EmpenhoItems LEFT JOIN Empenho ON Empenho.idempenho = EmpenhoItems.idempenho where EmpenhoItems.idedital =  " + cbolicitacao.SelectedValue + " AND EmpenhoItems.nempenho='" + txtempenho.Text + "')  as Pendente, " +
                                  "EmpenhoItems.vladitivo as Aditivo,(Select sum(Entrega.qtde) from Entrega LEFT JOIN  Empenho ON Entrega.idempenho = Empenho.idempenho WHERE Empenho.idedital = " + cbolicitacao.SelectedValue + " AND EmpenhoItems.nempenho='" + txtempenho.Text + "') as Entregues," +
                                  "Produto.idproduto,PrincipioAtivo.idprincipio,(RealinhamentoProposta.Qtde) as QtdEdital " +
                                  "From EmpenhoItems INNER JOIN Empenho ON EmpenhoItems.idempenho = Empenho.idempenho INNER JOIN  RealinhamentoProposta ON EmpenhoItems.idrealinhamento = RealinhamentoProposta.idrealinhamento " +
                                   "INNER JOIN Entrega ON  EmpenhoItems.idempenho = Entrega.idempenho,PrincipioAtivo,Produto,LancEditais,Marca,ItemsLicitacao  WHERE LancEditais.nlicitacao = ItemsLicitacao.nlicitacao AND " +
                                    "Produto.idprincipio = PrincipioAtivo.idprincipio AND RealinhamentoProposta.idmarca = Marca.idmarca AND ItemsLicitacao.idprincipio = PrincipioAtivo.idprincipio AND " +
                                   "  Produto.idproduto = EmpenhoItems.idproduto  AND EmpenhoItems.idedital = " + cbolicitacao.SelectedValue + " AND EmpenhoItems.nempenho='" + txtempenho.Text + "'";


                SqlDataAdapter da = new SqlDataAdapter(strConn, Conn);
                da.Fill(ds);


            }

            this.griditens.RowsDefaultCellStyle.BackColor = Color.LightBlue;
            this.griditens.AlternatingRowsDefaultCellStyle.BackColor = Color.Azure;

            var column = new DataGridViewComboBoxColumn();

            griditens.AutoGenerateColumns = false;
            //exibe os dados no datagridview
            griditens.DataSource = ds;
            griditens.Columns.Clear();
            griditens.Columns.Add(chkb);
            chkb.HeaderText = "Sel";
            chkb.Name = "chkb";
            griditens.Columns.Add("itemedital", "itemedital");
            griditens.Columns.Add("Descrição", "Descrição");
            griditens.Columns.Add("Marca", "Marca");
            griditens.Columns.Add("Item", "Item");
            griditens.Columns.Add("Lote", "Lote");


            DataTable data = new DataTable();

            data.Columns.Add(new DataColumn("Value", typeof(string)));
            data.Columns.Add(new DataColumn("Description", typeof(string)));

            data.Rows.Add("SIM", "SIM");
            data.Rows.Add("NAO", "NAO");
            column.DataSource = data;
            column.HeaderText = "Empenho";
            column.ValueMember = "Value";
            column.DisplayMember = "Description";
            griditens.Columns.Insert(6, column);


            griditens.Columns.Add("Preço", "Preço");
            griditens.Columns.Add("Qtde", "Qtde");
            griditens.Columns.Add("Total", "Total");


            griditens.Columns.Add("Pendente", "Pendente");
            griditens.Columns.Add("Aditivo", "Aditivo");
            griditens.Columns.Add("Solicitada", "Solicitada");
            griditens.Columns.Add("Entregues", "Entregues");
            griditens.Columns.Add("idproduto", "idproduto");
            griditens.Columns.Add("idprincipio", "idprincipio");
            griditens.Columns.Add("idempenhoitems", "idempenhoitems");
            griditens.Columns.Add("idmarca", "idmarca");
            griditens.Columns.Add("idempenho", "idempenho");
            griditens.Columns.Add("QtdEdital", "QtdEdital");
            griditens.Columns.Add("notafiscal", "notafiscal");


            griditens.Columns[0].Width = 50;
            griditens.Columns[1].Visible = false;
            griditens.Columns[2].Width = 200;
            griditens.Columns[3].Width = 140;
            griditens.Columns[4].Width = 50;
            griditens.Columns[5].Width = 53;
            griditens.Columns[7].Width = 75;
            griditens.Columns[8].Width = 65;
            griditens.Columns[9].Width = 80;
            griditens.Columns[10].Width = 70;
            griditens.Columns[11].Width = 70;
            griditens.Columns[12].Width = 80;
            griditens.Columns[13].Width = 80;
            griditens.Columns[14].Visible = false;
            griditens.Columns[15].Visible = false;
            griditens.Columns[16].Visible = false;
            griditens.Columns[17].Visible = false;
            griditens.Columns[18].Visible = false;
            griditens.Columns[19].Visible = false;
            griditens.Columns[20].Width = 110;

            griditens.Columns[7].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            griditens.Columns[8].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            griditens.Columns[8].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
            griditens.Columns[9].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            griditens.Columns[9].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
            griditens.Columns[4].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            griditens.Columns[5].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
            griditens.Columns[5].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            griditens.Columns[5].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
            griditens.Columns[10].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            griditens.Columns[10].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
            griditens.Columns[11].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            griditens.Columns[11].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
            griditens.Columns[12].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            griditens.Columns[12].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
            griditens.Columns[13].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            griditens.Columns[13].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;

            griditens.Columns[1].DataPropertyName = "itemedital";
            griditens.Columns[2].DataPropertyName = "Descrição";
            griditens.Columns[3].DataPropertyName = "Marca";
            griditens.Columns[4].DataPropertyName = "Item";
            griditens.Columns[5].DataPropertyName = "Lote";
            griditens.Columns[6].DataPropertyName = "Empenho";
            griditens.Columns[7].DataPropertyName = "Preço";
            griditens.Columns[8].DataPropertyName = "Qdte";
            griditens.Columns[9].DataPropertyName = "Total";
            griditens.Columns[10].DataPropertyName = "Pendente";
            griditens.Columns[11].DataPropertyName = "Aditivo";
            griditens.Columns[12].DataPropertyName = "Solicitada";
            griditens.Columns[13].DataPropertyName = "Entregues";
            griditens.Columns[14].DataPropertyName = "idproduto";
            griditens.Columns[15].DataPropertyName = "idprincipio";
            griditens.Columns[16].DataPropertyName = "idempenhoitems";
            griditens.Columns[17].DataPropertyName = "idmarca";
            griditens.Columns[18].DataPropertyName = "idempenho";
            griditens.Columns[19].DataPropertyName = "Qtde_Edital";
            griditens.Columns[20].DataPropertyName = "notafiscal";

            griditens.Columns[7].ReadOnly = true;
            griditens.Columns[3].ReadOnly = true;
            griditens.Columns[4].ReadOnly = true;
            griditens.Columns[5].ReadOnly = true;
            griditens.Columns[9].ReadOnly = true;
            griditens.Columns[10].ReadOnly = true;
            griditens.Columns[8].ReadOnly = true;
            griditens.Columns[11].ReadOnly = true;
            griditens.Columns[13].ReadOnly = true;
            griditens.Columns[12].ReadOnly = true;

            DataGridViewButtonColumn btn = new DataGridViewButtonColumn();
            griditens.Columns.Add(btn);
            btn.HeaderText = "Excluir";
            btn.Text = "Excluir";
            btn.Name = "btn";
            btn.Width = 60;
            btn.UseColumnTextForButtonValue = true;
            btn.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft;


            if (casas == 2)
            {

                griditens.Columns[7].DefaultCellStyle.Format = "n2";
                // griditens.Columns[10].DefaultCellStyle.Format = "#.00\\%";
                griditens.Columns[9].DefaultCellStyle.Format = "n2";



            }
            else if (casas == 3)
            {

                griditens.Columns[7].DefaultCellStyle.Format = "n3";
                //griditens.Columns[10].DefaultCellStyle.Format = "#.00\\%";
                griditens.Columns[9].DefaultCellStyle.Format = "n3";

            }
            else if (casas == 4)
            {

                griditens.Columns[7].DefaultCellStyle.Format = "n4";
                // griditens.Columns[10].DefaultCellStyle.Format = "#.00\\%";
                griditens.Columns[9].DefaultCellStyle.Format = "n4";

            }

            valor = 0;

            foreach (DataGridViewRow linha in griditens.Rows)
            {
                if ((linha.Cells[9].Value != DBNull.Value))
                {

                    valor += Convert.ToDouble(linha.Cells[9].Value);
                }

            }


            double valort = valor;
            string convertido = String.Format("{0:N3}", Math.Round(valort, 4));
            labTotal.Text = convertido;

            griditens.Refresh();
        }

        private void chkTodos_CheckedChanged(object sender, EventArgs e)
        {
            foreach (DataGridViewRow row in griditens.Rows)
            {
                DataGridViewCheckBoxCell chkb = (DataGridViewCheckBoxCell)row.Cells[0];
                chkb.Value = !(chkb.Value == null ? false : (bool)chkb.Value); //because chk.Value is initialy null
            }
        }

        private void griditens_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0 && e.ColumnIndex == 0)
            {

                foreach (DataGridViewRow row in griditens.Rows)
                {

                    if (row.Index == e.RowIndex)
                    {
                        row.Cells["chkb"].Value = !Convert.ToBoolean(row.Cells["chkb"].EditedFormattedValue);
                        int idprod = int.Parse(griditens.Rows[e.RowIndex].Cells[14].Value.ToString());
                        int codiditemedital = int.Parse(griditens.Rows[e.RowIndex].Cells[1].Value.ToString());
                        RetornaProduto(idprod);
                        RetornaFabricante(idprod);
                        string edt = Convert.ToString(cbolicitacao.SelectedValue);
                        RetReg(idprod, edt);
                        CarregaGridArquivos();
                        labqtdetotal.Text = Convert.ToString(griditens.Rows[e.RowIndex].Cells[19].Value.ToString());
                        txtnfiscal.Text = Convert.ToString(griditens.Rows[e.RowIndex].Cells[20].Value.ToString());
                        txtcodigo.Text = Convert.ToString(griditens.Rows[e.RowIndex].Cells[18].Value.ToString());



                    }
                    else
                    {
                        row.Cells["chkb"].Value = false;
                    }

                }

            }
            else if (e.RowIndex >= 0 && e.ColumnIndex == 21)
            {


                int coditemempenho = int.Parse(griditens.Rows[e.RowIndex].Cells[16].Value.ToString());
                VlItensEmpenho obj = new VlItensEmpenho();

                obj.iditemempenho = coditemempenho;

                PsItensEmpenho DAOItemEmpenho = new PsItensEmpenho();
                DAOItemEmpenho.Exluir(obj.iditemempenho);
                carregarGridItensAdd();

            }
        }

        private void RetReg(int codi, string edt)
        {

            //string reg = "Select * FROM Empenho Where Empenho.idproduto=" + codi + " AND Empenho.edital='" + edt + "'";
            //DataTable ds = new DataTable();
            //SqlConnection Conn = Banco.CriarConexao();
            //Conn.Open();

            //if (Conn.State == ConnectionState.Open)
            //{
            //    SqlCommand cmd = new SqlCommand(reg, Conn);
            //    SqlDataReader dr = cmd.ExecuteReader();
            //    if (dr.Read())
            //    {

            //        txtdescitem.Text = dr["descitem"].ToString();



            //    }
            //}

        }

        private void CarregarProduto()
        {
            SqlConnection Cnn = Banco.CriarConexao();
            SqlDataAdapter sql = new SqlDataAdapter("Select * from Produto", Cnn);
            DataSet Dt = new DataSet();
            sql.Fill(Dt, "Produto");
            DataRow dr = Dt.Tables["Produto"].NewRow();
            dr[1] = "";
            Dt.Tables["Produto"].Rows.Add(dr);
            try
            {

                this.cboproduto.DisplayMember = "nome";
                this.cboproduto.ValueMember = "idproduto";
                this.cboproduto.DataSource = Dt.Tables["Produto"];
                this.cboproduto.SelectedIndex = cboproduto.Items.Count - 1;



            }
            catch (Exception erro)
            {

                throw erro;
            }
            Cnn.Close();
        }
        private void RetornaProduto(Int32 retp)
        {
            SqlConnection Cnn = Banco.CriarConexao();
            SqlDataAdapter sql = new SqlDataAdapter("Select * from Produto WHERE idproduto=" + retp + "", Cnn);
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

        private void RetornaFabricante(Int32 retprod)
        {
            SqlConnection Cnn = Banco.CriarConexao();
            SqlDataAdapter sql = new SqlDataAdapter("Select Fabricante.nome,Fabricante.idfabricante from Fabricante,Produto WHERE Produto.idfabricante = Fabricante.idfabricante AND  Produto.idproduto=" + retprod + "", Cnn);
            DataTable Dt = new DataTable();
            sql.Fill(Dt);
            try
            {
                this.cbomarca.DataSource = Dt;
                this.cbomarca.DisplayMember = "nome";
                this.cbomarca.ValueMember = "idfabricante";
                this.cbomarca.Refresh();




            }
            catch (Exception erro)
            {

                throw erro;
            }
            Cnn.Close();
        }

        DataGridViewCheckBoxColumn chka = new DataGridViewCheckBoxColumn();
        private void CarregaGridArquivos()
        {


            //define o dataset

            System.Data.DataTable ds = new System.Data.DataTable();


            //cria uma conexÆo usando a string de conexÆo

            SqlConnection Conn = Banco.CriarConexao();



            try
            {

                //abre a conexao

                Conn.Open();

            }

            catch (System.Exception e)
            {

                throw e;

            }


            if (Conn.State == ConnectionState.Open)
            {

                //se a conexÆo estiver aberta usa uma instru‡Æo SQL para selecionar os registros da tabela clientes

                //SELECT campos FROM tabela



                SqlDataAdapter da = new SqlDataAdapter("Select DISTINCT DocumentoEmpenho.iddocempenho as Cod,DocumentoEmpenho.nomearq as Documento,DocumentoEmpenho.iditemedital as coditemedt, " +
                    "DocumentoEmpenho.Data as Data,DocumentoEmpenho.statusitem as Status  " +
                " from DocumentoEmpenho,Empenho Where Empenho.idedital = DocumentoEmpenho.idedital AND DocumentoEmpenho.idedital =" + cbolicitacao.SelectedValue + "" +
                "Order by Documento ASC ", Conn);

                da.Fill(ds);


                this.Grid.RowsDefaultCellStyle.BackColor = Color.LightBlue;
                this.Grid.AlternatingRowsDefaultCellStyle.BackColor = Color.Azure;

                //exibe os dados no datagridview
                Grid.AutoGenerateColumns = false;
                Grid.DataSource = ds;
                Grid.Columns.Clear();
                Grid.Columns.Add(chka);
                chka.HeaderText = "Sel";
                chka.Name = "chka";
                Grid.Columns.Add("Cod", "Cod");
                Grid.Columns.Add("Documento", "Documento");
                Grid.Columns.Add("coditemedt", "coditemedt");
                Grid.Columns.Add("Data", "Data");
                Grid.Columns.Add("Status", "Status");

                Grid.Columns[0].Width = 50;
                Grid.Columns[1].Width = 50;
                Grid.Columns[2].Width = 300;
                Grid.Columns[3].Visible = false;
                Grid.Columns[4].Width = 80;
                Grid.Columns[5].Width = 250;

                Grid.Columns[1].DataPropertyName = "Cod";
                Grid.Columns[2].DataPropertyName = "Documento";
                Grid.Columns[3].DataPropertyName = "coditemedt";
                Grid.Columns[4].DataPropertyName = "Data";
                Grid.Columns[5].DataPropertyName = "Status";

                DataGridViewButtonColumn btn = new DataGridViewButtonColumn();
                Grid.Columns.Add(btn);
                btn.HeaderText = "Excluir";
                btn.Text = "Excluir";
                btn.Name = "btn";
                btn.Width = 60;
                btn.UseColumnTextForButtonValue = true;
                btn.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft;


            }

        }
        int coda;
        private void Grid_CellClick(object sender, DataGridViewCellEventArgs e)
        {

            if (bool.Parse(Grid[0, e.RowIndex].EditedFormattedValue.ToString()) == true)
            {


                if (e.RowIndex >= 0 && e.ColumnIndex == 6)
                {
                    //Loop and uncheck all other CheckBoxes.
                    foreach (DataGridViewRow row in Grid.Rows)
                    {
                        if (row.Index == e.RowIndex)
                        {
                            row.Cells["chka"].Value = !Convert.ToBoolean(row.Cells["chka"].EditedFormattedValue);
                            coda = int.Parse(Grid.Rows[e.RowIndex].Cells[1].Value.ToString());
                            int codi = int.Parse(Grid.Rows[e.RowIndex].Cells[3].Value.ToString());
                            VlArquivoEmpenho obj = new VlArquivoEmpenho();

                            obj.iddocempenho = coda;

                            PsArquivoEmpenho DAOArquivos = new PsArquivoEmpenho();
                            DAOArquivos.Exluir(obj.iddocempenho);


                            CarregaGridArquivos();
                        }
                        else
                        {
                            row.Cells["chka"].Value = false;
                        }
                    }
                }
            }

        }

        private void RetornaCliente()
        {
            SqlConnection Cnn = Banco.CriarConexao();
            SqlDataAdapter sql = new SqlDataAdapter("Select * from LancEditais,Cliente " +
                " WHERE LancEditais.idcliente = Cliente.idcliente And LancEditais.idedital=" + cbolicitacao.SelectedValue + "", Cnn);
            DataSet Dt = new DataSet();
            sql.Fill(Dt);
            BindingSource bs = new BindingSource();
            bs.DataSource = Dt;
            bs.DataMember = Dt.Tables[0].TableName;

            try
            {
                this.cbocliente.DataSource = bs;
                this.cbocliente.DisplayMember = "nome";
                this.cbocliente.ValueMember = "idcliente";
                this.cbocliente.SelectedIndex = cbolicitacao.Items.Count - 1;



            }
            catch (Exception erro)
            {

                throw erro;
            }
            Cnn.Close();


        }

        private void button4_Click(object sender, EventArgs e)
        {
            try
            {
                OpenFileDialog AbrirComo = new OpenFileDialog();
                //DialogResult Caminho;

                AbrirComo.Multiselect = true;
                AbrirComo.Title = "Abrir Como";

                AbrirComo.FileName = "Nome Arquivo";
                AbrirComo.Filter = "Arquivos (*.*)|*.*";
                AbrirComo.InitialDirectory = "D:\\";
                if (AbrirComo.ShowDialog() == DialogResult.OK)

                    foreach (String file in AbrirComo.FileNames)
                    {

                        listarq.Items.Add(file);

                    }


                foreach (string items in listarq.Items)
                {

                    arquivo = System.IO.Path.GetFileName(items);

                    extensao = System.IO.Path.GetExtension(items);


                    FileData = ReadFile(items);

                    GravarArquivo();
                }
                listarq.Items.Clear();

                if (arquivo == "")
                {
                    MessageBox.Show("Arquivo Invalido", "Salvar Como", MessageBoxButtons.OK);
                }
                else
                {
                    // listarq.Items.Add(arquivo);

                    // FileData = ReadFile();

                }

            }
            catch (Exception erro)
            {
                MessageBox.Show("Erro ao carregar arquivo!" + erro.Message.ToString(), "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        byte[] ReadFile(string sPath)
        {

            //Initialize byte array with a null value initially.

            byte[] data = null;



            //Use FileInfo object to get file size.

            FileInfo fInfo = new FileInfo(sPath);

            long numBytes = fInfo.Length;



            //Open FileStream to read file

            FileStream fStream = new FileStream(sPath, FileMode.Open, FileAccess.Read);



            //Use BinaryReader to read file stream into byte array.

            BinaryReader br = new BinaryReader(fStream);



            //When you use BinaryReader, you need to supply number of bytes to read from file.
            //In this case we want to read entire file. So supplying total number of bytes.

            data = br.ReadBytes((int)numBytes);



            //Close BinaryReader

            br.Close();



            //Close FileStream

            fStream.Close();



            return data;

        }
        string arquivo;
        byte[] FileData;
        string extensao;

        int codarquivo;

        private void btnExtrair_Click(object sender, EventArgs e)
        {
            foreach (DataGridViewRow row in Grid.Rows)
            {

                if (bool.Parse(row.Cells[0].EditedFormattedValue.ToString()) == true)
                {

                    codarquivo = Convert.ToInt32(row.Cells[1].Value.ToString());



                    string folder = @"C:\" + cbolicitacao.SelectedValue + " - " + cbocliente.Text; //nome do diretorio a ser criado

                    //Se o diretório não existir...

                    if (!Directory.Exists(folder))
                    {

                        //Criamos um com o nome folder
                        Directory.CreateDirectory(folder);

                    }





                    SqlConnection Cnn = Banco.CriarConexao();
                    string query = "Select arq,extensao,nomearq from DocumentoEmpenho Where iddocempenho = " + codarquivo;
                    SqlCommand ObjC = new SqlCommand(query, Cnn);
                    Cnn.Open();
                    SqlDataReader dr = ObjC.ExecuteReader();


                    if (dr.Read())
                    {


                        byte[] byteArray = new byte[16 * 1024];
                        byte[] fileData = (byte[])dr["arq"];
                        string filename = dr["nomearq"].ToString();
                        arquivo = dr["nomearq"].ToString();

                        using (FileStream file = new FileStream(@"C:\" + cbolicitacao.SelectedValue + " - " + cbocliente.Text + "\\" + filename, FileMode.Create))
                        {

                            file.Write(fileData, 0, fileData.Length);
                            file.Close();
                            dr.Close();
                            Cnn.Close();
                        }




                    }

                }

            }





            string pastaParaZipar = @"C:\" + cbolicitacao.SelectedValue + " - " + cbocliente.Text;
            string caminhoZip = @"C:\" + cbolicitacao.SelectedValue + " - " + cbocliente.Text + ".zip";



            if (System.IO.File.Exists(@"C:\" + cbolicitacao.SelectedValue + " - " + cbocliente.Text + ".zip"))
            {


                ZipFile.CreateFromDirectory(pastaParaZipar, caminhoZip);

            }
            else
            {

                // ZipFile.CreateFromDirectory(pastaParaZipar, caminhoZip);
            }

        }

        private void GravarArquivo()
        {

            if (ValidaArquivo() == true)
            {

                foreach (DataGridViewRow row in griditens.Rows)
                {

                    if (bool.Parse(row.Cells[0].EditedFormattedValue.ToString()) == true)
                    {



                        VlArquivoEmpenho obj = new VlArquivoEmpenho();

                        VlArquivoEmpenho.arq = FileData;
                        obj.nomearq = arquivo;
                        obj.idempresa = Banco.idemp;
                        obj.edital = codedital;
                        obj.extensao = extensao;
                        obj.dtdocumento = DateTime.Now.ToString("dd/MM/yyyy");
                        obj.idusu = Banco.idusu;
                        obj.iditemedital = Convert.ToInt32(row.Cells[1].Value);
                        obj.statusitem = cbostatus.Text;
                        obj.data = mskdtdoc.Text;
                        obj.idedital = Convert.ToInt32(cbolicitacao.SelectedValue);


                        try
                        {
                            PsArquivoEmpenho PsArquivosbll = new PsArquivoEmpenho();
                            PsArquivosbll.Incluir(obj);
                            CarregaGridArquivos();

                        }
                        catch (Exception erro)
                        {

                            throw erro;
                        }
                    }
                    else
                    {
                        MessageBox.Show("Selecione o Item para Anexar o Documento!");
                    }
                }
            }
        }

        private void btnSalvar_Click(object sender, EventArgs e)
        {
            try


            {

                foreach (DataGridViewRow row in griditens.Rows)
                {

                    if (bool.Parse(row.Cells[0].EditedFormattedValue.ToString()))
                    {
                        //int iditem = Convert.ToInt32(row.Cells[1].Value);
                        //string edt = Convert.ToString(cbolicitacao.SelectedValue);

                        if (VerificaRegistroExiste(txtempenho.Text) == true)
                        {

                            SalvarDados();
                        }
                        else
                        {


                            AlterarDados();

                        }
                    }
                }
            }
            catch (Exception erro)
            {

                throw erro;
            }

            //  AlteraStatusLicitacao();
            carregarGridItens();

        }


        private Boolean ValidaArquivo()
        {
            if (this.cbostatus.Text == "")
            {
                MessageBox.Show("Informe o Status");
                cbostatus.Focus();
                return false;

            }

            if (this.mskdtdoc.Text == "  /  /")
            {
                MessageBox.Show("Informe a Data");
                mskdtdoc.Focus();
                return false;

            }


            return true;


        }


        private void GravaEmpenho()
        {

            try


            {

                if (VerificaRegistroExiste(txtempenho.Text) == true)
                {

                    SalvarDados();
                }
                else
                {


                    AlterarDados();

                }


            }
            catch (Exception erro)
            {

                throw erro;
            }

            //  AlteraStatusLicitacao();
            // carregarGridItens();



        }


        private Boolean VerificaRegistroExiste(string emp)
        {

            SqlConnection Cnn = Banco.CriarConexao();
            string obter = ("Select * From Empenho Where nempenho = '" + emp + "' AND idedital=" + cbolicitacao.SelectedValue + "");
            SqlCommand sql = new SqlCommand(obter, Cnn);
            Cnn.Open();
            SqlDataReader dr = sql.ExecuteReader();
            if (dr.Read())
            {

                return false;
            }
            return true;
        }

        public void SalvarDados()
        {

            SqlConnection Cnn = Banco.CriarConexao();



            string insert = "INSERT INTO Empenho (edital,idusu,dtrecimento,dtlimite,nempenho,obs,idedital,ata,dtvigencia,idcliente)" +
                " VALUES (@edital,@idusu,@dtrecimento,@dtlimite,@nempenho,@obs,@idedital,@ata,@dtvigencia,@idcliente)";

            SqlCommand cmd = new SqlCommand(insert, Cnn);
            cmd.Parameters.AddWithValue("@edital", codedital);
            cmd.Parameters.AddWithValue("@idusu", Banco.idusu);
            cmd.Parameters.AddWithValue("@dtrecimento", SqlDbType.Date).Value = Convert.ToDateTime(mskdtrec.Text).ToString("yyyy/MM/dd");
            cmd.Parameters.AddWithValue("@dtlimite", SqlDbType.Date).Value = Convert.ToDateTime(mskdtentrega.Text).ToString("yyyy/MM/dd");
            cmd.Parameters.AddWithValue("@nempenho", txtempenho.Text);
            cmd.Parameters.AddWithValue("@obs", txtobs.Text);
            cmd.Parameters.AddWithValue("@idedital", Convert.ToInt32(cbolicitacao.SelectedValue));
            cmd.Parameters.AddWithValue("@ata", txtatacontrato.Text);
            cmd.Parameters.AddWithValue("@dtvigencia", SqlDbType.Date).Value = Convert.ToDateTime(mskvigencia.Text).ToString("yyyy/MM/dd");
            cmd.Parameters.AddWithValue("@idcliente", Convert.ToInt32(cbocliente.SelectedValue));
            Cnn.Open();
            cmd.ExecuteNonQuery();
            Cnn.Close();





        }


        public void AlterarDados()
        {
            RetornaEmpenhoItems();
           
       


            SqlConnection Cnn = Banco.CriarConexao();

            string update = "UPDATE Empenho SET edital=@edital,idusu=@idusu,dtrecimento=@dtrecimento,dtlimite=@dtlimite,nempenho=@nempenho," +
                "obs=@obs,idedital=@idedital,ata=@ata,dtvigencia=@dtvigencia,@idcliente=@idcliente WHERE idempenho=@idempenho AND idedital=@idedital";

            SqlCommand cmd = new SqlCommand(update, Cnn);
            cmd.Parameters.AddWithValue("@idempenho", Convert.ToInt32(txtcodigo.Text));
            cmd.Parameters.AddWithValue("@edital", codedital);
            cmd.Parameters.AddWithValue("@idusu", Banco.idusu);
            cmd.Parameters.AddWithValue("@dtrecimento", SqlDbType.Date).Value = Convert.ToDateTime(mskdtrec.Text).ToString("yyyy/MM/dd");
            cmd.Parameters.AddWithValue("@dtlimite", SqlDbType.Date).Value = Convert.ToDateTime(mskdtentrega.Text).ToString("yyyy/MM/dd");
            cmd.Parameters.AddWithValue("@nempenho", txtempenho.Text);
            cmd.Parameters.AddWithValue("@obs", txtobs.Text.ToUpper());
            cmd.Parameters.AddWithValue("@idedital", Convert.ToInt32(cbolicitacao.SelectedValue));
            cmd.Parameters.AddWithValue("@ata", txtatacontrato.Text);
            cmd.Parameters.AddWithValue("@dtvigencia", SqlDbType.Date).Value = Convert.ToDateTime(mskvigencia.Text).ToString("yyyy/MM/dd");
            cmd.Parameters.AddWithValue("@idcliente", Convert.ToInt32(cbocliente.SelectedValue));
            Cnn.Open();
            cmd.ExecuteNonQuery();
            Cnn.Close();

            //int itemedt = editalitemID;
            //string edt = Convert.ToString(cbolicitacao.SelectedValue);
            //int usu = Banco.idusu;
            //int idprincipio = principioID;
            //int idproduto = Convert.ToInt32(produtoID);
            //double aditivo = Convert.ToDouble(AditivoItem);
            //int qtde = Convert.ToInt32(0);
            //double total = Convert.ToDouble(txttotal.Text);
            //int qtdesolicitada = Convert.ToInt32(0);
            //string dtrecebimento = this.mskdtrec.Text;
            //string dtlimite = this.mskdtentrega.Text;
            //string nempenho = txtempenho.Text;
            //string notafiscal = txtnfiscal.Text;
            //string descitem = txtdescitem.Text.ToUpper();
            //string obs = txtobs.Text.ToUpper();
            //int iditemempenho = Convert.ToInt32(idempenhoitems);
            //int idmarca = Convert.ToInt32(marcaID);
            //int idempenho = Convert.ToInt32(codempenho);
            //double preco = Convert.ToDouble(txtpreco.Text);



            //VlEntrega entrega = new VlEntrega();
            //entrega.iditemedital = itemedt;
            //entrega.edital = Convert.ToString(cbolicitacao.SelectedValue);
            //entrega.idusu = Banco.idusu;
            //entrega.idprincipio = idprincipio;
            //entrega.idproduto = idproduto;
            //entrega.dtentrega = null;
            //entrega.nempenho = nempenho;
            //entrega.aditivoedital = Convert.ToInt32(aditivo);
            //entrega.nfsaida = notafiscal;
            //entrega.preco = preco;
            //entrega.qtde = 0;
            //entrega.total = total;
            //entrega.idempenho = idempenho;
            //entrega.iditemempenho = iditemempenho;
            //entrega.idmarca = idmarca;



            //try
            //{
            //    if (VerificaRegistroEntregaExiste(entrega.iditemempenho, entrega.idempenho) == true)
            //    {

            //        PsEntrega DAOEntrega = new PsEntrega();
            //        DAOEntrega.Incluir(entrega);

            //    }
            //    else
            //    {

            //        PsEntrega DAOEntrega = new PsEntrega();
            //        DAOEntrega.Alterar(entrega);


            //    }


            //}
            //catch (Exception erro)
            //{

            //    throw erro;
            //}




        }

        public int idempenhoitems;
        private void RetornaEmpenhoItems()
        {

            string reg = "Select  MAX(EmpenhoItems.idempenhoitems) as idempenhoitems FROM EmpenhoItems  Where EmpenhoItems.nempenho='" + txtempenho.Text + "' AND   EmpenhoItems.idedital=" + cbolicitacao.SelectedValue + "";
            DataTable ds = new DataTable();
            SqlConnection Conn = Banco.CriarConexao();
            Conn.Open();

            if (Conn.State == ConnectionState.Open)
            {
                SqlCommand cmd = new SqlCommand(reg, Conn);
                SqlDataReader dr = cmd.ExecuteReader();
                if (dr.Read())
                {
                    if (!String.IsNullOrEmpty(dr["idempenhoitems"].ToString()))
                    {
                        idempenhoitems = Convert.ToInt32(dr["idempenhoitems"].ToString());
                    }



                }
            }



        }


        private Boolean VerificaRegistroEntregaExiste(int itememp, int idemp)
        {

            SqlConnection Cnn = Banco.CriarConexao();
            string obter = ("Select * From Entrega Where iditemempenho = " + itememp + " AND idempenho=" + idemp + "");
            SqlCommand sql = new SqlCommand(obter, Cnn);
            Cnn.Open();
            SqlDataReader dr = sql.ExecuteReader();
            if (dr.Read())
            {

                return false;
            }
            return true;
        }


        private void griditens_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {

            //double cell10 = Convert.ToDouble(griditens.CurrentRow.Cells[11].Value);
            //double cell8 = Convert.ToDouble(griditens.CurrentRow.Cells[9].Value);


            //if ((e.RowIndex != -1 && e.ColumnIndex == 10))
            //{


            //    if (cell10.ToString() != "")
            //    {


            //        griditens.CurrentRow.Cells[8].Value = ((cell8 * cell10) / 100 + cell8);

            //    }
            //}

            //if ((e.RowIndex != -1 && e.ColumnIndex == 11))
            //{


            //    double cell11 = Convert.ToDouble(griditens.CurrentRow.Cells[11].Value);
            //    double cell7 = Convert.ToDouble(griditens.CurrentRow.Cells[7].Value);

            //    if (cell11.ToString() != "")
            //    {


            //        griditens.CurrentRow.Cells[9].Value = ((cell7 - cell11));

            //    }
            //}

        }

        private void btnPesquisar_Click(object sender, EventArgs e)
        {
            ConsEmpenho frmemp = new ConsEmpenho();
            this.Close();
            frmemp.Show();
        }

        private void txtpesquisa_TextChanged(object sender, EventArgs e)
        {
            RetornaStatusCasas();
            carregarGridItens();
            //CarregaGridArquivos();
            //RetornaEmpenho();
        }

        private void cboprincipio_Click(object sender, EventArgs e)
        {
            CarregarPrincipioAtivo();
        }

        private void cboprincipio_KeyPress(object sender, KeyPressEventArgs e)
        {
            if ((Keys)e.KeyChar == Keys.Enter)
            {
                this.txtitem.Focus();
            }
        }

        private void txtitem_KeyPress(object sender, KeyPressEventArgs e)
        {
            if ((Keys)e.KeyChar == Keys.Enter)
            {
                this.cboempenho.Focus();
            }
        }

        private void cboempenho_KeyPress(object sender, KeyPressEventArgs e)
        {
            if ((Keys)e.KeyChar == Keys.Enter)
            {
                this.txtquantidade.Focus();
            }
        }

        private void txtquantidade_KeyPress(object sender, KeyPressEventArgs e)
        {
            if ((Keys)e.KeyChar == Keys.Enter)
            {
                if (this.txtquantidade.Text != "")
                {
                    double preco;
                    double Vltotal;
                    int qtde;

                    preco = Convert.ToDouble(this.txtpreco.Text);
                    qtde = Convert.ToInt32(txtquantidade.Text);

                    Vltotal = (preco * qtde);

                    string converttotal = String.Format("{0:N2}", Vltotal, 2);
                    this.txttotal.Text = Convert.ToString(converttotal);

                    this.cbostatus.Focus();
                }


            }
        }

        private void btnAddEmpenho_Click(object sender, EventArgs e)
        {

            GravaEmpenho();

            //if (CalculaQtdeAceita(Convert.ToInt32(txtquantidade.Text), Convert.ToInt32(cbolicitacao.SelectedValue), iditemedt) == true)
            //{

            VlEmpenhoItems items = new VlEmpenhoItems();

            if (ValidaCamposAdicionaEmpenho() == true)
            {

                items.idprincipio = principioID;
                items.iditemedital = iditemedt;
                items.idusu = Banco.idusu;
                items.empenho = Convert.ToString(cboempenho.Text);
                items.qtde = Convert.ToDouble(txtquantidade.Text);
                items.item = Convert.ToInt32(txtitem.Text);
                items.preco = Convert.ToDouble(txtpreco.Text);
                items.total = Convert.ToDouble(txttotal.Text);
                items.vladitivo = AditivoItem;
                items.edital = codedital;
                RetUltimoEmpenho();
                items.idempenho = codempenho;
                items.idproduto = Convert.ToInt32(cboprincipio.SelectedValue);
                items.nempenho = txtempenho.Text;
                items.lote = lote;
                items.idrealinhamento = realinhamentoID;
                items.idedital = Convert.ToInt32(cbolicitacao.SelectedValue);
                items.notafiscal = txtnfiscal.Text;


                try
                {


                    PsEmpenhoItems DAOEmpenho = new PsEmpenhoItems();
                    DAOEmpenho.Incluir(items);
                    int itemedt = editalitemID;
                    string edt = codedital;
                    int usu = Banco.idusu;
                    int idprincipio = principioID;
                    int idproduto = Convert.ToInt32(produtoID);
                    double aditivo = Convert.ToDouble(AditivoItem);
                    int qtde = Convert.ToInt32(txtquantidade.Text);
                    double total = Convert.ToDouble(txttotal.Text);
                    int qtdesolicitada = Convert.ToInt32(txtquantidade.Text);
                    string dtrecebimento = this.mskdtrec.Text;
                    string dtlimite = this.mskdtentrega.Text;
                    string nempenho = txtempenho.Text;
                    string notafiscal = txtnfiscal.Text;
                    string descitem = txtdescitem.Text.ToUpper();
                    string obs = txtobs.Text.ToUpper();
                    RetornaEmpenhoItems();
                    int iditemempenho = Convert.ToInt32(idempenhoitems);
                    int idmarca = Convert.ToInt32(marcaID);
                    int idempenho = Convert.ToInt32(codempenho);
                    double preco = Convert.ToDouble(txtpreco.Text);



                    VlEntrega entrega = new VlEntrega();
                    entrega.iditemedital = itemedt;
                    entrega.edital = codedital;
                    entrega.idusu = Banco.idusu;
                    entrega.idprincipio = idprincipio;
                    entrega.idproduto = idproduto;
                    entrega.dtentrega = null;
                    entrega.nempenho = nempenho;
                    entrega.aditivoedital = Convert.ToInt32(AditivoItem);
                    entrega.nfsaida = notafiscal;
                    entrega.preco = preco;
                    entrega.qtde = 0;
                    entrega.total = total;
                    entrega.idempenho = idempenho;
                    entrega.iditemempenho = iditemempenho;
                    entrega.idmarca = idmarca;
                    entrega.idedital = Convert.ToInt32(cbolicitacao.SelectedValue);
                    entrega.idrepresentante = 0;
                    entrega.comissao = 0;
                    entrega.vlcomissao = 0;


                    PsEntrega DAOEntrega = new PsEntrega();
                    DAOEntrega.Incluir(entrega);


                    carregarGridItensAdd();




                    //  LimpacamposAdd();




                }
                catch (Exception erro)
                {

                    throw erro;
                }
            }

            //}
            //else
            //{
            //    MessageBox.Show("Quantidade Informada Está Maior que a Quantidade do Edital!");
            //    txtquantidade.Focus();

            //}


        }

        private Boolean CalculaQtdeAceita(int QtdeAceita, int idEdital, int item)
        {

            SqlConnection Cnn = Banco.CriarConexao();
            string obter = ("Select (RealinhamentoProposta.Qtde) as Qdte_Edital,  (Select distinct ISNULL(SUM(EmpenhoItems.qtde),0) " +
                " From EmpenhoItems,Empenho where EmpenhoItems.idempenho = Empenho.idempenho AND  EmpenhoItems.iditemedital=" + item + " AND EmpenhoItems.idedital=" + idEdital + ") as Qdte_Items From RealinhamentoProposta,Proposta Where RealinhamentoProposta.idproposta = Proposta.idproposta AND  " +
                "Proposta.idedital='" + idEdital + "'  AND RealinhamentoProposta.iditemedital=" + item + "");
            SqlCommand sql = new SqlCommand(obter, Cnn);
            Cnn.Open();
            SqlDataReader dr = sql.ExecuteReader();
            if (dr.Read())
            {
                int Qtde_Edital = Convert.ToInt32(dr["Qdte_Edital"].ToString());
                int Qtde_Items = Convert.ToInt32(dr["Qdte_Items"].ToString()) + QtdeAceita;

                if (Qtde_Edital < Qtde_Items)
                {

                    return false;

                }
            }
            return true;



        }

        private void RetornaUltimoCodEmpenhoItem()
        {
            string reg = "Select Max(iditemempenho) as cod from Empenho WHERE idedital=" + cbolicitacao.SelectedValue + "";
            DataTable ds = new DataTable();
            SqlConnection Conn = Banco.CriarConexao();
            Conn.Open();

            if (Conn.State == ConnectionState.Open)
            {
                SqlCommand cmd = new SqlCommand(reg, Conn);
                SqlDataReader dr = cmd.ExecuteReader();
                if (dr.Read())
                {
                    coditemempenho = Convert.ToInt32(dr["cod"].ToString());

                }

            }
        }

        private void LimpacamposAdd()
        {
            cboprincipio.SelectedIndex = -1;
            iditemedt = 0;
            cboempenho.Text = "";
            txtquantidade.Text = "";
            txtitem.Text = "";
            txtpreco.Text = "0,00";
            txttotal.Text = "0,00";


        }
        int AditivoItem;
        int principioID;
        string lote;
        int realinhamentoID;
        int editalitemID;
        int marcaID;
        int produtoID;
        private void cboprincipio_SelectionChangeCommitted(object sender, EventArgs e)
        {
            if (Convert.ToString(cboprincipio.SelectedValue) != "")
            {

                string reg = "Select ItemsLicitacao.nritem,ItemsLicitacao.lote, RealinhamentoProposta.vlvenda, RealinhamentoProposta.iditemedital,Produto.nome,RealinhamentoProposta.vladitivo," +
                    "PrincipioAtivo.idprincipio,RealinhamentoProposta.idrealinhamento,RealinhamentoProposta.iditemedital,RealinhamentoProposta.vladitivo,Marca.idmarca,Produto.idproduto,RealinhamentoProposta.qtde " +
                    "FROM RealinhamentoProposta LEFT JOIN EmpenhoItems ON RealinhamentoProposta.idrealinhamento = EmpenhoItems.idrealinhamento,Produto,LancEditais,ItemsLicitacao,PrincipioAtivo,Marca " +
                    "WHERE LancEditais.idedital = ItemsLicitacao.idedital and ItemsLicitacao.idproduto = Produto.idproduto  AND ItemsLicitacao.iditemedital = RealinhamentoProposta.iditemedital AND RealinhamentoProposta.idmarca = Marca.idmarca " +
                    "AND ItemsLicitacao.idprincipio = PrincipioAtivo.idprincipio AND Produto.idproduto=" + cboprincipio.SelectedValue + "";
                DataTable ds = new DataTable();
                SqlConnection Conn = Banco.CriarConexao();
                Conn.Open();

                if (Conn.State == ConnectionState.Open)
                {
                    SqlCommand cmd = new SqlCommand(reg, Conn);
                    SqlDataReader dr = cmd.ExecuteReader();
                    if (dr.Read())
                    {

                        this.txtitem.Text = dr["nritem"].ToString();
                        decimal pcompra = Convert.ToDecimal(dr["vlvenda"].ToString());
                        this.txtpreco.Text = String.Format("{0:N2}", pcompra, 2);
                        iditemedt = Convert.ToInt32(dr["iditemedital"].ToString());
                        AditivoItem = Convert.ToInt32(dr["vladitivo"].ToString());
                        principioID = Convert.ToInt32(dr["idprincipio"].ToString());
                        lote = dr["lote"].ToString();
                        realinhamentoID = Convert.ToInt32(dr["idrealinhamento"].ToString());
                        editalitemID = Convert.ToInt32(dr["iditemedital"].ToString());
                        marcaID = Convert.ToInt32(dr["idmarca"].ToString());
                        produtoID = Convert.ToInt32(dr["idproduto"].ToString());
                        labqtdetotal.Text = Convert.ToString(dr["qtde"].ToString());

                    }
                }
            }

        }
        private void carregarGridItensAdd()
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

                string strConn = " select DISTINCT RealinhamentoProposta.iditemedital as itemedital,Produto.nome + ' - ' + Produto.apresentacao  as Descrição,Marca.nome as Marca, EmpenhoItems.item as Item,EmpenhoItems.lote as Lote," +
                                "EmpenhoItems.empenho as Empenho,RealinhamentoProposta.vlvenda as Preço, EmpenhoItems.qtde as QdtEmpenho,EmpenhoItems.total as Total," +
                                "(RealinhamentoProposta.Qtde) as QtdEdital,EmpenhoItems.idempenhoitems,RealinhamentoProposta.vladitivo as Aditivo, Marca.idmarca, EmpenhoItems.idempenho,EmpenhoItems.notafiscal," +
                                 "(RealinhamentoProposta.Qtde) - (Select  Sum(EmpenhoItems.qtde) From EmpenhoItems LEFT JOIN Empenho ON Empenho.idempenho = EmpenhoItems.idempenho  where RealinhamentoProposta.iditemedital = EmpenhoItems.iditemedital AND EmpenhoItems.idedital =  " + cbolicitacao.SelectedValue + " AND EmpenhoItems.nempenho='" + txtempenho.Text + "')  as Pendente, " +
                                "EmpenhoItems.vladitivo as Aditivo,(Select sum(Entrega.qtde)   from Entrega LEFT JOIN  Empenho ON Entrega.idempenho = Empenho.idempenho WHERE EmpenhoItems.iditemedital = Entrega.iditemedital AND Empenho.idedital = " + cbolicitacao.SelectedValue + " AND EmpenhoItems.nempenho='" + txtempenho.Text + "') as Entregues," +
                                "Produto.idproduto,PrincipioAtivo.idprincipio,(RealinhamentoProposta.Qtde) as Qtde_Edital " +
                                "From EmpenhoItems INNER JOIN Empenho ON EmpenhoItems.idempenho = Empenho.idempenho INNER JOIN  RealinhamentoProposta ON EmpenhoItems.idrealinhamento = RealinhamentoProposta.idrealinhamento  " +
                                 "INNER JOIN Entrega ON  EmpenhoItems.idempenho = Entrega.idempenho,PrincipioAtivo,Produto,Marca WHERE Produto.idprincipio = PrincipioAtivo.idprincipio AND RealinhamentoProposta.idmarca = Marca.idmarca AND " +
                                  "EmpenhoItems.idprincipio = PrincipioAtivo.idprincipio AND   Produto.idproduto = EmpenhoItems.idproduto  AND EmpenhoItems.idedital = " + cbolicitacao.SelectedValue + " AND EmpenhoItems.nempenho='" + txtempenho.Text + "'";


                SqlDataAdapter da = new SqlDataAdapter(strConn, Conn);
                da.Fill(ds);


            }

            this.griditens.RowsDefaultCellStyle.BackColor = Color.LightBlue;
            this.griditens.AlternatingRowsDefaultCellStyle.BackColor = Color.Azure;

            var column = new DataGridViewComboBoxColumn();

            griditens.AutoGenerateColumns = false;
            //exibe os dados no datagridview
            griditens.DataSource = ds;
            griditens.Columns.Clear();
            griditens.Columns.Add(chkb);
            chkb.HeaderText = "Sel";
            chkb.Name = "chkb";
            griditens.Columns.Add("itemedital", "itemedital");
            griditens.Columns.Add("Descrição", "Descrição");
            griditens.Columns.Add("Marca", "Marca");
            griditens.Columns.Add("Item", "Item");
            griditens.Columns.Add("Lote", "Lote");


            DataTable data = new DataTable();

            data.Columns.Add(new DataColumn("Value", typeof(string)));
            data.Columns.Add(new DataColumn("Description", typeof(string)));

            data.Rows.Add("SIM", "SIM");
            data.Rows.Add("NAO", "NAO");
            column.DataSource = data;
            column.HeaderText = "Empenho";
            column.ValueMember = "Value";
            column.DisplayMember = "Description";
            griditens.Columns.Insert(6, column);


            griditens.Columns.Add("Preço", "Preço");
            griditens.Columns.Add("QdtEmpenho", "QdtEmpenho");
            griditens.Columns.Add("Total", "Total");


            griditens.Columns.Add("Pendente", "Pendente");
            griditens.Columns.Add("Aditivo", "Aditivo");
            griditens.Columns.Add("Qtd_Edital", "Qtd_Edital");
            griditens.Columns.Add("Entregues", "Entregues");
            griditens.Columns.Add("idproduto", "idproduto");
            griditens.Columns.Add("idprincipio", "idprincipio");
            griditens.Columns.Add("idempenhoitems", "idempenhoitems");
            griditens.Columns.Add("idmarca", "idmarca");
            griditens.Columns.Add("idempenho", "idempenho");
            griditens.Columns.Add("QtdEdital", "QtdEdital");
            griditens.Columns.Add("notafiscal", "notafiscal");


            griditens.Columns[0].Width = 50;
            griditens.Columns[1].Visible = false;
            griditens.Columns[2].Width = 200;
            griditens.Columns[3].Width = 140;
            griditens.Columns[4].Width = 50;
            griditens.Columns[5].Width = 58;
            griditens.Columns[7].Width = 75;
            griditens.Columns[8].Width = 80;
            griditens.Columns[9].Width = 80;
            griditens.Columns[10].Width = 70;
            griditens.Columns[11].Width = 70;
            griditens.Columns[12].Width = 80;
            griditens.Columns[13].Width = 80;
            griditens.Columns[14].Visible = false;
            griditens.Columns[15].Visible = false;
            griditens.Columns[16].Visible = false;
            griditens.Columns[17].Visible = false;
            griditens.Columns[18].Visible = false;
            griditens.Columns[19].Visible = false;
            griditens.Columns[20].Width = 110;

            griditens.Columns[7].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            griditens.Columns[8].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            griditens.Columns[8].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
            griditens.Columns[9].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            griditens.Columns[9].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
            griditens.Columns[4].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            griditens.Columns[5].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
            griditens.Columns[5].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            griditens.Columns[5].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
            griditens.Columns[10].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            griditens.Columns[10].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
            griditens.Columns[11].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            griditens.Columns[11].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
            griditens.Columns[12].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            griditens.Columns[12].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
            griditens.Columns[13].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            griditens.Columns[13].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;

            griditens.Columns[1].DataPropertyName = "itemedital";
            griditens.Columns[2].DataPropertyName = "Descrição";
            griditens.Columns[3].DataPropertyName = "Marca";
            griditens.Columns[4].DataPropertyName = "Item";
            griditens.Columns[5].DataPropertyName = "Lote";
            griditens.Columns[6].DataPropertyName = "Empenho";
            griditens.Columns[7].DataPropertyName = "Preço";
            griditens.Columns[8].DataPropertyName = "QdtEmpenho";
            griditens.Columns[9].DataPropertyName = "Total";
            griditens.Columns[10].DataPropertyName = "Pendente";
            griditens.Columns[11].DataPropertyName = "Aditivo";
            griditens.Columns[12].DataPropertyName = "QtdEdital";
            griditens.Columns[13].DataPropertyName = "Entregues";
            griditens.Columns[14].DataPropertyName = "idproduto";
            griditens.Columns[15].DataPropertyName = "idprincipio";
            griditens.Columns[16].DataPropertyName = "idempenhoitems";
            griditens.Columns[17].DataPropertyName = "idmarca";
            griditens.Columns[18].DataPropertyName = "idempenho";
            griditens.Columns[19].DataPropertyName = "QtdEdital";
            griditens.Columns[20].DataPropertyName = "notafiscal";


            griditens.Columns[7].ReadOnly = true;
            griditens.Columns[3].ReadOnly = true;
            griditens.Columns[4].ReadOnly = true;
            griditens.Columns[5].ReadOnly = true;
            griditens.Columns[9].ReadOnly = true;
            griditens.Columns[10].ReadOnly = true;
            griditens.Columns[8].ReadOnly = true;
            griditens.Columns[11].ReadOnly = true;
            griditens.Columns[13].ReadOnly = true;
            griditens.Columns[12].ReadOnly = true;

            DataGridViewButtonColumn btn = new DataGridViewButtonColumn();
            griditens.Columns.Add(btn);
            btn.HeaderText = "Excluir";
            btn.Text = "Excluir";
            btn.Name = "btn";
            btn.Width = 60;
            btn.UseColumnTextForButtonValue = true;
            btn.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft;

            if (casas == 2)
            {

                griditens.Columns[7].DefaultCellStyle.Format = "n2";
                //  griditens.Columns[10].DefaultCellStyle.Format = "#.00\\%";
                griditens.Columns[9].DefaultCellStyle.Format = "n2";



            }
            else if (casas == 3)
            {

                griditens.Columns[7].DefaultCellStyle.Format = "n3";
                // griditens.Columns[10].DefaultCellStyle.Format = "#.00\\%";
                griditens.Columns[9].DefaultCellStyle.Format = "n3";

            }
            else if (casas == 4)
            {

                griditens.Columns[7].DefaultCellStyle.Format = "n4";
                // griditens.Columns[10].DefaultCellStyle.Format = "#.00\\%";
                griditens.Columns[9].DefaultCellStyle.Format = "n4";

            }

            valor = 0;

            foreach (DataGridViewRow linha in griditens.Rows)
            {
                if ((linha.Cells[9].Value != DBNull.Value))
                {

                    valor += Convert.ToDouble(linha.Cells[9].Value);
                }

            }


            double valort = valor;
            string convertido = String.Format("{0:N3}", Math.Round(valort, 4));
            labTotal.Text = convertido;

            griditens.Refresh();

        }

        double calculoaditivo;
        private void txtaditivo_KeyPress(object sender, KeyPressEventArgs e)
        {

            //if ((Keys)e.KeyChar == Keys.Enter)
            //{

            //    if (this.cbolicitacao.Text != "")
            //    {


            //        RetornaStatusCasas();

            //        double vltotal = Convert.ToDouble(txttotal.Text);
            //        double aditivo = Convert.ToDouble(txtaditivo.Text);


            //        double calculaaditivo = ((aditivo * vltotal) / 100);
            //        string aditivocauculado = Convert.ToString(calculaaditivo + vltotal);

            //        calculoaditivo = calculaaditivo;

            //        if (casas == 2)
            //        {

            //            string converttotal = String.Format("{0:N2}", aditivocauculado, 2);
            //            this.txttotal.Text = Convert.ToString(converttotal);
            //        }
            //        else if (casas == 3)
            //        {

            //            string converttotal = String.Format("{0:N3}", aditivocauculado, 3);
            //            this.txttotal.Text = Convert.ToString(converttotal);

            //        }
            //        else if (casas == 4)
            //        {

            //            string converttotal = String.Format("{0:N4}", aditivocauculado, 4);
            //            this.txttotal.Text = Convert.ToString(converttotal);

            //        }


            //        this.btnAddEmpenho.Focus();
            //    }
            //    else

            //    MessageBox.Show("Informe os dados da Licitação!");
            //    cbolicitacao.Focus();


            //}

        }

        private void Grid_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            codarquivo = Convert.ToInt32(Grid.CurrentRow.Cells[1].Value.ToString());


            SqlConnection Cnn = Banco.CriarConexao();
            string query = "Select arq,extensao,nomearq from DocumentoEmpenho Where DocumentoEmpenho.iddocempenho = " + Convert.ToInt32(Grid[1, e.RowIndex].Value.ToString());

            SqlCommand ObjC = new SqlCommand(query, Cnn);
            Cnn.Open();
            SqlDataReader dr = ObjC.ExecuteReader();

            dr.Read();


            try
            {


                //string FileLocation = Path.GetTempPath() + dr["tipo"].ToString();
                string ext = dr["extensao"].ToString();
                string narq = dr["nomearq"].ToString();

                byte[] fileData = (byte[])dr["arq"];
                using (System.IO.FileStream fs = new System.IO.FileStream(@"C:\D\" + narq, FileMode.Create))
                {

                    {
                        fs.Write(fileData, 0, fileData.Length);
                        System.Diagnostics.Process.Start(@"C:\D\" + narq);
                        fs.Close();
                        dr.Close();
                        Cnn.Close();
                    }
                }



            }
            catch (Exception)
            {

                MessageBox.Show("Arquivo já se encontra em aberto");
            }
            Cnn.Close();

        }

        private void cbostatus_KeyPress(object sender, KeyPressEventArgs e)
        {
            if ((Keys)e.KeyChar == Keys.Enter)
            {
                mskdtdoc.Focus();

            }
        }

        private void btnEmpenho_Click(object sender, EventArgs e)
        {

            foreach (DataGridViewRow row in griditens.Rows)
            {

                if (bool.Parse(row.Cells[0].EditedFormattedValue.ToString()))
                {

                    coditemempenho = Convert.ToInt32(row.Cells[1].Value);
                    ideditalempenho = Convert.ToInt32(cbolicitacao.SelectedValue);
                    ViewInformacoesRealinhamento frminforealinhamento = new ViewInformacoesRealinhamento(this);
                    frminforealinhamento.Show();


                }
            }
        }

        private void BtnImprimirProposta_Click(object sender, EventArgs e)
        {
            editalrel = Convert.ToInt32(cbolicitacao.SelectedValue);
            numeroempenho = txtempenho.Text;
            notafiscal = txtnfiscal.Text.Trim();

            RelEmpenho empenho = new RelEmpenho(this);
            empenho.Show();
        }

        private void Limpacampos()
        {

            this.txtempenho.Text = "";
            this.cboempenho.Text = "";
            this.cbocliente.SelectedIndex = -1;
            cbolicitacao.Text = "";
            this.txtnfiscal.Text = "";
            this.cbostatus.Text = "";
            mskdtrec.Text = "";
            mskdtentrega.Text = "";
            mskdtdoc.Text = "";
            txtpesquisa.Text = "";
            this.cboproduto.Text = "";
            cbomarca.Text = "";
            Grid.DataSource = null;
            griditens.DataSource = null;
            labTotal.Text = "00;00";
            txtatacontrato.Text = "";
            mskvigencia.Text = "";
            btnPesquisar.Focus();



        }


        private void button1_Click(object sender, EventArgs e)
        {
            Limpacampos();
            ConsNovoEmpenho frmemp = new ConsNovoEmpenho();
            this.Close();
            frmemp.Show();

        }

        private void button2_Click(object sender, EventArgs e)
        {

            if (txtempenho.Text != "")
            {

                numeroempenho = txtempenho.Text;
                notafiscal = txtnfiscal.Text;
                dtrecebimento = mskdtrec.Text;
                dtlimite = mskdtentrega.Text;
                idcli = Convert.ToInt32(cbocliente.SelectedValue);
                ideditalempenho = Convert.ToInt32(cbolicitacao.SelectedValue);
                ata = txtatacontrato.Text;
                dtvigencia = mskvigencia.Text;
                if (txtcodigo.Text != "")
                {
                    codempenho = Convert.ToInt32(txtcodigo.Text);
                }


                ViewAdicionaItemsEmpenho add = new ViewAdicionaItemsEmpenho(this);
                this.Close();
                add.Show();

            }
        }

        private void ViewEmpenho_Load(object sender, EventArgs e)
        {
            txtquantidade.SelectionStart = 0;
            txtquantidade.SelectionLength = txtquantidade.Text.Length;
            txtquantidade.Focus();
        }

        private void txtatacontrato_KeyPress(object sender, KeyPressEventArgs e)
        {
            if ((Keys)e.KeyChar == Keys.Enter)
            {
                this.mskvigencia.Focus();
            }
        }

        private void txtndoc_KeyPress(object sender, KeyPressEventArgs e)
        {
            if ((Keys)e.KeyChar == Keys.Enter)
            {
                this.mskdtrec.Focus();
            }
        }

        private void mskvigencia_KeyPress(object sender, KeyPressEventArgs e)
        {
            if ((Keys)e.KeyChar == Keys.Enter)
            {
                this.mskdtrec.Focus();
            }
        }

        private void txtnfiscal_KeyPress_1(object sender, KeyPressEventArgs e)
        {
            if ((Keys)e.KeyChar == Keys.Enter)
            {
                this.cbostatus.Focus();
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            VlEmpenho obj = new VlEmpenho();
            obj.idempenho = Convert.ToInt32(txtcodigo.Text);

            try
            {
                PsEmpenho DAOempenho = new PsEmpenho();
                DAOempenho.Exluir(obj.idempenho);
                DAOempenho.ExluirEmpenhoItens(obj.idempenho);
                MessageBox.Show("Registro Excluido Com Sucesso!");
                Limpacampos();




            }
            catch (Exception erro)
            {

                throw erro;
            }
        }

        private void button5_Click(object sender, EventArgs e)
        {
            GravaEmpenho();
            {
                foreach (DataGridViewRow row in griditens.Rows)
                {

                    if (bool.Parse(row.Cells[0].EditedFormattedValue.ToString()) == true)
                    {
                        VlEmpenhoItems items = new VlEmpenhoItems();

                        items.idempenhoitems = Convert.ToInt32(row.Cells[16].Value);
                        items.idusu = Banco.idusu;
                        items.notafiscal = txtnfiscal.Text.ToUpper();

                        {
                            PsEmpenhoItems DAOempenhoItems = new PsEmpenhoItems();
                            DAOempenhoItems.Alterar(items);
                            VlEntrega entrega = new VlEntrega();
                            entrega.iditemempenho = items.idempenhoitems;
                            entrega.idusu = items.idusu;
                            entrega.nfsaida = items.notafiscal;
                            PsEntrega DAOentrega = new PsEntrega();
                            DAOentrega.AlterarPorEmpenho(entrega);
                            MessageBox.Show("Registro Alterado Com Sucesso!");
                            CarregaGridNumeroEmpenho(txtempenho.Text);




                        }
                    }
                }
            }
        }
    }
}
