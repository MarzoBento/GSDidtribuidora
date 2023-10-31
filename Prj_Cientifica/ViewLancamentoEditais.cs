using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Prj_Cientifica
{
    public partial class ViewLancamentoEditais : Form
    {

        public static string TipoGravacao;
        public static int UltimoSelecionado;
        public string nomeform;
        public string edital;
        public string processo;
        public int cliente;
        public int coditemsproduto;
        public int codprincipio;
        public int codproduto;
        public int codunidade;
        public int codfabricante;
        public int codmarca;
        public int idedital;
        public int iditemedital;
        public int casas;

        public ViewLancamentoEditais()
        {
            InitializeComponent();
        }

        public ViewLancamentoEditais(ConsPrincipio frm) : this()
        {
            // UltimoSelecionado = Convert.ToString(frm.cod);

        }

        public ViewLancamentoEditais(RelInformacaoEdital frm) : this()
        {
            idedital = frm.idedital;

        }



        public void RetRegItens(int cod)
        {
            string reg = "Select * from Produto ";
            if (UltimoSelecionado != 0)
                reg += "Where idproduto = " + UltimoSelecionado;
            else reg += "Where idproduto = (Select Max(idproduto) from Produto)";
            DataTable ds = new DataTable();
            SqlConnection Conn = Banco.CriarConexao();
            Conn.Open();

            if (Conn.State == ConnectionState.Open)
            {
                SqlCommand cmd = new SqlCommand(reg, Conn);
                SqlDataReader dr = cmd.ExecuteReader();
                if (dr.Read())
                {
                    RetornaPrincipioAtivo(Convert.ToInt32(dr["idproduto"].ToString()));

                }
            }
        }


        public void RetornaItem()
        {
            string reg = "(Select Max(iditemedital) coditem from ItemsLicitacao)";
            DataTable ds = new DataTable();
            SqlConnection Conn = Banco.CriarConexao();
            Conn.Open();

            if (Conn.State == ConnectionState.Open)
            {
                SqlCommand cmd = new SqlCommand(reg, Conn);
                SqlDataReader dr = cmd.ExecuteReader();
                if (dr.Read())
                {
                    iditemedital = Convert.ToInt32(dr["coditem"].ToString());

                }
            }
        }



        public void RetRegPrincipio(int cod)
        {
            string reg = "Select * from PrincipioAtivo ";
            if (UltimoSelecionado != 0)
                reg += "Where idprincipio = " + UltimoSelecionado;
            else reg += "Where idprincipio = (Select Max(idprincipio) from PrincipioAtivo)";
            DataTable ds = new DataTable();
            SqlConnection Conn = Banco.CriarConexao();
            Conn.Open();

            if (Conn.State == ConnectionState.Open)
            {
                SqlCommand cmd = new SqlCommand(reg, Conn);
                SqlDataReader dr = cmd.ExecuteReader();
                if (dr.Read())
                {
                    RetornaPrincipioAtivo(Convert.ToInt32(dr["idprincipio"].ToString()));

                }
            }
        }
        public ViewLancamentoEditais(ConsLancEdital frm) : this()
        {
            UltimoSelecionado = Convert.ToInt32(frm.codedital);
            RetReg();


        }
        private void RetReg()
        {
            string reg = "Select * from LancEditais ";
            if (UltimoSelecionado != 0)
                reg += "Where idedital = " + UltimoSelecionado;
            else reg += "Where idedital = (Select Max(idedital) from LancEditais)";


            DataTable ds = new DataTable();
            SqlConnection Conn = Banco.CriarConexao();
            Conn.Open();

            if (Conn.State == ConnectionState.Open)
            {
                SqlCommand cmd = new SqlCommand(reg, Conn);
                SqlDataReader dr = cmd.ExecuteReader();
                if (dr.Read())
                {
                    txtcodigo.Text = dr["idedital"].ToString();
                    RetornaEmpresa(Convert.ToInt32(dr["idempresa"].ToString()));
                    cbodadosbancario.Text = dr["dadosbancario"].ToString();
                    RetornaRepresentante(Convert.ToInt32(dr["idrepresentante"].ToString()));
                    RetornaCliente(Convert.ToInt32(dr["idcliente"].ToString()));
                    cliente = Convert.ToInt32(dr["idcliente"].ToString());
                    cbotipo.Text = dr["tipocliente"].ToString();
                    RetornaModalidade(Convert.ToInt32(dr["idmodalidade"].ToString()));
                    msklimite.Text = dr["dtlimite"].ToString();
                    mskhora.Text = dr["hora"].ToString();
                    mskdtabertura.Text = dr["dtabertura"].ToString();
                    mskhoraabertura.Text = dr["horaabertura"].ToString();
                    txtobjeto.Text = dr["objeto"].ToString();
                    txtnlicitacao.Text = dr["nlicitacao"].ToString();
                    edital = dr["nlicitacao"].ToString();
                    txtnprocesso.Text = dr["nprocesso"].ToString();
                    processo = dr["nprocesso"].ToString();
                    cbotipoproposta.Text = dr["tipoproposta"].ToString();
                    RetornaRespProposta(Convert.ToInt32(dr["respproposta"].ToString()));
                    txticms.Text = dr["icms"].ToString();
                    RetornaRespDoc(Convert.ToInt32(dr["respdoc"].ToString()));
                    txtvalidadeproposta.Text = dr["vlproposta"].ToString();
                    txtprazoentrega.Text = dr["prazo"].ToString();
                    txtcondicoes.Text = dr["condpagto"].ToString();
                    txtvalidadeproduto.Text = dr["vlprodutos"].ToString();
                    txtvigenciacontrato.Text = dr["vigcontratoata"].ToString();
                    txtncontrato.Text = dr["ncontratratoata"].ToString();
                    mskdtata.Text = dr["dtata"].ToString();
                    txtportal.Text = dr["portal"].ToString();


                    if (Convert.ToInt32(dr["statuslicitacao"].ToString()) == 1)
                    {
                        rbtsomenteedital.Checked = true;
                        rbtsomenteedital.BackColor = Color.Green;
                    }
                    else if (Convert.ToInt32(dr["statuslicitacao"].ToString()) == 2)
                    {
                        rbtliberadocotacao.Checked = true;
                        rbtliberadocotacao.BackColor = Color.Green;
                    }
                    else if (Convert.ToInt32(dr["statuslicitacao"].ToString()) == 3)
                    {
                        this.rbtcotacaolancada.Checked = true;
                        rbtcotacaolancada.BackColor = Color.Green;
                    }
                    else if (Convert.ToInt32(dr["statuslicitacao"].ToString()) == 4)
                    {
                        this.rbtretcotacao.Checked = true;
                        rbtretcotacao.BackColor = Color.Green;
                    }
                    else if (Convert.ToInt32(dr["statuslicitacao"].ToString()) == 5)
                    {
                        this.rbtlibparaproposta.Checked = true;
                        rbtlibparaproposta.BackColor = Color.Green;
                    }
                    else if (Convert.ToInt32(dr["statuslicitacao"].ToString()) == 6)
                    {
                        this.rbtpropostalancada.Checked = true;
                        rbtpropostalancada.BackColor = Color.Green;
                    }
                    else if (Convert.ToInt32(dr["statuslicitacao"].ToString()) == 7)
                    {
                        this.rbtlibmapadeprecos.Checked = true;
                        rbtlibmapadeprecos.BackColor = Color.Green;
                    }
                    else if (Convert.ToInt32(dr["statuslicitacao"].ToString()) == 8)
                    {
                        this.rbtmapaprecolancado.Checked = true;
                        rbtmapaprecolancado.BackColor = Color.Green;
                    }
                    else if (Convert.ToInt32(dr["statuslicitacao"].ToString()) == 9)
                    {
                        this.rbtempenho.Checked = true;
                        rbtempenho.BackColor = Color.Green;
                    }
                    else if (Convert.ToInt32(dr["statuslicitacao"].ToString()) == 10)
                    {
                        this.rbteditalfinalizado.Checked = true;
                        rbteditalfinalizado.BackColor = Color.Green;
                    }
                    else if (Convert.ToInt32(dr["statuslicitacao"].ToString()) == 11)
                    {
                        this.rbteditalnaoganho.Checked = true;
                        rbteditalnaoganho.BackColor = Color.Red;
                    }
                    else if (Convert.ToInt32(dr["statuslicitacao"].ToString()) == 12)
                    {
                        this.rbteditalcancelado.Checked = true;
                        rbteditalcancelado.BackColor = Color.Red;
                    }
                    if (Convert.ToInt32(dr["casasdecimais"].ToString()) == 2)
                    {
                        casas = 2;
                        this.rbt2casas.Checked = true;

                    }
                    else if (Convert.ToInt32(dr["casasdecimais"].ToString()) == 3)
                    {
                        casas = 3;
                        this.rbt3casas.Checked = true;

                    }
                    else if (Convert.ToInt32(dr["casasdecimais"].ToString()) == 4)
                    {
                        casas = 4;
                        this.rbt4casas.Checked = true;

                    }
                    else if (Convert.ToInt32(dr["casasdecimais"].ToString()) == 5)
                    {
                        casas = 5;
                        this.rbt5casas.Checked = true;

                    }
                    else if (Convert.ToInt32(dr["casasdecimais"].ToString()) == 6)
                    {
                        casas = 6;
                        this.rbt6casas.Checked = true;

                    }

                    CarregaGrid();
                    CarregaGridFor();
                    CarregaGridPropostaEmp();
                    CarregaGridPropostaFor();
                    carregarGridItens();


                }
            }
        }
        private void Limpacampos()
        {
            txtcodigo.Text = "";
            cboempresa.SelectedIndex = -1;
            this.cbodadosbancario.SelectedIndex = -1;
            cborepresentate.SelectedIndex = -1;
            cbocliente.SelectedIndex = -1;
            cbotipo.SelectedIndex = -1;
            cbomodalidade.SelectedIndex = -1;
            cboitens.SelectedIndex = -1;
            cbofabricante.SelectedIndex = -1;
            msklimite.Text = "";
            mskhora.Text = "";
            mskdtabertura.Text = "";
            mskhoraabertura.Text = "";
            txtobjeto.Text = "";
            txtnlicitacao.Text = "";
            txtnprocesso.Text = "";
            cbotipoproposta.SelectedIndex = 1;
            cboresponsavel.SelectedIndex = -1;
            cborespdoc.SelectedIndex = -1;
            txticms.Text = "0,00";
            txtvalidadeproduto.Text = "";
            txtvalidadeproposta.Text = "";
            txtprazoentrega.Text = "";
            txtcondicoes.Text = "";
            txtvalidadeproduto.Text = "";
            txtvigenciacontrato.Text = "";
            txtncontrato.Text = "";
            mskdtata.Text = "";
            cbodadosbancario.Text = "";
            cbotipoproposta.SelectedIndex = -1;
            txtvlestimado.Text = "0,00";
            txtvlestimadototal.Text = "0,00";
            txtportal.Text = "";
            UltimoSelecionado = 0;
            cboempresa.Focus();


        }

        private Boolean ValidaCampos()
        {
            if (this.cboempresa.Text == "")
            {
                MessageBox.Show("Informe a Empresa");
                cboempresa.Focus();
                return false;

            }

            if (this.cbodadosbancario.Text == "")
            {
                MessageBox.Show("informe os dados Bancários");
                cbodadosbancario.Focus();
                return false;

            }
            if (this.cborepresentate.Text == "")
            {
                MessageBox.Show("informe o representante!");
                cborepresentate.Focus();
                return false;

            }

            if (this.cbocliente.Text == "")
            {
                MessageBox.Show("informe o Cliente!");
                cbocliente.Focus();
                return false;

            }

            if (this.cbotipo.Text == "")
            {
                MessageBox.Show("informe o tipo do Cliente!");
                cbotipo.Focus();
                return false;

            }

            if (this.cbomodalidade.Text == "")
            {
                MessageBox.Show("informe a Modalidade!");
                cbomodalidade.Focus();
                return false;

            }
            DateTime value;
            if (DateTime.TryParse(this.msklimite.Text, out value))
            {


            }
            else
            {
                MessageBox.Show("Data Limite Inválida!");
                msklimite.Focus();
                return false;

            }

            if (this.mskhora.Text == "  :")
            {
                MessageBox.Show("infomr a Hora!");
                mskhora.Focus();
                return false;

            }
            DateTime value2;
            if (DateTime.TryParse(this.mskdtabertura.Text, out value2))
            {


            }
            else
            {
                MessageBox.Show("Data de Abertura Inválida!");
                mskdtabertura.Focus();
                return false;

            }

            if (this.mskhoraabertura.Text == "  :")
            {
                MessageBox.Show("informe a Hora de Abertura");
                mskhoraabertura.Focus();
                return false;

            }

            if (this.txtobjeto.Text == "")
            {
                MessageBox.Show("informe o Objeto");
                txtobjeto.Focus();
                return false;

            }

            if (this.txtnlicitacao.Text == "")
            {
                MessageBox.Show("informe o Número da Licitação");
                txtnlicitacao.Focus();
                return false;

            }

            //if (this.txtnprocesso.Text == "")
            //{
            //    MessageBox.Show("informe o Número do Processo");
            //    txtnprocesso.Focus();
            //    return false;

            //}
            if (this.cbotipoproposta.Text == "")
            {
                MessageBox.Show("informe o Tipo da Proposta");
                cbotipoproposta.Focus();
                return false;

            }

            if (this.cboresponsavel.Text == "")
            {
                MessageBox.Show("informe o Reponsável pela Proposta");
                cboresponsavel.Focus();
                return false;

            }

            //if (this.txticms.Text == "0,00")
            //{
            //    MessageBox.Show("informe o ICMS");
            //    txticms.Focus();
            //    return false;

            //}
            if (this.cborespdoc.Text == "")
            {
                MessageBox.Show("informe Responsável pela Documentação");
                cborespdoc.Focus();
                return false;

            }

            if (this.rbt2casas.Checked == false && this.rbt3casas.Checked == false && this.rbt4casas.Checked == false && this.rbt5casas.Checked == false && this.rbt6casas.Checked == false)
            {
                MessageBox.Show("informe Qual a Casa Decimal !");
                txtncontrato.Focus();
                return false;

            }
            //if (this.txtprazoentrega.Text == "")
            //{
            //    MessageBox.Show("informe o Prazo da Entrega");
            //    txtprazoentrega.Focus();
            //    return false;

            //}

            //if (this.txtcondicoes.Text == "")
            //{
            //    MessageBox.Show("informe as Condições de Pagamentos");
            //    txtcondicoes.Focus();
            //    return false;

            //}

            //if (this.txtvalidadeproduto.Text == "")
            //{
            //    MessageBox.Show("informe a Validade dos Produtos");
            //    txtvalidadeproduto.Focus();
            //    return false;

            //}
            //if (this.txtvigenciacontrato.Text == "")
            //{
            //    MessageBox.Show("informe a Vigência do Contrato/Ata");
            //    txtvigenciacontrato.Focus();
            //    return false;

            //}
            //if (this.txtncontrato.Text == "")
            //{
            //    MessageBox.Show("informe o Nº Contrato/Ata");
            //    txtncontrato.Focus();
            //    return false;

            //}
            //DateTime value3;
            //if (DateTime.TryParse(this.mskdtata.Text, out value3))
            //{



            //}
            //else
            //{

            //    MessageBox.Show("Data da Ata Inválida!");
            //    mskdtata.Focus();
            //    return false;

            //}





            return true;


        }

        private void CarregarEmpresa()
        {
            SqlConnection Cnn = Banco.CriarConexao();
            SqlDataAdapter sql = new SqlDataAdapter("Select * from EmpresaLicitacao ", Cnn);
            DataSet Dt = new DataSet();
            sql.Fill(Dt, "EmpresaLicitacao");
            DataRow dr = Dt.Tables["EmpresaLicitacao"].NewRow();
            dr[1] = "";
            Dt.Tables["EmpresaLicitacao"].Rows.Add(dr);
            try
            {

                this.cboempresa.DisplayMember = "nome";
                this.cboempresa.ValueMember = "idempresa";
                this.cboempresa.DataSource = Dt.Tables["EmpresaLicitacao"];
                this.cboempresa.SelectedIndex = cboempresa.Items.Count - 1;



            }
            catch (Exception erro)
            {

                throw erro;
            }
            Cnn.Close();
        }
        private void RetornaEmpresa(Int32 retemp)
        {
            SqlConnection Cnn = Banco.CriarConexao();
            SqlDataAdapter sql = new SqlDataAdapter("Select * from EmpresaLicitacao WHERE idempresa=" + retemp + "", Cnn);
            DataTable Dt = new DataTable();
            sql.Fill(Dt);
            try
            {
                this.cboempresa.DataSource = Dt;
                this.cboempresa.DisplayMember = "nome";
                this.cboempresa.ValueMember = "idempresa";
                this.cboempresa.Refresh();




            }
            catch (Exception erro)
            {

                throw erro;
            }
            Cnn.Close();
        }
        private void CarregarDocEmpresa()
        {
            SqlConnection Cnn = Banco.CriarConexao();
            SqlDataAdapter sql = new SqlDataAdapter("Select * from EmpresaLicitacao ", Cnn);
            DataSet Dt = new DataSet();
            sql.Fill(Dt, "EmpresaLicitacao");
            DataRow dr = Dt.Tables["EmpresaLicitacao"].NewRow();
            dr[1] = "";
            Dt.Tables["EmpresaLicitacao"].Rows.Add(dr);
            try
            {

                this.cboDocEmpresa.DisplayMember = "nome";
                this.cboDocEmpresa.ValueMember = "idempresa";
                this.cboDocEmpresa.DataSource = Dt.Tables["EmpresaLicitacao"];
                this.cboDocEmpresa.SelectedIndex = cboDocEmpresa.Items.Count - 1;



            }
            catch (Exception erro)
            {

                throw erro;
            }
            Cnn.Close();
        }
        private void RetornaDocEmpresa(Int32 retemp)
        {
            SqlConnection Cnn = Banco.CriarConexao();
            SqlDataAdapter sql = new SqlDataAdapter("Select * from EmpresaLicitacao WHERE idempresa=" + retemp + "", Cnn);
            DataTable Dt = new DataTable();
            sql.Fill(Dt);
            try
            {
                this.cboDocEmpresa.DataSource = Dt;
                this.cboDocEmpresa.DisplayMember = "nome";
                this.cboDocEmpresa.ValueMember = "idempresa";
                this.cboDocEmpresa.Refresh();




            }
            catch (Exception erro)
            {

                throw erro;
            }
            Cnn.Close();
        }

        private void CarregarRepresentante()
        {
            SqlConnection Cnn = Banco.CriarConexao();
            SqlDataAdapter sql = new SqlDataAdapter("Select * from Representante order by nomerep asc ", Cnn);
            DataSet Dt = new DataSet();
            sql.Fill(Dt, "Representante");
            DataRow dr = Dt.Tables["Representante"].NewRow();
            dr[1] = "";
            Dt.Tables["Representante"].Rows.Add(dr);
            try
            {

                this.cborepresentate.DisplayMember = "nomerep";
                this.cborepresentate.ValueMember = "idrepresentante";
                this.cborepresentate.DataSource = Dt.Tables["Representante"];
                //  this.cborepresentate.SelectedIndex = cborepresentate.Items.Count - 1;



            }
            catch (Exception erro)
            {

                throw erro;
            }
            Cnn.Close();
        }
        private void RetornaRepresentante(Int32 retp)
        {
            SqlConnection Cnn = Banco.CriarConexao();
            SqlDataAdapter sql = new SqlDataAdapter("Select * from Representante WHERE idrepresentante=" + retp + "", Cnn);
            DataTable Dt = new DataTable();
            sql.Fill(Dt);
            try
            {
                this.cborepresentate.DataSource = Dt;
                this.cborepresentate.DisplayMember = "nomerep";
                this.cborepresentate.ValueMember = "idrepresentante";
                this.cborepresentate.Refresh();

                //RetRazao();


            }
            catch (Exception erro)
            {

                throw erro;
            }
            Cnn.Close();
        }

        private void CarregarCliente()
        {
            SqlConnection Cnn = Banco.CriarConexao();
            SqlDataAdapter sql = new SqlDataAdapter("Select * from Cliente order by nome asc", Cnn);
            DataSet Dt = new DataSet();
            sql.Fill(Dt, "Cliente");
            DataRow dr = Dt.Tables["Cliente"].NewRow();
            dr[1] = "";
            Dt.Tables["Cliente"].Rows.Add(dr);
            try
            {

                this.cbocliente.DisplayMember = "nome";
                this.cbocliente.ValueMember = "idcliente";
                this.cbocliente.DataSource = Dt.Tables["Cliente"];
                this.cbocliente.SelectedIndex = cbocliente.Items.Count - 1;



            }
            catch (Exception erro)
            {

                throw erro;
            }
            Cnn.Close();
        }
        private void RetornaCliente(Int32 retcli)
        {
            SqlConnection Cnn = Banco.CriarConexao();
            SqlDataAdapter sql = new SqlDataAdapter("Select * from Cliente WHERE idcliente=" + retcli + "", Cnn);
            DataTable Dt = new DataTable();
            sql.Fill(Dt);
            try
            {
                this.cbocliente.DataSource = Dt;
                this.cbocliente.DisplayMember = "nome";
                this.cbocliente.ValueMember = "idcliente";
                this.cbocliente.Refresh();




            }
            catch (Exception erro)
            {

                throw erro;
            }
            Cnn.Close();
        }
        private void CarregarFabricante()
        {
            SqlConnection Cnn = Banco.CriarConexao();
            SqlDataAdapter sql = new SqlDataAdapter("Select * from Fabricante asc ", Cnn);
            DataSet Dt = new DataSet();
            sql.Fill(Dt, "Fabricante");
            DataRow dr = Dt.Tables["Fabricante"].NewRow();
            dr[1] = "";
            Dt.Tables["Fabricante"].Rows.Add(dr);
            try
            {

                this.cbofabricante.DisplayMember = "nome";
                this.cbofabricante.ValueMember = "idfabricante";
                this.cbofabricante.DataSource = Dt.Tables["Fabricante"];
                this.cbofabricante.SelectedIndex = cbofabricante.Items.Count - 1;



            }
            catch (Exception erro)
            {

                throw erro;
            }
            Cnn.Close();
        }
        private void RetornaFabricante(Int32 retfabri)
        {
            SqlConnection Cnn = Banco.CriarConexao();
            SqlDataAdapter sql = new SqlDataAdapter("Select Fabricante.nome as Fabricante,Fabricante.idfabricante  from Fabricante,Produto " +
                "WHERE Produto.idfabricante = Fabricante.idfabricante AND Produto.idproduto=" + retfabri + "", Cnn);
            DataTable Dt = new DataTable();
            sql.Fill(Dt);
            try
            {
                this.cbofabricante.DataSource = Dt;
                this.cbofabricante.DisplayMember = "Fabricante";
                this.cbofabricante.ValueMember = "idfabricante";
                this.cbofabricante.Refresh();




            }
            catch (Exception erro)
            {

                throw erro;
            }
            Cnn.Close();
        }

        private void CarregarModalidade()
        {
            SqlConnection Cnn = Banco.CriarConexao();
            SqlDataAdapter sql = new SqlDataAdapter("Select * from Modalidade Order by nome asc ", Cnn);
            DataSet Dt = new DataSet();
            sql.Fill(Dt, "Modalidade");
            DataRow dr = Dt.Tables["Modalidade"].NewRow();
            dr[1] = "";
            Dt.Tables["Modalidade"].Rows.Add(dr);
            try
            {

                this.cbomodalidade.DisplayMember = "nome";
                this.cbomodalidade.ValueMember = "idmodalidade";
                this.cbomodalidade.DataSource = Dt.Tables["Modalidade"];
                this.cbomodalidade.SelectedIndex = cbomodalidade.Items.Count - 1;



            }
            catch (Exception erro)
            {

                throw erro;
            }
            Cnn.Close();
        }
        private void RetornaModalidade(Int32 retmod)
        {
            SqlConnection Cnn = Banco.CriarConexao();
            SqlDataAdapter sql = new SqlDataAdapter("Select * from Modalidade WHERE idmodalidade=" + retmod + "", Cnn);
            DataTable Dt = new DataTable();
            sql.Fill(Dt);
            try
            {
                this.cbomodalidade.DataSource = Dt;
                this.cbomodalidade.DisplayMember = "nome";
                this.cbomodalidade.ValueMember = "idmodalidade";
                this.cbomodalidade.Refresh();




            }
            catch (Exception erro)
            {

                throw erro;
            }
            Cnn.Close();
        }
        private void CarregarRespProposta()
        {
            SqlConnection Cnn = Banco.CriarConexao();
            SqlDataAdapter sql = new SqlDataAdapter("Select * from Usuarios order by nome asc ", Cnn);
            DataSet Dt = new DataSet();
            sql.Fill(Dt, "Usuarios");
            DataRow dr = Dt.Tables["Usuarios"].NewRow();
            dr[1] = "";
            Dt.Tables["Usuarios"].Rows.Add(dr);
            try
            {

                this.cboresponsavel.DisplayMember = "nome";
                this.cboresponsavel.ValueMember = "idusu";
                this.cboresponsavel.DataSource = Dt.Tables["Usuarios"];
                this.cboresponsavel.SelectedIndex = cboresponsavel.Items.Count - 1;



            }
            catch (Exception erro)
            {

                throw erro;
            }
            Cnn.Close();
        }
        private void RetornaRespProposta(Int32 retusu)
        {
            SqlConnection Cnn = Banco.CriarConexao();
            SqlDataAdapter sql = new SqlDataAdapter("Select * from Usuarios WHERE idusu=" + retusu + "", Cnn);
            DataTable Dt = new DataTable();
            sql.Fill(Dt);
            try
            {
                this.cboresponsavel.DataSource = Dt;
                this.cboresponsavel.DisplayMember = "nome";
                this.cboresponsavel.ValueMember = "idusu";
                this.cboresponsavel.Refresh();




            }
            catch (Exception erro)
            {

                throw erro;
            }
            Cnn.Close();
        }

        private void CarregarRespDoc()
        {
            SqlConnection Cnn = Banco.CriarConexao();
            SqlDataAdapter sql = new SqlDataAdapter("Select * from Usuarios Order by nome asc ", Cnn);
            DataSet Dt = new DataSet();
            sql.Fill(Dt, "Usuarios");
            DataRow dr = Dt.Tables["Usuarios"].NewRow();
            dr[1] = "";
            Dt.Tables["Usuarios"].Rows.Add(dr);
            try
            {

                this.cborespdoc.DisplayMember = "nome";
                this.cborespdoc.ValueMember = "idusu";
                this.cborespdoc.DataSource = Dt.Tables["Usuarios"];
                this.cborespdoc.SelectedIndex = cborespdoc.Items.Count - 1;



            }
            catch (Exception erro)
            {

                throw erro;
            }
            Cnn.Close();
        }
        private void RetornaRespDoc(Int32 retusu)
        {
            SqlConnection Cnn = Banco.CriarConexao();
            SqlDataAdapter sql = new SqlDataAdapter("Select * from Usuarios WHERE idusu=" + retusu + "", Cnn);
            DataTable Dt = new DataTable();
            sql.Fill(Dt);
            try
            {
                this.cborespdoc.DataSource = Dt;
                this.cborespdoc.DisplayMember = "nome";
                this.cborespdoc.ValueMember = "idusu";
                this.cborespdoc.Refresh();




            }
            catch (Exception erro)
            {

                throw erro;
            }
            Cnn.Close();
        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void cboempresa_KeyPress(object sender, KeyPressEventArgs e)
        {
            if ((Keys)e.KeyChar == Keys.Enter)
            {
                this.cbodadosbancario.Focus();
            }
        }

        private void cbodadosbancario_KeyPress(object sender, KeyPressEventArgs e)
        {
            if ((Keys)e.KeyChar == Keys.Enter)
            {
                this.cbocliente.Focus();

            }
        }

        private void cborepresentate_KeyPress(object sender, KeyPressEventArgs e)
        {
            if ((Keys)e.KeyChar == Keys.Enter)
            {
                this.cbomodalidade.Focus();
            }
        }

        private void cbocliente_KeyPress(object sender, KeyPressEventArgs e)
        {
            if ((Keys)e.KeyChar == Keys.Enter)
            {
                this.cbotipo.Focus();
            }
        }

        private void cbotipo_KeyPress(object sender, KeyPressEventArgs e)
        {
            if ((Keys)e.KeyChar == Keys.Enter)
            {
                this.cborepresentate.Focus();
            }
        }

        private void cbodepartamento_KeyPress(object sender, KeyPressEventArgs e)
        {
            if ((Keys)e.KeyChar == Keys.Enter)
            {
                this.cbomodalidade.Focus();
            }
        }

        private void cbomodalidade_KeyPress(object sender, KeyPressEventArgs e)
        {
            if ((Keys)e.KeyChar == Keys.Enter)
            {
                this.txtnlicitacao.Focus();
            }
        }

        private void msklimite_KeyPress(object sender, KeyPressEventArgs e)
        {
            if ((Keys)e.KeyChar == Keys.Enter)
            {
                this.mskhora.Focus();
            }
        }

        private void mskhoraabertura_KeyPress(object sender, KeyPressEventArgs e)
        {
            if ((Keys)e.KeyChar == Keys.Enter)
            {
                txtportal.Focus();
            }
        }

        private void txtobjeto_KeyPress(object sender, KeyPressEventArgs e)
        {
            if ((Keys)e.KeyChar == Keys.Enter)
            {
                this.cbotipoproposta.Focus();
            }
        }

        private void txtnlicitacao_KeyPress(object sender, KeyPressEventArgs e)
        {
            if ((Keys)e.KeyChar == Keys.Enter)
            {
                this.txtnprocesso.Focus();
            }
        }

        private void txtnprocesso_KeyPress(object sender, KeyPressEventArgs e)
        {
            if ((Keys)e.KeyChar == Keys.Enter)
            {
                this.msklimite.Focus();
            }
        }

        private void cbotipoproposta_KeyPress(object sender, KeyPressEventArgs e)
        {
            if ((Keys)e.KeyChar == Keys.Enter)
            {
                this.cboresponsavel.Focus();
            }
        }

        private void cborespdoc_KeyPress(object sender, KeyPressEventArgs e)
        {
            if ((Keys)e.KeyChar == Keys.Enter)
            {
                this.txtvalidadeproposta.Focus();
            }
        }

        private void txtvalidadeproposta_KeyPress(object sender, KeyPressEventArgs e)
        {
            if ((Keys)e.KeyChar == Keys.Enter)
            {
                this.txtprazoentrega.Focus();
            }
        }

        private void txtprazoentrega_KeyPress(object sender, KeyPressEventArgs e)
        {
            if ((Keys)e.KeyChar == Keys.Enter)
            {
                this.txtcondicoes.Focus();
            }
        }

        private void txtcondicoes_KeyPress(object sender, KeyPressEventArgs e)
        {
            if ((Keys)e.KeyChar == Keys.Enter)
            {
                this.txtvalidadeproduto.Focus();
            }
        }

        private void txtvalidadeproduto_KeyPress(object sender, KeyPressEventArgs e)
        {
            if ((Keys)e.KeyChar == Keys.Enter)
            {
                this.txtvigenciacontrato.Focus();
            }
        }

        private void txtvigenciacontrato_KeyPress(object sender, KeyPressEventArgs e)
        {
            if ((Keys)e.KeyChar == Keys.Enter)
            {

                this.mskdtata.Focus();
            }
        }

        private void txtncontrato_KeyPress(object sender, KeyPressEventArgs e)
        {
            if ((Keys)e.KeyChar == Keys.Enter)
            {
                this.BtnSalvar.Focus();
            }
        }

        private void mskdtata_KeyPress(object sender, KeyPressEventArgs e)
        {
            if ((Keys)e.KeyChar == Keys.Enter)
            {
                this.txtncontrato.Focus();
            }
        }

        private void BtnSair_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void cboempresa_Click(object sender, EventArgs e)
        {
            CarregarEmpresa();
        }

        private void cboempresa_SelectionChangeCommitted(object sender, EventArgs e)
        {
            BuscaDadosBancarios();

        }

        private void BuscaDadosBancarios()
        {

            string query = "Select (Banco.nome + ' - ' +  ContaEmpresa.agencia + ' - ' + ContaEmpresa.conta + ' - ' + ContaEmpresa.favorecido) as DadosBancarios " +
                " From Banco, ContaEmpresa, EmpresaLicitacao Where Banco.idbanco = ContaEmpresa.idbanco and ContaEmpresa.idempresa=" + cboempresa.SelectedValue;
            SqlConnection Cnx = Banco.CriarConexao();
            Cnx.Open();
            SqlCommand cmd = new SqlCommand(query, Cnx);
            SqlDataReader dr = cmd.ExecuteReader();
            if (dr.Read())
            {

                cbodadosbancario.Text = dr["DadosBancarios"].ToString();


            }

        }

        private void cborepresentate_Click(object sender, EventArgs e)
        {
            CarregarRepresentante();
        }

        private void RetRazao()
        {
            string reg = "Select idrepresentante,razao from Representante where idrepresentante=" + cborepresentate.SelectedValue + " ";
            DataTable ds = new DataTable();
            SqlConnection Conn = Banco.CriarConexao();
            Conn.Open();

            if (Conn.State == ConnectionState.Open)
            {
                SqlCommand cmd = new SqlCommand(reg, Conn);
                SqlDataReader dr = cmd.ExecuteReader();
                if (dr.Read())
                {

                    txtrazao.Text = dr["razao"].ToString();

                }
            }


        }

        private void cbocliente_Click(object sender, EventArgs e)
        {
            CarregarCliente();
        }

        private void cbodepartamento_Click(object sender, EventArgs e)
        {
            //CarregarDepartamento();
        }

        private void cbomodalidade_Click(object sender, EventArgs e)
        {
            CarregarModalidade();
        }

        private void cboresponsavel_Click(object sender, EventArgs e)
        {
            CarregarRespProposta();
        }

        private void cborespdoc_Click(object sender, EventArgs e)
        {
            CarregarRespDoc();
        }

        private void BtnNovo_Click(object sender, EventArgs e)
        {
            Limpacampos();
            Grid.DataSource = null;
            Gridd.DataSource = null;
            GridPropEmp.DataSource = null;
            GridPropFor.DataSource = null;
            griditens.DataSource = null;

        }

        private void BtnSalvar_Click(object sender, EventArgs e)
        {
            if (ValidaCampos() == true)
            {
                VlLancEdital obj = new VlLancEdital();

                if (txtcodigo.Text != "")
                {
                    obj.idedital = Convert.ToInt32(txtcodigo.Text);
                }
                obj.idempresa = Convert.ToInt32(cboempresa.SelectedValue);
                obj.dadosbancario = cbodadosbancario.Text;
                obj.idrepresentante = Convert.ToInt32(cborepresentate.SelectedValue);
                obj.idcliente = Convert.ToInt32(cbocliente.SelectedValue);
                obj.tipocliente = this.cbotipo.Text;
                obj.idmodalidade = Convert.ToInt32(this.cbomodalidade.SelectedValue);
                obj.dtlimite = msklimite.Text;
                obj.hora = mskhora.Text;
                obj.dtabertura = mskdtabertura.Text;
                obj.horaabertura = mskhoraabertura.Text;
                obj.objeto = txtobjeto.Text.ToUpper();
                obj.nlicitacao = txtnlicitacao.Text.ToUpper();
                obj.nprocesso = txtnprocesso.Text.ToUpper();
                obj.tipoproposta = cbotipoproposta.Text;
                obj.respproposta = Convert.ToInt32(cboresponsavel.SelectedValue);
                obj.icms = Convert.ToDecimal(txticms.Text);
                obj.respdoc = Convert.ToInt32(cborespdoc.SelectedValue);
                obj.vlproposta = txtvalidadeproposta.Text.ToUpper();
                obj.prazo = txtprazoentrega.Text.ToUpper();
                obj.condpagto = txtcondicoes.Text.ToUpper();
                obj.vlprodutos = txtvalidadeproduto.Text.ToUpper();
                obj.vigcontratoata = txtvigenciacontrato.Text.ToUpper();
                obj.ncontratratoata = txtncontrato.Text.ToUpper();
                obj.dtata = mskdtata.Text;
                obj.portal = txtportal.Text.ToUpper();
                // fazer  if do status statuslicitacao
                if (rbtsomenteedital.Checked == true)
                {
                    obj.statuslicitacao = 1;
                }
                else if (rbtliberadocotacao.Checked == true)
                {
                    obj.statuslicitacao = 2;
                }
                else if (rbtcotacaolancada.Checked == true)
                {
                    obj.statuslicitacao = 3;
                }
                else if (rbtretcotacao.Checked == true)
                {
                    obj.statuslicitacao = 4;
                }
                else if (rbtlibparaproposta.Checked == true)
                {
                    obj.statuslicitacao = 5;
                }
                else if (rbtpropostalancada.Checked == true)
                {
                    obj.statuslicitacao = 6;
                }
                else if (rbtlibmapadeprecos.Checked == true)
                {
                    obj.statuslicitacao = 7;
                }
                else if (rbtmapaprecolancado.Checked == true)
                {
                    obj.statuslicitacao = 8;
                }
                else if (rbtempenho.Checked == true)
                {
                    obj.statuslicitacao = 9;
                }
                else if (rbteditalfinalizado.Checked == true)
                {
                    obj.statuslicitacao = 10;
                }
                else if (rbteditalnaoganho.Checked == true)
                {
                    obj.statuslicitacao = 11;
                }
                else if (rbteditalcancelado.Checked == true)
                {
                    obj.statuslicitacao = 12;
                }

                if (rbt2casas.Checked == true)
                {
                    casas = 2;

                    obj.casasdecinais = 2;

                }
                else if (rbt3casas.Checked == true)
                {
                    casas = 3;

                    obj.casasdecinais = 3;

                }
                else if (rbt4casas.Checked == true)
                {
                    casas = 4;

                    obj.casasdecinais = 4;

                }
                else if (rbt5casas.Checked == true)
                {
                    casas = 5;

                    obj.casasdecinais = 5;

                }
                else if (rbt6casas.Checked == true)
                {
                    casas = 6;

                    obj.casasdecinais = 6;

                }


                obj.idusu = Banco.idusu;
                obj.valorlic = Convert.ToDecimal(0);




                try
                {


                    if (VerificaRegistroExiste(txtcodigo.Text) == true)
                    {
                        obj.statuslicitacao = 1;
                        PsLancEdital DAOLancEdital = new PsLancEdital();
                        DAOLancEdital.Incluir(obj);
                        MessageBox.Show("Registro Incluido com Sucesso!");
                        rbtsomenteedital.BackColor = Color.Gainsboro;
                        rbtliberadocotacao.BackColor = Color.Gainsboro;
                        rbtcotacaolancada.BackColor = Color.Gainsboro;
                        rbtretcotacao.BackColor = Color.Gainsboro;
                        rbtlibparaproposta.BackColor = Color.Gainsboro;
                        rbtpropostalancada.BackColor = Color.Gainsboro;
                        rbtempenho.BackColor = Color.Gainsboro;
                        rbteditalfinalizado.BackColor = Color.Gainsboro;
                        rbteditalnaoganho.BackColor = Color.Gainsboro;
                        rbteditalcancelado.BackColor = Color.Gainsboro;
                        // Limpacampos();
                        RetReg();


                    }
                    else
                    {

                        PsLancEdital DAOLancEdital = new PsLancEdital();
                        DAOLancEdital.Alterar(obj);
                        MessageBox.Show("Registro Alterada com Sucesso!");
                        rbtsomenteedital.BackColor = Color.Gainsboro;
                        rbtliberadocotacao.BackColor = Color.Gainsboro;
                        rbtcotacaolancada.BackColor = Color.Gainsboro;
                        rbtretcotacao.BackColor = Color.Gainsboro;
                        rbtlibparaproposta.BackColor = Color.Gainsboro;
                        rbtpropostalancada.BackColor = Color.Gainsboro;
                        rbtempenho.BackColor = Color.Gainsboro;
                        rbteditalfinalizado.BackColor = Color.Gainsboro;
                        rbteditalnaoganho.BackColor = Color.Gainsboro;
                        rbteditalcancelado.BackColor = Color.Gainsboro;
                        //Limpacampos();
                        RetReg();

                    }

                    //else
                    //{
                    //    MessageBox.Show("O Número do Edital já Exite no Sistema!");
                    //    txtnlicitacao.Focus();

                    //}
                }

                catch (Exception erro)
                {

                    throw erro;
                }

            }
        }

        private void GravaCasasProposta()
        {



        }

        private Boolean VerificaRegistroExiste(string cod)
        {

            SqlConnection Cnn = Banco.CriarConexao();
            string obter = ("Select * From LancEditais Where idedital = '" + txtcodigo.Text + "'");
            SqlCommand sql = new SqlCommand(obter, Cnn);
            Cnn.Open();
            SqlDataReader dr = sql.ExecuteReader();
            if (dr.Read())
            {

                return false;
            }
            return true;

        }

        private Boolean VerificaEditaltroExiste(string edt)
        {

            SqlConnection Cnn = Banco.CriarConexao();
            string obter = ("Select * From LancEditais Where idedital = " + txtcodigo.Text + "");
            SqlCommand sql = new SqlCommand(obter, Cnn);
            Cnn.Open();
            SqlDataReader dr = sql.ExecuteReader();
            if (dr.Read())
            {

                return false;
            }
            return true;
        }


        private void BtnRemover_Click(object sender, EventArgs e)
        {
            VlLancEdital obj = new VlLancEdital();
            obj.idedital = Convert.ToInt32(txtcodigo.Text);

            try
            {
                PsLancEdital DAOLancEdital = new PsLancEdital();
                DAOLancEdital.Exluir(obj.idedital);
                MessageBox.Show("Registro Excluido Com Sucesso!");
                Limpacampos();




            }
            catch (Exception erro)
            {

                throw erro;
            }
        }

        private void mskhora_KeyPress(object sender, KeyPressEventArgs e)
        {
            if ((Keys)e.KeyChar == Keys.Enter)
            {
                this.mskdtabertura.Focus();
            }
        }

        private void mskdtabertura_KeyPress(object sender, KeyPressEventArgs e)
        {
            if ((Keys)e.KeyChar == Keys.Enter)
            {
                this.mskhoraabertura.Focus();
            }
        }

        private void cboresponsavel_KeyPress(object sender, KeyPressEventArgs e)
        {
            if ((Keys)e.KeyChar == Keys.Enter)
            {
                this.txticms.Focus();
            }
        }


        private void txticms_KeyPress(object sender, KeyPressEventArgs e)
        {
            if ((Keys)e.KeyChar == Keys.Enter)
            {
                this.cborespdoc.Focus();
            }
        }

        private void txticms_KeyPress_1(object sender, KeyPressEventArgs e)
        {
            if ((Keys)e.KeyChar == Keys.Enter)
            {
                this.cborespdoc.Focus();
            }
        }



        private void btnPesquisar_Click(object sender, EventArgs e)
        {
            ConsLancEdital frmconv = new ConsLancEdital();
            this.Close();
            frmconv.Show();
        }

        private void cboDocEmpresa_Click(object sender, EventArgs e)
        {
            CarregarDocEmpresa();
        }

        private void CarregarFornecedor()
        {
            SqlConnection Cnn = Banco.CriarConexao();
            SqlDataAdapter sql = new SqlDataAdapter("Select * from Fornecedor Order By nome asc ", Cnn);
            DataSet Dt = new DataSet();
            sql.Fill(Dt, "Fornecedor");
            DataRow dr = Dt.Tables["Fornecedor"].NewRow();
            dr[1] = "";
            Dt.Tables["Fornecedor"].Rows.Add(dr);
            try
            {

                this.cboDocFornecedor.DisplayMember = "razao";
                this.cboDocFornecedor.ValueMember = "idfornecedor";
                this.cboDocFornecedor.DataSource = Dt.Tables["Fornecedor"];
                this.cboDocFornecedor.SelectedIndex = cboDocFornecedor.Items.Count - 1;



            }
            catch (Exception erro)
            {

                throw erro;
            }
            Cnn.Close();
        }
        private void RetornaFornecedor(Int32 retfor)
        {
            SqlConnection Cnn = Banco.CriarConexao();
            SqlDataAdapter sql = new SqlDataAdapter("Select * from Fornecedor WHERE idfornecedor=" + retfor + "", Cnn);
            DataTable Dt = new DataTable();
            sql.Fill(Dt);
            try
            {
                this.cboDocFornecedor.DataSource = Dt;
                this.cboDocFornecedor.DisplayMember = "razao";
                this.cboDocFornecedor.ValueMember = "idfornecedor";
                this.cboDocFornecedor.Refresh();




            }
            catch (Exception erro)
            {

                throw erro;
            }
            Cnn.Close();
        }

        private void CarregarFor()
        {
            SqlConnection Cnn = Banco.CriarConexao();
            SqlDataAdapter sql = new SqlDataAdapter("Select * from Fornecedor Order By nome asc ", Cnn);
            DataSet Dt = new DataSet();
            sql.Fill(Dt, "Fornecedor");
            DataRow dr = Dt.Tables["Fornecedor"].NewRow();
            dr[1] = "";
            Dt.Tables["Fornecedor"].Rows.Add(dr);
            try
            {

                this.cbofornecedor.DisplayMember = "razao";
                this.cbofornecedor.ValueMember = "idfornecedor";
                this.cbofornecedor.DataSource = Dt.Tables["Fornecedor"];
                this.cbofornecedor.SelectedIndex = cbofornecedor.Items.Count - 1;



            }
            catch (Exception erro)
            {

                throw erro;
            }
            Cnn.Close();
        }
        private void RetornaFor(Int32 retfor)
        {
            SqlConnection Cnn = Banco.CriarConexao();
            SqlDataAdapter sql = new SqlDataAdapter("Select * from Fornecedor WHERE idfornecedor=" + retfor + "", Cnn);
            DataTable Dt = new DataTable();
            sql.Fill(Dt);
            try
            {
                this.cbofornecedor.DataSource = Dt;
                this.cbofornecedor.DisplayMember = "razao";
                this.cbofornecedor.ValueMember = "idfornecedor";
                this.cbofornecedor.Refresh();




            }
            catch (Exception erro)
            {

                throw erro;
            }
            Cnn.Close();
        }


        private void CarregaForProd()
        {
            SqlConnection Cnn = Banco.CriarConexao();
            SqlDataAdapter sql = new SqlDataAdapter("Select Fornecedor.razao, Fornecedor.idfornecedor from Fornecedor,Produto_Fornecedor WHERE Fornecedor.idfornecedor = Produto_Fornecedor.idfornecedor AND " +
                "Produto_Fornecedor.idproduto=" + Convert.ToInt32(cboprincipioativo.SelectedValue) + "", Cnn);
            DataTable Dt = new DataTable();
            sql.Fill(Dt);
            try
            {
                this.cbofornecedor.DataSource = Dt;
                this.cbofornecedor.DisplayMember = "razao";
                this.cbofornecedor.ValueMember = "idfornecedor";
                this.cbofornecedor.Refresh();




            }
            catch (Exception erro)
            {

                throw erro;
            }
            Cnn.Close();
        }


        private void RetornaForProd(Int32 retfor)
        {
            SqlConnection Cnn = Banco.CriarConexao();
            SqlDataAdapter sql = new SqlDataAdapter("Select Fornecedor.razao, Fornecedor.idfornecedor from Fornecedor,Produto_Fornecedor WHERE Fornecedor.idfornecedor = Produto_Fornecedor.idfornecedor AND " +
                "Fornecedor.idfornecedor=" + retfor + "", Cnn);
            DataTable Dt = new DataTable();
            sql.Fill(Dt);
            try
            {
                this.cbofornecedor.DataSource = Dt;
                this.cbofornecedor.DisplayMember = "razao";
                this.cbofornecedor.ValueMember = "idfornecedor";
                this.cbofornecedor.Refresh();




            }
            catch (Exception erro)
            {

                throw erro;
            }
            Cnn.Close();
        }


        private void cboDocFornecedor_Click(object sender, EventArgs e)
        {
            CarregarFornecedor();
        }


        private void CarregarTipoDocumentoEmpresa()
        {
            SqlConnection Cnn = Banco.CriarConexao();
            SqlDataAdapter sql = new SqlDataAdapter("Select * from TipoDocumento asc ", Cnn);
            DataSet Dt = new DataSet();
            sql.Fill(Dt, "TipoDocumento");
            DataRow dr = Dt.Tables["TipoDocumento"].NewRow();
            dr[1] = "";
            Dt.Tables["TipoDocumento"].Rows.Add(dr);
            try
            {

                this.cbotipodoc.DisplayMember = "nome";
                this.cbotipodoc.ValueMember = "idtipodocumento";
                this.cbotipodoc.DataSource = Dt.Tables["TipoDocumento"];
                this.cbotipodoc.SelectedIndex = cbotipodoc.Items.Count - 1;



            }
            catch (Exception erro)
            {

                throw erro;
            }
            Cnn.Close();
        }
        private void RetornaTipoDocumentoEmpresar(Int32 retdoc)
        {
            SqlConnection Cnn = Banco.CriarConexao();
            SqlDataAdapter sql = new SqlDataAdapter("Select * from TipoDocumento WHERE idtipodocumento=" + retdoc + "", Cnn);
            DataTable Dt = new DataTable();
            sql.Fill(Dt);
            try
            {
                this.cbotipodoc.DataSource = Dt;
                this.cbotipodoc.DisplayMember = "nome";
                this.cbotipodoc.ValueMember = "idtipodocumento";
                this.cbotipodoc.Refresh();




            }
            catch (Exception erro)
            {

                throw erro;
            }
            Cnn.Close();
        }

        private void CarregarTipoDocumentoFornecedor()
        {
            SqlConnection Cnn = Banco.CriarConexao();
            SqlDataAdapter sql = new SqlDataAdapter("Select * from TipoDocumento Order by nome asc ", Cnn);
            DataSet Dt = new DataSet();
            sql.Fill(Dt, "TipoDocumento");
            DataRow dr = Dt.Tables["TipoDocumento"].NewRow();
            dr[1] = "";
            Dt.Tables["TipoDocumento"].Rows.Add(dr);
            try
            {

                this.cbotipodocc.DisplayMember = "nome";
                this.cbotipodocc.ValueMember = "idtipodocumento";
                this.cbotipodocc.DataSource = Dt.Tables["TipoDocumento"];
                this.cbotipodocc.SelectedIndex = cbotipodocc.Items.Count - 1;



            }
            catch (Exception erro)
            {

                throw erro;
            }
            Cnn.Close();
        }
        private void RetornaTipoDocumentoFornecedor(Int32 retdoc)
        {
            SqlConnection Cnn = Banco.CriarConexao();
            SqlDataAdapter sql = new SqlDataAdapter("Select * from TipoDocumento WHERE idtipodocumento=" + retdoc + "", Cnn);
            DataTable Dt = new DataTable();
            sql.Fill(Dt);
            try
            {
                this.cbotipodocc.DataSource = Dt;
                this.cbotipodocc.DisplayMember = "nome";
                this.cbotipodocc.ValueMember = "idtipodocumento";
                this.cbotipodocc.Refresh();




            }
            catch (Exception erro)
            {

                throw erro;
            }
            Cnn.Close();
        }


        private void cbotipodoc_Click(object sender, EventArgs e)
        {
            CarregarTipoDocumentoEmpresa();
        }

        private void cbotipodocc_Click(object sender, EventArgs e)
        {
            CarregarTipoDocumentoFornecedor();
        }

        string arquivopdf;
        byte[] FileData;
        string nomearq;
        string extensao;
        string tiporarq;
        private void btnanexar_Click(object sender, EventArgs e)
        {
            if (ValidaCampos() == true)
            {

                try
                {
                    OpenFileDialog AbrirComo = new OpenFileDialog();
                    //DialogResult Caminho;


                    AbrirComo.Title = "Abrir Como";

                    AbrirComo.FileName = "Nome Arquivo";
                    AbrirComo.Filter = "Arquivos (*.*)|*.*";
                    AbrirComo.InitialDirectory = "D:\\";
                    if (AbrirComo.ShowDialog() == DialogResult.OK)
                        arquivopdf = AbrirComo.FileName;
                    if (arquivopdf == " ")
                    {
                        MessageBox.Show("Arquivo Invalido", "Salvar Como", MessageBoxButtons.OK);
                    }
                    else
                    {


                        txtnomearquivo.Text = arquivopdf;
                        nomearq = System.IO.Path.GetFileName(txtnomearquivo.Text);

                        string arq = nomearq;

                        extensao = System.IO.Path.GetExtension(txtnomearquivo.Text);

                        tiporarq = arq.Substring(arq.Length - 3, 3);

                        FileData = ReadFile(txtnomearquivo.Text);

                        GravarArquivo();
                    }




                }
                catch (Exception erro)
                {
                    MessageBox.Show("Erro ao carregar arquivo!" + erro.Message.ToString(), "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }

        }
        byte[] ReadFile(string sPath)
        {

            //Initialize byte array with a null value initially.

            byte[] data = null;



            //Use FileInfo object to get file size.

            FileInfo fInfo = new FileInfo(sPath);

            long numBytes = fInfo.Length;



            //Open FileStream to read file

            FileStream fStream = new FileStream(sPath, FileMode.Open, FileAccess.Read);



            //Use BinaryReader to read file stream into byte array.

            BinaryReader br = new BinaryReader(fStream);



            //When you use BinaryReader, you need to supply number of bytes to read from file.
            //In this case we want to read entire file. So supplying total number of bytes.

            data = br.ReadBytes((int)numBytes);



            //Close BinaryReader

            br.Close();



            //Close FileStream

            fStream.Close();



            return data;
        }

        private void GravarArquivo()
        {


            if (ValidaCamposDocEmp() == true)
            {


                VlHabilitacaoDocEmpresa obj = new VlHabilitacaoDocEmpresa();
                obj.idempresa = Convert.ToInt32(cboDocEmpresa.SelectedValue);
                obj.idedital = Convert.ToInt32(txtcodigo.Text);
                obj.idtipodoc = Convert.ToInt32(cbotipodoc.SelectedValue);
                VlHabilitacaoDocEmpresa.arq = FileData;
                obj.nomearq = nomearq;
                obj.extensao = extensao;
                obj.dtarquivo = DateTime.Now.ToString("dd/MM/yyyy");
                obj.idusu = Banco.idusu;

                try
                {
                    PsHabilitacaoDocEmpresa DAODocEmp = new PsHabilitacaoDocEmpresa();
                    DAODocEmp.Incluir(obj);
                    CarregaGrid();
                    //MessageBox.Show("Registro Incluido com Sucesso!");
                    //Limpacampos();
                    //RetReg();

                }
                catch (Exception erro)
                {

                    throw erro;
                }

            }




        }



        private Boolean ValidaCamposDocEmp()
        {
            if (this.txtcodigo.Text == "")
            {
                MessageBox.Show("Informe o Código");
                txtcodigo.Focus();
                return false;

            }

            if (this.cboDocEmpresa.Text == "")
            {
                MessageBox.Show("informe a Empresa");
                cboDocEmpresa.Focus();
                return false;

            }
            if (this.cbotipodoc.Text == "")
            {
                MessageBox.Show("informe o Tipo de Documento!");
                cbotipodoc.Focus();
                return false;

            }


            return true;


        }

        private Boolean ValidaCamposDocFor()
        {
            if (this.txtcodigo.Text == "")
            {
                MessageBox.Show("Informe o Código");
                txtcodigo.Focus();
                return false;

            }

            if (this.cboDocFornecedor.Text == "")
            {
                MessageBox.Show("informe o Fornecedor");
                cboDocFornecedor.Focus();
                return false;

            }
            if (this.cbotipodocc.Text == "")
            {
                MessageBox.Show("informe o Tipo de Documento!");
                cbotipodocc.Focus();
                return false;

            }


            return true;


        }

        private Boolean ValidaCamposDocEmpProposta()
        {
            if (this.txtcodigo.Text == "")
            {
                MessageBox.Show("Informe o Código");
                txtcodigo.Focus();
                return false;

            }

            if (this.cboEmpProposta.Text == "")
            {
                MessageBox.Show("informe a Empresa");
                cboEmpProposta.Focus();
                return false;

            }
            if (this.cbotipodocprop.Text == "")
            {
                MessageBox.Show("informe o Tipo de Documento!");
                cbotipodocprop.Focus();
                return false;

            }


            return true;


        }
        private Boolean ValidaCamposDocForProposta()
        {
            if (this.txtcodigo.Text == "")
            {
                MessageBox.Show("Informe o Código");
                txtcodigo.Focus();
                return false;

            }

            if (this.cbopropfornecedor.Text == "")
            {
                MessageBox.Show("informe o Fornecedor");
                cbopropfornecedor.Focus();
                return false;

            }
            if (this.cbotipodocpropfor.Text == "")
            {
                MessageBox.Show("informe o Tipo de Documento!");
                cbotipodocpropfor.Focus();
                return false;

            }


            return true;


        }
        private void CarregaGrid()
        {


            //define o dataset

            DataTable ds = new DataTable();


            //cria uma conexÆo usando a string de conexÆo

            SqlConnection Conn = Banco.CriarConexao();



            try
            {

                //abre a conexao

                Conn.Open();

            }

            catch (System.Exception e)
            {

                throw e;

            }


            if (Conn.State == ConnectionState.Open)
            {

                //se a conexÆo estiver aberta usa uma instru‡Æo SQL para selecionar os registros da tabela clientes

                //SELECT campos FROM tabela



                SqlDataAdapter da = new SqlDataAdapter("Select DocHabilitacaoEmp.iddocempresa as Cod,TipoDocumento.nome as Tipo_Documento, DocHabilitacaoEmp.dtarquivo as DtArquivo " +
              " from TipoDocumento,DocHabilitacaoEmp,LancEditais Where DocHabilitacaoEmp.idedital = LancEditais.idedital AND DocHabilitacaoEmp.idtipodoc = TipoDocumento.idtipodocumento AND DocHabilitacaoEmp.idedital  =" + txtcodigo.Text + "  Order by DtArquivo Desc ", Conn);

                da.Fill(ds);

                this.Grid.RowsDefaultCellStyle.BackColor = Color.LightBlue;
                this.Grid.AlternatingRowsDefaultCellStyle.BackColor = Color.Azure;


                //exibe os dados no datagridview
                Grid.AutoGenerateColumns = false;
                Grid.DataSource = ds;
                Grid.Columns.Clear();
                Grid.Columns.Add("Cod", "Cod");
                Grid.Columns.Add("Tipo_Documento", "Tipo_Documento");
                Grid.Columns.Add("DtArquivo", "DtArquivo");

                Grid.Columns[0].Width = 50;
                Grid.Columns[1].Width = 280;
                Grid.Columns[2].Width = 80;

                Grid.Columns[0].DataPropertyName = "Cod";
                Grid.Columns[1].DataPropertyName = "Tipo_Documento";
                Grid.Columns[2].DataPropertyName = "DtArquivo";

                DataGridViewButtonColumn btn = new DataGridViewButtonColumn();
                Grid.Columns.Add(btn);
                btn.HeaderText = "Excluir";
                btn.Text = "Excluir";
                btn.Name = "btn";
                btn.Width = 50;
                btn.UseColumnTextForButtonValue = true;
                btn.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft;



            }

        }

        private void label26_Click(object sender, EventArgs e)
        {

        }

        private void cborespdoc_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void label24_Click(object sender, EventArgs e)
        {

        }

        private void cboresponsavel_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void label10_Click(object sender, EventArgs e)
        {

        }

        private void txticms_TextChanged(object sender, EventArgs e)
        {

        }

        int coddocemp;
        private void Grid_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex == 3)
            {
                coddocemp = Convert.ToInt32(Grid[0, e.RowIndex].Value.ToString());

                VlHabilitacaoDocEmpresa obj = new VlHabilitacaoDocEmpresa();
                obj.iddocempresa = coddocemp;

                try
                {
                    PsHabilitacaoDocEmpresa DAODocHABEmp = new PsHabilitacaoDocEmpresa();
                    DialogResult result = MessageBox.Show("Deseja Excluir este Item !", "Excluir", MessageBoxButtons.YesNo);
                    if (result == DialogResult.Yes)
                    {
                        DAODocHABEmp.Exluir(obj.iddocempresa);
                        MessageBox.Show("Registro Excluido com Sucesso!");
                        CarregaGrid();

                    }
                    else if (result == DialogResult.No)
                    {
                        return;
                    }



                }
                catch (Exception erro)
                {

                    throw erro;
                }



            }
            else
            {

                coddocemp = Convert.ToInt32(Grid[0, e.RowIndex].Value.ToString());


            }
        }
        int codarquivo;
        private void Grid_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            codarquivo = Convert.ToInt32(Grid.CurrentRow.Cells[0].Value.ToString());


            SqlConnection Cnn = Banco.CriarConexao();
            string query = "Select arq,extensao,nomearq from DocHabilitacaoEmp Where DocHabilitacaoEmp.iddocempresa = " + Convert.ToInt32(Grid[0, e.RowIndex].Value.ToString());

            SqlCommand ObjC = new SqlCommand(query, Cnn);
            Cnn.Open();
            SqlDataReader dr = ObjC.ExecuteReader();

            dr.Read();


            try
            {


                //string FileLocation = Path.GetTempPath() + dr["tipo"].ToString();
                string ext = dr["extensao"].ToString();
                string narq = dr["nomearq"].ToString();

                byte[] fileData = (byte[])dr["arq"];
                using (System.IO.FileStream fs = new System.IO.FileStream(@"C:\D\" + narq, FileMode.Create))
                {

                    {
                        fs.Write(fileData, 0, fileData.Length);
                        System.Diagnostics.Process.Start(@"C:\D\" + narq);
                        fs.Close();
                        dr.Close();
                        Cnn.Close();
                    }
                }



            }
            catch (Exception)
            {

                MessageBox.Show("Arquivo já se encontra em aberto");
            }
            Cnn.Close();

        }

        private void btnanexarr_Click(object sender, EventArgs e)
        {
            if (ValidaCamposDocFor() == true)
            {

                try
                {
                    OpenFileDialog AbrirComo = new OpenFileDialog();
                    //DialogResult Caminho;


                    AbrirComo.Title = "Abrir Como";

                    AbrirComo.FileName = "Nome Arquivo";
                    AbrirComo.Filter = "Arquivos (*.*)|*.*";
                    AbrirComo.InitialDirectory = "D:\\";
                    if (AbrirComo.ShowDialog() == DialogResult.OK)
                        arquivopdf = AbrirComo.FileName;
                    if (arquivopdf == " ")
                    {
                        MessageBox.Show("Arquivo Invalido", "Salvar Como", MessageBoxButtons.OK);
                    }
                    else
                    {


                        txtnomearquivoo.Text = arquivopdf;
                        nomearq = System.IO.Path.GetFileName(txtnomearquivoo.Text);

                        string arq = nomearq;

                        extensao = System.IO.Path.GetExtension(txtnomearquivoo.Text);

                        tiporarq = arq.Substring(arq.Length - 3, 3);

                        FileData = ReadFile(txtnomearquivoo.Text);

                        GravarArquivoFor();
                    }

                }
                catch (Exception erro)
                {
                    MessageBox.Show("Erro ao carregar arquivo!" + erro.Message.ToString(), "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }
        private void GravarArquivoFor()
        {


            if (ValidaCamposDocFor() == true)
            {


                VlHabilitacaoDocFornecedor obj = new VlHabilitacaoDocFornecedor();
                obj.idfornecedor = Convert.ToInt32(cboDocFornecedor.SelectedValue);
                obj.idedital = Convert.ToInt32(txtcodigo.Text);
                obj.idtipodoc = Convert.ToInt32(cbotipodocc.SelectedValue);
                VlHabilitacaoDocFornecedor.arq = FileData;
                obj.nomearq = nomearq;
                obj.extensao = extensao;
                obj.dtarquivo = DateTime.Now.ToString("dd/MM/yyyy");
                obj.idusu = Banco.idusu;

                try
                {
                    PsHabilitacaoDocFornecedor DAODocFor = new PsHabilitacaoDocFornecedor();
                    DAODocFor.Incluir(obj);
                    CarregaGridFor();
                    //MessageBox.Show("Registro Incluido com Sucesso!");
                    //Limpacampos();
                    //RetReg();

                }
                catch (Exception erro)
                {

                    throw erro;
                }

            }




        }
        private void CarregaGridFor()
        {


            //define o dataset

            DataTable ds = new DataTable();


            //cria uma conexÆo usando a string de conexÆo

            SqlConnection Conn = Banco.CriarConexao();



            try
            {

                //abre a conexao

                Conn.Open();

            }

            catch (System.Exception e)
            {

                throw e;

            }


            if (Conn.State == ConnectionState.Open)
            {

                //se a conexÆo estiver aberta usa uma instru‡Æo SQL para selecionar os registros da tabela clientes

                //SELECT campos FROM tabela



                SqlDataAdapter da = new SqlDataAdapter("Select DocHabilitacaoFornecedor.iddocfornecedor as Cod,TipoDocumento.nome as Tipo_Documento, DocHabilitacaoFornecedor.dtarquivo as DtArquivo " +
              " from TipoDocumento,DocHabilitacaoFornecedor,LancEditais Where DocHabilitacaoFornecedor.idedital = LancEditais.idedital AND DocHabilitacaoFornecedor.idtipodoc = TipoDocumento.idtipodocumento AND DocHabilitacaoFornecedor.idedital  =" + txtcodigo.Text + "  Order by DtArquivo Desc ", Conn);

                da.Fill(ds);

                this.Gridd.RowsDefaultCellStyle.BackColor = Color.LightBlue;
                this.Gridd.AlternatingRowsDefaultCellStyle.BackColor = Color.Azure;


                //exibe os dados no datagridview
                Gridd.AutoGenerateColumns = false;
                Gridd.DataSource = ds;
                Gridd.Columns.Clear();
                Gridd.Columns.Add("Cod", "Cod");
                Gridd.Columns.Add("Tipo_Documento", "Tipo_Documento");
                Gridd.Columns.Add("DtArquivo", "DtArquivo");

                Gridd.Columns[0].Width = 50;
                Gridd.Columns[1].Width = 280;
                Gridd.Columns[2].Width = 80;

                Gridd.Columns[0].DataPropertyName = "Cod";
                Gridd.Columns[1].DataPropertyName = "Tipo_Documento";
                Gridd.Columns[2].DataPropertyName = "DtArquivo";

                DataGridViewButtonColumn btn = new DataGridViewButtonColumn();
                Gridd.Columns.Add(btn);
                btn.HeaderText = "Excluir";
                btn.Text = "Excluir";
                btn.Name = "btn";
                btn.Width = 50;
                btn.UseColumnTextForButtonValue = true;
                btn.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft;



            }

        }
        int coddocfor;
        private void Gridd_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex == 3)
            {
                coddocfor = Convert.ToInt32(Grid[0, e.RowIndex].Value.ToString());

                VlHabilitacaoDocFornecedor obj = new VlHabilitacaoDocFornecedor();
                obj.iddocfornecedor = coddocfor;

                try
                {
                    PsHabilitacaoDocFornecedor DAODocHABFor = new PsHabilitacaoDocFornecedor();
                    DialogResult result = MessageBox.Show("Deseja Excluir este Item !", "Excluir", MessageBoxButtons.YesNo);
                    if (result == DialogResult.Yes)
                    {
                        DAODocHABFor.Exluir(obj.iddocfornecedor);
                        MessageBox.Show("Registro Excluido com Sucesso!");
                        CarregaGridFor();

                    }
                    else if (result == DialogResult.No)
                    {
                        return;
                    }



                }
                catch (Exception erro)
                {

                    throw erro;
                }



            }
            else
            {

                coddocemp = Convert.ToInt32(Grid[0, e.RowIndex].Value.ToString());


            }
        }
        int codarquivofor;
        private void Gridd_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            codarquivofor = Convert.ToInt32(Gridd.CurrentRow.Cells[0].Value.ToString());


            SqlConnection Cnn = Banco.CriarConexao();
            string query = "Select arq,extensao,nomearq from DocHabilitacaoFornecedor Where DocHabilitacaoFornecedor.iddocfornecedor = " + Convert.ToInt32(Gridd[0, e.RowIndex].Value.ToString());

            SqlCommand ObjC = new SqlCommand(query, Cnn);
            Cnn.Open();
            SqlDataReader dr = ObjC.ExecuteReader();

            dr.Read();


            try
            {


                //string FileLocation = Path.GetTempPath() + dr["tipo"].ToString();
                string ext = dr["extensao"].ToString();
                string narq = dr["nomearq"].ToString();

                byte[] fileData = (byte[])dr["arq"];
                using (System.IO.FileStream fs = new System.IO.FileStream(@"C:\D\" + narq, FileMode.Create))
                {

                    {
                        fs.Write(fileData, 0, fileData.Length);
                        System.Diagnostics.Process.Start(@"C:\D\" + narq);
                        fs.Close();
                        dr.Close();
                        Cnn.Close();
                    }
                }



            }
            catch (Exception)
            {

                MessageBox.Show("Arquivo já se encontra em aberto");
            }
            Cnn.Close();
        }

        private void cboEmpProposta_Click(object sender, EventArgs e)
        {
            CarregarDocEmpresaProposta();
        }

        private void CarregarDocEmpresaProposta()
        {
            SqlConnection Cnn = Banco.CriarConexao();
            SqlDataAdapter sql = new SqlDataAdapter("Select * from EmpresaLicitacao Order by nome asc ", Cnn);
            DataSet Dt = new DataSet();
            sql.Fill(Dt, "EmpresaLicitacao");
            DataRow dr = Dt.Tables["EmpresaLicitacao"].NewRow();
            dr[1] = "";
            Dt.Tables["EmpresaLicitacao"].Rows.Add(dr);
            try
            {

                this.cboEmpProposta.DisplayMember = "nome";
                this.cboEmpProposta.ValueMember = "idempresa";
                this.cboEmpProposta.DataSource = Dt.Tables["EmpresaLicitacao"];
                this.cboEmpProposta.SelectedIndex = cboEmpProposta.Items.Count - 1;



            }
            catch (Exception erro)
            {

                throw erro;
            }
            Cnn.Close();
        }
        private void RetornaDocEmpresaProposta(Int32 retemp)
        {
            SqlConnection Cnn = Banco.CriarConexao();
            SqlDataAdapter sql = new SqlDataAdapter("Select * from EmpresaLicitacao WHERE idempresa=" + retemp + "", Cnn);
            DataTable Dt = new DataTable();
            sql.Fill(Dt);
            try
            {
                this.cboEmpProposta.DataSource = Dt;
                this.cboEmpProposta.DisplayMember = "nome";
                this.cboEmpProposta.ValueMember = "idempresa";
                this.cboEmpProposta.Refresh();




            }
            catch (Exception erro)
            {

                throw erro;
            }
            Cnn.Close();
        }

        private void cbotipodocprop_Click(object sender, EventArgs e)
        {
            CarregarTipoDocumentoEmpresaProposta();
        }

        private void CarregarTipoDocumentoEmpresaProposta()
        {
            SqlConnection Cnn = Banco.CriarConexao();
            SqlDataAdapter sql = new SqlDataAdapter("Select * from TipoDocumento Order by nome asc ", Cnn);
            DataSet Dt = new DataSet();
            sql.Fill(Dt, "TipoDocumento");
            DataRow dr = Dt.Tables["TipoDocumento"].NewRow();
            dr[1] = "";
            Dt.Tables["TipoDocumento"].Rows.Add(dr);
            try
            {

                this.cbotipodocprop.DisplayMember = "nome";
                this.cbotipodocprop.ValueMember = "idtipodocumento";
                this.cbotipodocprop.DataSource = Dt.Tables["TipoDocumento"];
                this.cbotipodocprop.SelectedIndex = cbotipodocprop.Items.Count - 1;



            }
            catch (Exception erro)
            {

                throw erro;
            }
            Cnn.Close();
        }
        private void RetornaTipoDocumentoEmpresarProposta(Int32 retdoc)
        {
            SqlConnection Cnn = Banco.CriarConexao();
            SqlDataAdapter sql = new SqlDataAdapter("Select * from TipoDocumento WHERE idtipodocumento=" + retdoc + "", Cnn);
            DataTable Dt = new DataTable();
            sql.Fill(Dt);
            try
            {
                this.cbotipodocprop.DataSource = Dt;
                this.cbotipodocprop.DisplayMember = "nome";
                this.cbotipodocprop.ValueMember = "idtipodocumento";
                this.cbotipodocprop.Refresh();




            }
            catch (Exception erro)
            {

                throw erro;
            }
            Cnn.Close();
        }

        private void btnAnexarDocProposta_Click(object sender, EventArgs e)
        {
            if (ValidaCamposDocEmpProposta() == true)
            {

                try
                {
                    OpenFileDialog AbrirComo = new OpenFileDialog();
                    //DialogResult Caminho;


                    AbrirComo.Title = "Abrir Como";

                    AbrirComo.FileName = "Nome Arquivo";
                    AbrirComo.Filter = "Arquivos (*.*)|*.*";
                    AbrirComo.InitialDirectory = "D:\\";
                    if (AbrirComo.ShowDialog() == DialogResult.OK)
                        arquivopdf = AbrirComo.FileName;
                    if (arquivopdf == " ")
                    {
                        MessageBox.Show("Arquivo Invalido", "Salvar Como", MessageBoxButtons.OK);
                    }
                    else
                    {


                        txtxnomearqprop.Text = arquivopdf;
                        nomearq = System.IO.Path.GetFileName(txtxnomearqprop.Text);

                        string arq = nomearq;

                        extensao = System.IO.Path.GetExtension(txtxnomearqprop.Text);

                        tiporarq = arq.Substring(arq.Length - 3, 3);

                        FileData = ReadFile(txtxnomearqprop.Text);

                        GravarArquivoDocProposta();
                    }




                }
                catch (Exception erro)
                {
                    MessageBox.Show("Erro ao carregar arquivo!" + erro.Message.ToString(), "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }

        }
        private void GravarArquivoDocProposta()
        {


            if (ValidaCamposDocEmpProposta() == true)
            {


                VlDocPropostaEmp obj = new VlDocPropostaEmp();
                obj.idempresa = Convert.ToInt32(cboEmpProposta.SelectedValue);
                obj.idedital = Convert.ToInt32(txtcodigo.Text);
                obj.idtipodoc = Convert.ToInt32(cbotipodocprop.SelectedValue);
                VlDocPropostaEmp.arq = FileData;
                obj.nomearq = nomearq;
                obj.extensao = extensao;
                obj.dtarquivo = DateTime.Now.ToString("dd/MM/yyyy");
                obj.idusu = Banco.idusu;

                try
                {
                    PsPropostaDocEmp DAODocEmp = new PsPropostaDocEmp();
                    DAODocEmp.Incluir(obj);
                    CarregaGridPropostaEmp();
                    //MessageBox.Show("Registro Incluido com Sucesso!");
                    //Limpacampos();
                    //RetReg();

                }
                catch (Exception erro)
                {

                    throw erro;
                }

            }

        }

        private void CarregaGridPropostaEmp()
        {


            //define o dataset

            DataTable ds = new DataTable();


            //cria uma conexÆo usando a string de conexÆo

            SqlConnection Conn = Banco.CriarConexao();



            try
            {

                //abre a conexao

                Conn.Open();

            }

            catch (System.Exception e)
            {

                throw e;

            }


            if (Conn.State == ConnectionState.Open)
            {

                //se a conexÆo estiver aberta usa uma instru‡Æo SQL para selecionar os registros da tabela clientes

                //SELECT campos FROM tabela



                SqlDataAdapter da = new SqlDataAdapter("Select DocPropostaEmp.iddocempresaprop as Cod,TipoDocumento.nome as Tipo_Documento, DocPropostaEmp.dtarquivo as DtArquivo " +
              " from TipoDocumento,DocPropostaEmp,LancEditais Where DocPropostaEmp.idedital = LancEditais.idedital AND DocPropostaEmp.idtipodoc = TipoDocumento.idtipodocumento AND DocPropostaEmp.idedital  =" + txtcodigo.Text + "  Order by DtArquivo Desc ", Conn);

                da.Fill(ds);

                this.GridPropEmp.RowsDefaultCellStyle.BackColor = Color.LightBlue;
                this.GridPropEmp.AlternatingRowsDefaultCellStyle.BackColor = Color.Azure;


                //exibe os dados no datagridview
                GridPropEmp.AutoGenerateColumns = false;
                GridPropEmp.DataSource = ds;
                GridPropEmp.Columns.Clear();
                GridPropEmp.Columns.Add("Cod", "Cod");
                GridPropEmp.Columns.Add("Tipo_Documento", "Tipo_Documento");
                GridPropEmp.Columns.Add("DtArquivo", "DtArquivo");

                GridPropEmp.Columns[0].Width = 50;
                GridPropEmp.Columns[1].Width = 280;
                GridPropEmp.Columns[2].Width = 80;

                GridPropEmp.Columns[0].DataPropertyName = "Cod";
                GridPropEmp.Columns[1].DataPropertyName = "Tipo_Documento";
                GridPropEmp.Columns[2].DataPropertyName = "DtArquivo";

                DataGridViewButtonColumn btn = new DataGridViewButtonColumn();
                GridPropEmp.Columns.Add(btn);
                btn.HeaderText = "Excluir";
                btn.Text = "Excluir";
                btn.Name = "btn";
                btn.Width = 50;
                btn.UseColumnTextForButtonValue = true;
                btn.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft;



            }

        }
        int coddocpropemp;

        private void GridPropEmp_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex == 3)
            {
                coddocpropemp = Convert.ToInt32(GridPropEmp[0, e.RowIndex].Value.ToString());

                VlDocPropostaEmp obj = new VlDocPropostaEmp();
                obj.iddocempresaprop = coddocpropemp;

                try
                {
                    PsPropostaDocEmp DAODocPROPEmp = new PsPropostaDocEmp();
                    DialogResult result = MessageBox.Show("Deseja Excluir este Item !", "Excluir", MessageBoxButtons.YesNo);
                    if (result == DialogResult.Yes)
                    {
                        DAODocPROPEmp.Exluir(obj.iddocempresaprop);
                        MessageBox.Show("Registro Excluido com Sucesso!");
                        CarregaGridPropostaEmp();

                    }
                    else if (result == DialogResult.No)
                    {
                        return;
                    }



                }
                catch (Exception erro)
                {

                    throw erro;
                }



            }
            else
            {

                coddocpropemp = Convert.ToInt32(GridPropEmp[0, e.RowIndex].Value.ToString());


            }
        }

        private void GridPropEmp_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            codarquivo = Convert.ToInt32(GridPropEmp.CurrentRow.Cells[0].Value.ToString());


            SqlConnection Cnn = Banco.CriarConexao();
            string query = "Select arq,extensao,nomearq from DocPropostaEmp Where DocPropostaEmp.iddocempresaprop = " + Convert.ToInt32(GridPropEmp[0, e.RowIndex].Value.ToString());

            SqlCommand ObjC = new SqlCommand(query, Cnn);
            Cnn.Open();
            SqlDataReader dr = ObjC.ExecuteReader();

            dr.Read();


            try
            {


                //string FileLocation = Path.GetTempPath() + dr["tipo"].ToString();
                string ext = dr["extensao"].ToString();
                string narq = dr["nomearq"].ToString();

                byte[] fileData = (byte[])dr["arq"];
                using (System.IO.FileStream fs = new System.IO.FileStream(@"C:\D\" + narq, FileMode.Create))
                {

                    {
                        fs.Write(fileData, 0, fileData.Length);
                        System.Diagnostics.Process.Start(@"C:\D\" + narq);
                        fs.Close();
                        dr.Close();
                        Cnn.Close();
                    }
                }



            }
            catch (Exception)
            {

                MessageBox.Show("Arquivo já se encontra em aberto");
            }
            Cnn.Close();

        }

        private void cbopropfornecedor_Click(object sender, EventArgs e)
        {
            CarregarDocPropostaFornecedor();
        }

        private void CarregarDocPropostaFornecedor()
        {
            SqlConnection Cnn = Banco.CriarConexao();
            SqlDataAdapter sql = new SqlDataAdapter("Select * from Fornecedor ", Cnn);
            DataSet Dt = new DataSet();
            sql.Fill(Dt, "Fornecedor");
            DataRow dr = Dt.Tables["Fornecedor"].NewRow();
            dr[1] = "";
            Dt.Tables["Fornecedor"].Rows.Add(dr);
            try
            {

                this.cbopropfornecedor.DisplayMember = "razao";
                this.cbopropfornecedor.ValueMember = "idfornecedor";
                this.cbopropfornecedor.DataSource = Dt.Tables["Fornecedor"];
                this.cbopropfornecedor.SelectedIndex = cbopropfornecedor.Items.Count - 1;



            }
            catch (Exception erro)
            {

                throw erro;
            }
            Cnn.Close();
        }
        private void RetornaDocPropostaFornecedor(Int32 retfor)
        {
            SqlConnection Cnn = Banco.CriarConexao();
            SqlDataAdapter sql = new SqlDataAdapter("Select * from Fornecedor WHERE idfornecedor=" + retfor + "", Cnn);
            DataTable Dt = new DataTable();
            sql.Fill(Dt);
            try
            {
                this.cbopropfornecedor.DataSource = Dt;
                this.cbopropfornecedor.DisplayMember = "razao";
                this.cbopropfornecedor.ValueMember = "idfornecedor";
                this.cbopropfornecedor.Refresh();




            }
            catch (Exception erro)
            {

                throw erro;
            }
            Cnn.Close();
        }

        private void CarregarTipoDocumentoFornecedorProposta()
        {
            SqlConnection Cnn = Banco.CriarConexao();
            SqlDataAdapter sql = new SqlDataAdapter("Select * from TipoDocumento Order by nome asc ", Cnn);
            DataSet Dt = new DataSet();
            sql.Fill(Dt, "TipoDocumento");
            DataRow dr = Dt.Tables["TipoDocumento"].NewRow();
            dr[1] = "";
            Dt.Tables["TipoDocumento"].Rows.Add(dr);
            try
            {

                this.cbotipodocpropfor.DisplayMember = "nome";
                this.cbotipodocpropfor.ValueMember = "idtipodocumento";
                this.cbotipodocpropfor.DataSource = Dt.Tables["TipoDocumento"];
                this.cbotipodocpropfor.SelectedIndex = cbotipodocpropfor.Items.Count - 1;



            }
            catch (Exception erro)
            {

                throw erro;
            }
            Cnn.Close();
        }
        private void RetornaTipoDocumentoFornecedorProposta(Int32 retdoc)
        {
            SqlConnection Cnn = Banco.CriarConexao();
            SqlDataAdapter sql = new SqlDataAdapter("Select * from TipoDocumento WHERE idtipodocumento=" + retdoc + "", Cnn);
            DataTable Dt = new DataTable();
            sql.Fill(Dt);
            try
            {
                this.cbotipodocpropfor.DataSource = Dt;
                this.cbotipodocpropfor.DisplayMember = "nome";
                this.cbotipodocpropfor.ValueMember = "idtipodocumento";
                this.cbotipodocpropfor.Refresh();




            }
            catch (Exception erro)
            {

                throw erro;
            }
            Cnn.Close();
        }

        private void cbotipodocpropfor_Click(object sender, EventArgs e)
        {
            CarregarTipoDocumentoFornecedorProposta();
        }

        private void btnAnexarDocPropostaFornecedor_Click(object sender, EventArgs e)
        {
            if (ValidaCamposDocForProposta() == true)
            {

                try
                {
                    OpenFileDialog AbrirComo = new OpenFileDialog();
                    //DialogResult Caminho;


                    AbrirComo.Title = "Abrir Como";

                    AbrirComo.FileName = "Nome Arquivo";
                    AbrirComo.Filter = "Arquivos (*.*)|*.*";
                    AbrirComo.InitialDirectory = "D:\\";
                    if (AbrirComo.ShowDialog() == DialogResult.OK)
                        arquivopdf = AbrirComo.FileName;
                    if (arquivopdf == " ")
                    {
                        MessageBox.Show("Arquivo Invalido", "Salvar Como", MessageBoxButtons.OK);
                    }
                    else
                    {


                        txtxnomearqpropfor.Text = arquivopdf;
                        nomearq = System.IO.Path.GetFileName(txtxnomearqpropfor.Text);

                        string arq = nomearq;

                        extensao = System.IO.Path.GetExtension(txtxnomearqpropfor.Text);

                        tiporarq = arq.Substring(arq.Length - 3, 3);

                        FileData = ReadFile(txtxnomearqpropfor.Text);

                        GravarArquivoDocPropostaFor();
                    }




                }
                catch (Exception erro)
                {
                    MessageBox.Show("Erro ao carregar arquivo!" + erro.Message.ToString(), "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void GravarArquivoDocPropostaFor()
        {


            if (ValidaCamposDocForProposta() == true)
            {


                VlPropostaDocFornecedor obj = new VlPropostaDocFornecedor();
                obj.idfornecedor = Convert.ToInt32(cbopropfornecedor.SelectedValue);
                obj.idedital = Convert.ToInt32(txtcodigo.Text);
                obj.idtipodoc = Convert.ToInt32(cbotipodocpropfor.SelectedValue);
                VlPropostaDocFornecedor.arq = FileData;
                obj.nomearq = nomearq;
                obj.extensao = extensao;
                obj.dtarquivo = DateTime.Now.ToString("dd/MM/yyyy");
                obj.idusu = Banco.idusu;

                try
                {
                    PsPropostaDocFornecedor DAODocFor = new PsPropostaDocFornecedor();
                    DAODocFor.Incluir(obj);
                    CarregaGridPropostaFor();
                    //MessageBox.Show("Registro Incluido com Sucesso!");
                    //Limpacampos();
                    //RetReg();

                }
                catch (Exception erro)
                {

                    throw erro;
                }

            }

        }

        private void CarregaGridPropostaFor()
        {


            //define o dataset

            DataTable ds = new DataTable();


            //cria uma conexÆo usando a string de conexÆo

            SqlConnection Conn = Banco.CriarConexao();



            try
            {

                //abre a conexao

                Conn.Open();

            }

            catch (System.Exception e)
            {

                throw e;

            }


            if (Conn.State == ConnectionState.Open)
            {

                //se a conexÆo estiver aberta usa uma instru‡Æo SQL para selecionar os registros da tabela clientes

                //SELECT campos FROM tabela



                SqlDataAdapter da = new SqlDataAdapter("Select DocPropostaFornecedor.iddocfornecedorprop as Cod,TipoDocumento.nome as Tipo_Documento, DocPropostaFornecedor.dtarquivo as DtArquivo " +
              " from TipoDocumento,DocPropostaFornecedor,LancEditais Where DocPropostaFornecedor.idedital = LancEditais.idedital AND DocPropostaFornecedor.idtipodoc = TipoDocumento.idtipodocumento AND DocPropostaFornecedor.idedital  =" + txtcodigo.Text + "  Order by DtArquivo Desc ", Conn);

                da.Fill(ds);

                this.GridPropFor.RowsDefaultCellStyle.BackColor = Color.LightBlue;
                this.GridPropFor.AlternatingRowsDefaultCellStyle.BackColor = Color.Azure;


                //exibe os dados no datagridview
                GridPropFor.AutoGenerateColumns = false;
                GridPropFor.DataSource = ds;
                GridPropFor.Columns.Clear();
                GridPropFor.Columns.Add("Cod", "Cod");
                GridPropFor.Columns.Add("Tipo_Documento", "Tipo_Documento");
                GridPropFor.Columns.Add("DtArquivo", "DtArquivo");

                GridPropFor.Columns[0].Width = 50;
                GridPropFor.Columns[1].Width = 280;
                GridPropFor.Columns[2].Width = 80;

                GridPropFor.Columns[0].DataPropertyName = "Cod";
                GridPropFor.Columns[1].DataPropertyName = "Tipo_Documento";
                GridPropFor.Columns[2].DataPropertyName = "DtArquivo";

                DataGridViewButtonColumn btn = new DataGridViewButtonColumn();
                GridPropFor.Columns.Add(btn);
                btn.HeaderText = "Excluir";
                btn.Text = "Excluir";
                btn.Name = "btn";
                btn.Width = 50;
                btn.UseColumnTextForButtonValue = true;
                btn.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft;



            }

        }
        int coddocpropfor;

        private void GridPropFor_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex == 3)
            {
                coddocpropfor = Convert.ToInt32(GridPropFor[0, e.RowIndex].Value.ToString());

                VlPropostaDocFornecedor obj = new VlPropostaDocFornecedor();
                obj.iddocfornecedorprop = coddocpropfor;

                try
                {
                    PsPropostaDocFornecedor DAODocPROPFor = new PsPropostaDocFornecedor();
                    DialogResult result = MessageBox.Show("Deseja Excluir este Item !", "Excluir", MessageBoxButtons.YesNo);
                    if (result == DialogResult.Yes)
                    {
                        DAODocPROPFor.Exluir(obj.iddocfornecedorprop);
                        MessageBox.Show("Registro Excluido com Sucesso!");
                        CarregaGridPropostaFor();

                    }
                    else if (result == DialogResult.No)
                    {
                        return;
                    }



                }
                catch (Exception erro)
                {

                    throw erro;
                }



            }
            else
            {

                coddocpropfor = Convert.ToInt32(GridPropFor[0, e.RowIndex].Value.ToString());


            }
        }

        private void GridPropFor_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            codarquivo = Convert.ToInt32(GridPropFor.CurrentRow.Cells[0].Value.ToString());


            SqlConnection Cnn = Banco.CriarConexao();
            string query = "Select arq,extensao,nomearq from DocPropostaFornecedor Where DocPropostaFornecedor.iddocempresaprop = " + Convert.ToInt32(GridPropFor[0, e.RowIndex].Value.ToString());

            SqlCommand ObjC = new SqlCommand(query, Cnn);
            Cnn.Open();
            SqlDataReader dr = ObjC.ExecuteReader();

            dr.Read();


            try
            {


                //string FileLocation = Path.GetTempPath() + dr["tipo"].ToString();
                string ext = dr["extensao"].ToString();
                string narq = dr["nomearq"].ToString();

                byte[] fileData = (byte[])dr["arq"];
                using (System.IO.FileStream fs = new System.IO.FileStream(@"C:\D\" + narq, FileMode.Create))
                {

                    {
                        fs.Write(fileData, 0, fileData.Length);
                        System.Diagnostics.Process.Start(@"C:\D\" + narq);
                        fs.Close();
                        dr.Close();
                        Cnn.Close();
                    }
                }



            }
            catch (Exception)
            {

                MessageBox.Show("Arquivo já se encontra em aberto");
            }
            Cnn.Close();
        }

        private void cboprincipioativo_Click(object sender, EventArgs e)
        {

            CarregarPrincipioAtivo();

        }

        private void CarregarPrincipioAtivo()
        {
            SqlConnection Cnn = Banco.CriarConexao();
            SqlDataAdapter sql = new SqlDataAdapter("Select * from PrincipioAtivo asc", Cnn);
            DataSet Dt = new DataSet();
            sql.Fill(Dt, "PrincipioAtivo");
            DataRow dr = Dt.Tables["PrincipioAtivo"].NewRow();
            dr[0] = 0;
            Dt.Tables["PrincipioAtivo"].Rows.Add(dr);
            try
            {

                this.cboprincipioativo.DisplayMember = "nome";
                this.cboprincipioativo.ValueMember = "idprincipio";
                this.cboprincipioativo.DataSource = Dt.Tables["PrincipioAtivo"];
                this.cboprincipioativo.SelectedIndex = cboprincipioativo.Items.Count - 1;



            }
            catch (Exception erro)
            {

                throw erro;
            }
            Cnn.Close();
        }


        private void CarregarItens()
        {
            SqlConnection Cnn = Banco.CriarConexao();
            SqlDataAdapter sql = new SqlDataAdapter("Select * from Produto asc", Cnn);
            DataSet Dt = new DataSet();
            sql.Fill(Dt, "Produto");
            DataRow dr = Dt.Tables["Produto"].NewRow();
            dr[0] = 0;
            Dt.Tables["Produto"].Rows.Add(dr);
            try
            {

                this.cboitens.DisplayMember = "nome";
                this.cboitens.ValueMember = "idproduto";
                this.cboitens.DataSource = Dt.Tables["Produto"];
                this.cboitens.SelectedIndex = cboitens.Items.Count - 1;



            }
            catch (Exception erro)
            {

                throw erro;
            }
            Cnn.Close();
        }
        private void RetornaItens(Int32 retfor)
        {
            SqlConnection Cnn = Banco.CriarConexao();
            SqlDataAdapter sql = new SqlDataAdapter("Select idproduto, nome + ' - ' + apresentacao as Produto from Produto WHERE idproduto=" + retfor + "", Cnn);
            DataTable Dt = new DataTable();
            sql.Fill(Dt);
            try
            {
                this.cboitens.DataSource = Dt;
                this.cboitens.DisplayMember = "Produto";
                this.cboitens.ValueMember = "idproduto";
                this.cboitens.Refresh();


            }
            catch (Exception erro)
            {

                throw erro;
            }
            Cnn.Close();
        }

        private void RetornaPrincipioAtivo(Int32 retfor)
        {
            SqlConnection Cnn = Banco.CriarConexao();
            SqlDataAdapter sql = new SqlDataAdapter("Select * from PrincipioAtivo WHERE idprincipio=" + retfor + "", Cnn);
            DataTable Dt = new DataTable();
            sql.Fill(Dt);
            try
            {
                this.cboprincipioativo.DataSource = Dt;
                this.cboprincipioativo.DisplayMember = "nome";
                this.cboprincipioativo.ValueMember = "idprincipio";
                this.cboprincipioativo.Refresh();


            }
            catch (Exception erro)
            {

                throw erro;
            }
            Cnn.Close();
        }




        private void CarregarUnidadeMedidade()
        {
            SqlConnection Cnn = Banco.CriarConexao();
            SqlDataAdapter sql = new SqlDataAdapter("Select * from UnidadeMedida asc", Cnn);
            DataSet Dt = new DataSet();
            sql.Fill(Dt, "UnidadeMedida");
            DataRow dr = Dt.Tables["UnidadeMedida"].NewRow();
            dr[1] = "";
            Dt.Tables["UnidadeMedida"].Rows.Add(dr);
            try
            {

                this.cbounidade.DisplayMember = "nome";
                this.cbounidade.ValueMember = "idunidade";
                this.cbounidade.DataSource = Dt.Tables["UnidadeMedida"];
                this.cbounidade.SelectedIndex = cbounidade.Items.Count - 1;



            }
            catch (Exception erro)
            {

                throw erro;
            }
            Cnn.Close();
        }
        private void RetornaUnidade(Int32 retu)
        {
            SqlConnection Cnn = Banco.CriarConexao();
            SqlDataAdapter sql = new SqlDataAdapter("Select UnidadeMedida.nome,UnidadeMedida.idunidade  from UnidadeMedida, Produto  WHERE " +
                "UnidadeMedida.idunidade = Produto.idunidade AND Produto.idproduto=" + retu + "", Cnn);
            DataTable Dt = new DataTable();
            sql.Fill(Dt);
            try
            {
                this.cbounidade.DataSource = Dt;
                this.cbounidade.DisplayMember = "nome";
                this.cbounidade.ValueMember = "idunidade";
                this.cbounidade.Refresh();




            }
            catch (Exception erro)
            {

                throw erro;
            }
            Cnn.Close();
        }

        private void cbounidade_Click(object sender, EventArgs e)
        {
            //CarregarUnidadeMedidade();
        }

        int codf;
        int codp;

        private void cboprincipioativo_KeyPress(object sender, KeyPressEventArgs e)
        {

        }

        private void txtlote_KeyPress(object sender, KeyPressEventArgs e)
        {
            if ((Keys)e.KeyChar == Keys.Enter)
            {
                this.txtnitem.Focus();
            }
        }

        private void txtnitem_KeyPress(object sender, KeyPressEventArgs e)
        {
            if ((Keys)e.KeyChar == Keys.Enter)
            {
                this.txtquantidade.Focus();
            }
        }

        private void cbounidade_KeyPress(object sender, KeyPressEventArgs e)
        {
            if ((Keys)e.KeyChar == Keys.Enter)
            {
                this.txtquantidade.Focus();
            }
        }

        private void txtvlestimado_KeyPress(object sender, KeyPressEventArgs e)
        {
            //if ((Keys)e.KeyChar == Keys.Enter)
            //{

            //    if (txtquantidade.Text != "0")
            //    {
            //        Decimal vlunit;
            //        Decimal Vltotal;
            //        Decimal qtde;

            //        Decimal convertc = decimal.Parse("0");
            //        string converunit = String.Format("{0:N2}", convertc);
            //        vlunit= converunit;

            //        vlunit = decimal.Parse();
            //        qtde = Convert.ToDecimal(txtquantidade.Text);

            //        Vltotal = (vlunit * qtde);

            //        string converttotal = String.Format("{0:N2}", Math.Round(Vltotal, 2));
            //        this.txttotalestimado.Text = Convert.ToString(converttotal);

            //        cbofabricante.Focus();

            //        // this.btnAdd.Focus();

            //    }

            //}

        }

        private void txtquantidade_TextChanged(object sender, EventArgs e)
        {

        }

        private void txtquantidade_KeyPress(object sender, KeyPressEventArgs e)
        {


            if (!Char.IsDigit(e.KeyChar) && e.KeyChar != (char)8)
            {
                e.Handled = true;
                txtprecocusto.Focus();

            }




        }


        private Boolean ValidaCamposItens()
        {
            if (this.txtcodigo.Text == "")
            {
                MessageBox.Show("Informe o Código");
                txtcodigo.Focus();
                return false;

            }

            if (this.txtlote.Text == "")
            {
                MessageBox.Show("Informe o Lote");
                txtlote.Focus();
                return false;

            }

            if (this.txtnitem.Text == "")
            {
                MessageBox.Show("informe o Nº Item");
                txtnitem.Focus();
                return false;

            }
            if (this.cboitens.Text == "")
            {
                MessageBox.Show("informe o Principio Ativo!");
                cboitens.Focus();
                return false;

            }

            if (this.cbounidade.Text == "")
            {
                MessageBox.Show("informe a Unidade de Medida!");
                cbounidade.Focus();
                return false;

            }


            if (this.cbocliente.Text == "")
            {
                MessageBox.Show("informe o Cliente!");
                cbocliente.Focus();
                return false;

            }

            if (this.cbofabricante.Text == "")
            {
                MessageBox.Show("informe o Fabricante!");
                cbofabricante.Focus();
                return false;

            }

            if (this.cboprincipioativo.Text == "")
            {
                MessageBox.Show("informe o Princípio Ativo!");
                cboprincipioativo.Focus();
                return false;

            }
            if (this.cbofornecedor.Text == "")
            {
                MessageBox.Show("informe o Fornecedor!");
                cbofornecedor.Focus();
                return false;

            }

            if (this.cboitens.Text == "")
            {
                MessageBox.Show("informe o Item!");
                cboitens.Focus();
                return false;

            }


            return true;


        }

        int codfor;
        private void BuscaDadosFornecedor(int idproduto)
        {

            string query = "Select Produto_Fornecedor.idfornecedor as codfor  " +
                " From Produto_Fornecedor,Produto Where Produto_Fornecedor.idfornecedor = Produto.idfornecedor and Produto.idproduto=" + idproduto;
            SqlConnection Cnx = Banco.CriarConexao();
            Cnx.Open();
            SqlCommand cmd = new SqlCommand(query, Cnx);
            SqlDataReader dr = cmd.ExecuteReader();
            if (dr.Read())
            {

                codfor = Convert.ToInt32(dr["codfor"].ToString());


            }

        }


        private void btnAdd_Click(object sender, EventArgs e)
        {
            if (ValidaCamposItens() == true)
            {
                VlItemLicitacao obj = new VlItemLicitacao();
                obj.lote = txtlote.Text.ToUpper();
                obj.nritem = Convert.ToInt32(txtnitem.Text);
                obj.idproduto = Convert.ToInt32(cboitens.SelectedValue);
                obj.idunidade = Convert.ToInt32(cbounidade.SelectedValue);
                obj.vlestimado = Convert.ToDouble(txtvlestimado.Text); //- Convert.ToDecimal(txtcomissao.Text);
                obj.qtde = Convert.ToInt32(txtquantidade.Text);
                obj.vltotalestimado = Convert.ToDouble(txtvlestimadototal.Text);
                obj.dtitens = DateTime.Now.ToString("dd/MM/yyyy");
                obj.idusu = Banco.idusu;
                obj.descitem = "ND";
                obj.statusdesc = Convert.ToInt32(0);
                obj.statuscotacao = "SIM";
                obj.idcliente = Convert.ToInt32(cbocliente.SelectedValue);
                obj.nlicitacao = txtnlicitacao.Text.ToUpper();
                obj.processo = this.txtnprocesso.Text;
                obj.idfabricante = Convert.ToInt32(cbofabricante.SelectedValue);
                obj.idprincipio = Convert.ToInt32(cboprincipioativo.SelectedValue);
                obj.idmarca = Convert.ToInt32(cbomarca.SelectedValue);
                obj.idfornecedor = 0;
                obj.idedital = Convert.ToInt32(txtcodigo.Text);


                try
                {

                    //if (VerificaRegistroItemExiste(obj.idproduto, obj.idedital) == true)
                    //{


                    PsItemLicitacao DAOitem = new PsItemLicitacao();
                    DAOitem.Incluir(obj);
                    RetornaItem();
                    carregarGridItens();
                    GravarRetorno();
                    GravaTabelaPrecoVenda();
                    GravaProposta();
                    //}
                    //else
                    //{

                    //    PsItemLicitacao DAOitem = new PsItemLicitacao();
                    //    DAOitem.AlterarItem(obj);
                    //    carregarGridItens();

                    //}
                }

                catch (Exception erro)
                {
                    throw erro;
                }
            }
        }

        private void GravarRetorno()
        {

            try


            {
                //if (!cbofornecedor.SelectedIndex.Equals(-1))
                //{

                foreach (DataGridViewRow row in griditens.Rows)
                {

                    int item = Convert.ToInt32(row.Cells[1].Value);
                    int forcod = Convert.ToInt32(cbofornecedor.SelectedValue);
                    //string nforn = row.Cells[15].Value.ToString();



                    string edital = Convert.ToString(txtnlicitacao.Text);
                    int idedital = Convert.ToInt32(txtcodigo.Text);
                    int itemedital = Convert.ToInt32(row.Cells[1].Value);
                    int qtde = Convert.ToInt32(row.Cells[7].Value);

                    decimal desconto = Convert.ToDecimal(0);
                    decimal repasse = Convert.ToDecimal(0);
                    decimal ipi = Convert.ToDecimal(0);
                    decimal frete = Convert.ToDecimal(0);

                    int idfornecedor = Convert.ToInt32(cbofornecedor.SelectedValue);
                    int idproduto = Convert.ToInt32(cboitens.SelectedValue);

                    decimal preco = 0;
                    decimal liquido = 0;
                    decimal vltotal = 0;

                    if (casas == 2)
                    {
                        string vlpreco = String.Format("{0:N2}", Convert.ToDecimal(txtprecocusto.Text), 2);
                        preco = Convert.ToDecimal(vlpreco);
                        string vlliquido = String.Format("{0:N2}", Convert.ToDecimal(txtprecocusto.Text), 2);
                        liquido = Convert.ToDecimal(vlliquido);
                        string total = String.Format("{0:N2}", Convert.ToDecimal(preco * qtde), 2);
                        vltotal = Convert.ToDecimal(total);

                    }
                    else if (casas == 3)
                    {

                        string vlpreco = String.Format("{0:N3}", Convert.ToDecimal(txtprecocusto.Text), 3);
                        preco = Convert.ToDecimal(vlpreco);
                        string vlliquido = String.Format("{0:N3}", Convert.ToDecimal(txtprecocusto.Text), 3);
                        liquido = Convert.ToDecimal(vlliquido);
                        string total = String.Format("{0:N2}", Convert.ToDecimal(preco * qtde), 2);
                        vltotal = Convert.ToDecimal(total);


                    }
                    else if (casas == 4)
                    {

                        string vlpreco = String.Format("{0:N4}", Convert.ToDecimal(txtprecocusto.Text), 4);
                        preco = Convert.ToDecimal(vlpreco);
                        string vlliquido = String.Format("{0:N4}", Convert.ToDecimal(txtprecocusto.Text), 4);
                        liquido = Convert.ToDecimal(vlliquido);
                        string total = String.Format("{0:N2}", Convert.ToDecimal(preco * qtde), 2);
                        vltotal = Convert.ToDecimal(total);


                    }
                    else if (casas == 5)
                    {

                        string vlpreco = String.Format("{0:N5}", Convert.ToDecimal(row.Cells[5].Value), 4);
                        preco = Convert.ToDecimal(vlpreco);
                        string vlliquido = String.Format("{0:N5}", Convert.ToDecimal(row.Cells[11].Value), 4);
                        liquido = Convert.ToDecimal(vlliquido);
                        string total = String.Format("{0:N2}", Convert.ToDecimal(preco * qtde), 2);
                        vltotal = Convert.ToDecimal(total);


                    }
                    else if (casas == 6)
                    {

                        string vlpreco = String.Format("{0:N6}", Convert.ToDecimal(txtprecocusto.Text), 4);
                        preco = Convert.ToDecimal(vlpreco);
                        string vlliquido = String.Format("{0:N6}", Convert.ToDecimal(txtprecocusto.Text), 4);
                        liquido = Convert.ToDecimal(vlliquido);
                        string total = String.Format("{0:N2}", Convert.ToDecimal(preco * qtde), 2);
                        vltotal = Convert.ToDecimal(total);


                    }




                    if (VerificaRegistroExisteRetorno(item, idedital) == true)
                    {

                        SalvarDadosRetorno(itemedital, qtde, preco, desconto, repasse, ipi, frete, liquido, vltotal, edital, idfornecedor, idproduto, idedital);
                    }
                    else
                    {


                        AlterarDadosRetorno(itemedital, qtde, preco, desconto, repasse, ipi, frete, liquido, vltotal, edital, idfornecedor, idproduto, idedital);

                    }
                }


                //}
                //else
                //{
                //    MessageBox.Show("Favor Informar o nome do Fornecedor!");
                //    chkFornecedor.Checked = true;

                //}
            }
            catch (Exception erro)
            {

                throw erro;
            }


        }

        public void SalvarDadosRetorno(int itemedital, int qtde, decimal preco, decimal desconto, decimal repasse, decimal ipi, decimal frete, decimal liquido, decimal vltotal, string edital, int idfornecedor, int idproduto, int idedital)
        {
            try
            {



                SqlConnection Cnn = Banco.CriarConexao();

                string insert = "INSERT INTO RetCotacao(iditemedital,qtde,preco,desconto,repasse,ipi,frete,liquido,vltotal,idusu,idedital,idfornecedor,dtcotacao,idproduto) VALUES (@iditemedital,@qtde,@preco,@desconto,@repasse,@ipi,@frete,@liquido,@vltotal,@idusu,@idedital,@idfornecedor,@dtcotacao,@idproduto)";

                SqlCommand cmd = new SqlCommand(insert, Cnn);
                cmd.Parameters.AddWithValue("@iditemedital", itemedital);
                cmd.Parameters.AddWithValue("@qtde", qtde);
                cmd.Parameters.AddWithValue("@preco", preco);
                cmd.Parameters.AddWithValue("@desconto", desconto);
                cmd.Parameters.AddWithValue("@repasse", repasse);
                cmd.Parameters.AddWithValue("@ipi", ipi);
                cmd.Parameters.AddWithValue("@frete", frete);
                cmd.Parameters.AddWithValue("@liquido", liquido);
                cmd.Parameters.AddWithValue("@vltotal", vltotal);
                cmd.Parameters.AddWithValue("@idusu", Banco.idusu);
                cmd.Parameters.AddWithValue("@idedital", idedital);
                cmd.Parameters.AddWithValue("@idfornecedor", idfornecedor);
                cmd.Parameters.AddWithValue("@dtcotacao", SqlDbType.Date).Value = DateTime.Now.ToString("yyyy/MM/dd");
                cmd.Parameters.AddWithValue("@idproduto", idproduto);
                // cmd.Parameters.AddWithValue("@casasdecimais", casas);
                Cnn.Open();
                cmd.ExecuteNonQuery();
                Cnn.Close();



                MessageBox.Show("Dados incluídos com sucesso !!", "Inclusão", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                ex.Message.ToString();
            }
        }

        public void AlterarDadosRetorno(int itemedital, int qtde, decimal preco, decimal desconto, decimal repasse, decimal ipi, decimal frete, decimal liquido, decimal vltotal, string edital, int idfornecedor, int idproduto, int idedital)
        {
            try
            {

                SqlConnection Cnn = Banco.CriarConexao();

                string update = "UPDATE RetCotacao SET desconto=@desconto,repasse=@repasse,ipi=@ipi,frete=@frete,liquido=@liquido," +
                    ",idusu=@idusu,idedital=@idedital,dtcotacao=@dtcotacao,idproduto=@idproduto WHERE iditemedital=@iditemedital and idfornecedor=@idfornecedor and idedital=@idedital";

                SqlCommand cmd = new SqlCommand(update, Cnn);
                cmd.Parameters.AddWithValue("@iditemedital", itemedital);
                cmd.Parameters.AddWithValue("@desconto", desconto);
                cmd.Parameters.AddWithValue("@repasse", repasse);
                cmd.Parameters.AddWithValue("@ipi", ipi);
                cmd.Parameters.AddWithValue("@frete", frete);
                cmd.Parameters.AddWithValue("@liquido", liquido);
                cmd.Parameters.AddWithValue("@idusu", Banco.idusu);
                cmd.Parameters.AddWithValue("@idedital", idedital);
                cmd.Parameters.AddWithValue("@idfornecedor", idfornecedor);
                cmd.Parameters.AddWithValue("@dtcotacao", SqlDbType.Date).Value = DateTime.Now.ToString("yyyy/MM/dd");
                cmd.Parameters.AddWithValue("@idproduto", idproduto);
                // cmd.Parameters.AddWithValue("@casasdecimais", casasdecimais);
                Cnn.Open();
                cmd.ExecuteNonQuery();
                Cnn.Close();



                //MessageBox.Show("Dados Alterados com sucesso !!", "Inclusão", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                ex.Message.ToString();
            }
        }


        private Boolean VerificaRegistroExisteRetorno(int cod, int idedital)
        {

            SqlConnection Cnn = Banco.CriarConexao();
            string obter = ("Select * From RetCotacao Where iditemedital = " + cod +  " AND idedital=" + idedital + "");
            SqlCommand sql = new SqlCommand(obter, Cnn);
            Cnn.Open();
            SqlDataReader dr = sql.ExecuteReader();
            if (dr.Read())
            {

                return false;
            }
            return true;
        }
        private void GravaTabelaPrecoVenda()
        {
            try


            {

                foreach (DataGridViewRow row in griditens.Rows)
                {

                    int iditemedital = Convert.ToInt32(row.Cells[1].Value);
                    int codforn = Convert.ToInt32((cbofornecedor.SelectedValue));
                    string edital = Convert.ToString(txtnlicitacao.Text);
                    int qtd = Convert.ToInt32((row.Cells[7].Value));
                    double pcompra = Convert.ToDouble(txtprecocusto.Text);
                    int idedital = Convert.ToInt32(txtcodigo.Text);




                    if (VerificaRegistroExisteTabelaPrecoVenda(iditemedital,  idedital) == true)
                    {


                        SalvarDadosTabelaPrecoVenda(iditemedital, qtd, pcompra, codforn, 0, edital);
                    }
                    else
                    {


                        AlterarDadosTabelaPrecoVenda();

                    }
                }

            }
            catch (Exception erro)
            {

                throw erro;
            }

        }
        public void SalvarDadosTabelaPrecoVenda(int itemedital, int qtd, double pcompra, int codf, double preco, string edital)
        {



            int idedital = Convert.ToInt32(txtcodigo.Text);



            SqlConnection Cnn = Banco.CriarConexao();

            string insert = "INSERT INTO VendaPreco(iditemedital,nlicitacao,qtde,precocompra,repasse,desconto,ipi,frete,creditoicms,icmsvenda,pis,comissao,custofixo,ml,fretesaida,precocusto,idusu,idfornecedor,imprenda,contsocial,idedital) " +
                " VALUES (@iditemedital,@nlicitacao,@qtde,@precocompra,@repasse,@desconto,@ipi,@frete,@creditoicms,@icmsvenda,@pis,@comissao,@custofixo,@ml,@fretesaida,@precocusto,@idusu,@idfornecedor,@imprenda,@contsocial,@idedital)";

            SqlCommand cmd = new SqlCommand(insert, Cnn);
            cmd.Parameters.AddWithValue("@iditemedital", itemedital);
            cmd.Parameters.AddWithValue("@nlicitacao", edital);
            cmd.Parameters.AddWithValue("@qtde", qtd);
            cmd.Parameters.AddWithValue("@precocompra", 0);
            cmd.Parameters.AddWithValue("@repasse", 0);
            cmd.Parameters.AddWithValue("@desconto", 0);
            cmd.Parameters.AddWithValue("@ipi", 0);
            cmd.Parameters.AddWithValue("@frete", 0);
            cmd.Parameters.AddWithValue("@creditoicms", 0);
            cmd.Parameters.AddWithValue("@icmsvenda", 0);
            cmd.Parameters.AddWithValue("@pis", 0);
            cmd.Parameters.AddWithValue("@comissao", 0);
            cmd.Parameters.AddWithValue("@custofixo", 0);
            cmd.Parameters.AddWithValue("@ml", 0);
            cmd.Parameters.AddWithValue("@fretesaida", 0);
            cmd.Parameters.AddWithValue("@precocusto", pcompra);
            cmd.Parameters.AddWithValue("@idusu", Banco.idusu);
            cmd.Parameters.AddWithValue("@idfornecedor", codf);
            cmd.Parameters.AddWithValue("@imprenda", 0);
            cmd.Parameters.AddWithValue("@contsocial", 0);
            cmd.Parameters.AddWithValue("@idedital", idedital);
            Cnn.Open();
            cmd.ExecuteNonQuery();
            Cnn.Close();

        }


        public void AlterarDadosTabelaPrecoVenda()
        {
            try
            {
                foreach (DataGridViewRow row in griditens.Rows)
                {

                    string edital = txtnlicitacao.Text;
                    int idedital = Convert.ToInt32(txtcodigo.Text);
                    int itemedital = Convert.ToInt32(row.Cells[1].Value);
                    int qtd = Convert.ToInt32(row.Cells[7].Value);
                    int codforn = Convert.ToInt32((cbofornecedor.SelectedValue));
                    decimal pcusto = 0;
                    if (casas == 2)
                    {
                        string pcompra = String.Format("{0:N2}", Convert.ToDecimal(row.Cells[11].Value), 2);
                        pcusto = decimal.Parse(pcompra);
                    }
                    if (casas == 3)
                    {
                        string pcompra = String.Format("{0:N3}", Convert.ToDecimal(row.Cells[11].Value), 3);
                        pcusto = decimal.Parse(pcompra);
                    }
                    if (casas == 4)
                    {
                        string pcompra = String.Format("{0:N4}", Convert.ToDecimal(row.Cells[11].Value), 4);
                        pcusto = decimal.Parse(pcompra);
                    }
                    if (casas == 5)
                    {
                        string pcompra = String.Format("{0:N5}", Convert.ToDecimal(row.Cells[11].Value), 5);
                        pcusto = decimal.Parse(pcompra);
                    }
                    if (casas == 6)
                    {
                        string pcompra = String.Format("{0:N6}", Convert.ToDecimal(row.Cells[11].Value), 6);
                        pcusto = decimal.Parse(pcompra);
                    }



                    int codf = Convert.ToInt32(row.Cells[14].Value);



                    SqlConnection Cnn = Banco.CriarConexao();

                    string update = "UPDATE VendaPreco SET nlicitacao=@nlicitacao,repasse=@repasse,desconto=@desconto,ipi=@ipi,frete=@frete,creditoicms=@creditoicms,icmsvenda=@icmsvenda," +
                        "pis=@pis,comissao=@comissao,custofixo=@custofixo,ml=@ml,fretesaida=@fretesaida,idusu=@idusu,idfornecedor=@idfornecedor,imprenda=@imprenda,contsocial=@contsocial,idedital=@idedital WHERE idfornecedor=@idfornecedor and iditemedital=@iditemedital and idedital=@idedital";
                    SqlCommand cmd = new SqlCommand(update, Cnn);
                    cmd.Parameters.AddWithValue("@iditemedital", itemedital);
                    cmd.Parameters.AddWithValue("@nlicitacao", edital);
                    cmd.Parameters.AddWithValue("@repasse", 0);
                    cmd.Parameters.AddWithValue("@desconto", 0);
                    cmd.Parameters.AddWithValue("@ipi", 0);
                    cmd.Parameters.AddWithValue("@frete", 0);
                    cmd.Parameters.AddWithValue("@creditoicms", 0);
                    cmd.Parameters.AddWithValue("@icmsvenda", 0);
                    cmd.Parameters.AddWithValue("@pis", 0);
                    cmd.Parameters.AddWithValue("@comissao", 0);
                    cmd.Parameters.AddWithValue("@custofixo", 0);
                    cmd.Parameters.AddWithValue("@ml", 0);
                    cmd.Parameters.AddWithValue("@fretesaida", 0);
                    cmd.Parameters.AddWithValue("@idusu", Banco.idusu);
                    cmd.Parameters.AddWithValue("@idfornecedor", codf);
                    cmd.Parameters.AddWithValue("@imprenda", 0);
                    cmd.Parameters.AddWithValue("@contsocial", 0);
                    cmd.Parameters.AddWithValue("@idedital", idedital);
                    Cnn.Open();
                    cmd.ExecuteNonQuery();
                    Cnn.Close();

                }

                //MessageBox.Show("Dados Alterados com sucesso !!", "Inclusão", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                ex.Message.ToString();
            }
        }




        private Boolean VerificaRegistroExisteTabelaPrecoVenda(int cod, int idedital)
        {

            SqlConnection Cnn = Banco.CriarConexao();
            string obter = ("Select * From VendaPreco Where iditemedital = " + cod + " AND idedital='" + idedital + "'");
            SqlCommand sql = new SqlCommand(obter, Cnn);
            Cnn.Open();
            SqlDataReader dr = sql.ExecuteReader();
            if (dr.Read())
            {

                return false;
            }
            return true;
        }


        private void GravaProposta()
        {


            try
            {

                foreach (DataGridViewRow row in griditens.Rows)
                {


                    int iditem = Convert.ToInt32(row.Cells[1].Value);
                    int codf = Convert.ToInt32(cbofornecedor.SelectedValue);
                    int idedital = Convert.ToInt32(txtcodigo.Text);
                    string edital = Convert.ToString(txtnlicitacao.Text);

                    if (VerificaRegistroExisteProposta(iditem, idedital) == true)


                    {
                        SqlConnection Cnn = Banco.CriarConexao();

                        string insert = "INSERT INTO Proposta(iditemedital,selecionado,cotado,idusu,ganho,margemfinal,precovenda,casasdecimais,idfornecedor,edital,precominimo,minimototal,idedital) VALUES " +
                                "(@iditemedital,@selecionado,@cotado,@idusu,@ganho,@margemfinal,@precovenda,@casasdecimais,@idfornecedor,@edital,@precominimo,@minimototal,@idedital)";
                        SqlCommand cmd = new SqlCommand(insert, Cnn);
                        cmd.Parameters.AddWithValue("@iditemedital", iditem);
                        cmd.Parameters.AddWithValue("@selecionado", "SIM");
                        cmd.Parameters.AddWithValue("@cotado", "SIM");
                        cmd.Parameters.AddWithValue("@idusu", Banco.idusu);
                        cmd.Parameters.AddWithValue("@ganho", 1);
                        cmd.Parameters.AddWithValue("@margemfinal", 0);
                        cmd.Parameters.AddWithValue("@precovenda", 0);
                        cmd.Parameters.AddWithValue("@casasdecimais", casas);
                        cmd.Parameters.AddWithValue("@idfornecedor", codf);
                        cmd.Parameters.AddWithValue("@edital", edital);
                        cmd.Parameters.AddWithValue("@precominimo", 0);
                        cmd.Parameters.AddWithValue("@minimototal", 0);
                        cmd.Parameters.AddWithValue("@idedital", idedital);
                        Cnn.Open();
                        cmd.ExecuteNonQuery();
                        Cnn.Close();

                    }

                    else

                    {
                        SqlConnection Cnn = Banco.CriarConexao();

                        string update = "UPDATE Proposta SET selecionado=@selecionado,cotado=@cotado,idusu=@idusu,ganho=@ganho,casasdecimais=@casasdecimais," +
                                "idedital=@idedital WHERE iditemedital=@iditemedital and idedital=@idedital";

                        SqlCommand cmd = new SqlCommand(update, Cnn);
                        cmd.Parameters.AddWithValue("@iditemedital", iditem);
                        cmd.Parameters.AddWithValue("@selecionado", "SIM");
                        cmd.Parameters.AddWithValue("@cotado", "SIM");
                        cmd.Parameters.AddWithValue("@idusu", Banco.idusu);
                        cmd.Parameters.AddWithValue("@ganho", 1);
                        cmd.Parameters.AddWithValue("@casasdecimais", casas);
                        cmd.Parameters.AddWithValue("@edital", edital);
                        cmd.Parameters.AddWithValue("@idedital", idedital);
                        Cnn.Open();
                        cmd.ExecuteNonQuery();
                        Cnn.Close();



                    }



                }
                //  MessageBox.Show("Dados incluídos com sucesso !!", "Inclusão", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                ex.Message.ToString();
            }
        }

        private Boolean VerificaRegistroExisteProposta(int cod, int editall)
        {

            SqlConnection Cnn = Banco.CriarConexao();
            string obter = ("Select * From Proposta Where iditemedital = " + cod + " AND idedital='" + editall + "'");
            SqlCommand sql = new SqlCommand(obter, Cnn);
            Cnn.Open();
            SqlDataReader dr = sql.ExecuteReader();
            if (dr.Read())
            {

                return false;
            }
            return true;


        }



        private Boolean VerificaRegistroItemExiste(int idprodutto, int edtt)
        {

            SqlConnection Cnn = Banco.CriarConexao();
            string obter = ("Select * From ItemsLicitacao Where idproduto = " + idprodutto + " AND idedital=" + edtt + "");
            SqlCommand sql = new SqlCommand(obter, Cnn);
            Cnn.Open();
            SqlDataReader dr = sql.ExecuteReader();
            if (dr.Read())
            {

                return false;
            }
            return true;
        }

        DataGridViewCheckBoxColumn chk = new DataGridViewCheckBoxColumn();
        public Decimal valor;
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
                string strConn = "Select  ItemsLicitacao.iditemedital as Cod,ItemsLicitacao.lote as Lote,ItemsLicitacao.nritem as NºItem,PrincipioAtivo.nome + ' - ' + Marca.nome as PrincipioAtivo,Produto.nome + ' - ' + Produto.apresentacao as Produto, UnidadeMedida.nome as Unidade, ItemsLicitacao.qtde as Qtde, ItemsLicitacao.nlicitacao as codedital,Produto.idproduto" +
                " from ItemsLicitacao,UnidadeMedida,PrincipioAtivo, Produto, Marca Where  Marca.idmarca = Produto.idmarca AND ItemsLicitacao.idproduto = Produto.idproduto AND  Produto.idprincipio = PrincipioAtivo.idprincipio AND ItemsLicitacao.idunidade = UnidadeMedida.idunidade AND ItemsLicitacao.idedital=" + txtcodigo.Text + " Order By CASE WHEN ItemsLicitacao.lote ='0' THEN ItemsLicitacao.nritem WHEN  ItemsLicitacao.lote <> '0' THEN ItemsLicitacao.iditemedital END ";

                SqlDataAdapter da = new SqlDataAdapter(strConn, Conn);
                da.Fill(ds);


            }

            this.griditens.RowsDefaultCellStyle.BackColor = Color.LightBlue;
            this.griditens.AlternatingRowsDefaultCellStyle.BackColor = Color.Azure;


            griditens.AutoGenerateColumns = false;
            //exibe os dados no datagridview
            griditens.DataSource = ds;
            griditens.Columns.Clear();
            griditens.Columns.Add(chk);
            chk.HeaderText = "Sel";
            chk.Name = "chk";
            griditens.Columns.Add("Cod", "Cod");
            griditens.Columns.Add("Lote", "Lote");
            griditens.Columns.Add("NºItem", "NºItem");
            griditens.Columns.Add("Produto", "Produto");
            griditens.Columns.Add("PrincipioAtivo", "PrincipioAtivo");
            griditens.Columns.Add("Unidade", "Unidade");
            griditens.Columns.Add("Qtde", "Qtde");
            griditens.Columns.Add("codedital", "codedital");
            griditens.Columns.Add("idproduto", "idproduto");


            griditens.Columns[0].Width = 50;
            griditens.Columns[1].Visible = false;
            griditens.Columns[2].Width = 80;
            griditens.Columns[3].Width = 50;
            griditens.Columns[4].Width = 415;
            griditens.Columns[5].Width = 220;
            griditens.Columns[6].Width = 80;
            griditens.Columns[7].Width = 70;
            griditens.Columns[8].Visible = false;
            griditens.Columns[9].Visible = false;


            griditens.Columns[1].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft;
            griditens.Columns[6].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft;
            griditens.Columns[4].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft;



            griditens.Columns[1].DataPropertyName = "Cod";
            griditens.Columns[2].DataPropertyName = "Lote";
            griditens.Columns[3].DataPropertyName = "NºItem";
            griditens.Columns[4].DataPropertyName = "Produto";
            griditens.Columns[5].DataPropertyName = "PrincipioAtivo";
            griditens.Columns[6].DataPropertyName = "Unidade";
            griditens.Columns[7].DataPropertyName = "Qtde";
            griditens.Columns[8].DataPropertyName = "codedital";
            griditens.Columns[9].DataPropertyName = "idproduto";


            DataGridViewButtonColumn btn = new DataGridViewButtonColumn();
            griditens.Columns.Add(btn);
            btn.HeaderText = "Excluir";
            btn.Text = "Excluir";
            btn.Name = "btn";
            btn.Width = 70;
            btn.UseColumnTextForButtonValue = true;
            btn.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft;


            griditens.Refresh();

            Int32 total = 0;

            foreach (DataGridViewRow linhatotal in griditens.Rows)
            {
                total = total + 1;
            }

            this.txttotalitens.Text = Convert.ToString(total);
        }
        int coditems;
        private void griditens_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex == 0)
            {

                int coditem = Convert.ToInt32(griditens[1, e.RowIndex].Value.ToString());

                RetornaDadosItensEdital(coditem);

            }

            if (e.ColumnIndex == 10)
            {
                coditems = Convert.ToInt32(griditens[1, e.RowIndex].Value.ToString());

                VlItemLicitacao obj = new VlItemLicitacao();
                obj.iditemedital = coditems;

                try
                {
                    PsItemLicitacao DAOItem = new PsItemLicitacao();
                    DialogResult result = MessageBox.Show("Deseja Excluir este Item !", "Excluir", MessageBoxButtons.YesNo);
                    if (result == DialogResult.Yes)
                    {
                        DAOItem.Exluir(obj.iditemedital);
                        MessageBox.Show("Registro Excluido com Sucesso!");
                        carregarGridItens();

                    }
                    else if (result == DialogResult.No)
                    {
                        return;
                    }



                }
                catch (Exception erro)
                {

                    throw erro;
                }



            }
            else
            {

                coditems = Convert.ToInt32(griditens[1, e.RowIndex].Value.ToString());


            }

        }

        private void RetornaDadosItensEdital(int coditem)
        {

            string reg = "Select * From ItemsLicitacao where iditemedital=" + coditem + " ";
            DataTable ds = new DataTable();
            SqlConnection Conn = Banco.CriarConexao();
            Conn.Open();

            if (Conn.State == ConnectionState.Open)
            {
                SqlCommand cmd = new SqlCommand(reg, Conn);
                SqlDataReader dr = cmd.ExecuteReader();
                if (dr.Read())
                {

                    Decimal vlestimado = decimal.Parse(dr["vlestimado"].ToString());
                    string convertvlestimado = String.Format("{0:N2}", vlestimado);
                    this.txtvlestimado.Text = convertvlestimado;

                    Decimal vlestimadototal = decimal.Parse(dr["vltotalestimado"].ToString());
                    string convertvlestimadototal = String.Format("{0:N2}", vlestimadototal);
                    txtvlestimadototal.Text = convertvlestimadototal;

                    RetornaPrincipioAtivo(Convert.ToInt32(dr["idprincipio"].ToString()));
                    RetornaItens(Convert.ToInt32(dr["idproduto"].ToString()));
                    RetornaUnidade(Convert.ToInt32(dr["idunidade"].ToString()));
                    RetornaFabricante(Convert.ToInt32(dr["idfabricante"].ToString()));
                    RetornaMarca(Convert.ToInt32(dr["idmarca"].ToString()));
                    txtlote.Text = dr["lote"].ToString();
                    txtnitem.Text = dr["nritem"].ToString();
                    txtquantidade.Text = dr["qtde"].ToString();
                    RetornaFornecGravado(Convert.ToInt32(dr["iditemedital"].ToString()));
                   // RetornaFor(Convert.ToInt32(dr[""].ToString()));

                }
            }


        }


        private void RetornaFornecGravado(int iditedt)
        {
            SqlConnection Cnn = Banco.CriarConexao();
            SqlDataAdapter sql = new SqlDataAdapter("Select distinct Fornecedor.idfornecedor, Fornecedor.razao from ItemsLicitacao,RetCotacao,Fornecedor " +
                " WHERE ItemsLicitacao.iditemedital = RetCotacao.iditemedital And RetCotacao.idfornecedor = Fornecedor.idfornecedor AND RetCotacao.iditemedital=" + iditedt + "", Cnn);
            DataSet Dt = new DataSet();
            sql.Fill(Dt);
            BindingSource bs = new BindingSource();
            bs.DataSource = Dt;
            bs.DataMember = Dt.Tables[0].TableName;

            try
            {
                this.cbofornecedor.DataSource = bs;
                this.cbofornecedor.DisplayMember = "razao";
                this.cbofornecedor.ValueMember = "idfornecedor";
                // this.cbomarca.SelectedIndex = cbomarca.Items.Count - 1;



            }
            catch (Exception erro)
            {

                throw erro;
            }
            Cnn.Close();

        }

        private void txttotalgeral_TextChanged(object sender, EventArgs e)
        {

        }

        private void txttotalitens_TextChanged(object sender, EventArgs e)
        {

        }

        private void label43_Click(object sender, EventArgs e)
        {

        }

        private void label44_Click(object sender, EventArgs e)
        {

        }


        public int codigoitem;
        public int codigonitem;
        public int codigolote;
        private void BtnDescAuxiliar_Click(object sender, EventArgs e)
        {
            if (bool.Parse(griditens.CurrentRow.Cells[0].FormattedValue.ToString()) == true)
            {
                foreach (DataGridViewRow check in griditens.Rows)
                {
                    if ((bool)check.Cells[0].FormattedValue)
                    {
                        codigoitem = int.Parse(check.Cells[1].Value.ToString());
                        codigolote = int.Parse(check.Cells[2].Value.ToString());
                        codigonitem = int.Parse(check.Cells[3].Value.ToString());


                        ViewDescItens Desc = new ViewDescItens(this);
                        Desc.Show();

                    }
                }

            }
            else
            {
                MessageBox.Show("Selecione um item");
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            ViewGerarCotacao g = new ViewGerarCotacao();
            g.Show();
        }



        private void btnImportacao_Click(object sender, EventArgs e)
        {

        }

        private void cboitens_KeyPress(object sender, KeyPressEventArgs e)
        {
            if ((Keys)e.KeyChar == Keys.Enter)
            {

                txtquantidade.Focus();

                // btnAdd.Focus();
            }
        }

        private void cboitens_Click(object sender, EventArgs e)
        {
            //CarregarItens();
        }

        private void cboprincipioativo_Click_1(object sender, EventArgs e)
        {
            CarregarPrincipioAtivo();
        }

        private void cbofabricante_Click(object sender, EventArgs e)
        {
            CarregarFabricante();
        }

        private void cbofabricante_KeyPress(object sender, KeyPressEventArgs e)
        {
            if ((Keys)e.KeyChar == Keys.Enter)
            {

                cboprincipioativo.Focus();
            }
        }

        private void btnBusca_Click(object sender, EventArgs e)
        {
            ViewAdicionaItens add = new ViewAdicionaItens(this);
            add.Show();
        }

        public ViewLancamentoEditais(ViewAdicionaItens frm) : this()
        {
            UltimoSelecionado = frm.idedital;
            RetReg();
            tablanc.SelectedIndex = 3;
            txtlote.Focus();

            RetornaPrincipioAtivo(Convert.ToInt32(frm.codprincipio));
            RetornaItens(Convert.ToInt32(frm.codproduto));
            RetornaUnidade(Convert.ToInt32(frm.codproduto));
            RetornaFabricante(Convert.ToInt32(frm.codproduto));
            RetornaMarca(Convert.ToInt32(frm.codproduto));
            txtlote.Focus();


        }



        private void carregarGridItensAdd(string editalitems)
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
                string strConn = "Select DISTINCT ItemsLicitacao.iditemedital as Cod,ItemsLicitacao.lote as Lote,ItemsLicitacao.nritem as NºItem,PrincipioAtivo.nome as PrincipioAtivo,Produto.nome as Produto, UnidadeMedida.nome as Unidade, ItemsLicitacao.qtde as Qtde, ItemsLicitacao.nlicitacao as codedital" +
                " from ItemsLicitacao,UnidadeMedida,PrincipioAtivo, Produto Where ItemsLicitacao.idproduto = Produto.idproduto AND  Produto.idprincipio = PrincipioAtivo.idprincipio AND ItemsLicitacao.idunidade = UnidadeMedida.idunidade AND ItemsLicitacao.idedital=" + idedital + " ORDER BY ItemsLicitacao.lote,  ItemsLicitacao.nritem  asc";

                SqlDataAdapter da = new SqlDataAdapter(strConn, Conn);
                da.Fill(ds);


            }

            this.griditens.RowsDefaultCellStyle.BackColor = Color.LightBlue;
            this.griditens.AlternatingRowsDefaultCellStyle.BackColor = Color.Azure;


            griditens.AutoGenerateColumns = false;
            //exibe os dados no datagridview
            griditens.DataSource = ds;
            griditens.Columns.Clear();
            griditens.Columns.Add(chk);
            chk.HeaderText = "Sel";
            chk.Name = "chk";
            griditens.Columns.Add("Cod", "Cod");
            griditens.Columns.Add("Lote", "Lote");
            griditens.Columns.Add("NºItem", "NºItem");
            griditens.Columns.Add("PrincipioAtivo", "PrincipioAtivo");
            griditens.Columns.Add("Produto", "Produto");
            griditens.Columns.Add("Unidade", "Unidade");
            griditens.Columns.Add("Qtde", "Qtde");
            griditens.Columns.Add("codedital", "codedital");

            griditens.Columns[0].Width = 50;
            griditens.Columns[1].Width = 0;
            griditens.Columns[2].Width = 80;
            griditens.Columns[3].Width = 50;
            griditens.Columns[4].Width = 415;
            griditens.Columns[5].Width = 220;
            griditens.Columns[6].Width = 80;
            griditens.Columns[7].Width = 70;
            griditens.Columns[8].Width = 0;

            griditens.Columns[1].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft;
            griditens.Columns[6].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft;
            griditens.Columns[4].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft;



            griditens.Columns[1].DataPropertyName = "Cod";
            griditens.Columns[2].DataPropertyName = "Lote";
            griditens.Columns[3].DataPropertyName = "NºItem";
            griditens.Columns[4].DataPropertyName = "PrincipioAtivo";
            griditens.Columns[5].DataPropertyName = "Produto";
            griditens.Columns[6].DataPropertyName = "Unidade";
            griditens.Columns[7].DataPropertyName = "Qtde";
            griditens.Columns[8].DataPropertyName = "codedital";

            DataGridViewButtonColumn btn = new DataGridViewButtonColumn();
            griditens.Columns.Add(btn);
            btn.HeaderText = "Excluir";
            btn.Text = "Excluir";
            btn.Name = "btn";
            btn.Width = 70;
            btn.UseColumnTextForButtonValue = true;
            btn.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft;


            griditens.Refresh();

            Int32 total = 0;

            foreach (DataGridViewRow linhatotal in griditens.Rows)
            {
                total = total + 1;
            }

            this.txttotalitens.Text = Convert.ToString(total);
        }

        private void cbofabricante_SelectionChangeCommitted(object sender, EventArgs e)
        {
            //this.cbomarca.SelectedIndex = - 1;

            //SqlConnection Cnn = Banco.CriarConexao();
            //SqlDataAdapter sql = new SqlDataAdapter("Select Marca.idmarca as idmarca,Marca.nome as Marca from Fabricante,Marca " +
            //    " WHERE Fabricante.idfabricante = Marca.idfabricante And Fabricante.idfabricante='" + cbofabricante.SelectedValue + "'", Cnn);
            //DataSet Dt = new DataSet();
            //sql.Fill(Dt);
            //BindingSource bs = new BindingSource();
            //bs.DataSource = Dt;
            //bs.DataMember = Dt.Tables[0].TableName;

            //try
            //{
            //    this.cbomarca.DataSource = bs;
            //    this.cbomarca.DisplayMember = "Marca";
            //    this.cbomarca.ValueMember = "idmarca";
            //    this.cbomarca.SelectedIndex = cbomarca.Items.Count - 1;



            //}
            //catch (Exception erro)
            //{

            //    throw erro;
            //}
            //Cnn.Close();


        }



        private void RetornaMarca(int idmarc)
        {
            SqlConnection Cnn = Banco.CriarConexao();
            SqlDataAdapter sql = new SqlDataAdapter("Select distinct Marca.idmarca, Marca.nome as Marca from Marca,Produto " +
                " WHERE Produto.idmarca = Marca.idmarca And Produto.idproduto=" + idmarc + "", Cnn);
            DataSet Dt = new DataSet();
            sql.Fill(Dt);
            BindingSource bs = new BindingSource();
            bs.DataSource = Dt;
            bs.DataMember = Dt.Tables[0].TableName;

            try
            {
                this.cbomarca.DataSource = bs;
                this.cbomarca.DisplayMember = "Marca";
                this.cbomarca.ValueMember = "idmarca";
                // this.cbomarca.SelectedIndex = cbomarca.Items.Count - 1;



            }
            catch (Exception erro)
            {

                throw erro;
            }
            Cnn.Close();

        }

        private void RetornaItem(int codpcp)
        {

            LimpaItens();

            SqlConnection Cnn = Banco.CriarConexao();
            SqlDataAdapter sql = new SqlDataAdapter("Select Produto.idproduto, Produto.nome as Produto from Produto,PrincipioAtivo " +
                " WHERE Produto.idprincipio = PrincipioAtivo.idprincipio And Produto.idprincipio='" + codpcp + "'", Cnn);
            DataSet Dt = new DataSet();
            sql.Fill(Dt);
            BindingSource bs = new BindingSource();
            bs.DataSource = Dt;
            bs.DataMember = Dt.Tables[0].TableName;

            try
            {

                this.cboitens.DataSource = bs;
                this.cboitens.DisplayMember = "Produto";
                this.cboitens.ValueMember = "idproduto";
                this.cboitens.SelectedIndex = cboitens.Items.Count - 1;



            }
            catch (Exception erro)
            {

                throw erro;
            }
            Cnn.Close();



        }

        private void cbomarca_KeyPress(object sender, KeyPressEventArgs e)
        {
            if ((Keys)e.KeyChar == Keys.Enter)
            {


                this.cboitens.Focus();

            }
        }

        private void LimpaItens()
        {
            cboitens.SelectedIndex = -1;
            cbounidade.SelectedIndex = -1;
            cbomarca.SelectedIndex = -1;
            cbofabricante.SelectedIndex = -1;

        }

        private void cboprincipioativo_SelectionChangeCommitted_1(object sender, EventArgs e)
        {
            CarregaForProd();

        }

        private void cboitens_SelectionChangeCommitted(object sender, EventArgs e)
        {

            RetornaFabricante(Convert.ToInt32(cboitens.SelectedValue));
            RetornaMarca(Convert.ToInt32(cboitens.SelectedValue));
            RetornaUnidade(Convert.ToInt32(cboitens.SelectedValue));
            // coditemsproduto = Convert.ToInt32(cboitens.SelectedValue);

        }

        private void bntVisualizar_Click(object sender, EventArgs e)
        {

        }

        private void griditens_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            coditemsproduto = Convert.ToInt32(griditens[9, e.RowIndex].Value.ToString());
            ViewProduto frcont = new ViewProduto(this);
            frcont.Show();
        }

        private void txtquantidade_MouseClick(object sender, MouseEventArgs e)
        {
            ((TextBox)sender).SelectionStart = 0;
            ((TextBox)sender).SelectAll();
        }

        private void cboprincipioativo_Click_2(object sender, EventArgs e)
        {


        }

        private void ViewLancamentoEditais_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            idedital = Convert.ToInt32(txtcodigo.Text);
            ViewAdicionaItens add = new ViewAdicionaItens(this);
            this.Close();
            add.Show();
        }

        private void cborepresentate_SelectionChangeCommitted(object sender, EventArgs e)
        {

            string reg = "Select idrepresentante,razao from Representante where idrepresentante=" + cborepresentate.SelectedValue + " ";
            DataTable ds = new DataTable();
            SqlConnection Conn = Banco.CriarConexao();
            Conn.Open();

            if (Conn.State == ConnectionState.Open)
            {
                SqlCommand cmd = new SqlCommand(reg, Conn);
                SqlDataReader dr = cmd.ExecuteReader();
                if (dr.Read())
                {

                    txtrazao.Text = dr["razao"].ToString();

                }
            }


        }

        private void txtvlestimado_KeyPress_1(object sender, KeyPressEventArgs e)
        {
            if ((Keys)e.KeyChar == Keys.Enter)
            {

                decimal vlestimado = Convert.ToDecimal(this.txtvlestimado.Text);
                this.txtvlestimado.Text = String.Format("{0:N2}", Math.Round(vlestimado, 2));

                this.txtnitem.Focus();
            }
        }

        private void txtvlestimadototal_KeyPress(object sender, KeyPressEventArgs e)
        {
            if ((Keys)e.KeyChar == Keys.Enter)
            {

                decimal vlestimadototal = Convert.ToDecimal(this.txtvlestimadototal.Text);
                this.txtvlestimadototal.Text = String.Format("{0:N2}", Math.Round(vlestimadototal, 2));

                this.txtnitem.Focus();
            }
        }

        private void txtportal_KeyPress(object sender, KeyPressEventArgs e)
        {
            if ((Keys)e.KeyChar == Keys.Enter)
            {
                this.txtobjeto.Focus();
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            idedital = Convert.ToInt32(txtcodigo.Text);


            RelInformacaoEdital empenho = new RelInformacaoEdital(this);
            empenho.Show();
        }

        private void chkTodos_CheckedChanged(object sender, EventArgs e)
        {
            foreach (DataGridViewRow row in griditens.Rows)
            {
                DataGridViewCheckBoxCell chk = (DataGridViewCheckBoxCell)row.Cells[0];
                chk.Value = !(chk.Value == null ? false : (bool)chk.Value); //because chk.Value is initialy null
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {

            try


            {

                foreach (DataGridViewRow row in griditens.Rows)
                {


                    if (Convert.ToBoolean(row.Cells["chk"].EditedFormattedValue) == true)
                    {
                        int item = Convert.ToInt32(row.Cells[1].Value);
                        int codedital = Convert.ToInt32(txtcodigo.Text);
                        string nlicitacao = txtnlicitacao.Text;



                        SqlConnection Cnn = Banco.CriarConexao();

                        string update = "UPDATE ItemsLicitacao SET nlicitacao=@nlicitacao WHERE iditemedital=@iditemedital AND  idedital=@idedital";

                        SqlCommand cmd = new SqlCommand(update, Cnn);
                        cmd.Parameters.AddWithValue("@iditemedital", item);
                        cmd.Parameters.AddWithValue("@idedital", codedital);
                        cmd.Parameters.AddWithValue("@nlicitacao", nlicitacao);
                        Cnn.Open();
                        cmd.ExecuteNonQuery();
                        Cnn.Close();



                    }
                }
            }
            catch (Exception erro)
            {

                throw erro;
            }

            //  AlteraStatusLicitacao();
            carregarGridItens();


        }

        private void rbt2casas_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void cbofornecedor_Click(object sender, EventArgs e)
        {
            CarregarFor();
        }

        private void txtprecocusto_KeyPress(object sender, KeyPressEventArgs e)
        {
            if ((Keys)e.KeyChar == Keys.Enter)
            {
                Decimal convertc = decimal.Parse(txtprecocusto.Text);
                string converunit = String.Format("{0:N2}", convertc);
                txtprecocusto.Text = converunit;
                btnAdd.Focus();
            }
        }
    }

}