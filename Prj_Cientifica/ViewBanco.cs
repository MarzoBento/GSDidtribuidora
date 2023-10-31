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
    public partial class ViewBanco : Form
    {
        public static string TipoGravacao;
        public static string UltimoSelecionado;
        public ViewBanco()
        {
            InitializeComponent();
        }
        public ViewBanco(ConsBanco frm) : this()
        {
            UltimoSelecionado = Convert.ToString(frm.codbanco);
            RetReg();


        }
        private void RetReg()
        {
            string reg = "Select * from Banco ";
            if (UltimoSelecionado != "")
                reg += "Where idbanco = " + UltimoSelecionado;
            else reg += " Where idbanco = (Select Max(idbanco) from Banco)";
            DataTable ds = new DataTable();
            SqlConnection Conn = Banco.CriarConexao();
            Conn.Open();

            if (Conn.State == ConnectionState.Open)
            {
                SqlCommand cmd = new SqlCommand(reg, Conn);
                SqlDataReader dr = cmd.ExecuteReader();
                if (dr.Read())
                {
                    txtcodigo.Text = dr["idbanco"].ToString();
                    txtnomebanco.Text = dr["nome"].ToString();

                }
            }
        }

        private Boolean ValidaCampos()
        {
          

            if (this.txtnomebanco.Text == "")
            {
                MessageBox.Show("Informe o Nome do Banco");
                txtnomebanco.Focus();
                return false;

            }

            return true;


        }
        private void Limpacampos()
        {
            txtcodigo.Text = "";
            txtnomebanco.Text = "";
            txtnomebanco.Focus();


        }

        private void txtnomebanco_KeyPress(object sender, KeyPressEventArgs e)
        {
            if ((Keys)e.KeyChar == Keys.Enter)
            {
                this.BtnSalvar.Focus();
            }
        }

        private void BtnRemover_Click(object sender, EventArgs e)
        {
            VlBanco obj = new VlBanco();
            obj.idbanco = Convert.ToInt32(txtcodigo.Text);

            try
            {
                PsBanco PsBancobll = new PsBanco();
                PsBancobll.Exluir(obj.idbanco);
                MessageBox.Show("Registro Excluido Com Sucesso!");
                Limpacampos();




            }
            catch (Exception erro)
            {

                throw erro;
            }
        }

        private void BtnSair_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private Boolean VerificaRegistroExiste(string qd)
        {

            SqlConnection Cnn = Banco.CriarConexao();
            string obter = ("Select * From Banco Where idbanco = '" + txtcodigo.Text + "'");
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
                VlBanco obj = new VlBanco();

                if (txtcodigo.Text != "")
                {
                    obj.idbanco = Convert.ToInt32(txtcodigo.Text);
                }
                obj.nome = this.txtnomebanco.Text.ToUpper();
                obj.idusu = Banco.idusu;
               


                try
                {
                    if (VerificaRegistroExiste(txtcodigo.Text) == true)
                    {

                        PsBanco PsBancobll = new PsBanco();
                        PsBancobll.Incluir(obj);
                        MessageBox.Show("Registro Incluido com Sucesso!");
                        Limpacampos();
                    }
                    else
                    {


                        PsBanco PsBancobll = new PsBanco();
                        PsBancobll.Alterar(obj);
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

        private void BtnNovo_Click(object sender, EventArgs e)
        {
            Limpacampos();
        }

        private void btnPesquisar_Click(object sender, EventArgs e)
        {
            ConsBanco frmconv = new ConsBanco();
            this.Close();
            frmconv.Show();
        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }
    }
}
