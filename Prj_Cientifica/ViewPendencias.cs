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
    public partial class ViewPendencias : Form
    {
        public string editalrel;
        public string nomeFor = "ViewPendencias";
        public static string UltimoSelecionado;
        public int idedital;

        public ViewPendencias()
        {
            InitializeComponent();
        }

        public ViewPendencias(ConsGerarCotacao frm) : this()
        {
            idedital = frm.idedital;
            UltimoSelecionado = Convert.ToString(frm.codedital);
            RetronarCarregarLicitacao(UltimoSelecionado);
            RetornaCliente();
           


        }

        private void btnPesquisar_Click(object sender, EventArgs e)
        {
            ConsGerarCotacao frmconv = new ConsGerarCotacao(this);
            this.Close();
            frmconv.Show();
        }

        private void RetornaCliente()
        {
            SqlConnection Cnn = Banco.CriarConexao();
            SqlDataAdapter sql = new SqlDataAdapter("Select * from LancEditais,Cliente " +
                " WHERE LancEditais.idcliente = Cliente.idcliente And LancEditais.nlicitacao='" + cbolicitacao.SelectedValue + "'", Cnn);
            DataSet Dt = new DataSet();
            sql.Fill(Dt);
            BindingSource bs = new BindingSource();
            bs.DataSource = Dt;
            bs.DataMember = Dt.Tables[0].TableName;

            try
            {
                this.cbocliente.DataSource = bs;
                this.cbocliente.DisplayMember = "nome";
                this.cbocliente.ValueMember = "idcliente";
                //this.cbocliente.SelectedIndex = cbolicitacao.Items.Count - 1;



            }
            catch (Exception erro)
            {

                throw erro;
            }
            Cnn.Close();

            CarregaGridNumeroEmpenho();

        }

        private void RetronarCarregarLicitacao(string edital)
        {
            SqlConnection Cnn = Banco.CriarConexao();
            SqlDataAdapter sql = new SqlDataAdapter("Select LancEditais.nlicitacao,(CAST(LancEditais.nlicitacao AS VARCHAR(10))) + '               ' + (Modalidade.nome + '                    ' +  LancEditais.nlicitacao + '                        ' + " +
                "LancEditais.nprocesso + '                       ' + CONVERT(CHAR,LancEditais.dtabertura,103)) as Licitacao  from LancEditais,Modalidade " +
                " WHERE LancEditais.idmodalidade = Modalidade.idmodalidade and LancEditais.nlicitacao='" + edital + "'", Cnn);
            DataSet Dt = new DataSet();
            sql.Fill(Dt);
            BindingSource bs = new BindingSource();
            bs.DataSource = Dt;
            bs.DataMember = Dt.Tables[0].TableName;

            try
            {
                this.cbolicitacao.DataSource = bs;
                this.cbolicitacao.DisplayMember = "Licitacao";
                this.cbolicitacao.ValueMember = "nlicitacao";
                this.cbolicitacao.SelectedIndex = cbolicitacao.Items.Count - 1;



            }
            catch (Exception erro)
            {

                throw erro;
            }
            Cnn.Close();
        }
        public double valor;
        private void CarregaGridNumeroEmpenho()
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





                string strConn = "select DISTINCT RealinhamentoProposta.iditemedital as itemedital, Produto.nome as Descrição,Marca.nome as Marca,EmpenhoItems.item as Item,EmpenhoItems.lote as Lote," +
                                "EmpenhoItems.empenho as Empenho,RealinhamentoProposta.vlvenda as Preço, EmpenhoItems.qtde as Qdte_Empenho,EmpenhoItems.total as Total," +
                                "(RealinhamentoProposta.Qtde) as Qtd_Edital,EmpenhoItems.idempenhoitems,RealinhamentoProposta.vladitivo as Aditivo,Marca.idmarca, EmpenhoItems.idempenho," +
                                 "(RealinhamentoProposta.Qtde) - (Select  Sum(EmpenhoItems.qtde) From EmpenhoItems LEFT JOIN Empenho ON Empenho.idempenho = EmpenhoItems.idempenho where RealinhamentoProposta.iditemedital = EmpenhoItems.iditemedital AND  EmpenhoItems.edital =  '" + cbolicitacao.SelectedValue + "')  as Pendente, " +
                                "EmpenhoItems.vladitivo as Aditivo,(Select sum(Entrega.qtde) from Entrega LEFT JOIN  Empenho ON Entrega.idempenho = Empenho.idempenho WHERE EmpenhoItems.iditemedital = Entrega.iditemedital AND Empenho.edital = '" + cbolicitacao.SelectedValue + "') as Entregues," +
                                "Produto.idproduto,PrincipioAtivo.idprincipio,(RealinhamentoProposta.Qtde) as Qtde_Edital " +
                                "From EmpenhoItems INNER JOIN Empenho ON EmpenhoItems.idempenho = Empenho.idempenho INNER JOIN  RealinhamentoProposta ON EmpenhoItems.idrealinhamento = RealinhamentoProposta.idrealinhamento " +
                                 "INNER JOIN Entrega ON  EmpenhoItems.idempenho = Entrega.idempenho,PrincipioAtivo,Produto,Marca  WHERE " +
                                  "Produto.idprincipio = PrincipioAtivo.idprincipio AND RealinhamentoProposta.idmarca = Marca.idmarca AND EmpenhoItems.idprincipio = PrincipioAtivo.idprincipio AND " +
                                 "  Produto.idproduto = EmpenhoItems.idproduto  AND EmpenhoItems.edital = '" + cbolicitacao.SelectedValue + "'";




                SqlDataAdapter da = new SqlDataAdapter(strConn, Conn);
                da.Fill(ds);


            }

            this.griditens.RowsDefaultCellStyle.BackColor = Color.LightBlue;
            this.griditens.AlternatingRowsDefaultCellStyle.BackColor = Color.Azure;

            var column = new DataGridViewComboBoxColumn();

            griditens.AutoGenerateColumns = false;
            //exibe os dados no datagridview
            griditens.DataSource = ds;
            griditens.Columns.Clear();
            griditens.Columns.Add("itemedital", "itemedital");
            griditens.Columns.Add("Descrição", "Descrição");
            griditens.Columns.Add("Marca", "Marca");
            griditens.Columns.Add("Item", "Item");
            griditens.Columns.Add("Lote", "Lote");
            griditens.Columns.Add("Preço", "Preço");
            griditens.Columns.Add("Qdte_Empenho", "Qdte_Empenho");
            griditens.Columns.Add("Total", "Total");
            griditens.Columns.Add("Pendente", "Pendente");
            griditens.Columns.Add("Aditivo", "Aditivo");
            griditens.Columns.Add("Qtd_Edital", "Qtd_Edital");
            griditens.Columns.Add("Entregues", "Entregues");
            
           

            griditens.Columns[0].Visible = false;
            griditens.Columns[1].Width = 325;
            griditens.Columns[2].Width = 170;
            griditens.Columns[3].Width = 50;
            griditens.Columns[4].Width = 75;
            griditens.Columns[5].Width = 95;
            griditens.Columns[6].Width = 95;
            griditens.Columns[7].Width = 70;
            griditens.Columns[8].Width = 70;
            griditens.Columns[9].Width = 70;
            griditens.Columns[10].Width = 73;
            griditens.Columns[11].Width = 90;

            griditens.Columns[3].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            griditens.Columns[3].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
            griditens.Columns[6].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            griditens.Columns[6].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
            griditens.Columns[7].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleRight;
            griditens.Columns[7].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            griditens.Columns[8].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            griditens.Columns[8].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
            griditens.Columns[9].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            griditens.Columns[9].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
            griditens.Columns[4].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
            griditens.Columns[4].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            griditens.Columns[5].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
            griditens.Columns[5].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            griditens.Columns[5].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
            griditens.Columns[9].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            griditens.Columns[9].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
            griditens.Columns[10].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            griditens.Columns[10].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
            griditens.Columns[11].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            griditens.Columns[11].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
          


            griditens.Columns[0].DataPropertyName = "itemedital";
            griditens.Columns[1].DataPropertyName = "Descrição";
            griditens.Columns[2].DataPropertyName = "Marca";
            griditens.Columns[3].DataPropertyName = "Item";
            griditens.Columns[4].DataPropertyName = "Lote";
            griditens.Columns[5].DataPropertyName = "Preço";
            griditens.Columns[6].DataPropertyName = "Qdte_Empenho";
            griditens.Columns[7].DataPropertyName = "Total";
            griditens.Columns[8].DataPropertyName = "Pendente";
            griditens.Columns[9].DataPropertyName = "Aditivo";
            griditens.Columns[10].DataPropertyName = "Qtd_Edital";
            griditens.Columns[11].DataPropertyName = "Entregues";
            


            griditens.Columns[7].ReadOnly = true;
            griditens.Columns[3].ReadOnly = true;
            griditens.Columns[4].ReadOnly = true;
            griditens.Columns[5].ReadOnly = true;
            griditens.Columns[9].ReadOnly = true;
            griditens.Columns[10].ReadOnly = true;
            griditens.Columns[8].ReadOnly = true;
            griditens.Columns[11].ReadOnly = true;




            valor = 0;

            foreach (DataGridViewRow linha in griditens.Rows)
            {
                if ((linha.Cells[7].Value != DBNull.Value))
                {

                    valor += Convert.ToDouble(linha.Cells[7].Value);
                }

            }


            double valort = valor;
            string convertido = String.Format("{0:N2}", Math.Round(valort, 4));
            labTotal.Text = convertido;


            griditens.Refresh();


        }

        private void btnSair_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void BtnImprimirProposta_Click(object sender, EventArgs e)
        {

            editalrel = Convert.ToString(cbolicitacao.SelectedValue);
           
            RelPendenciaPorEdital pendencias = new RelPendenciaPorEdital(this);
            pendencias.Show();
        }
    }
}
