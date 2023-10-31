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
    public partial class ViewInformacaoEmpenho : Form
    {
        public int codigoitem;
        public string edital;


        public ViewInformacaoEmpenho()
        {
            InitializeComponent();
        }


        public ViewInformacaoEmpenho(ViewPropostaRealinhada frm) : this()
        {
            edital = Convert.ToString(frm.editalempenho);
            codigoitem = Convert.ToInt32(frm.coditemempenho);
            CarregaGridArquivos(edital, codigoitem);


        }

        private void CarregaGridArquivos(string edt,int codiditemedital)
        {


            //define o dataset

            System.Data.DataTable ds = new System.Data.DataTable();


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



                SqlDataAdapter da = new SqlDataAdapter("Select DISTINCT Produto.nome as Descrição,DocumentoEmpenho.iddocempenho as Cod,DocumentoEmpenho.nomearq as Documento," +
                    "DocumentoEmpenho.iditemedital as coditemedt,DocumentoEmpenho.Data as Data,DocumentoEmpenho.statusitem as Status  " +
                " from DocumentoEmpenho,EmpenhoItems,ItemsLicitacao,Produto Where ItemsLicitacao.idproduto =  Produto.idproduto and  ItemsLicitacao.iditemedital = DocumentoEmpenho.iditemedital And  " +
                "EmpenhoItems.edital = DocumentoEmpenho.edital AND EmpenhoItems.iditemedital = DocumentoEmpenho.iditemedital AND DocumentoEmpenho.edital ='" + edt + "' AND DocumentoEmpenho.iditemedital= " + codiditemedital + "  Order by Documento ASC ", Conn);

                da.Fill(ds);


                this.Grid.RowsDefaultCellStyle.BackColor = Color.LightBlue;
                this.Grid.AlternatingRowsDefaultCellStyle.BackColor = Color.Azure;

                //exibe os dados no datagridview
                Grid.AutoGenerateColumns = false;
                Grid.DataSource = ds;
                Grid.Columns.Clear();
                Grid.Columns.Add("Descrição", "Descrição");
                Grid.Columns.Add("Cod", "Cod");
                Grid.Columns.Add("Documento", "Documento");
                Grid.Columns.Add("coditemedt", "coditemedt");
                Grid.Columns.Add("Data", "Data");
                Grid.Columns.Add("Status", "Status");

                Grid.Columns[0].Width = 395;
                Grid.Columns[1].Visible = false;
                Grid.Columns[2].Width = 400;
                Grid.Columns[3].Visible = false;
                Grid.Columns[4].Width = 90;
                Grid.Columns[5].Width = 300;

                Grid.Columns[0].DataPropertyName = "Descrição";
                Grid.Columns[1].DataPropertyName = "Cod";
                Grid.Columns[2].DataPropertyName = "Documento";
                Grid.Columns[3].DataPropertyName = "coditemedt";
                Grid.Columns[4].DataPropertyName = "Data";
                Grid.Columns[5].DataPropertyName = "Status";

                DataGridViewButtonColumn btn = new DataGridViewButtonColumn();
                Grid.Columns.Add(btn);
                btn.HeaderText = "Documento";
                btn.Text = "Ver Documento";
                btn.Name = "btn";
                btn.Width = 105;
                btn.UseColumnTextForButtonValue = true;
                btn.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft;


            }

        }

        private void BtnSair_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void Grid_CellClick(object sender, DataGridViewCellEventArgs e)
        {

            if (e.RowIndex >= 0 && e.ColumnIndex == 6)
            {
                int codarquivo = Convert.ToInt32(Grid.CurrentRow.Cells[1].Value.ToString());


                SqlConnection Cnn = Banco.CriarConexao();
                string query = "Select arq,extensao,nomearq from DocumentoEmpenho Where DocumentoEmpenho.iddocempenho = " + Convert.ToInt32(Grid[1, e.RowIndex].Value.ToString());

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
        }
    }
}
