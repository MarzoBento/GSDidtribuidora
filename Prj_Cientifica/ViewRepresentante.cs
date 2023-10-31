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
    public partial class ViewRepresentante : Form
    {

        public static string TipoGravacao;
        public static string UltimoSelecionado;

        public ViewRepresentante()
        {
            InitializeComponent();
        }


        public ViewRepresentante(ConsRepresentante frm) : this()
        {
            UltimoSelecionado = Convert.ToString(frm.codrepresentante);
            RetReg();


        }

        private void RetReg()
        {
            string reg = "Select * from Representante ";
            if (UltimoSelecionado != null)
                reg += "Where idrepresentante = " + UltimoSelecionado;
            else reg += "Where idrepresentante = (Select Max(idrepresentante) from Representante)";
            DataTable ds = new DataTable();
            SqlConnection Conn = Banco.CriarConexao();
            Conn.Open();

            if (Conn.State == ConnectionState.Open)
            {
                SqlCommand cmd = new SqlCommand(reg, Conn);
                SqlDataReader dr = cmd.ExecuteReader();
                if (dr.Read())
                {
                    txtcodigo.Text = dr["idrepresentante"].ToString();
                    maskcnpj.Text = dr["cnpj"].ToString();
                    mskcpf.Text = dr["cpf"].ToString();
                    txtinscestadual.Text = dr["inscestadual"].ToString();
                    txtrg.Text = dr["rg"].ToString();
                    txtrazao.Text = dr["razao"].ToString();
                    txtnome.Text = dr["nomerep"].ToString();
                    txtendereco.Text = dr["endereco"].ToString();
                    txtbairro.Text = dr["bairro"].ToString();
                    mskcep.Text = dr["cep"].ToString();
                    RetornaCidade(Convert.ToInt32(dr["idcidade"].ToString()));
                    mskfone.Text = dr["fone"].ToString();
                    txtramal.Text = dr["ramal"].ToString();
                    msk.Text = dr["celular"].ToString();
                    mskfax.Text = dr["fax"].ToString();
                    txtemail.Text = dr["email"].ToString();
                    txtcomissao.Text = dr["comissao"].ToString();
                    txtsite.Text = dr["site"].ToString();
                    RetornaRegiao(Convert.ToInt32(dr["idregiao"].ToString()));
                    txtobs.Text = dr["obs"].ToString();
                    mskcad.Text = dr["dtcadastro"].ToString();
                    txtcontato.Text = dr["contato"].ToString();
                    mskcelcontato.Text = dr["celcontato"].ToString();
                    mskfonecontato.Text = dr["fonecontato"].ToString();
                    txtobscontato.Text = dr["obscontato"].ToString();
                    txtemailcontato.Text = dr["emailcontato"].ToString();

                    carregarGridConsulta();

                }
            }
        }


        private void carregarGridConsulta()
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
                string strConn = "Select DISTINCT ContaRepresentante.idcontarep as Cod,Banco.nome as Banco,ContaRepresentante.Agencia as Agencia, ContaRepresentante.conta as Conta, ContaRepresentante.favorecido as Favorecido" +
                " from Banco,ContaRepresentante,Representante Where Banco.idbanco = ContaRepresentante.idbanco AND Representante.idrepresentante = ContaRepresentante.idrepresentante AND Representante.idrepresentante=" + txtcodigo.Text + "";

                SqlDataAdapter da = new SqlDataAdapter(strConn, Conn);
                da.Fill(ds);


            }

            this.griditens.RowsDefaultCellStyle.BackColor = Color.LightBlue;
            this.griditens.AlternatingRowsDefaultCellStyle.BackColor = Color.Azure;


            griditens.AutoGenerateColumns = false;
            //exibe os dados no datagridview
            griditens.DataSource = ds;
            griditens.Columns.Clear();
            griditens.Columns.Add("Cod", "Cod");
            griditens.Columns.Add("Banco", "Banco");
            griditens.Columns.Add("Agencia", "Agencia");
            griditens.Columns.Add("Conta", "Conta");
            griditens.Columns.Add("Favorecido", "Favorecido");

            griditens.Columns[0].Width = 45;
            griditens.Columns[1].Width = 220;
            griditens.Columns[2].Width = 100;
            griditens.Columns[3].Width = 100;
            griditens.Columns[4].Width = 200;


            griditens.Columns[0].DataPropertyName = "Cod";
            griditens.Columns[1].DataPropertyName = "Banco";
            griditens.Columns[2].DataPropertyName = "Agencia";
            griditens.Columns[3].DataPropertyName = "Conta";
            griditens.Columns[4].DataPropertyName = "Favorecido";


            DataGridViewButtonColumn btn = new DataGridViewButtonColumn();
            griditens.Columns.Add(btn);
            btn.HeaderText = "Excluir";
            btn.Text = "Excluir";
            btn.Name = "btn";
            btn.Width = 50;
            btn.UseColumnTextForButtonValue = true;
            btn.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft;



            griditens.Refresh();
        }



        private void CarregarCidade()
        {
            SqlConnection Cnn = Banco.CriarConexao();
            SqlDataAdapter sql = new SqlDataAdapter("Select * from Cidade Order by nome asc", Cnn);
            DataSet Dt = new DataSet();
            sql.Fill(Dt, "Cidade");
            DataRow dr = Dt.Tables["Cidade"].NewRow();
            dr[1] = "";
            Dt.Tables["Cidade"].Rows.Add(dr);
            try
            {

                this.cbocidade.DisplayMember = "nome";
                this.cbocidade.ValueMember = "idcidade";
                this.cbocidade.DataSource = Dt.Tables["Cidade"];
                this.cbocidade.SelectedIndex = cbocidade.Items.Count - 1;



            }
            catch (Exception erro)
            {

                throw erro;
            }
            Cnn.Close();
        }
        private void RetornaCidade(Int32 retcid)
        {
            SqlConnection Cnn = Banco.CriarConexao();
            SqlDataAdapter sql = new SqlDataAdapter("Select * from Cidade WHERE idcidade=" + retcid + "", Cnn);
            DataTable Dt = new DataTable();
            sql.Fill(Dt);
            try
            {
                this.cbocidade.DataSource = Dt;
                this.cbocidade.DisplayMember = "nome";
                this.cbocidade.ValueMember = "idcidade";
                this.cbocidade.Refresh();




            }
            catch (Exception erro)
            {

                throw erro;
            }
            Cnn.Close();
        }
        private void CarregarRegiao()
        {
            SqlConnection Cnn = Banco.CriarConexao();
            SqlDataAdapter sql = new SqlDataAdapter("Select * from Regiao", Cnn);
            DataSet Dt = new DataSet();
            sql.Fill(Dt, "Regiao");
            DataRow dr = Dt.Tables["Regiao"].NewRow();
            dr[1] = "";
            Dt.Tables["Regiao"].Rows.Add(dr);
            try
            {

                this.cboregiao.DisplayMember = "nome";
                this.cboregiao.ValueMember = "idregiao";
                this.cboregiao.DataSource = Dt.Tables["Regiao"];
                this.cboregiao.SelectedIndex = cboregiao.Items.Count - 1;



            }
            catch (Exception erro)
            {

                throw erro;
            }
            Cnn.Close();
        }
        private void RetornaRegiao(Int32 retregiao)
        {
            SqlConnection Cnn = Banco.CriarConexao();
            SqlDataAdapter sql = new SqlDataAdapter("Select * from Regiao WHERE idregiao=" + retregiao + "", Cnn);
            DataTable Dt = new DataTable();
            sql.Fill(Dt);
            try
            {
                this.cboregiao.DataSource = Dt;
                this.cboregiao.DisplayMember = "nome";
                this.cboregiao.ValueMember = "idregiao";
                this.cboregiao.Refresh();




            }
            catch (Exception erro)
            {

                throw erro;
            }
            Cnn.Close();
        }

        private void CarregarBanco()
        {
            SqlConnection Cnn = Banco.CriarConexao();
            SqlDataAdapter sql = new SqlDataAdapter("Select * from Banco", Cnn);
            DataSet Dt = new DataSet();
            sql.Fill(Dt, "Banco");
            DataRow dr = Dt.Tables["Banco"].NewRow();
            dr[1] = "";
            Dt.Tables["Banco"].Rows.Add(dr);
            try
            {

                this.cbobanco.DisplayMember = "nome";
                this.cbobanco.ValueMember = "idbanco";
                this.cbobanco.DataSource = Dt.Tables["Banco"];
                this.cbobanco.SelectedIndex = cbobanco.Items.Count - 1;



            }
            catch (Exception erro)
            {

                throw erro;
            }
            Cnn.Close();
        }
        private void RetornaBanco(Int32 retcid)
        {
            SqlConnection Cnn = Banco.CriarConexao();
            SqlDataAdapter sql = new SqlDataAdapter("Select * from Banco WHERE idbanco=" + retcid + "", Cnn);
            DataTable Dt = new DataTable();
            sql.Fill(Dt);
            try
            {
                this.cbobanco.DataSource = Dt;
                this.cbobanco.DisplayMember = "nome";
                this.cbobanco.ValueMember = "idbanco";
                this.cbobanco.Refresh();




            }
            catch (Exception erro)
            {

                throw erro;
            }
            Cnn.Close();
        }



        private void cboregiao_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void maskcnpj_KeyPress(object sender, KeyPressEventArgs e)
        {
            if ((Keys)e.KeyChar == Keys.Enter)
            {
                this.txtinscestadual.Focus();
            }
        }

        private void txtrg_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox3_TextChanged(object sender, EventArgs e)
        {

        }

        private void txtinscestadual_KeyPress(object sender, KeyPressEventArgs e)
        {
            if ((Keys)e.KeyChar == Keys.Enter)
            {
                this.mskcpf.Focus();
            }
        }

        private void mskcpf_KeyPress(object sender, KeyPressEventArgs e)
        {
            if ((Keys)e.KeyChar == Keys.Enter)
            {
                this.txtrg.Focus();
            }
        }

        private void txtrg_KeyPress(object sender, KeyPressEventArgs e)
        {
            if ((Keys)e.KeyChar == Keys.Enter)
            {
                this.txtrazao.Focus();
            }
        }

        private void txtrazao_KeyPress(object sender, KeyPressEventArgs e)
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
                this.txtendereco.Focus();
            }
        }

        private void txtendereco_KeyPress(object sender, KeyPressEventArgs e)
        {
            if ((Keys)e.KeyChar == Keys.Enter)
            {
                this.txtbairro.Focus();
            }
        }

        private void txtbairro_KeyPress(object sender, KeyPressEventArgs e)
        {
            if ((Keys)e.KeyChar == Keys.Enter)
            {
                this.cbocidade.Focus();
            }
        }

        private void cbocidade_KeyPress(object sender, KeyPressEventArgs e)
        {
            if ((Keys)e.KeyChar == Keys.Enter)
            {
                this.mskcep.Focus();
            }
        }

        private void mskcep_KeyPress(object sender, KeyPressEventArgs e)
        {
            if ((Keys)e.KeyChar == Keys.Enter)
            {
                this.mskfone.Focus();
            }
        }

        private void mskfone_KeyPress(object sender, KeyPressEventArgs e)
        {
            if ((Keys)e.KeyChar == Keys.Enter)
            {
                this.txtramal.Focus();
            }
        }

        private void txtramal_KeyPress(object sender, KeyPressEventArgs e)
        {
            if ((Keys)e.KeyChar == Keys.Enter)
            {
                this.msk.Focus();
            }
        }

        private void msk_KeyPress(object sender, KeyPressEventArgs e)
        {
            if ((Keys)e.KeyChar == Keys.Enter)
            {
                this.mskfax.Focus();
            }
        }

        private void mskfax_KeyPress(object sender, KeyPressEventArgs e)
        {
            if ((Keys)e.KeyChar == Keys.Enter)
            {
                this.txtemail.Focus();
            }
        }

        private void txtemail_KeyPress(object sender, KeyPressEventArgs e)
        {
            if ((Keys)e.KeyChar == Keys.Enter)
            {
                this.txtsite.Focus();
            }
        }

        private void txtsite_KeyPress(object sender, KeyPressEventArgs e)
        {
            if ((Keys)e.KeyChar == Keys.Enter)
            {
                this.txtcomissao.Focus();
            }
        }

        private void txtcomissao_KeyPress(object sender, KeyPressEventArgs e)
        {
            if ((Keys)e.KeyChar == Keys.Enter)
            {
                this.cboregiao.Focus();
            }
        }

        private void cboregiao_KeyPress(object sender, KeyPressEventArgs e)
        {
            if ((Keys)e.KeyChar == Keys.Enter)
            {
                this.txtobs.Focus();
            }
        }

        private void txtobs_KeyPress(object sender, KeyPressEventArgs e)
        {
            if ((Keys)e.KeyChar == Keys.Enter)
            {
                this.txtcontato.Focus();
            }
        }

        private void txtcontato_KeyPress(object sender, KeyPressEventArgs e)
        {
            if ((Keys)e.KeyChar == Keys.Enter)
            {
                this.mskcelcontato.Focus();
            }
        }

        private void mskcelcontato_KeyPress(object sender, KeyPressEventArgs e)
        {
            if ((Keys)e.KeyChar == Keys.Enter)
            {
                this.mskfonecontato.Focus();
            }
        }

        private void mskfonecontato_KeyPress(object sender, KeyPressEventArgs e)
        {
            if ((Keys)e.KeyChar == Keys.Enter)
            {
                this.txtfuncao.Focus();
            }
        }

        private void txtfuncao_KeyPress(object sender, KeyPressEventArgs e)
        {
            if ((Keys)e.KeyChar == Keys.Enter)
            {
                this.txtobscontato.Focus();
            }
        }

        private void txtobscontato_KeyPress(object sender, KeyPressEventArgs e)
        {
            if ((Keys)e.KeyChar == Keys.Enter)
            {
                this.txtemailcontato.Focus();
            }
        }

        private void txtemailcontato_KeyPress(object sender, KeyPressEventArgs e)
        {
            if ((Keys)e.KeyChar == Keys.Enter)
            {
                this.BtnSalvar.Focus();
            }
        }

        private void cbobanco_KeyPress(object sender, KeyPressEventArgs e)
        {
            if ((Keys)e.KeyChar == Keys.Enter)
            {
                this.txtagencia.Focus();
            }

        }

        private void txtagencia_KeyPress(object sender, KeyPressEventArgs e)
        {
            if ((Keys)e.KeyChar == Keys.Enter)
            {
                this.txtnconta.Focus();
            }
        }

        private void txtnconta_KeyPress(object sender, KeyPressEventArgs e)
        {
            if ((Keys)e.KeyChar == Keys.Enter)
            {
                this.txtfavorecido.Focus();
            }
        }

        private void txtfavorecido_KeyPress(object sender, KeyPressEventArgs e)
        {
            if ((Keys)e.KeyChar == Keys.Enter)
            {
                this.btnAdd.Focus();
            }
        }

        private void cbocidade_Click(object sender, EventArgs e)
        {
            CarregarCidade();
        }

        private void cboregiao_Click(object sender, EventArgs e)
        {
            CarregarRegiao();
        }

        private void cbobanco_Click(object sender, EventArgs e)
        {
            CarregarBanco();
        }

        private void ViewRepresentante_Load(object sender, EventArgs e)
        {
            mskcad.Text = DateTime.Now.ToString("dd/MM/yyyy");
        }



        private void Limpacampos()
        {
            txtcodigo.Text = "";
            this.txtrazao.Text = "";
            this.txtnome.Text = "";
            txtinscestadual.Text = "";
            this.maskcnpj.Text = "";
            txtendereco.Text = "";
            txtbairro.Text = "";
            mskcep.Text = "";
            cbocidade.SelectedIndex = -1;
            this.mskfone.Text = "";
            this.msk.Text = "";
            txtramal.Text = "";
            txtcontato.Text = "";
            mskfax.Text = "";
            this.mskcad.Text = "";
            this.txtemail.Text = "";
            txtcontato.Text = "";
            txtsite.Text = "";
            txtcomissao.Text = "0";
            mskcep.Text = "";
            txtrg.Text = "";
            this.mskcpf.Text = "";
            cboregiao.SelectedIndex = -1;
            mskcelcontato.Text = "";
            mskfone.Text = "";
            txtfuncao.Text = "";
            txtobscontato.Text = "";
            txtemailcontato.Text = "";
            griditens.DataSource = null;
            this.maskcnpj.Focus();

        }

        private Boolean ValidaCampos()
        {
            if (this.txtnome.Text == "")
            {
                MessageBox.Show("Informe o Nome do Representante");
                txtnome.Focus();
                return false;

            }

            if (this.txtrazao.Text == "")
            {
                MessageBox.Show("Informe a Razão Social");
                txtrazao.Focus();
                return false;

            }

            if (this.cbocidade.Text == "")
            {
                MessageBox.Show("informe a Cidade");
                cbocidade.Focus();
                return false;

            }
            if (this.cboregiao.Text == "")
            {
                MessageBox.Show("informe a Região");
                cboregiao.Focus();
                return false;

            }
            if (this.mskfone.Text == "(  )    -    ")
            {
                MessageBox.Show("informe o Nº do Telefone!");
                mskfone.Focus();
                return false;

            }

            if (this.msk.Text == "(  )     -    ")
            {
                MessageBox.Show("informe o Nº do Celular!");
                mskfone.Focus();
                return false;

            }

            if (this.mskcad.Text == "__/__/____")
            {
                MessageBox.Show("informe a Data de Cadastro");
                mskcad.Focus();
                return false;

            }


            return true;


        }

        private void BtnNovo_Click(object sender, EventArgs e)
        {
            Limpacampos();
        }

        private void BtnSair_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void BtnSalvar_Click(object sender, EventArgs e)
        {
            if (ValidaCampos() == true)
            {
                VlRepresentante obj = new VlRepresentante();

                if (txtcodigo.Text != "")
                {
                    obj.idrepresentante = Convert.ToInt32(txtcodigo.Text);
                }

                obj.cnpj = maskcnpj.Text;
                obj.inscestadual = txtinscestadual.Text;
                obj.cpf = mskcpf.Text;
                obj.rg = txtrg.Text;
                obj.razao = txtrazao.Text.ToUpper();
                obj.nomerep = txtnome.Text.ToUpper();
                obj.endereco = txtendereco.Text.ToUpper();
                obj.bairro = txtbairro.Text.ToUpper();
                obj.idcidade = Convert.ToInt32(cbocidade.SelectedValue);
                obj.cep = mskcep.Text;
                obj.fone = mskfone.Text;
                obj.ramal = txtramal.Text;
                obj.celular = msk.Text;
                obj.fax = mskfax.Text;
                obj.email = txtemail.Text.ToLower();
                obj.site = txtsite.Text.ToLower();
                obj.comissao = Convert.ToDecimal(txtcomissao.Text);
                obj.idregiao = Convert.ToInt32(cboregiao.SelectedValue);
                obj.obs = txtobs.Text.ToUpper();
                obj.dtcadastro = mskcad.Text;
                obj.contato = txtcontato.Text.ToUpper();
                obj.celcontato = mskcelcontato.Text;
                obj.fonecontato = mskfonecontato.Text;
                obj.funcao = txtfuncao.Text;
                obj.obscontato = txtobscontato.Text.ToUpper();
                obj.emailcontato = txtemailcontato.Text.ToLower();
                obj.idempresa = Banco.idemp;
                obj.idusu = Banco.idusu;

                try
                {
                    if (VerificaRegistroExiste(txtcodigo.Text) == true)
                    {

                        PsRepresentante DAORepresentante = new PsRepresentante();
                        DAORepresentante.Incluir(obj);
                        MessageBox.Show("Registro Incluido com Sucesso!");
                        // Limpacampos();
                        RetReg();
                    }
                    else
                    {


                        PsRepresentante DAORepresentante = new PsRepresentante();
                        DAORepresentante.Alterar(obj);
                        MessageBox.Show("Registro Alterada com Sucesso!");
                        // Limpacampos();
                        RetReg();

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
            string obter = ("Select * From Representante Where idrepresentante = '" + txtcodigo.Text + "'");
            SqlCommand sql = new SqlCommand(obter, Cnn);
            Cnn.Open();
            SqlDataReader dr = sql.ExecuteReader();
            if (dr.Read())
            {

                return false;
            }
            return true;
        }

        private void BtnRemover_Click(object sender, EventArgs e)
        {
            VlRepresentante obj = new VlRepresentante();
            obj.idrepresentante = Convert.ToInt32(txtcodigo.Text);

            try
            {
                PsRepresentante DAORepresentante = new PsRepresentante();
                DAORepresentante.Exluir(obj.idrepresentante);
                MessageBox.Show("Registro Excluido Com Sucesso!");
                Limpacampos();




            }
            catch (Exception erro)
            {

                throw erro;
            }

        }

        private Boolean ValidaCampoDadosBancarios()
        {
            if (this.txtcodigo.Text == "")
            {
                MessageBox.Show("Não e Possível adicionar conta sem a Empresa!");
                txtcodigo.Focus();
                return false;

            }

            if (this.cbobanco.Text == "")
            {
                MessageBox.Show("Informe o Nome do Banco");
                cbobanco.Focus();
                return false;

            }

            if (this.txtagencia.Text == "")
            {
                MessageBox.Show("informe a Agência");
                txtagencia.Focus();
                return false;

            }
            if (this.txtnconta.Text == "")
            {
                MessageBox.Show("informe o Nº da Conta!");
                txtnconta.Focus();
                return false;

            }

            if (this.txtfavorecido.Text == "")
            {
                MessageBox.Show("informe o Nome do favorecido");
                txtfavorecido.Focus();
                return false;

            }


            return true;


        }

        private void LimpacamposConta()
        {
            cbobanco.SelectedIndex = -1;
            txtagencia.Text = "";
            txtnconta.Text = "";
            txtfavorecido.Text = "";
        }


        private void btnAdd_Click(object sender, EventArgs e)
        {
            if (ValidaCampoDadosBancarios() == true)
            {
                VlContaRepresentante obj = new VlContaRepresentante();
                obj.idrepresentante = Convert.ToInt32(txtcodigo.Text);
                obj.idbanco = Convert.ToInt32(cbobanco.SelectedValue);
                obj.agencia = txtagencia.Text;
                obj.conta = txtnconta.Text;
                obj.favorecido = txtfavorecido.Text.ToUpper();

                try
                {
                    PsContaRepresentante DAOContaRepresentante = new PsContaRepresentante();
                    DAOContaRepresentante.Incluir(obj);
                    MessageBox.Show("Registro Incluido com Sucesso!");
                    carregarGrid();
                    LimpacamposConta();
                    //RetReg();

                }
                catch (Exception erro)
                {

                    throw erro;
                }
            }

        }
        private void carregarGrid()
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
                string strConn = "Select DISTINCT ContaRepresentante.idcontarep as Cod,Banco.nome as Banco,ContaRepresentante.Agencia as Agencia, ContaRepresentante.conta as Conta, ContaRepresentante.favorecido as Favorecido" +
                " from Banco,ContaRepresentante,Representante Where Banco.idbanco = ContaRepresentante.idbanco AND Representante.idrepresentante = ContaRepresentante.idrepresentante AND ContaRepresentante.idrepresentante=" + txtcodigo.Text + "";

                SqlDataAdapter da = new SqlDataAdapter(strConn, Conn);
                da.Fill(ds);


            }

            this.griditens.RowsDefaultCellStyle.BackColor = Color.LightBlue;
            this.griditens.AlternatingRowsDefaultCellStyle.BackColor = Color.Azure;


            griditens.AutoGenerateColumns = false;
            //exibe os dados no datagridview
            griditens.DataSource = ds;
            griditens.Columns.Clear();
            griditens.Columns.Add("Cod", "Cod");
            griditens.Columns.Add("Banco", "Banco");
            griditens.Columns.Add("Agencia", "Agencia");
            griditens.Columns.Add("Conta", "Conta");
            griditens.Columns.Add("Favorecido", "Favorecido");

            griditens.Columns[0].Width = 45;
            griditens.Columns[1].Width = 220;
            griditens.Columns[2].Width = 100;
            griditens.Columns[3].Width = 100;
            griditens.Columns[4].Width = 200;


            griditens.Columns[0].DataPropertyName = "Cod";
            griditens.Columns[1].DataPropertyName = "Banco";
            griditens.Columns[2].DataPropertyName = "Agencia";
            griditens.Columns[3].DataPropertyName = "Conta";
            griditens.Columns[4].DataPropertyName = "Favorecido";


            DataGridViewButtonColumn btn = new DataGridViewButtonColumn();
            griditens.Columns.Add(btn);
            btn.HeaderText = "Excluir";
            btn.Text = "Excluir";
            btn.Name = "btn";
            btn.Width = 90;
            btn.UseColumnTextForButtonValue = true;
            btn.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft;



            griditens.Refresh();
        }

        private void btnPesquisar_Click(object sender, EventArgs e)
        {
            ConsRepresentante frmconv = new ConsRepresentante();
            this.Close();
            frmconv.Show();
        }
    }
}
