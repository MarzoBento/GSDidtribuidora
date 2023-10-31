using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Data.Common;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Prj_Cientifica
{
    public class DAOUsuarioMenu
    {


        public static void ControleMenu()
        {


            SqlConnection Cnn = Banco.CriarConexao();
            string obter = ("Select Empresa.nome as nomeemp, Empresa.idempresa,usuarios.*,Menu.menu,Menu.permissao From Usuarios, Empresa,Menu " +
                "Where  usuarios.idusu = Menu.idusu AND  Empresa.idempresa=" + Banco.idemp + " AND Login = '" + Banco.login + "' And Senha = '" + Banco.senha + "'");
            SqlCommand sql = new SqlCommand(obter, Cnn);
            Cnn.Open();

            DataTable dtTable = new DataTable();

            dtTable.Load(sql.ExecuteReader());

            // SqlDataReader dr = sql.ExecuteReader();


           

            MDIPrincipal frm = new MDIPrincipal();



            foreach (DataRow row in dtTable.Rows)
            {


                MenuStrip mnu = (MenuStrip)frm.Controls["menuStrip"];



                Banco.menu = row["menu"].ToString();
                Banco.status = Convert.ToBoolean(row["permissao"].ToString());

                HabilitaOuDesabilitaMenu(frm,mnu,Banco.menu, Banco.status);

                
                //ToolStripMenuItem menus =  mnu.Items.Find(Banco.menu, Banco.status)[0] as ToolStripMenuItem;

                //if (mnu.Items != null)
                //{


                //    menus.DropDownItems[Banco.menu.ToString()].Enabled = Banco.status;
                //}

               

                  //  ToolStripMenuItem tsmi = mnu.Items.Find(Banco.menu, Banco.status)[0] as ToolStripMenuItem;



                    // ToolStripItem[] items = mnu.Items.Find(Banco.menu, Banco.status);
                    //
                    // string[] items = new[] { Banco.menu, Banco.status };

                    //var items = mnu.Items.Find("SalesToolStripMenuItem", true);


                  

                //if (items.Count() > 0)
                //{
                //    ToolStripItem item = items.FirstOrDefault();
                //    item.Name = Banco.menu ?? item.Name;
                //    item.Visible = Banco.status;








                //    //tsmi.DropDownItems[Banco.menu].Enabled = Banco.status;

                //    //var item = mnu.Items.Find(Banco.menu, Banco.status).FirstOrDefault();

                //    //if (item != null)




                //}
            }






           // MenuStrip mnu = (MenuStrip)frm.Controls["menuStrip"];


            //foreach (ToolStripMenuItem item in mnu.Items)
            //{

            //    using (var dr = sql.ExecuteReader())
            //    {
            //        foreach (DbDataRecord reader in dr)
            //        {
            //            Banco.menu = dr["menu"].ToString();
            //            Banco.status = Convert.ToBoolean(dr["permissao"].ToString());


            //            ToolStripItem[] mnus = item.DropDownItems.Find(Banco.menu, true);


            //            if ((mnus.Length > 0))
            //            {

            //               mnus[0].Visible = Banco.status;
            //            }

            //        }

            //    }


            //}


        }

        private static void HabilitaOuDesabilitaMenu(MDIPrincipal frm, MenuStrip mnu,string menu, bool status)
        {
            foreach (ToolStripMenuItem item in mnu.Items)
            {
                if (item.Name.ToString() == menu)
                {
                    item.Enabled = status;
                }

                foreach (ToolStripItem objSubItem in item.DropDownItems)
                {
                    if(objSubItem.ToString() == menu)
                    {
                        objSubItem.Enabled = status;
                    }
                    //foreach (ToolStripMenuItem objSubItem2 in objSubItem.)
                    //{
                    //    if (objSubItem2.ToString() == menu)
                    //    {
                    //        objSubItem2.Enabled = status;
                    //    }

                    //}

                }
               
            }


           
        }
    }
}
