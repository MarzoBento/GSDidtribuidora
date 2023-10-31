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
    public partial class ViewCidade : Form
    {
        public static string TipoGravacao;
        public static string UltimoSelecionado;

        public ViewCidade()
        {
            InitializeComponent();
        }

        public ViewCidade(ConsCidade frm) : this()
        {
            UltimoSelecionado = Convert.ToString(frm.codcid);
            RetReg();


        }
        private void RetReg()
        {
            string reg = "Select * from Cidade ";
            if (UltimoSelecionado != "")
                reg += "Where idcidade = " + UltimoSelecionado;
            else reg += "Where idcidade = (Select Max(idcidade) from Cidade)";
            DataTable ds = new DataTable();
            SqlConnection Conn = Banco.CriarConexao();
            Conn.Open();

            if (Conn.State == ConnectionState.Open)
            {
                SqlCommand cmd = new SqlCommand(reg, Conn);
                SqlDataReader dr = cmd.ExecuteReader();
                if (dr.Read())
                {
                    txtcodigo.Text = dr["idcidade"].ToString();
                    txtcidade.Text = dr["nome"].ToString();
                    cmbuf.Text = dr["uf"].ToString();

                }
            }
        }

        private void Limpacampos()
        {
            txtcodigo.Text = "";
            txtcidade.Text = "";
            cmbuf.Text = "";

        }
        private Boolean ValidaCampos()
        {
            if (this.txtcidade.Text == "")
            {
                MessageBox.Show("Informe a Cidade");
                txtcidade.Focus();
                return false;

            }

            if (this.cmbuf.Text == "")
            {
                MessageBox.Show("Informe a UF");
                cmbuf.Focus();
                return false;

            }


            return true;


        }
        private Boolean VerificaRegistroExiste(string qd)
        {

            SqlConnection Cnn = Banco.CriarConexao();
            string obter = ("Select * From Cidade Where idcidade = '" + txtcodigo.Text + "'");
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
                VlCidade obj = new VlCidade();

                if (txtcodigo.Text != "")
                {
                    obj.idcidade = Convert.ToInt32(txtcodigo.Text);
                }

                obj.nome = txtcidade.Text.ToUpper();
                obj.uf = cmbuf.Text.ToUpper();
                obj.idusu = Banco.idusu;



                try
                {
                    if (VerificaRegistroExiste(txtcodigo.Text) == true)
                    {

                        PsCidade PsCidadebll = new PsCidade();
                        PsCidadebll.Incluir(obj);
                        MessageBox.Show("Registro Incluido com Sucesso!");
                        Limpacampos();
                    }
                    else
                    {

                        PsCidade PsCidadebll = new PsCidade();
                        PsCidadebll.Alterar(obj);
                        MessageBox.Show("Registro Alterada com Sucesso!");
                        Limpacampos();
                        //RetReg();

                    }
                    //RetReg();

                }
                catch (Exception erro)
                {

                    throw erro;
                }
            }
        }

        private void txtcidade_KeyPress(object sender, KeyPressEventArgs e)
        {
            if ((Keys)e.KeyChar == Keys.Enter)
            {
                this.cmbuf.Focus();
            }
        }

        private void cmbuf_KeyPress(object sender, KeyPressEventArgs e)
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

        private void btnPesquisar_Click(object sender, EventArgs e)
        {
            ConsCidade frmcid = new ConsCidade();
            this.Close();
            frmcid.Show();
        }

        private void BtnRemover_Click(object sender, EventArgs e)
        {
            VlCidade obj = new VlCidade();
            obj.idcidade = Convert.ToInt32(txtcodigo.Text);

            try
            {
                PsCidade PsCidadebll = new PsCidade();
                PsCidadebll.Exluir(obj.idcidade);
                MessageBox.Show("Registro Excluido Com Sucesso!");
                Limpacampos();




            }
            catch (Exception erro)
            {

                throw erro;
            }
        }
    }
}
