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
    public partial class ViewUnidadeMedida : Form
    {

        public static string TipoGravacao;
        public static string UltimoSelecionado;

        public ViewUnidadeMedida()
        {
            InitializeComponent();
        }
        public ViewUnidadeMedida(ConsUnidaddeMedida frm) : this()
        {
            UltimoSelecionado = Convert.ToString(frm.codunidade);
            RetReg();


        }
        private void RetReg()
        {
            string reg = "Select * from UnidadeMedida ";
            if (UltimoSelecionado != null)
                reg += "Where idunidade = " + UltimoSelecionado;
            else reg += " Where idunidade = (Select Max(idunidade) from UnidadeMedida)";
            DataTable ds = new DataTable();
            SqlConnection Conn = Banco.CriarConexao();
            Conn.Open();

            if (Conn.State == ConnectionState.Open)
            {
                SqlCommand cmd = new SqlCommand(reg, Conn);
                SqlDataReader dr = cmd.ExecuteReader();
                if (dr.Read())
                {
                    txtcodigo.Text = dr["idunidade"].ToString();
                    txtnome.Text = dr["nome"].ToString();

                }
            }
        }

        private Boolean ValidaCampos()
        {


            if (this.txtnome.Text == "")
            {
                MessageBox.Show("Informe a Unidade de Medida!");
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


        private void BtnSair_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void txtnome_KeyPress(object sender, KeyPressEventArgs e)
        {
            if ((Keys)e.KeyChar == Keys.Enter)
            {
                this.BtnSalvar.Focus();
            }
        }

        private void BtnNovo_Click(object sender, EventArgs e)
        {
            Limpacampos();
        }

        private void BtnSalvar_Click(object sender, EventArgs e)
        {


            if (ValidaCampos() == true)
            {
                VlUnidadeMedida obj = new VlUnidadeMedida();

                if (txtcodigo.Text != "")
                {
                    obj.idunidade = Convert.ToInt32(txtcodigo.Text);
                }
                obj.nome = this.txtnome.Text.ToUpper();
                obj.idusu = Banco.idusu;



                try
                {
                    if (VerificaRegistroExiste(txtcodigo.Text) == true)
                    {

                        PsUnidadeMedida DAOUnidade = new PsUnidadeMedida();
                        DAOUnidade.Incluir(obj);
                        MessageBox.Show("Registro Incluido com Sucesso!");
                        Limpacampos();
                    }
                    else
                    {

                        PsUnidadeMedida DAOUnidade = new PsUnidadeMedida();
                        DAOUnidade.Alterar(obj);
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
            string obter = ("Select * From UnidadeMedida Where idunidade = '" + txtcodigo.Text + "'");
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
            VlUnidadeMedida obj = new VlUnidadeMedida();
            obj.idunidade = Convert.ToInt32(txtcodigo.Text);

            try
            {
                PsUnidadeMedida DAOUnidade = new PsUnidadeMedida();
                DAOUnidade.Exluir(obj.idunidade);
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
            ConsUnidaddeMedida frmconv = new ConsUnidaddeMedida();
            this.Close();
            frmconv.Show();
        }
    }
}
