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
    public partial class RelCotacaoEmail : Form
    {

        private Font printFont;
        private StreamReader streamToPrint;
        public string nomefor;
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
        public string email;

        public RelCotacaoEmail()
        {
            InitializeComponent();
        }

        public RelCotacaoEmail(ViewGerarCotacao frm) : this()
        {
            codfor = frm.codfor;
            codlic = Convert.ToInt32(frm.codlic);

        }

        private void RelCotacaoEmail_Load(object sender, EventArgs e)
        {

            string reg = "Select DISTINCT Modalidade.nome as Modalidade,LancEditais.dtabertura as DtAbertura,LancEditais.vigcontratoata as Vigencia, LancEditais.vlproposta as Vlproposta,LancEditais.prazo as Prazo, Usuarios.nome as Analista, Fornecedor.nome as Fornecedor," +
             "Cliente.nome as Cliente,Cidade.uf as Uf,LancEditais.nprocesso as Processo,LancEditais.idedital as Edital,LancEditais.nlicitacao as Pregao, Fornecedor.email as Email" +
            " From Fornecedor,LancEditais,Cliente,Cidade,Modalidade,usuarios  Where  Cliente.idcliente = LancEditais.idcliente AND Cliente.idcidade= Cidade.idcidade AND  Modalidade.idmodalidade = LancEditais.idmodalidade AND Usuarios.idusu = LancEditais.idusu  AND " +
            "Fornecedor.idfornecedor=" + codfor + "  AND LancEditais.idedital='" + codlic + "'";



            DataTable ds = new DataTable();
            SqlConnection Conn = Banco.CriarConexao();
            Conn.Open();

            if (Conn.State == ConnectionState.Open)
            {
                SqlCommand cmd = new SqlCommand(reg, Conn);
                SqlDataReader dr = cmd.ExecuteReader();
                if (dr.Read())
                {

                    nomefor = dr["Fornecedor"].ToString();
                    nomecliente = dr["Cliente"].ToString();
                    uf = dr["Uf"].ToString();
                    modalidade = dr["Modalidade"].ToString();
                    processo = dr["Processo"].ToString();
                    DateTime DtP = Convert.ToDateTime(dr["DtAbertura"].ToString());
                    dtabertura = DtP.ToString("dd/MM/yyyy");
                    validade = dr["Vlproposta"].ToString();
                    prazo = dr["Prazo"].ToString();
                    vigencia = dr["Vigencia"].ToString();
                    idedital = dr["Edital"].ToString();
                    analista = dr["Analista"].ToString();
                    pregao = dr["Pregao"].ToString();
                    email = dr["Email"].ToString();




                }
            }



            // TODO: This line of code loads data into the 'DtCotacaoEmail.View_Cotacao_Email' table. You can move, or remove it, as needed.

            this.DtCotacaoEmail.EnforceConstraints = false;
            this.View_Cotacao_EmailTableAdapter.Fill(this.DtCotacaoEmail.View_Cotacao_Email);


            this.View_Cotacao_EmailTableAdapter.FillBy(this.DtCotacaoEmail.View_Cotacao_Email, codfor, codlic);
            this.reportViewer1.RefreshReport();

        }
    }
}
