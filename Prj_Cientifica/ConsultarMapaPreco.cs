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
    public partial class MapaPreço : Form
    {
        public MapaPreço()
        {
            InitializeComponent();
        }


        private void carregarGridItens()
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
                string strConn = "Select DISTINCT Concorrente.idconcorrente as Cod, Concorrente.nome as Concorrente, Cliente.nome as Cliente,sum(MapaPreco.precoganho * MapaPreco.qtde) as Valor_Produtos_Ganhos,LancEditais.idedital " +
                " FROM MapaPreco, Concorrente,Cliente,LancEditais WHERE LancEditais.idedital =  MapaPreco.idedital AND LancEditais.idcliente = Cliente.idcliente AND " +
                "MapaPreco.idconcorrente = Concorrente.idconcorrente AND MapaPreco.idedital like '%" + txtpesquisa.Text + "' GROUP BY  Concorrente.idconcorrente , Concorrente.nome, Cliente.nome,LancEditais.idedital";



                SqlDataAdapter da = new SqlDataAdapter(strConn, Conn);
                da.Fill(ds);


            }

            this.griditens.RowsDefaultCellStyle.BackColor = Color.LightBlue;
            this.griditens.AlternatingRowsDefaultCellStyle.BackColor = Color.Azure;


            griditens.AutoGenerateColumns = false;
            //exibe os dados no datagridview
            griditens.DataSource = ds;
            griditens.Columns.Clear();
            griditens.Columns.Add("Cod", "Cod");
            griditens.Columns.Add("Concorrente", "Concorrente");
            griditens.Columns.Add("Cliente", "Cliente");
            griditens.Columns.Add("Valor_Produtos_Ganhos", "Valor_Produtos_Ganhos");
            griditens.Columns.Add("idedital", "idedital");
            

            griditens.Columns[0].Width = 50;
            griditens.Columns[1].Width = 400;
            griditens.Columns[2].Width = 405;
            griditens.Columns[3].Width = 176;
            griditens.Columns[4].Visible =  false;

            griditens.Columns[3].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;


            griditens.Columns[0].DataPropertyName = "Cod";
            griditens.Columns[1].DataPropertyName = "Concorrente";
            griditens.Columns[2].DataPropertyName = "Cliente";
            griditens.Columns[3].DataPropertyName = "Valor_Produtos_Ganhos";
            griditens.Columns[4].DataPropertyName = "idedital";

            griditens.Columns[3].DefaultCellStyle.Format = "n2";

            griditens.Refresh();


        }

        private void txtpesquisa_TextChanged(object sender, EventArgs e)
        {
            carregarGridItens();
        }

        private void BtnImprimir_Click(object sender, EventArgs e)
        {

        }
        public int codedital;
        private void griditens_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            codedital = Convert.ToInt32(griditens[4, e.RowIndex].Value.ToString());
            RelMapa compras = new RelMapa(this);
            compras.Show();
            this.Close();
        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }

        private void BtnLimpar_Click(object sender, EventArgs e)
        {

        }

        private void BtnSair_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
