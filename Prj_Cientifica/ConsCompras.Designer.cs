namespace Prj_Cientifica
{
    partial class Compras
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.chkedital = new System.Windows.Forms.RadioButton();
            this.label44 = new System.Windows.Forms.Label();
            this.txttotalitens = new System.Windows.Forms.TextBox();
            this.panel3 = new System.Windows.Forms.Panel();
            this.label10 = new System.Windows.Forms.Label();
            this.panel2 = new System.Windows.Forms.Panel();
            this.labTotal = new System.Windows.Forms.Label();
            this.chkMarca = new System.Windows.Forms.RadioButton();
            this.chkProduto = new System.Windows.Forms.RadioButton();
            this.chkestado = new System.Windows.Forms.RadioButton();
            this.label1 = new System.Windows.Forms.Label();
            this.BtnSair = new System.Windows.Forms.Button();
            this.BtnLimpar = new System.Windows.Forms.Button();
            this.DtGConsulta = new System.Windows.Forms.DataGridView();
            this.txtpesquisa = new System.Windows.Forms.TextBox();
            this.groupBox1.SuspendLayout();
            this.panel3.SuspendLayout();
            this.panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.DtGConsulta)).BeginInit();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.chkedital);
            this.groupBox1.Controls.Add(this.label44);
            this.groupBox1.Controls.Add(this.txttotalitens);
            this.groupBox1.Controls.Add(this.panel3);
            this.groupBox1.Controls.Add(this.panel2);
            this.groupBox1.Controls.Add(this.chkMarca);
            this.groupBox1.Controls.Add(this.chkProduto);
            this.groupBox1.Controls.Add(this.chkestado);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.BtnSair);
            this.groupBox1.Controls.Add(this.BtnLimpar);
            this.groupBox1.Controls.Add(this.DtGConsulta);
            this.groupBox1.Controls.Add(this.txtpesquisa);
            this.groupBox1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox1.ForeColor = System.Drawing.Color.Black;
            this.groupBox1.Location = new System.Drawing.Point(-3, 9);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(1204, 441);
            this.groupBox1.TabIndex = 10;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Consultar Compras";
            // 
            // chkedital
            // 
            this.chkedital.AutoSize = true;
            this.chkedital.Location = new System.Drawing.Point(182, 12);
            this.chkedital.Name = "chkedital";
            this.chkedital.Size = new System.Drawing.Size(87, 20);
            this.chkedital.TabIndex = 421;
            this.chkedital.TabStop = true;
            this.chkedital.Text = "Nº Edital";
            this.chkedital.UseVisualStyleBackColor = true;
            this.chkedital.CheckedChanged += new System.EventHandler(this.chkedital_CheckedChanged);
            // 
            // label44
            // 
            this.label44.AutoSize = true;
            this.label44.Location = new System.Drawing.Point(490, 379);
            this.label44.Name = "label44";
            this.label44.Size = new System.Drawing.Size(103, 16);
            this.label44.TabIndex = 420;
            this.label44.Text = "Total de Itens";
            // 
            // txttotalitens
            // 
            this.txttotalitens.Enabled = false;
            this.txttotalitens.Location = new System.Drawing.Point(493, 395);
            this.txttotalitens.Name = "txttotalitens";
            this.txttotalitens.Size = new System.Drawing.Size(94, 22);
            this.txttotalitens.TabIndex = 419;
            this.txttotalitens.Text = "0";
            this.txttotalitens.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // panel3
            // 
            this.panel3.BackColor = System.Drawing.Color.Blue;
            this.panel3.Controls.Add(this.label10);
            this.panel3.Location = new System.Drawing.Point(924, 363);
            this.panel3.Margin = new System.Windows.Forms.Padding(2);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(257, 32);
            this.panel3.TabIndex = 297;
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label10.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.label10.Location = new System.Drawing.Point(88, -2);
            this.label10.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(117, 20);
            this.label10.TabIndex = 0;
            this.label10.Text = "Total Produto";
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.Color.LightBlue;
            this.panel2.Controls.Add(this.labTotal);
            this.panel2.Location = new System.Drawing.Point(924, 363);
            this.panel2.Margin = new System.Windows.Forms.Padding(2);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(257, 74);
            this.panel2.TabIndex = 298;
            // 
            // labTotal
            // 
            this.labTotal.AutoSize = true;
            this.labTotal.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labTotal.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.labTotal.Location = new System.Drawing.Point(97, 38);
            this.labTotal.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.labTotal.Name = "labTotal";
            this.labTotal.Size = new System.Drawing.Size(76, 29);
            this.labTotal.TabIndex = 0;
            this.labTotal.Text = "00,00";
            // 
            // chkMarca
            // 
            this.chkMarca.AutoSize = true;
            this.chkMarca.Location = new System.Drawing.Point(291, 12);
            this.chkMarca.Name = "chkMarca";
            this.chkMarca.Size = new System.Drawing.Size(69, 20);
            this.chkMarca.TabIndex = 12;
            this.chkMarca.TabStop = true;
            this.chkMarca.Text = "Marca";
            this.chkMarca.UseVisualStyleBackColor = true;
            // 
            // chkProduto
            // 
            this.chkProduto.AutoSize = true;
            this.chkProduto.Location = new System.Drawing.Point(387, 12);
            this.chkProduto.Name = "chkProduto";
            this.chkProduto.Size = new System.Drawing.Size(80, 20);
            this.chkProduto.TabIndex = 11;
            this.chkProduto.TabStop = true;
            this.chkProduto.Text = "Produto";
            this.chkProduto.UseVisualStyleBackColor = true;
            // 
            // chkestado
            // 
            this.chkestado.AutoSize = true;
            this.chkestado.Location = new System.Drawing.Point(501, 12);
            this.chkestado.Name = "chkestado";
            this.chkestado.Size = new System.Drawing.Size(75, 20);
            this.chkestado.TabIndex = 10;
            this.chkestado.TabStop = true;
            this.chkestado.Text = "Estado";
            this.chkestado.UseVisualStyleBackColor = true;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.label1.Location = new System.Drawing.Point(7, 29);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(78, 16);
            this.label1.TabIndex = 7;
            this.label1.Text = "Pesquisar";
            // 
            // BtnSair
            // 
            this.BtnSair.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.BtnSair.Image = global::Prj_Cientifica.Properties.Resources.enter_321;
            this.BtnSair.ImageAlign = System.Drawing.ContentAlignment.TopCenter;
            this.BtnSair.Location = new System.Drawing.Point(82, 364);
            this.BtnSair.Name = "BtnSair";
            this.BtnSair.Size = new System.Drawing.Size(70, 59);
            this.BtnSair.TabIndex = 6;
            this.BtnSair.Text = "Sair";
            this.BtnSair.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.BtnSair.UseVisualStyleBackColor = true;
            this.BtnSair.Click += new System.EventHandler(this.BtnSair_Click);
            // 
            // BtnLimpar
            // 
            this.BtnLimpar.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.BtnLimpar.Image = global::Prj_Cientifica.Properties.Resources._023_037_broom_clear_clean_tool_32;
            this.BtnLimpar.ImageAlign = System.Drawing.ContentAlignment.TopCenter;
            this.BtnLimpar.Location = new System.Drawing.Point(6, 364);
            this.BtnLimpar.Name = "BtnLimpar";
            this.BtnLimpar.Size = new System.Drawing.Size(70, 59);
            this.BtnLimpar.TabIndex = 5;
            this.BtnLimpar.Text = "Limpar";
            this.BtnLimpar.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.BtnLimpar.UseVisualStyleBackColor = true;
            this.BtnLimpar.Click += new System.EventHandler(this.BtnLimpar_Click);
            // 
            // DtGConsulta
            // 
            this.DtGConsulta.AllowUserToAddRows = false;
            this.DtGConsulta.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.DtGConsulta.Location = new System.Drawing.Point(6, 83);
            this.DtGConsulta.Name = "DtGConsulta";
            this.DtGConsulta.Size = new System.Drawing.Size(1192, 275);
            this.DtGConsulta.TabIndex = 4;
            this.DtGConsulta.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.DtGConsulta_CellDoubleClick);
            // 
            // txtpesquisa
            // 
            this.txtpesquisa.Location = new System.Drawing.Point(6, 48);
            this.txtpesquisa.Name = "txtpesquisa";
            this.txtpesquisa.Size = new System.Drawing.Size(1192, 22);
            this.txtpesquisa.TabIndex = 2;
            this.txtpesquisa.TextChanged += new System.EventHandler(this.txtpesquisa_TextChanged);
            // 
            // Compras
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1200, 461);
            this.Controls.Add(this.groupBox1);
            this.Name = "Compras";
            this.Text = "Consulta de Compras";
            this.Load += new System.EventHandler(this.Compras_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.panel3.ResumeLayout(false);
            this.panel3.PerformLayout();
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.DtGConsulta)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.RadioButton chkMarca;
        private System.Windows.Forms.RadioButton chkProduto;
        private System.Windows.Forms.RadioButton chkestado;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button BtnSair;
        private System.Windows.Forms.Button BtnLimpar;
        private System.Windows.Forms.DataGridView DtGConsulta;
        private System.Windows.Forms.TextBox txtpesquisa;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Label labTotal;
        private System.Windows.Forms.Label label44;
        private System.Windows.Forms.TextBox txttotalitens;
        private System.Windows.Forms.RadioButton chkedital;
    }
}