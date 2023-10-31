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
    public partial class ConsGerarCotacao : Form
    {
        string strConn;
        public string codedital;
        public static string nomeFor;
        public string edittal;
        public int idedital;
        public ConsGerarCotacao()
        {
            InitializeComponent();
        }

        public ConsGerarCotacao(ViewRetornoFornecedores frm) : this()
        {
            nomeFor = Convert.ToString(frm.nomeFor);

        }

        public ConsGerarCotacao(ViewGerarCotacao frm) : this()
        {
            nomeFor = Convert.ToString(frm.nomeFor);

        }

        public ConsGerarCotacao(ViewFormacaoPreco frm) : this()
        {
            nomeFor = Convert.ToString(frm.nomeFor);

        }


        public ConsGerarCotacao(ViewProposta frm) : this()
        {
            nomeFor = Convert.ToString(frm.nomeFor);

        }

        public ConsGerarCotacao(ViewPropostaRealinhada frm) : this()
        {
            nomeFor = Convert.ToString(frm.nomeFor);

        }

        public ConsGerarCotacao(ViewPendencias frm) : this()
        {
            nomeFor = Convert.ToString(frm.nomeFor);

        }

        public ConsGerarCotacao(ViewImportarItens frm) : this()
        {
            nomeFor = Convert.ToString(frm.nomeFor);

        }
        public ConsGerarCotacao(ViewPrecoItens frm) : this()
        {
            nomeFor = Convert.ToString(frm.nomeFor);

        }




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

                if (this.chkCliente.Checked == true)
                {

                    strConn = "Select idedital as NrEdital, nlicitacao as Edital, nome as Cliente,nprocesso as NºProcesso" +
                " from Cliente,LancEditais Where Cliente.idcliente = LancEditais.idcliente and  Cliente.nome   Like'" + txtpesquisa.Text + "%' Order by Cliente.nome";
                }
                else if (chkProcesso.Checked == true)
                {

                    strConn = "Select idedital as NrEdital, nlicitacao as Edital, nome as Cliente,nprocesso as NºProcesso" +
               " from Cliente,LancEditais Where  Cliente.idcliente = LancEditais.idcliente and LancEditais.nprocesso Like'" + txtpesquisa.Text + "%' Order by  Cliente.nome";


                }

                else if (this.chknedital.Checked == true)
                {

                    strConn = "Select idedital as NrEdital, nlicitacao as Edital, nome as Cliente,nprocesso as NºProcesso" +
               " from Cliente,LancEditais Where  Cliente.idcliente = LancEditais.idcliente and LancEditais.idedital Like'" + txtpesquisa.Text + "%' Order by  Cliente.nome";


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
            DtGConsulta.Columns.Add("NrEdital", "NrEdital");
            DtGConsulta.Columns.Add("Edital", "Edital");
            DtGConsulta.Columns.Add("Cliente", "Cliente");
            DtGConsulta.Columns.Add("NºProcesso", "NºProcesso");
            DtGConsulta.Columns[0].Width = 80;
            DtGConsulta.Columns[1].Width = 80;
            DtGConsulta.Columns[2].Width = 485;
            DtGConsulta.Columns[3].Width = 110;
            DtGConsulta.Columns[0].DataPropertyName = "NrEdital";
            DtGConsulta.Columns[1].DataPropertyName = "Edital";
            DtGConsulta.Columns[2].DataPropertyName = "Cliente";
            DtGConsulta.Columns[3].DataPropertyName = "NºProcesso";
            DtGConsulta.Refresh();

        }

        private void txtpesquisa_TextChanged(object sender, EventArgs e)
        {
            carregarGrid();
        }

        private void DtGConsulta_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {

            if (nomeFor == "ViewRetornoFornecedores")
            {
                codedital = DtGConsulta[0, e.RowIndex].Value.ToString();
                bool found = false;
                try
                {
                    for (int i = 0; i < Application.OpenForms.Count; i++)
                    {
                        //Checks if the window is already open, and brings it to the front if it is
                        Form n = Application.OpenForms[i];
                        if (n.Name == "ViewRetornoFornecedores")
                        {
                            n.BringToFront();
                            found = true;
                        }
                    }
                    if (!found)
                    {
                        ViewRetornoFornecedores aForm = new ViewRetornoFornecedores(this);
                        aForm.Name = "ViewRetornoFornecedores";
                        aForm.Show();
                        this.Close();
                    }
                }
                catch
                {
                }


            }
            else if (nomeFor == "ViewGerarCotacao")
            {
                codedital = DtGConsulta[0, e.RowIndex].Value.ToString();
                bool found = false;
                try
                {
                    for (int i = 0; i < Application.OpenForms.Count; i++)
                    {
                        //Checks if the window is already open, and brings it to the front if it is
                        Form n = Application.OpenForms[i];
                        if (n.Name == "ViewGerarCotacao")
                        {
                            n.BringToFront();
                            found = true;
                        }
                    }
                    if (!found)
                    {
                        ViewGerarCotacao aForm = new ViewGerarCotacao(this);
                        aForm.Name = "ViewGerarCotacao";
                        aForm.Show();
                        this.Close();
                    }
                }
                catch
                {
                }


            }
            else if (nomeFor == "ViewProposta")
            {
                codedital = DtGConsulta[0, e.RowIndex].Value.ToString();
                edittal =  DtGConsulta[1, e.RowIndex].Value.ToString();
                bool found = false;
                try
                {
                    for (int i = 0; i < Application.OpenForms.Count; i++)
                    {
                        //Checks if the window is already open, and brings it to the front if it is
                        Form n = Application.OpenForms[i];
                        if (n.Name == "ViewProposta")
                        {
                            n.BringToFront();
                            found = true;
                        }
                    }
                    if (!found)
                    {
                        ViewProposta aForm = new ViewProposta(this);
                        aForm.Name = "ViewProposta";
                        aForm.Show();
                        this.Close();
                    }
                }
                catch
                {


                }


            }

            else if (nomeFor == "ViewFormacaoPreco")
            {
                codedital = DtGConsulta[0, e.RowIndex].Value.ToString();
                bool found = false;
                try
                {
                    for (int i = 0; i < Application.OpenForms.Count; i++)
                    {
                        //Checks if the window is already open, and brings it to the front if it is
                        Form n = Application.OpenForms[i];
                        if (n.Name == "ViewFormacaoPreco")
                        {
                            n.BringToFront();
                            found = true;
                        }
                    }
                    if (!found)
                    {
                        ViewFormacaoPreco aForm = new ViewFormacaoPreco(this);
                        aForm.Name = "ViewFormacaoPreco";
                        aForm.Show();
                        this.Close();
                    }
                }
                catch
                {
                }



            }
            else if (nomeFor == "ViewPendencias")
            {
                idedital = Convert.ToInt32(DtGConsulta[0, e.RowIndex].Value.ToString());
                codedital = DtGConsulta[1, e.RowIndex].Value.ToString();
                bool found = false;
                try
                {
                    for (int i = 0; i < Application.OpenForms.Count; i++)
                    {
                        //Checks if the window is already open, and brings it to the front if it is
                        Form n = Application.OpenForms[i];
                        if (n.Name == "ViewPendencias")
                        {
                            n.BringToFront();
                            found = true;
                        }
                    }
                    if (!found)
                    {
                        ViewPendencias aForm = new ViewPendencias(this);
                        aForm.Name = "ViewPendencias";
                        aForm.Show();
                        this.Close();
                    }
                }
                catch
                {
                }



            }
            else if (nomeFor == "ViewImportarItens")
            {
                codedital = DtGConsulta[0, e.RowIndex].Value.ToString();
                bool found = false;
                try
                {
                    for (int i = 0; i < Application.OpenForms.Count; i++)
                    {
                        //Checks if the window is already open, and brings it to the front if it is
                        Form n = Application.OpenForms[i];
                        if (n.Name == "ViewImportarItens")
                        {
                            n.BringToFront();
                            found = true;
                        }
                    }
                    if (!found)
                    {
                       ViewImportarItens aForm = new ViewImportarItens(this);
                        aForm.Name = "ViewImportarItens";
                        aForm.Show();
                        this.Close();
                    }
                }
                catch
                {
                }




            }
            else if (nomeFor == "ViewPrecoItens")
            {
                codedital = DtGConsulta[1, e.RowIndex].Value.ToString();
                bool found = false;
                try
                {
                    for (int i = 0; i < Application.OpenForms.Count; i++)
                    {
                        //Checks if the window is already open, and brings it to the front if it is
                        Form n = Application.OpenForms[i];
                        if (n.Name == "ViewPrecoItens")
                        {
                            n.BringToFront();
                            found = true;
                        }
                    }
                    if (!found)
                    {
                        ViewPrecoItens aForm = new ViewPrecoItens(this);
                        aForm.Name = "ViewPrecoItens";
                        aForm.Show();
                        this.Close();
                    }
                }
                catch
                {
                }




            }
            else if (nomeFor == "ViewPropostaRealinhada")
            {
                codedital = DtGConsulta[0, e.RowIndex].Value.ToString();
                edittal = DtGConsulta[1, e.RowIndex].Value.ToString();

                bool found = false;
                try
                {
                    for (int i = 0; i < Application.OpenForms.Count; i++)
                    {
                        //Checks if the window is already open, and brings it to the front if it is
                        Form n = Application.OpenForms[i];
                        if (n.Name == "ViewPropostaRealinhada")
                        {
                            n.BringToFront();
                            found = true;
                        }
                    }
                    if (!found)
                    {
                        ViewPropostaRealinhada aForm = new ViewPropostaRealinhada(this);
                        aForm.Name = "ViewPropostaRealinhada";
                        aForm.Show();
                        this.Close();
                    }
                }
                catch
                {
                    MessageBox.Show("Não Existe Realinhamento de Proposta para esse Edital!");

                }





            }



        }

        private void BtnSair_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void BtnLimpar_Click(object sender, EventArgs e)
        {
            txtpesquisa.Text = "";
            DtGConsulta.DataSource = null;
            this.chknedital.Checked = true;
            chkProcesso.Checked = false;
            chkCliente.Checked = false;
            DtGConsulta.Refresh();
        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }

        private void ConsGerarCotacao_Load(object sender, EventArgs e)
        {
            this.chknedital.Checked = true;
        }
    }
}
