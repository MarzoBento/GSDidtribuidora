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
    public partial class ConsDocumentosFornecedoresAtrasados : Form
    {
        public ConsDocumentosFornecedoresAtrasados()
        {
            InitializeComponent();
        }

        private void BtnSair_Click(object sender, EventArgs e)
        {
            this.Close();
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




                SqlDataAdapter da = new SqlDataAdapter("Select DocFor.iddocfor as Cod,TipoDocumento.nome as Tipo_Documento, DocFor.dtemissao as DtEmissao,DocFor.dtvalidade as DtValidade,DATEDIFF(DAY,DtValidade,GETDATE()) as Dias,DocFor.nomearq as Arquivo,DocFor.diasvenc as Avisar " +
                    "From  DocFornecedor , DocFor, TipoDocumento WHERE TipoDocumento.idtipodocumento = DocFor.idtipodocumento AND  DocFor.iddocumento = DocFornecedor.iddocumento AND  DocFor.idfornecedor = DocFornecedor.idfornecedor AND (DATEDIFF(DAY,GETDATE(),DtValidade) < diasvenc)", Conn);

                da.Fill(ds);

                this.Grid.RowsDefaultCellStyle.BackColor = Color.PaleVioletRed;
                this.Grid.AlternatingRowsDefaultCellStyle.BackColor = Color.Plum;


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
                Grid.Columns.Add("Arquivo", "Arquivo");

                Grid.Columns[0].Width = 50;
                Grid.Columns[1].Width = 367;
                Grid.Columns[2].Width = 80;
                Grid.Columns[3].Width = 80;
                Grid.Columns[4].Width = 40;
                Grid.Columns[5].Width = 50;
                Grid.Columns[6].Width = 210;

                Grid.Columns[0].DataPropertyName = "Cod";
                Grid.Columns[1].DataPropertyName = "Tipo_Documento";
                Grid.Columns[2].DataPropertyName = "DtEmissao";
                Grid.Columns[3].DataPropertyName = "DtValidade";
                Grid.Columns[4].DataPropertyName = "Dias";
                Grid.Columns[5].DataPropertyName = "Avisar";
                Grid.Columns[6].DataPropertyName = "Arquivo";

                DataGridViewButtonColumn btn = new DataGridViewButtonColumn();
                Grid.Columns.Add(btn);
                btn.HeaderText = "Visualisar";
                btn.Text = "Visualisar";
                btn.Name = "btn";
                btn.Width = 68;
                btn.UseColumnTextForButtonValue = true;
                btn.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft;




            }

        }

        private void ConsDocumentosFornecedoresAtrasados_Load(object sender, EventArgs e)
        {
            CarregaGridFor();
        }

        private void Grid_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex == 7)
            {


                SqlConnection Cnn = Banco.CriarConexao();
                string query = "Select arq,extensao,nomearq from DocFor Where DocFor.iddocfor = " + Convert.ToInt32(Grid[0, e.RowIndex].Value.ToString());

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
