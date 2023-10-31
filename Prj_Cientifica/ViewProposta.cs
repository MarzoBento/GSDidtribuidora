using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.IO;
using System.IO.Compression;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;


namespace Prj_Cientifica
{



    public partial class ViewProposta : Form
    {
        public static string TipoGravacao;
        public static int UltimoSelecionado;
        public string nomeFor = "ViewProposta";
        public int casas;
        public int casascusto;
        public string Edittal;
        public List<Decrescimos> list = new List<Decrescimos>();


        public ViewProposta()
        {
            InitializeComponent();
        }

        public ViewProposta(ConsGerarCotacao frm) : this()
        {
            UltimoSelecionado = Convert.ToInt32(frm.codedital);
            Edittal = Convert.ToString(frm.edittal);
            RetReg();


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

            carregarGridItens();

        }


        private void RetReg()
        {
            string reg = "Select * from LancEditais Where idedital = " + UltimoSelecionado + "";
            DataTable ds = new DataTable();
            SqlConnection Conn = Banco.CriarConexao();
            Conn.Open();

            if (Conn.State == ConnectionState.Open)
            {
                SqlCommand cmd = new SqlCommand(reg, Conn);
                SqlDataReader dr = cmd.ExecuteReader();
                if (dr.Read())
                {
                    RetronarCarregarLicitacao(Convert.ToInt32(dr["idedital"].ToString()));
                    RetornaCliente(UltimoSelecionado);
                    RetornaStatusCasasCusto();
                    RetornaStatusCasas();
                    //CarregaGridArquivos();




                }
            }
        }



        private void RetronarCarregarLicitacao(int retgercot)
        {
            SqlConnection Cnn = Banco.CriarConexao();
            SqlDataAdapter sql = new SqlDataAdapter("Select LancEditais.idedital,LancEditais.nlicitacao,(CAST(LancEditais.nlicitacao AS VARCHAR(10))) + '               ' + (Modalidade.nome + '                    ' +  LancEditais.nlicitacao + '                        ' + " +
                "LancEditais.nprocesso + '                       ' + CONVERT(CHAR,LancEditais.dtabertura,103)) as Licitacao  from LancEditais,Modalidade " +
                " WHERE LancEditais.idmodalidade = Modalidade.idmodalidade and LancEditais.idedital=" + retgercot + "", Cnn);
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
            SqlDataAdapter sql = new SqlDataAdapter("Select LancEditais.idedital,LancEditais.nlicitacao,(CAST(LancEditais.nlicitacao AS VARCHAR(10))) + '          ' + (Modalidade.nome + '                      ' +  LancEditais.nlicitacao + '                        ' + " +
                "LancEditais.nprocesso + '             ' + CONVERT(CHAR,LancEditais.dtabertura,103)) as Licitacao from LancEditais,Modalidade " +
                " WHERE LancEditais.idmodalidade = Modalidade.idmodalidade ", Cnn);
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

            //RetornaStatusCasas();
            // carregarGridItens();

            //CarregaGridArquivos();


        }

        private void RetornaStatusCasas()
        {
            string reg = "Select casasdecimais FROM  Proposta  Where Proposta.idedital=" + cbolicitacao.SelectedValue + "";
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
                            carregarGridItens2CasasDecimais();

                        }
                        else if (casas == 3)
                        {
                            rbt3casas.Checked = true;
                            carregarGridItens3CasasDecimais();

                        }
                        else if (casas == 4)
                        {
                            rbt4casas.Checked = true;
                            carregarGridItens4CasasDecimais();

                        }


                    }
                }
            }


        }
        private void RetornaStatusCasasCusto()
        {
            string reg = "Select casasdecimais FROM  LancEditais  Where LancEditais.idedital=" + cbolicitacao.SelectedValue + "";
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

                        casascusto = Convert.ToInt32(dr["casasdecimais"].ToString());

                    }
                }
            }


        }


        public decimal valor;
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



                string strConn = "SELECT DISTINCT ItemsLicitacao.nritem , Fornecedor.nome as Fornecedor,CONVERT(varchar(10),ItemsLicitacao.nritem) + ' - ' + Produto.nome + ' - ' + Produto.apresentacao + ' - ' + Marca.nome as Item," +
               "ItemsLicitacao.qtde as Qtde,VendaPreco.precocusto as Custo,Proposta.margemfinal as MargemFinal,Proposta.precovenda as Venda," +
              "(Proposta.precovenda * ItemsLicitacao.qtde) as Total_Produto,Proposta.selecionado as Selecionado,Proposta.cotado as Cotado,ItemsLicitacao.iditemedital as Cod," +
               "Proposta.ganho as Ganho,UnidadeMedida.idunidade as Unidade,Marca.idmarca as Marca,Proposta.idproposta as idproposta,Decrescimos.vldecrescimo as Dec, Acrescimo.vlacrescimo as Acrescimo," +
               "Produto.idproduto,Proposta.precominimo as Vl_Minimo, Proposta.minimototal as Minimo_Total,Proposta.edital" +
              " From  ItemsLicitacao INNER JOIN Proposta ON ItemsLicitacao.iditemedital = Proposta.iditemedital  INNER JOIN VendaPreco ON ItemsLicitacao.iditemedital = VendaPreco.iditemedital" +
              " LEFT JOIN Decrescimos ON Proposta.idproposta = Decrescimos.idproposta  LEFT JOIN  Produto_Fornecedor ON Proposta.idfornecedor = Produto_Fornecedor.idfornecedor" +
              " LEFT JOIN Acrescimo ON  Proposta.idproposta = Acrescimo.idproposta,UnidadeMedida,Produto,Fornecedor,LancEditais,RetCotacao,Marca" +
               " Where LancEditais.idedital = Proposta.idedital  AND VendaPreco.idedital = RetCotacao.idedital AND VendaPreco.iditemedital = RetCotacao.iditemedital AND " +
               "Produto.idunidade = UnidadeMedida.idunidade AND Produto.idmarca = Marca.idmarca AND VendaPreco.idedital = ItemsLicitacao.idedital " +
               "and Proposta.idedital = VendaPreco.idedital and Produto.idproduto = ItemsLicitacao.idproduto AND ItemsLicitacao.iditemedital = RetCotacao.iditemedital " +
               "AND Proposta.idfornecedor = Fornecedor.idfornecedor AND ItemsLicitacao.idedital=" + cbolicitacao.SelectedValue + " Order by ItemsLicitacao.nritem";

                SqlDataAdapter da = new SqlDataAdapter(strConn, Conn);
                da.Fill(ds);


            }


            this.griditens.RowsDefaultCellStyle.BackColor = Color.LightBlue;
            this.griditens.AlternatingRowsDefaultCellStyle.BackColor = Color.Azure;

            var column = new DataGridViewComboBoxColumn();
            var cotado = new DataGridViewComboBoxColumn();
            griditens.AutoGenerateColumns = false;
            //exibe os dados no datagridview
            // ds.PrimaryKey = new DataColumn[] { ds.Columns["nritem"] };
            // ds.Columns[0].Unique = true;
            griditens.DataSource = ds;
            griditens.Columns.Clear();
            griditens.Columns.Add("Fornecedor", "Fornecedor");
            griditens.Columns.Add("Item", "Item");

            DataTable data = new DataTable();

            data.Columns.Add(new DataColumn("Value", typeof(string)));
            data.Columns.Add(new DataColumn("Description", typeof(string)));

            data.Rows.Add("SIM", "SIM");
            data.Rows.Add("NAO", "NAO");
            column.DataSource = data;
            column.HeaderText = "Selec ?";
            column.ValueMember = "Value";
            column.DisplayMember = "Description";
            griditens.Columns.Insert(2, column);


            DataTable dtcotado = new DataTable();

            dtcotado.Columns.Add(new DataColumn("Value", typeof(string)));
            dtcotado.Columns.Add(new DataColumn("Description", typeof(string)));

            dtcotado.Rows.Add("SIM", "SIM");
            dtcotado.Rows.Add("NAO", "NAO");
            cotado.DataSource = dtcotado;
            cotado.HeaderText = "Cotado ?";
            cotado.ValueMember = "Value";
            cotado.DisplayMember = "Description";
            griditens.Columns.Insert(3, cotado);


            griditens.Columns.Add("Qtde", "Qtde");
            griditens.Columns.Add("Custo", "Custo");
            griditens.Columns.Add("MargemFinal", "MargemFinal");
            griditens.Columns.Add("Venda", "Venda");
            griditens.Columns.Add("Total_Produto", "Total_Produto");
            griditens.Columns.Add("Cod", "Cod");
            griditens.Columns.Add(chkb);
            chkb.HeaderText = "Sel";
            chkb.Name = "chkb";
            chkb.Width = 30;
            griditens.Columns.Add("Ganho", "Ganho");
            griditens.Columns.Add("Unidade", "Unidade");
            griditens.Columns.Add("Marca", "Marca");
            griditens.Columns.Add("idproposta", "idproposta");
            griditens.Columns.Add("Dec", "Dec");
            griditens.Columns.Add("Acrescimo", "Acrescimo");
            griditens.Columns.Add("idproduto", "idproduto");
            griditens.Columns.Add("Vl_Minimo", "Vl_Minimo");
            griditens.Columns.Add("Minimo_Total", "Minimo_Total");
            griditens.Columns.Add("edital", "edital");

            griditens.Columns[0].Width = 150;
            griditens.Columns[1].Width = 190;
            griditens.Columns[4].Width = 70;
            griditens.Columns[5].Width = 70;
            griditens.Columns[6].Width = 80;
            griditens.Columns[7].Width = 80;
            griditens.Columns[8].Width = 110;
            griditens.Columns[9].Visible = false;
            griditens.Columns[10].Width = 40;
            griditens.Columns[11].Visible = false;
            griditens.Columns[12].Visible = false;
            griditens.Columns[13].Visible = false;
            griditens.Columns[14].Visible = false;
            griditens.Columns[15].Width = 50;
            griditens.Columns[16].Width = 80;
            griditens.Columns[17].Visible = false;
            griditens.Columns[18].Width = 80;
            griditens.Columns[19].Width = 85;
            griditens.Columns[20].Visible = false;

            griditens.Columns[5].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            griditens.Columns[6].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            griditens.Columns[7].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            griditens.Columns[8].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            griditens.Columns[9].DefaultCellStyle.Alignment = DataGridViewContentAlignment.TopCenter;
            griditens.Columns[15].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            griditens.Columns[16].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            griditens.Columns[18].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            griditens.Columns[19].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;

            griditens.Columns[0].DataPropertyName = "Fornecedor";
            griditens.Columns[1].DataPropertyName = "Item";
            griditens.Columns[2].DataPropertyName = "Selecionado";
            griditens.Columns[3].DataPropertyName = "Cotado";
            griditens.Columns[4].DataPropertyName = "Qtde";
            griditens.Columns[5].DataPropertyName = "Custo";
            griditens.Columns[6].DataPropertyName = "MargemFinal";
            griditens.Columns[7].DataPropertyName = "Venda";
            griditens.Columns[8].DataPropertyName = "Total_Produto";
            griditens.Columns[9].DataPropertyName = "Cod";
            griditens.Columns[10].DataPropertyName = "Ganha";
            griditens.Columns[11].DataPropertyName = "Ganho";
            griditens.Columns[12].DataPropertyName = "Unidade";
            griditens.Columns[13].DataPropertyName = "Marca";
            griditens.Columns[14].DataPropertyName = "idproposta";
            griditens.Columns[15].DataPropertyName = "Dec";
            griditens.Columns[16].DataPropertyName = "Acrescimo";
            griditens.Columns[17].DataPropertyName = "idproduto";
            griditens.Columns[18].DataPropertyName = "Vl_Minimo";
            griditens.Columns[19].DataPropertyName = "Minimo_Total";
            griditens.Columns[20].DataPropertyName = "edital";


            griditens.Columns[4].ReadOnly = true;
            griditens.Columns[5].ReadOnly = true;
            griditens.Columns[14].ReadOnly = true;
            griditens.Columns[15].ReadOnly = true;
            griditens.Columns[16].ReadOnly = true;
            griditens.Columns[12].ReadOnly = true;

            if (casas == 2)
            {
                rbt2casas.Checked = true;
                // griditens.Columns[5].DefaultCellStyle.Format = "n2";
                griditens.Columns[6].DefaultCellStyle.Format = "#.00\\%";
                griditens.Columns[7].DefaultCellStyle.Format = "n2";
                griditens.Columns[8].DefaultCellStyle.Format = "n2";
                griditens.Columns[15].DefaultCellStyle.Format = "#.00\\%";
                griditens.Columns[16].DefaultCellStyle.Format = "#.00\\%";
                griditens.Columns[18].DefaultCellStyle.Format = "n2";
                griditens.Columns[19].DefaultCellStyle.Format = "n2";

            }
            else if (casas == 3)
            {
                rbt3casas.Checked = true;
                //griditens.Columns[5].DefaultCellStyle.Format = "n3";
                griditens.Columns[6].DefaultCellStyle.Format = "#.00\\%";
                griditens.Columns[7].DefaultCellStyle.Format = "n3";
                griditens.Columns[8].DefaultCellStyle.Format = "n2";
                griditens.Columns[15].DefaultCellStyle.Format = "#.00\\%";
                griditens.Columns[16].DefaultCellStyle.Format = "#.00\\%";
                griditens.Columns[18].DefaultCellStyle.Format = "n3";
                griditens.Columns[19].DefaultCellStyle.Format = "n2";
            }
            else if (casas == 4)
            {
                rbt4casas.Checked = true;
                // griditens.Columns[5].DefaultCellStyle.Format = "n4";
                griditens.Columns[6].DefaultCellStyle.Format = "#.00\\%";
                griditens.Columns[7].DefaultCellStyle.Format = "n4";
                griditens.Columns[8].DefaultCellStyle.Format = "n2";
                griditens.Columns[15].DefaultCellStyle.Format = "#.00\\%";
                griditens.Columns[16].DefaultCellStyle.Format = "#.00\\%";
                griditens.Columns[18].DefaultCellStyle.Format = "n4";
                griditens.Columns[19].DefaultCellStyle.Format = "n2";
            }

            valor = 0;

            foreach (DataGridViewRow linha in griditens.Rows)
            {

                valor += Convert.ToDecimal(linha.Cells[8].Value);
            }


            decimal valort = valor;
            string convertido = String.Format("{0:N2}", Math.Round(valort, 2));
            labTotal.Text = convertido;



            foreach (DataGridViewRow linha in griditens.Rows)
            {
                if ((linha.Cells[9].Value.ToString() == Convert.ToString(2)))
                {

                    linha.Cells["chkb"].Value = true;


                }

            }



            Int32 total = 0;

            foreach (DataGridViewRow linhatotal in griditens.Rows)
            {
                total = total + 1;
            }

            this.txttotalitens.Text = Convert.ToString(total);



            griditens.Refresh();


        }

        private void griditens_DataError(object sender, DataGridViewDataErrorEventArgs e)
        {
            //if (e.Exception.Message == "DataGridViewComboBoxCell value is not valid.")
            //{
            //    object value = griditens.Rows[e.RowIndex].Cells[e.ColumnIndex].Value;
            //    if (!((DataGridViewComboBoxColumn)griditens.Columns[e.ColumnIndex]).Items.Contains(value))
            //    {
            //        ((DataGridViewComboBoxColumn)griditens.Columns[e.ColumnIndex]).Items.Add(value);
            //        e.ThrowException = true;
            //    }
            //}
        }

        private void btnSair_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        public int codret;
        private void btnSalvar_Click(object sender, EventArgs e)
        {


            GravaProposta();

        }


        private void GravaProposta()
        {

            try


            {

                foreach (DataGridViewRow row in griditens.Rows)
                {


                    if (Convert.ToBoolean(row.Cells["chkb"].EditedFormattedValue) == true)
                    {
                        double totalcusto = 0;
                        int col9 = Convert.ToInt32(row.Cells[9].Value);

                        VlRealinhamento obj = new VlRealinhamento();
                        obj.iditemedital = Convert.ToInt32(row.Cells[9].Value);
                        obj.qtde = Convert.ToInt32(row.Cells[4].Value);
                        if (rbt2casas.Checked == true)
                        {
                            //string vlcusto = String.Format("{0:N2}", Convert.ToDecimal(row.Cells[5].Value), 2);
                            //obj.vlcusto = Convert.ToDouble(vlcusto);

                            string vlvenda = String.Format("{0:N2}", Convert.ToDecimal(row.Cells[7].Value), 2);
                            obj.vlvenda = Convert.ToDecimal(vlvenda);
                            string vltotal = String.Format("{0:N2}", Convert.ToDecimal(row.Cells[8].Value), 2);
                            obj.vltotal = Convert.ToDecimal(vltotal);
                            if (row.Cells[18].Value.ToString() == "")
                            {
                                row.Cells[18].Value = "0,00";
                            }
                            string munit = String.Format("{0:N2}", Convert.ToDecimal(row.Cells[7].Value), 2);
                            obj.minimounit = Convert.ToDecimal(munit);
                            if (row.Cells[19].Value.ToString() == "")
                            {
                                row.Cells[19].Value = "0,00";
                            }
                            string mintot = String.Format("{0:N2}", Convert.ToDecimal(row.Cells[8].Value), 2);
                            obj.minimototal = Convert.ToDecimal(mintot);

                            casas = 2;




                        }
                        else if (rbt3casas.Checked == true)
                        {
                            //string vlcusto = String.Format("{0:N3}", Convert.ToDecimal(row.Cells[5].Value), 3);
                            //obj.vlcusto = Convert.ToDouble(vlcusto);
                            //totalcusto = Convert.ToInt32(row.Cells[4].Value);
                            //obj.total = totalcusto;

                            string vlvenda = String.Format("{0:N3}", Convert.ToDecimal(row.Cells[7].Value), 3);
                            obj.vlvenda = Convert.ToDecimal(vlvenda);
                            string vltotal = String.Format("{0:N2}", Convert.ToDecimal(row.Cells[8].Value), 3);
                            obj.vltotal = Convert.ToDecimal(vltotal);
                            if (row.Cells[18].Value.ToString() == "")
                            {
                                row.Cells[18].Value = "0,00";
                            }
                            string munit = String.Format("{0:N3}", Convert.ToDecimal(row.Cells[7].Value), 3);
                            obj.minimounit = Convert.ToDecimal(munit);
                            if (row.Cells[19].Value.ToString() == "")
                            {
                                row.Cells[19].Value = "0,00";
                            }
                            string mintot = String.Format("{0:N2}", Convert.ToDecimal(row.Cells[8].Value), 3);
                            obj.minimototal = Convert.ToDecimal(mintot);

                            casas = 3;

                        }
                        else if (rbt4casas.Checked == true)
                        {
                            //string vlcusto = String.Format("{0:N4}", Convert.ToDecimal(row.Cells[5].Value), 4);
                            //obj.vlcusto = Convert.ToDouble(vlcusto);
                            //totalcusto = Convert.ToInt32(row.Cells[4].Value);
                            //obj.total = totalcusto;
                            string vlvenda = String.Format("{0:N4}", Convert.ToDecimal(row.Cells[7].Value), 4);
                            obj.vlvenda = Convert.ToDecimal(vlvenda);
                            string vltotal = String.Format("{0:N2}", Convert.ToDecimal(row.Cells[8].Value), 2);
                            obj.vltotal = Convert.ToDecimal(vltotal);
                            if (row.Cells[18].Value.ToString() == "")
                            {
                                row.Cells[18].Value = "0,00";
                            }
                            string munit = String.Format("{0:N4}", Convert.ToDecimal(row.Cells[7].Value), 4);
                            obj.minimounit = Convert.ToDecimal(munit);
                            if (row.Cells[19].Value.ToString() == "")
                            {
                                row.Cells[19].Value = "0,00";
                            }
                            string mintot = String.Format("{0:N2}", Convert.ToDecimal(row.Cells[8].Value), 2);
                            obj.minimototal = Convert.ToDecimal(obj.minimounit * obj.qtde);

                            casas = 4;

                        }

                        obj.idusu = Banco.idusu;


                        totalcusto = Convert.ToInt32(row.Cells[5].Value);
                        obj.total = totalcusto;

                        obj.idunidade = Convert.ToInt32(row.Cells[12].Value);
                        obj.idmarca = Convert.ToInt32(row.Cells[13].Value);
                        // string mgfinal = "0,00";
                        obj.margemfinal = Convert.ToDecimal(row.Cells[6].Value);
                        //string tt = "0,00";
                        obj.total = Convert.ToDouble(row.Cells[8].Value);
                        obj.entrada = Convert.ToDecimal(row.Cells[7].Value);
                        obj.totalg = Convert.ToDecimal(row.Cells[8].Value);
                        obj.obs = "";
                        obj.idproposta = Convert.ToInt32(row.Cells[14].Value);
                        obj.aditivo = 0;
                        obj.vladitivo = 0;
                        obj.statusitem = "";
                        obj.imprimir = "SIM";
                        obj.dtrealinhamento = DateTime.Now.ToString("dd/MM/yyyy");
                        obj.idproduto = Convert.ToInt32(row.Cells[17].Value);
                        obj.idedital = Convert.ToInt32(cbolicitacao.SelectedValue);
                        obj.edital = Convert.ToString(row.Cells[20].Value);
                        obj.ganhou = "NAO";




                        codret = col9;

                        if (VerificaRegistroExiste(codret) == true)
                        {

                            SalvarDados();

                        }
                        else
                        {


                            AlterarDados();


                        }
                    }
                    else
                    {
                        row.Cells["chkb"].Value = false;
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
        private void GravaRealinhamentoProposta()
        {

            try


            {

                foreach (DataGridViewRow row in griditens.Rows)
                {


                    if (Convert.ToBoolean(row.Cells["chkb"].EditedFormattedValue) == true)
                    {
                        double totalcusto = 0;
                        int col9 = Convert.ToInt32(row.Cells[9].Value);

                        VlRealinhamento obj = new VlRealinhamento();
                        obj.iditemedital = Convert.ToInt32(row.Cells[9].Value);
                        obj.qtde = Convert.ToInt32(row.Cells[4].Value);
                        if (rbt2casas.Checked == true)
                        {
                            string vlcusto = String.Format("{0:N2}", Convert.ToDecimal(row.Cells[5].Value), 2);
                            obj.vlcusto = Convert.ToDouble(vlcusto);
                            totalcusto = Convert.ToInt32(row.Cells[4].Value);
                            obj.total = totalcusto;
                            string vlvenda = String.Format("{0:N2}", Convert.ToDecimal(row.Cells[7].Value), 2);
                            obj.vlvenda = Convert.ToDecimal(vlvenda);
                            string vltotal = String.Format("{0:N2}", Convert.ToDecimal(row.Cells[8].Value), 2);
                            obj.vltotal = Convert.ToDecimal(vltotal);
                            if (row.Cells[18].Value.ToString() == "")
                            {
                                row.Cells[18].Value = "0,00";
                            }
                            string munit = String.Format("{0:N2}", Convert.ToDecimal(row.Cells[7].Value), 2);
                            obj.minimounit = Convert.ToDecimal(munit);
                            if (row.Cells[19].Value.ToString() == "")
                            {
                                row.Cells[19].Value = "0,00";
                            }
                            string mintot = String.Format("{0:N2}", Convert.ToDecimal(row.Cells[8].Value), 2);
                            obj.minimototal = Convert.ToDecimal(mintot);

                            casas = 2;




                        }
                        else if (rbt3casas.Checked == true)
                        {
                            string vlcusto = String.Format("{0:N3}", Convert.ToDecimal(row.Cells[5].Value), 3);
                            obj.vlcusto = Convert.ToDouble(vlcusto);
                            totalcusto = Convert.ToInt32(row.Cells[4].Value);
                            obj.total = totalcusto;

                            string vlvenda = String.Format("{0:N3}", Convert.ToDecimal(row.Cells[7].Value), 3);
                            obj.vlvenda = Convert.ToDecimal(vlvenda);
                            string vltotal = String.Format("{0:N2}", Convert.ToDecimal(row.Cells[8].Value), 3);
                            obj.vltotal = Convert.ToDecimal(vltotal);
                            if (row.Cells[18].Value.ToString() == "")
                            {
                                row.Cells[18].Value = "0,00";
                            }
                            string munit = String.Format("{0:N3}", Convert.ToDecimal(row.Cells[7].Value), 3);
                            obj.minimounit = Convert.ToDecimal(munit);
                            if (row.Cells[19].Value.ToString() == "")
                            {
                                row.Cells[19].Value = "0,00";
                            }
                            string mintot = String.Format("{0:N2}", Convert.ToDecimal(row.Cells[8].Value), 3);
                            obj.minimototal = Convert.ToDecimal(mintot);

                            casas = 3;

                        }
                        else if (rbt4casas.Checked == true)
                        {
                            string vlcusto = String.Format("{0:N4}", Convert.ToDecimal(row.Cells[5].Value), 4);
                            obj.vlcusto = Convert.ToDouble(vlcusto);
                            totalcusto = Convert.ToInt32(row.Cells[4].Value);
                            obj.total = totalcusto;
                            string vlvenda = String.Format("{0:N4}", Convert.ToDecimal(row.Cells[7].Value), 4);
                            obj.vlvenda = Convert.ToDecimal(vlvenda);
                            string vltotal = String.Format("{0:N2}", Convert.ToDecimal(row.Cells[8].Value), 2);
                            obj.vltotal = Convert.ToDecimal(vltotal);
                            if (row.Cells[18].Value.ToString() == "")
                            {
                                row.Cells[18].Value = "0,00";
                            }
                            string munit = String.Format("{0:N4}", Convert.ToDecimal(row.Cells[7].Value), 4);
                            obj.minimounit = Convert.ToDecimal(munit);
                            if (row.Cells[19].Value.ToString() == "")
                            {
                                row.Cells[19].Value = "0,00";
                            }
                            string mintot = String.Format("{0:N2}", Convert.ToDecimal(row.Cells[8].Value), 2);
                            obj.minimototal = Convert.ToDecimal(obj.minimounit * obj.qtde);

                            casas = 4;

                        }

                        obj.idusu = Banco.idusu;


                        totalcusto = Convert.ToDouble(row.Cells[4].Value.ToString());
                        obj.total = totalcusto;

                        obj.idunidade = Convert.ToInt32(row.Cells[12].Value);
                        obj.idmarca = Convert.ToInt32(row.Cells[13].Value);
                        // string mgfinal = "0,00";
                        obj.margemfinal = Convert.ToDecimal(row.Cells[6].Value);
                        //string tt = "0,00";
                        obj.total = Convert.ToDouble(row.Cells[8].Value);
                        obj.entrada = Convert.ToDecimal(row.Cells[7].Value);
                        obj.totalg = Convert.ToDecimal(row.Cells[8].Value);
                        obj.obs = "";
                        obj.idproposta = Convert.ToInt32(row.Cells[14].Value);
                        obj.aditivo = 0;
                        obj.vladitivo = 0;
                        obj.statusitem = "";
                        obj.imprimir = "SIM";
                        obj.dtrealinhamento = DateTime.Now.ToString("dd/MM/yyyy");
                        obj.idproduto = Convert.ToInt32(row.Cells[17].Value);
                        obj.idedital = Convert.ToInt32(cbolicitacao.SelectedValue);
                        obj.edital = Convert.ToString(row.Cells[20].Value);
                        obj.ganhou = "NAO";




                        codret = col9;

                        if (VerificaRegistroExiste(codret) == true)
                        {


                            GravaRealinhamento(obj.iditemedital, obj.qtde, obj.vlcusto, obj.vlvenda, obj.idunidade, obj.vltotal, obj.idmarca, obj.margemfinal, obj.total, obj.entrada, obj.totalg, obj.minimounit, obj.minimototal,
            obj.obs, obj.idproposta, obj.aditivo, obj.vladitivo, obj.imprimir, obj.dtrealinhamento, obj.idproduto, obj.edital, obj.idedital, obj.ganhou);
                        }
                        else
                        {



                            GravaRealinhamento(obj.iditemedital, obj.qtde, obj.vlcusto, obj.vlvenda, obj.idunidade, obj.vltotal, obj.idmarca, obj.margemfinal, obj.total, obj.entrada, obj.totalg, obj.minimounit, obj.minimototal,
            obj.obs, obj.idproposta, obj.aditivo, obj.vladitivo, obj.imprimir, obj.dtrealinhamento, obj.idproduto, obj.edital, obj.idedital, obj.ganhou);

                        }
                    }
                    else
                    {
                        row.Cells["chkb"].Value = false;
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


        private void GravaPrecoMinino()
        {

            try


            {

                foreach (DataGridViewRow row in griditens.Rows)
                {


                    if (Convert.ToBoolean(row.Cells["chkb"].EditedFormattedValue) == true)
                    {
                        decimal totalcusto = 0;
                        int col9 = Convert.ToInt32(row.Cells[9].Value);

                        VlRealinhamento obj = new VlRealinhamento();
                        obj.iditemedital = Convert.ToInt32(row.Cells[9].Value);
                        obj.qtde = Convert.ToInt32(row.Cells[4].Value);
                        if (rbt2casas.Checked == true)
                        {
                            string vlcusto = (row.Cells[5].Value.ToString());
                            obj.vlcusto = Convert.ToDouble(vlcusto);
                            obj.total = Convert.ToDouble(obj.vlcusto * Convert.ToInt32(row.Cells[4].Value));
                            string vlvenda = String.Format("{0:N2}", Convert.ToDecimal(row.Cells[7].Value), 2);
                            obj.vlvenda = Convert.ToDecimal(vlvenda);
                            string vltotal = String.Format("{0:N2}", Convert.ToDecimal(row.Cells[8].Value), 2);
                            obj.vltotal = Convert.ToDecimal(vltotal);
                            if (row.Cells[18].Value.ToString() == "")
                            {
                                row.Cells[18].Value = "0,00";
                            }
                            string munit = String.Format("{0:N2}", Convert.ToDecimal(row.Cells[18].Value), 2);
                            obj.minimounit = Convert.ToDecimal(munit);
                            if (row.Cells[19].Value.ToString() == "")
                            {
                                row.Cells[19].Value = "0,00";
                            }
                            string mintot = String.Format("{0:N2}", Convert.ToDecimal(row.Cells[19].Value), 2);
                            obj.minimototal = Convert.ToDecimal(mintot);

                            casas = 2;




                        }
                        else if (rbt3casas.Checked == true)
                        {
                            string vlcusto = (row.Cells[5].Value.ToString());
                            obj.vlcusto = Convert.ToDouble(vlcusto);
                            obj.total = Convert.ToDouble(obj.vlcusto * Convert.ToInt32(row.Cells[4].Value));
                            string vlvenda = String.Format("{0:N3}", Convert.ToDecimal(row.Cells[7].Value), 3);
                            obj.vlvenda = Convert.ToDecimal(vlvenda);
                            string vltotal = String.Format("{0:N2}", Convert.ToDecimal(row.Cells[8].Value), 3);
                            obj.vltotal = Convert.ToDecimal(vltotal);
                            if (row.Cells[18].Value.ToString() == "")
                            {
                                row.Cells[18].Value = "0,00";
                            }
                            string munit = String.Format("{0:N3}", Convert.ToDecimal(row.Cells[18].Value), 3);
                            obj.minimounit = Convert.ToDecimal(munit);
                            if (row.Cells[19].Value.ToString() == "")
                            {
                                row.Cells[19].Value = "0,00";
                            }
                            string mintot = String.Format("{0:N2}", Convert.ToDecimal(row.Cells[19].Value), 3);
                            obj.minimototal = Convert.ToDecimal(mintot);

                            casas = 3;

                        }
                        else if (rbt4casas.Checked == true)
                        {
                            string vlcusto = (row.Cells[5].Value.ToString());
                            obj.vlcusto = Convert.ToDouble(vlcusto);
                            obj.total = Convert.ToDouble(obj.vlcusto * Convert.ToInt32(row.Cells[4].Value));
                            string vlvenda = String.Format("{0:N4}", Convert.ToDecimal(row.Cells[7].Value), 4);
                            obj.vlvenda = Convert.ToDecimal(vlvenda);
                            string vltotal = String.Format("{0:N2}", Convert.ToDecimal(row.Cells[8].Value), 2);
                            obj.vltotal = Convert.ToDecimal(vltotal);
                            if (row.Cells[18].Value.ToString() == "")
                            {
                                row.Cells[18].Value = "0,00";
                            }
                            string munit = String.Format("{0:N4}", Convert.ToDecimal(row.Cells[18].Value), 4);
                            obj.minimounit = Convert.ToDecimal(munit);
                            if (row.Cells[19].Value.ToString() == "")
                            {
                                row.Cells[19].Value = "0,00";
                            }
                            string mintot = String.Format("{0:N2}", Convert.ToDecimal(row.Cells[19].Value), 2);
                            obj.minimototal = Convert.ToDecimal(obj.minimounit * obj.qtde);

                            casas = 4;

                        }

                        obj.idusu = Banco.idusu;

                        obj.idunidade = Convert.ToInt32(row.Cells[12].Value);
                        obj.idmarca = Convert.ToInt32(row.Cells[13].Value);
                        // string mgfinal = "0,00";
                        obj.margemfinal = Convert.ToDecimal(row.Cells[6].Value);
                        //string tt = "0,00";
                        string ent = "0,00";
                        obj.entrada = Convert.ToDecimal(ent);
                        string ttg = "0,00";
                        obj.totalg = Convert.ToDecimal(ttg);

                        obj.obs = "";
                        obj.idproposta = Convert.ToInt32(row.Cells[14].Value);
                        obj.aditivo = 0;
                        obj.vladitivo = 0;
                        obj.statusitem = "";
                        obj.imprimir = "SIM";
                        obj.dtrealinhamento = DateTime.Now.ToString("dd/MM/yyyy");
                        obj.idproduto = Convert.ToInt32(row.Cells[17].Value);
                        obj.idedital = Convert.ToInt32(cbolicitacao.SelectedValue);
                        obj.edital = Convert.ToString(row.Cells[20].Value);








                        codret = col9;

                        if (VerificaRegistroExiste(codret) == true)
                        {

                            SalvarDados();
                            GravaRealinhamento(obj.iditemedital, obj.qtde, obj.vlcusto, obj.vlvenda, obj.idunidade, obj.vltotal, obj.idmarca, obj.margemfinal, obj.total, obj.entrada, obj.totalg, obj.minimounit, obj.minimototal,
            obj.obs, obj.idproposta, obj.aditivo, obj.vladitivo, obj.imprimir, obj.dtrealinhamento, obj.idproduto, obj.edital, obj.idedital, obj.ganhou);
                        }
                        else
                        {


                            AlterarDados();
                            GravaRealinhamento(obj.iditemedital, obj.qtde, obj.vlcusto, obj.vlvenda, obj.idunidade, obj.vltotal, obj.idmarca, obj.margemfinal, obj.total, obj.entrada, obj.totalg, obj.minimounit, obj.minimototal,
            obj.obs, obj.idproposta, obj.aditivo, obj.vladitivo, obj.imprimir, obj.dtrealinhamento, obj.idproduto, obj.edital, obj.idedital, obj.ganhou);

                        }
                    }
                    else
                    {
                        row.Cells["chkb"].Value = false;
                    }
                }
            }
            catch (Exception erro)
            {

                throw erro;
            }

            //  AlteraStatusLicitacao();
            //carregarGridItens();


        }


        private void AlteraStatusLicitacao()
        {


            VlLancEdital obj = new VlLancEdital();


            obj.nlicitacao = Convert.ToString(cbolicitacao.SelectedValue);
            obj.statuslicitacao = 5;
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
            string obter = ("Select * From Proposta Where iditemedital = " + cod + "");
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
            try
            {
                foreach (DataGridViewRow row in griditens.Rows)
                {

                    if (bool.Parse(row.Cells[10].EditedFormattedValue.ToString()) == true)
                    {
                        int col9 = Convert.ToInt32(row.Cells[9].Value);
                        string col2 = Convert.ToString(row.Cells[2].Value);
                        string col3 = Convert.ToString(row.Cells[3].Value);
                        decimal col6 = Convert.ToDecimal(row.Cells[6].Value);
                        decimal col7 = Convert.ToDecimal(row.Cells[7].Value);
                        decimal col18 = Convert.ToDecimal(row.Cells[18].Value);
                        decimal col19 = Convert.ToDecimal(row.Cells[19].Value);
                        string edital = Convert.ToString(row.Cells[20].Value);
                        int idedital = Convert.ToInt32(cbolicitacao.SelectedValue);
                        if (rbt2casas.Checked == true)
                        {
                            casas = 2;
                        }
                        else if (rbt3casas.Checked == true)
                        {
                            casas = 3;
                        }
                        else if (rbt4casas.Checked == true)
                        {
                            casas = 4;
                        }


                        SqlConnection Cnn = Banco.CriarConexao();

                        string insert = "INSERT INTO Proposta(iditemedital,selecionado,cotado,idusu,ganho,margemfinal,precovenda,casasdecimais,precominimo,minimototal,idedital) VALUES (@iditemedital,@selecionado,@cotado,@idusu,@ganho,@margemfinal,@VendaPreco,@casasdecimais,@precominimo,@minimototal,@idedital)";

                        SqlCommand cmd = new SqlCommand(insert, Cnn);
                        cmd.Parameters.AddWithValue("@iditemedital", col9);
                        cmd.Parameters.AddWithValue("@selecionado", col2);
                        cmd.Parameters.AddWithValue("@cotado", col3);
                        cmd.Parameters.AddWithValue("@idusu", Banco.idusu);
                        cmd.Parameters.AddWithValue("@ganho", 1);
                        cmd.Parameters.AddWithValue("@margemfinal", col6);
                        cmd.Parameters.AddWithValue("@presovenda", col7);
                        cmd.Parameters.AddWithValue("@casasdecimais", casas);
                        cmd.Parameters.AddWithValue("@idfornecedor", 0);
                        cmd.Parameters.AddWithValue("@edital", edital);
                        cmd.Parameters.AddWithValue("@precominimo", col18);
                        cmd.Parameters.AddWithValue("@minimototal", col19);
                        cmd.Parameters.AddWithValue("@idedital", idedital);
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

        public void AlterarDados()
        {
            try
            {
                foreach (DataGridViewRow row in griditens.Rows)
                {

                    if (bool.Parse(row.Cells[10].EditedFormattedValue.ToString()) == true)
                    {


                        decimal totalcusto = 0;

                        int col9 = Convert.ToInt32(row.Cells[9].Value);
                        string col2 = Convert.ToString(row.Cells[2].Value);
                        string col3 = Convert.ToString(row.Cells[3].Value);
                        decimal col6 = Convert.ToDecimal(row.Cells[6].Value);
                        decimal col7 = Convert.ToDecimal(row.Cells[7].Value);
                        decimal precominimo = Convert.ToDecimal(row.Cells[18].Value);
                        decimal minimototal = Convert.ToDecimal(row.Cells[19].Value);
                        string edital = Convert.ToString(row.Cells[20].Value);
                        int idedital = Convert.ToInt32(cbolicitacao.SelectedValue);
                        if (rbt2casas.Checked == true)
                        {
                            string vlvenda = String.Format("{0:N2}", Convert.ToDecimal(row.Cells[7].Value), 2);
                            vlvenda.Replace(",", ".");
                            col7 = Convert.ToDecimal(vlvenda);

                            if (row.Cells[18].Value.ToString() == "")
                            {
                                row.Cells[18].Value = "0,00";
                            }
                            string munit = String.Format("{0:N2}", Convert.ToDecimal(row.Cells[18].Value), 2);
                            precominimo = Convert.ToDecimal(munit);
                            if (row.Cells[19].Value.ToString() == "")
                            {
                                row.Cells[19].Value = "0,00";
                            }
                            string mintot = String.Format("{0:N2}", Convert.ToDecimal(row.Cells[19].Value), 2);
                            minimototal = Convert.ToDecimal(mintot);

                            casas = 2;
                        }
                        else if (rbt3casas.Checked == true)
                        {


                            string vlvenda = String.Format("{0:N3}", Convert.ToDecimal(row.Cells[7].Value), 3);
                            vlvenda.Replace(",", ".");
                            col7 = Math.Round(Convert.ToDecimal(vlvenda), 3);


                            if (row.Cells[18].Value.ToString() == "")
                            {
                                row.Cells[18].Value = "0,00";
                            }
                            string munit = String.Format("{0:N3}", Convert.ToDecimal(row.Cells[18].Value), 3);
                            precominimo = Math.Round(Convert.ToDecimal(munit), 3);
                            if (row.Cells[19].Value.ToString() == "")
                            {
                                row.Cells[19].Value = "0,00";
                            }
                            string mintot = String.Format("{0:N2}", Convert.ToDecimal(row.Cells[19].Value), 2);
                            minimototal = Convert.ToDecimal(mintot);

                            casas = 3;
                        }
                        else if (rbt4casas.Checked == true)
                        {
                            string vlvenda = String.Format("{0:N4}", Convert.ToDecimal(row.Cells[7].Value), 4);
                            vlvenda.Replace(",", ".");
                            col7 = Math.Round(Convert.ToDecimal(vlvenda), 4);

                            if (row.Cells[18].Value.ToString() == "")
                            {
                                row.Cells[18].Value = "0,00";
                            }
                            string munit = String.Format("{0:N4}", Convert.ToDecimal(row.Cells[18].Value), 4);
                            precominimo = Math.Round(Convert.ToDecimal(munit), 4);
                            if (row.Cells[19].Value.ToString() == "")
                            {
                                row.Cells[19].Value = "0,00";
                            }
                            string mintot = String.Format("{0:N2}", Convert.ToDecimal(row.Cells[19].Value), 2);
                            minimototal = Convert.ToDecimal(mintot);

                            casas = 4;
                        }


                        SqlConnection Cnn = Banco.CriarConexao();

                        string update = "UPDATE Proposta SET selecionado=@selecionado,cotado=@cotado,idusu=@idusu,ganho=@ganho,margemfinal=@margemfinal,precovenda=@precovenda," +
                            "casasdecimais=@casasdecimais,precominimo=@precominimo,minimototal=@minimototal,edital=@edital,idedital=@idedital WHERE iditemedital=@iditemedital";

                        SqlCommand cmd = new SqlCommand(update, Cnn);
                        cmd.Parameters.AddWithValue("@iditemedital", col9);
                        cmd.Parameters.AddWithValue("@selecionado", col2);
                        cmd.Parameters.AddWithValue("@cotado", col3);
                        cmd.Parameters.AddWithValue("@idusu", Banco.idusu);
                        cmd.Parameters.AddWithValue("@ganho", 2);
                        cmd.Parameters.AddWithValue("@margemfinal", col6);
                        cmd.Parameters.AddWithValue("@precovenda", col7);
                        cmd.Parameters.AddWithValue("@casasdecimais", casas);
                        cmd.Parameters.AddWithValue("@precominimo", precominimo);
                        cmd.Parameters.AddWithValue("@minimototal", minimototal);
                        cmd.Parameters.AddWithValue("@edital", edital);
                        cmd.Parameters.AddWithValue("@idedital", idedital);
                        Cnn.Open();
                        cmd.ExecuteNonQuery();
                        Cnn.Close();

                        //AlterarDadosRetornoCotacao(casas, idedital, col9);

                    }

                }

                //MessageBox.Show("Dados Alterados com sucesso !!", "Inclusão", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                ex.Message.ToString();
            }

        }
        public void AlterarDadosRetornoCotacao(int casasdecimais, int idedital, int iditemedital)
        {
            try
            {

                SqlConnection Cnn = Banco.CriarConexao();

                string update = "UPDATE RetCotacao SET casasdecimais=@casasdecimais,idusu=@idusu WHERE iditemedital=@iditemedital and idedital=@idedital";

                SqlCommand cmd = new SqlCommand(update, Cnn);
                cmd.Parameters.AddWithValue("@iditemedital", iditemedital);
                cmd.Parameters.AddWithValue("@idedital", idedital);
                cmd.Parameters.AddWithValue("@casasdecimais", casasdecimais);
                cmd.Parameters.AddWithValue("@idusu", Banco.idusu);


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




        public int codlic;
        public string totalgeral;
        private void BtnImprimirProposta_Click(object sender, EventArgs e)
        {
            codlic = Convert.ToInt32(cbolicitacao.SelectedValue);
            totalgeral = labTotal.Text;

            RelProposta proposta = new RelProposta(this);
            proposta.Show();
        }

        private void btnPesquisar_Click(object sender, EventArgs e)
        {
            ConsGerarCotacao frmconv = new ConsGerarCotacao(this);
            this.Close();
            frmconv.Show();
        }


        private Boolean VerificaRegistroExisteRealinhada(int cod)
        {

            SqlConnection Cnn = Banco.CriarConexao();
            string obter = ("Select * From RealinhamentoProposta Where iditemedital = " + cod + "");
            SqlCommand sql = new SqlCommand(obter, Cnn);
            Cnn.Open();
            SqlDataReader dr = sql.ExecuteReader();
            if (dr.Read())
            {

                return false;
            }
            return true;
        }

        private void button7_Click(object sender, EventArgs e)
        {
            GravaRealinhamentoProposta();
        }

        public void GravaRealinhamento(int iditemedital, int qtde, double vlcusto, decimal vlvenda, int idunidade, decimal vltotal, int idmarca, decimal margemfinal, double total, decimal entrada, decimal totalg, decimal minimounit, decimal minimototal,
            string obs, int idproposta, int aditivo, decimal vladitivo, string imprimir, string dtrealinhamento, int idproduto, string edital, int idedital, string ganho)
        {

            if (rbt2casas.Checked == true || rbt4casas.Checked == true || rbt3casas.Checked == true)
            {


                VlRealinhamento obj = new VlRealinhamento();
                decimal totalcusto = 0;
                obj.iditemedital = iditemedital;
                obj.qtde = qtde;
                if (rbt2casas.Checked == true)
                {

                    double vlc = vlcusto;
                    obj.vlcusto = Convert.ToDouble(vlc);
                    double totcusto = Convert.ToDouble(obj.vlcusto * qtde);
                    obj.total = Math.Round(totcusto, 2);
                    string vlv = String.Format("{0:N2}", Convert.ToDecimal(vlvenda), 2);
                    obj.vlvenda = Convert.ToDecimal(vlv);
                    string vltota = String.Format("{0:N2}", Convert.ToDecimal(total), 2);
                    obj.vltotal = Convert.ToDecimal(vltota);
                    string munit = String.Format("{0:N2}", Convert.ToDecimal(minimounit), 2);
                    obj.minimounit = Convert.ToDecimal(munit);
                    string mintot = String.Format("{0:N2}", Convert.ToDecimal(minimototal), 2);
                    obj.minimototal = Convert.ToDecimal(mintot);




                }
                else if (rbt3casas.Checked == true)
                {
                    double vlc = vlcusto;
                    obj.vlcusto = Convert.ToDouble(vlc);
                    double totcusto = Convert.ToDouble(obj.vlcusto * qtde);
                    obj.total = Math.Round(totcusto, 3);
                    string vlv = String.Format("{0:N3}", Convert.ToDecimal(vlvenda), 3);
                    obj.vlvenda = Convert.ToDecimal(vlv);
                    //string vltota = String.Format("{0:N3}", Convert.ToDecimal(total), 3);
                    //obj.vltotal = Convert.ToDecimal(vltotal);
                    string munit = String.Format("{0:N3}", Convert.ToDecimal(minimounit), 3);
                    obj.minimounit = Convert.ToDecimal(munit);
                    //string mintot = String.Format("{0:N3}", Convert.ToDecimal(minimototal), 3);
                    //obj.minimototal = Convert.ToDecimal(mintot);


                }
                else if (rbt4casas.Checked == true)
                {
                    double vlc = vlcusto;
                    obj.vlcusto = Convert.ToDouble(vlc);
                    double totcusto = Convert.ToDouble(obj.vlcusto * qtde);
                    obj.total = Math.Round(totcusto, 4);
                    string vlv = String.Format("{0:N4}", Convert.ToDecimal(vlvenda), 4);
                    obj.vlvenda = Convert.ToDecimal(vlv);
                    //string vltota = String.Format("{0:N4}", Convert.ToDecimal(total), 4);
                    //obj.vltotal = Convert.ToDecimal(vltotal);
                    string munit = String.Format("{0:N4}", Convert.ToDecimal(minimounit), 4);
                    obj.minimounit = Convert.ToDecimal(munit);
                    //string mintot = String.Format("{0:N4}", Convert.ToDecimal(minimototal), 4);
                    //obj.minimototal = Convert.ToDecimal(mintot);

                }

                obj.idusu = Banco.idusu;

                obj.idunidade = Convert.ToInt32(idunidade);
                obj.idmarca = Convert.ToInt32(idmarca);
                // string mgfinal = "0,00";
                obj.margemfinal = Convert.ToDecimal(margemfinal);
                //string tt = "0,00";
                //obj.total = Convert.ToDecimal(tt);

                obj.entrada = Convert.ToDecimal(entrada);
                obj.totalg = Convert.ToDecimal(totalg);

                obj.obs = "";
                obj.idproposta = Convert.ToInt32(idproposta);
                obj.aditivo = 0;
                obj.vladitivo = 0;
                obj.statusitem = "";
                obj.imprimir = "SIM";
                obj.dtrealinhamento = DateTime.Now.ToString("dd/MM/yyyy");
                obj.idproduto = Convert.ToInt32(idproduto);
                obj.edital = edital;
                obj.idedital = Convert.ToInt32(cbolicitacao.SelectedValue);
                obj.ganhou = "SIM";



                try
                {

                    if (VerificaRegistroExisteRealinhada(obj.iditemedital) == true)
                    {


                        PsRealinhamento DAORealinhada = new PsRealinhamento();
                        DAORealinhada.Incluir(obj);
                    }
                    else
                    {



                        PsRealinhamento DAORealinhada = new PsRealinhamento();
                        DAORealinhada.AlterarPelaProposta(obj);

                    }


                }
                catch (Exception erro)
                {

                    throw erro;
                }





                //}
                //MessageBox.Show("Itens(s) Realinhados com Sucesso!");
                ////  carregarGridItens(codfor);
                //// AlteraStatusLicitacao();


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

        private void griditens_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void griditens_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void griditens_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {





            if ((e.RowIndex != -1 && e.ColumnIndex == 6))
            {

                string valida7 = griditens.CurrentRow.Cells[7].Value.ToString();
                if (valida7 == "")
                {
                    griditens.CurrentRow.Cells[7].Value = 0;
                }
                decimal cell7 = Convert.ToDecimal(griditens.CurrentRow.Cells[7].Value);
                decimal cell4 = Convert.ToDecimal(griditens.CurrentRow.Cells[4].Value);
                //decimal cell8 = Convert.ToDecimal(griditens.CurrentRow.Cells[8].Value);
                decimal cell5 = Convert.ToDecimal(griditens.CurrentRow.Cells[5].Value);
                decimal cell6 = Convert.ToDecimal(griditens.CurrentRow.Cells[6].Value);



                string valida8 = griditens.CurrentRow.Cells[8].Value.ToString();


                if (valida8 == "")
                {
                    griditens.CurrentRow.Cells[8].Value = 0;
                }



                if (cell7.ToString() != "")
                {


                    griditens.CurrentRow.Cells[7].Value = ((cell5 * cell6) / 100 + cell5);
                    cell7 = Convert.ToDecimal(griditens.CurrentRow.Cells[7].Value);
                    decimal precototal = cell7 * cell4;
                    griditens.CurrentRow.Cells[8].Value = precototal;

                    griditens.CurrentRow.Cells[18].Value = griditens.CurrentRow.Cells[7].Value;
                    griditens.CurrentRow.Cells[19].Value = griditens.CurrentRow.Cells[8].Value;

                    // casasDecimais(Convert.ToDecimal(griditens.CurrentRow.Cells[7].Value));






                    valor = 0;

                    foreach (DataGridViewRow linha in griditens.Rows)
                    {
                        if (linha.Cells[8].Value != DBNull.Value && linha.Cells[2].Value.ToString() != "NAO")
                        {

                            valor += Convert.ToDecimal(linha.Cells[8].Value);
                        }

                    }


                    decimal valort = valor;
                    string convertido = String.Format("{0:N2}", Math.Round(valort, 2));
                    labTotal.Text = convertido;

                    // RetornaStatusCasas();

                    griditens.CurrentRow.Cells[18].Value = griditens.CurrentRow.Cells[7].Value;
                    griditens.CurrentRow.Cells[19].Value = griditens.CurrentRow.Cells[8].Value;

                    griditens.CurrentRow.Cells["chkb"].Value = true;

                    GravaProposta();



                }

                // e.SuppressKeyPress = true;
                int iColumn = 6;
                int iRow = griditens.CurrentCell.RowIndex;
                if (iColumn == griditens.ColumnCount)
                {
                    if (griditens.RowCount > (iColumn + iColumn))
                    {
                        griditens.CurrentCell = griditens[iRow, iRow + 1];
                    }
                    else
                    {
                        //focus next control
                    }
                }
                else
                    griditens.CurrentCell = griditens[iColumn, iRow];

            }
            else if ((e.ColumnIndex == 7 && e.RowIndex != -1))
            {

                string valida7 = griditens.CurrentRow.Cells[7].Value.ToString();
                if (valida7 == "")
                {
                    griditens.CurrentRow.Cells[5].Value = 0;
                }

                decimal cell7 = Convert.ToDecimal(griditens.CurrentRow.Cells[7].Value);
                decimal cell4 = Convert.ToDecimal(griditens.CurrentRow.Cells[4].Value);
                decimal cell5 = Convert.ToDecimal(griditens.CurrentRow.Cells[5].Value);



                var lucro = cell7 - cell5;
                var pecentual = (lucro * 100) / cell5;

                griditens.CurrentRow.Cells[6].Value = pecentual;


                decimal precototal = cell7 * cell4;


                griditens.CurrentRow.Cells[8].Value = precototal;

                griditens.CurrentRow.Cells[18].Value = griditens.CurrentRow.Cells[7].Value;
                griditens.CurrentRow.Cells[19].Value = griditens.CurrentRow.Cells[8].Value;

                //casasDecimais(Convert.ToDecimal(griditens.CurrentRow.Cells[6].Value));

                valor = 0;

                foreach (DataGridViewRow linha in griditens.Rows)
                {


                    {

                        valor += Convert.ToDecimal(linha.Cells[8].Value);
                    }

                }



                decimal valort = valor;
                string convertido = String.Format("{0:N2}", Math.Round(valort, 2));
                labTotal.Text = convertido;

                // RetornaStatusCasas();

                griditens.CurrentRow.Cells["chkb"].Value = true;

                GravaProposta();
                int iColumn = 7;
                int iRow = griditens.CurrentCell.RowIndex;
                if (iColumn == griditens.ColumnCount)
                {
                    if (griditens.RowCount > (iColumn + iColumn))
                    {
                        griditens.CurrentCell = griditens[iRow, iRow + 1];
                    }
                    else
                    {
                        //focus next control
                    }
                }
                else
                    griditens.CurrentCell = griditens[iColumn, iRow];


            }


        }

        private void rbt2casas_CheckedChanged(object sender, EventArgs e)
        {

            carregarGridItens2CasasDecimais();
        }
        private void carregarGridItens2CasasDecimais()
        {
            //chkTodos.Checked = false;
            // rbt2casas.Checked = true;

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
                string strConn = "SELECT DISTINCT ItemsLicitacao.nritem , Fornecedor.nome as Fornecedor,CONVERT(varchar(10),ItemsLicitacao.nritem) + ' - ' + Produto.nome + ' - ' + Produto.apresentacao  + ' - ' + Marca.nome as Item," +
             "ItemsLicitacao.qtde as Qtde, VendaPreco.precocusto as Custo,Proposta.margemfinal as MargemFinal,Proposta.precovenda as Venda," +
            "(Proposta.precovenda * ItemsLicitacao.qtde) as Total_Produto,Proposta.selecionado as Selecionado,Proposta.cotado as Cotado,ItemsLicitacao.iditemedital as Cod," +
             "Proposta.ganho as Ganho,UnidadeMedida.idunidade as Unidade,Marca.idmarca as Marca,Proposta.idproposta as idproposta,Decrescimos.vldecrescimo as Dec, Acrescimo.vlacrescimo as Acrescimo," +
             "Produto.idproduto,Proposta.precominimo as Vl_Minimo, Proposta.minimototal as Minimo_Total,Proposta.edital" +
            " From  ItemsLicitacao INNER JOIN Proposta ON ItemsLicitacao.iditemedital = Proposta.iditemedital  INNER JOIN VendaPreco ON ItemsLicitacao.iditemedital = VendaPreco.iditemedital" +
            " LEFT JOIN Decrescimos ON Proposta.idproposta = Decrescimos.idproposta  LEFT JOIN  Produto_Fornecedor ON Proposta.idfornecedor = Produto_Fornecedor.idfornecedor" +
            " LEFT JOIN Acrescimo ON  Proposta.idproposta = Acrescimo.idproposta,UnidadeMedida,Produto,Fornecedor,LancEditais,RetCotacao,Marca" +
             " Where LancEditais.idedital = Proposta.idedital AND " +
             "Produto.idunidade = UnidadeMedida.idunidade AND Produto.idmarca = Marca.idmarca AND VendaPreco.idedital = RetCotacao.idedital AND VendaPreco.iditemedital = RetCotacao.iditemedital  " +
             "and Proposta.idedital = VendaPreco.idedital and Produto.idproduto = ItemsLicitacao.idproduto AND ItemsLicitacao.iditemedital = RetCotacao.iditemedital " +
             "AND Proposta.idfornecedor = Fornecedor.idfornecedor AND ItemsLicitacao.idedital=" + cbolicitacao.SelectedValue + " Order by ItemsLicitacao.nritem";

                SqlDataAdapter da = new SqlDataAdapter(strConn, Conn);
                da.Fill(ds);


            }

            this.griditens.RowsDefaultCellStyle.BackColor = Color.LightBlue;
            this.griditens.AlternatingRowsDefaultCellStyle.BackColor = Color.Azure;

            var column = new DataGridViewComboBoxColumn();
            var cotado = new DataGridViewComboBoxColumn();
            griditens.AutoGenerateColumns = false;
            //exibe os dados no datagridview
            griditens.DataSource = ds;
            griditens.Columns.Clear();

            griditens.Columns.Add("Fornecedor", "Fornecedor");
            griditens.Columns.Add("Item", "Item");



            DataTable data = new DataTable();

            data.Columns.Add(new DataColumn("Value", typeof(string)));
            data.Columns.Add(new DataColumn("Description", typeof(string)));

            data.Rows.Add("SIM", "SIM");
            data.Rows.Add("NAO", "NAO");
            column.DataSource = data;
            column.HeaderText = "Selec ?";
            column.ValueMember = "Value";
            column.DisplayMember = "Description";
            griditens.Columns.Insert(2, column);


            DataTable dtcotado = new DataTable();

            dtcotado.Columns.Add(new DataColumn("Value", typeof(string)));
            dtcotado.Columns.Add(new DataColumn("Description", typeof(string)));

            dtcotado.Rows.Add("SIM", "SIM");
            dtcotado.Rows.Add("NAO", "NAO");
            cotado.DataSource = dtcotado;
            cotado.HeaderText = "Cotado ?";
            cotado.ValueMember = "Value";
            cotado.DisplayMember = "Description";
            griditens.Columns.Insert(3, cotado);


            griditens.Columns.Add("Qtde", "Qtde");
            griditens.Columns.Add("Custo", "Custo");
            griditens.Columns.Add("MargemFinal", "MargemFinal");
            griditens.Columns.Add("Venda", "Venda");
            griditens.Columns.Add("Total_Produto", "Total_Produto");
            griditens.Columns.Add("Cod", "Cod");
            griditens.Columns.Add(chkb);
            chkb.HeaderText = "Sel";
            chkb.Name = "chkb";
            chkb.Width = 30;
            griditens.Columns.Add("Ganho", "Ganho");
            griditens.Columns.Add("Unidade", "Unidade");
            griditens.Columns.Add("Marca", "Marca");
            griditens.Columns.Add("idproposta", "idproposta");
            griditens.Columns.Add("Dec", "Dec");
            griditens.Columns.Add("Acrescimo", "Acrescimo");
            griditens.Columns.Add("idproduto", "idproduto");
            griditens.Columns.Add("Vl_Minimo", "Vl_Minimo");
            griditens.Columns.Add("Minimo_Total", "Minimo_Total");
            griditens.Columns.Add("edital", "edital");

            griditens.Columns[0].Width = 150;
            griditens.Columns[1].Width = 190;
            griditens.Columns[4].Width = 70;
            griditens.Columns[5].Width = 70;
            griditens.Columns[6].Width = 80;
            griditens.Columns[7].Width = 80;
            griditens.Columns[8].Width = 110;
            griditens.Columns[9].Visible = false;
            griditens.Columns[10].Width = 40;
            griditens.Columns[11].Visible = false;
            griditens.Columns[12].Visible = false;
            griditens.Columns[13].Visible = false;
            griditens.Columns[14].Visible = false;
            griditens.Columns[15].Width = 50;
            griditens.Columns[16].Width = 80;
            griditens.Columns[17].Visible = false;
            griditens.Columns[18].Width = 80;
            griditens.Columns[19].Width = 85;
            griditens.Columns[20].Visible = false;

            griditens.Columns[5].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            griditens.Columns[6].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            griditens.Columns[7].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            griditens.Columns[8].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            griditens.Columns[9].DefaultCellStyle.Alignment = DataGridViewContentAlignment.TopCenter;
            griditens.Columns[15].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            griditens.Columns[16].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            griditens.Columns[18].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;

            griditens.Columns[0].DataPropertyName = "Fornecedor";
            griditens.Columns[1].DataPropertyName = "Item";
            griditens.Columns[2].DataPropertyName = "Selecionado";
            griditens.Columns[3].DataPropertyName = "Cotado";
            griditens.Columns[4].DataPropertyName = "Qtde";
            griditens.Columns[5].DataPropertyName = "Custo";
            griditens.Columns[6].DataPropertyName = "MargemFinal";
            griditens.Columns[7].DataPropertyName = "Venda";
            griditens.Columns[8].DataPropertyName = "Total_Produto";
            griditens.Columns[9].DataPropertyName = "Cod";
            griditens.Columns[10].DataPropertyName = "Ganha";
            griditens.Columns[11].DataPropertyName = "Ganho";
            griditens.Columns[12].DataPropertyName = "Unidade";
            griditens.Columns[13].DataPropertyName = "Marca";
            griditens.Columns[14].DataPropertyName = "idproposta";
            griditens.Columns[15].DataPropertyName = "Dec";
            griditens.Columns[16].DataPropertyName = "Acrescimo";
            griditens.Columns[17].DataPropertyName = "idproduto";
            griditens.Columns[18].DataPropertyName = "Vl_Minimo";
            griditens.Columns[19].DataPropertyName = "Minimo_Total";
            griditens.Columns[20].DataPropertyName = "edital";


            if (casascusto == 2)
            {
                griditens.Columns[5].DefaultCellStyle.Format = "n2";
            }
            else if (casascusto == 3)
            {

                griditens.Columns[5].DefaultCellStyle.Format = "n3";

            }
            else if (casascusto == 4)
            {

                griditens.Columns[5].DefaultCellStyle.Format = "n4";

            }
            else if (casascusto == 5)
            {

                griditens.Columns[5].DefaultCellStyle.Format = "n5";

            }
            else if (casascusto == 6)
            {

                griditens.Columns[5].DefaultCellStyle.Format = "n6";

            }

            griditens.Columns[6].DefaultCellStyle.Format = "#.00\\%";
            griditens.Columns[7].DefaultCellStyle.Format = "n2";
            griditens.Columns[8].DefaultCellStyle.Format = "n2";
            griditens.Columns[15].DefaultCellStyle.Format = "#.00\\%";
            griditens.Columns[16].DefaultCellStyle.Format = "#.00\\%";
            griditens.Columns[18].DefaultCellStyle.Format = "n2";
            griditens.Columns[19].DefaultCellStyle.Format = "n2";

            griditens.Columns[4].ReadOnly = true;
            griditens.Columns[5].ReadOnly = true;
            griditens.Columns[14].ReadOnly = true;
            griditens.Columns[15].ReadOnly = true;
            griditens.Columns[16].ReadOnly = true;
            griditens.Columns[12].ReadOnly = true;


            valor = 0;

            foreach (DataGridViewRow linha in griditens.Rows)
            {

                {

                    valor += Convert.ToDecimal(linha.Cells[8].Value);
                }

            }


            decimal valort = valor;
            string convertido = String.Format("{0:N2}", Math.Round(valort, 2));
            labTotal.Text = convertido;



            foreach (DataGridViewRow linha in griditens.Rows)
            {
                if ((linha.Cells[9].Value.ToString() == Convert.ToString(2)))
                {

                    linha.Cells["chkb"].Value = true;


                }

            }


            Int32 total = 0;

            foreach (DataGridViewRow linhatotal in griditens.Rows)
            {
                total = total + 1;
            }

            this.txttotalitens.Text = Convert.ToString(total);




            griditens.Refresh();

            Conn.Close();


        }

        private void rbt4casas_CheckedChanged(object sender, EventArgs e)
        {

            carregarGridItens4CasasDecimais();
        }

        private void carregarGridItens4CasasDecimais()
        {
            //chkTodos.Checked = false;
            //rbt4casas.Checked = true;

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
                string strConn = "SELECT DISTINCT ItemsLicitacao.nritem , Fornecedor.nome as Fornecedor,CONVERT(varchar(10),ItemsLicitacao.nritem) + ' - ' + Produto.nome + ' - ' + Produto.apresentacao  + ' - ' + Marca.nome as Item," +
              "ItemsLicitacao.qtde as Qtde, VendaPreco.precocusto as Custo,Proposta.margemfinal as MargemFinal,Proposta.precovenda as Venda," +
             "(Proposta.precovenda * ItemsLicitacao.qtde) as Total_Produto,Proposta.selecionado as Selecionado,Proposta.cotado as Cotado,ItemsLicitacao.iditemedital as Cod," +
              "Proposta.ganho as Ganho,UnidadeMedida.idunidade as Unidade,Marca.idmarca as Marca,Proposta.idproposta as idproposta,Decrescimos.vldecrescimo as Dec, Acrescimo.vlacrescimo as Acrescimo," +
              "Produto.idproduto,Proposta.precominimo as Vl_Minimo, Proposta.minimototal as Minimo_Total,Proposta.edital" +
             " From  ItemsLicitacao INNER JOIN Proposta ON ItemsLicitacao.iditemedital = Proposta.iditemedital  INNER JOIN VendaPreco ON ItemsLicitacao.iditemedital = VendaPreco.iditemedital" +
             " LEFT JOIN Decrescimos ON Proposta.idproposta = Decrescimos.idproposta  LEFT JOIN  Produto_Fornecedor ON Proposta.idfornecedor = Produto_Fornecedor.idfornecedor" +
             " LEFT JOIN Acrescimo ON  Proposta.idproposta = Acrescimo.idproposta,UnidadeMedida,Produto,Fornecedor,LancEditais,RetCotacao,Marca" +
              " Where LancEditais.idedital = Proposta.idedital AND " +
              "Produto.idunidade = UnidadeMedida.idunidade AND Produto.idmarca = Marca.idmarca AND VendaPreco.idedital = RetCotacao.idedital " +
              "and Proposta.idedital = VendaPreco.idedital and Produto.idproduto = ItemsLicitacao.idproduto AND ItemsLicitacao.iditemedital = RetCotacao.iditemedital " +
              "AND Proposta.idfornecedor = Fornecedor.idfornecedor AND ItemsLicitacao.idedital=" + cbolicitacao.SelectedValue + " Order by ItemsLicitacao.nritem";

                SqlDataAdapter da = new SqlDataAdapter(strConn, Conn);
                da.Fill(ds);


            }

            this.griditens.RowsDefaultCellStyle.BackColor = Color.LightBlue;
            this.griditens.AlternatingRowsDefaultCellStyle.BackColor = Color.Azure;

            var column = new DataGridViewComboBoxColumn();
            var cotado = new DataGridViewComboBoxColumn();
            griditens.AutoGenerateColumns = false;
            //exibe os dados no datagridview
            griditens.DataSource = ds;
            griditens.Columns.Clear();

            griditens.Columns.Add("Fornecedor", "Fornecedor");
            griditens.Columns.Add("Item", "Item");



            DataTable data = new DataTable();

            data.Columns.Add(new DataColumn("Value", typeof(string)));
            data.Columns.Add(new DataColumn("Description", typeof(string)));

            data.Rows.Add("SIM", "SIM");
            data.Rows.Add("NAO", "NAO");
            column.DataSource = data;
            column.HeaderText = "Selec ?";
            column.ValueMember = "Value";
            column.DisplayMember = "Description";
            griditens.Columns.Insert(2, column);


            DataTable dtcotado = new DataTable();

            dtcotado.Columns.Add(new DataColumn("Value", typeof(string)));
            dtcotado.Columns.Add(new DataColumn("Description", typeof(string)));

            dtcotado.Rows.Add("SIM", "SIM");
            dtcotado.Rows.Add("NAO", "NAO");
            cotado.DataSource = dtcotado;
            cotado.HeaderText = "Cotado ?";
            cotado.ValueMember = "Value";
            cotado.DisplayMember = "Description";
            griditens.Columns.Insert(3, cotado);


            griditens.Columns.Add("Qtde", "Qtde");
            griditens.Columns.Add("Custo", "Custo");
            griditens.Columns.Add("MargemFinal", "MargemFinal");
            griditens.Columns.Add("Venda", "Venda");
            griditens.Columns.Add("Total_Produto", "Total_Produto");
            griditens.Columns.Add("Cod", "Cod");
            griditens.Columns.Add(chkb);
            chkb.HeaderText = "Sel";
            chkb.Name = "chkb";
            chkb.Width = 30;
            griditens.Columns.Add("Ganho", "Ganho");
            griditens.Columns.Add("Unidade", "Unidade");
            griditens.Columns.Add("Marca", "Marca");
            griditens.Columns.Add("idproposta", "idproposta");
            griditens.Columns.Add("Dec", "Dec");
            griditens.Columns.Add("Acrescimo", "Acrescimo");
            griditens.Columns.Add("idproduto", "idproduto");
            griditens.Columns.Add("Vl_Minimo", "Vl_Minimo");
            griditens.Columns.Add("Minimo_Total", "Minimo_Total");
            griditens.Columns.Add("edital", "edital");

            griditens.Columns[0].Width = 150;
            griditens.Columns[1].Width = 190;
            griditens.Columns[4].Width = 70;
            griditens.Columns[5].Width = 70;
            griditens.Columns[6].Width = 80;
            griditens.Columns[7].Width = 80;
            griditens.Columns[8].Width = 110;
            griditens.Columns[9].Visible = false;
            griditens.Columns[10].Width = 40;
            griditens.Columns[11].Visible = false;
            griditens.Columns[12].Visible = false;
            griditens.Columns[13].Visible = false;
            griditens.Columns[14].Visible = false;
            griditens.Columns[15].Width = 50;
            griditens.Columns[16].Width = 80;
            griditens.Columns[17].Visible = false;
            griditens.Columns[18].Width = 80;
            griditens.Columns[19].Width = 85;
            griditens.Columns[20].Visible = false;

            griditens.Columns[5].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            griditens.Columns[6].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            griditens.Columns[7].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            griditens.Columns[8].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            griditens.Columns[9].DefaultCellStyle.Alignment = DataGridViewContentAlignment.TopCenter;
            griditens.Columns[15].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            griditens.Columns[16].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            griditens.Columns[18].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            griditens.Columns[19].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;

            griditens.Columns[0].DataPropertyName = "Fornecedor";
            griditens.Columns[1].DataPropertyName = "Item";
            griditens.Columns[2].DataPropertyName = "Selecionado";
            griditens.Columns[3].DataPropertyName = "Cotado";
            griditens.Columns[4].DataPropertyName = "Qtde";
            griditens.Columns[5].DataPropertyName = "Custo";
            griditens.Columns[6].DataPropertyName = "MargemFinal";
            griditens.Columns[7].DataPropertyName = "Venda";
            griditens.Columns[8].DataPropertyName = "Total_Produto";
            griditens.Columns[9].DataPropertyName = "Cod";
            griditens.Columns[10].DataPropertyName = "Ganha";
            griditens.Columns[11].DataPropertyName = "Ganho";
            griditens.Columns[12].DataPropertyName = "Unidade";
            griditens.Columns[13].DataPropertyName = "Marca";
            griditens.Columns[14].DataPropertyName = "idproposta";
            griditens.Columns[15].DataPropertyName = "Dec";
            griditens.Columns[16].DataPropertyName = "Acrescimo";
            griditens.Columns[17].DataPropertyName = "idproduto";
            griditens.Columns[18].DataPropertyName = "Vl_Minimo";
            griditens.Columns[19].DataPropertyName = "Minimo_Total";
            griditens.Columns[20].DataPropertyName = "edital";

            if (casascusto == 2)
            {
                griditens.Columns[5].DefaultCellStyle.Format = "n2";
            }
            else if (casascusto == 3)
            {

                griditens.Columns[5].DefaultCellStyle.Format = "n3";

            }
            else if (casascusto == 4)
            {

                griditens.Columns[5].DefaultCellStyle.Format = "n4";

            }
            else if (casascusto == 5)
            {

                griditens.Columns[5].DefaultCellStyle.Format = "n5";

            }
            else if (casascusto == 6)
            {

                griditens.Columns[5].DefaultCellStyle.Format = "n6";

            }
            griditens.Columns[6].DefaultCellStyle.Format = "#.00\\%";
            griditens.Columns[7].DefaultCellStyle.Format = "n4";
            griditens.Columns[8].DefaultCellStyle.Format = "n2";
            griditens.Columns[15].DefaultCellStyle.Format = "#.00\\%";
            griditens.Columns[16].DefaultCellStyle.Format = "#.00\\%";
            griditens.Columns[18].DefaultCellStyle.Format = "n4";
            griditens.Columns[19].DefaultCellStyle.Format = "n2";

            valor = 0;

            foreach (DataGridViewRow linha in griditens.Rows)
            {
                string cell2 = linha.Cells[2].Value.ToString().Trim();
                if (linha.Cells[8].Value != DBNull.Value && cell2 == "SIM")
                {

                    valor += Convert.ToDecimal(linha.Cells[8].Value);
                }

            }


            decimal valort = valor;
            string convertido = String.Format("{0:N2}", Math.Round(valort, 2));
            labTotal.Text = convertido;



            foreach (DataGridViewRow linha in griditens.Rows)
            {
                if ((linha.Cells[9].Value.ToString() == Convert.ToString(2)))
                {

                    linha.Cells["chkb"].Value = true;


                }

            }


            Int32 total = 0;

            foreach (DataGridViewRow linhatotal in griditens.Rows)
            {
                total = total + 1;
            }

            this.txttotalitens.Text = Convert.ToString(total);





            griditens.Refresh();

            Conn.Close();


        }
        private void carregarGridItens3CasasDecimais()
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
                string strConn = "SELECT DISTINCT ItemsLicitacao.nritem , Fornecedor.nome as Fornecedor,CONVERT(varchar(10),ItemsLicitacao.nritem) + ' - ' + Produto.nome + ' - ' + Produto.apresentacao  + ' - ' + Marca.nome as Item," +
              "ItemsLicitacao.qtde as Qtde, VendaPreco.precocusto as Custo,Proposta.margemfinal as MargemFinal,Proposta.precovenda as Venda," +
             "(Proposta.precovenda * ItemsLicitacao.qtde) as Total_Produto,Proposta.selecionado as Selecionado,Proposta.cotado as Cotado,ItemsLicitacao.iditemedital as Cod," +
              "Proposta.ganho as Ganho,UnidadeMedida.idunidade as Unidade,Marca.idmarca as Marca,Proposta.idproposta as idproposta,Decrescimos.vldecrescimo as Dec, Acrescimo.vlacrescimo as Acrescimo," +
              "Produto.idproduto,Proposta.precominimo as Vl_Minimo, Proposta.minimototal as Minimo_Total,Proposta.edital" +
             " From  ItemsLicitacao INNER JOIN Proposta ON ItemsLicitacao.iditemedital = Proposta.iditemedital  INNER JOIN VendaPreco ON ItemsLicitacao.iditemedital = VendaPreco.iditemedital" +
             " LEFT JOIN Decrescimos ON Proposta.idproposta = Decrescimos.idproposta  LEFT JOIN  Produto_Fornecedor ON Proposta.idfornecedor = Produto_Fornecedor.idfornecedor" +
             " LEFT JOIN Acrescimo ON  Proposta.idproposta = Acrescimo.idproposta,UnidadeMedida,Produto,Fornecedor,LancEditais,RetCotacao,Marca" +
              " Where LancEditais.idedital = Proposta.idedital AND " +
              "Produto.idunidade = UnidadeMedida.idunidade AND Produto.idmarca = Marca.idmarca AND VendaPreco.idedital = RetCotacao.idedital " +
              "and Proposta.idedital = VendaPreco.idedital and Produto.idproduto = ItemsLicitacao.idproduto AND ItemsLicitacao.iditemedital = RetCotacao.iditemedital " +
              "AND Proposta.idfornecedor = Fornecedor.idfornecedor AND ItemsLicitacao.idedital=" + cbolicitacao.SelectedValue + " Order by ItemsLicitacao.nritem";

                SqlDataAdapter da = new SqlDataAdapter(strConn, Conn);
                da.Fill(ds);


            }

            this.griditens.RowsDefaultCellStyle.BackColor = Color.LightBlue;
            this.griditens.AlternatingRowsDefaultCellStyle.BackColor = Color.Azure;

            var column = new DataGridViewComboBoxColumn();
            var cotado = new DataGridViewComboBoxColumn();
            griditens.AutoGenerateColumns = false;
            //exibe os dados no datagridview
            griditens.DataSource = ds;
            griditens.Columns.Clear();

            griditens.Columns.Add("Fornecedor", "Fornecedor");
            griditens.Columns.Add("Item", "Item");



            DataTable data = new DataTable();

            data.Columns.Add(new DataColumn("Value", typeof(string)));
            data.Columns.Add(new DataColumn("Description", typeof(string)));

            data.Rows.Add("SIM", "SIM");
            data.Rows.Add("NAO", "NAO");
            column.DataSource = data;
            column.HeaderText = "Selec ?";
            column.ValueMember = "Value";
            column.DisplayMember = "Description";
            griditens.Columns.Insert(2, column);


            DataTable dtcotado = new DataTable();

            dtcotado.Columns.Add(new DataColumn("Value", typeof(string)));
            dtcotado.Columns.Add(new DataColumn("Description", typeof(string)));

            dtcotado.Rows.Add("SIM", "SIM");
            dtcotado.Rows.Add("NAO", "NAO");
            cotado.DataSource = dtcotado;
            cotado.HeaderText = "Cotado ?";
            cotado.ValueMember = "Value";
            cotado.DisplayMember = "Description";
            griditens.Columns.Insert(3, cotado);


            griditens.Columns.Add("Qtde", "Qtde");
            griditens.Columns.Add("Custo", "Custo");
            griditens.Columns.Add("MargemFinal", "MargemFinal");
            griditens.Columns.Add("Venda", "Venda");
            griditens.Columns.Add("Total_Produto", "Total_Produto");
            griditens.Columns.Add("Cod", "Cod");
            griditens.Columns.Add(chkb);
            chkb.HeaderText = "Sel";
            chkb.Name = "chkb";
            chkb.Width = 30;
            griditens.Columns.Add("Ganho", "Ganho");
            griditens.Columns.Add("Unidade", "Unidade");
            griditens.Columns.Add("Marca", "Marca");
            griditens.Columns.Add("idproposta", "idproposta");
            griditens.Columns.Add("Dec", "Dec");
            griditens.Columns.Add("Acrescimo", "Acrescimo");
            griditens.Columns.Add("idproduto", "idproduto");
            griditens.Columns.Add("Vl_Minimo", "Vl_Minimo");
            griditens.Columns.Add("Minimo_Total", "Minimo_Total");
            griditens.Columns.Add("edital", "edital");

            griditens.Columns[0].Width = 150;
            griditens.Columns[1].Width = 190;
            griditens.Columns[4].Width = 70;
            griditens.Columns[5].Width = 80;
            griditens.Columns[6].Width = 80;
            griditens.Columns[7].Width = 70;
            griditens.Columns[8].Width = 110;
            griditens.Columns[9].Visible = false;
            griditens.Columns[10].Width = 40;
            griditens.Columns[11].Visible = false;
            griditens.Columns[12].Visible = false;
            griditens.Columns[13].Visible = false;
            griditens.Columns[14].Visible = false;
            griditens.Columns[15].Width = 50;
            griditens.Columns[16].Width = 80;
            griditens.Columns[17].Visible = false;
            griditens.Columns[18].Width = 80;
            griditens.Columns[19].Width = 85;
            griditens.Columns[20].Visible = false;


            griditens.Columns[5].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            griditens.Columns[6].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            griditens.Columns[7].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            griditens.Columns[8].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            griditens.Columns[9].DefaultCellStyle.Alignment = DataGridViewContentAlignment.TopCenter;
            griditens.Columns[15].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            griditens.Columns[16].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            griditens.Columns[18].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            griditens.Columns[19].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;

            griditens.Columns[0].DataPropertyName = "Fornecedor";
            griditens.Columns[1].DataPropertyName = "Item";
            griditens.Columns[2].DataPropertyName = "Selecionado";
            griditens.Columns[3].DataPropertyName = "Cotado";
            griditens.Columns[4].DataPropertyName = "Qtde";
            griditens.Columns[5].DataPropertyName = "Custo";
            griditens.Columns[6].DataPropertyName = "MargemFinal";
            griditens.Columns[7].DataPropertyName = "Venda";
            griditens.Columns[8].DataPropertyName = "Total_Produto";
            griditens.Columns[9].DataPropertyName = "Cod";
            griditens.Columns[10].DataPropertyName = "Ganha";
            griditens.Columns[11].DataPropertyName = "Ganho";
            griditens.Columns[12].DataPropertyName = "Unidade";
            griditens.Columns[13].DataPropertyName = "Marca";
            griditens.Columns[14].DataPropertyName = "idproposta";
            griditens.Columns[15].DataPropertyName = "Dec";
            griditens.Columns[16].DataPropertyName = "Acrescimo";
            griditens.Columns[17].DataPropertyName = "idproduto";
            griditens.Columns[18].DataPropertyName = "Vl_Minimo";
            griditens.Columns[19].DataPropertyName = "Minimo_Total";
            griditens.Columns[20].DataPropertyName = "edital";

            if (casascusto == 2)
            {
                griditens.Columns[5].DefaultCellStyle.Format = "n2";
            }
            else if (casascusto == 3)
            {

                griditens.Columns[5].DefaultCellStyle.Format = "n3";

            }
            else if (casascusto == 4)
            {

                griditens.Columns[5].DefaultCellStyle.Format = "n4";

            }
            else if (casascusto == 5)
            {

                griditens.Columns[5].DefaultCellStyle.Format = "n5";

            }
            else if (casascusto == 6)
            {

                griditens.Columns[5].DefaultCellStyle.Format = "n6";

            }
            griditens.Columns[6].DefaultCellStyle.Format = "#.00\\%";
            griditens.Columns[7].DefaultCellStyle.Format = "n3";
            griditens.Columns[8].DefaultCellStyle.Format = "n2";
            griditens.Columns[15].DefaultCellStyle.Format = "#.00\\%";
            griditens.Columns[16].DefaultCellStyle.Format = "#.00\\%";
            griditens.Columns[18].DefaultCellStyle.Format = "n3";
            griditens.Columns[19].DefaultCellStyle.Format = "n2";


            valor = 0;

            foreach (DataGridViewRow linha in griditens.Rows)
            {
                string cell2 = linha.Cells[2].Value.ToString().Trim();
                if (linha.Cells[8].Value != DBNull.Value && cell2 == "SIM")
                {

                    valor += Convert.ToDecimal(linha.Cells[8].Value);
                }

            }


            decimal valort = valor;
            string convertido = String.Format("{0:N2}", Math.Round(valort, 4));
            labTotal.Text = convertido;



            foreach (DataGridViewRow linha in griditens.Rows)
            {
                if ((linha.Cells[9].Value.ToString() == Convert.ToString(2)))
                {

                    linha.Cells["chkb"].Value = true;


                }

            }


            Int32 total = 0;

            foreach (DataGridViewRow linhatotal in griditens.Rows)
            {
                total = total + 1;
            }

            this.txttotalitens.Text = Convert.ToString(total);




            griditens.Refresh();
            Conn.Close();


        }

        private void chkTodos_CheckedChanged(object sender, EventArgs e)
        {
            foreach (DataGridViewRow row in griditens.Rows)
            {
                DataGridViewCheckBoxCell chkb = (DataGridViewCheckBoxCell)row.Cells[10];
                chkb.Value = !(chkb.Value == null ? false : (bool)chkb.Value); //because chk.Value is initialy null
            }
        }

        private void chkTodosSim_CheckedChanged(object sender, EventArgs e)
        {
            if (chkTodosSim.Checked == true)
            {
                chkTodosNao.Checked = false;

                for (int i = 0; i < griditens.RowCount; i++)
                {
                    griditens.Rows[i].Cells[2].Value = "SIM";
                    griditens.Rows[i].Cells[3].Value = "SIM";
                }
                AlterarDados();

            }
            else if (chkTodosSim.Checked == false)
            {
                for (int i = 0; i < griditens.RowCount; i++)
                {
                    griditens.Rows[i].Cells[2].Value = "";
                    griditens.Rows[i].Cells[3].Value = "";
                }
            }


        }

        private void rbt3casas_CheckedChanged(object sender, EventArgs e)
        {

            carregarGridItens3CasasDecimais();
        }

        private void button5_Click(object sender, EventArgs e)
        {

            try

            {

                foreach (DataGridViewRow row in griditens.Rows)
                {

                    if (bool.Parse(row.Cells[10].EditedFormattedValue.ToString()))
                    {

                        Decrescimos decrescimos = new Decrescimos();

                        decrescimos.idproposta = Convert.ToInt32(row.Cells[14].Value);
                        decrescimos.iditemedital = Convert.ToInt32(row.Cells[9].Value);
                        decrescimos.precovenda = Convert.ToDecimal(row.Cells[7].Value);
                        decrescimos.casasdecimais = casas;
                        list.Add(decrescimos);

                    }
                }
                ViewDecrecimo frmdec = new ViewDecrecimo(this);
                frmdec.Show();

            }
            catch (Exception erro)
            {

                throw erro;
            }




        }

        private void ViewProposta_Load(object sender, EventArgs e)
        {
        }

        private void btnAcrescimo_Click(object sender, EventArgs e)
        {
            foreach (DataGridViewRow row in griditens.Rows)
            {

                if (bool.Parse(row.Cells[10].EditedFormattedValue.ToString()) == true)
                {

                    Acrescimo acrescimo = new Acrescimo();
                    acrescimo.idproposta = Convert.ToInt32(row.Cells[14].Value);
                    acrescimo.iditemedital = Convert.ToInt32(row.Cells[9].Value);
                    acrescimo.casasdecimais = casas;


                    decimal porcent = Convert.ToDecimal(txtacrescimo.Text);
                    acrescimo.acrecimo = Convert.ToDecimal(porcent);
                    decimal vlcalculoalmento = Convert.ToDecimal(row.Cells[5].Value);
                    acrescimo.vlinicial = vlcalculoalmento;
                    decimal ac = ((Convert.ToDecimal(row.Cells[5].Value) + (porcent * Convert.ToDecimal(row.Cells[5].Value) / 100)));
                    row.Cells[18].Value = ac;
                    acrescimo.precominimo = Convert.ToDecimal(row.Cells[18].Value);


                    decimal calculaminimototal = Convert.ToDecimal(row.Cells[18].Value) * Convert.ToInt32(row.Cells[4].Value);


                    decimal vlaumentado = ac - vlcalculoalmento;

                    acrescimo.minimototal = calculaminimototal;
                    row.Cells[19].Value = acrescimo.minimototal;

                    if (acrescimo.casasdecimais == 2)
                    {

                        string vldecrescimo = String.Format("{0:N2}", Math.Round(Convert.ToDecimal(ac), 2));
                        acrescimo.precovenda = Convert.ToDecimal(vldecrescimo);

                        string vlcalculado = String.Format("{0:N2}", Math.Round(Convert.ToDecimal(vlaumentado), 2));
                        acrescimo.vlaumentado = Convert.ToDecimal(vlcalculado);





                    }
                    else if (acrescimo.casasdecimais == 3)
                    {
                        string vldecrescimo = String.Format("{0:N3}", (Convert.ToDecimal(ac)));
                        acrescimo.precovenda = Convert.ToDecimal(vldecrescimo);

                        string vlcalculado = String.Format("{0:N3}", Math.Round(Convert.ToDecimal(vlaumentado), 3));
                        acrescimo.vlaumentado = Convert.ToDecimal(vlcalculado);
                    }
                    else if (acrescimo.casasdecimais == 4)
                    {
                        string vldecrescimo = String.Format("{0:N4}", (Convert.ToDecimal(ac)));
                        acrescimo.precovenda = Convert.ToDecimal(vldecrescimo);

                        string vlcalculado = String.Format("{0:N4}", Math.Round(Convert.ToDecimal(vlaumentado), 4));
                        acrescimo.vlaumentado = Convert.ToDecimal(vlcalculado);
                    }

                    try
                    {

                        if (VerificaRegistroExisteAcrescimo(acrescimo.idproposta, acrescimo.iditemedital) == true)
                        {



                            PsAcrecimo DAOAcrescimo = new PsAcrecimo();
                            DAOAcrescimo.Alterar(acrescimo);
                            DAOAcrescimo.Incluir(acrescimo);
                            BuscaValorAcrescimo(nprop, coditems);
                            GravaProposta();
                            //carregarGridItens();
                        }
                        else
                        {

                            PsAcrecimo DAOAcrescimo = new PsAcrecimo();
                            DAOAcrescimo.Alterar(acrescimo);
                            DAOAcrescimo.AlterarAcrescimo(acrescimo);
                            BuscaValorAcrescimo(nprop, coditems);
                            GravaProposta();
                            // carregarGridItens();


                        }



                    }
                    catch (Exception erro)
                    {

                        throw erro;
                    }
                }
            }
        }

        private Boolean VerificaRegistroExisteAcrescimo(int prop, int edt)
        {

            SqlConnection Cnn = Banco.CriarConexao();
            string obter = ("Select * From Acrescimo  Where idproposta = " + prop + " AND iditemedital=" + edt);
            SqlCommand sql = new SqlCommand(obter, Cnn);
            Cnn.Open();
            SqlDataReader dr = sql.ExecuteReader();
            if (dr.Read())
            {

                return false;
            }
            return true;
        }


        private Boolean VerificaRegistroExisteDecrescimo(int prop, int edt)
        {

            SqlConnection Cnn = Banco.CriarConexao();
            string obter = ("Select * From Decrescimos  Where idproposta = " + prop + " AND iditemedital=" + edt);
            SqlCommand sql = new SqlCommand(obter, Cnn);
            Cnn.Open();
            SqlDataReader dr = sql.ExecuteReader();
            if (dr.Read())
            {

                return false;
            }
            return true;
        }




        public List<Decrescimos> listDecrescimos = new List<Decrescimos>();

        private void btnDeecrescimo_Click(object sender, EventArgs e)
        {

            foreach (DataGridViewRow row in griditens.Rows)
            {

                if (bool.Parse(row.Cells[10].EditedFormattedValue.ToString()) == true)
                {

                    // row.Cells[18].Value = 0;
                    //row.Cells[19].Value = 0;

                    Decrescimos decrescimos = new Decrescimos();
                    decrescimos.idproposta = Convert.ToInt32(row.Cells[14].Value);
                    decrescimos.iditemedital = Convert.ToInt32(row.Cells[9].Value);
                    decrescimos.casasdecimais = casas;

                    decimal porcent = Convert.ToDecimal(txtdecrescimo.Text);
                    decrescimos.decrecimo = Convert.ToDecimal(porcent);
                    decimal vlcalculoadiminuido = Convert.ToDecimal(row.Cells[18].Value);
                    decrescimos.vlinicial = vlcalculoadiminuido;
                    decimal dec = ((Convert.ToDecimal(row.Cells[18].Value) - (porcent * Convert.ToDecimal(row.Cells[18].Value) / 100)));
                    decimal vldiminuido = vlcalculoadiminuido - dec;
                    decimal minimototal = decrescimos.vlinicial - vldiminuido;
                    // decrescimos.minimototal = Convert.ToDecimal(row.Cells[18].Value) * Convert.ToInt32(row.Cells[4].Value);



                    if (decrescimos.casasdecimais == 2)
                    {

                        string vldecrescimo = String.Format("{0:N2}", Math.Round(Convert.ToDecimal(dec), 2));
                        decrescimos.precovenda = Convert.ToDecimal(vldecrescimo);
                        row.Cells[18].Value = decrescimos.precovenda;

                        string vlcalculado = String.Format("{0:N2}", Math.Round(Convert.ToDecimal(vldiminuido), 2));
                        decrescimos.vldiminuido = Convert.ToDecimal(vlcalculado);

                        string totalminimo = String.Format("{0:N2}", Math.Round(Convert.ToDecimal(minimototal), 2));
                        decrescimos.minimototal = Convert.ToDecimal(totalminimo) * Convert.ToInt32(row.Cells[4].Value);
                        row.Cells[19].Value = decrescimos.minimototal;






                    }
                    else if (decrescimos.casasdecimais == 3)
                    {
                        string vldecrescimo = String.Format("{0:N3}", (Convert.ToDecimal(dec)));
                        decrescimos.precovenda = Convert.ToDecimal(vldecrescimo);

                        string vlcalculado = String.Format("{0:N3}", Math.Round(Convert.ToDecimal(vldiminuido), 3));
                        decrescimos.vldiminuido = Convert.ToDecimal(vlcalculado);

                        string totalminimo = String.Format("{0:N2}", Math.Round(Convert.ToDecimal(minimototal), 3));
                        decrescimos.minimototal = Convert.ToDecimal(totalminimo) * Convert.ToInt32(row.Cells[4].Value);

                    }
                    else if (decrescimos.casasdecimais == 4)
                    {
                        string vldecrescimo = String.Format("{0:N4}", (Convert.ToDecimal(dec)));
                        decrescimos.precovenda = Convert.ToDecimal(vldecrescimo);

                        string vlcalculado = String.Format("{0:N4}", Math.Round(Convert.ToDecimal(vldiminuido), 4));
                        decrescimos.vldiminuido = Convert.ToDecimal(vlcalculado);

                        string totalminimo = String.Format("{0:N2}", Math.Round(Convert.ToDecimal(minimototal), 4));




                    }

                    try
                    {

                        if (VerificaRegistroExisteDecrescimo(decrescimos.idproposta, decrescimos.iditemedital) == true)
                        {

                            PsDecrescimo DAODecrescimo = new PsDecrescimo();
                            DAODecrescimo.Alterar(decrescimos);
                            DAODecrescimo.Incluir(decrescimos);
                            BuscaValorDecrescimo(nprop, coditems);
                            GravaProposta();
                            //carregarGridItens();

                        }
                        else
                        {
                            PsDecrescimo DAODecrescimo = new PsDecrescimo();
                            DAODecrescimo.Alterar(decrescimos);
                            DAODecrescimo.AlterarDecrescimo(decrescimos);
                            BuscaValorDecrescimo(nprop, coditems);
                            GravaProposta();
                            //carregarGridItens();


                        }
                    }
                    catch (Exception erro)
                    {

                        throw erro;
                    }
                }
            }

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




                    string LICITACAO = @"C:\LICITAÇÃO\";

                    if (!File.Exists(LICITACAO))
                    {

                        Directory.CreateDirectory(LICITACAO);
                    }




                    string folder = LICITACAO + Edittal + " - " + cbocliente.Text; //nome do diretorio a ser criado

                    //Se o diretório não existir...

                    if (!Directory.Exists(folder))
                    {

                        //Criamos um com o nome folder
                        Directory.CreateDirectory(folder);

                    }





                    SqlConnection Cnn = Banco.CriarConexao();
                    string query = "Select arq,extensao,nomearq from DocumentoProduto Where iddocproduto = " + codarquivo;
                    SqlCommand ObjC = new SqlCommand(query, Cnn);
                    Cnn.Open();
                    SqlDataReader dr = ObjC.ExecuteReader();


                    if (dr.Read())
                    {


                        byte[] byteArray = new byte[16 * 1024];
                        byte[] fileData = (byte[])dr["arq"];
                        string filename = dr["nomearq"].ToString();
                        arquivo = dr["nomearq"].ToString();

                        using (FileStream file = new FileStream(LICITACAO + Edittal + " - " + cbocliente.Text + "\\" + filename, FileMode.Create))
                        {

                            file.Write(fileData, 0, fileData.Length);
                            file.Close();
                            dr.Close();
                            Cnn.Close();
                        }




                    }


                }
                else
                {

                    MessageBox.Show("Favor Selecionar os Documentos a serem Extraidos!");
                    return;
                }

            }






            string pastaParaZipar = @"C:\LICITAÇÃO\" + Edittal + " - " + cbocliente.Text;
            string caminhoZip = @"C:\LICITAÇÃO\" + Edittal + " - " + cbocliente.Text + ".zip";



            if (!System.IO.File.Exists(@"C:\LICITAÇÃO\" + Edittal + " - " + cbocliente.Text + ".zip"))
            {


                ZipFile.CreateFromDirectory(pastaParaZipar, caminhoZip);

            }
            else
            {

                File.Delete(@"C:\LICITAÇÃO\" + Edittal + " - " + cbocliente.Text + ".zip");


                ZipFile.CreateFromDirectory(pastaParaZipar, caminhoZip);
            }
            //  File.Delete(@"C:\LICITAÇÃO\" + cbolicitacao.SelectedValue + ".zip");
        }

        private void GravarArquivo()
        {

            foreach (DataGridViewRow row in griditens.Rows)
            {

                if (bool.Parse(row.Cells[10].EditedFormattedValue.ToString()) == true)
                {

                    VlArquivo obj = new VlArquivo();

                    VlArquivo.arq = FileData;
                    obj.nomearq = arquivo;
                    obj.idempresa = Banco.idemp;
                    obj.edital = Edittal;
                    obj.extensao = extensao;
                    obj.dtdocumento = DateTime.Now.ToString("dd/MM/yyyy");
                    obj.idusu = Banco.idusu;
                    obj.iditemedital = Convert.ToInt32(row.Cells[9].Value);
                    obj.idedital = Convert.ToInt32(cbolicitacao.SelectedValue);



                    try
                    {
                        PsArquivos PsArquivosbll = new PsArquivos();
                        PsArquivosbll.Incluir(obj);
                        CarregaGridArquivos(obj.iditemedital);
                        //MessageBox.Show("Registro Incluido com Sucesso!");
                        //Limpacampos();
                        //RetReg();

                    }
                    catch (Exception erro)
                    {

                        throw erro;
                    }
                }
            }
        }

        DataGridViewCheckBoxColumn chka = new DataGridViewCheckBoxColumn();
        private void CarregaGridArquivos(int codiditemedital)
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



                SqlDataAdapter da = new SqlDataAdapter("Select DISTINCT DocumentoProduto.iddocproduto as Cod,DocumentoProduto.nomearq as Documento,DocumentoProduto.iditemedital as iditem" +
                " from DocumentoProduto,Proposta Where Proposta.idedital = DocumentoProduto.idedital AND DocumentoProduto.idedital =" + cbolicitacao.SelectedValue + " AND " +
                "DocumentoProduto.iditemedital=" + codiditemedital + " Order by Documento ASC ", Conn);

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
                Grid.Columns.Add("iditem", "iditem");

                Grid.Columns[0].Width = 50;
                Grid.Columns[1].Visible = false;
                Grid.Columns[2].Width = 245;
                Grid.Columns[3].Visible = false;

                Grid.Columns[1].DataPropertyName = "Cod";
                Grid.Columns[2].DataPropertyName = "Documento";
                Grid.Columns[3].DataPropertyName = "iditem";

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


                if (e.RowIndex >= 0 && e.ColumnIndex == 4)
                {
                    //Loop and uncheck all other CheckBoxes.
                    foreach (DataGridViewRow row in Grid.Rows)
                    {

                        if (row.Index == e.RowIndex)
                        {
                            row.Cells["chka"].Value = !Convert.ToBoolean(row.Cells["chka"].EditedFormattedValue);
                            coda = int.Parse(Grid.Rows[e.RowIndex].Cells[1].Value.ToString());
                            int codi = int.Parse(Grid.Rows[e.RowIndex].Cells[3].Value.ToString());

                            VlArquivo obj = new VlArquivo();

                            obj.iddocproduto = coda;

                            PsArquivos DAOArquivos = new PsArquivos();
                            DAOArquivos.Exluir(obj.iddocproduto);


                            CarregaGridArquivos(codi);
                        }

                        else
                        {
                            row.Cells["chka"].Value = false;
                        }

                    }

                }
            }
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

        private void label9_Click(object sender, EventArgs e)
        {

        }
        int coditems;
        int nprop;
        private void griditens_Click(object sender, EventArgs e)
        {



        }

        private void griditens_CellClick(object sender, DataGridViewCellEventArgs e)
        {



            txtacrescimo.Text = "0";
            txtvlacrecimo.Text = "";
            txtdecrescimo.Text = "0";
            txtvldecrescimo.Text = "";
            coditems = Convert.ToInt32(griditens[9, e.RowIndex].Value.ToString());
            nprop = Convert.ToInt32(griditens[14, e.RowIndex].Value.ToString());
            BuscaValorAcrescimo(nprop, coditems);
            BuscaValorDecrescimo(nprop, coditems);
            RetornaDadosItensEdital(coditems);
            CarregaGridArquivos(coditems);


        }


        private void RetornaDadosItensEdital(int coditem)
        {

            string reg = "Select * From ItemsLicitacao where iditemedital=" + coditem + " ";
            DataTable ds = new DataTable();
            SqlConnection Conn = Banco.CriarConexao();
            Conn.Open();

            if (Conn.State == ConnectionState.Open)
            {
                SqlCommand cmd = new SqlCommand(reg, Conn);
                SqlDataReader dr = cmd.ExecuteReader();
                if (dr.Read())
                {

                    Decimal vlestimado = decimal.Parse(dr["vlestimado"].ToString());
                    string convertvlestimado = String.Format("{0:N2}", vlestimado);
                    this.txtvlestimado.Text = convertvlestimado;

                    Decimal vlestimadototal = decimal.Parse(dr["vltotalestimado"].ToString());
                    string convertvlestimadototal = String.Format("{0:N2}", vlestimadototal);
                    txtvlestimadototal.Text = convertvlestimadototal;


                }
            }


        }

        private void BuscaValorAcrescimo(int prop, int edt)
        {


            SqlConnection Cnn = Banco.CriarConexao();
            string obter = ("Select * From Acrescimo  Where idproposta = " + prop + " AND iditemedital=" + edt);
            SqlCommand sql = new SqlCommand(obter, Cnn);
            Cnn.Open();
            SqlDataReader dr = sql.ExecuteReader();
            if (dr.Read())
            {

                int acre = Convert.ToInt32(dr["vlacrescimo"].ToString());
                txtacrescimo.Text = Convert.ToString(acre);
                string vlacrescimo = String.Format("{0:N2}", Math.Round(Convert.ToDecimal(dr["vlaumentado"].ToString()), 2));
                txtvlacrecimo.Text = vlacrescimo;

            }

        }

        private void BuscaValorDecrescimo(int prop, int edt)
        {


            SqlConnection Cnn = Banco.CriarConexao();
            string obter = ("Select * From Decrescimos  Where idproposta = " + prop + " AND iditemedital=" + edt);
            SqlCommand sql = new SqlCommand(obter, Cnn);
            Cnn.Open();
            SqlDataReader dr = sql.ExecuteReader();
            if (dr.Read())
            {


                int decre = Convert.ToInt32(dr["vldecrescimo"].ToString());
                this.txtdecrescimo.Text = Convert.ToString(decre);
                string vlderescimo = String.Format("{0:N2}", Math.Round(Convert.ToDecimal(dr["vldiminuido"].ToString()), 2));
                this.txtvldecrescimo.Text = vlderescimo;

            }

        }
        decimal vlinicial;
        private void button6_Click(object sender, EventArgs e)
        {

            try
            {
                foreach (DataGridViewRow row in griditens.Rows)
                {

                    if (bool.Parse(row.Cells[10].EditedFormattedValue.ToString()) == true)
                    {
                        int edt = Convert.ToInt32(row.Cells[9].Value);
                        int prop = Convert.ToInt32(row.Cells[14].Value);

                        SqlConnection Cnn = Banco.CriarConexao();
                        string obter = ("Select * From  Decrescimos Where idproposta = " + prop + " AND iditemedital=" + edt);
                        SqlCommand sql = new SqlCommand(obter, Cnn);
                        Cnn.Open();

                        SqlDataReader dr = sql.ExecuteReader();
                        if (dr.Read())
                        {
                            vlinicial = Convert.ToDecimal(dr["vlinicial"].ToString());


                        }


                        VlProposta proposta = new VlProposta();

                        proposta.idproposta = prop;
                        proposta.iditemedital = edt;
                        proposta.precovenda = vlinicial;
                        proposta.precominimo = Convert.ToDecimal(row.Cells[7].Value);
                        proposta.minimototal = Convert.ToDecimal(row.Cells[8].Value);


                        PsDecrescimo DAODescrescimo = new PsDecrescimo();
                        DAODescrescimo.VoltaValorInicial(proposta);
                        DAODescrescimo.Exluir(prop, edt);
                        txtdecrescimo.Text = "0";
                        this.txtvldecrescimo.Text = "";
                        carregarGridItens();

                    }

                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        private void button5_Click_1(object sender, EventArgs e)
        {
            try
            {
                foreach (DataGridViewRow row in griditens.Rows)
                {

                    if (bool.Parse(row.Cells[10].EditedFormattedValue.ToString()) == true)
                    {
                        int edt = Convert.ToInt32(row.Cells[9].Value);
                        int prop = Convert.ToInt32(row.Cells[14].Value);
                        decimal valor = Convert.ToDecimal(row.Cells[7].Value);
                        int idedital = Convert.ToInt32(cbolicitacao.SelectedValue);
                        int qtde = Convert.ToInt32(row.Cells[4].Value);

                        SqlConnection Cnn = Banco.CriarConexao();
                        string obter = ("Select * From Acrescimo Where idproposta = " + prop + " AND iditemedital=" + edt);
                        SqlCommand sql = new SqlCommand(obter, Cnn);
                        Cnn.Open();

                        SqlDataReader dr = sql.ExecuteReader();
                        if (dr.Read())
                        {
                            vlinicial = Convert.ToDecimal(dr["vlinicial"].ToString());

                        }


                        VlProposta proposta = new VlProposta();

                        proposta.idproposta = prop;
                        proposta.iditemedital = edt;
                        proposta.precovenda = valor;
                        proposta.precominimo = valor;
                        proposta.minimototal = valor * qtde;


                        PsAcrecimo DAOAcrescimo = new PsAcrecimo();
                        DAOAcrescimo.VoltaValorInicial(proposta);

                        DAOAcrescimo.Exluir(prop, edt);
                        this.txtacrescimo.Text = "0";
                        this.txtvlacrecimo.Text = "";

                        txtcaculavlminimo.Text = "";

                        carregarGridItens();

                    }

                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        private void Grid_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            codarquivo = Convert.ToInt32(Grid.CurrentRow.Cells[1].Value.ToString());


            SqlConnection Cnn = Banco.CriarConexao();
            string query = "Select arq,extensao,nomearq from DocumentoProduto Where DocumentoProduto.iddocproduto = " + Convert.ToInt32(Grid[1, e.RowIndex].Value.ToString());

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

        private void txtacrescimo_MouseClick(object sender, MouseEventArgs e)
        {
            ((TextBox)sender).SelectionStart = 0;
            ((TextBox)sender).SelectAll();
        }

        private void txtdecrescimo_MouseClick(object sender, MouseEventArgs e)
        {
            ((TextBox)sender).SelectionStart = 0;
            ((TextBox)sender).SelectAll();
        }

        private void btnImprimir_Itens_Click(object sender, EventArgs e)
        {

        }


        private void carregarGridItensPesquisa()
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


                string strConn = "Select DISTINCT ItemsLicitacao.nritem ,Fornecedor.nome as Fornecedor,CONVERT(varchar(10),ItemsLicitacao.nritem) + ' - ' + Produto.nome + ' - ' + Produto.apresentacao  + ' - ' + Marca.nome as Item,ItemsLicitacao.qtde as Qtde," +
                    " CASE WHEN RetCotacao.casasdecimais = 2 THEN ROUND(VendaPreco.precocusto,2) WHEN RetCotacao.casasdecimais = 3 THEN ROUND(VendaPreco.precocusto,3)" +
               " WHEN RetCotacao.casasdecimais = 4 THEN ROUND(VendaPreco.precocusto,4)  WHEN RetCotacao.casasdecimais = 5 THEN ROUND(VendaPreco.precocusto,5)" +
                " WHEN  RetCotacao.casasdecimais = 6 THEN ROUND(VendaPreco.precocusto,6) END AS Custo,Proposta.margemfinal as MargemFinal,Proposta.precovenda as Venda," +
                  "(Proposta.precovenda * ItemsLicitacao.qtde) as Total_Produto,Proposta.selecionado as Selecionado,Proposta.cotado as Cotado,ItemsLicitacao.iditemedital as Cod, Proposta.ganho as Ganho,UnidadeMedida.idunidade as Unidade," +
                  "Marca.idmarca as Marca,Proposta.idproposta as idproposta,Decrescimos.vldecrescimo as Dec, Acrescimo.vlacrescimo as Acrescimo,Produto.idproduto,Proposta.precominimo as Vl_Minimo, Proposta.minimototal as Minimo_Total,Proposta.edital " +
              " From  ItemsLicitacao LEFT JOIN Proposta ON ItemsLicitacao.iditemedital = Proposta.iditemedital  LEFT JOIN VendaPreco ON ItemsLicitacao.iditemedital = VendaPreco.iditemedital LEFT JOIN Decrescimos ON" +
              " Proposta.idproposta = Decrescimos.idproposta  LEFT JOIN  Produto_Fornecedor ON Proposta.idfornecedor = Produto_Fornecedor.idfornecedor LEFT JOIN Acrescimo ON  Proposta.idproposta = Acrescimo.idproposta," +
              "UnidadeMedida,PrincipioAtivo,Produto,Fornecedor,LancEditais,RetCotacao,Marca Where LancEditais.nlicitacao = ItemsLicitacao.nlicitacao AND  Produto.idprincipio = PrincipioAtivo.idprincipio AND " +
              "ItemsLicitacao.idprincipio = PrincipioAtivo.idprincipio AND ItemsLicitacao.idunidade = UnidadeMedida.idunidade AND ItemsLicitacao.idmarca = Marca.idmarca AND" +
                " VendaPreco.idfornecedor = RetCotacao.idfornecedor and Produto_Fornecedor.idfornecedor = VendaPreco.idfornecedor and " +
              " Produto.idproduto = ItemsLicitacao.idproduto AND  ItemsLicitacao.iditemedital = RetCotacao.iditemedital AND Produto_Fornecedor.idfornecedor= Fornecedor.idfornecedor AND " +
              " ItemsLicitacao.idedital=" + cbolicitacao.SelectedValue + " AND Produto.nome Like'" + txtpesquisa.Text + "%'";



                SqlDataAdapter da = new SqlDataAdapter(strConn, Conn);
                da.Fill(ds);


            }

            this.griditens.RowsDefaultCellStyle.BackColor = Color.LightBlue;
            this.griditens.AlternatingRowsDefaultCellStyle.BackColor = Color.Azure;

            var column = new DataGridViewComboBoxColumn();
            var cotado = new DataGridViewComboBoxColumn();
            griditens.AutoGenerateColumns = false;
            //exibe os dados no datagridview
            griditens.DataSource = ds;
            griditens.Columns.Clear();

            griditens.Columns.Add("Fornecedor", "Fornecedor");
            griditens.Columns.Add("Item", "Item");



            DataTable data = new DataTable();

            data.Columns.Add(new DataColumn("Value", typeof(string)));
            data.Columns.Add(new DataColumn("Description", typeof(string)));

            data.Rows.Add("SIM", "SIM");
            data.Rows.Add("NAO", "NAO");
            column.DataSource = data;
            column.HeaderText = "Selec ?";
            column.ValueMember = "Value";
            column.DisplayMember = "Description";
            griditens.Columns.Insert(2, column);


            DataTable dtcotado = new DataTable();

            dtcotado.Columns.Add(new DataColumn("Value", typeof(string)));
            dtcotado.Columns.Add(new DataColumn("Description", typeof(string)));

            dtcotado.Rows.Add("SIM", "SIM");
            dtcotado.Rows.Add("NAO", "NAO");
            cotado.DataSource = dtcotado;
            cotado.HeaderText = "Cotado ?";
            cotado.ValueMember = "Value";
            cotado.DisplayMember = "Description";
            griditens.Columns.Insert(3, cotado);


            griditens.Columns.Add("Qtde", "Qtde");
            griditens.Columns.Add("Custo", "Custo");
            griditens.Columns.Add("MargemFinal", "MargemFinal");
            griditens.Columns.Add("Venda", "Venda");
            griditens.Columns.Add("Total_Produto", "Total_Produto");
            griditens.Columns.Add("Cod", "Cod");
            griditens.Columns.Add(chkb);
            chkb.HeaderText = "Sel";
            chkb.Name = "chkb";
            chkb.Width = 30;
            griditens.Columns.Add("Ganho", "Ganho");
            griditens.Columns.Add("Unidade", "Unidade");
            griditens.Columns.Add("Marca", "Marca");
            griditens.Columns.Add("idproposta", "idproposta");
            griditens.Columns.Add("Dec", "Dec");
            griditens.Columns.Add("Acrescimo", "Acrescimo");
            griditens.Columns.Add("idproduto", "idproduto");
            griditens.Columns.Add("Vl_Minimo", "Vl_Minimo");
            griditens.Columns.Add("Minimo_Total", "Minimo_Total");
            griditens.Columns.Add("edital", "edital");

            griditens.Columns[0].Width = 150;
            griditens.Columns[1].Width = 190;
            griditens.Columns[4].Width = 70;
            griditens.Columns[5].Width = 70;
            griditens.Columns[6].Width = 80;
            griditens.Columns[7].Width = 80;
            griditens.Columns[8].Width = 110;
            griditens.Columns[9].Visible = false;
            griditens.Columns[10].Width = 40;
            griditens.Columns[11].Visible = false;
            griditens.Columns[12].Visible = false;
            griditens.Columns[13].Visible = false;
            griditens.Columns[14].Visible = false;
            griditens.Columns[15].Width = 50;
            griditens.Columns[16].Width = 80;
            griditens.Columns[17].Visible = false;
            griditens.Columns[18].Width = 80;
            griditens.Columns[19].Width = 85;
            griditens.Columns[20].Visible = false;

            griditens.Columns[5].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            griditens.Columns[6].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            griditens.Columns[7].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            griditens.Columns[8].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            griditens.Columns[9].DefaultCellStyle.Alignment = DataGridViewContentAlignment.TopCenter;
            griditens.Columns[15].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            griditens.Columns[16].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            griditens.Columns[18].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;

            griditens.Columns[0].DataPropertyName = "Fornecedor";
            griditens.Columns[1].DataPropertyName = "Item";
            griditens.Columns[2].DataPropertyName = "Selecionado";
            griditens.Columns[3].DataPropertyName = "Cotado";
            griditens.Columns[4].DataPropertyName = "Qtde";
            griditens.Columns[5].DataPropertyName = "Custo";
            griditens.Columns[6].DataPropertyName = "MargemFinal";
            griditens.Columns[7].DataPropertyName = "Venda";
            griditens.Columns[8].DataPropertyName = "Total_Produto";
            griditens.Columns[9].DataPropertyName = "Cod";
            griditens.Columns[10].DataPropertyName = "Ganha";
            griditens.Columns[11].DataPropertyName = "Ganho";
            griditens.Columns[12].DataPropertyName = "Unidade";
            griditens.Columns[13].DataPropertyName = "Marca";
            griditens.Columns[14].DataPropertyName = "idproposta";
            griditens.Columns[15].DataPropertyName = "Dec";
            griditens.Columns[16].DataPropertyName = "Acrescimo";
            griditens.Columns[17].DataPropertyName = "idproduto";
            griditens.Columns[18].DataPropertyName = "Vl_Minimo";
            griditens.Columns[19].DataPropertyName = "Minimo_Total";
            griditens.Columns[20].DataPropertyName = "edital";


            griditens.Columns[4].ReadOnly = true;
            griditens.Columns[5].ReadOnly = true;
            griditens.Columns[14].ReadOnly = true;
            griditens.Columns[15].ReadOnly = true;
            griditens.Columns[16].ReadOnly = true;
            griditens.Columns[12].ReadOnly = true;

            if (casas == 2)
            {
                rbt2casas.Checked = true;
                //griditens.Columns[5].DefaultCellStyle.Format = "n2";
                griditens.Columns[6].DefaultCellStyle.Format = "#.00\\%";
                griditens.Columns[7].DefaultCellStyle.Format = "n2";
                griditens.Columns[8].DefaultCellStyle.Format = "n2";
                griditens.Columns[15].DefaultCellStyle.Format = "#.00\\%";
                griditens.Columns[16].DefaultCellStyle.Format = "#.00\\%";
                griditens.Columns[18].DefaultCellStyle.Format = "n2";
                griditens.Columns[19].DefaultCellStyle.Format = "n2";

            }
            else if (casas == 3)
            {
                rbt3casas.Checked = true;
                // griditens.Columns[5].DefaultCellStyle.Format = "n3";
                griditens.Columns[6].DefaultCellStyle.Format = "#.00\\%";
                griditens.Columns[7].DefaultCellStyle.Format = "n3";
                griditens.Columns[8].DefaultCellStyle.Format = "n2";
                griditens.Columns[15].DefaultCellStyle.Format = "#.00\\%";
                griditens.Columns[16].DefaultCellStyle.Format = "#.00\\%";
                griditens.Columns[18].DefaultCellStyle.Format = "n3";
                griditens.Columns[19].DefaultCellStyle.Format = "n2";
            }
            else if (casas == 4)
            {
                rbt4casas.Checked = true;
                //griditens.Columns[5].DefaultCellStyle.Format = "n4";
                griditens.Columns[6].DefaultCellStyle.Format = "#.00\\%";
                griditens.Columns[7].DefaultCellStyle.Format = "n4";
                griditens.Columns[8].DefaultCellStyle.Format = "n2";
                griditens.Columns[15].DefaultCellStyle.Format = "#.00\\%";
                griditens.Columns[16].DefaultCellStyle.Format = "#.00\\%";
                griditens.Columns[18].DefaultCellStyle.Format = "n4";
                griditens.Columns[19].DefaultCellStyle.Format = "n2";

            }

            valor = 0;

            foreach (DataGridViewRow linha in griditens.Rows)
            {
                string cell2 = linha.Cells[2].Value.ToString().Trim();
                if (linha.Cells[8].Value != DBNull.Value && cell2 == "SIM")
                {

                    valor += Convert.ToDecimal(linha.Cells[8].Value);
                }

            }


            decimal valort = valor;
            string convertido = String.Format("{0:N2}", Math.Round(valort, 2));
            labTotal.Text = convertido;



            foreach (DataGridViewRow linha in griditens.Rows)
            {
                if ((linha.Cells[9].Value.ToString() == Convert.ToString(2)))
                {

                    linha.Cells["chkb"].Value = true;


                }

            }


            Int32 total = 0;

            foreach (DataGridViewRow linhatotal in griditens.Rows)
            {
                total = total + 1;
            }

            this.txttotalitens.Text = Convert.ToString(total);




            griditens.Refresh();

            Conn.Close();


        }

        private void txtpesquisa_TextChanged(object sender, EventArgs e)
        {
            carregarGridItensPesquisa();
        }

        private void chkTodosNao_CheckedChanged(object sender, EventArgs e)
        {
            if (chkTodosNao.Checked == true)
            {
                chkTodosSim.Checked = false;

                for (int i = 0; i < griditens.RowCount; i++)
                {
                    griditens.Rows[i].Cells[2].Value = "NAO";
                    griditens.Rows[i].Cells[3].Value = "NAO";
                }

                AlterarDados();
            }
            else if (chkTodosNao.Checked == false)
            {
                for (int i = 0; i < griditens.RowCount; i++)
                {
                    griditens.Rows[i].Cells[2].Value = "";
                    griditens.Rows[i].Cells[3].Value = "";
                }
            }

        }

        private void checkImprimirTodos_CheckedChanged(object sender, EventArgs e)
        {
            foreach (DataGridViewRow linha in griditens.Rows)
            {
                if (bool.Parse(linha.Cells[10].EditedFormattedValue.ToString()))

                    if (checkImprimirTodos.Checked == true)
                    {
                        int codproposta = Convert.ToInt32(linha.Cells[14].Value);

                        checkNaoImprimirTodos.Checked = false;

                        linha.Cells[2].Value = "SIM";

                        AlterarDadosImpressao(codproposta, linha.Cells[2].Value.ToString());

                    }
            }


        }

        private void checkNaoImprimirTodos_CheckedChanged(object sender, EventArgs e)
        {

            foreach (DataGridViewRow linha in griditens.Rows)
            {
                if (bool.Parse(linha.Cells[10].EditedFormattedValue.ToString()))

                    if (checkNaoImprimirTodos.Checked == true)
                    {
                        int codproposta = Convert.ToInt32(linha.Cells[14].Value);

                        checkImprimirTodos.Checked = false;

                        linha.Cells[2].Value = "NAO";

                        AlterarDadosImpressao(codproposta, linha.Cells[2].Value.ToString());

                    }
            }

        }

        private void AlterarDadosImpressao(int codproposta, string statusimp)
        {

            VlImprimeProposta obj = new VlImprimeProposta();

            obj.idproposta = codproposta;
            obj.imprimir = statusimp;

            try
            {

                PsImprimeProposta PsBancobll = new PsImprimeProposta();
                PsBancobll.Alterar(obj);

            }
            catch (Exception erro)
            {

                throw erro;
            }

        }

        private void griditens_KeyDown(object sender, KeyEventArgs e)
        {

        }

        private void griditens_KeyUp(object sender, KeyEventArgs e)
        {

        }

        private void griditens_KeyPress(object sender, KeyPressEventArgs e)
        {

        }

        private void button8_Click(object sender, EventArgs e)
        {
            codlic = Convert.ToInt32(cbolicitacao.SelectedValue);
            totalgeral = labTotal.Text;

            RelPropostaItem propostaitem = new RelPropostaItem(this);
            propostaitem.Show();
        }

        private void button9_Click(object sender, EventArgs e)
        {
            codlic = Convert.ToInt32(cbolicitacao.SelectedValue);
            totalgeral = labTotal.Text;

            RelLances lance = new RelLances(this);
            lance.Show();
        }

        private void txtcaculavlminimo_KeyPress(object sender, KeyPressEventArgs e)
        {

        }

        private void btncaulcular_Click(object sender, EventArgs e)
        {
            foreach (DataGridViewRow row in griditens.Rows)
            {

                if (bool.Parse(row.Cells[10].EditedFormattedValue.ToString()) == true)
                {

                    Acrescimo acrescimo = new Acrescimo();
                    acrescimo.idproposta = Convert.ToInt32(row.Cells[14].Value);
                    acrescimo.iditemedital = Convert.ToInt32(row.Cells[9].Value);
                    acrescimo.casasdecimais = casas;


                    decimal porcent = Convert.ToDecimal(this.txtcaculavlminimo.Text);
                    acrescimo.acrecimo = Convert.ToDecimal(porcent);
                    decimal vlcalculoalmento = Convert.ToDecimal(row.Cells[5].Value);
                    acrescimo.vlinicial = vlcalculoalmento;
                    decimal ac = ((Convert.ToDecimal(row.Cells[5].Value) + (porcent * Convert.ToDecimal(row.Cells[5].Value) / 100)));
                    row.Cells[18].Value = ac;
                    acrescimo.precominimo = Convert.ToDecimal(row.Cells[18].Value);


                    decimal calculaminimototal = Convert.ToDecimal(row.Cells[18].Value) * Convert.ToInt32(row.Cells[4].Value);


                    decimal vlaumentado = ac - vlcalculoalmento;

                    acrescimo.minimototal = calculaminimototal;
                    row.Cells[19].Value = acrescimo.minimototal;

                    acrescimo.idedital = Convert.ToInt32(cbolicitacao.SelectedValue);

                    if (acrescimo.casasdecimais == 2)
                    {

                        string vldecrescimo = String.Format("{0:N2}", Convert.ToDecimal(ac), 2);
                        acrescimo.precovenda = Convert.ToDecimal(vldecrescimo);

                        string vlcalculado = String.Format("{0:N2}", Convert.ToDecimal(vlaumentado), 2);
                        acrescimo.vlaumentado = Convert.ToDecimal(vlcalculado);





                    }
                    else if (acrescimo.casasdecimais == 3)
                    {
                        string vldecrescimo = String.Format("{0:N3}", (Convert.ToDecimal(ac)));
                        acrescimo.precovenda = Convert.ToDecimal(vldecrescimo);

                        string vlcalculado = String.Format("{0:N3}", Convert.ToDecimal(vlaumentado), 3);
                        acrescimo.vlaumentado = Convert.ToDecimal(vlcalculado);
                    }
                    else if (acrescimo.casasdecimais == 4)
                    {
                        string vldecrescimo = String.Format("{0:N4}", (Convert.ToDecimal(ac)));
                        acrescimo.precovenda = Convert.ToDecimal(vldecrescimo);

                        string vlcalculado = String.Format("{0:N4}", Convert.ToDecimal(vlaumentado), 4);
                        acrescimo.vlaumentado = Convert.ToDecimal(vlcalculado);
                    }



                    if (VerificaRegistroExisteAcrescimo(acrescimo.idproposta, acrescimo.iditemedital) == true)
                    {



                        PsAcrecimo DAOAcrescimo = new PsAcrecimo();
                        DAOAcrescimo.Alterar(acrescimo);
                        DAOAcrescimo.Incluir(acrescimo);
                        // BuscaValorAcrescimo(nprop, coditems);
                        if (Convert.ToBoolean(row.Cells["chkb"].EditedFormattedValue) == true)
                        {
                            decimal totalcusto = 0;
                            int col9 = Convert.ToInt32(row.Cells[9].Value);

                            VlRealinhamento obj = new VlRealinhamento();
                            obj.iditemedital = Convert.ToInt32(row.Cells[9].Value);
                            obj.qtde = Convert.ToInt32(row.Cells[4].Value);
                            if (rbt2casas.Checked == true)
                            {
                                string vlcusto = (row.Cells[5].Value.ToString());
                                obj.vlcusto = Convert.ToDouble(vlcusto);
                                obj.total = Convert.ToDouble(obj.vlcusto * Convert.ToInt32(row.Cells[4].Value));
                                string vlvenda = String.Format("{0:N2}", Convert.ToDecimal(row.Cells[7].Value), 2);
                                obj.vlvenda = Convert.ToDecimal(vlvenda);
                                string vltotal = String.Format("{0:N2}", Convert.ToDecimal(row.Cells[8].Value), 2);
                                obj.vltotal = Convert.ToDecimal(vltotal);
                                if (row.Cells[18].Value.ToString() == "")
                                {
                                    row.Cells[18].Value = "0,00";
                                }
                                string munit = String.Format("{0:N2}", Convert.ToDecimal(row.Cells[18].Value), 2);
                                obj.minimounit = Convert.ToDecimal(munit);
                                if (row.Cells[19].Value.ToString() == "")
                                {
                                    row.Cells[19].Value = "0,00";
                                }
                                string mintot = String.Format("{0:N2}", Convert.ToDecimal(row.Cells[19].Value), 2);
                                obj.minimototal = Convert.ToDecimal(mintot);

                                casas = 2;




                            }
                            else if (rbt3casas.Checked == true)
                            {
                                string vlcusto = (row.Cells[5].Value.ToString());
                                obj.vlcusto = Convert.ToDouble(vlcusto);
                                obj.total = Convert.ToDouble(obj.vlcusto * Convert.ToInt32(row.Cells[4].Value));
                                string vlvenda = String.Format("{0:N3}", Convert.ToDecimal(row.Cells[7].Value), 3);
                                obj.vlvenda = Convert.ToDecimal(vlvenda);
                                string vltotal = String.Format("{0:N2}", Convert.ToDecimal(row.Cells[8].Value), 3);
                                obj.vltotal = Convert.ToDecimal(vltotal);
                                if (row.Cells[18].Value.ToString() == "")
                                {
                                    row.Cells[18].Value = "0,00";
                                }
                                string munit = String.Format("{0:N3}", Convert.ToDecimal(row.Cells[18].Value), 3);
                                obj.minimounit = Convert.ToDecimal(munit);
                                if (row.Cells[19].Value.ToString() == "")
                                {
                                    row.Cells[19].Value = "0,00";
                                }
                                string mintot = String.Format("{0:N2}", Convert.ToDecimal(row.Cells[19].Value), 3);
                                obj.minimototal = Convert.ToDecimal(mintot);

                                casas = 3;

                            }
                            else if (rbt4casas.Checked == true)
                            {
                                string vlcusto = (row.Cells[5].Value.ToString());
                                obj.vlcusto = Convert.ToDouble(vlcusto);
                                obj.total = Convert.ToDouble(obj.vlcusto * Convert.ToInt32(row.Cells[4].Value));
                                string vlvenda = String.Format("{0:N4}", Convert.ToDecimal(row.Cells[7].Value), 4);
                                obj.vlvenda = Convert.ToDecimal(vlvenda);
                                string vltotal = String.Format("{0:N2}", Convert.ToDecimal(row.Cells[8].Value), 2);
                                obj.vltotal = Convert.ToDecimal(vltotal);
                                if (row.Cells[18].Value.ToString() == "")
                                {
                                    row.Cells[18].Value = "0,00";
                                }
                                string munit = String.Format("{0:N4}", Convert.ToDecimal(row.Cells[18].Value), 4);
                                obj.minimounit = Convert.ToDecimal(munit);
                                if (row.Cells[19].Value.ToString() == "")
                                {
                                    row.Cells[19].Value = "0,00";
                                }
                                string mintot = String.Format("{0:N2}", Convert.ToDecimal(row.Cells[19].Value), 2);
                                obj.minimototal = Convert.ToDecimal(obj.minimounit * obj.qtde);

                                casas = 4;

                            }

                            obj.idusu = Banco.idusu;

                            obj.idunidade = Convert.ToInt32(row.Cells[12].Value);
                            obj.idmarca = Convert.ToInt32(row.Cells[13].Value);
                            // string mgfinal = "0,00";
                            obj.margemfinal = Convert.ToDecimal(row.Cells[6].Value);
                            //string tt = "0,00";
                            string ent = "0,00";
                            obj.entrada = Convert.ToDecimal(ent);
                            string ttg = "0,00";
                            obj.totalg = Convert.ToDecimal(ttg);

                            obj.obs = "";
                            obj.idproposta = Convert.ToInt32(row.Cells[14].Value);
                            obj.aditivo = 0;
                            obj.vladitivo = 0;
                            obj.statusitem = "";
                            obj.imprimir = "SIM";
                            obj.dtrealinhamento = DateTime.Now.ToString("dd/MM/yyyy");
                            obj.idproduto = Convert.ToInt32(row.Cells[17].Value);
                            obj.idedital = Convert.ToInt32(cbolicitacao.SelectedValue);
                            obj.edital = Convert.ToString(row.Cells[20].Value);

                            codret = col9;

                            if (VerificaRegistroExiste(codret) == true)
                            {

                                SalvarDados();
                //                GravaRealinhamento(obj.iditemedital, obj.qtde, obj.vlcusto, obj.vlvenda, obj.idunidade, obj.vltotal, obj.idmarca, obj.margemfinal, obj.total, obj.entrada, obj.totalg, obj.minimounit, obj.minimototal,
                //obj.obs, obj.idproposta, obj.aditivo, obj.vladitivo, obj.imprimir, obj.dtrealinhamento, obj.idproduto, obj.edital, obj.idedital, obj.ganhou);
                            }
                            else
                            {


                                AlterarDados();
                //                GravaRealinhamento(obj.iditemedital, obj.qtde, obj.vlcusto, obj.vlvenda, obj.idunidade, obj.vltotal, obj.idmarca, obj.margemfinal, obj.total, obj.entrada, obj.totalg, obj.minimounit, obj.minimototal,
                //obj.obs, obj.idproposta, obj.aditivo, obj.vladitivo, obj.imprimir, obj.dtrealinhamento, obj.idproduto, obj.edital, obj.idedital, obj.ganhou);

                            }
                        }
                        else
                        {
                            row.Cells["chkb"].Value = false;

                        }



                        //GravaPrecoMinino();
                        //carregarGridItens();
                    }
                    else
                    {

                        PsAcrecimo DAOAcrescimo = new PsAcrecimo();
                        DAOAcrescimo.Alterar(acrescimo);
                        DAOAcrescimo.AlterarAcrescimo(acrescimo);
                        // BuscaValorAcrescimo(nprop, coditems);
                        //GravaPrecoMinino();
                        if (Convert.ToBoolean(row.Cells["chkb"].EditedFormattedValue) == true)
                        {
                            decimal totalcusto = 0;
                            int col9 = Convert.ToInt32(row.Cells[9].Value);

                            VlRealinhamento obj = new VlRealinhamento();
                            obj.iditemedital = Convert.ToInt32(row.Cells[9].Value);
                            obj.qtde = Convert.ToInt32(row.Cells[4].Value);
                            if (rbt2casas.Checked == true)
                            {
                                string vlcusto = (row.Cells[5].Value.ToString());
                                obj.vlcusto = Convert.ToDouble(vlcusto);
                                obj.total = Convert.ToDouble(obj.vlcusto * Convert.ToInt32(row.Cells[4].Value));
                                string vlvenda = String.Format("{0:N2}", Convert.ToDecimal(row.Cells[7].Value), 2);
                                obj.vlvenda = Convert.ToDecimal(vlvenda);
                                string vltotal = String.Format("{0:N2}", Convert.ToDecimal(row.Cells[8].Value), 2);
                                obj.vltotal = Convert.ToDecimal(vltotal);
                                if (row.Cells[18].Value.ToString() == "")
                                {
                                    row.Cells[18].Value = "0,00";
                                }
                                string munit = String.Format("{0:N2}", Convert.ToDecimal(row.Cells[18].Value), 2);
                                obj.minimounit = Convert.ToDecimal(munit);
                                if (row.Cells[19].Value.ToString() == "")
                                {
                                    row.Cells[19].Value = "0,00";
                                }
                                string mintot = String.Format("{0:N2}", Convert.ToDecimal(row.Cells[19].Value), 2);
                                obj.minimototal = Convert.ToDecimal(mintot);

                                casas = 2;




                            }
                            else if (rbt3casas.Checked == true)
                            {
                                string vlcusto = (row.Cells[5].Value.ToString());
                                obj.vlcusto = Convert.ToDouble(vlcusto);
                                obj.total = Convert.ToDouble(obj.vlcusto * Convert.ToInt32(row.Cells[4].Value));
                                string vlvenda = String.Format("{0:N3}", Convert.ToDecimal(row.Cells[7].Value), 3);
                                obj.vlvenda = Convert.ToDecimal(vlvenda);
                                string vltotal = String.Format("{0:N2}", Convert.ToDecimal(row.Cells[8].Value), 3);
                                obj.vltotal = Convert.ToDecimal(vltotal);
                                if (row.Cells[18].Value.ToString() == "")
                                {
                                    row.Cells[18].Value = "0,00";
                                }
                                string munit = String.Format("{0:N3}", Convert.ToDecimal(row.Cells[18].Value), 3);
                                obj.minimounit = Convert.ToDecimal(munit);
                                if (row.Cells[19].Value.ToString() == "")
                                {
                                    row.Cells[19].Value = "0,00";
                                }
                                string mintot = String.Format("{0:N2}", Convert.ToDecimal(row.Cells[19].Value), 3);
                                obj.minimototal = Convert.ToDecimal(mintot);

                                casas = 3;

                            }
                            else if (rbt4casas.Checked == true)
                            {
                                string vlcusto = (row.Cells[5].Value.ToString());
                                obj.vlcusto = Convert.ToDouble(vlcusto);
                                obj.total = Convert.ToDouble(obj.vlcusto * Convert.ToInt32(row.Cells[4].Value));
                                string vlvenda = String.Format("{0:N4}", Convert.ToDecimal(row.Cells[7].Value), 4);
                                obj.vlvenda = Convert.ToDecimal(vlvenda);
                                string vltotal = String.Format("{0:N2}", Convert.ToDecimal(row.Cells[8].Value), 2);
                                obj.vltotal = Convert.ToDecimal(vltotal);
                                if (row.Cells[18].Value.ToString() == "")
                                {
                                    row.Cells[18].Value = "0,00";
                                }
                                string munit = String.Format("{0:N4}", Convert.ToDecimal(row.Cells[18].Value), 4);
                                obj.minimounit = Convert.ToDecimal(munit);
                                if (row.Cells[19].Value.ToString() == "")
                                {
                                    row.Cells[19].Value = "0,00";
                                }
                                string mintot = String.Format("{0:N2}", Convert.ToDecimal(row.Cells[19].Value), 2);
                                obj.minimototal = Convert.ToDecimal(obj.minimounit * obj.qtde);

                                casas = 4;

                            }

                            obj.idusu = Banco.idusu;

                            obj.idunidade = Convert.ToInt32(row.Cells[12].Value);
                            obj.idmarca = Convert.ToInt32(row.Cells[13].Value);
                            // string mgfinal = "0,00";
                            obj.margemfinal = Convert.ToDecimal(row.Cells[6].Value);
                            //string tt = "0,00";
                            string ent = "0,00";
                            obj.entrada = Convert.ToDecimal(ent);
                            string ttg = "0,00";
                            obj.totalg = Convert.ToDecimal(ttg);

                            obj.obs = "";
                            obj.idproposta = Convert.ToInt32(row.Cells[14].Value);
                            obj.aditivo = 0;
                            obj.vladitivo = 0;
                            obj.statusitem = "";
                            obj.imprimir = "SIM";
                            obj.dtrealinhamento = DateTime.Now.ToString("dd/MM/yyyy");
                            obj.idproduto = Convert.ToInt32(row.Cells[17].Value);
                            obj.idedital = Convert.ToInt32(cbolicitacao.SelectedValue);
                            obj.edital = Convert.ToString(row.Cells[20].Value);

                            codret = col9;

                            if (VerificaRegistroExiste(codret) == true)
                            {

                                SalvarDados();
                //                GravaRealinhamento(obj.iditemedital, obj.qtde, obj.vlcusto, obj.vlvenda, obj.idunidade, obj.vltotal, obj.idmarca, obj.margemfinal, obj.total, obj.entrada, obj.totalg, obj.minimounit, obj.minimototal,
                //obj.obs, obj.idproposta, obj.aditivo, obj.vladitivo, obj.imprimir, obj.dtrealinhamento, obj.idproduto, obj.edital, obj.idedital, obj.ganhou);
                            }
                            else
                            {


                                AlterarDados();
                //                GravaRealinhamento(obj.iditemedital, obj.qtde, obj.vlcusto, obj.vlvenda, obj.idunidade, obj.vltotal, obj.idmarca, obj.margemfinal, obj.total, obj.entrada, obj.totalg, obj.minimounit, obj.minimototal,
                //obj.obs, obj.idproposta, obj.aditivo, obj.vladitivo, obj.imprimir, obj.dtrealinhamento, obj.idproduto, obj.edital, obj.idedital, obj.ganhou);

                            }
                        }
                        else
                        {
                            row.Cells["chkb"].Value = false;

                        }

                        //carregarGridItens();


                    }


                }
            }
            carregarGridItens();
        }

        private void button1_Click(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {

        }
    }
}



