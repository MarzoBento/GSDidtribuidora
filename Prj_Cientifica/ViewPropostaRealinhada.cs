using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Prj_Cientifica
{



    public partial class ViewPropostaRealinhada : Form
    {



        public static string TipoGravacao;
        public static int UltimoSelecionado;
        public string nomeFor = "ViewPropostaRealinhada";
        public int casas;
        public int coditems;
        public int coditemempenho;
        public string editalempenho;
        public string edittal;

        public ViewPropostaRealinhada()
        {
            InitializeComponent();
            // griditens.CellClick += griditens_CellClick;

        }

        public ViewPropostaRealinhada(ConsGerarCotacao frm) : this()
        {
            UltimoSelecionado = Convert.ToInt32(frm.codedital);
            edittal = frm.edittal;
            RetReg();
            BuscaDadosBancarios();
            //button1.PerformClick();
            RetornaStatusCasasReg();

            carregarGridItens();


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

            //carregarGridItens();
        }


        private void RetornaStatusCasasReg()
        {
            string reg = "Select casasdecimais  FROM Proposta where Proposta.idedital=" + UltimoSelecionado + "";
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


        private void RetornaStatusCasas()
        {
            string reg = "Select casasdecimais FROM Proposta  Where Proposta.idedital=" + cbolicitacao.SelectedValue + "";
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


                    }
                }
            }


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
                    RetornaCliente();



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


        private void btnSair_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void button5_Click(object sender, EventArgs e)
        {

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
                //this.cbocliente.SelectedIndex = cbolicitacao.Items.Count - 1;



            }
            catch (Exception erro)
            {

                throw erro;
            }
            Cnn.Close();
            BuscaDadosBancarios();
            button1.PerformClick();


            griditens.CellValueChanged +=
         new DataGridViewCellEventHandler(griditens_CellValueChanged);
            griditens.CurrentCellDirtyStateChanged +=
                         new EventHandler(griditens_CurrentCellDirtyStateChanged);
            carregarGridItens();


            foreach (DataGridViewRow linha in griditens.Rows)
            {


                //griditens.Rows[griditens.CurrentRow.Index + 1].Selected = true;
                griditens_CellContentClick(this.griditens, new DataGridViewCellEventArgs(linha.Index, linha.Index));

            }

            RetornaStatusCasas();




        }

        private void button1_Click(object sender, DataGridViewCellEventArgs e)
        {

            griditens_CellEndEdit(sender, e);
        }


        private void BuscaDadosBancarios()
        {

            string query = "Select (Banco.nome + ' - ' +  ContaEmpresa.agencia + ' - ' + ContaEmpresa.conta + ' - ' + ContaEmpresa.favorecido) as DadosBancarios " +
                " From Banco, ContaEmpresa, EmpresaLicitacao,LancEditais Where ContaEmpresa.idempresa = LancEditais.idempresa And  EmpresaLicitacao.idempresa = LancEditais.idempresa And  Banco.idbanco = ContaEmpresa.idbanco and LancEditais.idedital=" + cbolicitacao.SelectedValue + "";
            SqlConnection Cnx = Banco.CriarConexao();
            Cnx.Open();
            SqlCommand cmd = new SqlCommand(query, Cnx);
            SqlDataReader dr = cmd.ExecuteReader();
            if (dr.Read())
            {

                cboDadosBancario.Text = dr["DadosBancarios"].ToString();


            }

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
                string strConn = "Select DISTINCT ItemsLicitacao.nritem as Item,CONVERT(varchar(10),ItemsLicitacao.nritem) + ' - ' + PrincipioAtivo.nome + ' - ' + Produto.nome + ' - ' + Produto.apresentacao as Descrição,UnidadeMedida.nome as Unidade,RealinhamentoProposta.qtde as Qtde,Marca.idmarca as idmarca,RealinhamentoProposta.vlvenda as PreçoUnit,RealinhamentoProposta.vltotal as PreçoTotal,RealinhamentoProposta.margemfinal as MargFinal," +
                    " CASE WHEN LancEditais.casasdecimais = 2 THEN ROUND(RealinhamentoProposta.vlcusto,2) WHEN LancEditais.casasdecimais = 3 THEN ROUND(RealinhamentoProposta.vlcusto,3)" +
               " WHEN LancEditais.casasdecimais = 4 THEN ROUND(RealinhamentoProposta.vlcusto,4)  WHEN LancEditais.casasdecimais = 5 THEN ROUND(RealinhamentoProposta.vlcusto,5)" +
                " WHEN  LancEditais.casasdecimais = 6 THEN ROUND(RealinhamentoProposta.vlcusto,6) END AS Custo,RealinhamentoProposta.total as Total_Custo,RealinhamentoProposta.entrada as Entrada,RealinhamentoProposta.totalg as TotalGeral, RealinhamentoProposta.minimounit as MinimoUnit,RealinhamentoProposta.minimototal as MinimoTotal,RealinhamentoProposta.obs as Obs,LancEditais.nlicitacao, " +
                    "ItemsLicitacao.iditemedital as Cod,RealinhamentoProposta.idproposta as Id, PrincipioAtivo.idprincipio as idpricipio,Produto.idproduto as idproduto,RealinhamentoProposta.idrealinhamento as idrealinhamento,RealinhamentoProposta.aditivo as Aditivo,RealinhamentoProposta.vladitivo as QtdAdtvo,RealinhamentoProposta.imprimir as Imprimir,Produto.idproduto,RealinhamentoProposta.ganhou as Ganhou" +
                " From  ItemsLicitacao LEFT JOIN RealinhamentoProposta ON ItemsLicitacao.iditemedital = RealinhamentoProposta.iditemedital, UnidadeMedida,PrincipioAtivo,Produto,Fornecedor,LancEditais,Fabricante,Proposta,Marca,RetCotacao Where RetCotacao.idedital = RealinhamentoProposta.idedital AND RetCotacao.iditemedital = RealinhamentoProposta.iditemedital AND  LancEditais.idedital = ItemsLicitacao.idedital AND  Produto.idprincipio = PrincipioAtivo.idprincipio AND " +
                "ItemsLicitacao.idprincipio = PrincipioAtivo.idprincipio AND ItemsLicitacao.idunidade = UnidadeMedida.idunidade AND RealinhamentoProposta.idmarca = Marca.idmarca AND Proposta.idproposta = RealinhamentoProposta.idproposta AND " +
                "Produto.idproduto = ItemsLicitacao.idproduto AND Proposta.idfornecedor= Fornecedor.idfornecedor AND Marca.idfabricante = Fabricante.idfabricante AND RealinhamentoProposta.idedital=" + cbolicitacao.SelectedValue + " order by ItemsLicitacao.nritem";


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
            griditens.Columns.Add("Item", "Item");
            griditens.Columns.Add("Descrição", "Descrição");
            griditens.Columns.Add("Unidade", "Unidade");
            griditens.Columns.Add("Qtde", "Qtde");

            DataRow[] rows = ds.Select();

            DataGridViewComboBoxColumn Marca = new DataGridViewComboBoxColumn();

            for (int i = 0; i < rows.Length; i++)
            {
                DataSet Dtm = new DataSet();
                SqlConnection Cnn = Banco.CriarConexao();
                SqlDataAdapter sql = new SqlDataAdapter("Select Marca.idmarca, Marca.nome as Marca From ItemsLicitacao,Marca" +
                    " WHERE ItemsLicitacao.idmarca = Marca.idmarca ", Cnn);


                sql.Fill(Dtm);



                BindingSource bs = new BindingSource();

                bs.DataSource = Dtm;
                bs.DataMember = Dtm.Tables[0].TableName;
                Marca.DataSource = new BindingSource(bs, null);
                Marca.DisplayMember = "Marca";
                Marca.ValueMember = "idmarca";
                Marca.HeaderText = "Marca";
                Marca.FlatStyle = FlatStyle.Flat;
                Marca.DataPropertyName = "Marca";



                //if (Marca == null)
                //   return;



                //DataGridViewComboBoxCell comboCell = new DataGridViewComboBoxCell();
                //comboCell.DisplayMember = "Marca";
                //comboCell.ValueMember = "idfabricante";
                //comboCell.DataSource = Dtm;
                //griditens.Columns.Add(comboCell);
            };
            griditens.Columns.Insert(4, Marca);

            griditens.Columns.Add("PreçoUnit", "PreçoUnit");
            griditens.Columns.Add("PreçoTotal", "PreçoTotal");
            griditens.Columns.Add("MargFinal", "MargFinal");
            griditens.Columns.Add("Custo", "Custo");
            griditens.Columns.Add("Total_Custo", "Total_Custo");
            griditens.Columns.Add("Entrada", "Entrada");
            griditens.Columns.Add("TotalGeral", "TotalGeral");
            griditens.Columns.Add("MinimoUnit", "MinimoUnit");
            griditens.Columns.Add("MinimoTotal", "MinimoTotal");
            griditens.Columns.Add("Cod", "Cod");
            griditens.Columns.Add("Id", "Id");
            griditens.Columns.Add("idpricipio", "idpricipio");
            griditens.Columns.Add("idproduto", "idproduto");
            griditens.Columns.Add("idrealinhamento", "idrealinhamento");
            griditens.Columns.Add(chkb);
            chkb.HeaderText = "Sel";
            chkb.Name = "chkb";
            chkb.Width = 40;

            griditens.Columns.Add("Aditivo", "Aditivo");
            griditens.Columns.Add("QtdAdtvo", "QtdAdtvo");
            //DataTable data = new DataTable();

            //data.Columns.Add(new DataColumn("Value", typeof(string)));
            //data.Columns.Add(new DataColumn("Description", typeof(string)));

            //data.Rows.Add("SIM", "SIM");
            //data.Rows.Add("NAO", "NAO");
            //column.DataSource = data;
            //column.HeaderText = "Imprimir?";
            //column.ValueMember = "Value";
            //column.DisplayMember = "Description";
            //column.Width = 60;
            //griditens.Columns.Insert(22, column);
            griditens.Columns.Add("Imprimir", "Imprimir");
            griditens.Columns.Add("idproduto", "idproduto");
            griditens.Columns.Add("nlicitacao", "nlicitacao");
            griditens.Columns.Add("Ganhou", "Ganhou");




            griditens.Columns[0].Visible = false;
            griditens.Columns[1].Width = 210;
            griditens.Columns[2].Width = 60;
            griditens.Columns[3].Width = 60;
            griditens.Columns[4].Width = 150;
            griditens.Columns[5].Width = 70;
            griditens.Columns[6].Width = 80;
            griditens.Columns[7].Width = 70;
            griditens.Columns[8].Width = 60;
            griditens.Columns[9].Width = 75;
            griditens.Columns[10].Width = 70;
            griditens.Columns[11].Width = 80;
            griditens.Columns[12].Visible = false;
            griditens.Columns[13].Visible = false;
            griditens.Columns[14].Visible = false;
            griditens.Columns[15].Visible = false;
            griditens.Columns[16].Visible = false;
            griditens.Columns[17].Visible = false;
            griditens.Columns[18].Visible = false;
            griditens.Columns[20].Width = 60;
            griditens.Columns[21].Width = 70;
            griditens.Columns[22].Width = 60;
            griditens.Columns[23].Visible = false;
            griditens.Columns[24].Visible = false;
            griditens.Columns[25].Width = 65;
          


            griditens.Columns[0].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;

            griditens.Columns[3].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
            griditens.Columns[3].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;

            griditens.Columns[5].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            griditens.Columns[6].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            griditens.Columns[7].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleLeft;
            griditens.Columns[7].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            griditens.Columns[8].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            griditens.Columns[9].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            griditens.Columns[10].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            griditens.Columns[11].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            griditens.Columns[12].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            griditens.Columns[13].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;

            griditens.Columns[20].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            griditens.Columns[21].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;



            griditens.Columns[0].DataPropertyName = "Item";
            griditens.Columns[1].DataPropertyName = "Descrição";
            griditens.Columns[2].DataPropertyName = "Unidade";
            griditens.Columns[3].DataPropertyName = "Qtde";
            griditens.Columns[4].DataPropertyName = "idmarca";
            griditens.Columns[5].DataPropertyName = "PreçoUnit";
            griditens.Columns[6].DataPropertyName = "PreçoTotal";
            griditens.Columns[7].DataPropertyName = "MargFinal";
            griditens.Columns[8].DataPropertyName = "Custo";
            griditens.Columns[9].DataPropertyName = "Total_Custo";
            griditens.Columns[10].DataPropertyName = "Entrada";
            griditens.Columns[11].DataPropertyName = "TotalGeral";
            griditens.Columns[12].DataPropertyName = "MinimoUnit";
            griditens.Columns[13].DataPropertyName = "MinimoTotal";
            griditens.Columns[14].DataPropertyName = "Cod";
            griditens.Columns[15].DataPropertyName = "Id";
            griditens.Columns[16].DataPropertyName = "idpricipio";
            griditens.Columns[17].DataPropertyName = "idproduto";
            griditens.Columns[18].DataPropertyName = "idrealinhamento";
            griditens.Columns[20].DataPropertyName = "Aditivo";
            griditens.Columns[21].DataPropertyName = "QtdAdtvo";
            griditens.Columns[22].DataPropertyName = "Imprimir";
            griditens.Columns[23].DataPropertyName = "idproduto";
            griditens.Columns[24].DataPropertyName = "nlicitacao";
            griditens.Columns[25].DataPropertyName = "Ganhou";

            griditens.Columns[8].ReadOnly = true;
            griditens.Columns[21].ReadOnly = true;
            griditens.Columns[3].ReadOnly = true;
            griditens.Columns[10].ReadOnly = true;


            DataGridViewButtonColumn btn = new DataGridViewButtonColumn();
            griditens.Columns.Add(btn);
            btn.HeaderText = "Estornar";
            btn.Text = "Estornar";
            btn.Name = "btn";
            btn.Width = 60;
            btn.UseColumnTextForButtonValue = true;
            btn.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft;
            btn.Visible = false;

            decimal valor2casas = 0;

            //decimal valor3casas = 0;

            //decimal valor4casas = 0;



            if (casas == 2)
            {
                rbt2casas.Checked = true;
                griditens.Columns[5].DefaultCellStyle.Format = "n2";
                griditens.Columns[6].DefaultCellStyle.Format = "n2";
                griditens.Columns[7].DefaultCellStyle.Format = "#.00\\%";
                griditens.Columns[8].DefaultCellStyle.Format = "n2";
                griditens.Columns[9].DefaultCellStyle.Format = "n2";
                griditens.Columns[10].DefaultCellStyle.Format = "n2";
                griditens.Columns[11].DefaultCellStyle.Format = "n2";
                griditens.Columns[12].DefaultCellStyle.Format = "n2";
                griditens.Columns[13].DefaultCellStyle.Format = "n2";
                griditens.Columns[20].DefaultCellStyle.Format = "#.00\\%";
                // griditens.Columns[21].DefaultCellStyle.Format = "n2";



                foreach (DataGridViewRow linha in griditens.Rows)
                {
                    if ((linha.Cells[6].Value != DBNull.Value))
                    {

                        valor2casas += Convert.ToDecimal(linha.Cells[6].Value);
                    }

                }


                Decimal valort = valor2casas;
                string convertido = String.Format("{0:N2}", valort, 2);
                labTotal.Text = convertido;


            }
            else if (casas == 3)
            {
                rbt3casas.Checked = true;
                griditens.Columns[5].DefaultCellStyle.Format = "n3";
                griditens.Columns[6].DefaultCellStyle.Format = "n2";
                griditens.Columns[7].DefaultCellStyle.Format = "#.00\\%";
                griditens.Columns[8].DefaultCellStyle.Format = "n3";
                griditens.Columns[9].DefaultCellStyle.Format = "n2";
                griditens.Columns[10].DefaultCellStyle.Format = "n3";
                griditens.Columns[11].DefaultCellStyle.Format = "n2";
                griditens.Columns[12].DefaultCellStyle.Format = "n3";
                griditens.Columns[13].DefaultCellStyle.Format = "n2";
                griditens.Columns[20].DefaultCellStyle.Format = "#.00\\%";
                //  griditens.Columns[21].DefaultCellStyle.Format = "n3";


                foreach (DataGridViewRow linha in griditens.Rows)
                {
                    if ((linha.Cells[6].Value != DBNull.Value))
                    {

                        valor2casas += Convert.ToDecimal(linha.Cells[6].Value);
                    }

                }

                Decimal valort = valor2casas;
                string convertido = String.Format("{0:N2}", valort, 2);
                labTotal.Text = convertido;





            }
            else if (casas == 4)
            {
                rbt4casas.Checked = true;
                griditens.Columns[5].DefaultCellStyle.Format = "n4";
                griditens.Columns[6].DefaultCellStyle.Format = "n2";
                griditens.Columns[7].DefaultCellStyle.Format = "#.00\\%";
                griditens.Columns[9].DefaultCellStyle.Format = "n4";
                griditens.Columns[9].DefaultCellStyle.Format = "n2";
                griditens.Columns[10].DefaultCellStyle.Format = "n4";
                griditens.Columns[11].DefaultCellStyle.Format = "n2";
                griditens.Columns[12].DefaultCellStyle.Format = "n4";
                griditens.Columns[13].DefaultCellStyle.Format = "n2";
                griditens.Columns[20].DefaultCellStyle.Format = "#.00\\%";
                // griditens.Columns[21].DefaultCellStyle.Format = "n4";


                foreach (DataGridViewRow linha in griditens.Rows)
                {
                    if ((linha.Cells[6].Value != DBNull.Value))
                    {

                        valor2casas += Convert.ToDecimal(linha.Cells[6].Value);
                    }

                }

                Decimal valort = valor2casas;
                string convertido = String.Format("{0:N2}", valort, 2);
                labTotal.Text = convertido;


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

        private void griditens_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {




            if ((e.ColumnIndex == 5 && e.RowIndex != -1))
            {



                decimal cell5 = Convert.ToDecimal(griditens.CurrentRow.Cells[5].Value);
                decimal cell3 = Convert.ToDecimal(griditens.CurrentRow.Cells[3].Value);
                decimal cell8 = Convert.ToDecimal(griditens.CurrentRow.Cells[8].Value);

                decimal precototal = cell5 * cell3;


                griditens.CurrentRow.Cells[6].Value = precototal;

                var lucro = cell5 - cell8;
                var pecentual = (lucro * 100) / cell8;

                griditens.CurrentRow.Cells[7].Value = pecentual;








                string valida7 = griditens.CurrentRow.Cells[7].Value.ToString();
                if (valida7 == "")
                {
                    griditens.CurrentRow.Cells[7].Value = 0;
                }
                decimal desc = Convert.ToDecimal(griditens.CurrentRow.Cells[7].Value);

                string valida8 = griditens.CurrentRow.Cells[8].Value.ToString();
                if (valida8 == "")
                {
                    griditens.CurrentRow.Cells[8].Value = 0;
                }



                string valida9 = griditens.CurrentRow.Cells[9].Value.ToString();
                if (valida9 == "")
                {
                    griditens.CurrentRow.Cells[9].Value = 0;
                }

                decimal ipi = Convert.ToDecimal(griditens.CurrentRow.Cells[9].Value);




                if (cell3.ToString() != "" && cell5.ToString() != "")
                {

                    griditens.CurrentRow.Cells[6].Value = precototal;
                    griditens.CurrentRow.Cells[7].Value = (lucro * 100) / cell8;


                    griditens.CurrentRow.Cells["chkb"].Value = true;

                    AlterarDados();




                }

                griditens.Rows[e.RowIndex].Cells[5].Selected = true;

                int iColumn = 5;
                int iRow = e.RowIndex;
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
            if ((e.RowIndex != -1 && e.ColumnIndex == 7))
            {

                string valida5 = griditens.CurrentRow.Cells[5].Value.ToString();
                if (valida5 == "")
                {
                    griditens.CurrentRow.Cells[5].Value = 0;
                }
                decimal cell5 = Convert.ToDecimal(griditens.CurrentRow.Cells[5].Value);
                decimal cell3 = Convert.ToDecimal(griditens.CurrentRow.Cells[3].Value);
                decimal cell8 = Convert.ToDecimal(griditens.CurrentRow.Cells[8].Value);


                string valida8 = griditens.CurrentRow.Cells[8].Value.ToString();
                decimal cell7 = Convert.ToDecimal(griditens.CurrentRow.Cells[7].Value);


                if (valida8 == "")
                {
                    griditens.CurrentRow.Cells[8].Value = 0;
                }
                decimal repasse = Convert.ToDecimal(griditens.CurrentRow.Cells[8].Value);


                if (cell5.ToString() != "")
                {


                    griditens.CurrentRow.Cells[5].Value = ((cell8 * cell7) / 100 + cell8);
                    cell5 = Convert.ToDecimal(griditens.CurrentRow.Cells[5].Value);
                    decimal precototal = cell5 * cell3;
                    griditens.CurrentRow.Cells[6].Value = precototal;

                    //casasDecimais(Convert.ToDecimal(griditens.CurrentRow.Cells[6].Value));

                    griditens.CurrentRow.Cells[9].Value = cell8 * cell3;

                    //griditens.CurrentRow.Cells[10].Value = griditens.CurrentRow.Cells[5].Value;

                    //griditens.CurrentRow.Cells[11].Value = griditens.CurrentRow.Cells[6].Value;

                    // griditens.CurrentRow.Cells[12].Value = griditens.CurrentRow.Cells[5].Value;

                    // griditens.CurrentRow.Cells[13].Value = griditens.CurrentRow.Cells[6].Value;



                    // decimal valor = 0;

                    carregarGridItens();



                }
            }

            if ((e.RowIndex != -1 && e.ColumnIndex == 8))
            {

                string valida5 = griditens.CurrentRow.Cells[5].Value.ToString();
                if (valida5 == "")
                {
                    griditens.CurrentRow.Cells[5].Value = 0;
                }
                decimal cell3 = Convert.ToDecimal(griditens.CurrentRow.Cells[3].Value);

                decimal cell5 = Convert.ToDecimal(griditens.CurrentRow.Cells[5].Value);
                decimal cell6 = Convert.ToDecimal(griditens.CurrentRow.Cells[6].Value);
                decimal cell7 = Convert.ToDecimal(griditens.CurrentRow.Cells[7].Value);


                decimal precototal = cell5 * cell3;
                decimal cell8 = Convert.ToDecimal(griditens.CurrentRow.Cells[8].Value);
                griditens.CurrentRow.Cells[6].Value = precototal;
                decimal punit = Convert.ToDecimal(cell5);
                decimal custo = Convert.ToDecimal(cell8);
                double perc = Convert.ToDouble(griditens.CurrentRow.Cells[7].Value);




                decimal pcalculo = ((punit - custo) / custo * 100);
                decimal basecauculo = pcalculo / 100;

                decimal vlconvertido = custo + (basecauculo * custo);


                decimal pfinal = vlconvertido;

                griditens.CurrentRow.Cells[5].Value = Math.Round(pfinal);

                //casasDecimais(Convert.ToDecimal(griditens.CurrentRow.Cells[5].Value));


                decimal total = cell5 * cell3;

                griditens.CurrentRow.Cells[6].Value = total;

                //casasDecimais(Convert.ToDecimal(griditens.CurrentRow.Cells[6].Value));

                string valida8 = griditens.CurrentRow.Cells[8].Value.ToString();
                if (valida8 == "")
                {
                    griditens.CurrentRow.Cells[8].Value = 0;
                }


                if (cell5.ToString() != "" && cell6.ToString() != "")
                {

                    griditens.CurrentRow.Cells[6].Value = total;
                    griditens.CurrentRow.Cells[7].Value = (((cell5 - cell8) / cell8) * 100);

                    // casasDecimais(Convert.ToDecimal(griditens.CurrentRow.Cells[6].Value));

                    griditens.CurrentRow.Cells[9].Value = cell8 * cell3;

                    //griditens.CurrentRow.Cells[10].Value = griditens.CurrentRow.Cells[7].Value;

                    //griditens.CurrentRow.Cells[11].Value = total;


                    //Convert.ToDecimal(griditens.CurrentRow.Cells[9].Value);
                    //Convert.ToDecimal(griditens.CurrentRow.Cells[10].Value);


                    decimal valor = 0;

                    carregarGridItens();




                }
            }
            if ((e.RowIndex != -1 && e.ColumnIndex == 3))
            {
                string valida3 = griditens.CurrentRow.Cells[3].Value.ToString();
                if (valida3 == "")
                {
                    griditens.CurrentRow.Cells[3].Value = 0;
                }

                string valida5 = griditens.CurrentRow.Cells[5].Value.ToString();
                if (valida5 == "")
                {
                    griditens.CurrentRow.Cells[5].Value = 0;
                }

                decimal cell5 = Convert.ToDecimal(griditens.CurrentRow.Cells[5].Value);
                decimal cell3 = Convert.ToDecimal(griditens.CurrentRow.Cells[3].Value);
                decimal cell8 = Convert.ToDecimal(griditens.CurrentRow.Cells[8].Value);

                decimal precototal = cell5 * cell3;


                griditens.CurrentRow.Cells[6].Value = precototal;
                griditens.CurrentRow.Cells[7].Value = (((cell8 * 100) / cell5) - 100);


                //casasDecimais(Convert.ToDecimal(griditens.CurrentRow.Cells[6].Value));


                decimal valor = 0;


                carregarGridItens();





            }

          

            if ((e.RowIndex != -1 && e.ColumnIndex == 20))
            {
                int aditivo = 0;
                int totalqtdaditivo = 0;
                double qtdeaditivo = 0;


                int iditemedital = Convert.ToInt32(griditens.CurrentRow.Cells[14].Value);
                int idproposta = Convert.ToInt32(griditens.CurrentRow.Cells[15].Value);
                int qtd = Convert.ToInt32(griditens.CurrentRow.Cells[3].Value);

                string valida20 = Convert.ToString(griditens.CurrentRow.Cells[20].Value);


                if (valida20 == ".00%")
                {
                    griditens.CurrentRow.Cells[20].Value = 0;
                }
                else
                {



                    aditivo = Convert.ToInt32(griditens.CurrentRow.Cells[20].Value);
                    totalqtdaditivo = Convert.ToInt32(qtd * aditivo) / 100 + qtd;
                    qtdeaditivo = totalqtdaditivo - qtd;

                    griditens.CurrentRow.Cells[3].Value = totalqtdaditivo;
                    griditens.CurrentRow.Cells[21].Value = qtdeaditivo;

                    string valida5 = griditens.CurrentRow.Cells[5].Value.ToString();

                    if (valida5 == "")
                    {
                        griditens.CurrentRow.Cells[5].Value = 0;
                    }

                    int cell3 = Convert.ToInt32(griditens.CurrentRow.Cells[3].Value);

                    decimal precototal = 0;
                    decimal pminimo = 0;



                    decimal precuinitarioconvert = Convert.ToDecimal(griditens.CurrentRow.Cells[5].Value.ToString());

                    decimal punit = decimal.Round(precuinitarioconvert, 2, MidpointRounding.AwayFromZero);

                    precototal = (punit * cell3);

                    pminimo = cell3 * Convert.ToDecimal(griditens.CurrentRow.Cells[12].Value);




                    griditens.CurrentRow.Cells[6].Value = precototal;



                   

                    AlterarDadosAditivo(qtdeaditivo, aditivo, precototal, totalqtdaditivo, iditemedital, idproposta);


                  

                

                }
            }



        }


        //public int casasDecimais(decimal d)
        //{
        //    int res = 0;
        //    while (d != (long)d)
        //    {
        //        res++;
        //        d = d * 10;
        //    }
        //    return res;
        //}
        public int codret;
        private void btnSalvar_Click(object sender, EventArgs e)
        {

            try


            {
                foreach (DataGridViewRow row in griditens.Rows)
                {
                    if (bool.Parse(row.Cells[19].EditedFormattedValue.ToString()) == true)
                    {

                        if (griditens.Rows.Count >= 1)
                        {
                            codret = Convert.ToInt32(row.Cells[15].Value.ToString());

                            if (VerificaRegistroExiste(codret) == true)
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
            }
            catch (Exception erro)
            {

                throw erro;
            }

            // AlteraStatusLicitacao();
            carregarGridItens();

        }

        private Boolean VerificaRegistroExiste(int cod)
        {

            SqlConnection Cnn = Banco.CriarConexao();
            string obter = ("Select * From RealinhamentoProposta Where idproposta = " + cod + "");
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
                if (griditens.Rows.Count > 1)
                {
                    for (int i = 0; i <= griditens.Rows.Count - 1; i++)
                    {
                        int col15 = Convert.ToInt32(griditens.Rows[i].Cells[15].Value);
                        int col3 = Convert.ToInt32(griditens.Rows[i].Cells[3].Value);
                        int col2 = Convert.ToInt32(griditens.Rows[i].Cells[2].Value);
                        decimal col8 = Convert.ToDecimal(griditens.Rows[i].Cells[8].Value);
                        decimal col6 = Convert.ToDecimal(griditens.Rows[i].Cells[6].Value);
                        string col5 = Convert.ToString(griditens.Rows[i].Cells[5].Value);
                        decimal col7 = Convert.ToDecimal(griditens.Rows[i].Cells[7].Value);
                        int col4 = Convert.ToInt32(griditens.Rows[i].Cells[4].Value);
                        decimal col9 = Convert.ToDecimal(griditens.Rows[i].Cells[9].Value);
                        decimal col10 = Convert.ToDecimal(griditens.Rows[i].Cells[10].Value);
                        decimal col11 = Convert.ToDecimal(griditens.Rows[i].Cells[11].Value);
                        decimal col12 = Convert.ToDecimal(griditens.Rows[i].Cells[12].Value);
                        decimal col13 = Convert.ToDecimal(griditens.Rows[i].Cells[13].Value);
                        string col14 = Convert.ToString(griditens.Rows[i].Cells[14].Value);
                        string col16 = Convert.ToString(griditens.Rows[i].Cells[16].Value);

                        int principio = Convert.ToInt32(griditens.Rows[i].Cells[16].Value);
                        int produto = Convert.ToInt32(griditens.Rows[i].Cells[17].Value);
                        int idrealinhamento = Convert.ToInt32(griditens.Rows[i].Cells[18].Value);
                        int aditivo = Convert.ToInt32(griditens.Rows[i].Cells[20].Value);
                        double vladitivo = Convert.ToDouble(griditens.Rows[i].Cells[21].Value);
                        string imprimir = Convert.ToString(griditens.Rows[i].Cells[22].Value);
                        string dtrealinhamento = DateTime.Now.ToString("dd/MM/yyyy");
                        int idproduto = Convert.ToInt32(griditens.Rows[i].Cells[23].Value);
                        string edital = Convert.ToString(griditens.Rows[i].Cells[24].Value);


                        SqlConnection Cnn = Banco.CriarConexao();

                        string insert = "INSERT INTO RealinhamentoProposta(iditemedital,qtde,vlcusto,vlvenda,vltotal,idusu,idunidade,idfabricante,margemfinal,total,entrada,totalg,minimounit,minimototal,obs,idproposta,edital,idedital) VALUES " +
                            "(@iditemedital,@qtde,@vlcusto,@vlvenda,@vltotal,@idusu,@idunidade,@idmarca,@margemfinal,@total,@entrada,@totalg,@minimounit,@minimototal,@obs,@idproposta,@aditivo,@vladitivo,@imprimir,@dtrealinhamento,@idproduto,@edital,@idedital)";

                        SqlCommand cmd = new SqlCommand(insert, Cnn);
                        cmd.Parameters.AddWithValue("@iditemedital", col15);
                        cmd.Parameters.AddWithValue("@qtde", col3);
                        cmd.Parameters.AddWithValue("@vlcusto", col8);
                        cmd.Parameters.AddWithValue("@vlvenda", col5);
                        cmd.Parameters.AddWithValue("@vltotal", col6);
                        cmd.Parameters.AddWithValue("@idusu", Banco.idusu);
                        cmd.Parameters.AddWithValue("@idunidade", col2);
                        cmd.Parameters.AddWithValue("@idfabricante", col4);
                        cmd.Parameters.AddWithValue("@margemfinal", col7);
                        cmd.Parameters.AddWithValue("@total", col9);
                        cmd.Parameters.AddWithValue("@entrada", col10);
                        cmd.Parameters.AddWithValue("@totalg", col11);
                        cmd.Parameters.AddWithValue("@minimounit", col12);
                        cmd.Parameters.AddWithValue("@minimototal", col13);
                        cmd.Parameters.AddWithValue("@obs", txtobs.Text.ToUpper());
                        cmd.Parameters.AddWithValue("@idproposta", col16);
                        cmd.Parameters.AddWithValue("@aditivo", aditivo);
                        cmd.Parameters.AddWithValue("@vladitivo", vladitivo);
                        cmd.Parameters.AddWithValue("@imprimir", imprimir);
                        cmd.Parameters.AddWithValue("@dtrealinhamento", SqlDbType.Date).Value = Convert.ToDateTime(dtrealinhamento).ToString("yyyy/MM/dd");
                        cmd.Parameters.AddWithValue("@idproduto", idproduto);
                        cmd.Parameters.AddWithValue("@edital", edital);
                        cmd.Parameters.AddWithValue("@idedital", cbolicitacao.SelectedValue);
                        Cnn.Open();
                        cmd.ExecuteNonQuery();
                        Cnn.Close();




                        VlItemLicitacao itemlicitacao = new VlItemLicitacao();
                        itemlicitacao.idmarca = col4;
                        itemlicitacao.iditemedital = col15;
                        itemlicitacao.idedital = Convert.ToInt32(cbolicitacao.SelectedValue);
                        itemlicitacao.nlicitacao = edital;
                        itemlicitacao.idusu = Banco.idusu;


                        PsItemLicitacao DAOItemsLicitacao = new PsItemLicitacao();
                        DAOItemsLicitacao.AlterarMarca(itemlicitacao);




                    }

                }
            }
            catch (Exception ex)
            {
                ex.Message.ToString();
            }
        }

        private Boolean VerificaRegistroEmpenhoExiste(int idedital)
        {

            SqlConnection Cnn = Banco.CriarConexao();
            string obter = ("Select * From Empenho Where idedital='" + idedital + "'");
            SqlCommand sql = new SqlCommand(obter, Cnn);
            Cnn.Open();
            SqlDataReader dr = sql.ExecuteReader();
            if (dr.Read())
            {

                return false;
            }
            return true;
        }

        public void AlterarDados()
        {
            try
            {
                foreach (DataGridViewRow row in griditens.Rows)
                {

                    if (bool.Parse(row.Cells[19].EditedFormattedValue.ToString()) == true)
                    {

                        int col15 = Convert.ToInt32(row.Cells[15].Value);
                        int col3 = Convert.ToInt32(row.Cells[3].Value);
                        double col8 = Convert.ToDouble(row.Cells[8].Value);
                        double col6 = Convert.ToDouble(row.Cells[6].Value);
                        double col5 = Convert.ToDouble(row.Cells[5].Value);
                        double col7 = Convert.ToDouble(row.Cells[7].Value);
                        double col9 = Convert.ToDouble(row.Cells[9].Value);
                        double col10 = Convert.ToDouble(row.Cells[10].Value);
                        double col11 = Convert.ToDouble(row.Cells[11].Value);
                        double col12 = Convert.ToDouble(row.Cells[12].Value);
                        double col13 = Convert.ToDouble(row.Cells[13].Value);
                        int col14 = Convert.ToInt32(row.Cells[14].Value);
                        int col16 = Convert.ToInt32(row.Cells[16].Value);

                        int principio = Convert.ToInt32(row.Cells[16].Value);
                        int produto = Convert.ToInt32(row.Cells[17].Value);
                        int idrealinhamento = Convert.ToInt32(row.Cells[18].Value);
                        int idmarca = Convert.ToInt32(row.Cells[4].Value);
                        int aditivo = Convert.ToInt32(row.Cells[20].Value);
                        double vladitivo = Convert.ToDouble(row.Cells[21].Value);
                        string imprimir = "SIM";
                        string dtrealinhamento = DateTime.Now.ToString("dd/MM/yyyy");
                        int idproduto = Convert.ToInt32(row.Cells[23].Value);
                        string edital = Convert.ToString(row.Cells[24].Value);
                        int idedital = Convert.ToInt32(cbolicitacao.SelectedValue);
                        string ganhou = "SIM";


                        SqlConnection Cnn = Banco.CriarConexao();

                        string update = "UPDATE RealinhamentoProposta SET qtde=@qtde,vlcusto=@vlcusto,vlvenda=@vlvenda,vltotal=@vltotal,idusu=@idusu,margemfinal=@margemfinal," +
                            "total=@total,entrada=@entrada,totalg=@totalg,minimounit=@minimounit,minimototal=@minimototal,obs=@obs,idmarca=@idmarca,aditivo=@aditivo,vladitivo=@vladitivo," +
                            "imprimir=@imprimir,dtrealinhamento=@dtrealinhamento,idproduto=@idproduto,edital=@edital,idedital=@idedital,ganhou=@ganhou WHERE iditemedital=@iditemedital and idproposta=@idproposta";

                        SqlCommand cmd = new SqlCommand(update, Cnn);
                        cmd.Parameters.AddWithValue("@iditemedital", col14);
                        cmd.Parameters.AddWithValue("@idproposta", col15);
                        cmd.Parameters.AddWithValue("@qtde", col3);
                        cmd.Parameters.AddWithValue("@vlcusto", col8);
                        cmd.Parameters.AddWithValue("@vlvenda", col5);
                        cmd.Parameters.AddWithValue("@vltotal", col6);
                        cmd.Parameters.AddWithValue("@idusu", Banco.idusu);
                        cmd.Parameters.AddWithValue("@margemfinal", col7);
                        cmd.Parameters.AddWithValue("@total", col9);
                        cmd.Parameters.AddWithValue("@entrada", col10);
                        cmd.Parameters.AddWithValue("@totalg", col11);
                        cmd.Parameters.AddWithValue("@minimounit", col12);
                        cmd.Parameters.AddWithValue("@minimototal", col13);
                        cmd.Parameters.AddWithValue("@obs", txtobs.Text.ToUpper());
                        cmd.Parameters.AddWithValue("@idmarca", idmarca);
                        cmd.Parameters.AddWithValue("@aditivo", aditivo);
                        cmd.Parameters.AddWithValue("@vladitivo", vladitivo);
                        cmd.Parameters.AddWithValue("@imprimir", imprimir);
                        cmd.Parameters.AddWithValue("@dtrealinhamento", SqlDbType.Date).Value = Convert.ToDateTime(dtrealinhamento).ToString("yyyy/MM/dd");
                        cmd.Parameters.AddWithValue("@idproduto", idproduto);
                        cmd.Parameters.AddWithValue("@edital", edital);
                        cmd.Parameters.AddWithValue("@idedital", idedital);
                        cmd.Parameters.AddWithValue("@ganhou", ganhou);
                        Cnn.Open();
                        cmd.ExecuteNonQuery();
                        Cnn.Close();




                        VlItemLicitacao itemlicitacao = new VlItemLicitacao();
                        itemlicitacao.idmarca = idmarca;
                        itemlicitacao.iditemedital = col14;
                        itemlicitacao.nlicitacao = edital;
                        itemlicitacao.idedital = idedital;
                        itemlicitacao.idusu = Banco.idusu;

                        PsItemLicitacao DAOItemsLicitacao = new PsItemLicitacao();
                        DAOItemsLicitacao.AlterarMarca(itemlicitacao);
                        DAOItemsLicitacao.AlterarMarcaEntrega(itemlicitacao);




                    }
                }
                //MessageBox.Show("Dados Alterados com sucesso !!", "Inclusão", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                ex.Message.ToString();
            }
            carregarGridItens();
        }

        private void rbt2casas_CheckedChanged(object sender, EventArgs e)
        {
            if (rbt2casas.Checked == true)
            {

                carregarGridItens();


            }
        }

        public void AlterarDadosGanhou(string ganhou)
        {
            try
            {
                foreach (DataGridViewRow row in griditens.Rows)
                {

                    if (bool.Parse(row.Cells[19].EditedFormattedValue.ToString()) == true)
                    {

                        int col15 = Convert.ToInt32(row.Cells[15].Value);
                        int col14 = Convert.ToInt32(row.Cells[14].Value);
                       
                      


                        SqlConnection Cnn = Banco.CriarConexao();
                        string update = "UPDATE RealinhamentoProposta SET ganhou=@ganhou WHERE iditemedital=@iditemedital and idproposta=@idproposta";
                        SqlCommand cmd = new SqlCommand(update, Cnn);
                        cmd.Parameters.AddWithValue("@iditemedital", col14);
                        cmd.Parameters.AddWithValue("@idproposta", col15);
                        cmd.Parameters.AddWithValue("@ganhou", ganhou);
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
            carregarGridItens();
        }



        public void AlterarDadosNoClick(string imp)
        {
            try
            {
                foreach (DataGridViewRow row in griditens.Rows)
                {

                    if (bool.Parse(row.Cells[19].EditedFormattedValue.ToString()) == true)
                    {

                        int col15 = Convert.ToInt32(row.Cells[15].Value);
                        int col3 = Convert.ToInt32(row.Cells[3].Value);
                        double col8 = Convert.ToDouble(row.Cells[8].Value);
                        double col6 = Convert.ToDouble(row.Cells[6].Value);
                        double col5 = Convert.ToDouble(row.Cells[5].Value);
                        double col7 = Convert.ToDouble(row.Cells[7].Value);
                        double col9 = Convert.ToDouble(row.Cells[9].Value);
                        double col10 = Convert.ToDouble(row.Cells[10].Value);
                        double col11 = Convert.ToDouble(row.Cells[11].Value);
                        double col12 = Convert.ToDouble(row.Cells[12].Value);
                        double col13 = Convert.ToDouble(row.Cells[13].Value);
                        int col14 = Convert.ToInt32(row.Cells[14].Value);
                        int col16 = Convert.ToInt32(row.Cells[16].Value);

                        int principio = Convert.ToInt32(row.Cells[16].Value);
                        int produto = Convert.ToInt32(row.Cells[17].Value);
                        int idrealinhamento = Convert.ToInt32(row.Cells[18].Value);
                        int idmarca = Convert.ToInt32(row.Cells[4].Value);
                        int aditivo = Convert.ToInt32(row.Cells[20].Value);
                        double vladitivo = Convert.ToDouble(row.Cells[21].Value);
                        string imprimir = imp;
                        string dtrealinhamento = DateTime.Now.ToString("dd/MM/yyyy");
                        int idproduto = Convert.ToInt32(row.Cells[23].Value);
                        string edital = Convert.ToString(row.Cells[24].Value);
                        int idedital = Convert.ToInt32(cbolicitacao.SelectedValue);
                     


                        SqlConnection Cnn = Banco.CriarConexao();

                        string update = "UPDATE RealinhamentoProposta SET qtde=@qtde,vlcusto=@vlcusto,vlvenda=@vlvenda,vltotal=@vltotal,idusu=@idusu,margemfinal=@margemfinal," +
                            "total=@total,entrada=@entrada,totalg=@totalg,minimounit=@minimounit,minimototal=@minimototal,obs=@obs,idmarca=@idmarca,aditivo=@aditivo,vladitivo=@vladitivo," +
                            "imprimir=@imprimir,dtrealinhamento=@dtrealinhamento,idproduto=@idproduto,edital=@edital,idedital=@idedital WHERE iditemedital=@iditemedital and idproposta=@idproposta";

                        SqlCommand cmd = new SqlCommand(update, Cnn);
                        cmd.Parameters.AddWithValue("@iditemedital", col14);
                        cmd.Parameters.AddWithValue("@idproposta", col15);
                        cmd.Parameters.AddWithValue("@qtde", col3);
                        cmd.Parameters.AddWithValue("@vlcusto", col8);
                        cmd.Parameters.AddWithValue("@vlvenda", col5);
                        cmd.Parameters.AddWithValue("@vltotal", col6);
                        cmd.Parameters.AddWithValue("@idusu", Banco.idusu);
                        cmd.Parameters.AddWithValue("@margemfinal", col7);
                        cmd.Parameters.AddWithValue("@total", col9);
                        cmd.Parameters.AddWithValue("@entrada", col10);
                        cmd.Parameters.AddWithValue("@totalg", col11);
                        cmd.Parameters.AddWithValue("@minimounit", col12);
                        cmd.Parameters.AddWithValue("@minimototal", col13);
                        cmd.Parameters.AddWithValue("@obs", txtobs.Text.ToUpper());
                        cmd.Parameters.AddWithValue("@idmarca", idmarca);
                        cmd.Parameters.AddWithValue("@aditivo", aditivo);
                        cmd.Parameters.AddWithValue("@vladitivo", vladitivo);
                        cmd.Parameters.AddWithValue("@imprimir", imprimir);
                        cmd.Parameters.AddWithValue("@dtrealinhamento", SqlDbType.Date).Value = Convert.ToDateTime(dtrealinhamento).ToString("yyyy/MM/dd");
                        cmd.Parameters.AddWithValue("@idproduto", idproduto);
                        cmd.Parameters.AddWithValue("@edital", edital);
                        cmd.Parameters.AddWithValue("@idedital", idedital);
                      
                        Cnn.Open();
                        cmd.ExecuteNonQuery();
                        Cnn.Close();




                        VlItemLicitacao itemlicitacao = new VlItemLicitacao();
                        itemlicitacao.idmarca = idmarca;
                        itemlicitacao.iditemedital = col14;
                        itemlicitacao.nlicitacao = edital;
                        itemlicitacao.idedital = idedital;
                        itemlicitacao.idusu = Banco.idusu;

                        PsItemLicitacao DAOItemsLicitacao = new PsItemLicitacao();
                        DAOItemsLicitacao.AlterarMarca(itemlicitacao);




                    }
                }
                //MessageBox.Show("Dados Alterados com sucesso !!", "Inclusão", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                ex.Message.ToString();
            }
            carregarGridItens();
        }
    

        private void carregarGridItens2Casas()
        {


            this.griditens.RowsDefaultCellStyle.BackColor = Color.LightBlue;
            this.griditens.AlternatingRowsDefaultCellStyle.BackColor = Color.Azure;


            griditens.AutoGenerateColumns = false;
            //exibe os dados no datagridview


            griditens.Columns[0].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            griditens.Columns[5].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            griditens.Columns[6].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            griditens.Columns[7].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleLeft;
            griditens.Columns[7].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            griditens.Columns[8].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            griditens.Columns[9].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            griditens.Columns[10].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            griditens.Columns[11].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            griditens.Columns[12].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            griditens.Columns[13].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;

            griditens.Columns[8].ReadOnly = true;


            //DataGridViewButtonColumn btn = new DataGridViewButtonColumn();
            //griditens.Columns.Add(btn);
            //btn.HeaderText = "Cancelar";
            //btn.Text = "Cancelar";
            //btn.Name = "btn";
            //btn.Width = 65;
            //btn.UseColumnTextForButtonValue = true;
            //btn.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft;


            griditens.Columns[5].DefaultCellStyle.Format = "n2";
            griditens.Columns[6].DefaultCellStyle.Format = "n2";
            griditens.Columns[7].DefaultCellStyle.Format = "#.00\\%";
            griditens.Columns[8].DefaultCellStyle.Format = "n2";
            griditens.Columns[9].DefaultCellStyle.Format = "n2";
            griditens.Columns[10].DefaultCellStyle.Format = "n2";
            griditens.Columns[11].DefaultCellStyle.Format = "n2";
            griditens.Columns[12].DefaultCellStyle.Format = "n2";
            griditens.Columns[13].DefaultCellStyle.Format = "n2";



            carregarGridItens();





            griditens.Refresh();


        }
        private void carregarGridItens3Casas()
        {


            this.griditens.RowsDefaultCellStyle.BackColor = Color.LightBlue;
            this.griditens.AlternatingRowsDefaultCellStyle.BackColor = Color.Azure;


            griditens.AutoGenerateColumns = false;
            //exibe os dados no datagridview


            griditens.Columns[0].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            griditens.Columns[5].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            griditens.Columns[6].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            griditens.Columns[7].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleLeft;
            griditens.Columns[7].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            griditens.Columns[8].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            griditens.Columns[9].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            griditens.Columns[10].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            griditens.Columns[11].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            griditens.Columns[12].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            griditens.Columns[13].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;

            griditens.Columns[8].ReadOnly = true;


            //DataGridViewButtonColumn btn = new DataGridViewButtonColumn();
            //griditens.Columns.Add(btn);
            //btn.HeaderText = "Cancelar";
            //btn.Text = "Cancelar";
            //btn.Name = "btn";
            //btn.Width = 65;
            //btn.UseColumnTextForButtonValue = true;
            //btn.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft;


            griditens.Columns[5].DefaultCellStyle.Format = "n3";
            griditens.Columns[6].DefaultCellStyle.Format = "n2";
            griditens.Columns[7].DefaultCellStyle.Format = "#.00\\%";
            griditens.Columns[8].DefaultCellStyle.Format = "n3";
            griditens.Columns[9].DefaultCellStyle.Format = "n2";
            griditens.Columns[10].DefaultCellStyle.Format = "n3";
            griditens.Columns[11].DefaultCellStyle.Format = "n2";
            griditens.Columns[12].DefaultCellStyle.Format = "n3";
            griditens.Columns[13].DefaultCellStyle.Format = "n2";

            decimal valor = 0;

            foreach (DataGridViewRow linha in griditens.Rows)
            {
                if ((linha.Cells[6].Value != DBNull.Value))
                {

                    valor += Convert.ToDecimal(linha.Cells[6].Value);
                }

            }


            Decimal valort = valor;
            string convertido = String.Format("{0:N3}", valort, 3);
            labTotal.Text = convertido;


            griditens.Refresh();


        }

        private void rbt4casas_CheckedChanged(object sender, EventArgs e)
        {
            if (rbt4casas.Checked == true)
            {

                carregarGridItens();


            }
        }
        private void carregarGridItens4Casas()
        {


            this.griditens.RowsDefaultCellStyle.BackColor = Color.LightBlue;
            this.griditens.AlternatingRowsDefaultCellStyle.BackColor = Color.Azure;


            griditens.AutoGenerateColumns = false;
            //exibe os dados no datagridview


            griditens.Columns[0].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            griditens.Columns[5].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            griditens.Columns[6].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            griditens.Columns[7].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleLeft;
            griditens.Columns[7].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            griditens.Columns[8].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            griditens.Columns[9].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            griditens.Columns[10].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            griditens.Columns[11].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            griditens.Columns[12].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            griditens.Columns[13].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;

            griditens.Columns[8].ReadOnly = true;


            //DataGridViewButtonColumn btn = new DataGridViewButtonColumn();
            //griditens.Columns.Add(btn);
            //btn.HeaderText = "Cancelar";
            //btn.Text = "Cancelar";
            //btn.Name = "btn";
            //btn.Width = 65;
            //btn.UseColumnTextForButtonValue = true;
            //btn.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft;


            griditens.Columns[5].DefaultCellStyle.Format = "n4";
            griditens.Columns[6].DefaultCellStyle.Format = "n2";
            griditens.Columns[7].DefaultCellStyle.Format = "#.00\\%";
            griditens.Columns[8].DefaultCellStyle.Format = "n4";
            griditens.Columns[9].DefaultCellStyle.Format = "n2";
            griditens.Columns[10].DefaultCellStyle.Format = "n4";
            griditens.Columns[11].DefaultCellStyle.Format = "n2";
            griditens.Columns[12].DefaultCellStyle.Format = "n4";
            griditens.Columns[13].DefaultCellStyle.Format = "n2";

            decimal valor = 0;

            foreach (DataGridViewRow linha in griditens.Rows)
            {
                if ((linha.Cells[6].Value != DBNull.Value))
                {

                    valor += Convert.ToDecimal(linha.Cells[6].Value);
                }

            }


            Decimal valort = valor;
            string convertido = String.Format("{0:N4}", valort, 4);
            labTotal.Text = convertido;





            griditens.Refresh();


        }


        private Boolean ValidaArquivo()
        {
            if (this.cmbstatus.Text == "")
            {
                MessageBox.Show("Informe o Status");
                cmbstatus.Focus();
                return false;

            }

            if (this.mskdata.Text == "  /  /")
            {
                MessageBox.Show("Inform a Data");
                mskdata.Focus();
                return false;

            }


            return true;


        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }

        private void ViewPropostaRealinhada_Load(object sender, EventArgs e)
        {

        }

        private void griditens_CellClick(object sender, DataGridViewCellEventArgs e)
        {

            if (e.RowIndex >= 0 && e.ColumnIndex == 4)
            {

                DataSet Dtm = new DataSet();
                SqlConnection Cnn = Banco.CriarConexao();
                SqlDataAdapter sql = new SqlDataAdapter("Select idmarca, nome as Marca From Marca", Cnn);

                sql.Fill(Dtm);


                var combobox = (DataGridViewComboBoxCell)griditens.CurrentRow.Cells[4];
                BindingSource bs = new BindingSource();

                combobox.DataSource = null;
                combobox.Items.Clear();
                bs.DataSource = Dtm;
                bs.DataMember = Dtm.Tables[0].TableName;
                combobox.DataSource = bs;
                combobox.DisplayMember = "Marca";
                combobox.ValueMember = "idmarca";
                // griditens.CurrentRow.Cells[4].Value = null;




            }

            if (e.RowIndex >= 0 && e.ColumnIndex == 19)
            {

                foreach (DataGridViewRow row in griditens.Rows)
                {

                    if (row.Index == e.RowIndex)
                    {
                        row.Cells["chkb"].Value = !Convert.ToBoolean(row.Cells["chkb"].EditedFormattedValue);
                        int nproposta = int.Parse(griditens.Rows[e.RowIndex].Cells[15].Value.ToString());
                        int codiditemedital = int.Parse(griditens.Rows[e.RowIndex].Cells[14].Value.ToString());
                        string edt = Convert.ToString(cbolicitacao.SelectedValue);
                        CarregaObs(codiditemedital, nproposta);
                        CarregaGridArquivos(codiditemedital);





                        int iColumn = 6;
                        int iRow = e.RowIndex;
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
              
            }
            if (e.RowIndex >= 0 && e.ColumnIndex == 26)
            {

            }
        }
        public void AlterarDadosAditivo(double qtdeaditivo, int aditivo, decimal precototal, int totaladitivo, int iditemedital, int idproposta)
        {
            try
            {

                SqlConnection Cnn = Banco.CriarConexao();

                string update = "UPDATE RealinhamentoProposta SET qtde=@qtde,vltotal=@vltotal,idusu=@idusu,aditivo=@aditivo,vladitivo=@vladitivo " +
                    "WHERE iditemedital=@iditemedital and idproposta=@idproposta";

                SqlCommand cmd = new SqlCommand(update, Cnn);
                cmd.Parameters.AddWithValue("@iditemedital", iditemedital);
                cmd.Parameters.AddWithValue("@idproposta", idproposta);
                cmd.Parameters.AddWithValue("@qtde", totaladitivo );
                cmd.Parameters.AddWithValue("@vltotal", precototal);
                cmd.Parameters.AddWithValue("@idusu", Banco.idusu);
                cmd.Parameters.AddWithValue("@aditivo",  aditivo);
                cmd.Parameters.AddWithValue("@vladitivo", qtdeaditivo);
                Cnn.Open();
                cmd.ExecuteNonQuery();
                Cnn.Close();








                //MessageBox.Show("Dados Alterados com sucesso !!", "Inclusão", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                ex.Message.ToString();
            }
            carregarGridItens();
        }


        private void CarregaObs(int item, int proposta)
        {

            string reg = "Select * FROM RealinhamentoProposta  Where RealinhamentoProposta.iditemedital=" + item + " AND RealinhamentoProposta.idproposta='" + proposta + "'";
            DataTable ds = new DataTable();
            SqlConnection Conn = Banco.CriarConexao();
            Conn.Open();

            if (Conn.State == ConnectionState.Open)
            {
                SqlCommand cmd = new SqlCommand(reg, Conn);
                SqlDataReader dr = cmd.ExecuteReader();
                if (dr.Read())
                {

                    this.txtobs.Text = dr["obs"].ToString();



                }
            }

        }

        private void griditens_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {


            //coditems = Convert.ToInt32(griditens[14, e.RowIndex].Value.ToString());
            //ViewProduto frcont = new ViewProduto(this);
            //frcont.Show();
            //this.Close();


        }

        private void griditens_MultiSelectChanged(object sender, EventArgs e)
        {



        }

        private void griditens_Validated(object sender, EventArgs e)
        {

        }

        private void rbt3casas_CheckedChanged(object sender, EventArgs e)
        {
            if (rbt3casas.Checked == true)
            {

                carregarGridItens3Casas();


            }
        }

        private void griditens_MouseHover(object sender, EventArgs e)
        {

        }

        private void toolTip1_Draw(object sender, DrawToolTipEventArgs e)
        {
            e.DrawBackground();
            e.DrawBorder();
            e.DrawText();
        }

        private void griditens_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {


         

                 

                
                //foreach (DataGridViewRow linhas in griditens.Rows)
                //{
                //    string valida5 = linhas.Cells[5].Value.ToString();
                //    if (valida5 == "")
                //    {
                //        linhas.Cells[5].Value = 0;
                //    }
                //    decimal cell5 = Convert.ToDecimal(linhas.Cells[5].Value);
                //    decimal cell3 = Convert.ToDecimal(linhas.Cells[3].Value);
                //    decimal cell8 = Convert.ToDecimal(linhas.Cells[8].Value);


                //    string valida8 = linhas.Cells[8].Value.ToString();
                //    decimal cell7 = Convert.ToDecimal(linhas.Cells[7].Value);


                //    if (valida8 == "")
                //    {
                //        griditens.CurrentRow.Cells[8].Value = 0;
                //    }
                //    decimal repasse = Convert.ToDecimal(linhas.Cells[8].Value);


                //    if (cell5.ToString() != "")
                //    {


                //        linhas.Cells[5].Value = ((cell8 * cell7) / 100 + cell8);
                //        cell5 = Convert.ToDecimal(linhas.Cells[5].Value);
                //        decimal precototal = cell5 * cell3;
                //        linhas.Cells[6].Value = precototal;

                //        //casasDecimais(Convert.ToDecimal(linhas.Cells[6].Value));

                //        linhas.Cells[9].Value = cell8 * cell3;

                //        //linhas.Cells[10].Value = linhas.Cells[5].Value;

                //        //linhas.Cells[11].Value = linhas.Cells[6].Value;

                //        //linhas.Cells[12].Value = linhas.Cells[5].Value;

                //        //linhas.Cells[13].Value = linhas.Cells[6].Value;

                //    }
                //}

                //carregarGridItens();

            
        }
        public int codlic;
        public string totalgeral;
        public decimal valoritem = 0;
        private void BtnImprimirProposta_Click(object sender, EventArgs e)
        {


            codlic = Convert.ToInt32(cbolicitacao.SelectedValue);
            RetornaValorTotal();
            Decimal valort = 0;
            valort = valoritem;
            string convertido = String.Format("{0:N2}", valort, 2);


            totalgeral = convertido;

            RelRealinhamentoProposta proposta = new RelRealinhamentoProposta(this);
            proposta.Show();
        }

        private void btnPesquisar_Click(object sender, EventArgs e)
        {
            ConsGerarCotacao frmconv = new ConsGerarCotacao(this);
            this.Close();
            frmconv.Show();
        }

        private void griditens_CellBeginEdit(object sender, DataGridViewCellCancelEventArgs e)
        {

        }

        private void griditens_CellEnter(object sender, DataGridViewCellEventArgs e)
        {
            //if ((e.RowIndex != -1 && e.ColumnIndex == 20))
            //{

            //    BeginInvoke(new MethodInvoker(carregarGridItens));

            //    griditens.CurrentCell = griditens.Rows[e.RowIndex].Cells[e.ColumnIndex];



            //}

            if ((e.RowIndex != -1 && e.ColumnIndex == 5))
            {
                int iColumn = 5;
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

        private void griditens_CellValidated(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void griditens_CellMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {






        }

        private void griditens_Enter(object sender, EventArgs e)
        {


        }

        private void griditens_KeyPress(object sender, KeyPressEventArgs e)
        {

        }

        private void griditens_CurrentCellDirtyStateChanged(object sender, EventArgs e)
        {


            griditens.CommitEdit(DataGridViewDataErrorContexts.Commit);





        }

        private void griditens_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {


            string comboboxSelectedValue = string.Empty;

            //if (griditens.Columns[e.ColumnIndex].GetType() == typeof(DataGridViewComboBoxColumn))
            //   comboboxSelectedValue = griditens.Rows[e.RowIndex].Cells[4].Value.ToString();


        }

        private void griditens_EditingControlShowing(object sender, DataGridViewEditingControlShowingEventArgs e)
        {



        }

        private void griditens_DataError(object sender, DataGridViewDataErrorEventArgs e)
        {
            e.Cancel = true;
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
                    string query = "Select arq,extensao,nomearq from DocumentoRealinhamento Where iddocrealinhamento = " + codarquivo;
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
        }


        private void GravarArquivo()
        {


            if (ValidaArquivo() == true)
            {
                foreach (DataGridViewRow row in griditens.Rows)
                {

                    if (bool.Parse(row.Cells[19].EditedFormattedValue.ToString()) == true)
                    {

                        VlArquivoRealinhamento obj = new VlArquivoRealinhamento();

                        VlArquivoRealinhamento.arq = FileData;
                        obj.nomearq = arquivo;
                        obj.idempresa = Banco.idemp;
                        obj.edital = edittal;
                        obj.extensao = extensao;
                        obj.dtdocumento = DateTime.Now.ToString("dd/MM/yyyy");
                        obj.idusu = Banco.idusu;
                        obj.iditemedital = Convert.ToInt32(row.Cells[14].Value);
                        obj.data = mskdata.Text;
                        obj.status = cmbstatus.Text;
                        obj.idedital = Convert.ToInt32(cbolicitacao.SelectedValue);



                        try
                        {
                            PsArquivoRealinhamento PsArquivosbll = new PsArquivoRealinhamento();
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



                SqlDataAdapter da = new SqlDataAdapter("Select DISTINCT DocumentoRealinhamento.iddocrealinhamento as Cod,DocumentoRealinhamento.nomearq as Documento,DocumentoRealinhamento.iditemedital as coditemedt,DocumentoRealinhamento.Data as Data, DocumentoRealinhamento.Status as Status" +
                " from DocumentoRealinhamento,Proposta Where Proposta.edital = DocumentoRealinhamento.edital AND DocumentoRealinhamento.edital ='" + cbolicitacao.SelectedValue + "' AND " +
                "DocumentoRealinhamento.iditemedital=" + codiditemedital + " Order by DocumentoRealinhamento.data ASC ", Conn);

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
                Grid.Columns.Add("Data", "Data");
                Grid.Columns.Add("Status", "Status");
                Grid.Columns.Add("coditemedt", "coditemedt");
                Grid.Columns[0].Width = 50;
                Grid.Columns[1].Width = 50;
                Grid.Columns[2].Width = 245;
                Grid.Columns[3].Width = 100;
                Grid.Columns[4].Width = 200;
                Grid.Columns[5].Visible = false;

                Grid.Columns[1].DataPropertyName = "Cod";
                Grid.Columns[2].DataPropertyName = "Documento";
                Grid.Columns[3].DataPropertyName = "Data";
                Grid.Columns[4].DataPropertyName = "Status";
                Grid.Columns[5].DataPropertyName = "coditemedt";

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

        private void Grid_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            codarquivo = Convert.ToInt32(Grid.CurrentRow.Cells[1].Value.ToString());


            SqlConnection Cnn = Banco.CriarConexao();
            string query = "Select arq,extensao,nomearq from DocumentoRealinhamento Where DocumentoRealinhamento.iddocrealinhamento = " + Convert.ToInt32(Grid[1, e.RowIndex].Value.ToString());

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

        private void btnEmpenho_Click(object sender, EventArgs e)
        {
            foreach (DataGridViewRow row in griditens.Rows)
            {

                if (bool.Parse(row.Cells[19].EditedFormattedValue.ToString()))
                {

                    coditemempenho = Convert.ToInt32(row.Cells[14].Value);
                    editalempenho = Convert.ToString(cbolicitacao.SelectedValue);
                    ViewInformacaoEmpenho frminfoempenho = new ViewInformacaoEmpenho(this);
                    frminfoempenho.Show();


                }
            }
        }

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
                            int codi = int.Parse(Grid.Rows[e.RowIndex].Cells[5].Value.ToString());
                            VlArquivoRealinhamento obj = new VlArquivoRealinhamento();

                            obj.iddocrealinhamento = coda;

                            PsArquivoRealinhamento DAOArquivos = new PsArquivoRealinhamento();
                            DAOArquivos.Exluir(obj.iddocrealinhamento);


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
        private void checkImprimirTodos_CheckedChanged(object sender, EventArgs e)
        {
           
            foreach (DataGridViewRow linha in griditens.Rows)
            {
                if (bool.Parse(linha.Cells[19].EditedFormattedValue.ToString()) == true)

                    if (checkImprimirTodos.Checked == true)
                    {
                        int codproposta = Convert.ToInt32(linha.Cells[15].Value);

                        checkNaoImprimirTodos.Checked = false;

                        linha.Cells[22].Value = "SIM";

                        string imprimir = "SIM";

                       

                        AlterarDadosNoClick(imprimir);

                    }
            }
        }

        private void checkNaoImprimirTodos_CheckedChanged(object sender, EventArgs e)
        {

            foreach (DataGridViewRow linha in griditens.Rows)
            {
                if (bool.Parse(linha.Cells[19].EditedFormattedValue.ToString()) == true)

                    if (checkNaoImprimirTodos.Checked == true)
                    {
                        int codproposta = Convert.ToInt32(linha.Cells[15].Value);

                        checkImprimirTodos.Checked = false;

                        linha.Cells[22].Value = "NAO";

                        //AlterarDadosImpressao(codproposta, linha.Cells[22].Value.ToString());

                        string imprimir = "NAO";
                     

                        AlterarDadosNoClick(imprimir);

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
                PsBancobll.AlterarRealinhamento(obj);

            }
            catch (Exception erro)
            {

                throw erro;
            }

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
                string strConn = "Select DISTINCT ItemsLicitacao.nritem as Item,CONVERT(varchar(10),ItemsLicitacao.nritem)  + ' - ' + PrincipioAtivo.nome + ' - ' + Produto.nome + ' - ' + Produto.apresentacao  as Descrição,UnidadeMedida.nome as Unidade,RealinhamentoProposta.qtde as Qtde,Marca.idmarca as idmarca,RealinhamentoProposta.vlvenda as PreçoUnit,RealinhamentoProposta.vltotal as PreçoTotal,RealinhamentoProposta.margemfinal as MargFinal," +
                    "CASE WHEN LancEditais.casasdecimais = 2 THEN ROUND(RealinhamentoProposta.vlcusto,2) WHEN LancEditais.casasdecimais = 3 THEN ROUND(RealinhamentoProposta.vlcusto,3)" +
               " WHEN LancEditais.casasdecimais = 4 THEN ROUND(RealinhamentoProposta.vlcusto,4)  WHEN LancEditais.casasdecimais = 5 THEN ROUND(RealinhamentoProposta.vlcusto,5)" +
                " WHEN  LancEditais.casasdecimais = 6 THEN ROUND(RealinhamentoProposta.vlcusto,6) END AS Custo,RealinhamentoProposta.total as Total_Custo,RealinhamentoProposta.entrada as Entrada,RealinhamentoProposta.totalg as TotalGeral, RealinhamentoProposta.minimounit as MinimoUnit,RealinhamentoProposta.minimototal as MinimoTotal,RealinhamentoProposta.obs as Obs, LancEditais.nlicitacao, " +
                    "ItemsLicitacao.iditemedital as Cod,RealinhamentoProposta.idproposta as Id, PrincipioAtivo.idprincipio as idpricipio,Produto.idproduto as idproduto,RealinhamentoProposta.idrealinhamento as idrealinhamento,RealinhamentoProposta.aditivo as Aditivo,RealinhamentoProposta.vladitivo as QtdAdtvo,RealinhamentoProposta.imprimir as Imprimir,Produto.idproduto,RealinhamentoProposta.ganhou as Ganhou " +
                " From  ItemsLicitacao LEFT JOIN RealinhamentoProposta ON ItemsLicitacao.iditemedital = RealinhamentoProposta.iditemedital, UnidadeMedida,PrincipioAtivo,Produto,Fornecedor,LancEditais,Fabricante,Proposta,Marca,RetCotacao Where LancEditais.idedital = ItemsLicitacao.idedital AND  Produto.idprincipio = PrincipioAtivo.idprincipio AND " +
                "ItemsLicitacao.idprincipio = PrincipioAtivo.idprincipio AND ItemsLicitacao.idunidade = UnidadeMedida.idunidade AND RealinhamentoProposta.idmarca = Marca.idmarca AND Proposta.idproposta = RealinhamentoProposta.idproposta AND RetCotacao.iditemedital = RealinhamentoProposta.iditemedital AND RetCotacao.idedital = RealinhamentoProposta.idedital AND " +
                "Produto.idproduto = ItemsLicitacao.idproduto AND Proposta.idfornecedor= Fornecedor.idfornecedor AND Marca.idfabricante = Fabricante.idfabricante AND ItemsLicitacao.idedital=" + cbolicitacao.SelectedValue + " AND Produto.nome Like'" + txtpesquisa.Text + "%' Order by ItemsLicitacao.nritem";


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
            griditens.Columns.Add("Item", "Item");
            griditens.Columns.Add("Descrição", "Descrição");
            griditens.Columns.Add("Unidade", "Unidade");
            griditens.Columns.Add("Qtde", "Qtde");

            DataRow[] rows = ds.Select();

            DataGridViewComboBoxColumn Marca = new DataGridViewComboBoxColumn();

            for (int i = 0; i < rows.Length; i++)
            {
                DataSet Dtm = new DataSet();
                SqlConnection Cnn = Banco.CriarConexao();
                SqlDataAdapter sql = new SqlDataAdapter("Select Marca.idmarca, Marca.nome as Marca From ItemsLicitacao,Marca" +
                    " WHERE ItemsLicitacao.idmarca = Marca.idmarca ", Cnn);


                sql.Fill(Dtm);



                BindingSource bs = new BindingSource();

                bs.DataSource = Dtm;
                bs.DataMember = Dtm.Tables[0].TableName;
                Marca.DataSource = new BindingSource(bs, null);
                Marca.DisplayMember = "Marca";
                Marca.ValueMember = "idmarca";
                Marca.HeaderText = "Marca";
                Marca.FlatStyle = FlatStyle.Flat;
                Marca.DataPropertyName = "Marca";



                //if (Marca == null)
                //   return;



                //DataGridViewComboBoxCell comboCell = new DataGridViewComboBoxCell();
                //comboCell.DisplayMember = "Marca";
                //comboCell.ValueMember = "idfabricante";
                //comboCell.DataSource = Dtm;
                //griditens.Columns.Add(comboCell);
            };
            griditens.Columns.Insert(4, Marca);

            griditens.Columns.Add("PreçoUnit", "PreçoUnit");
            griditens.Columns.Add("PreçoTotal", "PreçoTotal");
            griditens.Columns.Add("MargFinal", "MargFinal");
            griditens.Columns.Add("Custo", "Custo");
            griditens.Columns.Add("Total_Custo", "Total_Custo");
            griditens.Columns.Add("Entrada", "Entrada");
            griditens.Columns.Add("TotalGeral", "TotalGeral");
            griditens.Columns.Add("MinimoUnit", "MinimoUnit");
            griditens.Columns.Add("MinimoTotal", "MinimoTotal");
            griditens.Columns.Add("Cod", "Cod");
            griditens.Columns.Add("Id", "Id");
            griditens.Columns.Add("idpricipio", "idpricipio");
            griditens.Columns.Add("idproduto", "idproduto");
            griditens.Columns.Add("idrealinhamento", "idrealinhamento");
            griditens.Columns.Add(chkb);
            chkb.HeaderText = "Sel";
            chkb.Name = "chkb";
            chkb.Width = 40;

            griditens.Columns.Add("Aditivo", "Aditivo");
            griditens.Columns.Add("QtdAdtvo", "QtdAdtvo");
            //DataTable data = new DataTable();

            //data.Columns.Add(new DataColumn("Value", typeof(string)));
            //data.Columns.Add(new DataColumn("Description", typeof(string)));

            //data.Rows.Add("SIM", "SIM");
            //data.Rows.Add("NAO", "NAO");
            //column.DataSource = data;
            //column.HeaderText = "Imprimir?";
            //column.ValueMember = "Value";
            //column.DisplayMember = "Description";
            //column.Width = 60;
            griditens.Columns.Add("Imprimir", "Imprimir");
            griditens.Columns.Insert(22, column);
            griditens.Columns.Add("idproduto", "idproduto");
            griditens.Columns.Add("nlicitacao", "nlicitacao");
            griditens.Columns.Add("Ganhou", "Ganhou");



            griditens.Columns[0].Visible = false;
            griditens.Columns[1].Width = 210;
            griditens.Columns[2].Width = 60;
            griditens.Columns[3].Width = 60;
            griditens.Columns[4].Width = 150;
            griditens.Columns[5].Width = 70;
            griditens.Columns[6].Width = 80;
            griditens.Columns[7].Width = 70;
            griditens.Columns[8].Width = 60;
            griditens.Columns[9].Width = 75;
            griditens.Columns[10].Width = 70;
            griditens.Columns[11].Width = 80;
            griditens.Columns[12].Visible = false;
            griditens.Columns[13].Visible = false;
            griditens.Columns[14].Visible = false;
            griditens.Columns[15].Visible = false;
            griditens.Columns[16].Visible = false;
            griditens.Columns[17].Visible = false;
            griditens.Columns[18].Visible = false;
            griditens.Columns[20].Width = 60;
            griditens.Columns[21].Width = 70;
            griditens.Columns[22].Width = 60;
            griditens.Columns[23].Visible = false;
            griditens.Columns[24].Visible = false;
            griditens.Columns[25].Width = 65;
          

            griditens.Columns[0].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;

            griditens.Columns[3].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
            griditens.Columns[3].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;

            griditens.Columns[5].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            griditens.Columns[6].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            griditens.Columns[7].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleLeft;
            griditens.Columns[7].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            griditens.Columns[8].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            griditens.Columns[9].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            griditens.Columns[10].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            griditens.Columns[11].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            griditens.Columns[12].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            griditens.Columns[13].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;

            griditens.Columns[20].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            griditens.Columns[21].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;



            griditens.Columns[0].DataPropertyName = "Item";
            griditens.Columns[1].DataPropertyName = "Descrição";
            griditens.Columns[2].DataPropertyName = "Unidade";
            griditens.Columns[3].DataPropertyName = "Qtde";
            griditens.Columns[4].DataPropertyName = "idmarca";
            griditens.Columns[5].DataPropertyName = "PreçoUnit";
            griditens.Columns[6].DataPropertyName = "PreçoTotal";
            griditens.Columns[7].DataPropertyName = "MargFinal";
            griditens.Columns[8].DataPropertyName = "Custo";
            griditens.Columns[9].DataPropertyName = "Total_Custo";
            griditens.Columns[10].DataPropertyName = "Entrada";
            griditens.Columns[11].DataPropertyName = "TotalGeral";
            griditens.Columns[12].DataPropertyName = "MinimoUnit";
            griditens.Columns[13].DataPropertyName = "MinimoTotal";
            griditens.Columns[14].DataPropertyName = "Cod";
            griditens.Columns[15].DataPropertyName = "Id";
            griditens.Columns[16].DataPropertyName = "idpricipio";
            griditens.Columns[17].DataPropertyName = "idproduto";
            griditens.Columns[18].DataPropertyName = "idrealinhamento";
            griditens.Columns[20].DataPropertyName = "Aditivo";
            griditens.Columns[21].DataPropertyName = "QtdAdtvo";
            griditens.Columns[22].DataPropertyName = "Imprimir";
            griditens.Columns[23].DataPropertyName = "idproduto";
            griditens.Columns[24].DataPropertyName = "nlicitacao";
            griditens.Columns[25].DataPropertyName = "Ganhou";

            griditens.Columns[8].ReadOnly = true;
            griditens.Columns[21].ReadOnly = true;
            griditens.Columns[3].ReadOnly = true;
            griditens.Columns[10].ReadOnly = true;


            DataGridViewButtonColumn btn = new DataGridViewButtonColumn();
            griditens.Columns.Add(btn);
            btn.HeaderText = "Estornar";
            btn.Text = "Estornar";
            btn.Name = "btn";
            btn.Width = 60;
            btn.UseColumnTextForButtonValue = true;
            btn.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft;
            btn.Visible = false;

            decimal valor = 0;


            if (casas == 2)
            {
                rbt2casas.Checked = true;
                griditens.Columns[5].DefaultCellStyle.Format = "n2";
                griditens.Columns[6].DefaultCellStyle.Format = "n2";
                griditens.Columns[7].DefaultCellStyle.Format = "#.00\\%";
                griditens.Columns[8].DefaultCellStyle.Format = "n2";
                griditens.Columns[9].DefaultCellStyle.Format = "n2";
                griditens.Columns[10].DefaultCellStyle.Format = "n2";
                griditens.Columns[11].DefaultCellStyle.Format = "n2";
                griditens.Columns[12].DefaultCellStyle.Format = "n2";
                griditens.Columns[13].DefaultCellStyle.Format = "n2";
                griditens.Columns[20].DefaultCellStyle.Format = "#.00\\%";
                // griditens.Columns[21].DefaultCellStyle.Format = "n2";



                foreach (DataGridViewRow linha in griditens.Rows)
                {
                    if ((linha.Cells[6].Value != DBNull.Value))
                    {

                        valor += Convert.ToDecimal(linha.Cells[6].Value);
                    }

                }


                Decimal valort = valor;
                string convertido = String.Format("{0:N2}", valort, 2);
                labTotal.Text = convertido;


            }
            else if (casas == 3)
            {
                rbt3casas.Checked = true;
                griditens.Columns[5].DefaultCellStyle.Format = "n3";
                griditens.Columns[6].DefaultCellStyle.Format = "n2";
                griditens.Columns[7].DefaultCellStyle.Format = "#.00\\%";
                griditens.Columns[8].DefaultCellStyle.Format = "n3";
                griditens.Columns[9].DefaultCellStyle.Format = "n2";
                griditens.Columns[10].DefaultCellStyle.Format = "n3";
                griditens.Columns[11].DefaultCellStyle.Format = "n2";
                griditens.Columns[12].DefaultCellStyle.Format = "n3";
                griditens.Columns[13].DefaultCellStyle.Format = "n2";
                griditens.Columns[20].DefaultCellStyle.Format = "#.00\\%";
                //  griditens.Columns[21].DefaultCellStyle.Format = "n3";

                foreach (DataGridViewRow linha in griditens.Rows)
                {
                    if ((linha.Cells[11].Value != DBNull.Value))
                    {

                        valor += Convert.ToDecimal(linha.Cells[11].Value);
                    }

                }


                Decimal valort = valor;
                string convertido = String.Format("{0:N3}", valort, 3);
                labTotal.Text = convertido;








            }
            else if (casas == 4)
            {
                rbt4casas.Checked = true;
                griditens.Columns[5].DefaultCellStyle.Format = "n4";
                griditens.Columns[6].DefaultCellStyle.Format = "n2";
                griditens.Columns[7].DefaultCellStyle.Format = "#.00\\%";
                griditens.Columns[8].DefaultCellStyle.Format = "n4";
                griditens.Columns[9].DefaultCellStyle.Format = "n2";
                griditens.Columns[10].DefaultCellStyle.Format = "n4";
                griditens.Columns[11].DefaultCellStyle.Format = "n2";
                griditens.Columns[12].DefaultCellStyle.Format = "n4";
                griditens.Columns[13].DefaultCellStyle.Format = "n2";
                griditens.Columns[20].DefaultCellStyle.Format = "#.00\\%";
                // griditens.Columns[21].DefaultCellStyle.Format = "n4";



                foreach (DataGridViewRow linha in griditens.Rows)
                {
                    if ((linha.Cells[6].Value != DBNull.Value))
                    {

                        valor += Convert.ToDecimal(linha.Cells[6].Value);
                    }

                }


                Decimal valort = valor;
                string convertido = String.Format("{0:N4}", valort, 4);
                labTotal.Text = convertido;


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

        private void button1_Click(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {

        }

        private void chkTodos_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void chkTodos_CheckedChanged_1(object sender, EventArgs e)
        {
            foreach (DataGridViewRow row in griditens.Rows)
            {
                DataGridViewCheckBoxCell chkb = (DataGridViewCheckBoxCell)row.Cells[19];
                chkb.Value = !(chkb.Value == null ? false : (bool)chkb.Value); //because chk.Value is initialy null
            }
        }


        private void RetornaValorTotal()
        {

            valoritem = 0;

            string reg = "Select RealinhamentoProposta.vltotal From  ItemsLicitacao LEFT JOIN RealinhamentoProposta ON ItemsLicitacao.iditemedital = RealinhamentoProposta.iditemedital," +
                "UnidadeMedida,PrincipioAtivo,Produto,Fornecedor,LancEditais,Fabricante,Proposta,Marca Where LancEditais.idedital = ItemsLicitacao.idedital " +
                "AND Produto.idprincipio = PrincipioAtivo.idprincipio AND ItemsLicitacao.idprincipio = PrincipioAtivo.idprincipio AND ItemsLicitacao.idunidade = UnidadeMedida.idunidade " +
                "AND RealinhamentoProposta.idmarca = Marca.idmarca AND Proposta.idproposta = RealinhamentoProposta.idproposta AND Produto.idproduto = ItemsLicitacao.idproduto " +
                "AND Proposta.idfornecedor = Fornecedor.idfornecedor AND Marca.idfabricante = Fabricante.idfabricante AND RealinhamentoProposta.idedital  =" + UltimoSelecionado + " AND imprimir = 'SIM' order by ItemsLicitacao.nritem";
            DataTable ds = new DataTable();
            SqlConnection Conn = Banco.CriarConexao();
            Conn.Open();

            if (Conn.State == ConnectionState.Open)
            {
                SqlCommand cmd = new SqlCommand(reg, Conn);
                SqlDataReader dr = cmd.ExecuteReader();
                while (dr.Read())
                {
                    valoritem += Convert.ToDecimal(dr["vltotal"].ToString());

                }
            }
        }

        private void btnImprimir_Itens_Click(object sender, EventArgs e)
        {
            codlic = Convert.ToInt32(cbolicitacao.SelectedValue);
            RetornaValorTotal();
            Decimal valort = 0;
            valort = valoritem;
            string convertido = String.Format("{0:N2}", valort, 2);


            totalgeral = convertido;

            RelRealinhamentoPropostaItem proposta = new RelRealinhamentoPropostaItem(this);
            proposta.Show();
        }

        private void griditens_KeyDown(object sender, KeyEventArgs e)
        {
            //e.SuppressKeyPress = true;
            //int iColumn = griditens.CurrentCell.ColumnIndex;
            //int iRow = griditens.CurrentCell.RowIndex;
            //if (iColumn == griditens.ColumnCount - 1)
            //{
            //    if (griditens.RowCount > (iRow + 1))
            //    {
            //        griditens.CurrentCell = griditens[1, iRow + 1];
            //    }
            //    else
            //    {
            //        //focus next control
            //    }
            //}
            //else
            //    griditens.CurrentCell = griditens[iColumn + 1, iRow];

        }

        private void chkganhou_CheckedChanged(object sender, EventArgs e)
        {
            foreach (DataGridViewRow linha in griditens.Rows)
            {
                if (bool.Parse(linha.Cells[19].EditedFormattedValue.ToString()) == true)

                    if (chkganhou.Checked == true)
                    {
                        int codproposta = Convert.ToInt32(linha.Cells[15].Value);

                        checkNaoImprimirTodos.Checked = false;


                        string ganhou = "SIM";


                        AlterarDadosGanhou(ganhou);

                    }
            }
        }

        private void chknaoganhou_CheckedChanged(object sender, EventArgs e)
        {
            foreach (DataGridViewRow linha in griditens.Rows)
            {
                if (bool.Parse(linha.Cells[19].EditedFormattedValue.ToString()) == true)

                    if (this.chknaoganhou.Checked == true)
                    {
                        int codproposta = Convert.ToInt32(linha.Cells[15].Value);

                        checkNaoImprimirTodos.Checked = false;

                        string ganhou = "NAO";


                        AlterarDadosGanhou(ganhou);

                    }
            }
        }

        private void button9_Click(object sender, EventArgs e)
        {
          
        }
    }
}
