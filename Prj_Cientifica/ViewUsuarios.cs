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
    public partial class ViewUsuarios : Form
    {
        public static string TipoGravacao;
        public static string UltimoSelecionado;

        public ViewUsuarios()
        {
            InitializeComponent();
        }

        public ViewUsuarios(ConsUsuario frm) : this()
        {
            UltimoSelecionado = Convert.ToString(frm.codusuario);
            RetReg();


        }

        private void RetReg()
        {
            string reg = "Select * from usuarios ";
            if (UltimoSelecionado != "")
                reg += "Where idusu = " + UltimoSelecionado;
            else reg += "Where idusu = (Select Max(idusu) from usuarios)";
            DataTable ds = new DataTable();
            SqlConnection Conn = Banco.CriarConexao();
            Conn.Open();

            if (Conn.State == ConnectionState.Open)
            {
                SqlCommand cmd = new SqlCommand(reg, Conn);
                SqlDataReader dr = cmd.ExecuteReader();
                if (dr.Read())
                {
                    txtcodigo.Text = dr["idusu"].ToString();
                    txtnome.Text = dr["nome"].ToString();
                    txtemail.Text = dr["email"].ToString();
                    txtlogin.Text = dr["login"].ToString();
                    txtsenha.Text = dr["senha"].ToString();
                    cbostatus.Text = dr["status"].ToString();
                    txtdados.Text = dr["dados"].ToString();




                }
            }
        }

              private void Limpacampos()
        {
            txtcodigo.Text = "";
            txtnome.Text = "";
            txtemail.Text = "";
            txtlogin.Text = "";
            txtsenha.Text = "";
            cbostatus.Text = "";
            txtdados.Text = "";
            txtnome.Focus();

        }

        private Boolean ValidaCampos()
        {
            if (this.txtnome.Text == "")
            {
                MessageBox.Show("Informe o Nome");
                txtnome.Focus();
                return false;

            }

            if (this.txtemail.Text == "")
            {
                MessageBox.Show("informe o Email");
                txtemail.Focus();
                return false;

            }
            if (this.txtlogin.Text == "")
            {
                MessageBox.Show("informe o Login");
                txtlogin.Focus();
                return false;

            }
            if (this.txtsenha.Text == "")
            {
                MessageBox.Show("informe a Senha");
                txtsenha.Focus();
                return false;

            }
            if (this.cbostatus.Text == "")
            {
                MessageBox.Show("informe o Status do Usuário");
                cbostatus.Focus();
                return false;

            }
          
          


            return true;


        }



        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }

        private void BtnSair_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void BtnSalvar_Click(object sender, EventArgs e)
        {
            if (ValidaCampos() == true)
            {
                VlUsuario obj = new VlUsuario();


                if (txtcodigo.Text != "")
                {
                    obj.idusu = Convert.ToInt32(txtcodigo.Text);
                }
                obj.nome = txtnome.Text.ToUpper();
                obj.email = txtemail.Text.ToLower();
                obj.login = txtlogin.Text.ToUpper();
                obj.senha = txtsenha.Text;
                obj.status = cbostatus.Text.ToUpper();
                obj.dados = txtdados.Text;
              

                try
                {
                    if (VerificaRegistroExiste(txtcodigo.Text) == true)
                    {

                        PsUsuario PPsUsuariobll = new PsUsuario();
                        PPsUsuariobll.Incluir(obj);
                        MessageBox.Show("Registro Incluido com Sucesso!");
                        Limpacampos();
                    }
                    else
                    {

                        PsUsuario PPsUsuariobll = new PsUsuario();
                        PPsUsuariobll.Alterar(obj);
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
            string obter = ("Select * From usuarios Where idusu = '" + txtcodigo.Text + "'");
            SqlCommand sql = new SqlCommand(obter, Cnn);
            Cnn.Open();
            SqlDataReader dr = sql.ExecuteReader();
            if (dr.Read())
            {

                return false;
            }
            return true;
        }

        private void BtnNovo_Click(object sender, EventArgs e)
        {
            Limpacampos();
        }

        private void BtnRemover_Click(object sender, EventArgs e)
        {
            VlUsuario obj = new VlUsuario();
            obj.idusu = Convert.ToInt32(txtcodigo.Text);

            try
            {
                PsUsuario PsUsuariobll = new PsUsuario();
                PsUsuariobll.Exluir(obj.idusu);
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
            ConsUsuario frmc = new ConsUsuario();
            this.Close();
            frmc.Show();
        }
    }
}
