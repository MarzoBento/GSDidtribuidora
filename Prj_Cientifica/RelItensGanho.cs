using Microsoft.Reporting.WinForms;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Prj_Cientifica
{
    public partial class RelItensGanho : Form
    {
        public string Produto;
        public string Fornecedor;
        public string OrgaoG;
        public int idproduto;
        public int idfornecedor;
        public int idcliente;
        public string UF;
        public int opcao;
        public string totalitens;
        public string totalproduto;


        public RelItensGanho()
        {
            InitializeComponent();
        }



        public RelItensGanho(ConsItensGanho frm) : this()
        {

            idproduto = frm.idproduto;
            idfornecedor = frm.idfornecedor;
            idcliente = frm.idcliente;
            UF = frm.UF;
            opcao = frm.opcao;
            totalitens = frm.totalitens;
            totalproduto = frm.totalproduto;
        }

        private void RelItensGanho_Load(object sender, EventArgs e)
        {

            ReportParameter[] parameters = new ReportParameter[2];
            {

                parameters[0] = new ReportParameter("TotalItens", totalitens);
                parameters[1] = new ReportParameter("TotalProduto", totalproduto);


            };
            reportViewer1.LocalReport.SetParameters(parameters);





            // TODO: This line of code loads data into the 'DtGanhou.View_Ganhou' table. You can move, or remove it, as needed.
            this.View_GanhouTableAdapter.Fill(this.DtGanhou.View_Ganhou);

            if (opcao == 1)
            {
                this.View_GanhouTableAdapter.FillBy(this.DtGanhou.View_Ganhou, idproduto);
            }
            else if (opcao == 2)
            {

                this.View_GanhouTableAdapter.FillBy1(this.DtGanhou.View_Ganhou, idfornecedor);

            }
            else if (opcao == 3)
            {

                this.View_GanhouTableAdapter.FillBy2(this.DtGanhou.View_Ganhou, idcliente);


            }
            else if (opcao == 4)
            {

                this.View_GanhouTableAdapter.FillBy3(this.DtGanhou.View_Ganhou, UF);


            }
            else if (opcao == 5)
            {

                this.View_GanhouTableAdapter.Fill(this.DtGanhou.View_Ganhou);


            }


            this.reportViewer1.RefreshReport();

        }
    }
}
