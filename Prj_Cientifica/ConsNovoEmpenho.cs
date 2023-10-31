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
    public partial class ConsNovoEmpenho : Form
    {
        public ConsNovoEmpenho()
        {
            InitializeComponent();
        }


        public string Edital;
        public int idedital;

        private void carregarGridEmpresas()
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
                string strConn = "Select Empenho.idempenho as Codigo, Empenho.nempenho as NºEmpenho,LancEditais.nlicitacao as Edital,Cliente.nome as Cliente,LancEditais.idedital as NrEdital " +
                " FROM LancEditais LEFT JOIN Empenho  ON  LancEditais.idedital =  Empenho.idedital  LEFT JOIN  Cliente ON  LancEditais.idcliente = Cliente.idcliente  Where LancEditais.idedital Like'" + txtpesquisa.Text + "%' Order by Cliente.nome";
                SqlDataAdapter da = new SqlDataAdapter(strConn, Conn);
                da.Fill(ds);


            }

            this.DtGConsulta.RowsDefaultCellStyle.BackColor = Color.LightBlue;
            this.DtGConsulta.AlternatingRowsDefaultCellStyle.BackColor = Color.Azure;



            DtGConsulta.AutoGenerateColumns = false;
            //exibe os dados no datagridview
            DtGConsulta.DataSource = ds;
            DtGConsulta.Columns.Clear();
            DtGConsulta.Columns.Add("Codigo", "Codigo");
            DtGConsulta.Columns.Add("NºEmpenho", "NºEmpenho");
            DtGConsulta.Columns.Add("Edital", "Edital");
            DtGConsulta.Columns.Add("Cliente", "Cliente");
            DtGConsulta.Columns.Add("NrEdital", "NrEdital");
            DtGConsulta.Columns[0].Visible = false;
            DtGConsulta.Columns[1].Visible =  false;
            DtGConsulta.Columns[2].Width = 140;
            DtGConsulta.Columns[3].Width = 703;
            DtGConsulta.Columns[4].Width = 60;

            DtGConsulta.Columns[0].DataPropertyName = "Codigo";
            DtGConsulta.Columns[1].DataPropertyName = "NºEmpenho";
            DtGConsulta.Columns[2].DataPropertyName = "Edital";
            DtGConsulta.Columns[3].DataPropertyName = "Cliente";
            DtGConsulta.Columns[4].DataPropertyName = "NrEdital";

            DtGConsulta.Refresh();

        }

        private void txtpesquisa_TextChanged(object sender, EventArgs e)
        {
            carregarGridEmpresas();
        }

        private void DtGConsulta_CellClick(object sender, DataGridViewCellEventArgs e)
        {

            Edital = Convert.ToString(DtGConsulta[2, e.RowIndex].Value.ToString());
            idedital = Convert.ToInt32(DtGConsulta[4, e.RowIndex].Value.ToString());

            ViewEmpenho frm = new ViewEmpenho(this);
            frm.Show();
            this.Close();


        }

        private void BtnSair_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void ConsNovoEmpenho_Load(object sender, EventArgs e)
        {
            chkedital.Checked = true;
        }
    }



}
