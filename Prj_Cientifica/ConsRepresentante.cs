﻿using System;
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
    public partial class ConsRepresentante : Form
    {
        public ConsRepresentante()
        {
            InitializeComponent();
        }


        public int codrepresentante;
        private void carregarGrid()
        {
            DataTable ds = new DataTable();
            SqlConnection Conn = Banco.CriarConexao();
            try
            {
                Conn.Open();
            }

            catch (System.Exception e)
            {
                throw e;
            }


            if (Conn.State == ConnectionState.Open)
            {
                string strConn = "Select idrepresentante as Codigo, nomerep as Representante" +
                " from Representante Where nomerep  Like'" + txtpesquisa.Text + "%' Order by nomerep";
                SqlDataAdapter da = new SqlDataAdapter(strConn, Conn);
                da.Fill(ds);


            }

            this.DtGConsulta.RowsDefaultCellStyle.BackColor = Color.LightBlue;
            this.DtGConsulta.AlternatingRowsDefaultCellStyle.BackColor = Color.Azure;



            DtGConsulta.AutoGenerateColumns = false;
            //exibe os dados no datagridview
            DtGConsulta.DataSource = ds;
            DtGConsulta.Columns.Clear();
            DtGConsulta.Columns.Add("Codigo", "Codigo");
            DtGConsulta.Columns.Add("Representante", "Representante");
            DtGConsulta.Columns[0].Width = 80;
            DtGConsulta.Columns[1].Width = 480;
            DtGConsulta.Columns[0].DataPropertyName = "Codigo";
            DtGConsulta.Columns[1].DataPropertyName = "Representante";
            DtGConsulta.Refresh();

        }

        private void DtGConsulta_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            codrepresentante = Convert.ToInt32(DtGConsulta[0, e.RowIndex].Value.ToString());
            ViewRepresentante frcont = new ViewRepresentante(this);
            frcont.Show();
            this.Close();
        }

        private void BtnLimpar_Click(object sender, EventArgs e)
        {
            txtpesquisa.Text = "";
            DtGConsulta.DataSource = null;
            DtGConsulta.Refresh();
        }

        private void BtnSair_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void txtpesquisa_TextChanged(object sender, EventArgs e)
        {
            carregarGrid();
        }
    }
}
