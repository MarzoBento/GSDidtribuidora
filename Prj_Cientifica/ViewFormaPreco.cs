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
    public partial class ViewFormaPreco : Form
    {

        public string nlicitacao;
        public int coditemlic;
        public string nomeprod;
        public decimal precocompra;


        public ViewFormaPreco()
        {
            InitializeComponent();
        }


        public ViewFormaPreco(ViewFormacaoPreco frm) : this()
        {
            nlicitacao = Convert.ToString(frm.nlicitacao);
            coditemlic = Convert.ToInt32(frm.coditemlic);
            nomeprod = frm.nomeprod;
            precocompra = frm.precocompra;
            carregarGridformapreco(nlicitacao, coditemlic);
           // RetReg();


        }


        private void carregarGridformapreco(string nlic, int cod)
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
                string strConn = "Select DISTINCT PrecoVenda.idpreco as Cod,PrecoVenda.precocompra as PrecoCompra,PrecoVenda.desconto as Desconto,PrecoVenda.repasse as Repasse, PrecoVenda.fretecompra as FreteCompra,PrecoVenda.ipi as Ipi, " +
                    "PrecoVenda.retencao as Retencao,PrecoVenda.icmscompra as IcmsCompra, PrecoVenda.custocompra as CustoCompra, PrecoVenda.icmsvenda as IcmsVenda, PrecoVenda.pis as Pis, PrecoVenda.confins as Confins,PrecoVenda.impostorenda as ImpostoRenda," +
                     "PrecoVenda.contribuicaosocial as ContribuicaoSocial,PrecoVenda.cpmf as Cpmf, PrecoVenda.custofixo as CustoFixo, PrecoVenda.comissao as Comissao, PrecoVenda.fretevenda as FreteVenda, PrecoVenda.lucro as Lucro,PrecoVenda.precovenda as PreçoVenda" +
                " from PrecoVenda,ItemsLicitacao Where PrecoVenda.iditemedital = ItemsLicitacao.iditemedital AND PrecoVenda.nlicitacao='" + nlicitacao + "' AND PrecoVenda.iditemedital=" + coditemlic + "";


                SqlDataAdapter da = new SqlDataAdapter(strConn, Conn);
                da.Fill(ds);


            }

           // this.griditens.RowsDefaultCellStyle.BackColor = Color.LightBlue;
           // this.griditens.AlternatingRowsDefaultCellStyle.BackColor = Color.Azure;


           // griditens.AutoGenerateColumns = false;
           // //exibe os dados no datagridview
           // griditens.DataSource = ds;
           // griditens.Columns.Clear();

           // griditens.Columns.Add("Cod", "Cod");
           // griditens.Columns.Add("PrecoCompra", "PrecoCompra");
           // griditens.Columns.Add("Desconto", "Desconto");
           // griditens.Columns.Add("Repasse", "Repasse");
           // griditens.Columns.Add("FreteCompra", "FreteCompra");
           // griditens.Columns.Add("Ipi", "Ipi");
           // griditens.Columns.Add("Retencao", "Retencao");
           // griditens.Columns.Add("IcmsCompra", "IcmsCompra");
           // griditens.Columns.Add("CustoCompra", "CustoCompra");
           // griditens.Columns.Add("IcmsVenda", "IcmsVenda");
           // griditens.Columns.Add("Pis", "Pis");
           // griditens.Columns.Add("Confins", "Confins");
           // griditens.Columns.Add("ImpostoRenda", "ImpostoRenda");
           // griditens.Columns.Add("ContribuicaoSocial", "ContribuicaoSocial");
           // griditens.Columns.Add("Cpmf", "Cpmf");
           // griditens.Columns.Add("CustoFixo", "CustoFixo");
           // griditens.Columns.Add("Comissao", "Comissao");
           // griditens.Columns.Add("FreteVenda", "FreteVenda");
           // griditens.Columns.Add("Lucro", "Lucro");
           // griditens.Columns.Add("PreçoVenda", "PreçoVenda");



           // griditens.Columns[0].Width = 50;
           // griditens.Columns[1].Width = 80;
           // griditens.Columns[2].Width = 80;
           // griditens.Columns[3].Width = 80;
           // griditens.Columns[4].Width = 80;
           // griditens.Columns[5].Width = 80;
           // griditens.Columns[6].Width = 80;
           // griditens.Columns[7].Width = 80;
           // griditens.Columns[8].Width = 80;
           // griditens.Columns[9].Width = 80;
           // griditens.Columns[10].Width = 80;
           // griditens.Columns[11].Width = 80;
           // griditens.Columns[12].Width = 80;
           // griditens.Columns[13].Width = 80;
           // griditens.Columns[14].Width = 80;
           // griditens.Columns[15].Width = 80;
           // griditens.Columns[16].Width = 80;
           // griditens.Columns[17].Width = 80;
           // griditens.Columns[18].Width = 80;
           // griditens.Columns[19].Width = 80;
           //// griditens.Columns[20].Width = 80;


           // //griditens.Columns[1].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
           //// griditens.Columns[2].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;

           // griditens.Columns[0].DataPropertyName = "Cod";
           // griditens.Columns[1].DataPropertyName = "PrecoCompra";
           // griditens.Columns[2].DataPropertyName = "Desconto";
           // griditens.Columns[3].DataPropertyName = "Repasse";
           // griditens.Columns[4].DataPropertyName = "FreteCompra";
           // griditens.Columns[5].DataPropertyName = "Ipi";
           // griditens.Columns[6].DataPropertyName = "Retencao";
           // griditens.Columns[7].DataPropertyName = "IcmsCompra";
           // griditens.Columns[8].DataPropertyName = "Custo_Compra";
           // griditens.Columns[9].DataPropertyName = "IcmsVenda";
           // griditens.Columns[10].DataPropertyName = "Pis";
           // griditens.Columns[11].DataPropertyName = "Confins";
           // griditens.Columns[12].DataPropertyName = "ImpostoRenda";
           // griditens.Columns[13].DataPropertyName = "ContribuicaoSocial";
           // griditens.Columns[14].DataPropertyName = "Cpmf";
           // griditens.Columns[15].DataPropertyName = "CustoFixo";
           // griditens.Columns[16].DataPropertyName = "Comissao";
           // griditens.Columns[17].DataPropertyName = "FreteVenda";
           // griditens.Columns[18].DataPropertyName = "Lucro";
           // griditens.Columns[19].DataPropertyName = "PreçoVenda";
         


           // griditens.Columns[1].DefaultCellStyle.Format = "#.00\\%";





           // //valor = 0;

           // //foreach (DataGridViewRow linha in griditens.Rows)
           // //{
           // //    if ((linha.Cells[12].Value != DBNull.Value))
           // //    {

           // //        valor += Convert.ToDecimal(linha.Cells[12].Value);
           // //    }

           // //}


           // //Decimal valort = valor;
           // //string convertido = String.Format("{0:N2}", Math.Round(valort, 2));
           // //labTotal.Text = convertido;


           // griditens.Refresh();


        }

        private void ViewFormaPreco_Load(object sender, EventArgs e)
        {
            lablnomeprod.Text = nomeprod;

           decimal pcompra = Convert.ToDecimal(precocompra);
            this.txttotalcompra.Text = String.Format("{0:N4}", Math.Round(pcompra, 4));

            casasDecimais(Convert.ToDecimal(txttotalcompra.Text));


        }

        public int casasDecimais(decimal d)
        {
            int res = 0;
            while (d != (long)d)
            {
                res++;
                d = d * 10;
            }
            return res;
        }

        private void BtnSair_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
