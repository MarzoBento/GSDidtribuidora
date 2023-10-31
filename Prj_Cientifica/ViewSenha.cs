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
    public partial class ViewSenha : Form
    {
        public ViewSenha()
        {
            InitializeComponent();
            this.StartPosition = FormStartPosition.CenterScreen;
        }


        private void CarregaEmpresa()
        {
            SqlConnection Cnn = Banco.CriarConexao();
            SqlDataAdapter sql = new SqlDataAdapter("Select Empresa.idempresa, Empresa.nome as nome  from Empresa,usuarios, Acessos where Empresa.idempresa = Acessos.idempresa And usuarios.idusu = Acessos.idusu And Usuarios.login ='" + txtusuario.Text + "' Order by nome Asc", Cnn);
            DataSet Dt = new DataSet();
            sql.Fill(Dt, "Empresa");
            DataRow dr = Dt.Tables["Empresa"].NewRow();
            dr[1] = "";
            Dt.Tables["Empresa"].Rows.Add(dr);
            try
            {

                this.cboempresa.DisplayMember = "nome";
                this.cboempresa.ValueMember = "idempresa";
                this.cboempresa.DataSource = Dt.Tables["Empresa"];
                this.cboempresa.SelectedIndex = cboempresa.Items.Count - 1;



            }
            catch (Exception erro)
            {

                throw erro;
            }
            Cnn.Close();
        }
        public string statususu;

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void BtnEntrar_Click(object sender, EventArgs e)
        {

            if (txtusuario.Text != "" & txtsenha.Text != "" & cboempresa.SelectedValue != null)
            {
                SqlConnection Cnn = Banco.CriarConexao();
                string obter = ("Select Empresa.nome as nomeemp, Empresa.idempresa,usuarios.*,Menu.menu,Menu.permissao From Usuarios, Empresa,Menu " +
                    "Where  usuarios.idusu = Menu.idusu AND  Empresa.idempresa=" + cboempresa.SelectedValue + " AND Login = '" + txtusuario.Text + "' And Senha = '" + txtsenha.Text + "'");
                SqlCommand sql = new SqlCommand(obter, Cnn);
                Cnn.Open();
                SqlDataReader dr = sql.ExecuteReader();
                if (dr.Read())
                {
                    string Login = dr["Login"].ToString();
                    //Banco.tipousuario = dr["tipousuario"].ToString();
                    statususu = dr["status"].ToString();
                    Banco.Nomeusu = dr["nome"].ToString();
                    Banco.idusu = Convert.ToInt32(dr["idusu"].ToString());
                    Banco.idemp = Convert.ToInt32(dr["idempresa"].ToString());
                    Banco.nomeempresa = dr["nomeemp"].ToString();
                    Banco.login = dr["login"].ToString();
                    Banco.senha = dr["senha"].ToString();

                  
                   // DAOUsuarioMenu.ControleMenu();



                    MDIPrincipal Principal = new MDIPrincipal(this);
                    Principal.FormClosing += new FormClosingEventHandler(Principal_FormClosing);
                    this.Visible = false;
                    Cnn.Close();
                    Principal.ShowDialog();

                }
                else
                {
                    MessageBox.Show("Dados Incorretos !");
                    txtusuario.Text = "";
                    txtsenha.Text = "";
                    txtusuario.Focus();
                }
                Cnn.Close();
            }
            else
            {
                MessageBox.Show("Dados Incorretos !");
                txtusuario.Text = "";
                txtsenha.Text = "";
                txtusuario.Focus();

            }
        

         

        }
        void Principal_FormClosing(object sender, FormClosingEventArgs e)
        {
            Application.Exit();
        }

        private void txtusuario_TextChanged(object sender, EventArgs e)
        {
            if (txtusuario.Text != "")
            {

                CarregaEmpresa();
            }

        }

        private void BtnCancelar_Click(object sender, EventArgs e)
        {
            txtusuario.Controls.Clear();
            txtsenha.Text = "";
            txtusuario.Focus();
        }

        private void txtusuario_KeyPress(object sender, KeyPressEventArgs e)
        {
            if ((Keys)e.KeyChar == Keys.Enter)
            {

                this.cboempresa.Focus();
            }
        }

        private void cboempresa_KeyPress(object sender, KeyPressEventArgs e)
        {
            if ((Keys)e.KeyChar == Keys.Enter)
            {
                this.txtsenha.Focus();
            }
        }

        private void txtsenha_KeyPress(object sender, KeyPressEventArgs e)
        {
            if ((Keys)e.KeyChar == Keys.Enter)
            {
                this.BtnEntrar.Focus();
            }
        }

        private void BtnSair_Click(object sender, EventArgs e)
        {
            this.Close();
        }


        public static void ControleMenu(MDIPrincipal frm)
        {

            MenuStrip mnu = (MenuStrip)frm.Controls["menuStrip"];


            foreach (ToolStripMenuItem item in mnu.Items)
            {

                if (item.ToString() == Banco.menu)
                {

                    item.Visible = Banco.status;

                }

                foreach (ToolStripItem ObjSubMenu in item.DropDownItems)
                {
                    if (ObjSubMenu.ToString() == Banco.menu)
                    {

                        ObjSubMenu.Visible = Banco.status;
                    }

                }


            }


        }

    }
}
