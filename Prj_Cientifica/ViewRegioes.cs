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
    public partial class ViewRegioes : Form
    {

        public static string TipoGravacao;
        public static string UltimoSelecionado;

        public ViewRegioes()
        {
            InitializeComponent();
        }

        private void BtnSair_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        public ViewRegioes(ConsRegiao frm) : this()
        {
            UltimoSelecionado = Convert.ToString(frm.codregiao);
            RetReg();


        }

        private void RetReg()
        {
            string reg = "Select * from Regiao ";
            if (UltimoSelecionado != "")
                reg += "Where idregiao = " + UltimoSelecionado;
            else reg += "Where idregiao = (Select Max(idregiao) from Regiao)";
            DataTable ds = new DataTable();
            SqlConnection Conn = Banco.CriarConexao();
            Conn.Open();

            if (Conn.State == ConnectionState.Open)
            {
                SqlCommand cmd = new SqlCommand(reg, Conn);
                SqlDataReader dr = cmd.ExecuteReader();
                if (dr.Read())
                {
                    txtcodigo.Text = dr["idregiao"].ToString();
                    this.txtregiao.Text = dr["nome"].ToString();


                }
            }
        }
        private void Limpacampos()
        {
            txtcodigo.Text = "";
            this.txtregiao.Text = "";
            this.txtregiao.Focus();

        }

        private Boolean ValidaCampos()
        {
            if (this.txtregiao.Text == "")
            {
                MessageBox.Show("Informe a Região!");
                txtregiao.Focus();
                return false;

            }


            return true;


        }

        private void txtregiao_KeyPress(object sender, KeyPressEventArgs e)
        {
            if ((Keys)e.KeyChar == Keys.Enter)
            {
                this.BtnSalvar.Focus();
            }
        }

        private void btnPesquisar_Click(object sender, EventArgs e)
        {
            ConsRegiao frmc = new ConsRegiao();
            this.Close();
            frmc.Show();
        }

        private void BtnNovo_Click(object sender, EventArgs e)
        {
            Limpacampos();
        }

        private void BtnSalvar_Click(object sender, EventArgs e)
        {

            if (ValidaCampos() == true)
            {
                VlRegiao obj = new VlRegiao();

                if (txtcodigo.Text != "")
                {
                    obj.idregiao = Convert.ToInt32(txtcodigo.Text);
                }
                obj.nome = this.txtregiao.Text.ToUpper();
                obj.idusu = Banco.idusu ;


                try
                {
                    if (VerificaRegistroExiste(txtcodigo.Text) == true)
                    {

                        PsRegiao DAORegiao = new PsRegiao();
                        DAORegiao.Incluir(obj);
                        MessageBox.Show("Registro Incluido com Sucesso!");
                        Limpacampos();
                    }
                    else
                    {

                        PsRegiao DAORegiao = new PsRegiao();
                        DAORegiao.Alterar(obj);
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
            string obter = ("Select * From Regiao Where idregiao = '" + txtcodigo.Text + "'");
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
            VlRegiao obj = new VlRegiao();
            obj.idregiao = Convert.ToInt32(txtcodigo.Text);

            try
            {
                PsRegiao DAORegiao = new PsRegiao();
                DAORegiao.Exluir(obj.idregiao);
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
