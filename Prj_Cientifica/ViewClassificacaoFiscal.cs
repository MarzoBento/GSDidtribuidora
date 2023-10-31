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
    public partial class ViewClassificacaoFiscal : Form
    {
        public static string TipoGravacao;
        public static string UltimoSelecionado;

        public ViewClassificacaoFiscal()
        {
            InitializeComponent();
        }

        public ViewClassificacaoFiscal(ConsClassificacaoFiscal frm) : this()
        {
            UltimoSelecionado = Convert.ToString(frm.codfiscal);
            RetReg();


        }

        private void RetReg()
        {
            string reg = "Select * from ClassificacaoFiscal ";
            if (UltimoSelecionado != "")
                reg += "Where idclassificacaofiscal = " + UltimoSelecionado;
            else reg += " Where idclassificacaofiscal = (Select Max(idclassificacaofiscal) from ClassificacaoFiscal)";
            DataTable ds = new DataTable();
            SqlConnection Conn = Banco.CriarConexao();
            Conn.Open();

            if (Conn.State == ConnectionState.Open)
            {
                SqlCommand cmd = new SqlCommand(reg, Conn);
                SqlDataReader dr = cmd.ExecuteReader();
                if (dr.Read())
                {
                    txtcodigo.Text = dr["idclassificacaofiscal"].ToString();
                    txtnome.Text = dr["nome"].ToString();

                }
            }
        }

        private Boolean ValidaCampos()
        {


            if (this.txtnome.Text == "")
            {
                MessageBox.Show("Informe o Nome da Classificação Fiscal");
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
                VlClassificacaoFiscal obj = new VlClassificacaoFiscal();

                if (txtcodigo.Text != "")
                {
                    obj.idclassificacaofiscal = Convert.ToInt32(txtcodigo.Text);
                }
                obj.nome = this.txtnome.Text.ToUpper();
                obj.idusu = Banco.idusu;



                try
                {
                    if (VerificaRegistroExiste(txtcodigo.Text) == true)
                    {

                        PsClassificacaoFiscal DAOFiscal = new PsClassificacaoFiscal();
                        DAOFiscal.Incluir(obj);
                        MessageBox.Show("Registro Incluido com Sucesso!");
                        Limpacampos();
                    }
                    else
                    {


                        PsClassificacaoFiscal DAOFiscal = new PsClassificacaoFiscal();
                        DAOFiscal.Alterar(obj);
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
            string obter = ("Select * From ClassificacaoFiscal Where idclassificacaofiscal = '" + txtcodigo.Text + "'");
            SqlCommand sql = new SqlCommand(obter, Cnn);
            Cnn.Open();
            SqlDataReader dr = sql.ExecuteReader();
            if (dr.Read())
            {

                return false;
            }
            return true;
        }

        private void btnPesquisar_Click(object sender, EventArgs e)
        {
            ConsClassificacaoFiscal frmconv = new ConsClassificacaoFiscal();
            this.Close();
            frmconv.Show();
        }

        private void BtnRemover_Click(object sender, EventArgs e)
        {
            VlClassificacaoFiscal obj = new VlClassificacaoFiscal();
            obj.idclassificacaofiscal = Convert.ToInt32(txtcodigo.Text);

            try
            {
                PsClassificacaoFiscal DAOFiscal = new PsClassificacaoFiscal();
                DAOFiscal.Exluir(obj.idclassificacaofiscal);
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
    }
}
