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
    public partial class ViewProduto : Form
    {
        public static string TipoGravacao;
        public static string UltimoSelecionado;
        public int codproduto;


        public ViewProduto()
        {
            InitializeComponent();
        }

        public ViewProduto(ViewCotarFornecedores frm) : this()
        {

            UltimoSelecionado = Convert.ToString(frm.codprod);
            RetReg();

        }

        public ViewProduto(ViewPropostaRealinhada frm) : this()
        {
            UltimoSelecionado = Convert.ToString(frm.coditems);
            RetRegProd();


        }

        public ViewProduto(ConsProduto frm) : this()
        {
            UltimoSelecionado = Convert.ToString(frm.codproduto);
            RetReg();


        }

        public ViewProduto(ViewLancamentoEditais frm) : this()
        {
            UltimoSelecionado = Convert.ToString(frm.coditemsproduto);
            RetReg();
        }


        private void RetRegProd()
        {
            string reg = "Select  Produto.* From Produto,ItemsLicitacao WHERE  Produto.idproduto = ItemsLicitacao.idproduto AND ItemsLicitacao.iditemedital= " + UltimoSelecionado + "";
            DataTable ds = new DataTable();
            SqlConnection Conn = Banco.CriarConexao();
            Conn.Open();

            if (Conn.State == ConnectionState.Open)
            {
                SqlCommand cmd = new SqlCommand(reg, Conn);
                SqlDataReader dr = cmd.ExecuteReader();
                if (dr.Read())
                {
                    txtcodigo.Text = dr["idproduto"].ToString();
                    codproduto = Convert.ToInt32(dr["idproduto"].ToString());
                    RetornaPricipio(Convert.ToInt32(dr["idprincipio"].ToString()));
                    //  RetornaFornecedor(Convert.ToInt32(dr["idfornecedor"].ToString()));
                    txtnome.Text = dr["nome"].ToString();
                    RetornaUnidade(Convert.ToInt32(dr["idunidade"].ToString()));
                    txtapresentacao.Text = dr["apresentacao"].ToString();
                    txtcodca.Text = dr["codca"].ToString();
                    txtregistro.Text = dr["registro"].ToString();
                    mskvalidade.Text = dr["dtvalidade"].ToString();
                    RetornaProcedencia(Convert.ToInt32(dr["idprocedencia"].ToString()));
                    RetornaFabricante(Convert.ToInt32(dr["idfabricante"].ToString()));

                    Decimal precofabrica = decimal.Parse(dr["precofabrica"].ToString());
                    string convertprecofabrica = String.Format("{0:N2}", precofabrica);
                    this.txtprecofabrica.Text = convertprecofabrica;

                    Decimal pmvg = decimal.Parse(dr["pmvg"].ToString());
                    string convertpmvg = String.Format("{0:N2}", pmvg);
                    this.txtpmvg.Text = convertpmvg;

                    txtconvenio.Text = dr["convenioicms"].ToString();

                    Decimal cap = decimal.Parse(dr["cap"].ToString());
                    string convercap = String.Format("{0:N2}", cap);
                    this.txtcap.Text = convercap;


                    cbostatus.Text = dr["statusprod"].ToString();

                    RetornaClassificacao(Convert.ToInt32(dr["idclassificacaofiscal"].ToString()));
                    mskcad.Text = dr["dtcadastro"].ToString();
                    RetornaMarca(Convert.ToInt32(dr["idmarca"].ToString()));
                   txtvalidadeproduto.Text = dr["dtproduto"].ToString();

                    carregarGridItens();

                }
            }
        }


        private void RetReg()
        {
            string reg = "Select * from Produto ";
            if (UltimoSelecionado != "")
                reg += "Where idproduto = " + UltimoSelecionado;
            else reg += "Where idproduto = (Select Max(idproduto) from Produto)";
            DataTable ds = new DataTable();
            SqlConnection Conn = Banco.CriarConexao();
            Conn.Open();

            if (Conn.State == ConnectionState.Open)
            {
                SqlCommand cmd = new SqlCommand(reg, Conn);
                SqlDataReader dr = cmd.ExecuteReader();
                if (dr.Read())
                {
                    txtcodigo.Text = dr["idproduto"].ToString();
                    RetornaPricipio(Convert.ToInt32(dr["idprincipio"].ToString()));
                    codproduto = Convert.ToInt32(dr["idproduto"].ToString());
                    //RetornaFornecedor(Convert.ToInt32(dr["idfornecedor"].ToString()));
                    txtnome.Text = dr["nome"].ToString();
                    RetornaUnidade(Convert.ToInt32(dr["idunidade"].ToString()));
                    txtapresentacao.Text = dr["apresentacao"].ToString();
                    txtcodca.Text = dr["codca"].ToString();
                    txtregistro.Text = dr["registro"].ToString();
                    mskvalidade.Text = dr["dtvalidade"].ToString();
                    RetornaProcedencia(Convert.ToInt32(dr["idprocedencia"].ToString()));
                    RetornaFabricante(Convert.ToInt32(dr["idfabricante"].ToString()));

                    Decimal precofabrica = decimal.Parse(dr["precofabrica"].ToString());
                    string convertprecofabrica = String.Format("{0:N2}", precofabrica);
                    this.txtprecofabrica.Text = convertprecofabrica;

                    Decimal pmvg = decimal.Parse(dr["pmvg"].ToString());
                    string convertpmvg = String.Format("{0:N2}", pmvg);
                    this.txtpmvg.Text = convertpmvg;

                    txtconvenio.Text = dr["convenioicms"].ToString();

                    Decimal cap = decimal.Parse(dr["cap"].ToString());
                    string convercap = String.Format("{0:N2}", cap);
                    this.txtcap.Text = convercap;


                    cbostatus.Text = dr["statusprod"].ToString();

                    RetornaClassificacao(Convert.ToInt32(dr["idclassificacaofiscal"].ToString()));
                    mskcad.Text = dr["dtcadastro"].ToString();
                    RetornaMarca(Convert.ToInt32(dr["idmarca"].ToString()));
                    txtvalidadeproduto.Text = dr["validadeprod"].ToString();


                    carregarGridItens();

                }
            }
        }
        private void Limpacampos()
        {
            txtcodigo.Text = "";
            this.txtnome.Text = "";
            cboprincipio.SelectedIndex = -1;
            cbounidade.SelectedIndex = -1;
            txtapresentacao.Text = "";
            txtcodca.Text = "";
            txtregistro.Text = "";
            mskvalidade.Text = "";
            cboprocedencia.SelectedIndex = -1;
            cbofabricante.SelectedIndex = -1;
            txtprecofabrica.Text = "0,00";
            txtpmvg.Text = "0,00";
            txtconvenio.Text = "0,00";
            txtcap.Text = "0,00";
            cboclassificacao.SelectedIndex = -1;
            cbomarca.SelectedIndex = -1;
            txtvalidadeproduto.Text = "";
            cbostatus.SelectedValue = -1;
            cboprincipio.Focus();


        }

        private Boolean ValidaCampos()
        {
            if (this.cboprincipio.Text == "")
            {
                MessageBox.Show("Informe o Princípio Ativo");
                cboprincipio.Focus();
                return false;

            }

            if (this.cbounidade.Text == "")
            {
                MessageBox.Show("informe a Unidade de Medida!");
                cbounidade.Focus();
                return false;

            }

            if (this.cboprocedencia.Text == "")
            {
                MessageBox.Show("informe a Procedência!");
                cboprocedencia.Focus();
                return false;

            }

            if (this.cbofabricante.Text == "")
            {
                MessageBox.Show("informe o fabricante!");
                cbofabricante.Focus();
                return false;

            }
            if (this.cbomarca.Text == "")
            {
                MessageBox.Show("informe a Marca!");
                cbomarca.Focus();
                return false;

            }

            if (this.txtprecofabrica.Text == "")
            {
                MessageBox.Show("informe o Preço de fabricante!");
                txtprecofabrica.Focus();
                return false;

            }

            if (this.txtpmvg.Text == "")
            {
                MessageBox.Show("informe o PMVG!");
                txtpmvg.Focus();
                return false;

            }

            if (this.txtcap.Text == "")
            {
                MessageBox.Show("informe o CAP!");
                txtcap.Focus();
                return false;

            }
            //if (this.cboclassificacao.Text == "")
            //{
            //    MessageBox.Show("informe a Classificação!");
            //    cboclassificacao.Focus();
            //    return false;

            //}



            if (this.txtapresentacao.Text == "")
            {
                MessageBox.Show("informe a Apresentação");
                txtapresentacao.Focus();
                return false;

            }


            if (this.cbostatus.Text == "")
            {
                MessageBox.Show("informe o Status do Produto");
                cbostatus.Focus();
                return false;

            }





            return true;


        }

        private void RetornaMarca(int idmarc)
        {
            SqlConnection Cnn = Banco.CriarConexao();
            SqlDataAdapter sql = new SqlDataAdapter("Select Marca.idmarca, Marca.nome as Marca from Marca,Fabricante " +
                " WHERE Fabricante.idfabricante = Marca.idfabricante And Marca.idmarca=" + idmarc + "", Cnn);
            DataSet Dt = new DataSet();
            sql.Fill(Dt);
            BindingSource bs = new BindingSource();
            bs.DataSource = Dt;
            bs.DataMember = Dt.Tables[0].TableName;

            try
            {
                this.cbomarca.DataSource = bs;
                this.cbomarca.DisplayMember = "Marca";
                this.cbomarca.ValueMember = "idmarca";
                this.cbomarca.SelectedIndex = cbomarca.Items.Count - 1;



            }
            catch (Exception erro)
            {

                throw erro;
            }
            Cnn.Close();

        }



        private void CarregarPricipio()
        {
            SqlConnection Cnn = Banco.CriarConexao();
            SqlDataAdapter sql = new SqlDataAdapter("Select * from PrincipioAtivo order by nome asc ", Cnn);
            DataSet Dt = new DataSet();
            sql.Fill(Dt, "PrincipioAtivo");
            DataRow dr = Dt.Tables["PrincipioAtivo"].NewRow();
            dr[1] = "";
            Dt.Tables["PrincipioAtivo"].Rows.Add(dr);
            try
            {

                this.cboprincipio.DisplayMember = "nome";
                this.cboprincipio.ValueMember = "idprincipio";
                this.cboprincipio.DataSource = Dt.Tables["PrincipioAtivo"];
                this.cboprincipio.SelectedIndex = cboprincipio.Items.Count - 1;



            }
            catch (Exception erro)
            {

                throw erro;
            }
            Cnn.Close();
        }
        private void RetornaPricipio(Int32 retp)
        {
            SqlConnection Cnn = Banco.CriarConexao();
            SqlDataAdapter sql = new SqlDataAdapter("Select * from PrincipioAtivo WHERE idprincipio=" + retp + "", Cnn);
            DataTable Dt = new DataTable();
            sql.Fill(Dt);
            try
            {
                this.cboprincipio.DataSource = Dt;
                this.cboprincipio.DisplayMember = "nome";
                this.cboprincipio.ValueMember = "idprincipio";
                this.cboprincipio.Refresh();




            }
            catch (Exception erro)
            {

                throw erro;
            }
            Cnn.Close();
        }

        private void CarregarUnidadeMedidade()
        {
            SqlConnection Cnn = Banco.CriarConexao();
            SqlDataAdapter sql = new SqlDataAdapter("Select * from UnidadeMedida", Cnn);
            DataSet Dt = new DataSet();
            sql.Fill(Dt, "UnidadeMedida");
            DataRow dr = Dt.Tables["UnidadeMedida"].NewRow();
            dr[1] = "";
            Dt.Tables["UnidadeMedida"].Rows.Add(dr);
            try
            {

                this.cbounidade.DisplayMember = "nome";
                this.cbounidade.ValueMember = "idunidade";
                this.cbounidade.DataSource = Dt.Tables["UnidadeMedida"];
                this.cbounidade.SelectedIndex = cbounidade.Items.Count - 1;



            }
            catch (Exception erro)
            {

                throw erro;
            }
            Cnn.Close();
        }
        private void RetornaUnidade(Int32 retu)
        {
            SqlConnection Cnn = Banco.CriarConexao();
            SqlDataAdapter sql = new SqlDataAdapter("Select * from UnidadeMedida WHERE idunidade=" + retu + "", Cnn);
            DataTable Dt = new DataTable();
            sql.Fill(Dt);
            try
            {
                this.cbounidade.DataSource = Dt;
                this.cbounidade.DisplayMember = "nome";
                this.cbounidade.ValueMember = "idunidade";
                this.cbounidade.Refresh();




            }
            catch (Exception erro)
            {

                throw erro;
            }
            Cnn.Close();
        }
        private void CarregarProcedencia()
        {
            SqlConnection Cnn = Banco.CriarConexao();
            SqlDataAdapter sql = new SqlDataAdapter("Select * from Procedencia", Cnn);
            DataSet Dt = new DataSet();
            sql.Fill(Dt, "Procedencia");
            DataRow dr = Dt.Tables["Procedencia"].NewRow();
            dr[1] = "";
            Dt.Tables["Procedencia"].Rows.Add(dr);
            try
            {

                this.cboprocedencia.DisplayMember = "nome";
                this.cboprocedencia.ValueMember = "idprocedencia";
                this.cboprocedencia.DataSource = Dt.Tables["Procedencia"];
                this.cboprocedencia.SelectedIndex = cboprocedencia.Items.Count - 1;



            }
            catch (Exception erro)
            {

                throw erro;
            }
            Cnn.Close();
        }
        private void RetornaProcedencia(Int32 retproc)
        {
            SqlConnection Cnn = Banco.CriarConexao();
            SqlDataAdapter sql = new SqlDataAdapter("Select * from Procedencia WHERE idprocedencia=" + retproc + "", Cnn);
            DataTable Dt = new DataTable();
            sql.Fill(Dt);
            try
            {
                this.cboprocedencia.DataSource = Dt;
                this.cboprocedencia.DisplayMember = "nome";
                this.cboprocedencia.ValueMember = "idprocedencia";
                this.cboprocedencia.Refresh();




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
            SqlDataAdapter sql = new SqlDataAdapter("Select * from Fabricante", Cnn);
            DataSet Dt = new DataSet();
            sql.Fill(Dt, "Fabricante");
            DataRow dr = Dt.Tables["Fabricante"].NewRow();
            dr[1] = "";
            Dt.Tables["Fabricante"].Rows.Add(dr);
            try
            {

                this.cbofabricante.DisplayMember = "nome";
                this.cbofabricante.ValueMember = "idfabricante";
                this.cbofabricante.DataSource = Dt.Tables["Fabricante"];
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
            SqlDataAdapter sql = new SqlDataAdapter("Select * from Fabricante WHERE idfabricante=" + retfab + "", Cnn);
            DataTable Dt = new DataTable();
            sql.Fill(Dt);
            try
            {
                this.cbofabricante.DataSource = Dt;
                this.cbofabricante.DisplayMember = "nome";
                this.cbofabricante.ValueMember = "idfabricante";
                this.cbofabricante.Refresh();




            }
            catch (Exception erro)
            {

                throw erro;
            }
            Cnn.Close();
        }

        private void CarregarClassificacao()
        {
            SqlConnection Cnn = Banco.CriarConexao();
            SqlDataAdapter sql = new SqlDataAdapter("Select * from ClassificacaoFiscal", Cnn);
            DataSet Dt = new DataSet();
            sql.Fill(Dt, "ClassificacaoFiscal");
            DataRow dr = Dt.Tables["ClassificacaoFiscal"].NewRow();
            dr[1] = "";
            Dt.Tables["ClassificacaoFiscal"].Rows.Add(dr);
            try
            {

                this.cboclassificacao.DisplayMember = "nome";
                this.cboclassificacao.ValueMember = "idclassificacaofiscal";
                this.cboclassificacao.DataSource = Dt.Tables["ClassificacaoFiscal"];
                this.cboclassificacao.SelectedIndex = cboclassificacao.Items.Count - 1;



            }
            catch (Exception erro)
            {

                throw erro;
            }
            Cnn.Close();
        }
        private void RetornaClassificacao(Int32 retcla)
        {
            SqlConnection Cnn = Banco.CriarConexao();
            SqlDataAdapter sql = new SqlDataAdapter("Select * from ClassificacaoFiscal WHERE idclassificacaofiscal=" + retcla + "", Cnn);
            DataTable Dt = new DataTable();
            sql.Fill(Dt);
            try
            {
                this.cboclassificacao.DataSource = Dt;
                this.cboclassificacao.DisplayMember = "nome";
                this.cboclassificacao.ValueMember = "idclassificacaofiscal";
                this.cboclassificacao.Refresh();




            }
            catch (Exception erro)
            {

                throw erro;
            }
            Cnn.Close();
        }



        private void cboprincipio_KeyPress(object sender, KeyPressEventArgs e)
        {
            if ((Keys)e.KeyChar == Keys.Enter)
            {
                this.txtnome.Focus();
            }
        }

        private void cbofornecedor_KeyPress(object sender, KeyPressEventArgs e)
        {
            if ((Keys)e.KeyChar == Keys.Enter)
            {
                this.txtnome.Focus();
            }
        }

        private void txtnome_KeyPress(object sender, KeyPressEventArgs e)
        {
            if ((Keys)e.KeyChar == Keys.Enter)
            {
                this.cbounidade.Focus();
            }
        }

        private void cbounidade_KeyPress(object sender, KeyPressEventArgs e)
        {
            if ((Keys)e.KeyChar == Keys.Enter)
            {
                this.txtapresentacao.Focus();
            }
        }

        private void cbostatus_KeyPress(object sender, KeyPressEventArgs e)
        {
            if ((Keys)e.KeyChar == Keys.Enter)
            {
                this.txtregistro.Focus();
            }
        }

        private void txtregistro_KeyPress(object sender, KeyPressEventArgs e)
        {
            if ((Keys)e.KeyChar == Keys.Enter)
            {
                this.mskvalidade.Focus();
            }
        }

        private void mskvalidade_KeyPress(object sender, KeyPressEventArgs e)
        {
            if ((Keys)e.KeyChar == Keys.Enter)
            {
                this.cboprocedencia.Focus();
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
            if ((Keys)e.KeyChar == Keys.Enter)
            {
                this.cbomarca.Focus();
            }
        }

        private void txtprecofabrica_KeyPress(object sender, KeyPressEventArgs e)
        {
            if ((Keys)e.KeyChar == Keys.Enter)
            {

                decimal precofabrica = Convert.ToDecimal(this.txtprecofabrica.Text);
                this.txtprecofabrica.Text = String.Format("{0:N2}", Math.Round(precofabrica, 2));


                this.txtpmvg.Focus();
            }
        }

        private void txtpmvg_KeyPress(object sender, KeyPressEventArgs e)
        {
            if ((Keys)e.KeyChar == Keys.Enter)
            {
                decimal pmvg = Convert.ToDecimal(this.txtpmvg.Text);
                this.txtpmvg.Text = String.Format("{0:N2}", Math.Round(pmvg, 2));

                txtconvenio.Focus();
            }
        }

        private void txtconvenio_KeyPress(object sender, KeyPressEventArgs e)
        {
            if ((Keys)e.KeyChar == Keys.Enter)
            {
                this.txtcap.Focus();
            }
        }

        private void txtcap_KeyPress(object sender, KeyPressEventArgs e)
        {
            if ((Keys)e.KeyChar == Keys.Enter)
            {
                this.cboclassificacao.Focus();
            }
        }

        private void cboclassificacao_KeyPress(object sender, KeyPressEventArgs e)
        {
            if ((Keys)e.KeyChar == Keys.Enter)
            {
                this.BtnSalvar.Focus();
            }
        }

        private void BtnNovo_Click(object sender, EventArgs e)
        {
            Limpacampos();
        }

        private void dtvalidade_ValueChanged(object sender, EventArgs e)
        {
            this.mskvalidade.Text = dtvalidade.Value.ToString("dd/MM/yyyy");
        }

        private void BtnSalvar_Click(object sender, EventArgs e)
        {

            if (ValidaCampos() == true)
            {
                VlProduto obj = new VlProduto();

                if (txtcodigo.Text != "")
                {
                    obj.idproduto = Convert.ToInt32(txtcodigo.Text);
                }
                obj.idprincipio = Convert.ToInt32(cboprincipio.SelectedValue);
                obj.nome = txtnome.Text.ToUpper();
                obj.idunidade = Convert.ToInt32(cbounidade.SelectedValue);
                obj.apresentacao = txtapresentacao.Text.ToUpper();
                obj.codca = txtcodca.Text;
                obj.registro = txtregistro.Text;
                if (mskvalidade.Text != "  /  /")
                {
                    obj.dtvalidade = mskvalidade.Text;
                }
                else
                {
                    obj.dtvalidade = "";
                }
                obj.idprocedencia = Convert.ToInt32(cboprocedencia.SelectedValue);
                obj.idfabricante = Convert.ToInt32(cbofabricante.SelectedValue);
                obj.precofabrica = Convert.ToDecimal(txtprecofabrica.Text);
                obj.pmvg = Convert.ToDecimal(txtpmvg.Text);
                obj.convenioicms = Convert.ToDecimal(txtconvenio.Text);
                obj.cap = Convert.ToDecimal(txtcap.Text);
                if (cboclassificacao.Text != "")
                {
                    obj.idclassificacaofiscal = Convert.ToInt32(cboclassificacao.SelectedValue);
                }
                else
                {
                    obj.idclassificacaofiscal = 0;
                }
                obj.dtcadastro = mskcad.Text;
                obj.idusu = Banco.idusu;
                obj.idempresa = Banco.idemp;
                obj.statusprod = cbostatus.Text.ToUpper();
                obj.idmarca = Convert.ToInt32(cbomarca.SelectedValue);
                obj.validadeprod = txtvalidadeproduto.Text.ToUpper();




                try
                {
                    if (VerificaRegistroExiste(txtcodigo.Text) == true)
                    {

                        PsProduto DAOPsProduto = new PsProduto();
                        DAOPsProduto.Incluir(obj);
                        MessageBox.Show("Registro Incluido com Sucesso!");
                        Limpacampos();
                    }
                    else
                    {

                        PsProduto DAOPsProduto = new PsProduto();
                        DAOPsProduto.Alterar(obj);
                        MessageBox.Show("Registro Alterada com Sucesso!");
                        //Limpacampos();
                        //RetReg();

                    }
                }
                catch (Exception erro)
                {

                    throw erro;
                }
            }


        }
        private Boolean VerificaRegistroExiste(string qd)
        {

            SqlConnection Cnn = Banco.CriarConexao();
            string obter = ("Select * From Produto Where idproduto = '" + txtcodigo.Text + "'");
            SqlCommand sql = new SqlCommand(obter, Cnn);
            Cnn.Open();
            SqlDataReader dr = sql.ExecuteReader();
            if (dr.Read())
            {

                return false;
            }
            return true;
        }

        private void btnPesquisar_Click(object sender, EventArgs e)
        {
            ConsProduto frmc = new ConsProduto();
            this.Close();
            frmc.Show();
        }

        private void BtnRemover_Click(object sender, EventArgs e)
        {
            VlProduto obj = new VlProduto();
            obj.idproduto = Convert.ToInt32(txtcodigo.Text);

            try
            {
                PsProduto DAOPsProduto = new PsProduto();
                DAOPsProduto.Exluir(obj.idproduto);
                MessageBox.Show("Registro Excluido Com Sucesso!");
                Limpacampos();




            }
            catch (Exception erro)
            {

                throw erro;
            }
        }

        private void ViewProduto_Load(object sender, EventArgs e)
        {
            mskcad.Text = DateTime.Now.ToString("dd/MM/yyyy");
        }

        private void cboprincipio_Click(object sender, EventArgs e)
        {
            CarregarPricipio();
        }

        private void cbofornecedor_Click(object sender, EventArgs e)
        {
            //CarregarFornecedor();
        }

        private void cbounidade_Click(object sender, EventArgs e)
        {
            CarregarUnidadeMedidade();
        }

        private void cbostatus_Click(object sender, EventArgs e)
        {
            //if (txtcodca.Text == "ISENTO")
            //{
            //    txtregistro.Enabled = false;
            //}
            //else if (cbostatus.Text == "NOTIFICADO")
            //{
            //    txtregistro.Enabled = true;
            //}
        }

        private void cboprocedencia_Click(object sender, EventArgs e)
        {
            CarregarProcedencia();
        }

        private void cbofabricante_Click(object sender, EventArgs e)
        {
            CarregarFabricante();
        }

        private void cboclassificacao_Click(object sender, EventArgs e)
        {
            CarregarClassificacao();
        }

        private void BtnSair_Click(object sender, EventArgs e)
        {
            this.Close();
        }
         
        private void button1_Click(object sender, EventArgs e)
        {
            ViewCotarFornecedores frmcotar = new ViewCotarFornecedores(this);
            this.Close();
            frmcotar.Show();
        }

        DataGridViewCheckBoxColumn chk = new DataGridViewCheckBoxColumn();

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
                string strConn = "Select DISTINCT Produto_Fornecedor.idprodfornecedor as Codigo, Fornecedor.nome as Fornecedor " +
                "from Fornecedor, Produto_Fornecedor,Produto " +
               " where Produto_Fornecedor.idfornecedor = Fornecedor.idfornecedor and Produto_Fornecedor.idproduto = Produto.idproduto " +
               "and  Produto.idproduto=" + codproduto + "";


                SqlDataAdapter da = new SqlDataAdapter(strConn, Conn);
                da.Fill(ds);


            }

            this.griditens.RowsDefaultCellStyle.BackColor = Color.LightBlue;
            this.griditens.AlternatingRowsDefaultCellStyle.BackColor = Color.Azure;

            griditens.DataSource = ds;
            griditens.Columns.Clear();
            griditens.Columns.Add(chk);
            chk.HeaderText = "Sel";
            chk.Name = "chk";
            griditens.Columns.Add("Codigo", "Codigo");
            griditens.Columns.Add("Fornecedor", "Fornecedor");


            griditens.Columns[0].Width = 50;
            griditens.Columns[1].Width = 80;
            griditens.Columns[2].Width = 600;



            griditens.Columns[1].DataPropertyName = "Codigo";
            griditens.Columns[2].DataPropertyName = "Fornecedor";



            DataGridViewButtonColumn btn = new DataGridViewButtonColumn();
            griditens.Columns.Add(btn);
            btn.HeaderText = "Excluir";
            btn.Text = "Excluir";
            btn.Name = "btn";
            btn.Width = 60;
            btn.UseColumnTextForButtonValue = true;
            btn.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft;



            griditens.Refresh();




        }

        private void cbomarca_KeyPress(object sender, KeyPressEventArgs e)
        {
            if ((Keys)e.KeyChar == Keys.Enter)
            {
                this.txtprecofabrica.Focus();
            }
        }

        private void cbofabricante_SelectionChangeCommitted(object sender, EventArgs e)
        {

            SqlConnection Cnn = Banco.CriarConexao();
            SqlDataAdapter sql = new SqlDataAdapter("Select Marca.idmarca as idmarca,Marca.nome as Marca from Fabricante,Marca " +
                " WHERE Fabricante.idfabricante = Marca.idfabricante And Fabricante.idfabricante='" + cbofabricante.SelectedValue + "'", Cnn);
            DataSet Dt = new DataSet();
            sql.Fill(Dt);
            BindingSource bs = new BindingSource();
            bs.DataSource = Dt;
            bs.DataMember = Dt.Tables[0].TableName;

            try
            {
                this.cbomarca.DataSource = bs;
                this.cbomarca.DisplayMember = "Marca";
                this.cbomarca.ValueMember = "idmarca";
                this.cbomarca.SelectedIndex = cbomarca.Items.Count - 1;



            }
            catch (Exception erro)
            {

                throw erro;
            }
            Cnn.Close();



        }

        private void cbomarca_Click(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            ConsProdutoPreco frmc = new ConsProdutoPreco();
            frmc.Show();
        }

        private void txtstatus_KeyPress(object sender, KeyPressEventArgs e)
        {
            if ((Keys)e.KeyChar == Keys.Enter)
            {
                this.txtvalidadeproduto.Focus();
            }
        }

        private void griditens_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex == 1)
            {

                int codfor = int.Parse(griditens.Rows[e.RowIndex].Cells[2].Value.ToString());
                VlProduto_Fornecedor obj = new VlProduto_Fornecedor();

                obj.idprodfornecedor = codfor;

                PsProduto_Fornecedor DAOProd_Fornecedor = new PsProduto_Fornecedor();
                DAOProd_Fornecedor.Exluir(obj.idprodfornecedor);
                carregarGridItens();
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            ViewPrincipioAtivo ativo = new ViewPrincipioAtivo();
            ativo.Show();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            ViewUnidadeMedida medida = new ViewUnidadeMedida();
            medida.Show();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            ViewProcedencia procedencia = new ViewProcedencia();
            procedencia.Show();
        }

        private void button6_Click(object sender, EventArgs e)
        {
            ViewFabricante fabricante = new ViewFabricante();
            fabricante.Show();
        }
    }
}
