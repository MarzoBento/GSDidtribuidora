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
    public partial class ViewMenorPrecoItems : Form
    {
        public ViewMenorPrecoItems()
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
                string strConn = "select DISTINCT Produto.nome as Produto,PrincipioAtivo.nome as PrincipioAtivo, Marca.nome as Marca,Min(RealinhamentoProposta.vlvenda) as Menor_Preço, Max(RealinhamentoProposta.dtrealinhamento) as Data,  " +
                    "(Cliente.nome + ' - ' + LancEditais.nlicitacao) as Cliente FROM  Produto,Marca,PrincipioAtivo,RealinhamentoProposta,Cliente,LancEditais,Proposta WHERE  LancEditais.nlicitacao = Proposta.edital AND  Proposta.idproposta = RealinhamentoProposta.idproposta AND " +
                "  RealinhamentoProposta.idproduto = Produto.idproduto AND RealinhamentoProposta.idmarca = Marca.idmarca AND Cliente.idcliente = LancEditais.idcliente AND   " +
                "  PrincipioAtivo.idprincipio=Produto.idprincipio AND Produto.nome Like'%" + txtpesquisa.Text + "%'  GROUP BY  Produto.nome,PrincipioAtivo.nome,Marca.nome,Cliente.nome, LancEditais.nlicitacao ";



                SqlDataAdapter da = new SqlDataAdapter(strConn, Conn);
                da.Fill(ds);


            }

            this.griditens.RowsDefaultCellStyle.BackColor = Color.LightBlue;
            this.griditens.AlternatingRowsDefaultCellStyle.BackColor = Color.Azure;

            griditens.DataSource = ds;
            griditens.Columns.Clear();
            griditens.Columns.Add("Produto", "Produto");
            griditens.Columns.Add("PrincipioAtivo", "PrincipioAtivo");
            griditens.Columns.Add("Marca", "Marca");
            griditens.Columns.Add("Menor_Preço", "Menor_Preço");
            griditens.Columns.Add("Data", "Data");
            griditens.Columns.Add("Cliente", "Cliente");

            griditens.Columns[0].Width = 330;
            griditens.Columns[1].Width = 275;
            griditens.Columns[2].Width = 200;
            griditens.Columns[3].Width = 100;
            griditens.Columns[4].Width = 75;
            griditens.Columns[5].Width = 297;

            griditens.Columns[0].DataPropertyName = "Produto";
            griditens.Columns[1].DataPropertyName = "PrincipioAtivo";
            griditens.Columns[2].DataPropertyName = "Marca";
            griditens.Columns[3].DataPropertyName = "Menor_Preço";
            griditens.Columns[4].DataPropertyName = "Data";
            griditens.Columns[5].DataPropertyName = "Cliente";

            griditens.Columns[3].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            griditens.Columns[3].DefaultCellStyle.Format = "c";

            griditens.Refresh();




        }

        private void txtpesquisa_TextChanged(object sender, EventArgs e)
        {
            carregarGridItens();
        }

        private void BtnSair_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void BtnLimpar_Click(object sender, EventArgs e)
        {
            griditens.DataSource = null;
            txtpesquisa.Text = "";
            txtpesquisa.Focus();
        }

        private void griditens_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
    }
}
