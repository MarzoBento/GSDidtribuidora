using Microsoft.Reporting.WinForms;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Data.SqlTypes;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Prj_Cientifica
{
    public partial class ViewGerarCotacao : Form
    {
        public static string TipoGravacao;
        public  int UltimoSelecionado;
        public ReportViewer relatorio;

        public string nomeFor = "ViewGerarCotacao";
        public ViewGerarCotacao()
        {
            InitializeComponent();
        }

        public ViewGerarCotacao(ConsGerarCotacao frm) : this()
        {
            UltimoSelecionado = Convert.ToInt32(frm.codedital);
            RetReg();


        }


        private void RetReg()
        {
            string reg = "Select * from LancEditais Where idedital =" + UltimoSelecionado + "";
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
                    carregarGriFornecedores();



                }
            }
        }



        private void CarregarLicitacao()
        {
            SqlConnection Cnn = Banco.CriarConexao();
            SqlDataAdapter sql = new SqlDataAdapter("Select LancEditais.nlicitacao,(CAST(LancEditais.nlicitacao AS VARCHAR(10))) + '               ' + (Modalidade.nome + '                    ' +  LancEditais.nlicitacao + '                        ' + " +
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
                this.cbolicitacao.ValueMember = "nlicitacao";
                this.cbolicitacao.SelectedIndex = cbolicitacao.Items.Count - 1;



            }
            catch (Exception erro)
            {

                throw erro;
            }
            Cnn.Close();
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

        private void cbolicitacao_Click(object sender, EventArgs e)
        {
            CarregarLicitacao();
        }

        DataGridViewCheckBoxColumn chk = new DataGridViewCheckBoxColumn();
        public Decimal valor;
        private void carregarGriFornecedores()
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
                string strConn = "Select DISTINCT Fornecedor.idfornecedor as Cod,Fornecedor.nome as Fornecedor" +
                " from ItemsLicitacao,Fornecedor,Produto,LancEditais,Produto_Fornecedor Where ItemsLicitacao.idprincipio = Produto.idprincipio and Produto_Fornecedor.idfornecedor = Fornecedor.idfornecedor " +
                " AND ItemsLicitacao.idproduto = Produto_Fornecedor.idproduto AND ItemsLicitacao.nlicitacao = LancEditais.nlicitacao AND  ItemsLicitacao.idedital=" + cbolicitacao.SelectedValue + "  Order by Fornecedor.nome ASC";

                SqlDataAdapter da = new SqlDataAdapter(strConn, Conn);
                da.Fill(ds);


            }

            this.GridFor.RowsDefaultCellStyle.BackColor = Color.LightBlue;
            this.GridFor.AlternatingRowsDefaultCellStyle.BackColor = Color.Azure;


            GridFor.AutoGenerateColumns = false;
            //exibe os dados no datagridview
            GridFor.DataSource = ds;
            GridFor.Columns.Clear();
            GridFor.Columns.Add(chk);
            chk.HeaderText = "Sel";
            chk.Name = "chk";
            GridFor.Columns.Add("Cod", "Cod");
            GridFor.Columns.Add("Fornecedor", "Fornecedor");


            GridFor.Columns[0].Width = 50;
            GridFor.Columns[1].Width = 80;
            GridFor.Columns[2].Width = 580;

            GridFor.Columns[1].DataPropertyName = "Cod";
            GridFor.Columns[2].DataPropertyName = "Fornecedor";

            //DataGridViewButtonColumn btn = new DataGridViewButtonColumn();
            //GridFor.Columns.Add(btn);
            //btn.HeaderText = "Excluir";
            //btn.Text = "Excluir";
            //btn.Name = "btn";
            //btn.Width = 50;
            //btn.UseColumnTextForButtonValue = true;
            //btn.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft;

            valor = 0;

            //foreach (DataGridViewRow linha in griditens.Rows)
            //{
            //    valor += Convert.ToDecimal(linha.Cells[8].Value);

            //}

            //this.txttotalgeral.Text = Convert.ToDecimal(valor).ToString();



            GridFor.Refresh();


            //foreach (DataGridViewRow linhatotal in griditens.Rows)
            //{
            //    total = total + 1;
            //}

            //this.txttotalitens.Text = Convert.ToString(total);
        }

        private void ViewGerarCotacao_Load(object sender, EventArgs e)
        {

        }

        private void cbolicitacao_SelectionChangeCommitted(object sender, EventArgs e)
        {
            carregarGriFornecedores();
        }

        public int codfor;
        private void GridFor_CellClick(object sender, DataGridViewCellEventArgs e)
        {

            if (e.RowIndex >= 0 && e.ColumnIndex == 0)
            {
                //Loop and uncheck all other CheckBoxes.
                foreach (DataGridViewRow row in GridFor.Rows)
                {
                    if (row.Index == e.RowIndex)
                    {
                        row.Cells["chk"].Value = !Convert.ToBoolean(row.Cells["chk"].EditedFormattedValue);
                        codfor = int.Parse(GridFor.Rows[e.RowIndex].Cells[1].Value.ToString());
                        carregarGridItens(codfor);
                    }
                    else
                    {
                        row.Cells["chk"].Value = false;
                    }
                }
            }


        }

        DataGridViewCheckBoxColumn chkb = new DataGridViewCheckBoxColumn();

        private void carregarGridItens(int codfor)
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
                string strConn = "Select DISTINCT ItemsLicitacao.iditemedital as Cod,ItemsLicitacao.nritem as NºItem,ItemsLicitacao.lote as Lote,Produto.nome as Item, UnidadeMedida.nome as Unidade,ItemsLicitacao.qtde as Qtde," +
                     "Produto.apresentacao as Apresentacao, ItemsLicitacao.statuscotacao as Cotar,Produto_Fornecedor.idfornecedor as codfor,Produto_Fornecedor.idproduto as codprod" +
                 " from ItemsLicitacao,UnidadeMedida,PrincipioAtivo,Produto,Fornecedor,LancEditais,Produto_Fornecedor Where LancEditais.idedital = ItemsLicitacao.idedital AND  Produto.idprincipio = PrincipioAtivo.idprincipio AND ItemsLicitacao.idprincipio = PrincipioAtivo.idprincipio " +
                 "AND ItemsLicitacao.idunidade = UnidadeMedida.idunidade AND Produto.idproduto = ItemsLicitacao.idproduto AND Produto_Fornecedor.idproduto = ItemsLicitacao.idproduto AND  Produto_Fornecedor.idfornecedor=" + codfor + "  AND LancEditais.idedital=" + cbolicitacao.SelectedValue + "";



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
            griditens.Columns.Add("Lote", "Lote");
            griditens.Columns.Add("Item", "Item");
            griditens.Columns.Add("Qtde", "Qtde");
            griditens.Columns.Add("Unidade", "Unidade");
            griditens.Columns.Add("Apresentacao", "Apresentacao");
            griditens.Columns.Add("Cotar", "Cotar");
            griditens.Columns.Add("codfor", "codfor");
            griditens.Columns.Add("codprod", "codprod");

            griditens.Columns[0].Width = 50;
            griditens.Columns[1].Width = 50;
            griditens.Columns[2].Width = 80;
            griditens.Columns[3].Width = 80;
            griditens.Columns[4].Width = 400;
            griditens.Columns[5].Width = 70;
            griditens.Columns[6].Width = 150;
            griditens.Columns[7].Width = 150;
            griditens.Columns[8].Width = 70;
            griditens.Columns[9].Visible = false;
            griditens.Columns[10].Visible = false;


            griditens.Columns[1].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft;
            griditens.Columns[5].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft;
            griditens.Columns[4].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft;


            griditens.Columns[1].DataPropertyName = "Cod";
            griditens.Columns[2].DataPropertyName = "NºItem";
            griditens.Columns[3].DataPropertyName = "Lote";
            griditens.Columns[4].DataPropertyName = "Item";
            griditens.Columns[5].DataPropertyName = "Qtde";
            griditens.Columns[6].DataPropertyName = "Unidade";
            griditens.Columns[7].DataPropertyName = "Apresentacao";
            griditens.Columns[8].DataPropertyName = "Cotar";
            griditens.Columns[9].DataPropertyName = "codfor";
            griditens.Columns[10].DataPropertyName = "codprod";

            DataGridViewButtonColumn btn = new DataGridViewButtonColumn();
            griditens.Columns.Add(btn);
            btn.HeaderText = "Cancelar";
            btn.Text = "Cancelar";
            btn.Name = "btn";
            btn.Width = 65;
            btn.UseColumnTextForButtonValue = true;
            btn.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft;

            griditens.Refresh();


        }

        private void GridFor_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void GridFor_CellMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {

        }

        public string codi;
        private void BtnCotar_Click(object sender, EventArgs e)
        {
            foreach (DataGridViewRow row in griditens.Rows)
            {

                if (bool.Parse(row.Cells[0].EditedFormattedValue.ToString()))
                {

                    VlItemLicitacao obj = new VlItemLicitacao();
                    obj.idproduto = Convert.ToInt32(row.Cells[10].Value);
                    obj.statuscotacao = "SIM";
                    obj.idusu = Banco.idusu;
                    obj.idfornecedor = Convert.ToInt32(row.Cells[9].Value);
                    obj.idedital = Convert.ToInt32(cbolicitacao.SelectedValue);



                    //VlItemCotacao objcotacao = new VlItemCotacao();
                    //objcotacao.idproduto = Convert.ToInt32(row.Cells[10].Value);
                    //objcotacao.statuscotacao = "SIM";
                    //objcotacao.idusu = Banco.idusu;
                    //objcotacao.idfornecedor = Convert.ToInt32(row.Cells[9].Value);
                    //objcotacao.edital = Convert.ToString(cbolicitacao.SelectedValue);

                    try
                    {
                        PsItemLicitacao DAOLicitacao = new PsItemLicitacao();
                        DAOLicitacao.AlterarCotacao(obj);

                        //if (VerificaRegistroExisteCotacao(objcotacao.idproduto, objcotacao.idfornecedor, objcotacao.edital) == true)
                        //{

                        //    PsItemCotacao DAOCotacao = new PsItemCotacao();
                        //    DAOCotacao.Incluir(objcotacao);

                        //}
                        //else
                        //{


                        //    PsItemCotacao DAOCotacao = new PsItemCotacao();
                        //    DAOCotacao.Alterar(objcotacao);

                        //}






                    }
                    catch (Exception erro)
                    {

                        throw erro;
                    }
                }




            }
            MessageBox.Show("Itens(s) Cotados com Sucesso!");
            GrvavaFornecedorRetorno();
            carregarGridItens(codfor);
            // GrvavaFornecedorRetorno();
            AlteraStatusLicitacao();

        }
        public int codret;
        private void GrvavaFornecedorRetorno()
        {


            try


            {


                foreach (DataGridViewRow row in griditens.Rows)
                {

                    if (bool.Parse(row.Cells[0].EditedFormattedValue.ToString()))
                    {
                        int col1 = Convert.ToInt32(row.Cells[1].Value);
                        int forcod = Convert.ToInt32(codfor);

                        codret = col1;

                        if (VerificaRegistroExisteRet(codret, forcod) == true)
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
        }



        private Boolean VerificaRegistroExisteCotacao(int idprod, int forncod, string editall)
        {

            SqlConnection Cnn = Banco.CriarConexao();
            string obter = ("Select * From ItemGerarCotacao Where idproduto = " + idprod + " And idfornecedor=" + forncod + " AND edital='" + editall + "'");
            SqlCommand sql = new SqlCommand(obter, Cnn);
            Cnn.Open();
            SqlDataReader dr = sql.ExecuteReader();
            if (dr.Read())
            {

                return false;
            }
            return true;
        }



        private Boolean VerificaRegistroExisteRet(int cod, int fcod)
        {

            SqlConnection Cnn = Banco.CriarConexao();
            string obter = ("Select * From RetCotacao Where iditemedital = " + cod + " And idfornecedor=" + fcod);
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

                    if (bool.Parse(row.Cells[0].EditedFormattedValue.ToString()) == true)
                    {
                        int col1 = Convert.ToInt32(row.Cells[1].Value);
                        int col2 = Convert.ToInt32(row.Cells[5].Value);
                        string col3 = Convert.ToString(cbolicitacao.SelectedValue);
                        int col4 = Convert.ToInt32(codfor);
                        int idprod = Convert.ToInt32(row.Cells[10].Value);



                        SqlConnection Cnn = Banco.CriarConexao();

                        string insert = "INSERT INTO RetCotacao(iditemedital,qtde,preco,desconto,repasse,ipi,frete,liquido,vltotal,idusu,idedital,idfornecedor,dtcotacao,idproduto) VALUES " +
                            "(@iditemedital,@qtde,@preco,@desconto,@repasse,@ipi,@frete,@liquido,@vltotal,@idusu,@idedital,@idfornecedor,@dtcotacao,@idproduto)";

                        SqlCommand cmd = new SqlCommand(insert, Cnn);
                        cmd.Parameters.AddWithValue("@iditemedital", col1);
                        cmd.Parameters.AddWithValue("@qtde", col2);
                        cmd.Parameters.AddWithValue("@preco", 0);
                        cmd.Parameters.AddWithValue("@desconto", 0);
                        cmd.Parameters.AddWithValue("@repasse", 0);
                        cmd.Parameters.AddWithValue("@ipi", 0);
                        cmd.Parameters.AddWithValue("@frete", 0);
                        cmd.Parameters.AddWithValue("@liquido", 0);
                        cmd.Parameters.AddWithValue("@vltotal", 0);
                        cmd.Parameters.AddWithValue("@idusu", Banco.idusu);
                        cmd.Parameters.AddWithValue("@idedital", col3);
                        cmd.Parameters.AddWithValue("@idfornecedor", col4);
                        cmd.Parameters.AddWithValue("@dtcotacao", SqlDbType.Date).Value = DateTime.Now.ToString("yyyy/MM/dd");
                        cmd.Parameters.AddWithValue("@idproduto", idprod);
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


        public void AlterarDados()
        {
            try
            {

                foreach (DataGridViewRow row in griditens.Rows)
                {

                    if (bool.Parse(row.Cells[0].EditedFormattedValue.ToString()) == true)
                    {
                        int col1 = Convert.ToInt32(row.Cells[1].Value);
                        int col2 = Convert.ToInt32(row.Cells[5].Value);
                        string col3 = Convert.ToString(cbolicitacao.SelectedValue);
                        int col4 = Convert.ToInt32(codfor);
                        int idprod = Convert.ToInt32(row.Cells[10].Value);

                        SqlConnection Cnn = Banco.CriarConexao();

                        string update = "UPDATE RetCotacao SET qtde=@qtde,preco=@preco,desconto=@desconto,repasse=@repasse,ipi=@ipi,frete=@frete,liquido=@liquido,vltotal=@vltotal," +
                            "idusu=@idusu,idedital=@idedital,dtcotacao=@dtcotacao,idproduto=@idproduto WHERE iditemedital=@iditemedital and idfornecedor=@idfornecedor";

                        SqlCommand cmd = new SqlCommand(update, Cnn);
                        cmd.Parameters.AddWithValue("@iditemedital", col1);
                        cmd.Parameters.AddWithValue("@qtde", col2);
                        cmd.Parameters.AddWithValue("@preco", 0);
                        cmd.Parameters.AddWithValue("@desconto", 0);
                        cmd.Parameters.AddWithValue("@repasse", 0);
                        cmd.Parameters.AddWithValue("@ipi", 0);
                        cmd.Parameters.AddWithValue("@frete", 0);
                        cmd.Parameters.AddWithValue("@liquido", 0);
                        cmd.Parameters.AddWithValue("@vltotal", 0);
                        cmd.Parameters.AddWithValue("@idusu", Banco.idusu);
                        cmd.Parameters.AddWithValue("@idedital", col3);
                        cmd.Parameters.AddWithValue("@idfornecedor", col4);
                        cmd.Parameters.AddWithValue("@dtcotacao", SqlDbType.Date).Value = DateTime.Now.ToString("yyyy/MM/dd");
                        cmd.Parameters.AddWithValue("@idproduto", idprod);
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




        private void AlteraStatusLicitacao()
        {


            VlLancEdital obj = new VlLancEdital();


            obj.nlicitacao = Convert.ToString(cbolicitacao.SelectedValue);
            obj.statuslicitacao = 3;
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

        int codup;
        private void griditens_CellClick(object sender, DataGridViewCellEventArgs e)
        {

            if (e.ColumnIndex == 11)
            {
                foreach (DataGridViewRow row in griditens.Rows)
                {

                    if (bool.Parse(row.Cells[0].EditedFormattedValue.ToString()) == true)
                    {

                        VlItemLicitacao obj = new VlItemLicitacao();
                        obj.idproduto = Convert.ToInt32(row.Cells[10].Value);
                        obj.statuscotacao = "NAO";
                        obj.idusu = Banco.idusu;
                        codlic = Convert.ToString(cbolicitacao.SelectedValue);
                        obj.idedital = Convert.ToInt32(cbolicitacao.SelectedValue);


                        //VlItemCotacao objcotacao = new VlItemCotacao();
                        //objcotacao.idproduto = Convert.ToInt32(row.Cells[10].Value);
                        //objcotacao.statuscotacao = "NAO";
                        //objcotacao.idusu = Banco.idusu;
                        //objcotacao.idfornecedor = Convert.ToInt32(row.Cells[9].Value);
                        //objcotacao.edital = Convert.ToString(cbolicitacao.SelectedValue);


                        try
                        {
                            PsItemLicitacao DAOLicitacao = new PsItemLicitacao();
                            DAOLicitacao.AlterarCotacao(obj);

                            //if (VerificaRegistroExisteCotacao(objcotacao.idproduto, objcotacao.idfornecedor, objcotacao.edital) == true)
                            //{

                            //    PsItemCotacao DAOCotacao = new PsItemCotacao();
                            //    DAOCotacao.Incluir(objcotacao);

                            //}
                            //else
                            //{


                            //    PsItemCotacao DAOCotacao = new PsItemCotacao();
                            //    DAOCotacao.Alterar(objcotacao);

                            //}


                            DAOLicitacao.ExluirItemDaCotacao(obj.idproduto, codfor, codlic);






                        }
                        catch (Exception erro)
                        {

                            throw erro;
                        }
                    }

                }
                MessageBox.Show("Cotação(s) Desfeita com Sucesso!");
                carregarGridItens(codfor);
            }


        }
        public string codlic;
        private void BtnGerarForn_Click(object sender, EventArgs e)
        {
            codlic = Convert.ToString(cbolicitacao.SelectedValue);

            RelGerarCotacao obj = new RelGerarCotacao(this);


            obj.Show();
        }

        public string codedital;
        private void button2_Click(object sender, EventArgs e)
        {
            codedital = Convert.ToString(cbolicitacao.SelectedValue);

            ConsFornecedorItem obj = new ConsFornecedorItem(this);
            obj.Show();
        }

        private void btnPesquisar_Click(object sender, EventArgs e)
        {
            ConsGerarCotacao frmconv = new ConsGerarCotacao(this);
            this.Close();
            frmconv.Show();
        }

        private void chkTodos_CheckedChanged(object sender, EventArgs e)
        {
            foreach (DataGridViewRow row in griditens.Rows)
            {
                DataGridViewCheckBoxCell chkb = (DataGridViewCheckBoxCell)row.Cells[0];
                chkb.Value = !(chkb.Value == null ? false : (bool)chkb.Value); //because chk.Value is initialy null
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            ConsProdutoPreco frmc = new ConsProdutoPreco();
            frmc.Show();
        }

        private void button3_Click(object sender, EventArgs e)
        {
             relatorio = new Microsoft.Reporting.WinForms.ReportViewer();
            //relatorio.LocalReport.DataSources.Add(reportDataSource1);




            var servicoRelatorio = new ServicoRelatorioCotacao(codfor, UltimoSelecionado, relatorio);



            servicoRelatorio.PreparaRelatorioComOsParametros();

            ViewEmail email = new ViewEmail(this);
            email.Show();


        }
    }
}
