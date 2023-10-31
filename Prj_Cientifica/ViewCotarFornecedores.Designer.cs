namespace Prj_Cientifica
{
    partial class ViewCotarFornecedores
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
            this.txtpesquisa = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.DtGConsulta = new System.Windows.Forms.DataGridView();
            this.btnCotar = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.cboproduto = new System.Windows.Forms.ComboBox();
            this.label20 = new System.Windows.Forms.Label();
            this.label22 = new System.Windows.Forms.Label();
            this.griditens = new System.Windows.Forms.DataGridView();
            this.BtnSair = new System.Windows.Forms.Button();
            this.BtnLimpar = new System.Windows.Forms.Button();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.DtGConsulta)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.griditens)).BeginInit();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.txtpesquisa);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.DtGConsulta);
            this.groupBox1.Controls.Add(this.btnCotar);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.cboproduto);
            this.groupBox1.Controls.Add(this.label20);
            this.groupBox1.Controls.Add(this.label22);
            this.groupBox1.Controls.Add(this.griditens);
            this.groupBox1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox1.Location = new System.Drawing.Point(2, 3);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(795, 628);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Selecionar Fornecedores para Cotação";
            // 
            // txtpesquisa
            // 
            this.txtpesquisa.Location = new System.Drawing.Point(10, 88);
            this.txtpesquisa.Name = "txtpesquisa";
            this.txtpesquisa.Size = new System.Drawing.Size(639, 22);
            this.txtpesquisa.TabIndex = 333;
            this.txtpesquisa.TextChanged += new System.EventHandler(this.txtpesquisa_TextChanged);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.Color.Blue;
            this.label2.Location = new System.Drawing.Point(283, 120);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(120, 20);
            this.label2.TabIndex = 332;
            this.label2.Text = "Fornecedores";
            // 
            // DtGConsulta
            // 
            this.DtGConsulta.AllowUserToAddRows = false;
            this.DtGConsulta.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.DtGConsulta.Location = new System.Drawing.Point(3, 142);
            this.DtGConsulta.Margin = new System.Windows.Forms.Padding(2);
            this.DtGConsulta.Name = "DtGConsulta";
            this.DtGConsulta.RowTemplate.Height = 24;
            this.DtGConsulta.Size = new System.Drawing.Size(784, 255);
            this.DtGConsulta.TabIndex = 331;
            // 
            // btnCotar
            // 
            this.btnCotar.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.btnCotar.Image = global::Prj_Cientifica.Properties.Resources.images3;
            this.btnCotar.Location = new System.Drawing.Point(669, 40);
            this.btnCotar.Name = "btnCotar";
            this.btnCotar.Size = new System.Drawing.Size(126, 71);
            this.btnCotar.TabIndex = 330;
            this.btnCotar.Text = "Adicionar";
            this.btnCotar.TextAlign = System.Drawing.ContentAlignment.TopLeft;
            this.btnCotar.UseVisualStyleBackColor = true;
            this.btnCotar.Click += new System.EventHandler(this.btnCotar_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(9, 69);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(88, 16);
            this.label1.TabIndex = 329;
            this.label1.Text = "Fornecedor";
            // 
            // cboproduto
            // 
            this.cboproduto.Enabled = false;
            this.cboproduto.FormattingEnabled = true;
            this.cboproduto.Location = new System.Drawing.Point(10, 40);
            this.cboproduto.Name = "cboproduto";
            this.cboproduto.Size = new System.Drawing.Size(639, 24);
            this.cboproduto.TabIndex = 326;
            // 
            // label20
            // 
            this.label20.AutoSize = true;
            this.label20.Location = new System.Drawing.Point(9, 22);
            this.label20.Name = "label20";
            this.label20.Size = new System.Drawing.Size(129, 16);
            this.label20.TabIndex = 327;
            this.label20.Text = "Nome do Produto";
            // 
            // label22
            // 
            this.label22.AutoSize = true;
            this.label22.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label22.ForeColor = System.Drawing.Color.Blue;
            this.label22.Location = new System.Drawing.Point(286, 414);
            this.label22.Name = "label22";
            this.label22.Size = new System.Drawing.Size(208, 20);
            this.label22.TabIndex = 325;
            this.label22.Text = "Produto e  Fornecedores";
            // 
            // griditens
            // 
            this.griditens.AllowUserToAddRows = false;
            this.griditens.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.griditens.Location = new System.Drawing.Point(6, 436);
            this.griditens.Margin = new System.Windows.Forms.Padding(2);
            this.griditens.Name = "griditens";
            this.griditens.RowTemplate.Height = 24;
            this.griditens.Size = new System.Drawing.Size(784, 217);
            this.griditens.TabIndex = 324;
            // 
            // BtnSair
            // 
            this.BtnSair.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BtnSair.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.BtnSair.Image = global::Prj_Cientifica.Properties.Resources.enter_321;
            this.BtnSair.ImageAlign = System.Drawing.ContentAlignment.TopCenter;
            this.BtnSair.Location = new System.Drawing.Point(93, 666);
            this.BtnSair.Name = "BtnSair";
            this.BtnSair.Size = new System.Drawing.Size(70, 59);
            this.BtnSair.TabIndex = 8;
            this.BtnSair.Text = "Sair";
            this.BtnSair.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.BtnSair.UseVisualStyleBackColor = true;
            this.BtnSair.Click += new System.EventHandler(this.BtnSair_Click);
            // 
            // BtnLimpar
            // 
            this.BtnLimpar.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BtnLimpar.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.BtnLimpar.Image = global::Prj_Cientifica.Properties.Resources._023_037_broom_clear_clean_tool_32;
            this.BtnLimpar.ImageAlign = System.Drawing.ContentAlignment.TopCenter;
            this.BtnLimpar.Location = new System.Drawing.Point(17, 666);
            this.BtnLimpar.Name = "BtnLimpar";
            this.BtnLimpar.Size = new System.Drawing.Size(70, 59);
            this.BtnLimpar.TabIndex = 7;
            this.BtnLimpar.Text = "Limpar";
            this.BtnLimpar.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.BtnLimpar.UseVisualStyleBackColor = true;
            this.BtnLimpar.Click += new System.EventHandler(this.BtnLimpar_Click);
            // 
            // ViewCotarFornecedores
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 737);
            this.Controls.Add(this.BtnSair);
            this.Controls.Add(this.BtnLimpar);
            this.Controls.Add(this.groupBox1);
            this.Name = "ViewCotarFornecedores";
            this.Text = "Selecionar Fornecedores para Cotação";
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.DtGConsulta)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.griditens)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label label22;
        private System.Windows.Forms.DataGridView griditens;
        private System.Windows.Forms.ComboBox cboproduto;
        private System.Windows.Forms.Label label20;
        private System.Windows.Forms.Button btnCotar;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.DataGridView DtGConsulta;
        private System.Windows.Forms.TextBox txtpesquisa;
        private System.Windows.Forms.Button BtnSair;
        private System.Windows.Forms.Button BtnLimpar;
    }
}