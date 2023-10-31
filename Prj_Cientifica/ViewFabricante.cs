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
    public partial class ViewFabricante : Form
    {
        public static string TipoGravacao;
        public static string UltimoSelecionado;

        public ViewFabricante()
        {
            InitializeComponent();
        }

        public ViewFabricante(ConsFabricante frm) : this()
        {
            UltimoSelecionado = Convert.ToString(frm.codfabricante);
            RetReg();


        }

        private void RetReg()
        {
            string reg = "Select * from Fabricante ";
            if (UltimoSelecionado != "")
                reg += "Where idfabricante = " + UltimoSelecionado;
            else reg += " Where idfabricante = (Select Max(idfabricante) from Fabricante)";
            DataTable ds = new DataTable();
            SqlConnection Conn = Banco.CriarConexao();
            Conn.Open();

            if (Conn.State == ConnectionState.Open)
            {
                SqlCommand cmd = new SqlCommand(reg, Conn);
                SqlDataReader dr = cmd.ExecuteReader();
                if (dr.Read())
                {
                    txtcodigo.Text = dr["idfabricante"].ToString();
                    txtnome.Text = dr["nome"].ToString();
                    maskcnpj.Text = dr["cnpj"].ToString();
                    txtfantasia.Text = dr["fantasia"].ToString();
                    RetornaCidade(Convert.ToInt32(dr["idcidade"].ToString()));

                }
            }
        }


        private void CarregarCidade()
        {
            SqlConnection Cnn = Banco.CriarConexao();
            SqlDataAdapter sql = new SqlDataAdapter("Select * from Cidade Order by nome asc ", Cnn);
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
        private void RetornaCidade(Int32 retfab)
        {
            SqlConnection Cnn = Banco.CriarConexao();
            SqlDataAdapter sql = new SqlDataAdapter("Select * from Cidade WHERE idcidade=" + retfab + "", Cnn);
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

        private Boolean ValidaCampos()
        {


            if (this.txtnome.Text == "")
            {
                MessageBox.Show("Informe a Razão Social");
                txtnome.Focus();
                return false;

            }

            if (this.maskcnpj.Text == "")
            {
                MessageBox.Show("Informe o Número do CNPJ");
                maskcnpj.Focus();
                return false;

            }

            if (this.txtfantasia.Text == "")
            {
                MessageBox.Show("Informe o Nome do Fantasia");
                txtfantasia.Focus();
                return false;

            }

            if (this.cbocidade.Text == "")
            {
                MessageBox.Show("Informe a Cidade ");
                cbocidade.Focus();
                return false;

            }





            return true;


        }
        private void Limpacampos()
        {
            txtcodigo.Text = "";
            txtnome.Text = "";
            maskcnpj.Text = "";
            txtfantasia.Text = "";
            cbocidade.Text = "";
            txtnome.Focus();


        }

        private void txtnome_KeyPress(object sender, KeyPressEventArgs e)
        {
            if ((Keys)e.KeyChar == Keys.Enter)
            {

                this.maskcnpj.Focus();
            }
        }

        private void BtnNovo_Click(object sender, EventArgs e)
        {
            Limpacampos();
        }

        private void BtnSair_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void BtnRemover_Click(object sender, EventArgs e)
        {
            VlFabricante obj = new VlFabricante();
            obj.idfabricante = Convert.ToInt32(txtcodigo.Text);

            try
            {
                PsFabricante DAOFabricante = new PsFabricante();
                DAOFabricante.Exluir(obj.idfabricante);
                MessageBox.Show("Registro Excluido Com Sucesso!");
                Limpacampos();




            }
            catch (Exception erro)
            {

                throw erro;
            }
        }

        private void BtnSalvar_Click(object sender, EventArgs e)
        {
            if (ValidaCampos() == true)
            {
                VlFabricante obj = new VlFabricante();

                if (txtcodigo.Text != "")
                {
                    obj.idfabricante = Convert.ToInt32(txtcodigo.Text);
                }
                obj.nome = this.txtnome.Text.ToUpper();
                obj.cnpj = this.maskcnpj.Text.ToUpper();
                obj.fantasia = this.txtfantasia.Text.ToUpper();
                obj.idcidade = Convert.ToInt32(cbocidade.SelectedValue);
                obj.idusu = Banco.idusu;



                try
                {
                    if (VerificaRegistroExiste(txtcodigo.Text) == true)
                    {

                        PsFabricante DAOFabricante = new PsFabricante();
                        DAOFabricante.Incluir(obj);
                        MessageBox.Show("Registro Incluido com Sucesso!");
                        Limpacampos();
                    }
                    else
                    {


                        PsFabricante DAOFabricante = new PsFabricante();
                        DAOFabricante.Alterar(obj);
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
            string obter = ("Select * From Fabricante Where idfabricante = '" + txtcodigo.Text + "'");
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
            ConsFabricante frmconv = new ConsFabricante();
            this.Close();
            frmconv.Show();
        }

        private void txtmarca_KeyPress(object sender, KeyPressEventArgs e)
        {
            if ((Keys)e.KeyChar == Keys.Enter)
            {

                this.BtnSalvar.Focus();
            }
        }

        private void maskcnpj_KeyPress(object sender, KeyPressEventArgs e)
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

                this.cbocidade.Focus();
            }
        }

        private void cbocidade_KeyPress(object sender, KeyPressEventArgs e)
        {
            if ((Keys)e.KeyChar == Keys.Enter)
            {

                this.BtnSalvar.Focus();
            }
        }

        private void cbocidade_Click(object sender, EventArgs e)
        {
            CarregarCidade();
        }
    }
}
