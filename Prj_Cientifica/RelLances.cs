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
    public partial class RelLances : Form
    {

        public string nomecliente;
        public int codlic;
        public string modalidade;
        public string pregao;
        public string processo;
        public string dtabertura;
        public string idedital;
        public string validade;
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

        public RelLances()
        {
            InitializeComponent();
        }

        public RelLances(ViewProposta frm) : this()
        {

            codlic = Convert.ToInt32(frm.codlic);
            totalgeral = frm.totalgeral;
            decimal vlgeral = Convert.ToDecimal(frm.totalgeral);
            ExtensoGeral = Conversor.EscreverExtenso(vlgeral);

        }



        private void RelLances_Load(object sender, EventArgs e)
        {

            string reg = "Select DISTINCT Modalidade.nome as modalidade,LancEditais.dtabertura as DtAbertura,LancEditais.vigcontratoata as Vigencia, LancEditais.vlproposta as Vlproposta,LancEditais.prazo as Prazo," +
              " RetCotacao.liquido as Vlliquido,RetCotacao.vltotal as Total,  " +
            "Cliente.nome as Cliente,Cliente.razao as Razao,Cidade.nome as Cidade,Cidade.uf as Uf,LancEditais.nprocesso as Processo,LancEditais.idedital as Edital,LancEditais.nlicitacao as Pregao,LancEditais.hora as Hora" +
           " From LancEditais,Cliente,Cidade,Modalidade,ItemsLicitacao,RetCotacao,Empresa Where ItemsLicitacao.iditemedital = RetCotacao.iditemedital AND Cliente.idcliente = LancEditais.idcliente AND Empresa.idcidade = Cidade.idcidade AND  Modalidade.idmodalidade = LancEditais.idmodalidade AND " +
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
                    DateTime DtP = Convert.ToDateTime(dr["DtAbertura"].ToString());
                    dtabertura = DtP.ToString("dd/MM/yyyy");
                    validade = dr["Vlproposta"].ToString();
                    hora = dr["Hora"].ToString();
                    idedital = dr["Edital"].ToString();
                    pregao = dr["Pregao"].ToString();
                    DateTime DtH = DateTime.Now;
                    dthoje = DtP.ToString("dd/MM/yyyy");
                    decimal vlunit = Convert.ToDecimal(dr["Vlliquido"].ToString());
                    ExtensoUnitario = Conversor.EscreverExtenso(vlunit);
                    decimal vltot = Convert.ToDecimal(dr["Total"].ToString());
                    Extensototal = Conversor.EscreverExtenso(vltot);
                    razao = dr["razao"].ToString();



                }
                Conn.Close();
            }

            ReportParameter[] parameters = new ReportParameter[10];
            {

                parameters[0] = new ReportParameter("Orgao", nomecliente);
                parameters[1] = new ReportParameter("Modalidade", modalidade);
                parameters[2] = new ReportParameter("DtAbertura", dtabertura);
                parameters[3] = new ReportParameter("HoraAbertura", hora);
                parameters[4] = new ReportParameter("Edital", idedital);
                parameters[5] = new ReportParameter("Cidade", cidade);
                parameters[6] = new ReportParameter("Dthoje", dthoje);
                parameters[7] = new ReportParameter("Processo", processo);
                parameters[8] = new ReportParameter("Pregao", pregao);
                parameters[9] = new ReportParameter("Razao", razao);


            };
            reportViewer1.LocalReport.SetParameters(parameters);


            this.DtPropostaLancamentos.EnforceConstraints = false;
            this.View_PropostaLancamentosTableAdapter.Fill(this.DtPropostaLancamentos.View_PropostaLancamentos);

            this.View_PropostaLancamentosTableAdapter.FillBy(this.DtPropostaLancamentos.View_PropostaLancamentos, codlic);

            this.reportViewer1.RefreshReport();


        }
    }
}
