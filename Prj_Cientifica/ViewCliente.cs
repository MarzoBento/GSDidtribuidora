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
    public partial class ViewCliente : Form
    {
        public static string TipoGravacao;
        public static string UltimoSelecionado;
        public static int tipocliente;

        public ViewCliente()
        {
            InitializeComponent();
        }

        public ViewCliente(ConsCliente frm) : this()
        {
            UltimoSelecionado = Convert.ToString(frm.codcli);
            RetReg();


        }


        private void RetReg()
        {
            string reg = "Select * from Cliente ";
            if (UltimoSelecionado != null)
                reg += "Where idcliente = " + UltimoSelecionado;
            else reg += " Where idcliente = (Select Max(idcliente) from Cliente)";
            DataTable ds = new DataTable();
            SqlConnection Conn = Banco.CriarConexao();
            Conn.Open();

            if (Conn.State == ConnectionState.Open)
            {
                SqlCommand cmd = new SqlCommand(reg, Conn);
                SqlDataReader dr = cmd.ExecuteReader();
                if (dr.Read())
                {
                    txtcodigo.Text = dr["idcliente"].ToString();
                    maskcnpj.Text = dr["cnpj"].ToString();
                    txtinscestadual.Text = dr["inscestadual"].ToString();
                    if (Convert.ToInt32(dr["tipocli"].ToString()) == 1)
                    {
                        RbtFederal.Checked = true;
                    }
                    else if (Convert.ToInt32(dr["tipocli"].ToString()) == 2)
                    {
                        RbtEstadual.Checked = true;
                    }
                    else if(Convert.ToInt32(dr["tipocli"].ToString()) == 3)
                    {
                        RbtMunicipal.Checked = true;
                    }
                    else if (Convert.ToInt32(dr["tipocli"].ToString()) == 4)
                    {
                        RbtParticular.Checked = true;
                    }
                    txtcliente.Text = dr["razao"].ToString();
                    txtfantasia.Text = dr["nome"].ToString();
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
                    RetornaRepresentante(Convert.ToInt32(dr["idrepresentante"].ToString()));
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
                    txtentrega.Text = dr["entrega"].ToString();
                    mskcad.Text = dr["dtcadastro"].ToString();
                    if(dr["estado"].ToString() != "")
                    {
                        
                        cboestado.Text = dr["estado"].ToString();

                    }
                    else
                    {
                        cboestado.Text = "";

                    }
                    if (dr["statuscli"].ToString() != "")
                    {

                        cbostatus.Text = dr["statuscli"].ToString();

                    }
                    else
                    {
                        cbostatus.Text = "";

                    }


                    // carregarGridConsulta();

                }
            }
        }

        private void CarregarCidade()
        {
            SqlConnection Cnn = Banco.CriarConexao();
            SqlDataAdapter sql = new SqlDataAdapter("Select Cidade.idcidade, Cidade.nome + '-' + Cidade.uf as nome from Cidade Order by nome asc ", Cnn);
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
            SqlDataAdapter sql = new SqlDataAdapter("Select Cidade.idcidade, Cidade.nome + '-' + Cidade.uf  as nome from Cidade WHERE Cidade.idcidade=" + retcid + "", Cnn);
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

        private void txtfantasia_TextChanged(object sender, EventArgs e)
        {

        }

        private void cbocidade_SelectedIndexChanged(object sender, EventArgs e)
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
                this.txtcliente.Focus();
            }
        }

        private void txtcliente_KeyPress(object sender, KeyPressEventArgs e)
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
                this.cborepresentante.Focus();
            }
        }

        private void cborepresentante_KeyPress(object sender, KeyPressEventArgs e)
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
                this.txtentrega.Focus();
            }
        }

        private void BtnSair_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void cbocidade_Click(object sender, EventArgs e)
        {
            CarregarCidade();
        }

        private void cborepresentante_Click(object sender, EventArgs e)
        {
            CarregarRepresentante();
        }

        private void ViewCliente_Load(object sender, EventArgs e)
        {
            mskcad.Text = DateTime.Now.ToString("dd/MM/yyyy");
            RbtFederal.Checked = true;
        }


        private void Limpacampos()
        {
            txtcodigo.Text = "";
            this.txtfantasia.Text = "";
            this.txtcliente.Text = "";
            txtinscestadual.Text = "";
            this.maskcnpj.Text = "";
            txtendereco.Text = "";
            txtbairro.Text = "";
            mskcep.Text = "";
            cbocidade.SelectedIndex = -1;
            cborepresentante.SelectedIndex = -1;
            cbostatus.SelectedIndex = -1;
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
            txtfantasia.Text = "";
            txtsite.Text = "";
            txtentrega.Text = "";
            mskcep.Text = "";
            RbtFederal.Checked = true;
            RbtEstadual.Checked = false;
            RbtMunicipal.Checked = false;
            RbtParticular.Checked = false;
            this.maskcnpj.Focus();

        }

        private Boolean ValidaCampos()
        {
            if (this.txtcliente.Text == "")
            {
                MessageBox.Show("Informe o Nome do Cliente");
                txtcliente.Focus();
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
            if (this.cborepresentante.Text == "")
            {
                MessageBox.Show("informe o representante");
                cborepresentante.Focus();
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

            if (this.cboestado.Text == "")
            {
                MessageBox.Show("informe o Estado!");
                cboestado.Focus();
                return false;

            }


            return true;


        }

        private void BtnNovo_Click(object sender, EventArgs e)
        {
            Limpacampos();
        }

        private void BtnSalvar_Click(object sender, EventArgs e)
        {

            if (ValidaCampos() == true)
            {
                VlCliente obj = new VlCliente();

                if (txtcodigo.Text != "")
                {
                    obj.idcliente = Convert.ToInt32(txtcodigo.Text);
                }

                obj.cnpj = maskcnpj.Text;
                obj.inscestadual = txtinscestadual.Text;
                if (RbtFederal.Checked == true)
                {
                    obj.tipocli = 1;
                }
                else if (RbtEstadual.Checked == true)
                {
                    obj.tipocli = 2;
                }
                else if (RbtMunicipal.Checked == true)
                {
                    obj.tipocli = 3;
                }
                else if (RbtParticular.Checked == true)
                {
                    obj.tipocli = 4;
                }
              
                obj.razao = txtcliente.Text.ToUpper();
                obj.nome = txtfantasia.Text.ToUpper();
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
                obj.idrepresentante = Convert.ToInt32(cborepresentante.SelectedValue);
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
                obj.entrega = txtentrega.Text;
                obj.dtcadastro = mskcad.Text;
                obj.idempresa = Banco.idemp;
                obj.idusu = Banco.idusu;
                obj.estado = cboestado.Text;
                obj.statuscli = cbostatus.Text;
                

                try
                {
                    if (VerificaRegistroExiste(txtcodigo.Text) == true)
                    {

                        PsCliente DAOCliente = new PsCliente();
                        DAOCliente.Incluir(obj);
                        MessageBox.Show("Registro Incluido com Sucesso!");
                        // Limpacampos();
                        RetReg();
                    }
                    else
                    {


                        PsCliente DAOCliente = new PsCliente();
                        DAOCliente.Alterar(obj);
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
            string obter = ("Select * From Cliente Where idcliente = '" + txtcodigo.Text + "'");
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
            VlCliente obj = new VlCliente();
            obj.idcliente = Convert.ToInt32(txtcodigo.Text);

            try
            {
                PsCliente DAOCliente = new PsCliente();
                DAOCliente.Exluir(obj.idcliente);
                MessageBox.Show("Registro Excluido Com Sucesso!");
                Limpacampos();




            }
            catch (Exception erro)
            {

                throw erro;
            }

        }

        private void btnPesquisar_Click(object sender, EventArgs e)
        {
            ConsCliente frmconv = new ConsCliente();
            this.Close();
            frmconv.Show();
        }

        private void cbostatus_KeyPress(object sender, KeyPressEventArgs e)
        {
            if ((Keys)e.KeyChar == Keys.Enter)
            {
                this.txtcontato.Focus();
            }
        }
    }
}
