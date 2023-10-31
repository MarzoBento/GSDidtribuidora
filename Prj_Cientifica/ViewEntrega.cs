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
    public partial class ViewEntrega : Form
    {
        public static string codselecionado;
        DateTimePicker dtp = new DateTimePicker();
        Rectangle _Rectangle;
        public int casas;
        public int editalrel;
        public string numeroempenho;
        public string notafiscal;
        public int idedital;
        public int statusimpressao;
        public string nfsaida;

        public ViewEntrega()
        {
            InitializeComponent();

            //GridEmpenho.Controls.Add(dtp);
            //dtp.Visible = false;
            //dtp.Format = DateTimePickerFormat.Custom;
            //dtp.TextChanged += new EventHandler(dtp_TextChange);




        }

        public ViewEntrega(ConsEntrega frm) : this()
        {
            codselecionado = frm.codempenho;
            RetReg(codselecionado);


        }
        private void RetReg(string codsel)
        {

            string reg = "Select * FROM Entrega Where Entrega.nempenho='" + codsel + "'";
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
                    if (dr["idrepresentante"].ToString() != "")
                    {
                        RetornaRepresentante(Convert.ToInt32(dr["idrepresentante"].ToString()));
                    }
                    txtcomissao.Text = dr["comissao"].ToString();
                    string convertido = String.Format("{0:N2}", dr["vlcomissao"].ToString(), 2);
                    this.txtvlcomissao.Text = convertido;
                    CarregaGridEmpenhos();
                    // CarregaGridEntrega(Convert.ToInt32(dr["idempenho"].ToString()));


                }
            }



        }



        private void dtp_TextChange(object sender, EventArgs e)
        {
            GridEmpenho.CurrentCell.Value = dtp.Text.ToString();
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
                this.cbolicitacao.DisplayMember = "nlicitacao";
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
            SqlDataAdapter sql = new SqlDataAdapter("Select LancEditais.idedital,LancEditais.nlicitacao,(CAST(LancEditais.nlicitacao AS VARCHAR(10))) + '               ' + (Modalidade.nome + '                    ' +  LancEditais.nlicitacao + '                        ' + " +
                "LancEditais.nprocesso + '                       ' + CONVERT(CHAR,LancEditais.dtabertura,103) + '          ' + Cliente.nome) as Licitacao  from LancEditais,Modalidade,Cliente " +
                " WHERE LancEditais.idmodalidade = Modalidade.idmodalidade and LancEditais.idcliente =  Cliente.idcliente and LancEditais.idedital=" + retedt + "", Cnn);
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

            CarregaGridEmpenhos();
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



        private void label9_Click(object sender, EventArgs e)
        {

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
            CarregaGridEmpenhos();
            // carregarGridItens();
            //CarregaGridArquivos();

        }

        private void cbolicitacao_Click(object sender, EventArgs e)
        {
            CarregarLicitacao();
        }


        DataGridViewCheckBoxColumn chka = new DataGridViewCheckBoxColumn();
        private void CarregaGridEmpenhos()
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



                SqlDataAdapter da = new SqlDataAdapter("Select DISTINCT Empenho.idempenho as Cod,Empenho.edital as Edital, Empenho.dtrecimento as DtRecebimento,Empenho.dtrecimento as DtLimite,Empenho.nempenho as Empenho,EmpenhoItems.notafiscal as Nota_Fiscal_de_Saida" +
                " FROM Empenho,RealinhamentoProposta,EmpenhoItems WHERE EmpenhoItems.idrealinhamento = RealinhamentoProposta.idrealinhamento  AND EmpenhoItems.iditemedital = RealinhamentoProposta.iditemedital AND " +
                " EmpenhoItems.idempenho =  Empenho.idempenho AND EmpenhoItems.idedital=" + cbolicitacao.SelectedValue + "" +
                " GROUP BY  Empenho.idempenho,Empenho.nempenho,EmpenhoItems.notafiscal,EmpenhoItems.qtde,RealinhamentoProposta.qtde,Empenho.dtrecimento,Empenho.Edital, RealinhamentoProposta.iditemedital ", Conn);

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
                Grid.Columns.Add("Edital", "Edital");
                Grid.Columns.Add("DtRecebimento", "DtRecebimento");
                Grid.Columns.Add("DtLimite", "DtLimite");
                Grid.Columns.Add("Empenho", "Empenho");
                Grid.Columns.Add("Nota_Fiscal_de_Saida", "Nota_Fiscal_de_Saida");

                Grid.Columns[0].Width = 50;
                Grid.Columns[1].Visible = false;
                Grid.Columns[2].Width = 150;
                Grid.Columns[3].Width = 100;
                Grid.Columns[4].Width = 95;
                Grid.Columns[5].Width = 110;
                Grid.Columns[6].Width = 156;


                Grid.Columns[1].DataPropertyName = "Cod";
                Grid.Columns[2].DataPropertyName = "Edital";
                Grid.Columns[3].DataPropertyName = "DtRecebimento";
                Grid.Columns[4].DataPropertyName = "DtLimite";
                Grid.Columns[5].DataPropertyName = "Empenho";
                Grid.Columns[6].DataPropertyName = "Nota_Fiscal_de_Saida";



                //Grid.Columns[5].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
                //Grid.Columns[5].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
                //Grid.Columns[6].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
                //Grid.Columns[6].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
                //Grid.Columns[7].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
                //Grid.Columns[7].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;

                Grid.Columns[2].ReadOnly = true;
                Grid.Columns[3].ReadOnly = true;
                Grid.Columns[4].ReadOnly = true;
                Grid.Columns[5].ReadOnly = true;
                Grid.Columns[6].ReadOnly = true;
                //Grid.Columns[7].ReadOnly = true;




                //DataGridViewButtonColumn btn = new DataGridViewButtonColumn();
                //Grid.Columns.Add(btn);
                //btn.HeaderText = "Excluir";
                //btn.Text = "Excluir";
                //btn.Name = "btn";
                //btn.Width = 60;
                //btn.UseColumnTextForButtonValue = true;
                //btn.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft;


            }

        }

        public double valor;
        DataGridViewCheckBoxColumn chk = new DataGridViewCheckBoxColumn();
        private void CarregaGridEntrega(string nempenhp, string nota)
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



                SqlDataAdapter da = new SqlDataAdapter("Select DISTINCT EmpenhoItems.idempenho as Cod,Entrega.nempenho as Empenho,Entrega.nfsaida as Nf_Saida,Produto.nome + ' - ' + Produto.apresentacao  as Descrição, Marca.nome as Marca,(EmpenhoItems.qtde) as Qtde_Empenho," +
                    "RealinhamentoProposta.qtde as Qtde, Entrega.qtde as Entegue, Entrega.dtentrega as Dt_Entrega,Entrega.identrega as identrega, RealinhamentoProposta.qtde -(Select  Sum(EmpenhoItems.qtde) From EmpenhoItems  LEFT JOIN Empenho ON Empenho.idempenho = EmpenhoItems.idempenho where " +
                     " RealinhamentoProposta.iditemedital = EmpenhoItems.iditemedital  AND  EmpenhoItems.idedital =" + cbolicitacao.SelectedValue + " AND Entrega.nempenho ='" + nempenhp + "'  AND  EmpenhoItems.notafiscal ='" + nota + "') as Pendente, Entrega.identrega,RealinhamentoProposta.vladitivo as aditivoedital, " +
                     "Entrega.preco,PrincipioAtivo.nome as Principio,UnidadeMedida.nome as Unidade,Empenho.dtrecimento as Data, " +
                    "ItemsLicitacao.nritem,Produto.apresentacao,Entrega.total as Total,Marca.idmarca FROM EmpenhoItems,Entrega ,RealinhamentoProposta,Produto,PrincipioAtivo,Marca,ItemsLicitacao,UnidadeMedida,Empenho " +
                    " WHERE EmpenhoItems.idrealinhamento = RealinhamentoProposta.idrealinhamento AND EmpenhoItems.idempenhoitems = Entrega.iditemempenho AND Produto.idproduto = Entrega.idproduto AND PrincipioAtivo.idprincipio = Entrega.idprincipio AND Produto.idunidade = UnidadeMedida.idunidade " +
                    "  AND ItemsLicitacao.iditemedital = Entrega.iditemedital  AND Produto.idunidade = ItemsLicitacao.idunidade AND Marca.idmarca = RealinhamentoProposta.idmarca AND Empenho.idempenho = Entrega.idempenho AND  " +
                    "  Entrega.idedital=" + cbolicitacao.SelectedValue + " AND Entrega.nempenho='" + nempenhp + "' AND  EmpenhoItems.notafiscal ='" + nota + "' GROUP BY EmpenhoItems.idempenho,Entrega.nempenho,Entrega.nfsaida, Produto.nome, Marca.nome,EmpenhoItems.qtde, " +
                    "RealinhamentoProposta.qtde, Entrega.qtde,Entrega.dtentrega,RealinhamentoProposta.qtde,Entrega.identrega,RealinhamentoProposta.vladitivo,Entrega.preco,PrincipioAtivo.nome,UnidadeMedida.nome,ItemsLicitacao.nritem,Produto.apresentacao," +
                    "Entrega.total,Marca.idmarca,EmpenhoItems.qtde,RealinhamentoProposta.idrealinhamento, Entrega.nempenho, RealinhamentoProposta.iditemedital,Empenho.dtrecimento  ", Conn);

                da.Fill(ds);


                this.GridEmpenho.RowsDefaultCellStyle.BackColor = Color.LightBlue;
                this.GridEmpenho.AlternatingRowsDefaultCellStyle.BackColor = Color.Azure;

                //exibe os dados no datagridview
                GridEmpenho.AutoGenerateColumns = false;
                GridEmpenho.DataSource = ds;
                GridEmpenho.Columns.Clear();
                GridEmpenho.Columns.Add(chk);
                chk.HeaderText = "Sel";
                chk.Name = "chk";
                GridEmpenho.Columns.Add("Cod", "Cod");
                GridEmpenho.Columns.Add("Data", "Data");
                GridEmpenho.Columns.Add("Empenho", "Empenho");
                GridEmpenho.Columns.Add("Nf_Saida", "Nf_Saida");
                GridEmpenho.Columns.Add("Descrição", "Descrição");
                GridEmpenho.Columns.Add("Marca", "Marca");
                GridEmpenho.Columns.Add("Qtde_Empenho", "Qtde_Empenho");
                GridEmpenho.Columns.Add("Entegue", "Entegue");
                GridEmpenho.Columns.Add("Dt_Entrega", "Dt_Entrega");
                GridEmpenho.Columns.Add("Pendente", "Pendente");
                GridEmpenho.Columns.Add("identrega", "identrega");
                GridEmpenho.Columns.Add("Qtde", "Qtde");
                GridEmpenho.Columns.Add("Principio", "Principio");
                GridEmpenho.Columns.Add("Unidade", "Unidade");
                GridEmpenho.Columns.Add("preco", "preco");
                GridEmpenho.Columns.Add("aditivoedital", "aditivoedital");
                GridEmpenho.Columns.Add("nritem", "nritem");
                GridEmpenho.Columns.Add("apresentacao", "apresentacao");
                GridEmpenho.Columns.Add("Total", "Total");
                GridEmpenho.Columns.Add("idmarca", "idmarca");
                GridEmpenho.Columns.Add("identrega", "identrega");



                GridEmpenho.Columns[0].Width = 50;
                GridEmpenho.Columns[1].Visible = false;
                GridEmpenho.Columns[2].Width = 85;
                GridEmpenho.Columns[3].Width = 110;
                GridEmpenho.Columns[4].Width = 138;
                GridEmpenho.Columns[5].Width = 312;
                GridEmpenho.Columns[6].Width = 203;
                GridEmpenho.Columns[7].Width = 92;
                GridEmpenho.Columns[8].Width = 92;
                GridEmpenho.Columns[9].Width = 101;
                GridEmpenho.Columns[10].Width = 95;
                GridEmpenho.Columns[11].Visible = false;
                GridEmpenho.Columns[12].Visible = false;
                GridEmpenho.Columns[13].Visible = false;
                GridEmpenho.Columns[14].Visible = false;
                GridEmpenho.Columns[15].Visible = false;
                GridEmpenho.Columns[16].Visible = false;
                GridEmpenho.Columns[17].Visible = false;
                GridEmpenho.Columns[18].Visible = false;
                GridEmpenho.Columns[19].Visible = false;
                GridEmpenho.Columns[20].Visible = false;
                GridEmpenho.Columns[21].Visible = false;





                GridEmpenho.Columns[7].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
                GridEmpenho.Columns[7].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
                GridEmpenho.Columns[8].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
                GridEmpenho.Columns[8].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
                GridEmpenho.Columns[10].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
                GridEmpenho.Columns[10].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;



                GridEmpenho.Columns[1].DataPropertyName = "Cod";
                GridEmpenho.Columns[2].DataPropertyName = "Data";
                GridEmpenho.Columns[3].DataPropertyName = "Empenho";
                GridEmpenho.Columns[4].DataPropertyName = "Nf_Saida";
                GridEmpenho.Columns[5].DataPropertyName = "Descrição";
                GridEmpenho.Columns[6].DataPropertyName = "Marca";
                GridEmpenho.Columns[7].DataPropertyName = "Qtde_Empenho";
                GridEmpenho.Columns[8].DataPropertyName = "Entegue";
                GridEmpenho.Columns[9].DataPropertyName = "Dt_Entrega";
                GridEmpenho.Columns[10].DataPropertyName = "Pendente";
                GridEmpenho.Columns[11].DataPropertyName = "identrega";
                GridEmpenho.Columns[12].DataPropertyName = "Qtde";
                GridEmpenho.Columns[13].DataPropertyName = "Principio";
                GridEmpenho.Columns[14].DataPropertyName = "Unidade";
                GridEmpenho.Columns[15].DataPropertyName = "preco";
                GridEmpenho.Columns[16].DataPropertyName = "aditivoedital";
                GridEmpenho.Columns[17].DataPropertyName = "nritem";
                GridEmpenho.Columns[18].DataPropertyName = "apresentacao";
                GridEmpenho.Columns[19].DataPropertyName = "Total";
                GridEmpenho.Columns[20].DataPropertyName = "idmarca";
                GridEmpenho.Columns[21].DataPropertyName = "identrega";

                GridEmpenho.Columns[9].DefaultCellStyle.Format = "dd/MM/yyyy";





                //DateTime dt = DateTime.ParseExact(stringdate, "MM/dd/yyyy", CultureInfo.InvariantCulture);



                GridEmpenho.Columns[2].ReadOnly = true;
                GridEmpenho.Columns[3].ReadOnly = true;
                GridEmpenho.Columns[4].ReadOnly = true;
                GridEmpenho.Columns[5].ReadOnly = true;
                GridEmpenho.Columns[6].ReadOnly = true;
                GridEmpenho.Columns[7].ReadOnly = true;
                GridEmpenho.Columns[10].ReadOnly = true;

                valor = 0;

                foreach (DataGridViewRow linha in GridEmpenho.Rows)
                {
                    if ((linha.Cells[19].Value != DBNull.Value))
                    {

                        valor += Convert.ToDouble(linha.Cells[19].Value);
                    }

                }


                double valort = valor;
                string convertido = String.Format("{0:N2}", Math.Round(valort, 4));
                labTotal.Text = convertido;



            }

        }

        private void Grid_CellClick(object sender, DataGridViewCellEventArgs e)
        {


            foreach (DataGridViewRow row in Grid.Rows)
            {

                if (row.Index == e.RowIndex)
                {
                    row.Cells["chka"].Value = !Convert.ToBoolean(row.Cells["chka"].EditedFormattedValue);
                    int idemp = int.Parse(Grid.Rows[e.RowIndex].Cells[1].Value.ToString());
                    numeroempenho = Convert.ToString(Grid.Rows[e.RowIndex].Cells[5].Value.ToString());
                    notafiscal = Grid.Rows[e.RowIndex].Cells[6].Value.ToString();
                    CarregaGridEntrega(numeroempenho, notafiscal);

                }
                else
                {
                    row.Cells["chka"].Value = false;
                }
            }
        }

        private void GridEmpenho_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {




        }

        private void GridEmpenho_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void GridEmpenho_CellValidated(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void GridEmpenho_CellBeginEdit(object sender, DataGridViewCellCancelEventArgs e)
        {

        }


        private void GridEmpenho_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            //if (e.ColumnIndex == 9)
            //{


            //    GridEmpenho.Controls.Add(dtp);
            //    dtp.Format = DateTimePickerFormat.Short;
            //    Rectangle Rectangle = GridEmpenho.GetCellDisplayRectangle(e.ColumnIndex, e.RowIndex, true);
            //    dtp.Size = new Size(Rectangle.Width, Rectangle.Height);
            //    dtp.Location = new Point(Rectangle.X, Rectangle.Y);
            //    dtp.CloseUp += new EventHandler(dtp_CloseUp);
            //    dtp.TextChanged += new EventHandler(dtp_OnTextChange);
            //    dtp.Visible = true;


            //    // dtp.Value = Convert.ToDateTime(GridEmpenho.SelectedRows[e.RowIndex].Cells[e.ColumnIndex].Value.ToString("dd/MM/yyyy"));

            //    //_Rectangle = GridEmpenho.GetCellDisplayRectangle(e.ColumnIndex, e.RowIndex, true); //  
            //    //dtp.Size = new Size(_Rectangle.Width, _Rectangle.Height); //  
            //    //dtp.Location = new Point(_Rectangle.X, _Rectangle.Y); //  
            //    //dtp.Visible = true;




            //}

            if (e.RowIndex >= 0 && e.ColumnIndex == 0)
            {

                foreach (DataGridViewRow row in GridEmpenho.Rows)
                {

                    if (row.Index == e.RowIndex)
                    {
                        row.Cells["chk"].Value = !Convert.ToBoolean(row.Cells["chk"].EditedFormattedValue);
                        txtmarca.Text = Convert.ToString(GridEmpenho.Rows[e.RowIndex].Cells[6].Value.ToString());
                        labentregue.Text = Convert.ToString(GridEmpenho.Rows[e.RowIndex].Cells[8].Value.ToString());
                        labfaltam.Text = Convert.ToString(GridEmpenho.Rows[e.RowIndex].Cells[10].Value.ToString());
                        labqtdetotal.Text = Convert.ToString(GridEmpenho.Rows[e.RowIndex].Cells[12].Value.ToString());
                        txtprincipio.Text = Convert.ToString(GridEmpenho.Rows[e.RowIndex].Cells[13].Value.ToString());
                        labunidade.Text = Convert.ToString(GridEmpenho.Rows[e.RowIndex].Cells[14].Value.ToString());
                        txtpreco.Text = Convert.ToString(GridEmpenho.Rows[e.RowIndex].Cells[15].Value.ToString());
                        labaditivo.Text = Convert.ToString(GridEmpenho.Rows[e.RowIndex].Cells[16].Value.ToString());
                        labitem.Text = Convert.ToString(GridEmpenho.Rows[e.RowIndex].Cells[17].Value.ToString());
                        txtapresentacao.Text = Convert.ToString(GridEmpenho.Rows[e.RowIndex].Cells[18].Value.ToString());
                        txtnomecomercial.Text = Convert.ToString(GridEmpenho.Rows[e.RowIndex].Cells[5].Value.ToString());
                        double total;
                        total = Convert.ToDouble(GridEmpenho.Rows[e.RowIndex].Cells[19].Value.ToString());
                        string convertido = String.Format("{0:N2}", total, 2);
                        txtvltotal.Text = convertido;
                        int identrega = Convert.ToInt32(GridEmpenho.Rows[e.RowIndex].Cells[21].Value.ToString());
                        RetornaClick(identrega);



                        //string edt = Convert.ToString(cbolicitacao.SelectedValue);
                        //CarregaObs(codiditemedital, nproposta);
                        //CarregaGridArquivos(codiditemedital);



                    }
                    else
                    {
                        row.Cells["chk"].Value = false;
                    }
                }
            }

        }


        private void RetornaClick(int codentrega)
        {

            string reg = "Select * FROM Entrega Where Entrega.identrega='" + codentrega + "'";
            DataTable ds = new DataTable();
            SqlConnection Conn = Banco.CriarConexao();
            Conn.Open();

            if (Conn.State == ConnectionState.Open)
            {
                SqlCommand cmd = new SqlCommand(reg, Conn);
                SqlDataReader dr = cmd.ExecuteReader();
                if (dr.Read())
                {
                    if (dr["idrepresentante"].ToString() != "")
                    {

                        RetornaRepresentante(Convert.ToInt32(dr["idrepresentante"].ToString()));
                    }
                    txtcomissao.Text = dr["comissao"].ToString();
                    string convertido = String.Format("{0:N2}", dr["vlcomissao"].ToString(), 2);
                    this.txtvlcomissao.Text = convertido;
                  
                    


                }
            }



        }


        private void dtp_OnTextChange(object sender, EventArgs e)
        {

            GridEmpenho.CurrentCell.Value = dtp.Text.ToString();
        }

        void dtp_CloseUp(object sender, EventArgs e)
        {
            dtp.Visible = false;
        }

        private void GridEmpenho_CellParsing(object sender, DataGridViewCellParsingEventArgs e)
        {

        }

        private void ViewEntrega_Load(object sender, EventArgs e)
        {

        }

        private void GridEmpenho_ColumnWidthChanged(object sender, DataGridViewColumnEventArgs e)
        {
            dtp.Visible = false;
        }

        private void GridEmpenho_Scroll(object sender, ScrollEventArgs e)
        {
            dtp.Visible = false;
        }
        int idempp = 0;
        string numempenho;
        private void btnAddEmpenho_Click(object sender, EventArgs e)
        {

            try


            {
                SalvarEntrega();


            }
            catch (Exception erro)
            {

                throw erro;
            }

            //  AlteraStatusLicitacao();
            CarregaGridEntrega(numempenho, notafiscal);
        }

        private Boolean VerificaRegistroExiste(int entregaid)
        {

            SqlConnection Cnn = Banco.CriarConexao();
            string obter = ("Select * From Entrega Where identrega = " + entregaid + "");
            SqlCommand sql = new SqlCommand(obter, Cnn);
            Cnn.Open();
            SqlDataReader dr = sql.ExecuteReader();
            if (dr.Read())
            {

                return false;
            }
            return true;
        }
        decimal comissao;
        int idrepresentante;
        decimal calculocomissao;
        public void SalvarEntrega()
        {
            try
            {
                foreach (DataGridViewRow row in GridEmpenho.Rows)
                {

                    if (bool.Parse(row.Cells[0].EditedFormattedValue.ToString()) == true)
                    {
                      
                      
                        //if ((Convert.ToInt32(row.Cells[7].Value) == (Convert.ToInt32(row.Cells[8].Value))))
                        //{
                        int identrega = Convert.ToInt32(row.Cells[11].Value);
                        idempp = Convert.ToInt32(row.Cells[1].Value);
                        numempenho = Convert.ToString(row.Cells[3].Value);

                        if (VerificaRegistroExiste(identrega) == false)
                        {
                            int quantidadeentrega = Convert.ToInt32(row.Cells[8].Value);
                            //row.Cells[9].Value = dtp.Value.ToString("dd/MM/yyyy");
                            // dtp.Value = Convert.ToDateTime(row.Cells[9].Value.ToString());
                            string dataentrega = Convert.ToString(row.Cells[9].Value.ToString());



                            // string dataentrega = dtp.Value.ToString("dd/MM/yyyy");
                            // int identrega = Convert.ToInt32(row.Cells[11].Value);
                            int usu = Banco.idusu;
                            int idmarca = Convert.ToInt32(row.Cells[20].Value.ToString());

                            if (Convert.ToString(cborepresentante.SelectedValue) != "")
                            {

                                 idrepresentante = Convert.ToInt32(cborepresentante.SelectedValue);
                            }
                            else
                            {
                                idrepresentante = 0;
                            }
                            if (txtcomissao.Text != "0")
                            {
                                comissao = Convert.ToDecimal(txtcomissao.Text);
                                decimal total = Convert.ToDecimal(txtvltotal.Text);

                                 calculocomissao = (total * comissao) / 100;
                            }
                            else
                            {
                                calculocomissao = 0;
                            }






                            SqlConnection Cnn = Banco.CriarConexao();

                            string update = "UPDATE Entrega SET qtde=@qtde,dtentrega=@dtentrega,idusu=@idusu,idmarca=@idmarca,idrepresentante=@idrepresentante,comissao=@comissao,vlcomissao=@vlcomissao WHERE identrega=@identrega";

                            SqlCommand cmd = new SqlCommand(update, Cnn);
                            cmd.Parameters.AddWithValue("@identrega", identrega);
                            cmd.Parameters.AddWithValue("@qtde", quantidadeentrega);
                            cmd.Parameters.AddWithValue("@dtentrega", SqlDbType.Date).Value = Convert.ToDateTime(dataentrega).ToString("yyyy/MM/dd");
                            cmd.Parameters.AddWithValue("@idusu", Banco.idusu);
                            cmd.Parameters.AddWithValue("@idmarca", idmarca);
                            cmd.Parameters.AddWithValue("@idrepresentante", idrepresentante);
                            cmd.Parameters.AddWithValue("@comissao", comissao);
                            cmd.Parameters.AddWithValue("@vlcomissao", calculocomissao);
                            Cnn.Open();
                            cmd.ExecuteNonQuery();
                            Cnn.Close();


                        }

                        //}

                        //else
                        //{
                        //    MessageBox.Show("Quantidade de Entrega não pode ser menor que a quantidade Solicitada!");
                        //}

                    }
                }


            }
            catch (Exception ex)
            {
                ex.Message.ToString();
            }
        }

        private void chkTodos_CheckedChanged(object sender, EventArgs e)
        {
            foreach (DataGridViewRow row in GridEmpenho.Rows)
            {
                DataGridViewCheckBoxCell chkb = (DataGridViewCheckBoxCell)row.Cells[0];
                chkb.Value = !(chkb.Value == null ? false : (bool)chkb.Value); //because chk.Value is initialy null
            }
        }

        private void btnPesquisar_Click(object sender, EventArgs e)
        {
            ConsEntrega frmentrega = new ConsEntrega();
            this.Close();
            frmentrega.Show();

        }

        private void btnSair_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void BtnImprimirProposta_Click(object sender, EventArgs e)
        {
            editalrel = Convert.ToInt32(cbolicitacao.SelectedValue);
            statusimpressao = 1;

            RelEntrega entrega = new RelEntrega(this);
            entrega.Show();
        }

        private void Limpacampos()
        {

            this.txtmarca.Text = "";
            this.txtpreco.Text = "0,00";
            this.cbocliente.SelectedIndex = -1;
            cbolicitacao.Text = "";
            this.txtprincipio.Text = "";
            this.txtnomecomercial.Text = "";
            txtapresentacao.Text = "";
            labitem.Text = "0";
            labunidade.Text = "Unidade";
            labqtdetotal.Text = "0";
            this.labaditivo.Text = "0";
            labentregue.Text = "0";
            labfaltam.Text = "0";
            Grid.DataSource = null;
            GridEmpenho.DataSource = null;
            labTotal.Text = "00;00";
            btnPesquisar.Focus();



        }

        private void button1_Click(object sender, EventArgs e)
        {
            Limpacampos();
        }

        private void GridEmpenho_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {


        }

        private void button2_Click(object sender, EventArgs e)
        {
            editalrel = Convert.ToInt32(cbolicitacao.SelectedValue);
            statusimpressao = 2;
            nfsaida = notafiscal;

            RelEntrega entrega = new RelEntrega(this);
            entrega.Show();
        }

        private void CarregarRepresentante()
        {
            SqlConnection Cnn = Banco.CriarConexao();
            SqlDataAdapter sql = new SqlDataAdapter("Select * from Representante", Cnn);
            DataSet Dt = new DataSet();
            sql.Fill(Dt, "Representante");
            DataRow dr = Dt.Tables["Representante"].NewRow();
            dr[1] = "";
            Dt.Tables["Representante"].Rows.Add(dr);
            try
            {

                this.cborepresentante.DisplayMember = "nomerep";
                this.cborepresentante.ValueMember = "idrepresentante";
                this.cborepresentante.DataSource = Dt.Tables["Representante"];
                this.cborepresentante.SelectedIndex = cborepresentante.Items.Count - 1;



            }
            catch (Exception erro)
            {

                throw erro;
            }
            Cnn.Close();
        }
        private void RetornaRepresentante(Int32 retrep)
        {
            SqlConnection Cnn = Banco.CriarConexao();
            SqlDataAdapter sql = new SqlDataAdapter("Select * from Representante WHERE idrepresentante=" + retrep + "", Cnn);
            DataTable Dt = new DataTable();
            sql.Fill(Dt);
            try
            {
                this.cborepresentante.DataSource = Dt;
                this.cborepresentante.DisplayMember = "nomerep";
                this.cborepresentante.ValueMember = "idrepresentante";
                this.cborepresentante.Refresh();




            }
            catch (Exception erro)
            {

                throw erro;
            }
            Cnn.Close();
        }

        private void cborepresentante_Click(object sender, EventArgs e)
        {
            CarregarRepresentante();
        }

        private void txtcomissão_KeyPress(object sender, KeyPressEventArgs e)
        {


            if ((Keys)e.KeyChar == Keys.Enter)
            {

                if (txtcomissao.Text != "0")
                {
                    comissao = Convert.ToDecimal(txtcomissao.Text);
                    decimal total = Convert.ToDecimal(txtvltotal.Text);

                    calculocomissao = (total * comissao) / 100;

                    string convertido = String.Format("{0:N2}", calculocomissao, 2);
                    this.txtvlcomissao.Text = convertido;
                }
                else
                {
                    calculocomissao = 0;
                }

                this.btnAddEmpenho.Focus();
            }

          
        }
    }

}
