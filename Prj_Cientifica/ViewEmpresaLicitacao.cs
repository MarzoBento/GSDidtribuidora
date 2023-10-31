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
    public partial class ViewEmpresaLicitacao : Form
    {
        public static string TipoGravacao;
        public static string UltimoSelecionado;
        public static int tipo;


        public ViewEmpresaLicitacao()
        {
            InitializeComponent();
        }

        public ViewEmpresaLicitacao(ConsultaEmpresaLicitacao frm) : this()
        {
            UltimoSelecionado = Convert.ToString(frm.codemplict);
            RetReg();


        }

        private void RetReg()
        {
            string reg = "Select * from EmpresaLicitacao ";
            if (UltimoSelecionado != null)
                reg += "Where idempresa = " + UltimoSelecionado;
            else reg += "Where idempresa = (Select Max(idempresa) from EmpresaLicitacao)";
            DataTable ds = new DataTable();
            SqlConnection Conn = Banco.CriarConexao();
            Conn.Open();

            if (Conn.State == ConnectionState.Open)
            {
                SqlCommand cmd = new SqlCommand(reg, Conn);
                SqlDataReader dr = cmd.ExecuteReader();
                if (dr.Read())
                {
                    txtcodigo.Text = dr["idempresa"].ToString();
                    txtempresa.Text = dr["nome"].ToString();
                    maskcpfcnpj.Text = dr["cpfcnpj"].ToString();
                    txtinscestadual.Text = dr["inscestadual"].ToString();
                    txtendereco.Text = dr["endereco"].ToString();
                    txtbairro.Text = dr["bairro"].ToString();
                    mskcep.Text = dr["cep"].ToString();
                    RetornaCidade(Convert.ToInt32(dr["idcidade"].ToString()));
                    mskfone.Text = dr["fone"].ToString();
                    txtramal.Text = dr["ramal"].ToString();
                    msk.Text = dr["celular"].ToString();
                    txtcontato.Text = dr["contato"].ToString();
                    mskfax.Text = dr["fax"].ToString();
                    txtemail.Text = dr["email"].ToString();
                    txtfantasia.Text = dr["nomefantasia"].ToString();
                    txtsite.Text = dr["site"].ToString();
                    txtresponsavel.Text = dr["responsavel"].ToString();
                    mskcpf.Text = dr["cpfresp"].ToString();
                    txtrg.Text = dr["rgresp"].ToString();
                    mskcad.Text = dr["data"].ToString();
                    if(Convert.ToInt32(dr["tipo"].ToString()) == 1)
                    {
                        RbtMatriz.Checked = true;
                    }
                    else if (Convert.ToInt32(dr["tipo"].ToString()) == 2)
                    {
                        RbtFilial.Checked = true;
                    }

                    carregarGridConsulta();

                }
            }
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





        private void radioButton2_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void txtempresa_KeyPress(object sender, KeyPressEventArgs e)
        {
            if ((Keys)e.KeyChar == Keys.Enter)
            {
                this.RbtMatriz.Focus();
            }
        }

        private void RbtMatriz_KeyPress(object sender, KeyPressEventArgs e)
        {
            if ((Keys)e.KeyChar == Keys.Enter)
            {
                this.RbtFilial.Focus();
            }
        }

        private void RbtFilial_KeyPress(object sender, KeyPressEventArgs e)
        {
            if ((Keys)e.KeyChar == Keys.Enter)
            {
                this.rbtcpf.Focus();
            }
        }

        private void rbtcpf_KeyPress(object sender, KeyPressEventArgs e)
        {
            if ((Keys)e.KeyChar == Keys.Enter)
            {
                this.rbtcnpj.Focus();
            }
        }

        private void rbtcnpj_KeyPress(object sender, KeyPressEventArgs e)
        {
            if ((Keys)e.KeyChar == Keys.Enter)
            {
                this.maskcpfcnpj.Focus();
            }
        }

        private void maskcpfcnpj_KeyPress(object sender, KeyPressEventArgs e)
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

        private void txtbairro_TextChanged(object sender, EventArgs e)
        {

        }

        private void txtbairro_KeyPress(object sender, KeyPressEventArgs e)
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
                this.cbocidade.Focus();
            }
        }

        private void cbocidade_KeyPress(object sender, KeyPressEventArgs e)
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
                this.txtcontato.Focus();
            }
        }

        private void txtcontato_KeyPress(object sender, KeyPressEventArgs e)
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
                this.txtfantasia.Focus();
            }
        }

        private void txtfantasia_KeyPress(object sender, KeyPressEventArgs e)
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
                this.txtresponsavel.Focus();
            }
        }

        private void txtresponsavel_KeyPress(object sender, KeyPressEventArgs e)
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

        private void RbtMatriz_CheckedChanged(object sender, EventArgs e)
        {
            if (RbtMatriz.Checked == true)
            {
                tipo = 1;

            }
        }

        private void RbtFilial_CheckedChanged(object sender, EventArgs e)
        {
            if (RbtMatriz.Checked == true)
            {
                tipo = 2;

            }
        }

        private void ViewEmpresaLicitacao_Load(object sender, EventArgs e)
        {
            mskcad.Text = DateTime.Now.ToString("dd/MM/yyyy");
            RbtMatriz.Checked = true;
            tipo = 1;
        }

        private void Limpacampos()
        {
            txtcodigo.Text = "";
            this.txtempresa.Text = "";
            txtinscestadual.Text = "";
            this.maskcpfcnpj.Text = "";
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
            txtfantasia.Text = "";
            txtsite.Text = "";
            txtresponsavel.Text = "";
            mskcep.Text = "";
            txtrg.Text = "";
            this.mskcpf.Text = "";
            RbtMatriz.Checked = true;
            RbtFilial.Checked = false;
            rbtcnpj.Checked = true;
            rbtcpf.Checked = false;
            griditens.DataSource = null;
            this.txtempresa.Focus();

        }

        private Boolean ValidaCampos()
        {
            if (this.txtempresa.Text == "")
            {
                MessageBox.Show("Informe o Nome da Empresa");
                txtempresa.Focus();
                return false;

            }

            if (this.cbocidade.Text == "")
            {
                MessageBox.Show("informe a Cidade");
                cbocidade.Focus();
                return false;

            }
            if (this.mskfone.Text == "(__)____-____")
            {
                MessageBox.Show("informe o Nº do Telefone!");
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

        private void rbtcpf_CheckedChanged(object sender, EventArgs e)
        {
            maskcpfcnpj.Text = "";
            if (rbtcpf.Checked == true)
            {
                maskcpfcnpj.Mask = "000,000,000-00";
                maskcpfcnpj.Focus();

            }
        }

        private void rbtcnpj_CheckedChanged(object sender, EventArgs e)
        {
            maskcpfcnpj.Text = "";
            if (rbtcnpj.Checked == true)
            {
                maskcpfcnpj.Mask = "00,000,000/0000-00";
                maskcpfcnpj.Focus();
            }
        }

        private void BtnNovo_Click(object sender, EventArgs e)
        {
            Limpacampos();
        }

        private void BtnSalvar_Click(object sender, EventArgs e)
        {
            if (ValidaCampos() == true)
            {
                VlEmpLicitacao obj = new VlEmpLicitacao();

                if (txtcodigo.Text != "")
                {
                    obj.idempresa = Convert.ToInt32(txtcodigo.Text);
                }
                obj.nome = txtempresa.Text.ToUpper();
                obj.cpfcnpj = maskcpfcnpj.Text;
                obj.inscestadual = txtinscestadual.Text;
                obj.endereco = txtendereco.Text.ToUpper();
                obj.bairro = txtbairro.Text.ToUpper();
                obj.cep = mskcep.Text;
                obj.idcidade = Convert.ToInt32(cbocidade.SelectedValue);
                obj.fone = mskfone.Text;
                obj.ramal = txtramal.Text;
                obj.celular = msk.Text;
                obj.contato = txtcontato.Text.ToUpper();
                obj.fax = mskfax.Text;
                obj.email = txtemail.Text.ToLower();
                obj.data = mskcad.Text;
                obj.nomefantasia = txtfantasia.Text.ToUpper();
                obj.site =   txtsite.Text.ToLower();
                obj.responsavel = txtresponsavel.Text.ToUpper();
                obj.cep =  mskcep.Text;
                obj.rgresp = txtrg.Text;
                obj.cpfresp = mskcpf.Text;
               if( RbtMatriz.Checked == true)
                {
                    obj.tipo = 1;
                }
               else if( RbtFilial.Checked == true)
                {
                    obj.tipo = 2;
                }
                obj.idusu = Banco.idusu;
               

                try
                {
                    if (VerificaRegistroExiste(txtcodigo.Text) == true)
                    {

                        PsEmpLicitacao PsEmpLicitacaobll = new PsEmpLicitacao();
                        PsEmpLicitacaobll.Incluir(obj);
                        MessageBox.Show("Registro Incluido com Sucesso!");
                        // Limpacampos();
                        RetReg();
                    }
                    else
                    {


                        PsEmpLicitacao PsEmpLicitacaobll = new PsEmpLicitacao();
                        PsEmpLicitacaobll.Alterar(obj);
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
            string obter = ("Select * From EmpresaLicitacao Where idempresa = '" + txtcodigo.Text + "'");
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
            VlEmpLicitacao obj = new VlEmpLicitacao();
            obj.idempresa = Convert.ToInt32(txtcodigo.Text);

            try
            {
                PsEmpLicitacao PsEmpLicitacaobll = new PsEmpLicitacao();
                PsEmpLicitacaobll.Exluir(obj.idempresa);
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
                VlContaEmpresa obj = new VlContaEmpresa();
                obj.idempresa = Convert.ToInt32(txtcodigo.Text);
                obj.idbanco = Convert.ToInt32(cbobanco.SelectedValue);
                obj.agencia = txtagencia.Text;
                obj.conta = txtnconta.Text;
                obj.favorecido = txtfavorecido.Text.ToUpper();

                try
                {
                    PsContaEmpresa PsContaEmpresabll = new PsContaEmpresa();
                    PsContaEmpresabll.Incluir(obj);
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
                string strConn = "Select DISTINCT ContaEmpresa.idconta as Cod,Banco.nome as Banco,ContaEmpresa.Agencia as Agencia, ContaEmpresa.conta as Conta, ContaEmpresa.favorecido as Favorecido" +
                " from Banco,ContaEmpresa,EmpresaLicitacao Where Banco.idbanco = ContaEmpresa.idbanco AND EmpresaLicitacao.idempresa = ContaEmpresa.idempresa AND ContaEmpresa.idempresa=" + txtcodigo.Text + "";

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
            ConsultaEmpresaLicitacao frmconv = new ConsultaEmpresaLicitacao();
            this.Close();
            frmconv.Show();
        }

        private void cbobanco_Click(object sender, EventArgs e)
        {
            CarregarBanco();
        }

        int codi;
        private void griditens_CellClick(object sender, DataGridViewCellEventArgs e)
        {

            if (e.ColumnIndex == 5)
            {
                codi = Convert.ToInt32(griditens[0, e.RowIndex].Value.ToString());

                VlContaEmpresa obj = new VlContaEmpresa();
                obj.idconta = codi;

                try
                {
                    PsContaEmpresa PsContaEmpresabll = new PsContaEmpresa();
                    DialogResult result = MessageBox.Show("Deseja Excluir este Item !", "Excluir", MessageBoxButtons.YesNo);
                    if (result == DialogResult.Yes)
                    {
                        PsContaEmpresabll.Exluir(obj.idconta);
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
                string strConn = "Select DISTINCT ContaEmpresa.idconta as Cod,Banco.nome as Banco,ContaEmpresa.Agencia as Agencia, ContaEmpresa.conta as Conta, ContaEmpresa.favorecido as Favorecido" +
                " from Banco,ContaEmpresa,EmpresaLicitacao Where Banco.idbanco = ContaEmpresa.idbanco AND EmpresaLicitacao.idempresa = ContaEmpresa.idempresa AND ContaEmpresa.idempresa=" + txtcodigo.Text + "";

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

        private void BtnSair_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
