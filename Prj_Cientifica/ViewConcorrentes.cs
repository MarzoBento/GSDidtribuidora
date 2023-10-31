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
    public partial class ViewConcorrentes : Form
    {
        public static string TipoGravacao;
        public static string UltimoSelecionado;
        public static int tipocliente;

        public ViewConcorrentes()
        {
            InitializeComponent();
        }
        public ViewConcorrentes(ConsConcorrente frm) : this()
        {
            UltimoSelecionado = Convert.ToString(frm.codconcorrente);
            RetReg();


        }

        private void maskcnpj_KeyPress(object sender, KeyPressEventArgs e)
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

        private void BtnSair_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void RetReg()
        {
            string reg = "Select * from Concorrente ";
            if (UltimoSelecionado != null)
                reg += "Where idconcorrente = " + UltimoSelecionado;
            else reg += "Where idconcorrente = (Select Max(idconcorrente) from Concorrente)";
            DataTable ds = new DataTable();
            SqlConnection Conn = Banco.CriarConexao();
            Conn.Open();

            if (Conn.State == ConnectionState.Open)
            {
                SqlCommand cmd = new SqlCommand(reg, Conn);
                SqlDataReader dr = cmd.ExecuteReader();
                if (dr.Read())
                {
                    txtcodigo.Text = dr["idconcorrente"].ToString();
                    maskcnpj.Text = dr["cnpj"].ToString();
                    txtcliente.Text = dr["razao"].ToString();
                    txtfantasia.Text = dr["nome"].ToString();
                    txtestado.Text = dr["estado"].ToString();
                    RetornaCidade(Convert.ToInt32(dr["idcidade"].ToString()));


                    // carregarGridConsulta();

                }
            }
        }
        private void Limpacampos()
        {
            txtcodigo.Text = "";
            this.txtfantasia.Text = "";
            this.txtcliente.Text = "";
            this.txtestado.Text = "";
            this.maskcnpj.Text = "";
            cbocidade.SelectedIndex = -1;
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
                VlConcorrente obj = new VlConcorrente();

                if (txtcodigo.Text != "")
                {
                    obj.idconcorrente = Convert.ToInt32(txtcodigo.Text);
                }

                obj.cnpj = maskcnpj.Text;
               

                obj.razao = txtcliente.Text.ToUpper();
                obj.nome = txtfantasia.Text.ToUpper();
                obj.idcidade = Convert.ToInt32(cbocidade.SelectedValue);
                obj.estado = txtestado.Text.ToUpper();
                obj.idusu = Banco.idusu;


                try
                {
                    if (VerificaRegistroExiste(txtcodigo.Text) == true)
                    {

                        PsConcorrente DAOConcorrente = new PsConcorrente();
                        DAOConcorrente.Incluir(obj);
                        MessageBox.Show("Registro Incluido com Sucesso!");
                        RetReg();
                    }
                    else
                    {


                        PsConcorrente DAOConcorrente = new PsConcorrente();
                        DAOConcorrente.Alterar(obj);
                        MessageBox.Show("Registro Alterada com Sucesso!");
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
            string obter = ("Select * From Concorrente Where idconcorrente = '" + txtcodigo.Text + "'");
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
            VlConcorrente obj = new VlConcorrente();
            obj.idconcorrente = Convert.ToInt32(txtcodigo.Text);

            try
            {
                PsConcorrente DAOConcorrente = new PsConcorrente();
                DAOConcorrente.Exluir(obj.idconcorrente);
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
            ConsConcorrente frmconv = new ConsConcorrente();
            this.Close();
            frmconv.Show();
        }

        private void cbocidade_SelectionChangeCommitted(object sender, EventArgs e)
        {

            string reg = "Select uf from Cidade Where idcidade = " + cbocidade.SelectedValue;
            DataTable ds = new DataTable();
            SqlConnection Conn = Banco.CriarConexao();
            Conn.Open();

            if (Conn.State == ConnectionState.Open)
            {
                SqlCommand cmd = new SqlCommand(reg, Conn);
                SqlDataReader dr = cmd.ExecuteReader();
                if (dr.Read())
                {
                   
                    txtestado.Text = dr["uf"].ToString();


                    // carregarGridConsulta();

                }
            }

        }

        private void cbocidade_Click(object sender, EventArgs e)
        {
            CarregarCidade();
        }
    }
}
