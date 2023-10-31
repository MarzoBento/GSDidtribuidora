namespace Prj_Cientifica
{
    partial class ConsEmpenho
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ConsEmpenho));
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.chkedital = new System.Windows.Forms.RadioButton();
            this.chkCliente = new System.Windows.Forms.RadioButton();
            this.btnPesqData = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.label17 = new System.Windows.Forms.Label();
            this.mskfim = new System.Windows.Forms.MaskedTextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.mskini = new System.Windows.Forms.MaskedTextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.BtnSair = new System.Windows.Forms.Button();
            this.BtnLimpar = new System.Windows.Forms.Button();
            this.DtGConsulta = new System.Windows.Forms.DataGridView();
            this.txtpesquisa = new System.Windows.Forms.TextBox();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.DtGConsulta)).BeginInit();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.chkedital);
            this.groupBox1.Controls.Add(this.chkCliente);
            this.groupBox1.Controls.Add(this.btnPesqData);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.label17);
            this.groupBox1.Controls.Add(this.mskfim);
            this.groupBox1.Controls.Add(this.label7);
            this.groupBox1.Controls.Add(this.mskini);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.BtnSair);
            this.groupBox1.Controls.Add(this.BtnLimpar);
            this.groupBox1.Controls.Add(this.DtGConsulta);
            this.groupBox1.Controls.Add(this.txtpesquisa);
            this.groupBox1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox1.ForeColor = System.Drawing.Color.Black;
            this.groupBox1.Location = new System.Drawing.Point(12, 9);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(1002, 429);
            this.groupBox1.TabIndex = 7;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Consultar Empenho";
            // 
            // chkedital
            // 
            this.chkedital.AutoSize = true;
            this.chkedital.Location = new System.Drawing.Point(206, 21);
            this.chkedital.Name = "chkedital";
            this.chkedital.Size = new System.Drawing.Size(90, 20);
            this.chkedital.TabIndex = 423;
            this.chkedital.TabStop = true;
            this.chkedital.Text = "Nº Edital";
            this.chkedital.UseVisualStyleBackColor = true;
            // 
            // chkCliente
            // 
            this.chkCliente.AutoSize = true;
            this.chkCliente.Location = new System.Drawing.Point(315, 21);
            this.chkCliente.Name = "chkCliente";
            this.chkCliente.Size = new System.Drawing.Size(76, 20);
            this.chkCliente.TabIndex = 422;
            this.chkCliente.TabStop = true;
            this.chkCliente.Text = "Cliente";
            this.chkCliente.UseVisualStyleBackColor = true;
            // 
            // btnPesqData
            // 
            this.btnPesqData.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnPesqData.Image = ((System.Drawing.Image)(resources.GetObject("btnPesqData.Image")));
            this.btnPesqData.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnPesqData.Location = new System.Drawing.Point(861, 31);
            this.btnPesqData.Name = "btnPesqData";
            this.btnPesqData.Size = new System.Drawing.Size(129, 39);
            this.btnPesqData.TabIndex = 413;
            this.btnPesqData.Text = "Pesquisar";
            this.btnPesqData.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnPesqData.UseVisualStyleBackColor = true;
            this.btnPesqData.Click += new System.EventHandler(this.btnPesqData_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.ForeColor = System.Drawing.Color.Black;
            this.label2.Location = new System.Drawing.Point(691, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(146, 16);
            this.label2.TabIndex = 412;
            this.label2.Text = "Pesquisar por Data";
            // 
            // label17
            // 
            this.label17.AutoSize = true;
            this.label17.Location = new System.Drawing.Point(772, 32);
            this.label17.Name = "label17";
            this.label17.Size = new System.Drawing.Size(64, 16);
            this.label17.TabIndex = 411;
            this.label17.Text = "Dt.Final";
            // 
            // mskfim
            // 
            this.mskfim.Location = new System.Drawing.Point(772, 48);
            this.mskfim.Mask = "00/00/0000";
            this.mskfim.Name = "mskfim";
            this.mskfim.Size = new System.Drawing.Size(83, 22);
            this.mskfim.TabIndex = 410;
            this.mskfim.ValidatingType = typeof(System.DateTime);
            this.mskfim.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.mskfim_KeyPress);
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(680, 32);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(71, 16);
            this.label7.TabIndex = 409;
            this.label7.Text = "Dt.Inicial";
            // 
            // mskini
            // 
            this.mskini.Location = new System.Drawing.Point(683, 49);
            this.mskini.Mask = "00/00/0000";
            this.mskini.Name = "mskini";
            this.mskini.Size = new System.Drawing.Size(83, 22);
            this.mskini.TabIndex = 408;
            this.mskini.ValidatingType = typeof(System.DateTime);
            this.mskini.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.mskini_KeyPress);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.label1.Location = new System.Drawing.Point(7, 29);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(79, 16);
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
            // 
            // DtGConsulta
            // 
            this.DtGConsulta.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.DtGConsulta.Location = new System.Drawing.Point(6, 76);
            this.DtGConsulta.Name = "DtGConsulta";
            this.DtGConsulta.Size = new System.Drawing.Size(990, 275);
            this.DtGConsulta.TabIndex = 4;
            this.DtGConsulta.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.DtGConsulta_CellDoubleClick);
            // 
            // txtpesquisa
            // 
            this.txtpesquisa.Location = new System.Drawing.Point(6, 48);
            this.txtpesquisa.Name = "txtpesquisa";
            this.txtpesquisa.Size = new System.Drawing.Size(671, 22);
            this.txtpesquisa.TabIndex = 2;
            this.txtpesquisa.TextChanged += new System.EventHandler(this.txtpesquisa_TextChanged);
            this.txtpesquisa.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtpesquisa_KeyPress);
            // 
            // ConsEmpenho
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1014, 440);
            this.Controls.Add(this.groupBox1);
            this.Name = "ConsEmpenho";
            this.Text = "Consulta de Empenho";
            this.Load += new System.EventHandler(this.ConsEmpenho_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.DtGConsulta)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button BtnSair;
        private System.Windows.Forms.Button BtnLimpar;
        private System.Windows.Forms.DataGridView DtGConsulta;
        private System.Windows.Forms.TextBox txtpesquisa;
        private System.Windows.Forms.Label label17;
        private System.Windows.Forms.MaskedTextBox mskfim;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.MaskedTextBox mskini;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button btnPesqData;
        private System.Windows.Forms.RadioButton chkedital;
        private System.Windows.Forms.RadioButton chkCliente;
    }
}