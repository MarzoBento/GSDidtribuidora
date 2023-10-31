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
    public partial class MDIPrincipal : Form
    {
        private int childFormNumber = 0;

        public MDIPrincipal()
        {
            InitializeComponent();

        }

        public MDIPrincipal(ViewSenha frm)
        {
            InitializeComponent();
            nomeusuario = Convert.ToString(Banco.Nomeusu);
            tipousuario = Convert.ToString(Banco.tipousuario);
            statususuario = frm.statususu;
        }
        private string nomeusuario;
        private string tipousuario;
        private string statususuario;

        private void ShowNewForm(object sender, EventArgs e)
        {
            Form childForm = new Form();
            childForm.MdiParent = this;
            childForm.Text = "Window " + childFormNumber++;
            childForm.Show();
        }

        private void OpenFile(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.InitialDirectory = Environment.GetFolderPath(Environment.SpecialFolder.Personal);
            openFileDialog.Filter = "Text Files (*.txt)|*.txt|All Files (*.*)|*.*";
            if (openFileDialog.ShowDialog(this) == DialogResult.OK)
            {
                string FileName = openFileDialog.FileName;
            }
        }

        private void SaveAsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SaveFileDialog saveFileDialog = new SaveFileDialog();
            saveFileDialog.InitialDirectory = Environment.GetFolderPath(Environment.SpecialFolder.Personal);
            saveFileDialog.Filter = "Text Files (*.txt)|*.txt|All Files (*.*)|*.*";
            if (saveFileDialog.ShowDialog(this) == DialogResult.OK)
            {
                string FileName = saveFileDialog.FileName;
            }
        }

        private void ExitToolsStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void CutToolStripMenuItem_Click(object sender, EventArgs e)
        {
        }

        private void CopyToolStripMenuItem_Click(object sender, EventArgs e)
        {
        }

        private void PasteToolStripMenuItem_Click(object sender, EventArgs e)
        {
        }

        private void ToolBarToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //toolStrip.Visible = toolBarToolStripMenuItem.Checked;
        }

        private void StatusBarToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void CascadeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            LayoutMdi(MdiLayout.Cascade);
        }

        private void TileVerticalToolStripMenuItem_Click(object sender, EventArgs e)
        {
            LayoutMdi(MdiLayout.TileVertical);
        }

        private void TileHorizontalToolStripMenuItem_Click(object sender, EventArgs e)
        {
            LayoutMdi(MdiLayout.TileHorizontal);
        }

        private void ArrangeIconsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            LayoutMdi(MdiLayout.ArrangeIcons);
        }

        private void CloseAllToolStripMenuItem_Click(object sender, EventArgs e)
        {
            foreach (Form childForm in MdiChildren)
            {
                childForm.Close();
            }
        }

        private void MDIPrincipal_Load(object sender, EventArgs e)
        {

            ConsDocumentosFornecedoresAtrasados forncedores = new ConsDocumentosFornecedoresAtrasados();
            forncedores.TopLevel = true;
            forncedores.TopMost = true;
            forncedores.BringToFront();
            forncedores.Show();
            forncedores.Activate();
            forncedores.Focus();
            DocumentoEmpresaAtrasos empresa = new DocumentoEmpresaAtrasos();
            empresa.TopLevel = true;
            empresa.TopMost = true;
            empresa.BringToFront();
            empresa.Show();
            empresa.Activate();
            empresa.Focus();

        
        


            this.WindowState = FormWindowState.Maximized;

            ControlaMenu();


        }

        private void Item_click(Object sender, EventArgs e)
        {

            ToolStripMenuItem item = sender as ToolStripMenuItem;
            switch (item.Text)

            {

                case "Cidade":

                    bool found = false;
                    try
                    {
                        for (int i = 0; i < Application.OpenForms.Count; i++)
                        {
                            //Checks if the window is already open, and brings it to the front if it is
                            Form n = Application.OpenForms[i];
                            if (n.Name == "ViewCidade")
                            {
                                n.BringToFront();
                                found = true;
                            }
                        }
                        if (!found)
                        {
                            ViewCidade aForm = new ViewCidade();
                            aForm.Name = "ViewCidade";
                            aForm.Show();

                        }
                    }
                    catch
                    {
                    }

                    break;

                case "Fornecedor":

                    bool found2 = false;
                    try
                    {
                        for (int i = 0; i < Application.OpenForms.Count; i++)
                        {
                            //Checks if the window is already open, and brings it to the front if it is
                            Form n = Application.OpenForms[i];
                            if (n.Name == "ViewFornecedor")
                            {
                                n.BringToFront();
                                found2 = true;
                            }
                        }
                        if (!found2)
                        {
                            ViewFornecedor aForm = new ViewFornecedor();
                            aForm.Name = "ViewFornecedor";
                            aForm.Show();

                        }
                    }
                    catch
                    {
                    }

                    break;

                case "Usuario":

                    bool found3 = false;
                    try
                    {
                        for (int i = 0; i < Application.OpenForms.Count; i++)
                        {
                            //Checks if the window is already open, and brings it to the front if it is
                            Form n = Application.OpenForms[i];
                            if (n.Name == "ViewUsuarios")
                            {
                                n.BringToFront();
                                found3 = true;
                            }
                        }
                        if (!found3)
                        {
                            ViewUsuarios aForm = new ViewUsuarios();
                            aForm.Name = "ViewUsuarios";
                            aForm.Show();

                        }
                    }
                    catch
                    {
                    }

                    break;


                case "Empresa":

                    bool found4 = false;
                    try
                    {
                        for (int i = 0; i < Application.OpenForms.Count; i++)
                        {
                            //Checks if the window is already open, and brings it to the front if it is
                            Form n = Application.OpenForms[i];
                            if (n.Name == "ViewEmpresa")
                            {
                                n.BringToFront();
                                found4 = true;
                            }
                        }
                        if (!found4)
                        {
                            ViewEmpresa aForm = new ViewEmpresa();
                            aForm.Name = "ViewEmpresa";
                            aForm.Show();

                        }
                    }
                    catch
                    {
                    }



                    break;

                case "Empresa de Licitação":

                    bool found5 = false;
                    try
                    {
                        for (int i = 0; i < Application.OpenForms.Count; i++)
                        {
                            //Checks if the window is already open, and brings it to the front if it is
                            Form n = Application.OpenForms[i];
                            if (n.Name == "ViewEmpresaLicitacao")
                            {
                                n.BringToFront();
                                found5 = true;
                            }
                        }
                        if (!found5)
                        {
                            ViewEmpresaLicitacao aForm = new ViewEmpresaLicitacao();
                            aForm.Name = "ViewEmpresaLicitacao";
                            aForm.Show();

                        }
                    }
                    catch
                    {
                    }

                    break;

                case "Banco":


                    bool found6 = false;
                    try
                    {
                        for (int i = 0; i < Application.OpenForms.Count; i++)
                        {
                            //Checks if the window is already open, and brings it to the front if it is
                            Form n = Application.OpenForms[i];
                            if (n.Name == "ViewBanco")
                            {
                                n.BringToFront();
                                found6 = true;
                            }
                        }
                        if (!found6)
                        {
                            ViewBanco aForm = new ViewBanco();
                            aForm.Name = "ViewBanco";
                            aForm.Show();

                        }
                    }
                    catch
                    {
                    }

                    break;

                case "Modalidade":



                    bool found7 = false;
                    try
                    {
                        for (int i = 0; i < Application.OpenForms.Count; i++)
                        {
                            //Checks if the window is already open, and brings it to the front if it is
                            Form n = Application.OpenForms[i];
                            if (n.Name == "ViewModalidade")
                            {
                                n.BringToFront();
                                found7 = true;
                            }
                        }
                        if (!found7)
                        {
                            ViewModalidade aForm = new ViewModalidade();
                            aForm.Name = "ViewModalidade";
                            aForm.Show();

                        }
                    }
                    catch
                    {
                    }

                    break;

                case "Tipo de Documentos":


                    bool found8 = false;
                    try
                    {
                        for (int i = 0; i < Application.OpenForms.Count; i++)
                        {
                            //Checks if the window is already open, and brings it to the front if it is
                            Form n = Application.OpenForms[i];
                            if (n.Name == "ViewTipoDocumento")
                            {
                                n.BringToFront();
                                found8 = true;
                            }
                        }
                        if (!found8)
                        {
                            ViewTipoDocumento aForm = new ViewTipoDocumento();
                            aForm.Name = "ViewTipoDocumento";
                            aForm.Show();

                        }
                    }
                    catch
                    {
                    }

                    break;

                case "Regiao":


                    bool found9 = false;
                    try
                    {
                        for (int i = 0; i < Application.OpenForms.Count; i++)
                        {
                            //Checks if the window is already open, and brings it to the front if it is
                            Form n = Application.OpenForms[i];
                            if (n.Name == "ViewRegioes")
                            {
                                n.BringToFront();
                                found9 = true;
                            }
                        }
                        if (!found9)
                        {
                            ViewRegioes aForm = new ViewRegioes();
                            aForm.Name = "ViewRegioes";
                            aForm.Show();

                        }
                    }
                    catch
                    {
                    }

                    break;


                case "Representantes":

                    bool found10 = false;
                    try
                    {
                        for (int i = 0; i < Application.OpenForms.Count; i++)
                        {
                            //Checks if the window is already open, and brings it to the front if it is
                            Form n = Application.OpenForms[i];
                            if (n.Name == "ViewRepresentante")
                            {
                                n.BringToFront();
                                found10 = true;
                            }
                        }
                        if (!found10)
                        {
                            ViewRepresentante aForm = new ViewRepresentante();
                            aForm.Name = "ViewRegioes";
                            aForm.Show();

                        }
                    }
                    catch
                    {
                    }

                    break;

                case "Clientes":

                    bool found11 = false;
                    try
                    {
                        for (int i = 0; i < Application.OpenForms.Count; i++)
                        {
                            //Checks if the window is already open, and brings it to the front if it is
                            Form n = Application.OpenForms[i];
                            if (n.Name == "ViewCliente")
                            {
                                n.BringToFront();
                                found11 = true;
                            }
                        }
                        if (!found11)
                        {
                            ViewCliente aForm = new ViewCliente();
                            aForm.Name = "ViewCliente";
                            aForm.Show();

                        }
                    }
                    catch
                    {
                    }
                    break;

                case "Correlatos & Princípios Ativos":

                    bool found12 = false;
                    try
                    {
                        for (int i = 0; i < Application.OpenForms.Count; i++)
                        {
                            //Checks if the window is already open, and brings it to the front if it is
                            Form n = Application.OpenForms[i];
                            if (n.Name == "ViewPrincipioAtivo")
                            {
                                n.BringToFront();
                                found12 = true;
                            }
                        }
                        if (!found12)
                        {
                            ViewPrincipioAtivo aForm = new ViewPrincipioAtivo();
                            aForm.Name = "ViewPrincipioAtivo";
                            aForm.Show();

                        }
                    }
                    catch
                    {
                    }
                    break;

                case "Unidade de Medida":


                    bool found13 = false;
                    try
                    {
                        for (int i = 0; i < Application.OpenForms.Count; i++)
                        {
                            //Checks if the window is already open, and brings it to the front if it is
                            Form n = Application.OpenForms[i];
                            if (n.Name == "ViewUnidadeMedida")
                            {
                                n.BringToFront();
                                found13 = true;
                            }
                        }
                        if (!found13)
                        {
                            ViewUnidadeMedida aForm = new ViewUnidadeMedida();
                            aForm.Name = "ViewUnidadeMedida";
                            aForm.Show();

                        }
                    }
                    catch
                    {
                    }
                    break;


                case "Procedência":


                    bool found14 = false;
                    try
                    {
                        for (int i = 0; i < Application.OpenForms.Count; i++)
                        {
                            //Checks if the window is already open, and brings it to the front if it is
                            Form n = Application.OpenForms[i];
                            if (n.Name == "ViewProcedencia")
                            {
                                n.BringToFront();
                                found14 = true;
                            }
                        }
                        if (!found14)
                        {
                            ViewProcedencia aForm = new ViewProcedencia();
                            aForm.Name = "ViewProcedencia";
                            aForm.Show();

                        }
                    }
                    catch
                    {
                    }
                    break;

                case "Fabricante":

                    bool found15 = false;
                    try
                    {
                        for (int i = 0; i < Application.OpenForms.Count; i++)
                        {
                            //Checks if the window is already open, and brings it to the front if it is
                            Form n = Application.OpenForms[i];
                            if (n.Name == "ViewFabricante")
                            {
                                n.BringToFront();
                                found15 = true;
                            }
                        }
                        if (!found15)
                        {
                            ViewFabricante aForm = new ViewFabricante();
                            aForm.Name = "ViewFabricante";
                            aForm.Show();

                        }
                    }
                    catch
                    {
                    }
                    break;

                case "Marca":

                    bool found33 = false;
                    try
                    {
                        for (int i = 0; i < Application.OpenForms.Count; i++)
                        {
                            //Checks if the window is already open, and brings it to the front if it is
                            Form n = Application.OpenForms[i];
                            if (n.Name == "ViewMarca")
                            {
                                n.BringToFront();
                                found33 = true;
                            }
                        }
                        if (!found33)
                        {
                            ViewMarca aForm = new ViewMarca();
                            aForm.Name = "ViewMarca";
                            aForm.Show();

                        }
                    }
                    catch
                    {
                    }
                    break;


                case "Código GGREM":

                    bool found16 = false;
                    try
                    {
                        for (int i = 0; i < Application.OpenForms.Count; i++)
                        {
                            //Checks if the window is already open, and brings it to the front if it is
                            Form n = Application.OpenForms[i];
                            if (n.Name == "ViewClassificacaoFiscal")
                            {
                                n.BringToFront();
                                found16 = true;
                            }
                        }
                        if (!found16)
                        {
                            ViewClassificacaoFiscal aForm = new ViewClassificacaoFiscal();
                            aForm.Name = "ViewClassificacaoFiscal";
                            aForm.Show();

                        }
                    }
                    catch
                    {
                    }
                    break;

                case "Produtos":

                    bool found17 = false;
                    try
                    {
                        for (int i = 0; i < Application.OpenForms.Count; i++)
                        {
                            //Checks if the window is already open, and brings it to the front if it is
                            Form n = Application.OpenForms[i];
                            if (n.Name == "ViewProduto")
                            {
                                n.BringToFront();
                                found17 = true;
                            }
                        }
                        if (!found17)
                        {
                            ViewProduto aForm = new ViewProduto();
                            aForm.Name = "ViewProduto";
                            aForm.Show();

                        }
                    }
                    catch
                    {
                    }
                    break;

                case "Controle de Acessos":

                    bool found18 = false;
                    try
                    {
                        for (int i = 0; i < Application.OpenForms.Count; i++)
                        {
                            //Checks if the window is already open, and brings it to the front if it is
                            Form n = Application.OpenForms[i];
                            if (n.Name == "ViewAcesso")
                            {
                                n.BringToFront();
                                found18 = true;
                            }
                        }
                        if (!found18)
                        {
                            ViewAcesso aForm = new ViewAcesso();
                            aForm.Name = "ViewAcesso";
                            aForm.Show();

                        }
                    }
                    catch
                    {
                    }
                    break;

                case "Documento Empresa":

                    bool found19 = false;
                    try
                    {
                        for (int i = 0; i < Application.OpenForms.Count; i++)
                        {
                            //Checks if the window is already open, and brings it to the front if it is
                            Form n = Application.OpenForms[i];
                            if (n.Name == "ViewDocumentoEmp")
                            {
                                n.BringToFront();
                                found19 = true;
                            }
                        }
                        if (!found19)
                        {
                            ViewDocumentoEmp aForm = new ViewDocumentoEmp();
                            aForm.Name = "ViewDocumentoEmp";
                            aForm.Show();

                        }
                    }
                    catch
                    {
                    }
                    break;

                case "Documento Fornecedor":


                    bool found20 = false;
                    try
                    {
                        for (int i = 0; i < Application.OpenForms.Count; i++)
                        {
                            //Checks if the window is already open, and brings it to the front if it is
                            Form n = Application.OpenForms[i];
                            if (n.Name == "ViewDocFornecedor")
                            {
                                n.BringToFront();
                                found20 = true;
                            }
                        }
                        if (!found20)
                        {
                            ViewDocFornecedor aForm = new ViewDocFornecedor();
                            aForm.Name = "ViewDocFornecedor";
                            aForm.Show();

                        }
                    }
                    catch
                    {
                    }
                    break;

                case "Lançamento de Editais":


                    bool found21 = false;
                    try
                    {
                        for (int i = 0; i < Application.OpenForms.Count; i++)
                        {
                            //Checks if the window is already open, and brings it to the front if it is
                            Form n = Application.OpenForms[i];
                            if (n.Name == "ViewLancamentoEditais")
                            {
                                n.BringToFront();
                                found21 = true;
                            }
                        }
                        if (!found21)
                        {
                            ViewLancamentoEditais aForm = new ViewLancamentoEditais();
                            aForm.Name = "ViewLancamentoEditais";
                            aForm.Show();

                        }
                    }
                    catch
                    {
                    }
                    break;

                case "Departamentos":

                    bool found22 = false;
                    try
                    {
                        for (int i = 0; i < Application.OpenForms.Count; i++)
                        {
                            //Checks if the window is already open, and brings it to the front if it is
                            Form n = Application.OpenForms[i];
                            if (n.Name == "ViewDepartamento")
                            {
                                n.BringToFront();
                                found22 = true;
                            }
                        }
                        if (!found22)
                        {
                            ViewDepartamento aForm = new ViewDepartamento();
                            aForm.Name = "ViewDepartamento";
                            aForm.Show();

                        }
                    }
                    catch
                    {
                    }
                    break;

                case "Gerar Cotações":

                    bool found23 = false;
                    try
                    {
                        for (int i = 0; i < Application.OpenForms.Count; i++)
                        {
                            //Checks if the window is already open, and brings it to the front if it is
                            Form n = Application.OpenForms[i];
                            if (n.Name == "ViewGerarCotacao")
                            {
                                n.BringToFront();
                                found23 = true;
                            }
                        }
                        if (!found23)
                        {
                            ViewGerarCotacao aForm = new ViewGerarCotacao();
                            aForm.Name = "ViewGerarCotacao";
                            aForm.Show();

                        }
                    }
                    catch
                    {
                    }
                    break;

                case "Retorno de Cotações":

                    bool found24 = false;
                    try
                    {
                        for (int i = 0; i < Application.OpenForms.Count; i++)
                        {
                            //Checks if the window is already open, and brings it to the front if it is
                            Form n = Application.OpenForms[i];
                            if (n.Name == "ViewRetornoFornecedores")
                            {
                                n.BringToFront();
                                found24 = true;
                            }
                        }
                        if (!found24)
                        {
                            ViewRetornoFornecedores aForm = new ViewRetornoFornecedores();
                            aForm.Name = "ViewRetornoFornecedores";
                            aForm.Show();

                        }
                    }
                    catch
                    {
                    }
                    break;

                case "Proposta":

                    bool found25 = false;
                    try
                    {
                        for (int i = 0; i < Application.OpenForms.Count; i++)
                        {
                            //Checks if the window is already open, and brings it to the front if it is
                            Form n = Application.OpenForms[i];
                            if (n.Name == "ViewProposta")
                            {
                                n.BringToFront();
                                found25 = true;
                            }
                        }
                        if (!found25)
                        {
                            ViewProposta aForm = new ViewProposta();
                            aForm.Name = "ViewProposta";
                            aForm.Show();

                        }
                    }
                    catch
                    {
                    }
                    break;

                case "Importar Itens do Edital":

                    bool found26 = false;
                    try
                    {
                        for (int i = 0; i < Application.OpenForms.Count; i++)
                        {
                            //Checks if the window is already open, and brings it to the front if it is
                            Form n = Application.OpenForms[i];
                            if (n.Name == "ViewImportarItens")
                            {
                                n.BringToFront();
                                found26 = true;
                            }
                        }
                        if (!found26)
                        {
                            ViewImportarItens aForm = new ViewImportarItens();
                            aForm.Name = "ViewImportarItens";
                            aForm.Show();

                        }
                    }
                    catch
                    {
                    }
                    break;

                case "Realinhamento de Proposta":

                    bool found27 = false;
                    try
                    {
                        for (int i = 0; i < Application.OpenForms.Count; i++)
                        {
                            //Checks if the window is already open, and brings it to the front if it is
                            Form n = Application.OpenForms[i];
                            if (n.Name == "ViewPropostaRealinhada")
                            {
                                n.BringToFront();
                                found27 = true;
                            }
                        }
                        if (!found27)
                        {
                            ViewPropostaRealinhada aForm = new ViewPropostaRealinhada();
                            aForm.Name = "ViewPropostaRealinhada";
                            aForm.Show();

                        }
                    }
                    catch
                    {
                    }
                    break;

                case "Formação de Preços":

                    bool found28 = false;
                    try
                    {
                        for (int i = 0; i < Application.OpenForms.Count; i++)
                        {
                            //Checks if the window is already open, and brings it to the front if it is
                            Form n = Application.OpenForms[i];
                            if (n.Name == "ViewFormacaoPreco")
                            {
                                n.BringToFront();
                                found28 = true;
                            }
                        }
                        if (!found28)
                        {
                            ViewFormacaoPreco aForm = new ViewFormacaoPreco();
                            aForm.Name = "ViewFormacaoPreco";
                            aForm.Show();

                        }
                    }
                    catch
                    {
                    }
                    break;

                case "Relatório de Mapa de Preço":

                    bool found29 = false;
                    try
                    {
                        for (int i = 0; i < Application.OpenForms.Count; i++)
                        {
                            //Checks if the window is already open, and brings it to the front if it is
                            Form n = Application.OpenForms[i];
                            if (n.Name == "RelMapaPreco")
                            {
                                n.BringToFront();
                                found29 = true;
                            }
                        }
                        if (!found29)
                        {
                            RelMapaPreco aForm = new RelMapaPreco();
                            aForm.Name = "RelMapaPreco";
                            aForm.Show();

                        }
                    }
                    catch
                    {
                    }
                    break;

                case "Últimos Preços Ganho":

                    bool found30 = false;
                    try
                    {
                        for (int i = 0; i < Application.OpenForms.Count; i++)
                        {
                            //Checks if the window is already open, and brings it to the front if it is
                            Form n = Application.OpenForms[i];
                            if (n.Name == "ViewImportarItens")
                            {
                                n.BringToFront();
                                found30 = true;
                            }
                        }
                        if (!found30)
                        {
                            ViewImportarItens aForm = new ViewImportarItens();
                            aForm.Name = "ViewImportarItens";
                            aForm.Show();

                        }
                    }
                    catch
                    {
                    }
                    break;

                case "Itens Ganho Por Empresa":

                    bool found31 = false;
                    try
                    {
                        for (int i = 0; i < Application.OpenForms.Count; i++)
                        {
                            //Checks if the window is already open, and brings it to the front if it is
                            Form n = Application.OpenForms[i];
                            if (n.Name == "ViewPrecoItens")
                            {
                                n.BringToFront();
                                found31 = true;
                            }
                        }
                        if (!found31)
                        {
                            ViewPrecoItens aForm = new ViewPrecoItens();
                            aForm.Name = "ViewPrecoItens";
                            aForm.Show();

                        }
                    }
                    catch
                    {
                    }
                    break;

                case "Empenho":

                    bool found32 = false;
                    try
                    {
                        for (int i = 0; i < Application.OpenForms.Count; i++)
                        {
                            //Checks if the window is already open, and brings it to the front if it is
                            Form n = Application.OpenForms[i];
                            if (n.Name == "ViewEmpenho")
                            {
                                n.BringToFront();
                                found32 = true;
                            }
                        }
                        if (!found32)
                        {
                            ViewEmpenho aForm = new ViewEmpenho();
                            aForm.Name = "ViewEmpenho";
                            aForm.Show();

                        }
                    }
                    catch
                    {
                    }
                    break;

                case "Entrega":

                    bool found34 = false;
                    try
                    {
                        for (int i = 0; i < Application.OpenForms.Count; i++)
                        {
                            //Checks if the window is already open, and brings it to the front if it is
                            Form n = Application.OpenForms[i];
                            if (n.Name == "ViewEntrega")
                            {
                                n.BringToFront();
                                found34 = true;
                            }
                        }
                        if (!found34)
                        {
                            ViewEntrega aForm = new ViewEntrega();
                            aForm.Name = "ViewEntrega";
                            aForm.Show();

                        }
                    }
                    catch
                    {
                    }
                    break;

                case "Pesquisa de Preço":

                    bool found35 = false;
                    try
                    {
                        for (int i = 0; i < Application.OpenForms.Count; i++)
                        {
                            //Checks if the window is already open, and brings it to the front if it is
                            Form n = Application.OpenForms[i];
                            if (n.Name == "ViewMapaPreco")
                            {
                                n.BringToFront();
                                found35 = true;
                            }
                        }
                        if (!found35)
                        {
                            ViewMapaPreco aForm = new ViewMapaPreco();
                            aForm.Name = "ViewMapaPreco";
                            aForm.Show();

                        }
                    }
                    catch
                    {
                    }
                    break;

                case "Mapa de Preços":

                    bool found36 = false;
                    try
                    {
                        for (int i = 0; i < Application.OpenForms.Count; i++)
                        {
                            //Checks if the window is already open, and brings it to the front if it is
                            Form n = Application.OpenForms[i];
                            if (n.Name == "ViewImportarItens")
                            {
                                n.BringToFront();
                                found36 = true;
                            }
                        }
                        if (!found36)
                        {
                            ViewImportarItens aForm = new ViewImportarItens();
                            aForm.Name = "ViewImportarItens";
                            aForm.Show();

                        }
                    }
                    catch
                    {
                    }
                    break;

                case "Enviar Email":

                    bool found37 = false;
                    try
                    {
                        for (int i = 0; i < Application.OpenForms.Count; i++)
                        {
                            //Checks if the window is already open, and brings it to the front if it is
                            Form n = Application.OpenForms[i];
                            if (n.Name == "ViewEmail")
                            {
                                n.BringToFront();
                                found37 = true;
                            }
                        }
                        if (!found37)
                        {
                            ViewEmail aForm = new ViewEmail();
                            aForm.Name = "ViewEmail";
                            aForm.Show();

                        }
                    }
                    catch
                    {
                    }
                    break;

                case "Documentos de Fornecedores em Atraso":

                    bool found38 = false;
                    try
                    {
                        for (int i = 0; i < Application.OpenForms.Count; i++)
                        {
                            //Checks if the window is already open, and brings it to the front if it is
                            Form n = Application.OpenForms[i];
                            if (n.Name == "ConsDocumentosFornecedoresAtrasados")
                            {
                                n.BringToFront();
                                found38 = true;
                            }
                        }
                        if (!found38)
                        {
                            ConsDocumentosFornecedoresAtrasados aForm = new ConsDocumentosFornecedoresAtrasados();
                            aForm.Name = "ConsDocumentosFornecedoresAtrasados";
                            aForm.Show();

                        }
                    }
                    catch
                    {
                    }
                    break;

                case "Documentos de Empresas em Atraso":

                    bool found39 = false;
                    try
                    {
                        for (int i = 0; i < Application.OpenForms.Count; i++)
                        {
                            //Checks if the window is already open, and brings it to the front if it is
                            Form n = Application.OpenForms[i];
                            if (n.Name == "DocumentoEmpresaAtrasos")
                            {
                                n.BringToFront();
                                found39 = true;
                            }
                        }
                        if (!found39)
                        {
                            DocumentoEmpresaAtrasos aForm = new DocumentoEmpresaAtrasos();
                            aForm.Name = "DocumentoEmpresaAtrasos";
                            aForm.Show();

                        }
                    }
                    catch
                    {
                    }
                    break;

                case "Menor Preço Por Itens Ganho":

                    bool found40 = false;
                    try
                    {
                        for (int i = 0; i < Application.OpenForms.Count; i++)
                        {
                            //Checks if the window is already open, and brings it to the front if it is
                            Form n = Application.OpenForms[i];
                            if (n.Name == "ViewMenorPrecoItems")
                            {
                                n.BringToFront();
                                found40 = true;
                            }
                        }
                        if (!found40)
                        {
                            ViewMenorPrecoItems aForm = new ViewMenorPrecoItems();
                            aForm.Name = "ViewMenorPrecoItems";
                            aForm.Show();

                        }
                    }
                    catch
                    {
                    }
                    break;
                case "Pendências":

                    bool found41 = false;
                    try
                    {
                        for (int i = 0; i < Application.OpenForms.Count; i++)
                        {
                            //Checks if the window is already open, and brings it to the front if it is
                            Form n = Application.OpenForms[i];
                            if (n.Name == "ViewPendencias")
                            {
                                n.BringToFront();
                                found41 = true;
                            }
                        }
                        if (!found41)
                        {
                            ViewPendencias aForm = new ViewPendencias();
                            aForm.Name = "ViewPendencias";
                            aForm.Show();

                        }
                    }
                    catch
                    {
                    }
                    break;


                case "Concorrentes":

                    bool found42 = false;
                    try
                    {
                        for (int i = 0; i < Application.OpenForms.Count; i++)
                        {
                            //Checks if the window is already open, and brings it to the front if it is
                            Form n = Application.OpenForms[i];
                            if (n.Name == "ViewConcorrentes")
                            {
                                n.BringToFront();
                                found42 = true;
                            }
                        }
                        if (!found42)
                        {
                            ViewConcorrentes aForm = new ViewConcorrentes();
                            aForm.Name = "ViewConcorrentes";
                            aForm.Show();

                        }
                    }
                    catch
                    {
                    }
                    break;

                case "Orgao":

                    bool found43 = false;
                    try
                    {
                        for (int i = 0; i < Application.OpenForms.Count; i++)
                        {
                            //Checks if the window is already open, and brings it to the front if it is
                            Form n = Application.OpenForms[i];
                            if (n.Name == "Orgao")
                            {
                                n.BringToFront();
                                found43 = true;
                            }
                        }
                        if (!found43)
                        {
                            Orgao aForm = new Orgao();
                            aForm.Name = "Orgao";
                            aForm.Show();

                        }
                    }
                    catch
                    {
                    }
                    break;

                case "Compras":

                    bool found44 = false;
                    try
                    {
                        for (int i = 0; i < Application.OpenForms.Count; i++)
                        {
                            //Checks if the window is already open, and brings it to the front if it is
                            Form n = Application.OpenForms[i];
                            if (n.Name == "Compras")
                            {
                                n.BringToFront();
                                found44 = true;
                            }
                        }
                        if (!found44)
                        {
                            Compras aForm = new Compras();
                            aForm.Name = "Compras";
                            aForm.Show();

                        }
                    }
                    catch
                    {
                    }
                    break;


                case "MapaPreço":

                    bool found45 = false;
                    try
                    {
                        for (int i = 0; i < Application.OpenForms.Count; i++)
                        {
                            //Checks if the window is already open, and brings it to the front if it is
                            Form n = Application.OpenForms[i];
                            if (n.Name == "MapaPreço")
                            {
                                n.BringToFront();
                                found45 = true;
                            }
                        }
                        if (!found45)
                        {
                            MapaPreço aForm = new MapaPreço();
                            aForm.Name = "MapaPreço";
                            aForm.Show();

                        }
                    }
                    catch
                    {
                    }
                    break;
                case "Mapa_de_Preco_por_Itens":

                    bool found46 = false;
                    try
                    {
                        for (int i = 0; i < Application.OpenForms.Count; i++)
                        {
                            //Checks if the window is already open, and brings it to the front if it is
                            Form n = Application.OpenForms[i];
                            if (n.Name == "Mapa_de_Preco_por_Itens")
                            {
                                n.BringToFront();
                                found46 = true;
                            }
                        }
                        if (!found46)
                        {
                            Mapa_de_Preco_por_Itens aForm = new Mapa_de_Preco_por_Itens();
                            aForm.Name = "Mapa_de_Preco_por_Itens";
                            aForm.Show();

                        }
                    }
                    catch
                    {
                    }
                    break;
                case "Itens Ganho":

                    bool found47 = false;
                    try
                    {
                        for (int i = 0; i < Application.OpenForms.Count; i++)
                        {
                            //Checks if the window is already open, and brings it to the front if it is
                            Form n = Application.OpenForms[i];
                            if (n.Name == "ConsItensGanho")
                            {
                                n.BringToFront();
                                found47 = true;
                            }
                        }
                        if (!found47)
                        {
                            ConsItensGanho aForm = new ConsItensGanho();
                            aForm.Name = "ConsItensGanho";
                            aForm.Show();

                        }
                    }
                    catch
                    {
                    }
                    break;
                case "Comissões de Representantes":

                    bool found48 = false;
                    try
                    {
                        for (int i = 0; i < Application.OpenForms.Count; i++)
                        {
                            //Checks if the window is already open, and brings it to the front if it is
                            Form n = Application.OpenForms[i];
                            if (n.Name == "ViewComissao")
                            {
                                n.BringToFront();
                                found48 = true;
                            }
                        }
                        if (!found48)
                        {
                            ViewComissao aForm = new ViewComissao();
                            aForm.Name = "ViewComissao";
                            aForm.Show();

                        }
                    }
                    catch
                    {
                    }
                    break;







                    //......other code here

            }

        }

        private void Cliente_click(Object sender, EventArgs e)
        {

            //ViewCliente clientes = new ViewCliente();
            //clientes.Show();

        }


        private List<Menu> ListaDeMenus()
        {
            List<Menu> menus = new List<Menu>();

            menus.Add(new Menu() { Nome = Banco.menu, Subnome = Banco.submenu, Status = Banco.status });


            return menus;
        }


        class Menu
        {
            public string Nome { get; set; }
            public string Subnome { get; set; }
            public bool Status { get; set; }

        }


        private void ControlaMenu()
        {
            SqlConnection Cnn = Banco.CriarConexao();
            string obter = ("Select Empresa.nome as nomeemp, Empresa.idempresa,usuarios.*,Menu.menu,Menu.permissao,Menu.submenu From Usuarios, Empresa,Menu " +
                "Where  usuarios.idusu = Menu.idusu AND Menu.idempresa= Empresa.idempresa and Empresa.idempresa=" + Banco.idemp + " AND Login = '" + Banco.login + "' And Senha = '" + Banco.senha + "'");
            SqlCommand sql = new SqlCommand(obter, Cnn);
            Cnn.Open();

            DataTable dtTable = new DataTable();

            dtTable.Load(sql.ExecuteReader());

            // SqlDataReader dr = sql.ExecuteReader();


            foreach (DataRow row in dtTable.Rows)
            {


                Banco.menu = row["menu"].ToString();
                Banco.submenu = row["submenu"].ToString();
                Banco.status = Convert.ToBoolean(row["permissao"].ToString());


                Load_MenuToolStripMenuItem();

                //  HabilitaOuDesabilitaMenu(frm, mnu, Banco.menu, Banco.status);


            }


        }


        //private static void HabilitaOuDesabilitaMenu(MDIPrincipal frm, MenuStrip mnu, string menu, bool status)
        //{

        //    foreach (ToolStripMenuItem item in mnu.Items)
        //    {
        //        if (item.ToString() == menu)
        //        {
        //            item.Enabled = status;
        //        }

        //        foreach (ToolStripItem objSubItem in item.DropDownItems)
        //        {
        //            if (objSubItem.ToString() == menu)
        //            {
        //                objSubItem.Enabled = status;
        //            }
        //            //foreach (ToolStripMenuItem objSubItem2 in objSubItem.)
        //            //{
        //            //    if (objSubItem2.ToString() == menu)
        //            //    {
        //            //        objSubItem2.Enabled = status;
        //            //    }

        //            //}

        //        }

        //    }
        //}





        private void Load_MenuToolStripMenuItem()
        {
            //create count to retrieved tag or id of clicked item
            int id = 0;

            //retrieve all menu items
            foreach (Menu menu in ListaDeMenus())
            {
                //Create ToolStripMenuItem to asign values
                ToolStripMenuItem item = new ToolStripMenuItem(menu.Subnome);
                item.Tag = id;
                item.Enabled = menu.Status;
                item.ForeColor = Color.Blue;




                // incremente id to make it "unique"
                id++;

                //add ToolStripMenuItem to toolStripMenuItem1 we added in form 1


                if (Banco.menu == "Painel")
                {
                    PainelMenu.DropDownItems.Add(item);
                }
                else if (Banco.menu == "Cadastro")
                {
                    cadastroMenu.DropDownItems.Add(item);
                }
                else if (Banco.menu == "Documentos")
                {
                    docMenu.DropDownItems.Add(item);
                }
                else if (Banco.menu == "Processos Licitatórios")
                {
                    ProcessoMenu.DropDownItems.Add(item);
                }
                else if (Banco.menu == "Gerar Cotações")
                {
                    GerarCotacaoMenu.DropDownItems.Add(item);
                }
                else if (Banco.menu == "Retorno de Cotações")
                {
                    RetornoCotacaoMenu.DropDownItems.Add(item);
                }
                else if (Banco.menu == "Proposta")
                {
                    PropostaMenu.DropDownItems.Add(item);
                }

                else if (Banco.menu == "Realinhamento de Proposta")
                {
                    RealinhadaPropostaMenu.DropDownItems.Add(item);
                }
                else if (Banco.menu == "Formação de Preços")
                {
                    FormacaoMenu.DropDownItems.Add(item);
                }
                //else if (Banco.menu == "Relatórios")
                //{
                //    RelMenu.DropDownItems.Add(item);
                //}
                else if (Banco.menu == "Mapa de Preços")
                {
                    MapaMenu.DropDownItems.Add(item);
                }
                else if (Banco.menu == "Empenho")
                {
                    EmpenhoMenu.DropDownItems.Add(item);
                }
                else if (Banco.menu == "Entrega")
                {
                    EntregaMenu.DropDownItems.Add(item);
                }
                //else if (Banco.menu == "Enviar Email")
                //{
                //    MenuEmail.DropDownItems.Add(item);
                //}
                else if (Banco.menu == "Relatórios")
                {
                    RelMenu.DropDownItems.Add(item);
                }


                //set up click event for each clicked item. 
                item.Click += new EventHandler(Item_click);

            }
        }

        private void PainelMenu_Click(object sender, EventArgs e)
        {

        }

        private void toolStripMenuItem1_Click(object sender, EventArgs e)
        {

        }



        private void statusStrip_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {

        }

        private void ProcessoMenu_Click(object sender, EventArgs e)
        {

        }

        private void GerarCotacaoMenu_Click(object sender, EventArgs e)
        {

        }

        private void toolStripMenuItem1_Click_1(object sender, EventArgs e)
        {
            this.Visible = false;
            ViewSenha login = new ViewSenha();
            login.ShowDialog();
        }

        private void PropostaMenu_Click(object sender, EventArgs e)
        {

        }
    }
}






