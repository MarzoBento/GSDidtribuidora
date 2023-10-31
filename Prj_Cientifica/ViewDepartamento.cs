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
    public partial class ViewDepartamento : Form
    {
        public static string TipoGravacao;
        public static string UltimoSelecionado;

        public ViewDepartamento()
        {
            InitializeComponent();
        }

        public ViewDepartamento(ConsDepartamento frm) : this()
        {
            UltimoSelecionado = Convert.ToString(frm.coddepto);
            RetReg();


        }

        private void RetReg()
        {
            string reg = "Select * from Departamento ";
            if (UltimoSelecionado != "")
                reg += "Where iddepartamento = " + UltimoSelecionado;
            else reg += " Where iddepartamento = (Select Max(iddepartamento) from Departamento)";
            DataTable ds = new DataTable();
            SqlConnection Conn = Banco.CriarConexao();
            Conn.Open();

            if (Conn.State == ConnectionState.Open)
            {
                SqlCommand cmd = new SqlCommand(reg, Conn);
                SqlDataReader dr = cmd.ExecuteReader();
                if (dr.Read())
                {
                    txtcodigo.Text = dr["iddepartamento"].ToString();
                    txtnome.Text = dr["nome"].ToString();

                }
            }
        }

        private Boolean ValidaCampos()
        {


            if (this.txtnome.Text == "")
            {
                MessageBox.Show("Informe o Nome do Departamento");
                txtnome.Focus();
                return false;

            }

            return true;


        }
        private void Limpacampos()
        {
            txtcodigo.Text = "";
            txtnome.Text = "";
            txtnome.Focus();


        }

        private void txtnome_KeyPress(object sender, KeyPressEventArgs e)
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

        private void BtnRemover_Click(object sender, EventArgs e)
        {
            VlDepartamento obj = new VlDepartamento();
            obj.iddepartamento = Convert.ToInt32(txtcodigo.Text);

            try
            {
                PsDepartamento DepartamentoDAO = new PsDepartamento();
                DepartamentoDAO.Exluir(obj.iddepartamento);
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
                VlDepartamento obj = new VlDepartamento();

                if (txtcodigo.Text != "")
                {
                    obj.iddepartamento = Convert.ToInt32(txtcodigo.Text);
                }
                obj.nome = this.txtnome.Text.ToUpper();
                obj.idusu = Banco.idusu;



                try
                {
                    if (VerificaRegistroExiste(txtcodigo.Text) == true)
                    {

                        PsDepartamento DAODepartamento = new PsDepartamento();
                        DAODepartamento.Incluir(obj);
                        MessageBox.Show("Registro Incluido com Sucesso!");
                        Limpacampos();
                    }
                    else
                    {


                        PsDepartamento DAODepartamento = new PsDepartamento();
                        DAODepartamento.Alterar(obj);
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
            string obter = ("Select * From Departamento Where iddepartamento = '" + txtcodigo.Text + "'");
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
            ConsDepartamento frmconv = new ConsDepartamento();
            this.Close();
            frmconv.Show();
        }
    }
}
