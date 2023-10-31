namespace Prj_Cientifica
{
    partial class ViewPrecoItens
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
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.griditensultimo = new System.Windows.Forms.DataGridView();
            this.griditens = new System.Windows.Forms.DataGridView();
            this.txtpesquisa = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.cboprocesso = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.BtnSair = new System.Windows.Forms.Button();
            this.BtnNovo = new System.Windows.Forms.Button();
            this.btnPesquisar = new System.Windows.Forms.Button();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.griditensultimo)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.griditens)).BeginInit();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.BtnSair);
            this.groupBox1.Controls.Add(this.BtnNovo);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.griditensultimo);
            this.groupBox1.Controls.Add(this.griditens);
            this.groupBox1.Controls.Add(this.txtpesquisa);
            this.groupBox1.Controls.Add(this.label7);
            this.groupBox1.Controls.Add(this.btnPesquisar);
            this.groupBox1.Controls.Add(this.cboprocesso);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox1.Location = new System.Drawing.Point(2, 3);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(1112, 682);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Itens Ganho por Empresas";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.Color.Blue;
            this.label2.Location = new System.Drawing.Point(416, 104);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(251, 24);
            this.label2.TabIndex = 325;
            this.label2.Text = "Total Ganho Por Empresa";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.ForeColor = System.Drawing.Color.Blue;
            this.label3.Location = new System.Drawing.Point(442, 347);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(248, 24);
            this.label3.TabIndex = 321;
            this.label3.Text = "Itens Ganho por Empresa";
            // 
            // griditensultimo
            // 
            this.griditensultimo.AllowUserToAddRows = false;
            this.griditensultimo.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.griditensultimo.Location = new System.Drawing.Point(8, 373);
            this.griditensultimo.Margin = new System.Windows.Forms.Padding(2);
            this.griditensultimo.Name = "griditensultimo";
            this.griditensultimo.RowTemplate.Height = 24;
            this.griditensultimo.Size = new System.Drawing.Size(1092, 257);
            this.griditensultimo.TabIndex = 320;
            // 
            // griditens
            // 
            this.griditens.AllowUserToAddRows = false;
            this.griditens.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.griditens.Location = new System.Drawing.Point(5, 129);
            this.griditens.Margin = new System.Windows.Forms.Padding(2);
            this.griditens.Name = "griditens";
            this.griditens.RowTemplate.Height = 24;
            this.griditens.Size = new System.Drawing.Size(1096, 216);
            this.griditens.TabIndex = 318;
            this.griditens.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.griditens_CellClick);
            // 
            // txtpesquisa
            // 
            this.txtpesquisa.Location = new System.Drawing.Point(5, 81);
            this.txtpesquisa.Name = "txtpesquisa";
            this.txtpesquisa.Size = new System.Drawing.Size(1095, 20);
            this.txtpesquisa.TabIndex = 317;
            this.txtpesquisa.TextChanged += new System.EventHandler(this.txtpesquisa_TextChanged);
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(2, 62);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(114, 13);
            this.label7.TabIndex = 316;
            this.label7.Text = "Pesquisar Empresa";
            // 
            // cboprocesso
            // 
            this.cboprocesso.Enabled = false;
            this.cboprocesso.FormattingEnabled = true;
            this.cboprocesso.Location = new System.Drawing.Point(5, 38);
            this.cboprocesso.Name = "cboprocesso";
            this.cboprocesso.Size = new System.Drawing.Size(1007, 21);
            this.cboprocesso.TabIndex = 310;
            this.cboprocesso.Click += new System.EventHandler(this.cboprocesso_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(6, 22);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(134, 13);
            this.label1.TabIndex = 309;
            this.label1.Text = "Informações  do Edital";
            // 
            // BtnSair
            // 
            this.BtnSair.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BtnSair.Image = global::Prj_Cientifica.Properties.Resources.enter_241;
            this.BtnSair.ImageAlign = System.Drawing.ContentAlignment.TopCenter;
            this.BtnSair.Location = new System.Drawing.Point(1040, 635);
            this.BtnSair.Name = "BtnSair";
            this.BtnSair.Size = new System.Drawing.Size(60, 43);
            this.BtnSair.TabIndex = 322;
            this.BtnSair.Text = "Sair";
            this.BtnSair.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.BtnSair.UseVisualStyleBackColor = true;
            this.BtnSair.Click += new System.EventHandler(this.BtnSair_Click);
            // 
            // BtnNovo
            // 
            this.BtnNovo.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BtnNovo.Image = global::Prj_Cientifica.Properties.Resources._4016089_watch_add_smartwatch_icon_1_3;
            this.BtnNovo.ImageAlign = System.Drawing.ContentAlignment.TopCenter;
            this.BtnNovo.Location = new System.Drawing.Point(973, 635);
            this.BtnNovo.Name = "BtnNovo";
            this.BtnNovo.Size = new System.Drawing.Size(61, 43);
            this.BtnNovo.TabIndex = 323;
            this.BtnNovo.Text = "Novo";
            this.BtnNovo.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.BtnNovo.UseVisualStyleBackColor = true;
            this.BtnNovo.Click += new System.EventHandler(this.BtnNovo_Click);
            // 
            // btnPesquisar
            // 
            this.btnPesquisar.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(192)))));
            this.btnPesquisar.Image = global::Prj_Cientifica.Properties.Resources._7938_16x16;
            this.btnPesquisar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnPesquisar.Location = new System.Drawing.Point(1018, 27);
            this.btnPesquisar.Name = "btnPesquisar";
            this.btnPesquisar.Size = new System.Drawing.Size(83, 40);
            this.btnPesquisar.TabIndex = 311;
            this.btnPesquisar.Text = "Pesquisar";
            this.btnPesquisar.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnPesquisar.UseVisualStyleBackColor = true;
            this.btnPesquisar.Click += new System.EventHandler(this.btnPesquisar_Click);
            // 
            // ViewPrecoItens
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1114, 687);
            this.Controls.Add(this.groupBox1);
            this.Name = "ViewPrecoItens";
            this.Text = "Itens Ganho por Empresas";
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.griditensultimo)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.griditens)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.TextBox txtpesquisa;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.DataGridView griditens;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.DataGridView griditensultimo;
        private System.Windows.Forms.Button BtnSair;
        private System.Windows.Forms.Button BtnNovo;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button btnPesquisar;
        private System.Windows.Forms.ComboBox cboprocesso;
        private System.Windows.Forms.Label label1;
    }
}