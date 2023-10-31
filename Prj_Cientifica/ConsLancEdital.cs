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
    public partial class ConsLancEdital : Form
    {
        string strConn;
        public int codedital;
        public ConsLancEdital()
        {
            InitializeComponent();
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


            if (Conn.State == ConnectionState.Open)
            {

                if (this.chkempresa.Checked == true)
                {

                    strConn = "Select idedital as NrEdital, nlicitacao as Edital, nome as Cliente,nprocesso as NºProcesso" +
                " from Cliente,LancEditais Where Cliente.idcliente = LancEditais.idcliente and  Cliente.nome  Like'%" + txtpesquisa.Text + "%' Order by Cliente.nome";
                }
                else if (chkProcesso.Checked == true)
                {

                    strConn = "Select idedital as NrEdital, nlicitacao as Edital, nome as Cliente,nprocesso as NºProcesso" +
               " from Cliente,LancEditais Where Cliente.idcliente = LancEditais.idcliente and  LancEditais.idedital Like'%" + txtpesquisa.Text + "%' Order by  Cliente.nome";


                }



                SqlDataAdapter da = new SqlDataAdapter(strConn, Conn);
                da.Fill(ds);


            }

            this.DtGConsulta.RowsDefaultCellStyle.BackColor = Color.LightBlue;
            this.DtGConsulta.AlternatingRowsDefaultCellStyle.BackColor = Color.Azure;



            DtGConsulta.AutoGenerateColumns = false;
            //exibe os dados no datagridview
            DtGConsulta.DataSource = ds;
            DtGConsulta.Columns.Clear();
            DtGConsulta.Columns.Add("NrEdital", "NrEdital");
            DtGConsulta.Columns.Add("Edital", "Edital");
            DtGConsulta.Columns.Add("Cliente", "Cliente");
            DtGConsulta.Columns.Add("NºProcesso", "NºProcesso");
            DtGConsulta.Columns[0].Width = 80;
            DtGConsulta.Columns[1].Width = 110;
            DtGConsulta.Columns[2].Width = 430;
            DtGConsulta.Columns[3].Width = 110;
            DtGConsulta.Columns[0].DataPropertyName = "NrEdital";
            DtGConsulta.Columns[1].DataPropertyName = "Edital";
            DtGConsulta.Columns[2].DataPropertyName = "Cliente";
            DtGConsulta.Columns[3].DataPropertyName = "NºProcesso";
            DtGConsulta.Refresh();

        }

        private void DtGConsulta_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            codedital = Convert.ToInt32(DtGConsulta[0, e.RowIndex].Value.ToString());
            ViewLancamentoEditais frcont = new ViewLancamentoEditais(this);
            frcont.Show();
            this.Close();
        }

        private void BtnLimpar_Click(object sender, EventArgs e)
        {
            txtpesquisa.Text = "";
            DtGConsulta.DataSource = null;
            chkempresa.Checked = true;
            chkProcesso.Checked = false;
            DtGConsulta.Refresh();
        }

        private void BtnSair_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void txtpesquisa_TextChanged(object sender, EventArgs e)
        {
            carregarGrid();
        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }

        private void ConsLancEdital_Load(object sender, EventArgs e)
        {
            this.chkProcesso.Checked = true;
        }

        private void chkempresa_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void chkProcesso_CheckedChanged(object sender, EventArgs e)
        {

        }
    }
}
