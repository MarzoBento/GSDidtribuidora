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
    public partial class RelOrgao : Form
    {

        public string nomecliente;
        public int codcli;
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




        public RelOrgao()
        {
            InitializeComponent();
        }


        public RelOrgao(Orgao frm) : this()
        {

            codcli = Convert.ToInt32(frm.codcli);


        }

        private void RelOrgao_Load(object sender, EventArgs e)
        {
            string reg = "Select * From View_Orgao WHERE idcliente=" + codcli + "";



            DataTable ds = new DataTable();
            SqlConnection Conn = Banco.CriarConexao();
            Conn.Open();

            if (Conn.State == ConnectionState.Open)
            {
                SqlCommand cmd = new SqlCommand(reg, Conn);
                SqlDataReader dr = cmd.ExecuteReader();
                if (dr.Read())
                {


                    nomecliente = dr["nome"].ToString();
                    cidade = dr["cidade"].ToString();
                    uf = dr["Uf"].ToString();
                    modalidade = dr["modalidade"].ToString();
                    processo = dr["nprocesso"].ToString();
                    DateTime DtP = Convert.ToDateTime(dr["DtAbertura"].ToString());
                    dtabertura = DtP.ToString("dd/MM/yyyy");
                    hora = dr["Hora"].ToString();
                    idedital = dr["idedital"].ToString();
                    pregao = dr["nlicitacao"].ToString();
                    DateTime DtH = DateTime.Now;
                    dthoje = DtP.ToString("dd/MM/yyyy");
                    razao = dr["razao"].ToString();



                }
            }

            ReportParameter[] parameters = new ReportParameter[10];
            {

                parameters[0] = new ReportParameter("Orgao", nomecliente);
                parameters[1] = new ReportParameter("Modalidadde", modalidade);
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

            this.DtOrgao.EnforceConstraints = false;

            // TODO: This line of code loads data into the 'DtOrgao.View_Orgao' table. You can move, or remove it, as needed.
            this.View_OrgaoTableAdapter.Fill(this.DtOrgao.View_Orgao);

            this.View_OrgaoTableAdapter.FillBy(this.DtOrgao.View_Orgao, codcli);
            this.reportViewer1.RefreshReport();



        }
    }
}
