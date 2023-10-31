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
    public partial class RelInformacaoEdital : Form
    {
        public int idedital;
        public string modalidade;
        public string nlicitacao;
        public string empresa;
        public string razao;
        public string nprocesso;
        public string dtlimite;
        public string portal;
        public string objeto;
        public string hora;
        public string dtabertura;
        public string tipoproposta;
        public string responsavelproposta;
        public string responsaveldocumentacao;
        public string validaddeproposta;
        public string prazo;
        public int idedt;
        





        public RelInformacaoEdital()
        {
            InitializeComponent();
        }






        public RelInformacaoEdital(ViewLancamentoEditais frm) : this()
        {

            idedt = Convert.ToInt32(frm.idedital);
   


        }

        private void RelInformacaoEdital_Load(object sender, EventArgs e)
        {


            string reg = "Select * From  View_LancamentoEditais Where idedital  =" + idedt + "";

            DataTable ds = new DataTable();
            SqlConnection Conn = Banco.CriarConexao();
            Conn.Open();

            if (Conn.State == ConnectionState.Open)
            {
                SqlCommand cmd = new SqlCommand(reg, Conn);
                SqlDataReader dr = cmd.ExecuteReader();
                if (dr.Read())
                {
                    idedital = Convert.ToInt32(dr["idedital"].ToString());
                    nlicitacao = dr["nlicitacao"].ToString();
                    modalidade = dr["nome"].ToString();
                    empresa = dr["Empresa"].ToString();
                    razao = dr["razao"].ToString();
                    nprocesso = dr["nprocesso"].ToString();
                    DateTime DtLimite = Convert.ToDateTime(dr["dtlimite"].ToString());
                    dtlimite = DtLimite.ToString("dd/MM/yyyy");
                    portal = dr["portal"].ToString();
                    objeto = dr["objeto"].ToString();
                    hora = dr["hora"].ToString();
                    DateTime Dtabt = Convert.ToDateTime(dr["dtabertura"].ToString());
                    dtabertura = Dtabt.ToString("dd/MM/yyyy");
                    tipoproposta = dr["tipoproposta"].ToString();
                    responsavelproposta = dr["RespProposta"].ToString();
                    responsaveldocumentacao = dr["RespDoc"].ToString();
                    validaddeproposta = dr["vlproposta"].ToString();
                    prazo = dr["prazo"].ToString();
                    


                }
            }

            ReportParameter[] parameters = new ReportParameter[16];
            {

                parameters[0] = new ReportParameter("codigoedital", Convert.ToString(idedital));
                parameters[1] = new ReportParameter("empresa", empresa);
                parameters[2] = new ReportParameter("cliente", razao);
                parameters[3] = new ReportParameter("modalidade", modalidade);
                parameters[4] = new ReportParameter("nedital", nlicitacao);
                parameters[5] = new ReportParameter("nprocesso", nprocesso);
                parameters[6] = new ReportParameter("dtlimite", dtlimite);
                parameters[7] = new ReportParameter("portal", portal);
                parameters[8] = new ReportParameter("objeto", objeto);
                parameters[9] = new ReportParameter("hora", hora);
                parameters[10] = new ReportParameter("abertura", dtabertura);
                parameters[11] = new ReportParameter("tipoproposta", tipoproposta);
                parameters[12] = new ReportParameter("responsavelproposta", responsavelproposta);
                parameters[13] = new ReportParameter("validadeproposta", validaddeproposta);
                parameters[14] = new ReportParameter("prazoentrega", prazo);
                parameters[15] = new ReportParameter("responsaveldocumento", responsaveldocumentacao);


            };
            reportViewer1.LocalReport.SetParameters(parameters);




            this.reportViewer1.RefreshReport();


        }
    }
}
