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
    public partial class RelRetFornecedor : Form
    {
      
        public string nomecliente;
        public string uf;
        public string modalidade;
        public string pregao;
        public string processo;
        public int codlic;
        public string dtabertura;
        public string prazo;
        public int codfor;
        public string vigencia;
        public string idedital;
        public string validade;
        public string analista;
        public string edital;


        public RelRetFornecedor(ViewRetornoFornecedores frm) : this()
        {
            //codfor = frm.codfor;
            codlic = Convert.ToInt32(frm.codlic);

        }


        public RelRetFornecedor()
        {
            InitializeComponent();
        }

        private void RelRetFornecedor_Load(object sender, EventArgs e)
        {
            string reg = "Select DISTINCT Modalidade.nome as Modalidade,LancEditais.dtabertura as DtAbertura,LancEditais.vigcontratoata as Vigencia, LancEditais.vlproposta as Vlproposta,LancEditais.prazo as Prazo, Usuarios.nome as Analista," +
             "Cliente.nome as Cliente,Cidade.uf as Uf,LancEditais.nprocesso as Processo,LancEditais.idedital as idedital,LancEditais.nlicitacao as Pregao,LancEditais.nlicitacao as edital" +
            " From Fornecedor,LancEditais,Cliente,Cidade,Modalidade,usuarios,ItemsLicitacao,RetCotacao  Where  Cliente.idcliente = LancEditais.idcliente AND Cliente.idcidade= Cidade.idcidade AND  Modalidade.idmodalidade = LancEditais.idmodalidade AND Usuarios.idusu = LancEditais.idusu AND Fornecedor.idfornecedor =  RetCotacao.idfornecedor  AND " +
            " LancEditais.idedital='" + codlic + "'";



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
                    uf = dr["Uf"].ToString();
                    modalidade = dr["Modalidade"].ToString();
                    processo = dr["Processo"].ToString();
                    DateTime DtP = Convert.ToDateTime(dr["DtAbertura"].ToString());
                    dtabertura = DtP.ToString("dd/MM/yyyy");
                    validade = dr["Vlproposta"].ToString();
                    prazo = dr["Prazo"].ToString();
                    vigencia = dr["Vigencia"].ToString();
                    idedital = dr["idedital"].ToString();
                    analista = dr["Analista"].ToString();
                    pregao = dr["Pregao"].ToString();
                    edital =  dr["edital"].ToString();




                }
            }

            ReportParameter[] parameters = new ReportParameter[12];
            {
              
                parameters[0] = new ReportParameter("Cliente", nomecliente);
                parameters[1] = new ReportParameter("Uf", uf);
                parameters[2] = new ReportParameter("Modalidade", modalidade);
                parameters[3] = new ReportParameter("Pregao", pregao);
                parameters[4] = new ReportParameter("Processo", processo);
                parameters[5] = new ReportParameter("Dtabertura", dtabertura);
                parameters[6] = new ReportParameter("Dtvalidade", validade);
                parameters[7] = new ReportParameter("Prazo", prazo);
                parameters[8] = new ReportParameter("Vigencia", vigencia);
                parameters[9] = new ReportParameter("edital", idedital);
                parameters[10] = new ReportParameter("usuario", analista);
                parameters[11] = new ReportParameter("nlicitacao", edital);

            };
            reportViewer1.LocalReport.SetParameters(parameters);


            this.DtRetFornecedor.EnforceConstraints = false;
            this.View_RetCotacaoTableAdapter.Fill(this.DtRetFornecedor.View_RetCotacao);

            this.View_RetCotacaoTableAdapter.FillBy(this.DtRetFornecedor.View_RetCotacao,  codlic);
            this.reportViewer1.RefreshReport();

        }
    }
}
