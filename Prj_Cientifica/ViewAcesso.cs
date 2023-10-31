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
    public partial class ViewAcesso : Form
    {
        public ViewAcesso()
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

                this.cbousuario.DisplayMember = "nome";
                this.cbousuario.ValueMember = "idusu";
                this.cbousuario.DataSource = Dt.Tables["Usuarios"];
                this.cbousuario.SelectedIndex = cbousuario.Items.Count - 1;

               

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
                this.cbousuario.DataSource = Dt;
                this.cbousuario.DisplayMember = "nome";
                this.cbousuario.ValueMember = "idusu";
                this.cbousuario.Refresh();




            }
            catch (Exception erro)
            {

                throw erro;
            }
            Cnn.Close();
        }

        //private void CarregarMenu()
        //{
        //    SqlConnection Cnn = Banco.CriarConexao();
        //    SqlDataAdapter sql = new SqlDataAdapter("Select Distinct * from Menu", Cnn);
        //    DataSet Dt = new DataSet();
        //    sql.Fill(Dt, "Menu");
        //    DataRow dr = Dt.Tables["Menu"].NewRow();
        //    dr[1] = "";
        //    Dt.Tables["Menu"].Rows.Add(dr);
        //    try
        //    {

        //        this.cbomenu.DisplayMember = "menu";
        //        this.cbomenu.ValueMember = "idmenu";
        //        this.cbomenu.DataSource = Dt.Tables["Menu"];
        //        this.cbomenu.SelectedIndex = cbomenu.Items.Count - 1;



        //    }
        //    catch (Exception erro)
        //    {

        //        throw erro;
        //    }
        //    Cnn.Close();
        //}
        //private void RetornaMenu(Int32 retmenu)
        //{
        //    SqlConnection Cnn = Banco.CriarConexao();
        //    SqlDataAdapter sql = new SqlDataAdapter("Select * from Menu WHERE idmenu=" + retmenu + "", Cnn);
        //    DataTable Dt = new DataTable();
        //    sql.Fill(Dt);
        //    try
        //    {
        //        this.cbomenu.DataSource = Dt;
        //        this.cbomenu.DisplayMember = "menu";
        //        this.cbomenu.ValueMember = "idmenu";
        //        this.cbomenu.Refresh();




        //    }
        //    catch (Exception erro)
        //    {

        //        throw erro;
        //    }
        //    Cnn.Close();
        //}

        private void CarregarOpcoes()
        {
            SqlConnection Cnn = Banco.CriarConexao();
            SqlDataAdapter sql = new SqlDataAdapter("Select DISTINCT submenu from Menu Where menu='" + cbomenu.Text + "'", Cnn);
            DataSet Dt = new DataSet();
            sql.Fill(Dt, "Menu");
            DataRow dr = Dt.Tables["Menu"].NewRow();
            dr[0] = "";
            Dt.Tables["Menu"].Rows.Add(dr);
            try
            {

                this.cboopcoes.DisplayMember = "submenu";
               // this.cboopcoes.ValueMember = "idmenu";
                this.cboopcoes.DataSource = Dt.Tables["Menu"];
                this.cboopcoes.SelectedIndex = cboopcoes.Items.Count - 1;



            }
            catch (Exception erro)
            {

                throw erro;
            }
            Cnn.Close();
        }
        private void RetornaOpcoes(Int32 retop)
        {
            SqlConnection Cnn = Banco.CriarConexao();
            SqlDataAdapter sql = new SqlDataAdapter("Select distinct submenu from Menu WHERE idmenu=" + retop + "", Cnn);
            DataTable Dt = new DataTable();
            sql.Fill(Dt);
            try
            {
                this.cboopcoes.DataSource = Dt;
                this.cboopcoes.DisplayMember = "submenu";
               // this.cboopcoes.ValueMember = "idmenu";
                this.cboopcoes.Refresh();




            }
            catch (Exception erro)
            {

                throw erro;
            }
            Cnn.Close();
        }
        private void CarregarEmpresa()
        {
            SqlConnection Cnn = Banco.CriarConexao();
            SqlDataAdapter sql = new SqlDataAdapter("Select * from Empresa", Cnn);
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
        private void RetornaEmpresa(Int32 retemp)
        {
            SqlConnection Cnn = Banco.CriarConexao();
            SqlDataAdapter sql = new SqlDataAdapter("Select * from Empresa WHERE idempresa=" + retemp + "", Cnn);
            DataTable Dt = new DataTable();
            sql.Fill(Dt);
            try
            {
                this.cboempresa.DataSource = Dt;
                this.cboempresa.DisplayMember = "nome";
                this.cboempresa.ValueMember = "idusuario";
                this.cboempresa.Refresh();




            }
            catch (Exception erro)
            {

                throw erro;
            }
            Cnn.Close();
        }

        private void cbousuario_Click(object sender, EventArgs e)
        {
            CarregarUsuario();
        }

        private void cbomenu_Click(object sender, EventArgs e)
        {
           
        }

        private void cboopcoes_Click(object sender, EventArgs e)
        {
            CarregarOpcoes();
        }

        private void cboempresa_Click(object sender, EventArgs e)
        {
            CarregarEmpresa();
        }


        private void carregarGridConsulta()
        {
            DataTable ds = new DataTable();
            SqlConnection Conn = Banco.CriarConexao();
            try
            {
                Conn.Open();
            }

            catch (System.Exception e)
            {
                throw e;
            }

           // int codusuario = Convert.ToInt32(cbousuario.SelectedValue);


            if (Conn.State == ConnectionState.Open)
            {
                string strConn = "Select DISTINCT Menu.idmenu as Cod, Usuarios.nome as Nome,Menu.menu as Menu,Menu.submenu as Opção, CASE WHEN Menu.Permissao = 'True' THEN 'SIM' ELSE 'NAO' END as Permissao, Empresa.nome as Empresa" +
                " from Menu,Usuarios,Empresa Where Menu.idusu = Usuarios.idusu AND Menu.idempresa = Empresa.idempresa AND Usuarios.nome='" + cbousuario.Text  + "'";

                SqlDataAdapter da = new SqlDataAdapter(strConn, Conn);
                da.Fill(ds);


            }

            this.griditens.RowsDefaultCellStyle.BackColor = Color.LightBlue;
            this.griditens.AlternatingRowsDefaultCellStyle.BackColor = Color.Azure;


            griditens.AutoGenerateColumns = false;
            //exibe os dados no datagridview
            griditens.DataSource = ds;
            griditens.Columns.Clear();
            griditens.Columns.Add("Cod", "Cod");
            griditens.Columns.Add("Nome", "Nome");
            griditens.Columns.Add("Menu", "Menu");
            griditens.Columns.Add("Opção", "Opção");
            griditens.Columns.Add("Permissao", "Permissao");
            griditens.Columns.Add("Empresa", "Empresa");

            griditens.Columns[0].Width = 45;
            griditens.Columns[1].Width = 200;
            griditens.Columns[2].Width = 148;
            griditens.Columns[3].Width = 250;
            griditens.Columns[4].Width = 100;
            griditens.Columns[5].Width = 220;

            griditens.Columns[0].DataPropertyName = "Cod";
            griditens.Columns[1].DataPropertyName = "Nome";
            griditens.Columns[2].DataPropertyName = "Menu";
            griditens.Columns[3].DataPropertyName = "Opção";
            griditens.Columns[4].DataPropertyName = "Permissao";
            griditens.Columns[5].DataPropertyName = "Empresa";


            DataGridViewButtonColumn btn = new DataGridViewButtonColumn();
            griditens.Columns.Add(btn);
            btn.HeaderText = "Excluir";
            btn.Text = "Excluir";
            btn.Name = "btn";
            btn.Width = 60;
            btn.UseColumnTextForButtonValue = true;
            btn.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft;



            griditens.Refresh();
        }

        private void cbousuario_SelectionChangeCommitted(object sender, EventArgs e)
        {
            carregarGridConsulta();
        }

        private void btnBusca_Click(object sender, EventArgs e)
        {

            if (cbousuario.Text != "")
            {

                carregarGridConsulta();
            }
        }

        private Boolean ValidaCampos()
        {
            if (this.cbousuario.Text == "")
            {
                MessageBox.Show("Informe o Usuário");
                cbousuario.Focus();
                return false;

            }

            if (this.cbomenu.Text == "")
            {
                MessageBox.Show("informe o Menu a ser Perminito");
                cbomenu.Focus();
                return false;

            }
            if (this.cboopcoes.Text == "")
            {
                MessageBox.Show("informe a Opção a ser Permitida!");
                cboopcoes.Focus();
                return false;

            }

            if (this.cbopermissao.Text == "")
            {
                MessageBox.Show("informe a Permissão!");
                cbopermissao.Focus();
                return false;

            }

            if (this.cboempresa.Text == "")
            {
                MessageBox.Show("informe a Empresa!");
                cboempresa.Focus();
                return false;

            }

          


            return true;


        }

        private void BtnSalvar_Click(object sender, EventArgs e)
        {
            if (ValidaCampos() == true)
            {



                VlAcessos obj = new VlAcessos();
                obj.menu = cbomenu.Text;
                obj.submenu = cboopcoes.Text;
                if (cbopermissao.Text == "SIM")
                {
                    obj.permissao = Convert.ToBoolean(1);
                }
                else if(cbopermissao.Text == "NAO")
                {
                    obj.permissao = Convert.ToBoolean(0);
                }
                obj.idusu = Convert.ToInt32(cbousuario.SelectedValue);
                obj.idempresa = Convert.ToInt32(cboempresa.SelectedValue);

                try
                {
                    if (VerificaRegistroExiste() == true)
                    {

                        PsAcessos DAOAcesso = new PsAcessos();
                        DAOAcesso.Incluir(obj);
                        MessageBox.Show("Registro Incluido com Sucesso!");
                       // Limpacampos();
                        carregarGrid();
                    }
                  
                }
                catch (Exception erro)
                {

                    throw erro;
                }
            }
        }
        
        private Boolean VerificaRegistroExiste()
        {

            SqlConnection Cnn = Banco.CriarConexao();
            string obter = ("Select * From Menu Where Menu = '" + cbomenu.Text + "' AND submenu ='" + cboopcoes.Text + "' AND idusu=" + cbousuario.SelectedValue + " AND idempresa=" + cboempresa.SelectedValue + "" );
            SqlCommand sql = new SqlCommand(obter, Cnn);
            Cnn.Open();
            SqlDataReader dr = sql.ExecuteReader();
            if (dr.Read())
            {

                return false;
            }
            return true;
        }

        private void carregarGrid()
        {
            DataTable ds = new DataTable();
            SqlConnection Conn = Banco.CriarConexao();

            try
            {
                Conn.Open();
            }

            catch (System.Exception e)
            {
                throw e;
            }

            // int codusuario = Convert.ToInt32(cbousuario.SelectedValue);


            if (Conn.State == ConnectionState.Open)
            {
                string strConn = "Select DISTINCT Menu.idmenu as Cod, Usuarios.nome as Nome,Menu.menu as Menu,Menu.submenu as Opção, Menu.Permissao as Permissao, Empresa.nome as Empresa" +
                " from Menu,Usuarios,Empresa Where Menu.idusu = Usuarios.idusu AND Menu.idempresa = Empresa.idempresa AND Usuarios.nome='" + cbousuario.Text + "'";

                SqlDataAdapter da = new SqlDataAdapter(strConn, Conn);
                da.Fill(ds);


            }

            this.griditens.RowsDefaultCellStyle.BackColor = Color.LightBlue;
            this.griditens.AlternatingRowsDefaultCellStyle.BackColor = Color.Azure;


            griditens.AutoGenerateColumns = false;
            //exibe os dados no datagridview
            griditens.DataSource = ds;
            griditens.Columns.Clear();
            griditens.Columns.Add("Cod", "Cod");
            griditens.Columns.Add("Nome", "Nome");
            griditens.Columns.Add("Menu", "Menu");
            griditens.Columns.Add("Opção", "Opção");
            griditens.Columns.Add("Permissao", "Permissao");
            griditens.Columns.Add("Empresa", "Empresa");

            griditens.Columns[0].Width = 45;
            griditens.Columns[1].Width = 200;
            griditens.Columns[2].Width = 148;
            griditens.Columns[3].Width = 250;
            griditens.Columns[4].Width = 100;
            griditens.Columns[5].Width = 220;


            griditens.Columns[0].DataPropertyName = "Cod";
            griditens.Columns[1].DataPropertyName = "Nome";
            griditens.Columns[2].DataPropertyName = "Menu";
            griditens.Columns[3].DataPropertyName = "Opção";
            griditens.Columns[4].DataPropertyName = "Permissao";
            griditens.Columns[5].DataPropertyName = "Empresa";


            DataGridViewButtonColumn btn = new DataGridViewButtonColumn();
            griditens.Columns.Add(btn);
            btn.HeaderText = "Excluir";
            btn.Text = "Excluir";
            btn.Name = "btn";
            btn.Width = 50;
            btn.UseColumnTextForButtonValue = true;
            btn.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft;



            griditens.Refresh();
        }
        int codi;
        private void griditens_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex == 6)
            {
                codi = Convert.ToInt32(griditens[0, e.RowIndex].Value.ToString());

                VlAcessos obj = new VlAcessos();
                obj.idmenu = codi;

                try
                {
                    PsAcessos DAOAcessos = new PsAcessos();
                    DialogResult result = MessageBox.Show("Deseja Excluir este Item !", "Excluir", MessageBoxButtons.YesNo);
                    if (result == DialogResult.Yes)
                    {
                        DAOAcessos.Exluir(obj.idmenu);
                        MessageBox.Show("Registro Excluido com Sucesso!");
                        carregarGrid();

                    }
                    else if (result == DialogResult.No)
                    {
                        return;
                    }



                }
                catch (Exception erro)
                {

                    throw erro;
                }



            }
            else
            {

                codi = Convert.ToInt32(griditens[0, e.RowIndex].Value.ToString());


            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            ViewConcederPermissoes permitir = new ViewConcederPermissoes();
            permitir.Show();
        }

        private void btnSair_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
