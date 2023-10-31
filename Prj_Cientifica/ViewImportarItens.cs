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
    public partial class ViewImportarItens : Form
    {

        public string nomeFor = "ViewImportarItens";
        public ViewImportarItens()
        {
            InitializeComponent();
        }

        public ViewImportarItens(ConsGerarCotacao frm) : this()
        {
           Convert.ToInt32(frm.codedital);
            RetronarCarregarLicitacao(Convert.ToInt32(frm.codedital));
            carregarGridItens();
        }

        private void RetronarCarregarLicitacao(int edital)
        {
            SqlConnection Cnn = Banco.CriarConexao();
            SqlDataAdapter sql = new SqlDataAdapter("Select LancEditais.idedital, LancEditais.nlicitacao,(CAST(LancEditais.nlicitacao AS VARCHAR(10))) + '               ' + (Modalidade.nome + '                    ' +  LancEditais.nlicitacao + '                        ' + " +
                "LancEditais.nprocesso + '                       ' + CONVERT(CHAR,LancEditais.dtabertura,103)) + '  ' + Cliente.nome as Licitacao  from LancEditais,Modalidade,Cliente " +
                " WHERE LancEditais.idmodalidade = Modalidade.idmodalidade and LancEditais.idcliente =  Cliente.idcliente AND LancEditais.idedital=" + edital + "", Cnn);
            DataSet Dt = new DataSet();
            sql.Fill(Dt);
            BindingSource bs = new BindingSource();
            bs.DataSource = Dt;
            bs.DataMember = Dt.Tables[0].TableName;

            try
            {
                this.cboprocesso.DataSource = bs;
                this.cboprocesso.DisplayMember = "Licitacao";
                this.cboprocesso.ValueMember = "idedital";
                this.cboprocesso.SelectedIndex = cboprocesso.Items.Count - 1;



            }
            catch (Exception erro)
            {

                throw erro;
            }
            Cnn.Close();
        }

        string arquivoxls;
        string arquivoquebra;
        byte[] DataFile;
        string nomearqxls;
        string tiporarqimpxls;

        private void CarregarProcesso()
        {
            SqlConnection Cnn = Banco.CriarConexao();
            SqlDataAdapter sql = new SqlDataAdapter("Select * from LancEditais Order by nlicitacao asc", Cnn);
            DataSet Dt = new DataSet();
            sql.Fill(Dt, "LancEditais");
            DataRow dr = Dt.Tables["LancEditais"].NewRow();
            dr[2] = "";
            Dt.Tables["LancEditais"].Rows.Add(dr);
            try
            {

                this.cboprocesso.DisplayMember = "nlicitacao";
                this.cboprocesso.ValueMember = "idedital";
                this.cboprocesso.DataSource = Dt.Tables["LancEditais"];
                this.cboprocesso.SelectedIndex = cboprocesso.Items.Count - 1;



            }
            catch (Exception erro)
            {

                throw erro;
            }
            Cnn.Close();
        }


        private void btnImportacao_Click(object sender, EventArgs e)
        {

            if (cboprocesso.Text != "")
            {

                OpenFileDialog AbrirComo = new OpenFileDialog();

                AbrirComo.Title = "Abrir Como";

                AbrirComo.FileName = "Nome Arquivo";
                AbrirComo.Filter = "Arquivos (*.*)|*.*";
                AbrirComo.InitialDirectory = "D:\\";
                if (AbrirComo.ShowDialog() == DialogResult.OK)
                    arquivoxls = AbrirComo.FileName;
                if (arquivoxls == " ")
                {
                    MessageBox.Show("Arquivo Invalido", "Salvar Como", MessageBoxButtons.OK);
                }
                else
                {

                    arquivoquebra = arquivoxls;


                    string FileName = arquivoquebra;


                    string con = @"Provider = Microsoft.ACE.OLEDB.12.0; Data Source = " + FileName + ";Extended Properties='Excel 12.0;HDR=Yes;'";
                    using (System.Data.OleDb.OleDbConnection connection = new System.Data.OleDb.OleDbConnection(con))
                    {
                        connection.Open();

                        string filename = FileName;

                        System.Data.OleDb.OleDbCommand command = new System.Data.OleDb.OleDbCommand(@"select * from  [Planilha1$]", connection);
                        using (System.Data.OleDb.OleDbDataReader dr = command.ExecuteReader())
                        {
                            while (dr.Read())
                            {



                                string lote = dr[0].ToString();
                                if (lote == "")
                                {
                                    lote = "";
                                }
                                string item = dr[1].ToString();
                                if (item == "")
                                {
                                    item = "";
                                }

                                string descricao = dr[2].ToString();
                                string unidade = dr[3].ToString();
                                string qtde = dr[4].ToString();
                                string processo = dr[5].ToString();
                                string edital = dr[6].ToString();
                                int idedital = 0;




                                GravaRegistro(lote, item, descricao, unidade, qtde, processo, edital,idedital);

                            }

                            carregarGridItens();
                            AlteraStatusLicitacao();


                        }

                    }
                }


            }
            else
            {
                MessageBox.Show("Informe o Nº do Processo !");
            }
        }
        private void GravaRegistro(string lote, string item, string descricao, string unidade, string qtde, string processo, string edital, int idedital)
        {


            VlImportacao obj = new VlImportacao();

            if (lote != "")
            {

                obj.lote = Convert.ToInt32(lote);
                obj.nritem = Convert.ToInt32(item);
                obj.descricao = descricao;
                obj.unidade = unidade;
                obj.qtde = Convert.ToDecimal(qtde);
                obj.processo = processo;
                obj.idusu = Banco.idusu;
                obj.status = "BAIXADO";
                obj.edital = edital;

                try
                {
                    PsImportacao DAOimportacao = new PsImportacao();

                    DAOimportacao.Incluir(obj);


                }

                catch (Exception erro)
                {

                    throw erro;
                }
            }

        }

        private void AlteraStatusLicitacao()
        {


            VlLancEdital obj = new VlLancEdital();


            obj.nprocesso = cboprocesso.Text;
            obj.statuslicitacao = 2;
            obj.idusu = Banco.idusu;


            try
            {
                PsLancEdital DAOLicitacao = new PsLancEdital();

                DAOLicitacao.AlterarStatus(obj);


            }

            catch (Exception erro)
            {

                throw erro;
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
                string strConn = "Select DISTINCT ItemsLicitacao.iditemedital as Cod,ItemsLicitacao.nritem as NºItem,ItemsLicitacao.lote as Lote,(Produto.nome  + '-' + Produto.apresentacao + '-' + Marca.nome) as Descricao , UnidadeMedida.nome as Unidade,ItemsLicitacao.qtde as Qtde, Concorrente.nome as Concorrente, MapaPreco.precoinicial as VlInicial,MIN(MapaPreco.precoganho) as VlGanho,ItemsLicitacao.idedital" +
                " from ItemsLicitacao LEFT JOIN MapaPreco ON ItemsLicitacao.iditemedital = MapaPreco.iditemedital LEFT JOIN Concorrente ON MapaPreco.idconcorrente = Concorrente.idconcorrente, Produto,UnidadeMedida,Marca  WHERE Produto.idproduto = ItemsLicitacao.idproduto AND " +
                " ItemsLicitacao.idunidade = UnidadeMedida.idunidade  AND Marca.idmarca = Produto.idmarca AND ItemsLicitacao.idedital=" + cboprocesso.SelectedValue + " GROUP BY  ItemsLicitacao.iditemedital ,ItemsLicitacao.nritem,ItemsLicitacao.lote ,Produto.nome," +
                "UnidadeMedida.nome,ItemsLicitacao.qtde, Concorrente.nome , MapaPreco.precoinicial,ItemsLicitacao.idedital,Produto.apresentacao,Marca.nome ";


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
            griditens.Columns.Add("Descricao", "Descricao");
            griditens.Columns.Add("Qtde", "Qtde");
            griditens.Columns.Add("Unidade", "Unidade");
            griditens.Columns.Add("Concorrente", "Concorrente");
            griditens.Columns.Add("VlInicial", "VlInicial");
            griditens.Columns.Add("VlGanho", "VlGanho");
            griditens.Columns.Add("idedital", "idedital");

            griditens.Columns[0].Width = 50;
            griditens.Columns[1].Width = 50;
            griditens.Columns[2].Width = 75;
            griditens.Columns[3].Width = 70;
            griditens.Columns[4].Width = 380;
            griditens.Columns[5].Width = 70;
            griditens.Columns[6].Width = 110;
            griditens.Columns[7].Width = 263;
            griditens.Columns[8].Width = 100;
            griditens.Columns[9].Width = 100;
            griditens.Columns[10].Visible = false;

            griditens.Columns[1].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft;
            griditens.Columns[5].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft;
            griditens.Columns[4].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft;


            griditens.Columns[1].DataPropertyName = "Cod";
            griditens.Columns[2].DataPropertyName = "NºItem";
            griditens.Columns[3].DataPropertyName = "Lote";
            griditens.Columns[4].DataPropertyName = "Descricao";
            griditens.Columns[5].DataPropertyName = "Qtde";
            griditens.Columns[6].DataPropertyName = "Unidade";
            griditens.Columns[7].DataPropertyName = "Concorrente";
            griditens.Columns[8].DataPropertyName = "VlInicial";
            griditens.Columns[9].DataPropertyName = "VlGanho";
            griditens.Columns[10].DataPropertyName = "idedital";



            int total = 0;

            foreach (DataGridViewRow linha in griditens.Rows)
            {
                total = total + 1;
            }

            ladtotal.Text = Convert.ToString(total);


            griditens.Refresh();


        }

        private void cboprocesso_Click(object sender, EventArgs e)
        {
            CarregarProcesso();
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

        private void CarregarConcorrente()
        {
            SqlConnection Cnn = Banco.CriarConexao();
            SqlDataAdapter sql = new SqlDataAdapter("Select * from Concorrente", Cnn);
            DataSet Dt = new DataSet();
            sql.Fill(Dt, "Concorrente");
            DataRow dr = Dt.Tables["Concorrente"].NewRow();
            dr[1] = "";
            Dt.Tables["Concorrente"].Rows.Add(dr);
            try
            {

                this.cboconcorrente.DisplayMember = "nome";
                this.cboconcorrente.ValueMember = "idconcorrente";
                this.cboconcorrente.DataSource = Dt.Tables["Concorrente"];
                this.cboconcorrente.SelectedIndex = cboconcorrente.Items.Count - 1;



            }
            catch (Exception erro)
            {

                throw erro;
            }
            Cnn.Close();
        }
        private void RetornaConcorrente(Int32 retp)
        {
            SqlConnection Cnn = Banco.CriarConexao();
            SqlDataAdapter sql = new SqlDataAdapter("Select * from Concorrente WHERE idconcorrente=" + retp + "", Cnn);
            DataTable Dt = new DataTable();
            sql.Fill(Dt);
            try
            {
                this.cboconcorrente.DataSource = Dt;
                this.cboconcorrente.DisplayMember = "nome";
                this.cboconcorrente.ValueMember = "idconcorrente";
                this.cboconcorrente.Refresh();




            }
            catch (Exception erro)
            {

                throw erro;
            }
            Cnn.Close();
        }


        private void CarregarFabricante()
        {
            SqlConnection Cnn = Banco.CriarConexao();
            SqlDataAdapter sql = new SqlDataAdapter("Select * from Marca", Cnn);
            DataSet Dt = new DataSet();
            sql.Fill(Dt, "Marca");
            DataRow dr = Dt.Tables["Marca"].NewRow();
            dr[1] = "";
            Dt.Tables["Marca"].Rows.Add(dr);
            try
            {

                this.cbofabricante.DisplayMember = "nome";
                this.cbofabricante.ValueMember = "idmarca";
                this.cbofabricante.DataSource = Dt.Tables["Marca"];
                this.cbofabricante.SelectedIndex = cbofabricante.Items.Count - 1;



            }
            catch (Exception erro)
            {

                throw erro;
            }
            Cnn.Close();
        }
        private void RetornaFabricante(Int32 retfab)
        {
            SqlConnection Cnn = Banco.CriarConexao();
            SqlDataAdapter sql = new SqlDataAdapter("Select * from Marca WHERE idmarca=" + retfab + "", Cnn);
            DataTable Dt = new DataTable();
            sql.Fill(Dt);
            try
            {
                this.cbofabricante.DataSource = Dt;
                this.cbofabricante.DisplayMember = "nome";
                this.cbofabricante.ValueMember = "idmarca";
                this.cbofabricante.Refresh();




            }
            catch (Exception erro)
            {

                throw erro;
            }
            Cnn.Close();
        }



        private void cboprincipio_Click(object sender, EventArgs e)
        {
            CarregarConcorrente();
        }

        private void cbofornecedor_Click(object sender, EventArgs e)
        {
            // CarregarFornecedor();
        }

        private void cbounidade_Click(object sender, EventArgs e)
        {

        }

        private void cboprocedencia_Click(object sender, EventArgs e)
        {

        }

        private void cbofabricante_Click(object sender, EventArgs e)
        {
            CarregarFabricante();
        }

        private void cboclassificacao_Click(object sender, EventArgs e)
        {
        }

        private void cbofornecedor_KeyPress(object sender, KeyPressEventArgs e)
        {

        }

        private void cbounidade_KeyPress(object sender, KeyPressEventArgs e)
        {

        }

        private void cbostatus_KeyPress(object sender, KeyPressEventArgs e)
        {

        }

        private void mskvalidade_KeyPress(object sender, KeyPressEventArgs e)
        {
            if ((Keys)e.KeyChar == Keys.Enter)
            {
                this.BtnSalvar.Focus();
            }

        }

        private void cboprocedencia_KeyPress(object sender, KeyPressEventArgs e)
        {
            if ((Keys)e.KeyChar == Keys.Enter)
            {
                this.cbofabricante.Focus();
            }
        }

        private void cbofabricante_KeyPress(object sender, KeyPressEventArgs e)
        {

        }

        private void txtprecofabrica_KeyPress(object sender, KeyPressEventArgs e)
        {

        }

        private void txtpmvg_KeyPress(object sender, KeyPressEventArgs e)
        {

        }

        private void txtconvenio_KeyPress(object sender, KeyPressEventArgs e)
        {

        }

        private void txtcap_KeyPress(object sender, KeyPressEventArgs e)
        {

        }

        private void cboclassificacao_KeyPress(object sender, KeyPressEventArgs e)
        {

        }

        private void dtvalidade_ValueChanged(object sender, EventArgs e)
        {
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
               string strConn = "Select DISTINCT ItemsLicitacao.iditemedital as Cod,ItemsLicitacao.nritem as NºItem,ItemsLicitacao.lote as Lote,Produto.nome as Descricao, UnidadeMedida.nome as Unidade,ItemsLicitacao.qtde as Qtde, Concorrente.nome as Concorrente, MapaPreco.precoinicial as VlInicial,MIN(MapaPreco.precoganho) as VlGanho,ItemsLicitacao.idedital" +
                " from ItemsLicitacao LEFT JOIN MapaPreco ON ItemsLicitacao.iditemedital = MapaPreco.iditemedital LEFT JOIN Concorrente ON MapaPreco.idconcorrente = Concorrente.idconcorrente,Produto,UnidadeMedida WHERE Produto.idproduto = ItemsLicitacao.idproduto AND " +
                "ItemsLicitacao.idunidade = UnidadeMedida.idunidade  AND Produto.nome Like'%" + txtpesquisa.Text + "%' GROUP BY  ItemsLicitacao.iditemedital ,ItemsLicitacao.nritem,ItemsLicitacao.lote ,Produto.nome," +
                "UnidadeMedida.nome,ItemsLicitacao.qtde, Concorrente.nome , MapaPreco.precoinicial ";


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
            griditens.Columns.Add("Descricao", "Descricao");
            griditens.Columns.Add("Qtde", "Qtde");
            griditens.Columns.Add("Unidade", "Unidade");
            griditens.Columns.Add("Concorrente", "Concorrente");
            griditens.Columns.Add("VlInicial", "VlInicial");
            griditens.Columns.Add("VlGanho", "VlGanho");
            griditens.Columns.Add("idedital", "idedital");

            griditens.Columns[0].Width = 50;
            griditens.Columns[1].Width = 50;
            griditens.Columns[2].Width = 80;
            griditens.Columns[3].Width = 80;
            griditens.Columns[4].Width = 400;
            griditens.Columns[5].Width = 70;
            griditens.Columns[6].Width = 130;
            griditens.Columns[7].Width = 258;
            griditens.Columns[8].Width = 100;
            griditens.Columns[9].Width = 100;
            griditens.Columns[10].Visible = false;


            griditens.Columns[1].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft;
            griditens.Columns[5].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft;
            griditens.Columns[4].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft;


            griditens.Columns[1].DataPropertyName = "Cod";
            griditens.Columns[2].DataPropertyName = "NºItem";
            griditens.Columns[3].DataPropertyName = "Lote";
            griditens.Columns[4].DataPropertyName = "Descricao";
            griditens.Columns[5].DataPropertyName = "Qtde";
            griditens.Columns[6].DataPropertyName = "Unidade";
            griditens.Columns[7].DataPropertyName = "Concorrente";
            griditens.Columns[8].DataPropertyName = "VlInicial";
            griditens.Columns[9].DataPropertyName = "VlGanho";
            griditens.Columns[10].DataPropertyName = "idedital";

            int total = 0;

            foreach (DataGridViewRow linha in griditens.Rows)
            {
                total = total + 1;
            }

            ladtotal.Text = Convert.ToString(total);


            griditens.Refresh();


        }

        private void txtpesquisa_TextChanged(object sender, EventArgs e)
        {
            carregarGridPesquisa();
        }


        private void griditens_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0 && e.ColumnIndex == 0)
            {

                int codii = Convert.ToInt32(griditens.CurrentRow.Cells[1].Value);
                carregarGridUltimo(codii);
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

        private void chkTodos_CheckedChanged(object sender, EventArgs e)
        {
            foreach (DataGridViewRow row in griditens.Rows)
            {
                DataGridViewCheckBoxCell chk = (DataGridViewCheckBoxCell)row.Cells[0];
                chk.Value = !(chk.Value == null ? false : (bool)chk.Value); //because chk.Value is initialy null
            }

        }
        string itemlt;
        int itemit;
        decimal itemqt;
        private void BtnSalvar_Click(object sender, EventArgs e)
        {

            foreach (DataGridViewRow row in griditens.Rows)
            {

                if (bool.Parse(row.Cells[0].EditedFormattedValue.ToString())  == true)
                {


                    if (ValidaCampos() == true)
                    {

                        VlMapa obj = new VlMapa();
                        int codi = Convert.ToInt32(row.Cells[1].Value);
                        string codedital = Convert.ToString(row.Cells[10].Value);
                        obj.idmapa = codi;
                        obj.iditemedital = codi;
                        int edt = Convert.ToInt32(cboprocesso.SelectedValue);

                        if (mskvalidade.Text != "  /  /")
                        {
                            obj.dtmapa = mskvalidade.Text;
                        }
                        else
                        {
                            obj.dtmapa = "";
                        }
                        obj.idconcorrente = Convert.ToInt32(cboconcorrente.SelectedValue);
                        obj.idedital = edt;
                        obj.edital = codedital;
                        obj.precoinicial = Convert.ToDecimal(txtprecoinicial.Text);
                        obj.precoganho = Convert.ToDecimal(txtprecoganho.Text);
                        obj.idmarca = Convert.ToInt32(this.cbofabricante.SelectedValue);
                        obj.dtmapa = mskvalidade.Text;
                        obj.idusu = Banco.idusu;
                        obj.idempresa = Banco.idemp;
                        obj.qtde = Convert.ToInt32(row.Cells[5].Value);



                        try
                        {
                            //if (VerificaRegistroExiste(obj.iditemimportado, obj.edital ) == true)
                            //{

                            PsMapa DAOMapa = new PsMapa();
                            DAOMapa.Incluir(obj);
                            carregarGridUltimo(codi);
                            carregarGridItens();
                            LimpacamposItens();
                            //}
                            //else
                            //{
                            //    PsMapa DAOMapa = new PsMapa();
                            //    DAOMapa.Alterar(obj);
                            //   // MessageBox.Show("Registro Alterada com Sucesso!");
                            //    //Limpacampos();


                            //}
                        }
                        catch (Exception erro)
                        {

                            throw erro;
                        }
                    }



                }

            }
            //GravaItensLicitacao();

        }

        //private void AlteraStatus(int codst)
        //{


        //    VlImportacao obj = new VlImportacao();

        //    obj.iditem = Convert.ToInt32(codst);
        //    obj.status = "IMPORTADO";


        //    try
        //    {
        //        PsImportacao DAOimportacao = new PsImportacao();

        //        DAOimportacao.AlterarStatus(obj);


        //    }

        //    catch (Exception erro)
        //    {

        //        throw erro;
        //    }


        //}

        //private void GravaItensLicitacao()
        //{

        //    string reg = "Select distinct produto.idproduto as Cod, Produto.lote as Lote,Produto.item as Item,Produto.idprincipio,Produto.idunidade,Produto.qtde,Produto.idusu," +
        //        "produto.nome as descricao,Produto.idproduto,LancEditais.idcliente,LancEditais.nlicitacao,Produto.processo,Fabricante.idfabricante " +
        //        "FROM  Produto,LancEditais,Cliente,UnidadeMedida,PrincipioAtivo,Fabricante Where LancEditais.nprocesso = Produto.processo and Produto.idprincipio = PrincipioAtivo.idprincipio and " +
        //        " Produto.idunidade = UnidadeMedida.idunidade and LancEditais.idcliente = Cliente.idcliente AND Produto.idfabricante = Fabricante.idfabricante AND " +
        //        "   Produto.processo = '" + cboprocesso.Text + "' AND Produto.statusprod = 'EXPORTADO' ";

        //    DataTable ds = new DataTable();
        //    SqlConnection Conn = Banco.CriarConexao();
        //    Conn.Open(); 

        //    if (Conn.State == ConnectionState.Open)
        //    {
        //        SqlCommand cmd = new SqlCommand(reg, Conn);
        //        SqlDataReader dr = cmd.ExecuteReader();
        //        while (dr.Read())
        //        {
        //            int cod = Convert.ToInt32(dr["Cod"].ToString());
        //            string lote = dr["Lote"].ToString();
        //            int item = Convert.ToInt32(dr["Item"].ToString());
        //            int principio = Convert.ToInt32(dr["idprincipio"].ToString());
        //            int unidade = Convert.ToInt32(dr["idunidade"].ToString());
        //            decimal precofabrica = Convert.ToDecimal(0);
        //            int qtde = Convert.ToInt32(dr["qtde"].ToString());
        //            decimal vlestimado = Convert.ToDecimal(0);
        //            string dtatual = DateTime.Now.ToString("dd/MM/yyyy");
        //            int usu = Convert.ToInt32(dr["idusu"].ToString());
        //            string desc = "ND";
        //            int statusdesc = Convert.ToInt32(0);
        //            string stcotacao = "NAO";
        //            int prod = Convert.ToInt32(dr["idproduto"].ToString());
        //            int cli = Convert.ToInt32(dr["idcliente"].ToString());
        //            string edt = dr["nlicitacao"].ToString();
        //            string processo = dr["processo"].ToString();
        //            int fabricante = Convert.ToInt32(dr["idfabricante"].ToString());

        //            GravaItems(lote, item, principio, unidade, precofabrica, qtde, vlestimado, dtatual, usu, desc, statusdesc, stcotacao, prod, cli, edt, processo,cod, fabricante);

        //        }
        //    }

        //}
        //private void GravaItems(string lote,int item, int principio,int unidade,decimal precofabrica,int qtde, decimal vlestimado,
        //   string dtatual,int usu, string desc, int statusdesc, string stcotacao, int prod, int cli, string edt, string processo,int cod, int fabricante)
        //{

        //    VlItemLicitacao obj = new VlItemLicitacao();
        //    obj.lote = lote;
        //    obj.nritem = item;
        //    obj.idprincipio = principio;
        //    obj.idunidade = unidade;
        //    obj.vlestimado = precofabrica;
        //    obj.qtde = qtde;
        //    obj.vltotalestimado = vlestimado;
        //    obj.dtitens = dtatual;
        //    obj.idusu = Banco.idusu;
        //    obj.descitem = "ND";
        //    obj.statusdesc = Convert.ToInt32(0);
        //    obj.statuscotacao = "NAO";
        //    obj.idproduto = prod;
        //    obj.idcliente = cli; ;
        //    obj.nlicitacao = edt;
        //    obj.processo = processo;
        //    int idp = cod;
        //    obj.idfabricante = fabricante;
        //    AlteraStatusProduto(idp);

        //    try
        //    {
        //        PsItemLicitacao DAOitem = new PsItemLicitacao();
        //        DAOitem.Incluir(obj);



        //    }
        //    catch (Exception erro)
        //    {
        //        throw erro;
        //    }

        //}

        //private void AlteraStatusProduto(int cod)
        //{



        //    VlProduto obj = new VlProduto();

        //    obj.idproduto = Convert.ToInt32(cod);
        //    obj.statusprod = "PRODUCAO";


        //    try
        //    {
        //        PsProduto DAOproduto = new PsProduto();

        //        DAOproduto.AlteraStatusProduto(obj);


        //    }

        //    catch (Exception erro)
        //    {

        //        throw erro;
        //    }



        //}



        private Boolean VerificaRegistroExiste(int cod, string edital)
        {

            SqlConnection Cnn = Banco.CriarConexao();
            string obter = ("Select * From MapaPreco Where iditemimportado = " + cod + "AND edital='" + edital + "'");
            SqlCommand sql = new SqlCommand(obter, Cnn);
            Cnn.Open();
            SqlDataReader dr = sql.ExecuteReader();
            if (dr.Read())
            {

                return false;
            }
            return true;
        }


        private Boolean ValidaCampos()
        {
            if (this.cboconcorrente.Text == "")
            {
                MessageBox.Show("Informe o Princípio Ativo");
                cboconcorrente.Focus();
                return false;

            }



            if (this.cbofabricante.Text == "")
            {
                MessageBox.Show("informe o fabricante!");
                cbofabricante.Focus();
                return false;

            }

            if (this.txtprecoinicial.Text == "")
            {
                MessageBox.Show("informe o Preço de fabricante!");
                txtprecoinicial.Focus();
                return false;

            }

            if (this.txtprecoganho.Text == "")
            {
                MessageBox.Show("informe o PMVG!");
                txtprecoganho.Focus();
                return false;

            }




            return true;


        }

        private void BtnSair_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void BtnNovo_Click(object sender, EventArgs e)
        {
            Limpacampos();
        }

        private void LimpacamposItens()
        {

            cboconcorrente.SelectedIndex = -1;
            mskvalidade.Text = "";
            cbofabricante.SelectedIndex = -1;
            txtprecoinicial.Text = "0,00";
            txtprecoganho.Text = "0,00";
          
            cboconcorrente.Focus();

        }

        private void Limpacampos()
        {

            cboconcorrente.SelectedIndex = -1;

            mskvalidade.Text = "";

            cbofabricante.SelectedIndex = -1;
            txtprecoinicial.Text = "0,00";
            txtprecoganho.Text = "0,00";

            griditens.DataSource = null;
            griditens.Refresh();
            cboconcorrente.Focus();


        }

        private void btnpesqProd_Click(object sender, EventArgs e)
        {
            ConsProduto produto = new ConsProduto();
            produto.Show();
        }

        private void cboconcorrente_Click(object sender, EventArgs e)
        {
            CarregarConcorrente();
        }

        private void cboconcorrente_KeyPress(object sender, KeyPressEventArgs e)
        {
            if ((Keys)e.KeyChar == Keys.Enter)
            {

                this.txtprecoinicial.Focus();
            }
        }

        private void txtprecoganho_KeyPress(object sender, KeyPressEventArgs e)
        {
            if ((Keys)e.KeyChar == Keys.Enter)
            {

                decimal precoganho = Convert.ToDecimal(this.txtprecoinicial.Text);
                this.txtprecoinicial.Text = String.Format("{0:N2}", Math.Round(precoganho, 2));
                this.cbofabricante.Focus();
            }
        }

        private void txtprecoinicial_KeyPress(object sender, KeyPressEventArgs e)
        {

            if ((Keys)e.KeyChar == Keys.Enter)
            {

                decimal precoinicial = Convert.ToDecimal(this.txtprecoinicial.Text);
                this.txtprecoinicial.Text = String.Format("{0:N2}", Math.Round(precoinicial, 2));
                this.txtprecoganho.Focus();
            }
        }

        private void cbofabricante_KeyPress_1(object sender, KeyPressEventArgs e)
        {

        }

        private void cbofabricante_KeyPress_2(object sender, KeyPressEventArgs e)
        {
            if ((Keys)e.KeyChar == Keys.Enter)
            {
                this.mskvalidade.Focus();
            }
        }

        DataGridViewCheckBoxColumn chk = new DataGridViewCheckBoxColumn();
        private void carregarGridUltimo(int coditemmap)
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
                string strConn = "Select DISTINCT MapaPreco.idmapa as Cod,ItemsLicitacao.nritem as NºItem,ItemsLicitacao.lote as Lote,Produto.nome as Descricao,Marca.nome as Marca, Concorrente.nome as Concorrente, MapaPreco.precoinicial as VlInicial,MapaPreco.precoganho as VlGanho" +
                " from ItemsLicitacao LEFT JOIN MapaPreco ON ItemsLicitacao.iditemedital = MapaPreco.iditemedital LEFT JOIN Concorrente ON MapaPreco.idconcorrente = Concorrente.idconcorrente LEFT JOIN Marca ON MapaPreco.idmarca = Marca.idmarca,Produto WHERE " +
                " Produto.idproduto = ItemsLicitacao.idproduto AND MapaPreco.iditemedital=" + coditemmap + "";


                SqlDataAdapter da = new SqlDataAdapter(strConn, Conn);
                da.Fill(ds);


            }

            this.griditensultimo.RowsDefaultCellStyle.BackColor = Color.LightBlue;
            this.griditensultimo.AlternatingRowsDefaultCellStyle.BackColor = Color.Azure;


            griditensultimo.AutoGenerateColumns = false;
            //exibe os dados no datagridview
            griditensultimo.DataSource = ds;
            griditensultimo.Columns.Clear();
            griditensultimo.Columns.Add(chk);
            chk.HeaderText = "Sel";
            chk.Name = "chk";
            griditensultimo.Columns.Add("Cod", "Cod");
            griditensultimo.Columns.Add("NºItem", "NºItem");
            griditensultimo.Columns.Add("Lote", "Lote");
            griditensultimo.Columns.Add("Descricao", "Descricao");
            griditensultimo.Columns.Add("Marca", "Marca");
            griditensultimo.Columns.Add("Concorrente", "Concorrente");
            griditensultimo.Columns.Add("VlInicial", "VlInicial");
            griditensultimo.Columns.Add("VlGanho", "VlGanho");

            griditensultimo.Columns[0].Width = 50;
            griditensultimo.Columns[1].Width = 50;
            griditensultimo.Columns[2].Width = 55;
            griditensultimo.Columns[3].Width = 50;
            griditensultimo.Columns[4].Width = 300;
            griditensultimo.Columns[5].Width = 150;
            griditensultimo.Columns[6].Width = 233;
            griditensultimo.Columns[7].Width = 70;
            griditensultimo.Columns[8].Width = 70;


            griditensultimo.Columns[1].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft;
            griditensultimo.Columns[4].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft;


            griditensultimo.Columns[1].DataPropertyName = "Cod";
            griditensultimo.Columns[2].DataPropertyName = "NºItem";
            griditensultimo.Columns[3].DataPropertyName = "Lote";
            griditensultimo.Columns[4].DataPropertyName = "Descricao";
            griditensultimo.Columns[5].DataPropertyName = "Marca";
            griditensultimo.Columns[6].DataPropertyName = "Concorrente";
            griditensultimo.Columns[7].DataPropertyName = "VlInicial";
            griditensultimo.Columns[8].DataPropertyName = "VlGanho";

            DataGridViewButtonColumn btn = new DataGridViewButtonColumn();
            griditensultimo.Columns.Add(btn);
            btn.HeaderText = "Excluir";
            btn.Text = "Excluir";
            btn.Name = "btn";
            btn.Width = 60;
            btn.UseColumnTextForButtonValue = true;
            btn.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft;


            int total = 0;

            foreach (DataGridViewRow linha in griditensultimo.Rows)
            {
                total = total + 1;
            }

            ladtotal.Text = Convert.ToString(total);


            griditensultimo.Refresh();


        }
        int codex;
        private void griditensultimo_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex == 9)
            {
                codex = Convert.ToInt32(griditensultimo[1, e.RowIndex].Value.ToString());

                VlMapa obj = new VlMapa();
                obj.idmapa = codex;

                try
                {
                    PsMapa DAOMapa = new PsMapa();
                    DialogResult result = MessageBox.Show("Deseja Excluir este Item !", "Excluir", MessageBoxButtons.YesNo);
                    if (result == DialogResult.Yes)
                    {
                        DAOMapa.Exluir(obj.idmapa);
                        MessageBox.Show("Registro Excluido com Sucesso!");
                        carregarGridItens();
                        carregarGridUltimo(obj.idmapa);

                    }
                    else if (result == DialogResult.No)
                    {
                        return;
                    }



                }
                catch (Exception erro)
                {

                    throw erro;
                }



            }
        }
    }
}
