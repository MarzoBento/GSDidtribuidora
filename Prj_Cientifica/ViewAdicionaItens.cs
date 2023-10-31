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
    public partial class ViewAdicionaItens : Form
    {
        public string edital;
        public string processo;
        public int cliente;
        public int codprincipio;
        public int codproduto;
        public int codunidade;
        public int codfabricante;
        public int codmarca;
        public int idedital;
        public int idfornecedor;

        public ViewAdicionaItens()
        {
            InitializeComponent();
        }

        public ViewAdicionaItens(ViewLancamentoEditais frm) : this()
        {
            edital = Convert.ToString(frm.edital);
            processo = Convert.ToString(frm.processo);
            cliente = Convert.ToInt32(frm.cliente);
            idedital = Convert.ToInt32(frm.idedital);


        }

        private void BtnSair_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        string strConn;
        DataGridViewCheckBoxColumn chkb = new DataGridViewCheckBoxColumn();
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
                if (this.chkProduto.Checked == true)
                {

                    strConn = "Select DISTINCT Produto.idproduto as codproduto,PrincipioAtivo.idprincipio as codprincipio,UnidadeMedida.idunidade as codunidade,Fabricante.idfabricante as codfabricante,  " +
                    "Marca.idmarca as codmarca,PrincipioAtivo.nome as PrincipioAtivo, Produto.nome as Produto,UnidadeMedida.nome as Unidade,Fabricante.nome as Fabricante,Marca.nome as Marca, Produto.apresentacao as Apresentação" +
                " From Produto,PrincipioAtivo,UnidadeMedida,Fabricante,Marca WHERE  Produto.idprincipio = PrincipioAtivo.idprincipio AND Produto.idunidade = UnidadeMedida.idunidade AND " +
                "Produto.idfabricante = Fabricante.idfabricante AND Produto.idmarca = Marca.idmarca  AND Produto.statusprod= 'ATIVO' AND Produto.nome Like'%" + txtpesquisa.Text + "%' Order by PrincipioAtivo.nome asc";
                }
                else if (chkprincipio.Checked == true)
                {
                    strConn = "Select DISTINCT Produto.idproduto as codproduto,PrincipioAtivo.idprincipio as codprincipio,UnidadeMedida.idunidade as codunidade,Fabricante.idfabricante as codfabricante,  " +
                    "Marca.idmarca as codmarca,PrincipioAtivo.nome as PrincipioAtivo, Produto.nome as Produto,UnidadeMedida.nome as Unidade,Fabricante.nome as Fabricante,Marca.nome as Marca, Produto.apresentacao as Apresentação" +
                " From Produto,PrincipioAtivo,UnidadeMedida,Fabricante,Marca WHERE Produto.idprincipio = PrincipioAtivo.idprincipio AND Produto.idunidade = UnidadeMedida.idunidade AND " +
                "Produto.idfabricante = Fabricante.idfabricante AND Produto.idmarca = Marca.idmarca  AND Produto.statusprod= 'ATIVO' AND  PrincipioAtivo.nome   Like'%" + txtpesquisa.Text + "%' Order by Produto.nome asc";


                }
                else if (this.rbtcodigo.Checked == true)
                {
                    strConn = "Select DISTINCT Produto.idproduto as codproduto,PrincipioAtivo.idprincipio as codprincipio,UnidadeMedida.idunidade as codunidade,Fabricante.idfabricante as codfabricante,  " +
                    "Marca.idmarca as codmarca,PrincipioAtivo.nome as PrincipioAtivo, Produto.nome as Produto,UnidadeMedida.nome as Unidade,Fabricante.nome as Fabricante,Marca.nome as Marca, Produto.apresentacao as Apresentação" +
                " From Produto,PrincipioAtivo,UnidadeMedida,Fabricante,Marca WHERE Produto.idprincipio = PrincipioAtivo.idprincipio AND Produto.idunidade = UnidadeMedida.idunidade AND " +
                "Produto.idfabricante = Fabricante.idfabricante AND Produto.idmarca = Marca.idmarca  AND Produto.statusprod= 'ATIVO' AND  Produto.idproduto =" + txtpesquisa.Text + " Order by Produto.nome asc";


                }

                else if (this.chkmarca.Checked == true)
                {
                    strConn = "Select DISTINCT Produto.idproduto as codproduto,PrincipioAtivo.idprincipio as codprincipio,UnidadeMedida.idunidade as codunidade,Fabricante.idfabricante as codfabricante,  " +
                     "Marca.idmarca as codmarca,PrincipioAtivo.nome as PrincipioAtivo, Produto.nome as Produto,UnidadeMedida.nome as Unidade,Fabricante.nome as Fabricante,Marca.nome as Marca, Produto.apresentacao as Apresentação" +
                 " From Produto,PrincipioAtivo,UnidadeMedida,Fabricante,Marca WHERE Produto.idprincipio = PrincipioAtivo.idprincipio AND Produto.idunidade = UnidadeMedida.idunidade AND " +
                 "Produto.idfabricante = Fabricante.idfabricante AND Produto.idmarca = Marca.idmarca AND Produto.statusprod= 'ATIVO' AND Marca.nome  Like'%" + txtpesquisa.Text + "%'  Order by Marca.nome asc";


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
            DtGConsulta.Columns.Add(chkb);
            chkb.HeaderText = "Sel";
            chkb.Name = "chkb";
            DtGConsulta.Columns.Add("codproduto", "codproduto");
            DtGConsulta.Columns.Add("codprincipio", "codprincipio");
            DtGConsulta.Columns.Add("codunidade", "codunidade");
            DtGConsulta.Columns.Add("codfabricante", "codfabricante");
            DtGConsulta.Columns.Add("codmarca", "codmarca");
            DtGConsulta.Columns.Add("PrincipioAtivo", "PrincipioAtivo");
            DtGConsulta.Columns.Add("Produto", "Produto");
            DtGConsulta.Columns.Add("Apresentação", "Apresentação");
            DtGConsulta.Columns.Add("Unidade", "Unidade");
            DtGConsulta.Columns.Add("Fabricante", "Fabricante");
            DtGConsulta.Columns.Add("Marca", "Marca");

            DtGConsulta.Columns[0].Width = 50;
            DtGConsulta.Columns[1].Visible = false;
            DtGConsulta.Columns[2].Visible = false;
            DtGConsulta.Columns[3].Visible = false;
            DtGConsulta.Columns[4].Visible = false;
            DtGConsulta.Columns[5].Visible = false;
            DtGConsulta.Columns[6].Width = 400;
            DtGConsulta.Columns[7].Width = 400;
            DtGConsulta.Columns[8].Width = 400;
            DtGConsulta.Columns[9].Width = 150;
            DtGConsulta.Columns[10].Width = 225;
            DtGConsulta.Columns[11].Width = 180;



            DtGConsulta.Columns[1].DataPropertyName = "codproduto";
            DtGConsulta.Columns[2].DataPropertyName = "codprincipio";
            DtGConsulta.Columns[3].DataPropertyName = "codunidade";
            DtGConsulta.Columns[4].DataPropertyName = "codfabricante";
            DtGConsulta.Columns[5].DataPropertyName = "codmarca";
            DtGConsulta.Columns[6].DataPropertyName = "PrincipioAtivo";
            DtGConsulta.Columns[7].DataPropertyName = "Produto";
            DtGConsulta.Columns[8].DataPropertyName = "Apresentação";
            DtGConsulta.Columns[9].DataPropertyName = "Unidade";
            DtGConsulta.Columns[10].DataPropertyName = "Fabricante";
            DtGConsulta.Columns[11].DataPropertyName = "Marca";
            DtGConsulta.Refresh();


            // carregarGridItens();


        }

        private void txtpesquisa_TextChanged(object sender, EventArgs e)
        {

        }

        private void txtpesquisa_TextChanged_1(object sender, EventArgs e)
        {
            carregarGrid();
        }

        private void BtnSair_Click_1(object sender, EventArgs e)
        {
            this.Close();
        }

        private void BtnAdd_Click(object sender, EventArgs e)
        {

            //try


            //{

            //    foreach (DataGridViewRow row in DtGConsulta.Rows)
            //    {

            //        if (bool.Parse(row.Cells[0].EditedFormattedValue.ToString()))
            //        {
            //            int codp = Convert.ToInt32(row.Cells[1].Value);

            //            lote = row.Cells[2].Value.ToString();
            //            nritem = Convert.ToInt32(row.Cells[3].Value.ToString());
            //            qtde = row.Cells[5].Value.ToString();

            //            if (VerificaRegistroExisteProd(codp) == true)
            //            {

            //                GravaProduto(codp);

            //            }
            //            else
            //            {


            //                AlterarProduto(codp);


            //            }
            //        }
            //    }
            //}
            //catch (Exception erro)
            //{

            //    throw erro;
            //}




        }

        private Boolean VerificaRegistroExisteProd(int cod)
        {

            SqlConnection Cnn = Banco.CriarConexao();
            string obter = ("Select * From ItemsLicitacao Where idproduto = " + cod + "");
            SqlCommand sql = new SqlCommand(obter, Cnn);
            Cnn.Open();
            SqlDataReader dr = sql.ExecuteReader();
            if (dr.Read())
            {

                return false;
            }
            return true;
        }


        private void GravaProduto(int codprod)
        {

            string reg = "Select * from Produto where idproduto=" + codprod + "";
            DataTable ds = new DataTable();
            SqlConnection Conn = Banco.CriarConexao();
            Conn.Open();

            if (Conn.State == ConnectionState.Open)
            {
                SqlCommand cmd = new SqlCommand(reg, Conn);
                SqlDataReader dr = cmd.ExecuteReader();
                if (dr.Read())
                {
                    int codproduto = Convert.ToInt32(dr["idproduto"].ToString());
                    int codpricipio = Convert.ToInt32(dr["idprincipio"].ToString());
                    string nomeprod = dr["nome"].ToString();
                    int codunidade = Convert.ToInt32(dr["idunidade"].ToString());
                    string apresentacao = dr["apresentacao"].ToString();
                    string ststusreg = dr["statusreg"].ToString();
                    string registro = dr["registro"].ToString();
                    string dtvalidade = dr["dtvalidade"].ToString();
                    int idprocedencia = Convert.ToInt32(dr["idprocedencia"].ToString());
                    int idfabricante = Convert.ToInt32(dr["idfabricante"].ToString());
                    double vlestimado = Convert.ToDouble(dr["vlunitestimado"].ToString());
                    double vltotalestimado = Convert.ToDouble(dr["vltotaloestimado"].ToString());
                    decimal pmvg = Convert.ToDecimal(dr["pmvg"].ToString());
                    decimal convenioicms = Convert.ToDecimal(dr["convenioicms"].ToString());
                    decimal cap = Convert.ToDecimal(dr["cap"].ToString());
                    int idclassificacaofiscal = Convert.ToInt32(dr["idclassificacaofiscal"].ToString());
                    string dtcadastro = dr["dtcadastro"].ToString();
                    int idusu = Banco.idusu;
                    int idempresa = Banco.idemp;
                    string statusprod = dr["statusprod"].ToString();
                    int idmarca = Convert.ToInt32(dr["idmarca"].ToString());



                    VlItemLicitacao obj = new VlItemLicitacao();
                    obj.lote = lote;
                    obj.nritem = nritem;
                    obj.idproduto = codproduto;
                    obj.idunidade = codunidade;
                    obj.vlestimado = vlestimado; //- Convert.ToDecimal(txtcomissao.Text);
                    obj.qtde = Convert.ToInt32(qtde);
                    obj.vltotalestimado = vltotalestimado;
                    obj.dtitens = DateTime.Now.ToString("dd/MM/yyyy");
                    obj.idusu = Banco.idusu;
                    obj.descitem = "ND";
                    obj.statusdesc = Convert.ToInt32(0);
                    obj.statuscotacao = "NAO";
                    obj.idcliente = cliente;
                    obj.nlicitacao = edital;
                    obj.processo = processo;
                    obj.idfabricante = idfabricante;
                    obj.idprincipio = codpricipio;
                    obj.idmarca = idmarca;

                    try
                    {
                        PsItemLicitacao DAOitem = new PsItemLicitacao();
                        DAOitem.Incluir(obj);


                    }
                    catch (Exception erro)
                    {
                        throw erro;
                    }
                }
            }


        }

        private void AlterarProduto(int codprod)
        {

            string reg = "Select * from Produto where idproduto=" + codprod + "";
            DataTable ds = new DataTable();
            SqlConnection Conn = Banco.CriarConexao();
            Conn.Open();

            if (Conn.State == ConnectionState.Open)
            {
                SqlCommand cmd = new SqlCommand(reg, Conn);
                SqlDataReader dr = cmd.ExecuteReader();
                if (dr.Read())
                {

                    int codproduto = Convert.ToInt32(dr["idproduto"].ToString());
                    int codpricipio = Convert.ToInt32(dr["idprincipio"].ToString());
                    string nomeprod = dr["nome"].ToString();
                    int codunidade = Convert.ToInt32(dr["idunidade"].ToString());
                    string apresentacao = dr["apresentacao"].ToString();
                    string ststusreg = dr["statusreg"].ToString();
                    string registro = dr["registro"].ToString();
                    string dtvalidade = dr["dtvalidade"].ToString();
                    int idprocedencia = Convert.ToInt32(dr["idprocedencia"].ToString());
                    int idfabricante = Convert.ToInt32(dr["idfabricante"].ToString());
                    double vlestimado = Convert.ToDouble(dr["vlunitestimado"].ToString());
                    double vltotalestimado = Convert.ToDouble(dr["vltotaloestimado"].ToString());
                    decimal pmvg = Convert.ToDecimal(dr["pmvg"].ToString());
                    decimal convenioicms = Convert.ToDecimal(dr["convenioicms"].ToString());
                    decimal cap = Convert.ToDecimal(dr["cap"].ToString());
                    int idclassificacaofiscal = Convert.ToInt32(dr["idclassificacaofiscal"].ToString());
                    string dtcadastro = dr["dtcadastro"].ToString();
                    int idusu = Banco.idusu;
                    int idempresa = Banco.idemp;
                    string statusprod = dr["statusprod"].ToString();



                    VlItemLicitacao obj = new VlItemLicitacao();
                    obj.lote = lote;
                    obj.nritem = nritem;
                    obj.idproduto = codproduto;
                    obj.idunidade = codunidade;
                    obj.vlestimado = vlestimado; //- Convert.ToDecimal(txtcomissao.Text);
                    obj.qtde = Convert.ToInt32(qtde);
                    obj.vltotalestimado = vltotalestimado;
                    obj.dtitens = DateTime.Now.ToString("dd/MM/yyyy");
                    obj.idusu = Banco.idusu;
                    obj.descitem = "ND";
                    obj.statusdesc = Convert.ToInt32(0);
                    obj.statuscotacao = "NAO";
                    obj.idcliente = cliente;
                    obj.nlicitacao = edital;
                    obj.processo = processo;
                    obj.idfabricante = idfabricante;
                    obj.idprincipio = codpricipio;

                    try
                    {
                        PsItemLicitacao DAOitem = new PsItemLicitacao();
                        DAOitem.Alterar(obj);


                    }
                    catch (Exception erro)
                    {
                        throw erro;
                    }
                }
            }


        }



        private void chkTodos_CheckedChanged(object sender, EventArgs e)
        {
            foreach (DataGridViewRow row in DtGConsulta.Rows)
            {
                DataGridViewCheckBoxCell chkb = (DataGridViewCheckBoxCell)row.Cells[0];
                chkb.Value = !(chkb.Value == null ? false : (bool)chkb.Value); //because chk.Value is initialy null
            }
        }
        string qtde;
        string lote;
        int nritem;
        private void DtGConsulta_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {
            if ((e.RowIndex != -1 && e.ColumnIndex == 2))
            {

                lote = DtGConsulta.CurrentRow.Cells[2].Value.ToString();

            }
            if ((e.RowIndex != -1 && e.ColumnIndex == 3))
            {

                nritem = Convert.ToInt32(DtGConsulta.CurrentRow.Cells[3].Value.ToString());

            }

            if ((e.RowIndex != -1 && e.ColumnIndex == 5))
            {

                qtde = DtGConsulta.CurrentRow.Cells[5].Value.ToString();

            }
        }

        private void DtGConsulta_CellClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void DtGConsulta_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if ((e.RowIndex != -1 && e.ColumnIndex == 0))
            {

                if (bool.Parse(DtGConsulta.Rows[e.RowIndex].Cells[0].EditedFormattedValue.ToString()))
                {

                    codprincipio = int.Parse(DtGConsulta.Rows[e.RowIndex].Cells[2].Value.ToString());
                    codproduto = int.Parse(DtGConsulta.Rows[e.RowIndex].Cells[1].Value.ToString());
                 
                    ViewLancamentoEditais frmconv = new ViewLancamentoEditais(this);
                    this.Close();
                    frmconv.Show();


                }
            }
        }

        private void ViewAdicionaItens_Load(object sender, EventArgs e)
        {
            this.chkProduto.Checked = true;
        }
    }
}
