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
    public partial class RelMapa : Form
    {
        public RelMapa()
        {
            InitializeComponent();
        }

        public int codlic;

        public RelMapa(MapaPreço frm) : this()
        {

            codlic = Convert.ToInt32(frm.codedital);
          

        }

        private void RelMapa_Load(object sender, EventArgs e)
        {
            this.DtMapaPreco.EnforceConstraints = false;

            // TODO: This line of code loads data into the 'DtMapaPreco.View_Mapa_de_Preco' table. You can move, or remove it, as needed.
            this.View_Mapa_de_PrecoTableAdapter.Fill(this.DtMapaPreco.View_Mapa_de_Preco);

            this.View_Mapa_de_PrecoTableAdapter.FillBy(this.DtMapaPreco.View_Mapa_de_Preco, codlic);
            this.reportViewer1.RefreshReport();

        }
    }
}
