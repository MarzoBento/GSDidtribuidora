using Microsoft.Reporting.WinForms;
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
    public partial class RelCompras : Form
    {
        public string nomecliente;
        public int codlic;
        public string modalidade;
        public string pregao;
        public string processo;
        public string dtabertura;
        public string idedital;
        public string estado;
        public string analista;
        public string uf;
        public string cidade;
        public string dthoje;
        public string hora;
        public string representante;
        public string cpf;
        public string rg;
        public string funcao;
        public string totalgeral;
        public string ExtensoUnitario;
        public string Extensototal;
        public string ExtensoGeral;
        public string imprimir;
        public string razao;
        public string NomeFantasia;



        public RelCompras(Compras frm) : this()
        {

            codlic = Convert.ToInt32(frm.codedital);


        }


        public RelCompras()
        {
            InitializeComponent();
        }

        private void RelCompras_Load(object sender, EventArgs e)
        {
            string reg = "Select DISTINCT Modalidade.nome as modalidade,LancEditais.dtabertura as DtAbertura,LancEditais.vigcontratoata as Vigencia, LancEditais.vlproposta as Vlproposta,LancEditais.prazo as Prazo, Usuarios.nome as Analista, Fornecedor.nome as Fornecedor," +
             " Representante.nomerep, Representante.rg,Representante.cpf,Representante.funcao,RetCotacao.liquido as Vlliquido,RetCotacao.vltotal as Total,  " +
           "Cliente.nome as Cliente,Cliente.razao as Razao,Cliente.estado as Estado,Cidade.nome as Cidade,Cidade.uf as Uf,LancEditais.nprocesso as Processo,LancEditais.idedital as Edital,LancEditais.nlicitacao as Pregao,LancEditais.hora as Hora" +
          " From Fornecedor,LancEditais,Cliente,Cidade,Modalidade,usuarios,Representante,ItemsLicitacao,RetCotacao,Empresa " +
          "Where ItemsLicitacao.iditemedital = RetCotacao.iditemedital AND Cliente.idcliente = LancEditais.idcliente AND Empresa.idcidade = Cidade.idcidade AND " +
          "Modalidade.idmodalidade = LancEditais.idmodalidade AND Usuarios.idusu = LancEditais.idusu  AND LancEditais.idrepresentante = Representante.idrepresentante AND " +
          " LancEditais.idedital=" + codlic + "";



            DataTable ds = new DataTable();
            SqlConnection Conn = Banco.CriarConexao();
            Conn.Open();

            if (Conn.State == ConnectionState.Open)
            {
                SqlCommand cmd = new SqlCommand(reg, Conn);
                SqlDataReader dr = cmd.ExecuteReader();
                if (dr.Read())
                {


                    nomecliente = dr["Cliente"].ToString();
                    cidade = dr["cidade"].ToString();
                    uf = dr["Uf"].ToString();
                    modalidade = dr["modalidade"].ToString();
                    processo = dr["Processo"].ToString();
                    estado = dr["Estado"].ToString();
                    idedital = dr["Edital"].ToString();
                    pregao = dr["Pregao"].ToString();
                    razao = dr["razao"].ToString();



                }

                Conn.Close();
              
            }

            ReportParameter[] parameters = new ReportParameter[9];
            {

                parameters[0] = new ReportParameter("Orgao", nomecliente);
                parameters[1] = new ReportParameter("Modalidade", modalidade);
                parameters[2] = new ReportParameter("Edital", idedital);
                parameters[3] = new ReportParameter("Cidade", cidade);
                parameters[4] = new ReportParameter("Uf", uf);
                parameters[5] = new ReportParameter("Processo", processo);
                parameters[6] = new ReportParameter("Pregao", pregao);
                parameters[7] = new ReportParameter("Estado", estado);
                parameters[8] = new ReportParameter("Razao", razao);


            };
            reportViewer1.LocalReport.SetParameters(parameters);


            // TODO: This line of code loads data into the 'DtProposta.View_Proposta' table. You can move, or remove it, as needed.
            this.DtCompras.EnforceConstraints = false;

            this.View_ComprasTableAdapter.Fill(this.DtCompras.View_Compras);


            this.View_ComprasTableAdapter.FillBy(this.DtCompras.View_Compras, codlic);
            this.reportViewer1.RefreshReport();


        }
    }
}
