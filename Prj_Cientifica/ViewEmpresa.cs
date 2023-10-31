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
    public partial class ViewEmpresa : Form
    {
        public static string TipoGravacao;
        public static string UltimoSelecionado;

        public ViewEmpresa()
        {
            InitializeComponent();
        }

        public ViewEmpresa(ConsEmpresa frm) : this()
        {
            UltimoSelecionado = Convert.ToString(frm.codempresa);
            RetReg();


        }

        private void RetReg()
        {
            string reg = "Select * from Empresa ";
            if (UltimoSelecionado != "")
                reg += "Where idempresa = " + UltimoSelecionado;
            else reg += "Where idempresa = (Select Max(idempresa) from Empresa)";
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
                    mskcad.Text = dr["data"].ToString();
                  


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

                this.cbocidade.DisplayMember = "cidade";
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
                this.cbocidade.DisplayMember = "cidade";
                this.cbocidade.ValueMember = "idcidade";
                this.cbocidade.Refresh();




            }
            catch (Exception erro)
            {

                throw erro;
            }
            Cnn.Close();
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
            this.txtcodigo.Focus();

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

        private void BtnNovo_Click(object sender, EventArgs e)
        {
            Limpacampos();
        }

        private void txtempresa_KeyPress(object sender, KeyPressEventArgs e)
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
                this.BtnSalvar.Focus();
            }
        }

        private void ViewEmpresa_Load(object sender, EventArgs e)
        {
            mskcad.Text = DateTime.Now.ToString("dd/MM/yyyy");
            rbtcnpj.Checked = true;
        }

        private void BtnSair_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnPesquisar_Click(object sender, EventArgs e)
        {
            ConsEmpresa frmc = new ConsEmpresa();
            this.Close();
            frmc.Show();
        }

        private void BtnSalvar_Click(object sender, EventArgs e)
        {
            if (ValidaCampos() == true)
            {
                VlEmpresa obj = new VlEmpresa();

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

                try
                {
                    if (VerificaRegistroExiste(txtcodigo.Text) == true)
                    {

                        PsEmpresa PsEmpresabll = new PsEmpresa();
                        PsEmpresabll.Incluir(obj);
                        MessageBox.Show("Registro Incluido com Sucesso!");
                        Limpacampos();
                    }
                    else
                    {

                        PsEmpresa PsEmpresabll = new PsEmpresa();
                        PsEmpresabll.Alterar(obj);
                        MessageBox.Show("Registro Alterada com Sucesso!");
                        Limpacampos();
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
                string obter = ("Select * From Empresa Where idempresa = '" + txtcodigo.Text + "'");
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
            VlEmpresa obj = new VlEmpresa();
            obj.idempresa = Convert.ToInt32(txtcodigo.Text);

            try
            {
                PsEmpresa PsEmpresabll = new PsEmpresa();
                PsEmpresabll.Exluir(obj.idempresa);
                MessageBox.Show("Registro Excluido Com Sucesso!");
                Limpacampos();




            }
            catch (Exception erro)
            {

                throw erro;
            }

        }
    }
}
