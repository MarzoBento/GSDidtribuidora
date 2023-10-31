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
    public partial class ViewTipoDocumento : Form
    {
        public static string TipoGravacao;
        public static string UltimoSelecionado;

        public ViewTipoDocumento()
        {
            InitializeComponent();
        }

        public ViewTipoDocumento(ConsTipoDocumento frm) : this()
        {
            UltimoSelecionado = Convert.ToString(frm.coddoc);
            RetReg();


        }

        private void RetReg()
        {
            string reg = "Select * from TipoDocumento ";
            if (UltimoSelecionado != "")
                reg += "Where idtipodocumento = " + UltimoSelecionado;
            else reg += "Where idtipodocumento = (Select Max(idtipodocumento) from TipoDocumento)";
            DataTable ds = new DataTable();
            SqlConnection Conn = Banco.CriarConexao();
            Conn.Open();

            if (Conn.State == ConnectionState.Open)
            {
                SqlCommand cmd = new SqlCommand(reg, Conn);
                SqlDataReader dr = cmd.ExecuteReader();
                if (dr.Read())
                {
                    txtcodigo.Text = dr["idtipodocumento"].ToString();
                    this.txttipo.Text = dr["nome"].ToString();
                    this.txtobs.Text = dr["obs"].ToString();


                }
            }
        }

        private void Limpacampos()
        {
            txtcodigo.Text = "";
            this.txttipo.Text = "";
            this.txtobs.Text = "";
            this.txttipo.Focus();

        }

        private Boolean ValidaCampos()
        {
            if (this.txttipo.Text == "")
            {
                MessageBox.Show("Informe o Tipo do Documento!");
                txttipo.Focus();
                return false;

            }


            return true;


        }


        private void txttipo_KeyPress(object sender, KeyPressEventArgs e)
        {
            if ((Keys)e.KeyChar == Keys.Enter)
            {
                this.txtobs.Focus();
            }
        }

        private void BtnNovo_Click(object sender, EventArgs e)
        {
            Limpacampos();
        }

        private void btnPesquisar_Click(object sender, EventArgs e)
        {
            ConsTipoDocumento frmc = new ConsTipoDocumento();
            this.Close();
            frmc.Show();
        }

        private void BtnSair_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void BtnSalvar_Click(object sender, EventArgs e)
        {
            if (ValidaCampos() == true)
            {
              VlTipoDocumento   obj = new VlTipoDocumento();

                if (txtcodigo.Text != "")
                {
                    obj.idtipodocumento = Convert.ToInt32(txtcodigo.Text);
                }
                obj.nome = this.txttipo.Text.ToUpper();
                obj.obs = txtobs.Text;
               

                try
                {
                    if (VerificaRegistroExiste(txtcodigo.Text) == true)
                    {

                        PsTipoDocumento DAOTipodocumento = new PsTipoDocumento();
                        DAOTipodocumento.Incluir(obj);
                        MessageBox.Show("Registro Incluido com Sucesso!");
                        Limpacampos();
                    }
                    else
                    {

                        PsTipoDocumento DAOTipodocumento = new PsTipoDocumento();
                        DAOTipodocumento.Alterar(obj);
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
            string obter = ("Select * From TipoDocumento Where idtipodocumento = '" + txtcodigo.Text + "'");
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
            VlTipoDocumento obj = new VlTipoDocumento();
            obj.idtipodocumento = Convert.ToInt32(txtcodigo.Text);

            try
            {
                PsTipoDocumento DAOTipodocumento = new PsTipoDocumento();
                DAOTipodocumento.Exluir(obj.idtipodocumento);
                MessageBox.Show("Registro Excluido Com Sucesso!");
                Limpacampos();




            }
            catch (Exception erro)
            {

                throw erro;
            }
        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }
    }
}
