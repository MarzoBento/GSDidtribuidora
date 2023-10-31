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
    public partial class ViewFornecedor : Form
    {
        public static string TipoGravacao;
        public static string UltimoSelecionado;

        public ViewFornecedor()
        {
            InitializeComponent();
        }

        public ViewFornecedor(ConsFornecedor frm) : this()
        {
            UltimoSelecionado = Convert.ToString(frm.codfornecedor);
            RetReg();


        }

        private void RetReg()
        {
            string reg = "Select * from Fornecedor ";
            if (UltimoSelecionado != null)
                reg += "Where idfornecedor = " + UltimoSelecionado;
            else reg += "Where idfornecedor = (Select Max(idfornecedor) from Fornecedor)";
            DataTable ds = new DataTable();
            SqlConnection Conn = Banco.CriarConexao();
            Conn.Open();

            if (Conn.State == ConnectionState.Open)
            {
                SqlCommand cmd = new SqlCommand(reg, Conn);
                SqlDataReader dr = cmd.ExecuteReader();
                if (dr.Read())
                {
                    txtcodigo.Text = dr["idfornecedor"].ToString();
                    maskcnpj.Text = dr["cnpj"].ToString();
                    txtinscestadual.Text = dr["inscestadual"].ToString();
                    cbofornecedor.Text = dr["status"].ToString();
                    txtrazao.Text = dr["razao"].ToString();
                    txtfornecedor.Text = dr["nome"].ToString();
                    txtendereco.Text = dr["endereco"].ToString();
                    txtbairro.Text = dr["bairro"].ToString();
                    RetornaCidade(Convert.ToInt32(dr["idcidade"].ToString()));
                    mskcep.Text = dr["cep"].ToString();
                    mskfax.Text = dr["fax"].ToString();
                    mskfone.Text = dr["fone"].ToString();
                    txtramal.Text = dr["ramal"].ToString();
                    msk.Text = dr["celular"].ToString();
                    txtemail.Text = dr["email"].ToString();
                    txtsite.Text = dr["site"].ToString();
                    txtobs.Text = dr["obs"].ToString();
                    txtcontato.Text = dr["contato"].ToString();
                    maskfonecontato.Text = dr["fonecontato"].ToString();
                    txtramalcontato.Text = dr["ramalcontato"].ToString();
                    mskcelcontato.Text = dr["celcontato"].ToString();
                    txtemailcontato.Text = dr["emailcontato"].ToString();
                    txtcontato2.Text = dr["contato2"].ToString();
                    mskfonecontato2.Text = dr["fonecontato2"].ToString();
                    txtramalcontato2.Text = dr["ramalcontato2"].ToString();
                    mskcelcontato2.Text = dr["celcontato2"].ToString();
                    txtemailcontato2.Text = dr["emailcontato2"].ToString();
                    //mskcad.Text = dr["dtcadastro"].ToString();

                    carregarGridConsulta();

                }
            }
        }

        private void Limpacampos()
        {
            txtcodigo.Text = "";
            cbofornecedor.Text = "";
            this.txtfornecedor.Text = "";
            this.txtrazao.Text = "";
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
            maskfonecontato.Text = "";
            txtramalcontato.Text = "";
            mskcelcontato.Text = "";
            txtemailcontato.Text = "";
            txtcontato2.Text = "";
            mskfonecontato2.Text = "";
            txtramalcontato2.Text = "";
            mskcelcontato2.Text = "";
            txtemailcontato2.Text = "";
            mskfax.Text = "";
           // this.mskcad.Text = "";
            this.txtemail.Text = "";
            txtsite.Text = "";
            mskcep.Text = "";
            this.maskcnpj.Focus();

        }

        private Boolean ValidaCampos()
        {
            if (this.txtfornecedor.Text == "")
            {
                MessageBox.Show("Informe o Nome do Fornecedor");
                txtfornecedor.Focus();
                return false;

            }
            if (this.maskcnpj.Text == "  .   .   /    -  ")
            {
                MessageBox.Show("Informe o Cnpj do Cliente");
                maskcnpj.Focus();
                return false;

            }

            if (this.cbocidade.Text == "")
            {
                MessageBox.Show("informe a Cidade");
                cbocidade.Focus();
                return false;

            }
            if (this.cbofornecedor.Text == "")
            {
                MessageBox.Show("informe o Status Ativo/Inativo !");
                cbofornecedor.Focus();
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
                msk.Focus();
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
                string strConn = "Select DISTINCT ContaFornecedor.idcontafor as Cod,Banco.nome as Banco,ContaFornecedor.Agencia as Agencia, ContaFornecedor.conta as Conta, ContaFornecedor.favorecido as Favorecido" +
                " from Banco,ContaFornecedor,Fornecedor Where Banco.idbanco = ContaFornecedor.idbanco AND Fornecedor.idfornecedor = ContaFornecedor.idfornecedor AND ContaFornecedor.idfornecedor=" + txtcodigo.Text + "";

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

        private void groupBox2_Enter(object sender, EventArgs e)
        {

        }

        private void label15_Click(object sender, EventArgs e)
        {

        }

        private void maskcnpj_KeyPress(object sender, KeyPressEventArgs e)
        {
            if ((Keys)e.KeyChar == Keys.Enter)
            {
                this.txtinscestadual.Focus();
            }
        }

        private void txtinscestadual_KeyPress(object sender, KeyPressEventArgs e)
        {
            if ((Keys)e.KeyChar == Keys.Enter)
            {
                this.cbofornecedor.Focus();
            }
        }

        private void cbofornecedor_KeyPress(object sender, KeyPressEventArgs e)
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
                this.txtfornecedor.Focus();
            }
        }

        private void txtfornecedor_KeyPress(object sender, KeyPressEventArgs e)
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
                this.mskfax.Focus();
            }
        }

        private void mskfax_KeyPress(object sender, KeyPressEventArgs e)
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
                this.txtobs.Focus();
            }
        }

        private void txtcontato_KeyPress(object sender, KeyPressEventArgs e)
        {
            if ((Keys)e.KeyChar == Keys.Enter)
            {
                this.maskfonecontato.Focus();
            }
        }

        private void maskfonecontato_KeyPress(object sender, KeyPressEventArgs e)
        {
            if ((Keys)e.KeyChar == Keys.Enter)
            {
                this.txtramalcontato.Focus();
            }
        }

        private void txtramalcontato_KeyPress(object sender, KeyPressEventArgs e)
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
                this.txtemailcontato.Focus();
            }
        }

        private void txtemailcontato_KeyPress(object sender, KeyPressEventArgs e)
        {
            if ((Keys)e.KeyChar == Keys.Enter)
            {
                this.txtcontato2.Focus();
            }
        }

        private void txtcontato2_KeyPress(object sender, KeyPressEventArgs e)
        {
            if ((Keys)e.KeyChar == Keys.Enter)
            {
                this.mskfonecontato2.Focus();
            }
        }

        private void mskfonecontato2_KeyPress(object sender, KeyPressEventArgs e)
        {
            if ((Keys)e.KeyChar == Keys.Enter)
            {
                this.txtramalcontato2.Focus();
            }
        }

        private void txtramalcontato2_KeyPress(object sender, KeyPressEventArgs e)
        {
            if ((Keys)e.KeyChar == Keys.Enter)
            {
                this.mskcelcontato2.Focus();
            }
        }

        private void mskcelcontato2_KeyPress(object sender, KeyPressEventArgs e)
        {
            if ((Keys)e.KeyChar == Keys.Enter)
            {
                this.txtemailcontato2.Focus();
            }
        }

        private void txtemailcontato2_KeyPress(object sender, KeyPressEventArgs e)
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

        private void cbocidade_Click(object sender, EventArgs e)
        {
            CarregarCidade();
        }

        private void cbobanco_Click(object sender, EventArgs e)
        {
            CarregarBanco();
        }

        private void BtnNovo_Click(object sender, EventArgs e)
        {
            Limpacampos();
        }

        private void BtnSalvar_Click(object sender, EventArgs e)
        {
           
            if (ValidaCampos() == true)
            {
                VlFornecedor obj = new VlFornecedor();

                if (txtcodigo.Text != "")
                {
                    obj.idfornecedor = Convert.ToInt32(txtcodigo.Text);
                }

                obj.cnpj = maskcnpj.Text;
                obj.inscestadual = txtinscestadual.Text;
                obj.status = cbofornecedor.Text;
                obj.razao = txtrazao.Text.ToUpper();
                obj.nome = txtfornecedor.Text.ToUpper();
                obj.endereco = txtendereco.Text.ToUpper();
                obj.bairro = txtbairro.Text.ToUpper();
                obj.idcidade = Convert.ToInt32(cbocidade.SelectedValue);
                obj.cep = mskcep.Text;
                obj.fax = mskfax.Text;
                obj.fone = mskfone.Text;
                obj.ramal = txtramal.Text;
                obj.celular = msk.Text;
                obj.email = txtemail.Text.ToLower();
                obj.site = txtsite.Text.ToLower();
                obj.obs = txtobs.Text.ToUpper();
                obj.contato = txtcontato.Text.ToUpper();
                obj.fonecontato = maskfonecontato.Text;
                obj.ramalcontato = txtramalcontato.Text;
                obj.celcontato = mskcelcontato.Text;
                obj.emailcontato = txtemailcontato.Text.ToLower();
                obj.contato2 = txtcontato2.Text.ToUpper();
                obj.fonecontato2 = mskfonecontato2.Text;
                obj.ramalcontato2 = txtramalcontato2.Text;
                obj.celcontato2 = mskcelcontato2.Text;
                obj.emailcontato2 = txtemailcontato2.Text.ToLower();
                obj.dtcadastro = mskcad.Text;
                obj.idempresa = Banco.idemp;
                obj.idusu = Banco.idusu;


                try
                {
                    if (VerificaRegistroExiste(txtcodigo.Text) == true)
                    {

                        PsFornecedor DAOFornecedor = new PsFornecedor();
                        DAOFornecedor.Incluir(obj);
                        MessageBox.Show("Registro Incluido com Sucesso!");
                        // Limpacampos();
                        RetReg();
                    }
                    else
                    {


                        PsFornecedor DAOFornecedor = new PsFornecedor();
                        DAOFornecedor.Alterar(obj);
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
            string obter = ("Select * From Fornecedor Where idfornecedor = '" + txtcodigo.Text + "'");
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
            VlFornecedor obj = new VlFornecedor();
            obj.idfornecedor = Convert.ToInt32(txtcodigo.Text);

            try
            {
                PsFornecedor DAOFornecedor = new PsFornecedor();
                DAOFornecedor.Exluir(obj.idfornecedor);
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
                VlContaFornecedor obj = new VlContaFornecedor();
                obj.idfornecedor = Convert.ToInt32(txtcodigo.Text);
                obj.idbanco = Convert.ToInt32(cbobanco.SelectedValue);
                obj.agencia = txtagencia.Text;
                obj.conta = txtnconta.Text;
                obj.favorecido = txtfavorecido.Text.ToUpper();

                try
                {
                    PsContaFornecedor DAOFornecedor = new PsContaFornecedor();
                    DAOFornecedor.Incluir(obj);
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
                string strConn = "Select DISTINCT ContaFornecedor.idcontafor as Cod,Banco.nome as Banco,ContaFornecedor.Agencia as Agencia, ContaFornecedor.conta as Conta, ContaFornecedor.favorecido as Favorecido" +
                " from Banco,ContaFornecedor,Fornecedor Where Banco.idbanco = ContaFornecedor.idbanco AND Fornecedor.idfornecedor = ContaFornecedor.idfornecedor AND ContaFornecedor.idfornecedor=" + txtcodigo.Text + "";

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
        int codi;
        private void griditens_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex == 5)
            {
                codi = Convert.ToInt32(griditens[0, e.RowIndex].Value.ToString());

                VlContaFornecedor obj = new VlContaFornecedor();
                obj.idcontafor = codi;

                try
                {
                    PsContaFornecedor DAOContaFornecedor = new PsContaFornecedor();
                    DialogResult result = MessageBox.Show("Deseja Excluir este Item !", "Excluir", MessageBoxButtons.YesNo);
                    if (result == DialogResult.Yes)
                    {
                        DAOContaFornecedor.Exluir(obj.idcontafor);
                        MessageBox.Show("Registro Excluido com Sucesso!");
                        carregarGrid();

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
            else
            {

                codi = Convert.ToInt32(griditens[0, e.RowIndex].Value.ToString());


            }
        }

        private void BtnSair_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void ViewFornecedor_Load(object sender, EventArgs e)
        {
            mskcad.Text = DateTime.Now.ToString("dd/MM/yyyy");
        }

        private void btnPesquisar_Click(object sender, EventArgs e)
        {
            ConsFornecedor frmconv = new ConsFornecedor();
            this.Close();
            frmconv.Show();
        }
    }
}
