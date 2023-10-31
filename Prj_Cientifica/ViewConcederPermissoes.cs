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
    public partial class ViewConcederPermissoes : Form
    {
        public ViewConcederPermissoes()
        {
            InitializeComponent();
        }


        private void CarregarUsuario()
        {
            SqlConnection Cnn = Banco.CriarConexao();
            SqlDataAdapter sql = new SqlDataAdapter("Select * from Usuarios", Cnn);
            DataSet Dt = new DataSet();
            sql.Fill(Dt, "Usuarios");
            DataRow dr = Dt.Tables["Usuarios"].NewRow();
            dr[1] = "";
            Dt.Tables["Usuarios"].Rows.Add(dr);
            try
            {

                this.cbousuarioatual.DisplayMember = "nome";
                this.cbousuarioatual.ValueMember = "idusu";
                this.cbousuarioatual.DataSource = Dt.Tables["Usuarios"];
                this.cbousuarioatual.SelectedIndex = cbousuarioatual.Items.Count - 1;



            }
            catch (Exception erro)
            {

                throw erro;
            }
            Cnn.Close();
        }
        private void RetornaUsuario(Int32 retusu)
        {
            SqlConnection Cnn = Banco.CriarConexao();
            SqlDataAdapter sql = new SqlDataAdapter("Select * from Usuarios WHERE idusuario=" + retusu + "", Cnn);
            DataTable Dt = new DataTable();
            sql.Fill(Dt);
            try
            {
                this.cbousuarioatual.DataSource = Dt;
                this.cbousuarioatual.DisplayMember = "nome";
                this.cbousuarioatual.ValueMember = "idusu";
                this.cbousuarioatual.Refresh();




            }
            catch (Exception erro)
            {

                throw erro;
            }
            Cnn.Close();
        }


        private void CarregarUsuario2()
        {
            SqlConnection Cnn = Banco.CriarConexao();
            SqlDataAdapter sql = new SqlDataAdapter("Select * from Usuarios", Cnn);
            DataSet Dt = new DataSet();
            sql.Fill(Dt, "Usuarios");
            DataRow dr = Dt.Tables["Usuarios"].NewRow();
            dr[1] = "";
            Dt.Tables["Usuarios"].Rows.Add(dr);
            try
            {

                this.cbousuariopermitir.DisplayMember = "nome";
                this.cbousuariopermitir.ValueMember = "idusu";
                this.cbousuariopermitir.DataSource = Dt.Tables["Usuarios"];
                this.cbousuariopermitir.SelectedIndex = cbousuariopermitir.Items.Count - 1;



            }
            catch (Exception erro)
            {

                throw erro;
            }
            Cnn.Close();
        }
        private void RetornaUsuario2(Int32 retusu)
        {
            SqlConnection Cnn = Banco.CriarConexao();
            SqlDataAdapter sql = new SqlDataAdapter("Select * from Usuarios WHERE idusuario=" + retusu + "", Cnn);
            DataTable Dt = new DataTable();
            sql.Fill(Dt);
            try
            {
                this.cbousuariopermitir.DataSource = Dt;
                this.cbousuariopermitir.DisplayMember = "nome";
                this.cbousuariopermitir.ValueMember = "idusu";
                this.cbousuariopermitir.Refresh();




            }
            catch (Exception erro)
            {

                throw erro;
            }
            Cnn.Close();
        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }

        private void cbousuarioatual_Click(object sender, EventArgs e)
        {
            CarregarUsuario();
        }

        private void cbousuariopermitir_Click(object sender, EventArgs e)
        {
            CarregarUsuario2();
        }

        private void BtnNovo_Click(object sender, EventArgs e)
        {
            cbousuarioatual.SelectedIndex = -1;
            cbousuariopermitir.SelectedIndex = -1;
            cbousuarioatual.Focus();
        }

        private void BtnSair_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnConceder_Click(object sender, EventArgs e)
        {
            string query = "Insert into Menu (menu,submenu,permissao,idusu,idempresa) select menu,submenu,permissao," + cbousuariopermitir.SelectedValue + ",idempresa from Menu WHERE idusu=" + cbousuarioatual.SelectedValue;
            SqlConnection Cnx = Banco.CriarConexao();
            Cnx.Open();
            SqlCommand cmd = new SqlCommand(query, Cnx);
            SqlDataReader dr = cmd.ExecuteReader();

            VlAcessos acessos = new VlAcessos();


            if (dr.Read())
            {

                MessageBox.Show("Permissão Concedida com sucesso!");

            }
        }
        private Boolean VerificaRegistroExiste(string qd)
        {

            SqlConnection Cnn = Banco.CriarConexao();
            string obter = ("Select * From Menu Where idusu = " + cbousuarioatual.SelectedValue + "");
            SqlCommand sql = new SqlCommand(obter, Cnn);
            Cnn.Open();
            SqlDataReader dr = sql.ExecuteReader();
            if (dr.Read())
            {

                return false;
            }
            return true;
        }
    }
}
