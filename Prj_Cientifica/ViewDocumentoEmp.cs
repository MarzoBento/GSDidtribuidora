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
    public partial class ViewDocumentoEmp : Form
    {
        public static string TipoGravacao;
        public static string UltimoSelecionado;
        public static string nomeform;

        public ViewDocumentoEmp()
        {
            InitializeComponent();
        }

        private void dtemi_ValueChanged(object sender, EventArgs e)
        {
        }

        public ViewDocumentoEmp(ConsDocEmpresa frm) : this()
        {
            UltimoSelecionado = Convert.ToString(frm.codempresa);
            RetReg();


        }

        private void RetContador()
        {

            if (nomeform == "ConsDocEmpresa")
            {
                string query = "Select Max(iddocumento) as cont From DocEmpresa";
                SqlConnection Cnx = Banco.CriarConexao();
                Cnx.Open();
                SqlCommand cmd = new SqlCommand(query, Cnx);
                SqlDataReader dr = cmd.ExecuteReader();
                if (dr.Read())
                {

                    if (dr["cont"].ToString() != "")
                    {

                        int soma = Convert.ToInt32(dr["cont"].ToString());
                        soma = soma + 1;
                        txtcodigo.Text = Convert.ToString(soma);
                    }
                    else
                    {
                        txtcodigo.Text = Convert.ToString(1);
                    }

                }
            }
        }

        private void RetRegDocEmpresa()
        {

            string reg = "Select * from DocEmpresa ";
            if (UltimoSelecionado != null)
                reg += "Where DocEmpresa.idempresa = " + UltimoSelecionado;
            else reg += "Where DocEmpresa.iddocumento = (Select Max(iddocumento) from DocEmpresa)";
            DataTable ds = new DataTable();
            SqlConnection Conn = Banco.CriarConexao();
            Conn.Open();

            if (Conn.State == ConnectionState.Open)
            {
                SqlCommand cmd = new SqlCommand(reg, Conn);
                SqlDataReader dr = cmd.ExecuteReader();
                if (dr.Read())
                {
                    txtcodigo.Text = dr["iddocumento"].ToString();
                    
                }
            }


        }



        private void RetReg()
        {
            string reg = "Select * from DocEmpresa,DocEmp ";
            if (UltimoSelecionado != null)
                reg += "Where DocEmpresa.iddocumento =  DocEmp.iddocumento AND DocEmpresa.idempresa = " + UltimoSelecionado;
            else reg += "Where DocEmpresa.iddocumento =  DocEmp.iddocumento AND DocEmpresa.iddocumento = (Select Max(iddocumento) from DocEmpresa)";
            DataTable ds = new DataTable();
            SqlConnection Conn = Banco.CriarConexao();
            Conn.Open();

            if (Conn.State == ConnectionState.Open)
            {
                SqlCommand cmd = new SqlCommand(reg, Conn);
                SqlDataReader dr = cmd.ExecuteReader();
                if (dr.Read())
                {
                    txtcodigo.Text = dr["iddocumento"].ToString();
                    RetornaEmpresa(Convert.ToInt32(dr["idempresa"].ToString()));
                    RetornaTipoDoc(Convert.ToInt32(dr["idtipodocumento"].ToString()));
                    mskemissao.Text = dr["dtemissao"].ToString();
                    mskdtvalidade.Text = dr["dtvalidade"].ToString();
                    txtdiasvenc.Text = dr["diasvenc"].ToString();
                    txtobs.Text = dr["observacao"].ToString();
                    calculaDias(mskdtvalidade.Text);

                    CarregaGrid();
                }
            }
        }

        private void CarregarEmpresa()
        {
            SqlConnection Cnn = Banco.CriarConexao();
            SqlDataAdapter sql = new SqlDataAdapter("Select * from EmpresaLicitacao", Cnn);
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

        private void CarregarTipoDoc()
        {
            SqlConnection Cnn = Banco.CriarConexao();
            SqlDataAdapter sql = new SqlDataAdapter("Select * from TipoDocumento", Cnn);
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
        private void RetornaTipoDoc(Int32 retdoc)
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

        private void dtvalidade_ValueChanged(object sender, EventArgs e)
        {


        }

        private Boolean ValidaCampos()
        {
            //if (this.txtcodigo.Text == "")
            //{
            //    MessageBox.Show("Grave as Informações do Documento !");
            //    txtcodigo.Focus();
            //    return false;

            //}
            if (this.cboempresa.Text == "")
            {
                MessageBox.Show("Informe o Nome da Empresa");
                cboempresa.Focus();
                return false;

            }
            if (this.txtdiasvenc.Text == "")
            {
                MessageBox.Show("Informe a Quantidade de dias que o Documento ira vencer!");
                txtdiasvenc.Focus();
                return false;

            }


            return true;


        }

        private void cboempresa_KeyPress(object sender, KeyPressEventArgs e)
        {
            if ((Keys)e.KeyChar == Keys.Enter)
            {
                this.cbotipodoc.Focus();
            }
        }

        private void cbotipodoc_KeyPress(object sender, KeyPressEventArgs e)
        {
            if ((Keys)e.KeyChar == Keys.Enter)
            {
                this.mskemissao.Focus();
            }
        }

        private void mskemissao_KeyPress(object sender, KeyPressEventArgs e)
        {
            if ((Keys)e.KeyChar == Keys.Enter)
            {
                this.mskdtvalidade.Focus();
            }
        }

        private void mskdtvalidade_KeyPress(object sender, KeyPressEventArgs e)
        {
            if ((Keys)e.KeyChar == Keys.Enter)
            {
                if (mskdtvalidade.Text != "  /  /")
                {
                    calculaDias(mskdtvalidade.Text);
                }

                this.txtdiasaviso.Focus();
            }
        }

        private void Limpacampos()
        {
            txtcodigo.Text = "";
            this.cboempresa.SelectedIndex = -1;
            this.cbotipodoc.SelectedIndex = -1;
            this.mskemissao.Text = "";
            this.mskdtvalidade.Text = "";
            this.txtdiasaviso.Text = "";
            txtobs.Text = "";
            // txtnomearquivo.Text = "";
            Grid.DataSource = null;
            Grid.Refresh();
            cboempresa.Focus();


        }

        private void BtnSair_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void BtnNovo_Click(object sender, EventArgs e)
        {
            Limpacampos();
        }
        private Boolean VerificaRegistroExiste(string qd)
        {

            SqlConnection Cnn = Banco.CriarConexao();
            string obter = ("Select * From DocEmpresa Where iddocumento = '" + txtcodigo.Text + "'");
            SqlCommand sql = new SqlCommand(obter, Cnn);
            Cnn.Open();
            SqlDataReader dr = sql.ExecuteReader();
            if (dr.Read())
            {

                return false;
            }
            return true;
        }


        private void GravaDocEmpresa()
        {

            if (ValidaCampos() == true)
            {
                VlDocEmpresa obj = new VlDocEmpresa();

                if (txtcodigo.Text != "")
                {
                    obj.iddocumento = Convert.ToInt32(txtcodigo.Text);
                }



                obj.idempresa = Convert.ToInt32(cboempresa.SelectedValue);


                obj.idusu = Banco.idusu;


                try
                {
                    if (VerificaRegistroExiste(txtcodigo.Text) == true)
                    {

                        PsDocEmpresa DAODocEmpresa = new PsDocEmpresa();
                        DAODocEmpresa.Incluir(obj);
                      //  MessageBox.Show("Registro Incluido com Sucesso!");
                        // Limpacampos();
                        RetRegDocEmpresa();
                    }
                    else
                    {


                        PsDocEmpresa DAODocEmpresa = new PsDocEmpresa();
                        DAODocEmpresa.Alterar(obj);
                       // MessageBox.Show("Registro Alterada com Sucesso!");
                        // Limpacampos();
                        RetRegDocEmpresa();

                    }
                }
                catch (Exception erro)
                {

                    throw erro;
                }
            }



        }

        private void BtnSalvar_Click(object sender, EventArgs e)
        {
           

        }

        private void BtnRemover_Click(object sender, EventArgs e)
        {
            VlDocEmpresa obj = new VlDocEmpresa();
            obj.iddocumento = Convert.ToInt32(txtcodigo.Text);

            try
            {
                PsDocEmpresa DAODocEmpresa = new PsDocEmpresa();
                DAODocEmpresa.Exluir(obj.iddocumento);
                MessageBox.Show("Registro Excluido Com Sucesso!");
                Limpacampos();




            }
            catch (Exception erro)
            {

                throw erro;
            }
        }

        private void btnPesquisar_Click(object sender, EventArgs e)
        {
            ConsDocEmpresa frmconv = new ConsDocEmpresa();
            this.Close();
            frmconv.Show();
        }

        private void cboempresa_Click(object sender, EventArgs e)
        {
            CarregarEmpresa();


        }

        private void cbotipodoc_Click(object sender, EventArgs e)
        {
            CarregarTipoDoc();
        }

        private void calculaDias(string dias)
        {
            if (dias != "  /  /")
            {

                DateTime dt = Convert.ToDateTime(dias);
                //TimeSpan com a data atual menos data do niversário
                TimeSpan ts = (DateTime.Parse(dias) - DateTime.Now);

                //TimeSpan ts = DateTime.Today - dt;
                //Converter TimeSpan para DateTime
                //Como o new DateTime() retorna 01/01/0001 00:00:00
                //vou ter que remover um ano .AddYears(- 1) e um dia .AddDays(-1) para ter a data exata.


                this.txtdiasaviso.Text = Convert.ToString(ts.Days);
            }

        }

        string arquivo;
        byte[] FileData;
        string nomearq;
        string extensao;
        string tiporarq;

        private void btnanexar_Click(object sender, EventArgs e)
        {
            GravaDocEmpresa();

            if (ValidaCampos() == true)
            {

                try
                {
                    OpenFileDialog AbrirComo = new OpenFileDialog();
                    //DialogResult Caminho;

                    AbrirComo.Multiselect = true;
                    AbrirComo.Title = "Abrir Como";

                    AbrirComo.FileName = "Nome Arquivo";
                    AbrirComo.Filter = "Arquivos (*.*)|*.*";
                    AbrirComo.InitialDirectory = "D:\\";
                    if (AbrirComo.ShowDialog() == DialogResult.OK)

                        foreach (String file in AbrirComo.FileNames)
                        {

                            listarq.Items.Add(file);

                        }


                    foreach (string items in listarq.Items)
                    {

                        arquivo = System.IO.Path.GetFileName(items);

                        extensao = System.IO.Path.GetExtension(items);


                        FileData = ReadFile(items);

                        GravarArquivo();
                    }
                    listarq.Items.Clear();

                    if (arquivo == "")
                    {
                        MessageBox.Show("Arquivo Invalido", "Salvar Como", MessageBoxButtons.OK);
                    }
                    else
                    {
                        // listarq.Items.Add(arquivo);

                        // FileData = ReadFile();

                    }

                }
                catch (Exception erro)
                {
                    MessageBox.Show("Erro ao carregar arquivo!" + erro.Message.ToString(), "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
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
        }

        private void GravarArquivo()
        {


            if (ValidaCampos() == true)
            {


                VlDocEmp obj = new VlDocEmp();
                VlDocEmp.arq = FileData;
                obj.nomearq = arquivo;
                obj.idempresa = Convert.ToInt32(cboempresa.SelectedValue);
                obj.iddocumento = Convert.ToInt32(txtcodigo.Text);
                obj.idtipodocumento = Convert.ToInt32(cbotipodoc.SelectedValue);
                obj.dtemissao = mskemissao.Text;
                obj.dtvalidade = mskdtvalidade.Text;
                obj.observacao = txtobs.Text.ToUpper();
                obj.extensao = extensao;
                obj.idusu = Banco.idusu;
                obj.diasvenc = Convert.ToInt32(txtdiasvenc.Text);

                try
                {
                    PsDocEmp DAODocEmp = new PsDocEmp();
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



                SqlDataAdapter da = new SqlDataAdapter("Select DocEmp.iddocemp as Cod,TipoDocumento.nome as Tipo_Documento, DocEmp.dtemissao as DtEmissao, DocEmp.dtvalidade as DtValidade,DATEDIFF(DAY, GETDATE(), DtValidade) as Dias,DocEmp.observacao as Observacao,DocEmp.diasvenc as Avisar " +
              " from TipoDocumento,DocEmp,EmpresaLicitacao Where DocEmp.idempresa = EmpresaLicitacao.idempresa AND DocEmp.idtipodocumento = TipoDocumento.idtipodocumento AND DocEmp.iddocumento  =" + txtcodigo.Text + " And DocEmp.idempresa=" + cboempresa.SelectedValue + "  Order by data Desc ", Conn);

                da.Fill(ds);

                this.Grid.RowsDefaultCellStyle.BackColor = Color.LightBlue;
                this.Grid.AlternatingRowsDefaultCellStyle.BackColor = Color.Azure;


                //exibe os dados no datagridview
                Grid.AutoGenerateColumns = false;
                Grid.DataSource = ds;
                Grid.Columns.Clear();
                Grid.Columns.Add("Cod", "Cod");
                Grid.Columns.Add("Tipo_Documento", "Tipo_Documento");
                Grid.Columns.Add("DtEmissao", "DtEmissao");
                Grid.Columns.Add("DtValidade", "DtValidade");
                Grid.Columns.Add("Dias", "Dias");
                Grid.Columns.Add("Avisar", "Avisar");
                Grid.Columns.Add("Observacao", "Observacao");

                Grid.Columns[0].Width = 50;
                Grid.Columns[1].Width = 370;
                Grid.Columns[2].Width = 80;
                Grid.Columns[3].Width = 80;
                Grid.Columns[4].Width = 40;
                Grid.Columns[5].Width = 50;
                Grid.Columns[6].Width = 225;

                Grid.Columns[0].DataPropertyName = "Cod";
                Grid.Columns[1].DataPropertyName = "Tipo_Documento";
                Grid.Columns[2].DataPropertyName = "DtEmissao";
                Grid.Columns[3].DataPropertyName = "DtValidade";
                Grid.Columns[4].DataPropertyName = "Dias";
                Grid.Columns[5].DataPropertyName = "Avisar";
                Grid.Columns[6].DataPropertyName = "Observacao";

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
        int codarquivo;

        private void Grid_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            codarquivo = Convert.ToInt32(Grid.CurrentRow.Cells[0].Value.ToString());


            SqlConnection Cnn = Banco.CriarConexao();
            string query = "Select arq,extensao,nomearq from DocEmp Where DocEmp.iddocemp = " + Convert.ToInt32(Grid[0, e.RowIndex].Value.ToString());

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
        int codi;
        private void Grid_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex == 7)
            {
                codi = Convert.ToInt32(Grid[0, e.RowIndex].Value.ToString());

                VlDocEmp obj = new VlDocEmp();
                obj.iddocemp = codi;

                try
                {
                    PsDocEmp DAODocEmp = new PsDocEmp();
                    DialogResult result = MessageBox.Show("Deseja Excluir este Item !", "Excluir", MessageBoxButtons.YesNo);
                    if (result == DialogResult.Yes)
                    {
                        DAODocEmp.Exluir(obj.iddocemp);
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

                codi = Convert.ToInt32(Grid[0, e.RowIndex].Value.ToString());


            }
        }
        private void CarregaGridEmp()
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

                if (txtcodigo.Text != "")
                {



                    SqlDataAdapter da = new SqlDataAdapter("Select DocEmp.iddocemp as Cod,TipoDocumento.nome as Tipo_Documento, DocEmp.dtemissao as DtEmissao, DocEmp.dtvalidade as DtValidade,DATEDIFF(DAY,GETDATE(), DtValidade) as Dias,DocEmp.observacao as Observacao,DocEmp.diasvenc as Avisar " +
                  " from TipoDocumento,DocEmp,EmpresaLicitacao Where DocEmp.idempresa = EmpresaLicitacao.idempresa AND DocEmp.idtipodocumento = TipoDocumento.idtipodocumento AND DocEmp.iddocumento  =" + txtcodigo.Text + " And DocEmp.idempresa=" + cboempresa.SelectedValue + "  Order by data Desc ", Conn);

                    da.Fill(ds);

                    this.Grid.RowsDefaultCellStyle.BackColor = Color.LightBlue;
                    this.Grid.AlternatingRowsDefaultCellStyle.BackColor = Color.Azure;


                    //exibe os dados no datagridview
                    Grid.AutoGenerateColumns = false;
                    Grid.DataSource = ds;
                    Grid.Columns.Clear();
                    Grid.Columns.Add("Cod", "Cod");
                    Grid.Columns.Add("Tipo_Documento", "Tipo_Documento");
                    Grid.Columns.Add("DtEmissao", "DtEmissao");
                    Grid.Columns.Add("DtValidade", "DtValidade");
                    Grid.Columns.Add("Dias", "Dias");
                    Grid.Columns.Add("Avisar", "Avisar");
                    Grid.Columns.Add("Observacao", "Observacao");

                    Grid.Columns[0].Width = 50;
                    Grid.Columns[1].Width = 370;
                    Grid.Columns[2].Width = 80;
                    Grid.Columns[3].Width = 80;
                    Grid.Columns[4].Width = 40;
                    Grid.Columns[5].Width = 50;
                    Grid.Columns[6].Width = 225;

                    Grid.Columns[0].DataPropertyName = "Cod";
                    Grid.Columns[1].DataPropertyName = "Tipo_Documento";
                    Grid.Columns[2].DataPropertyName = "DtEmissao";
                    Grid.Columns[3].DataPropertyName = "DtValidade";
                    Grid.Columns[4].DataPropertyName = "Dias";
                    Grid.Columns[5].DataPropertyName = "Avisar";
                    Grid.Columns[6].DataPropertyName = "Observacao";

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


        }
        private void BuscaCodEmp()
        {

            string query = "Select DocEmpresa.iddocumento as cod From EmpresaLicitacao LEFT JOIN DocEmpresa ON EmpresaLicitacao.idempresa = DocEmpresa.idempresa WHERE EmpresaLicitacao.idempresa=" + cboempresa.SelectedValue;
            SqlConnection Cnx = Banco.CriarConexao();
            Cnx.Open();
            SqlCommand cmd = new SqlCommand(query, Cnx);
            SqlDataReader dr = cmd.ExecuteReader();
            if (dr.Read())
            {

                txtcodigo.Text = dr["cod"].ToString();

            }

        }

        private void cboempresa_SelectionChangeCommitted(object sender, EventArgs e)
        {
            BuscaCodEmp();
            CarregaGridEmp();
        }

        private void ViewDocumentoEmp_Load(object sender, EventArgs e)
        {
            StringBuilder stringBuilder = new StringBuilder();
            List<Vencimentos> lista = new List<Vencimentos>();


            string query = "Select DISTINCT DocEmp.dtvalidade as DtValidade,DATEDIFF(DAY,GETDATE(), DtValidade) as Dias,DocEmp.nomearq as Arquivo,DocEmp.diasvenc as Avisar From  DocEmpresa , DocEmp WHERE DocEmp.iddocumento = DocEmpresa.iddocumento AND  DocEmp.idempresa = DocEmpresa.idempresa ";
            SqlConnection Cnx = Banco.CriarConexao();
            Cnx.Open();
            SqlCommand cmd = new SqlCommand(query, Cnx);
            SqlDataReader dr = cmd.ExecuteReader();
            while (dr.Read())
            {
                Vencimentos vencimentos = new Vencimentos();

                vencimentos.dias = Convert.ToInt32(dr["Dias"].ToString());
                vencimentos.diasvenc = Convert.ToInt32(dr["Avisar"].ToString());
                vencimentos.nomearq = dr["Arquivo"].ToString();


                if( vencimentos.dias < vencimentos.diasvenc)
                {

                    lista.Add(vencimentos);

                }

              
               

            }

            foreach (var venc in lista)
            {
                stringBuilder.AppendLine("NOME DO DOCUMENTO " + venc.nomearq + " - " + "DIAS " + venc.dias);

            }

            MessageBox.Show("VENCIMENTO DE DOCUMENTOS DA EMPRESA PARA RENOVAÇÃO ! " +
                stringBuilder.ToString());

        }

        private void btnCadDoc_Click(object sender, EventArgs e)
        {
            ViewTipoDocumento emp = new ViewTipoDocumento();
            emp.Show();
        }

        private void txtdiasvenc_KeyPress(object sender, KeyPressEventArgs e)
        {
            if ((Keys)e.KeyChar == Keys.Enter)
            {
                this.txtobs.Focus();
            }
        }
    }
}
