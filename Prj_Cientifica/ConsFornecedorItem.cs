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
    public partial class ConsFornecedorItem : Form
    {

        public static int codfor ;
        public static string codedital;
       
        public ConsFornecedorItem()
        {
            InitializeComponent();
        }

        public ConsFornecedorItem(ViewGerarCotacao frm) : this()
        {
           // codfor = Convert.ToInt32(frm.codfor);
            codedital = Convert.ToString(frm.codedital);

            carregarGridItens();


        }



        DataGridViewCheckBoxColumn chkb = new DataGridViewCheckBoxColumn();

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
                string strConn = "Select DISTINCT Produto.idproduto as Cod,ItemsLicitacao.nritem as NºItem,PrincipioAtivo.nome as PrincipioAtivo, UnidadeMedida.nome as Unidade" +
                " from ItemsLicitacao,UnidadeMedida,PrincipioAtivo,Produto,Fornecedor,LancEditais Where LancEditais.nprocesso = ItemsLicitacao.processo AND " +
                " Produto.idprincipio = PrincipioAtivo.idprincipio AND ItemsLicitacao.idprincipio = PrincipioAtivo.idprincipio AND ItemsLicitacao.idunidade = UnidadeMedida.idunidade AND " +
                "Produto.idproduto = ItemsLicitacao.idproduto  AND Fornecedor.idfornecedor = ItemsLicitacao.idfornecedor AND ItemsLicitacao.nlicitacao='" + codedital + "'";


                SqlDataAdapter da = new SqlDataAdapter(strConn, Conn);
                da.Fill(ds);


            }

            this.griditens.RowsDefaultCellStyle.BackColor = Color.LightBlue;
            this.griditens.AlternatingRowsDefaultCellStyle.BackColor = Color.Azure;


            griditens.AutoGenerateColumns = false;
            //exibe os dados no datagridview
            griditens.DataSource = ds;
            griditens.Columns.Clear();
            griditens.Columns.Add(chkb);
            chkb.HeaderText = "Sel";
            chkb.Name = "chkb";
            griditens.Columns.Add("Cod", "Cod");
            griditens.Columns.Add("NºItem", "NºItem");
            griditens.Columns.Add("PrincipioAtivo", "PrincipioAtivo");
            griditens.Columns.Add("Unidade", "Unidade");

            griditens.Columns[0].Width = 50;
            griditens.Columns[1].Width = 50;
            griditens.Columns[2].Width = 80;
            griditens.Columns[3].Width = 450;
            griditens.Columns[4].Width = 280;
           
            griditens.Columns[1].DataPropertyName = "Cod";
            griditens.Columns[2].DataPropertyName = "NºItem";
            griditens.Columns[3].DataPropertyName = "PrincipioAtivo";
            griditens.Columns[4].DataPropertyName = "Unidade";


            griditens.Refresh();


        }

        DataGridViewCheckBoxColumn chk = new DataGridViewCheckBoxColumn();
        private void carregarGriFornecedores(int codproduto)
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
                string strConn = "Select DISTINCT Fornecedor.idfornecedor as Cod,Fornecedor.nome as Fornecedor,Fornecedor.razao as Nome_Comercial,Produto.apresentacao as Apresentacao" +
                " from ItemsLicitacao,Fornecedor,Produto,LancEditais Where ItemsLicitacao.idprincipio = Produto.idprincipio" +
                " AND ItemsLicitacao.idfornecedor = Fornecedor.idfornecedor AND LancEditais.nprocesso = ItemsLicitacao.processo AND Produto.idproduto=" + codproduto + "  Order by Fornecedor.nome ASC";

                SqlDataAdapter da = new SqlDataAdapter(strConn, Conn);
                da.Fill(ds);


            }

            this.GridFor.RowsDefaultCellStyle.BackColor = Color.LightBlue;
            this.GridFor.AlternatingRowsDefaultCellStyle.BackColor = Color.Azure;


            GridFor.AutoGenerateColumns = false;
            //exibe os dados no datagridview
            GridFor.DataSource = ds;
            GridFor.Columns.Clear();
            GridFor.Columns.Add("Cod", "Cod");
            GridFor.Columns.Add("Fornecedor", "Fornecedor");
            GridFor.Columns.Add("Nome_Comercial", "Nome_Comercial");
            GridFor.Columns.Add("Apresentacao", "Apresentacao");

            GridFor.Columns[0].Width = 40;
            GridFor.Columns[1].Width = 315;
            GridFor.Columns[2].Width = 315;
            GridFor.Columns[3].Width = 240;


            GridFor.Columns[0].DataPropertyName = "Cod";
            GridFor.Columns[1].DataPropertyName = "Fornecedor";
            GridFor.Columns[2].DataPropertyName = "Nome_Comercial";
            GridFor.Columns[3].DataPropertyName = "Apresentacao";

            GridFor.Refresh();


          
        }
        int codprod;
        private void griditens_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0 && e.ColumnIndex == 0)
            {
                //Loop and uncheck all other CheckBoxes.
                foreach (DataGridViewRow row in griditens.Rows)
                {
                    if (row.Index == e.RowIndex)
                    {
                        row.Cells["chkb"].Value = !Convert.ToBoolean(row.Cells["chkb"].EditedFormattedValue);
                        codprod = int.Parse(griditens.Rows[e.RowIndex].Cells[1].Value.ToString());
                        carregarGriFornecedores(codprod);
                    }
                    else
                    {
                        row.Cells["chkb"].Value = false;
                    }
                }
            }
        }
    }
}
