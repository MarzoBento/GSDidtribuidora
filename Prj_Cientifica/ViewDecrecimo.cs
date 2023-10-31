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

    public partial class ViewDecrecimo : Form
    {

        public List<Decrescimos> listDecrescimos = new List<Decrescimos>();

        public ViewDecrecimo()
        {
            InitializeComponent();
        }



        public ViewDecrecimo(ViewProposta frmdec)
        {
            InitializeComponent();
            listDecrescimos = frmdec.list;
        }





        private void btnDecrecimo_Click(object sender, EventArgs e)
        {


            for (int i = 0; i < listDecrescimos.Count; i++)
            {

                Decrescimos decrescimos = new Decrescimos();
                decrescimos.idproposta = listDecrescimos[i].idproposta;
                decrescimos.iditemedital = listDecrescimos[i].iditemedital;
                decrescimos.casasdecimais = listDecrescimos[i].casasdecimais;


                decimal porcent = Convert.ToDecimal(txtdecrescimo.Text);
                decrescimos.decrecimo = Convert.ToDecimal(porcent);
              decimal dec = ((listDecrescimos[i].precovenda - (porcent * listDecrescimos[i].precovenda / 100)));
                if (decrescimos.casasdecimais == 2)
                {

                    string vldecrescimo = String.Format("{0:N2}", Math.Round(Convert.ToDouble(dec), 2));
                    decrescimos.precovenda = Convert.ToDecimal(vldecrescimo);
                }
                else if (decrescimos.casasdecimais == 3)
                {
                    string vldecrescimo = String.Format("{0:N3}", (Convert.ToDouble(dec)));
                    decrescimos.precovenda = Convert.ToDecimal(vldecrescimo);
                }
                else if (decrescimos.casasdecimais == 4)
                {
                    string vldecrescimo = String.Format("{0:N4}", (Convert.ToDouble(dec)));
                    decrescimos.precovenda = Convert.ToDecimal(vldecrescimo);
                }

                try
                {


                    PsDecrescimo DAODecrescimo = new PsDecrescimo();
                    DAODecrescimo.Alterar(decrescimos);
                    DAODecrescimo.Incluir(decrescimos);




                }
                catch (Exception erro)
                {

                    throw erro;
                }
            }



        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void txtdecrescimo_KeyPress(object sender, KeyPressEventArgs e)
        {
            if ((Keys)e.KeyChar == Keys.Enter)
            {
                this.btnDecrecimo.Focus();
            }

        }
    }
}

