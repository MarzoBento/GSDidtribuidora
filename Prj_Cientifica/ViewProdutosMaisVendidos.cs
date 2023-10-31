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
    public partial class ViewProdutosMaisVendidos : Form
    {
        public ViewProdutosMaisVendidos()
        {
            InitializeComponent();
        }

        private void dtini_ValueChanged(object sender, EventArgs e)
        {
            this.mskdtini.Text = dtini.Value.ToString("dd/MM/yyyy");
        }

        private void dtfim_ValueChanged(object sender, EventArgs e)
        {
            this.mskdtfim.Text = dtfim.Value.ToString("dd/MM/yyyy");
        }

        private void btnBusca_Click(object sender, EventArgs e)
        {
            string dtini = Convert.ToDateTime(mskdtini.Text).ToString("yyyy-MM-dd");
            string dtfim = Convert.ToDateTime(mskdtfim.Text).ToString("yyyy-MM-dd");

            this.view_Mais_VendidosTableAdapter.FillBy(this.dtMaisVendidos.View_Mais_Vendidos, dtini, dtfim);

            chart1.DataBind();
        }

        private void ViewProdutosMaisVendidos_Load(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'dtMaisVendidos.View_Mais_Vendidos' table. You can move, or remove it, as needed.
            //this.view_Mais_VendidosTableAdapter.Fill(this.dtMaisVendidos.View_Mais_Vendidos);
            // TODO: This line of code loads data into the 'dtMais_Vendidos.View_Mais_Vendidos' table. You can move, or remove it, as needed.
            // TODO: This line of code loads data into the 'cientificaDataSet.View_Mais_Vendidos' table. You can move, or remove it, as needed.

            // TODO: This line of code loads data into the 'dtMaisVendidos.View_Mais_Vendidos' table. You can move, or remove it, as needed.




        }
    }
}
