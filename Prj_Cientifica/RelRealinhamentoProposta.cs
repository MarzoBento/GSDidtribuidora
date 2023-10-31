

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
    public partial class RelRealinhamentoProposta : Form
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
        public string razao;


        public RelRealinhamentoProposta()
        {
            InitializeComponent();
        }


        public RelRealinhamentoProposta(ViewPropostaRealinhada frm) : this()
        {

            codlic = Convert.ToInt32(frm.codlic);
            totalgeral = frm.totalgeral;
            decimal vlgeral = Convert.ToDecimal(frm.totalgeral);
            ExtensoGeral = Conversor.EscreverExtenso(vlgeral);

        }

        private void RelRealinhamentoProposta_Load(object sender, EventArgs e)
        {

            string reg = "Select DISTINCT Modalidade.nome as modalidade,LancEditais.dtabertura as DtAbertura,LancEditais.vigcontratoata as Vigencia, LancEditais.vlproposta as Vlproposta,LancEditais.prazo as Prazo,Usuarios.nome as Analista, Fornecedor.nome as Fornecedor," +
              " Representante.nomerep, Representante.rg,Representante.cpf,Representante.funcao,RealinhamentoProposta.vlvenda as Vlliquido,  " +
            " RealinhamentoProposta.vlvenda * RealinhamentoProposta.qtde as Total,  Cliente.nome as Cliente,Cidade.nome as Cidade,Cidade.uf as Uf,Cliente.razao as clirazao,LancEditais.nprocesso as Processo,LancEditais.idedital as Edital,LancEditais.nlicitacao as Pregao,LancEditais.hora as Hora" +
           " From Fornecedor,LancEditais,Cliente,Cidade,Modalidade,usuarios,Representante,Empresa,RealinhamentoProposta, Proposta Where Cliente.idcliente = LancEditais.idcliente AND RealinhamentoProposta.idedital =  LancEditais.idedital AND Empresa.idcidade = Cidade.idcidade AND " +
           " Modalidade.idmodalidade = LancEditais.idmodalidade AND Proposta.idfornecedor = Fornecedor.idfornecedor AND Usuarios.idusu = LancEditais.idusu  AND RealinhamentoProposta.idproposta = Proposta.idproposta AND " +
           "LancEditais.idrepresentante = Representante.idrepresentante AND  RealinhamentoProposta.idedital=" + codlic + "";



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
                    representante = dr["nomerep"].ToString();
                    cpf = dr["cpf"].ToString();
                    rg = dr["rg"].ToString();
                    funcao = dr["funcao"].ToString();
                    idedital = dr["Edital"].ToString();
                    analista = dr["Analista"].ToString();
                    pregao = dr["Pregao"].ToString();
                    DateTime DtH = DateTime.Now;
                    dthoje = DtP.ToString("dd/MM/yyyy");
                    decimal vlunit = Convert.ToDecimal(dr["Vlliquido"].ToString());
                    ExtensoUnitario = Conversor.EscreverExtenso(vlunit);
                    decimal vltot = Convert.ToDecimal(dr["Total"].ToString());
                    Extensototal = Conversor.EscreverExtenso(vltot);
                    razao = dr["clirazao"].ToString();



                }
            }

            ReportParameter[] parameters = new ReportParameter[17];
            {

                parameters[0] = new ReportParameter("Orgao", nomecliente);
                parameters[1] = new ReportParameter("Modalidade", modalidade);
                parameters[2] = new ReportParameter("DtAbertura", dtabertura);
                parameters[3] = new ReportParameter("HoraAbertura", hora);
                parameters[4] = new ReportParameter("Edital", idedital);
                parameters[5] = new ReportParameter("Usuario", representante);
                parameters[6] = new ReportParameter("Cidade", cidade);
                parameters[7] = new ReportParameter("Uf", uf);
                parameters[8] = new ReportParameter("DtHoje", dthoje);
                parameters[9] = new ReportParameter("Processo", processo);
                parameters[10] = new ReportParameter("Pregao", pregao);
                parameters[11] = new ReportParameter("rg", rg);
                parameters[12] = new ReportParameter("cpf", cpf);
                parameters[13] = new ReportParameter("funcao", funcao);
                parameters[14] = new ReportParameter("TotalGeral", totalgeral);
                parameters[15] = new ReportParameter("ExtensoGeral", ExtensoGeral);
                parameters[16] = new ReportParameter("Razao", razao);



            };
            reportViewer1.LocalReport.SetParameters(parameters);

            this.DtRealinhamento.EnforceConstraints = false;

            // TODO: This line of code loads data into the 'DtRealinhamento.View_RealinhamentoProposta' table. You can move, or remove it, as needed.
            this.View_RealinhamentoPropostaTableAdapter.Fill(this.DtRealinhamento.View_RealinhamentoProposta);

            this.View_RealinhamentoPropostaTableAdapter.FillBy(this.DtRealinhamento.View_RealinhamentoProposta, codlic);
            this.reportViewer1.RefreshReport();

           
        }
    }
}
