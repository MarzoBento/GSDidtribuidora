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
    public partial class ViewModalidade : Form
    {

        public static string TipoGravacao;
        public static string UltimoSelecionado;
        public static int Tipo;
        public ViewModalidade()
        {
            InitializeComponent();
        }
        public ViewModalidade(ConsModalidade frm) : this()
        {
            UltimoSelecionado = Convert.ToString(frm.codmod);
            RetReg();

        }
        private void RetReg()
        {
            string reg = "Select * from Modalidade ";
            if (UltimoSelecionado != "")
                reg += "Where idmodalidade = " + UltimoSelecionado;
            else reg += " Where idmodalidade = (Select Max(idmodalidade) from Modalidade)";
            DataTable ds = new DataTable();
            SqlConnection Conn = Banco.CriarConexao();
            Conn.Open();

            if (Conn.State == ConnectionState.Open)
            {
                SqlCommand cmd = new SqlCommand(reg, Conn);
                SqlDataReader dr = cmd.ExecuteReader();
                if (dr.Read())
                {
                    txtcodigo.Text = dr["idmodalidade"].ToString();
                    txtmodalidade.Text = dr["nome"].ToString();
                    if(Convert.ToInt32(dr["tipo"].ToString()) == 1)
                    {
                        RbtLicNormal.Checked = true;
                    }
                    else if (Convert.ToInt32(dr["tipo"].ToString()) == 2)
                    {
                        RbtPregao.Checked = true;
                    }
                            


                }
            }
        }

        private Boolean ValidaCampos()
        {


            if (this.txtmodalidade.Text == "")
            {
                MessageBox.Show("Informe o Nome da Modalidade");
                txtmodalidade.Focus();
                return false;

            }

            if (RbtLicNormal.Checked == false && RbtPregao.Checked == false)
            {
                MessageBox.Show("Informe o Tipo da Licitação");
                RbtLicNormal.Focus();
                return false;

            }




            return true;


        }
        private void Limpacampos()
        {
            txtcodigo.Text = "";
            txtmodalidade.Text = "";
            txtmodalidade.Focus();


        }

        private void RbtLicNormal_CheckedChanged(object sender, EventArgs e)
        {
            if(RbtLicNormal.Checked == true)
            {
                Tipo = 1;
            }
        }

        private void RbtPregao_CheckedChanged(object sender, EventArgs e)
        {
            if (RbtPregao.Checked == true)
            {
                Tipo = 2;
            }
        }

        private void BtnSair_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnPesquisar_Click(object sender, EventArgs e)
        {
            ConsModalidade frmconv = new ConsModalidade();
            this.Close();
            frmconv.Show();
        }

        private void BtnNovo_Click(object sender, EventArgs e)
        {
            Limpacampos();
        }

        private void BtnSalvar_Click(object sender, EventArgs e)
        {
            if (ValidaCampos() == true)
            {
                VlModalidade obj = new VlModalidade();

                if (txtcodigo.Text != "")
                {
                    obj.idmodalidade = Convert.ToInt32(txtcodigo.Text);
                }
                obj.nome = this.txtmodalidade.Text.ToUpper();
                if(RbtLicNormal.Checked == true)
                {
                    obj.tipo = 1;
                }
                else if (RbtPregao.Checked == true)
                {
                    obj.tipo = 2;
                }
                obj.idusu = Banco.idusu;



                try
                {
                    if (VerificaRegistroExiste(txtcodigo.Text) == true)
                    {

                        PsModalidade DAOModalidade = new PsModalidade();
                        DAOModalidade.Incluir(obj);
                        MessageBox.Show("Registro Incluido com Sucesso!");
                        Limpacampos();
                    }
                    else
                    {


                        PsModalidade DAOModalidade = new PsModalidade();
                        DAOModalidade.Alterar(obj);
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
            string obter = ("Select * From Modalidade Where idmodalidade = '" + txtcodigo.Text + "'");
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
            VlModalidade obj = new VlModalidade();
            obj.idmodalidade = Convert.ToInt32(txtcodigo.Text);

            try
            {
                PsModalidade DAOModalidade = new PsModalidade();
                DAOModalidade.Exluir(obj.idmodalidade);
                MessageBox.Show("Registro Excluido Com Sucesso!");
                Limpacampos();




            }
            catch (Exception erro)
            {

                throw erro;
            }
        }

        private void ViewModalidade_Load(object sender, EventArgs e)
        {
           
        }
    }
}
