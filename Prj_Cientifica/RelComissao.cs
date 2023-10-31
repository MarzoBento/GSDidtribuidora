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
    public partial class RelComissao : Form
    {

        public string dtinicio;
        public string dtfim;
        public int codrep;
        public int status;

        public RelComissao()
        {
            InitializeComponent();
        }

        public RelComissao(ViewComissao frm) : this()
        {


            dtinicio = frm.dtini;
            dtfim = frm.dtfim;
            codrep = frm.codrep;
            status = frm.status;


        }


        private void RelComissao_Load(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'DtComissao.View_Comissao' table. You can move, or remove it, as needed.
            if (status == 1)
            {
                this.DtComissao.EnforceConstraints = false;

                this.View_ComissaoTableAdapter.FillBy1(this.DtComissao.View_Comissao, dtinicio, dtfim);
            }
            else if (status == 2)
            {
                this.DtComissao.EnforceConstraints = false;

                this.View_ComissaoTableAdapter.FillBy(this.DtComissao.View_Comissao, dtinicio, dtfim, codrep);

            }

            this.reportViewer1.RefreshReport();




        }
    }
}
