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
    public partial class ViewMarca : Form
    {

        public static string TipoGravacao;
        public static string UltimoSelecionado;

        public ViewMarca()
        {
            InitializeComponent();
        }

        public ViewMarca(ConsMarca frm) : this()
        {
            UltimoSelecionado = Convert.ToString(frm.codmarca);
            RetReg();


        }

        private void RetReg()
        {
            string reg = "Select * from Marca ";
            if (UltimoSelecionado != "")
                reg += " Where idmarca = " + UltimoSelecionado;
            else reg += " Where idmarca = (Select Max(idmarca) from Marca)";
            DataTable ds = new DataTable();
            SqlConnection Conn = Banco.CriarConexao();
            Conn.Open();

            if (Conn.State == ConnectionState.Open)
            {
                SqlCommand cmd = new SqlCommand(reg, Conn);
                SqlDataReader dr = cmd.ExecuteReader();
                if (dr.Read())
                {
                    txtcodigo.Text = dr["idmarca"].ToString();
                    txtmarca.Text = dr["nome"].ToString();
                    RetornaFabricante(Convert.ToInt32(dr["idfabricante"].ToString()));

                }
            }
        }


        private void CarregarFabricante()
        {
            SqlConnection Cnn = Banco.CriarConexao();
            SqlDataAdapter sql = new SqlDataAdapter("Select * from Fabricante Order by nome asc ", Cnn);
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

        private void cbofabricante_Click(object sender, EventArgs e)
        {
            CarregarFabricante();
        }

        private Boolean ValidaCampos()
        {


            if (this.txtmarca.Text == "")
            {
                MessageBox.Show("Informe a Marca");
                txtmarca.Focus();
                return false;

            }
            if (this.cbofabricante.Text == "")
            {
                MessageBox.Show("informe o Fabricante");
                cbofabricante.Focus();
                return false;

            }


            return true;


        }
        private void Limpacampos()
        {
            txtcodigo.Text = "";
            this.txtmarca.Text = "";
            cbofabricante.SelectedIndex = -1;
            txtmarca.Focus();


        }

        private void txtmarca_KeyPress(object sender, KeyPressEventArgs e)
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

                this.BtnSalvar.Focus();
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

        private Boolean VerificaRegistroExiste(string qd)
        {

            SqlConnection Cnn = Banco.CriarConexao();
            string obter = ("Select * From Marca Where idmarca = '" + txtcodigo.Text + "'");
            SqlCommand sql = new SqlCommand(obter, Cnn);
            Cnn.Open();
            SqlDataReader dr = sql.ExecuteReader();
            if (dr.Read())
            {

                return false;
            }
            return true;
        }

        private void BtnSalvar_Click(object sender, EventArgs e)
        {
            if (ValidaCampos() == true)
            {
                VlMarca obj = new VlMarca();

                if (txtcodigo.Text != "")
                {
                    obj.idmarca = Convert.ToInt32(txtcodigo.Text);
                }
                obj.nome = this.txtmarca.Text.ToUpper();
                obj.idfabricante = Convert.ToInt32(cbofabricante.SelectedValue);
                obj.idusu = Banco.idusu;



                try
                {
                    if (VerificaRegistroExiste(txtcodigo.Text) == true)
                    {

                        PsMarca DAOFabricante = new PsMarca();
                        DAOFabricante.Incluir(obj);
                        MessageBox.Show("Registro Incluido com Sucesso!");
                        Limpacampos();
                    }
                    else
                    {


                        PsMarca DAOFabricante = new PsMarca();
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

        private void btnPesquisar_Click(object sender, EventArgs e)
        {
            ConsMarca frmmarca = new ConsMarca();
            this.Close();
            frmmarca.Show();
        }

        private void BtnRemover_Click(object sender, EventArgs e)
        {

        }
    }
}
