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
    public partial class Map_de_Preço_por_Itens : Form
    {
        public Map_de_Preço_por_Itens()
        {
            InitializeComponent();
        }
        public int codproduto;

        public Map_de_Preço_por_Itens(Mapa_de_Preco_por_Itens frm) : this()
        {

            codproduto = Convert.ToInt32(frm.codproduto);


        }


        private void Map_de_Preço_por_Itens_Load(object sender, EventArgs e)
        {

            this.DtMapaPrecoItens.EnforceConstraints = false;
            // TODO: This line of code loads data into the 'DtMapaPrecoItens.View_Mapa_de_Preco_por_Item' table. You can move, or remove it, as needed.
            this.View_Mapa_de_Preco_por_ItemTableAdapter.Fill(this.DtMapaPrecoItens.View_Mapa_de_Preco_por_Item);

            this.View_Mapa_de_Preco_por_ItemTableAdapter.FillBy(this.DtMapaPrecoItens.View_Mapa_de_Preco_por_Item, codproduto);
            this.reportViewer1.RefreshReport();

        }
    }
}
