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
    public partial class ViewDescItens : Form
    {
        public static string TipoGravacao;
        public static string UltimoSelecionado;

        public ViewDescItens()
        {
            InitializeComponent();
        }


        public ViewDescItens(ViewLancamentoEditais frm) : this()
        {
            txtcodigo.Text = Convert.ToString(frm.codigoitem);
            txtlote.Text = Convert.ToString(frm.codigolote);
            txtnritem.Text = Convert.ToString(frm.codigonitem);
            RetReg();


        }

        private void RetReg()
        {
            string reg = "Select * from ItemsLicitacao  Where iditemedital =" + txtcodigo.Text + "";
            DataTable ds = new DataTable();
            SqlConnection Conn = Banco.CriarConexao();
            Conn.Open();

            if (Conn.State == ConnectionState.Open)
            {
                SqlCommand cmd = new SqlCommand(reg, Conn);
                SqlDataReader dr = cmd.ExecuteReader();
                if (dr.Read())
                {
                    txtdescricao.Text = dr["descitem"].ToString();

                    if (dr["statusdesc"].ToString() != "")
                    {

                        if (Convert.ToInt32(dr["statusdesc"].ToString()) == 1)
                        {
                            RbtAdicionar.Checked = true;
                        }
                        else if (Convert.ToInt32(dr["statusdesc"].ToString()) == 2)
                        {
                            RbtSubstituir.Checked = true;
                        }
                    }
                  
                }
            }
        }

        private void Cancelar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private Boolean ValidaCampos()
        {
            if (this.txtcodigo.Text == "")
            {
                MessageBox.Show("Informe o Código");
                txtcodigo.Focus();
                return false;

            }

            if (this.txtcodigo.Text == "")
            {
                MessageBox.Show("informe o Código");
                txtcodigo.Focus();
                return false;

            }
            if (this.txtdescricao.Text == "")
            {
                MessageBox.Show("informe a Descrição!");
                txtdescricao.Focus();
                return false;

            }


            return true;
        }


            private void Salvar_Click(object sender, EventArgs e)
        {
            if (ValidaCampos() == true)
            {
                VlDescItens obj = new VlDescItens();

                if (txtcodigo.Text != "")
                {
                    obj.iditemedital = Convert.ToInt32(txtcodigo.Text);
                }
                obj.descitem = txtdescricao.Text.ToUpper();
               
              
                if (RbtAdicionar.Checked == true)
                {
                    obj.statusdesc = 1;
                }
                else if (RbtSubstituir.Checked == true)
                {
                    obj.statusdesc = 2;
                }
               

                try
                {
                  

                        PsDescItens DAODescItem = new PsDescItens();
                        DAODescItem.Alterar(obj);
                       // MessageBox.Show("Registro Alterada com Sucesso!");
                        //Limpacampos();
                       RetReg();

                    
                }
                catch (Exception erro)
                {

                    throw erro;
                }
            }
        }
    }
}
