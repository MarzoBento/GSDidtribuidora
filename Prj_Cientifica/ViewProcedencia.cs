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

    public partial class ViewProcedencia : Form
    {

        public static string TipoGravacao;
        public static string UltimoSelecionado;

        public ViewProcedencia()
        {
            InitializeComponent();
        }

        public ViewProcedencia(ConsProcedencia frm) : this()
        {
            UltimoSelecionado = Convert.ToString(frm.codprocedencia);
            RetReg();


        }

        private void RetReg()
        {
            string reg = "Select * from Procedencia ";
            if (UltimoSelecionado != "")
                reg += "Where idprocedencia = " + UltimoSelecionado;
            else reg += " Where idprocedencia = (Select Max(idprocedencia) from Procedencia)";
            DataTable ds = new DataTable();
            SqlConnection Conn = Banco.CriarConexao();
            Conn.Open();

            if (Conn.State == ConnectionState.Open)
            {
                SqlCommand cmd = new SqlCommand(reg, Conn);
                SqlDataReader dr = cmd.ExecuteReader();
                if (dr.Read())
                {
                    txtcodigo.Text = dr["idprocedencia"].ToString();
                    txtnome.Text = dr["nome"].ToString();

                }
            }
        }

        private Boolean ValidaCampos()
        {


            if (this.txtnome.Text == "")
            {
                MessageBox.Show("Informe a Procedência");
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

        private void BtnSalvar_Click(object sender, EventArgs e)
        {

            if (ValidaCampos() == true)
            {
                VlProcedencia obj = new VlProcedencia();

                if (txtcodigo.Text != "")
                {
                    obj.idprocedencia = Convert.ToInt32(txtcodigo.Text);
                }
                obj.nome = this.txtnome.Text.ToUpper();
                obj.idusu = Banco.idusu;



                try
                {
                    if (VerificaRegistroExiste(txtcodigo.Text) == true)
                    {

                        PsProcedencia DAOProcedencia = new PsProcedencia();
                        DAOProcedencia.Incluir(obj);
                        MessageBox.Show("Registro Incluido com Sucesso!");
                        Limpacampos();
                    }
                    else
                    {


                        PsProcedencia DAOProcedencia = new PsProcedencia();
                        DAOProcedencia.Alterar(obj);
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
            string obter = ("Select * From Procedencia Where idprocedencia = '" + txtcodigo.Text + "'");
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
            VlProcedencia obj = new VlProcedencia();
            obj.idprocedencia = Convert.ToInt32(txtcodigo.Text);

            try
            {
                PsProcedencia DAOProcedencia = new PsProcedencia();
                DAOProcedencia.Exluir(obj.idprocedencia);
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
            ConsProcedencia frmconv = new ConsProcedencia();
            this.Close();
            frmconv.Show();
        }

        private void BtnSair_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
