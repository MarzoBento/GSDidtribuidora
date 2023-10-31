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
    public partial class ViewPrincipioAtivo : Form
    {
        public static string TipoGravacao;
        public static string UltimoSelecionado;

        public ViewPrincipioAtivo()
        {
            InitializeComponent();
        }
        public ViewPrincipioAtivo(ConsPrincipio frm) : this()
        {
            UltimoSelecionado = Convert.ToString(frm.codprincipio);
            RetReg();


        }

        private void RetReg()
        {
            string reg = "Select * from PrincipioAtivo ";
            if (UltimoSelecionado != null)
                reg += "Where idprincipio = " + UltimoSelecionado;
            else reg += " Where idprincipio = (Select Max(idprincipio) from PrincipioAtivo)";
            DataTable ds = new DataTable();
            SqlConnection Conn = Banco.CriarConexao();
            Conn.Open();

            if (Conn.State == ConnectionState.Open)
            {
                SqlCommand cmd = new SqlCommand(reg, Conn);
                SqlDataReader dr = cmd.ExecuteReader();
                if (dr.Read())
                {
                    txtcodigo.Text = dr["idprincipio"].ToString();
                    txtnome.Text = dr["nome"].ToString();

                }
            }
        }

        private Boolean ValidaCampos()
        {


            if (this.txtnome.Text == "")
            {
                MessageBox.Show("Informe o Nome do Correlato/Princípio Ativo");
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

        private void BtnSair_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void BtnNovo_Click(object sender, EventArgs e)
        {
            Limpacampos();
        }

        private void BtnSalvar_Click(object sender, EventArgs e)
        {

            if (ValidaCampos() == true)
            {
                VlPrincipio obj = new VlPrincipio();

                if (txtcodigo.Text != "")
                {
                    obj.idprincipio = Convert.ToInt32(txtcodigo.Text);
                }
                obj.nome = this.txtnome.Text.ToUpper();
                obj.idusu = Banco.idusu;


                try
                {
                    if (VerificaRegistroExiste(txtcodigo.Text) == true)
                    {

                        PsPrincipio DAOPrincipio = new PsPrincipio();
                        DAOPrincipio.Incluir(obj);
                        MessageBox.Show("Registro Incluido com Sucesso!");
                        Limpacampos();
                    }
                    else
                    {

                        PsPrincipio DAOPrincipio = new PsPrincipio();
                        DAOPrincipio.Alterar(obj);
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
            string obter = ("Select * From PrincipioAtivo Where idprincipio = '" + txtcodigo.Text + "'");
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
            VlPrincipio obj = new VlPrincipio();
            obj.idprincipio = Convert.ToInt32(txtcodigo.Text);

            try
            {

                PsPrincipio DAOPrincipio = new PsPrincipio();
                DAOPrincipio.Exluir(obj.idprincipio);
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
            ConsPrincipio frmc = new ConsPrincipio();
            this.Close();
            frmc.Show();
        }
    }
}
