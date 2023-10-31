namespace Prj_Cientifica
{
    partial class ViewDocFornecedor
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
            this.listarq = new System.Windows.Forms.ListBox();
            this.txtdiasvenc = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.Grid = new System.Windows.Forms.DataGridView();
            this.txtdiasaviso = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.txtobs = new System.Windows.Forms.TextBox();
            this.label30 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.mskdtvalidade = new System.Windows.Forms.MaskedTextBox();
            this.cbotipodoc = new System.Windows.Forms.ComboBox();
            this.label12 = new System.Windows.Forms.Label();
            this.cbofornecedor = new System.Windows.Forms.ComboBox();
            this.label6 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.mskemissao = new System.Windows.Forms.MaskedTextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.txtcodigo = new System.Windows.Forms.TextBox();
            this.BtnSair = new System.Windows.Forms.Button();
            this.BtnNovo = new System.Windows.Forms.Button();
            this.BtnRemover = new System.Windows.Forms.Button();
            this.btnCadDoc = new System.Windows.Forms.Button();
            this.btnanexar = new System.Windows.Forms.Button();
            this.btnPesquisar = new System.Windows.Forms.Button();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.Grid)).BeginInit();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.listarq);
            this.groupBox1.Controls.Add(this.BtnSair);
            this.groupBox1.Controls.Add(this.BtnNovo);
            this.groupBox1.Controls.Add(this.txtdiasvenc);
            this.groupBox1.Controls.Add(this.BtnRemover);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.btnCadDoc);
            this.groupBox1.Controls.Add(this.Grid);
            this.groupBox1.Controls.Add(this.btnanexar);
            this.groupBox1.Controls.Add(this.txtdiasaviso);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.txtobs);
            this.groupBox1.Controls.Add(this.label30);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.mskdtvalidade);
            this.groupBox1.Controls.Add(this.cbotipodoc);
            this.groupBox1.Controls.Add(this.label12);
            this.groupBox1.Controls.Add(this.cbofornecedor);
            this.groupBox1.Controls.Add(this.label6);
            this.groupBox1.Controls.Add(this.label7);
            this.groupBox1.Controls.Add(this.mskemissao);
            this.groupBox1.Controls.Add(this.btnPesquisar);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Controls.Add(this.txtcodigo);
            this.groupBox1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.groupBox1.Location = new System.Drawing.Point(1, 2);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(1001, 562);
            this.groupBox1.TabIndex = 9;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Cadastro de Documento de Fornecedores";
            // 
            // listarq
            // 
            this.listarq.FormattingEnabled = true;
            this.listarq.Location = new System.Drawing.Point(16, 223);
            this.listarq.Name = "listarq";
            this.listarq.Size = new System.Drawing.Size(796, 56);
            this.listarq.TabIndex = 380;
            // 
            // txtdiasvenc
            // 
            this.txtdiasvenc.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtdiasvenc.Location = new System.Drawing.Point(45, 188);
            this.txtdiasvenc.Name = "txtdiasvenc";
            this.txtdiasvenc.Size = new System.Drawing.Size(138, 29);
            this.txtdiasvenc.TabIndex = 260;
            this.txtdiasvenc.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.txtdiasvenc.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtdiasvenc_KeyPress);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.ForeColor = System.Drawing.Color.Red;
            this.label3.Location = new System.Drawing.Point(7, 169);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(285, 16);
            this.label3.TabIndex = 259;
            this.label3.Text = "Avisar Vencimento  Com Quantos Dias ?";
            // 
            // Grid
            // 
            this.Grid.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.Grid.Location = new System.Drawing.Point(10, 284);
            this.Grid.Margin = new System.Windows.Forms.Padding(2);
            this.Grid.Name = "Grid";
            this.Grid.RowTemplate.Height = 24;
            this.Grid.Size = new System.Drawing.Size(991, 169);
            this.Grid.TabIndex = 256;
            this.Grid.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.Grid_CellClick);
            this.Grid.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.Grid_CellDoubleClick);
            // 
            // txtdiasaviso
            // 
            this.txtdiasaviso.Enabled = false;
            this.txtdiasaviso.Location = new System.Drawing.Point(900, 135);
            this.txtdiasaviso.Name = "txtdiasaviso";
            this.txtdiasaviso.Size = new System.Drawing.Size(79, 20);
            this.txtdiasaviso.TabIndex = 162;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(904, 119);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(67, 13);
            this.label2.TabIndex = 163;
            this.label2.Text = "Dias Aviso";
            // 
            // txtobs
            // 
            this.txtobs.Location = new System.Drawing.Point(309, 185);
            this.txtobs.Multiline = true;
            this.txtobs.Name = "txtobs";
            this.txtobs.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.txtobs.Size = new System.Drawing.Size(670, 34);
            this.txtobs.TabIndex = 4;
            // 
            // label30
            // 
            this.label30.AutoSize = true;
            this.label30.Location = new System.Drawing.Point(306, 169);
            this.label30.Name = "label30";
            this.label30.Size = new System.Drawing.Size(75, 13);
            this.label30.TabIndex = 100;
            this.label30.Text = "Observação";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(808, 119);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(73, 13);
            this.label1.TabIndex = 160;
            this.label1.Text = "Dt.Validade";
            // 
            // mskdtvalidade
            // 
            this.mskdtvalidade.Location = new System.Drawing.Point(811, 135);
            this.mskdtvalidade.Mask = "00/00/0000";
            this.mskdtvalidade.Name = "mskdtvalidade";
            this.mskdtvalidade.Size = new System.Drawing.Size(83, 20);
            this.mskdtvalidade.TabIndex = 3;
            this.mskdtvalidade.ValidatingType = typeof(System.DateTime);
            this.mskdtvalidade.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.mskdtvalidade_KeyPress);
            // 
            // cbotipodoc
            // 
            this.cbotipodoc.FormattingEnabled = true;
            this.cbotipodoc.Location = new System.Drawing.Point(7, 135);
            this.cbotipodoc.Name = "cbotipodoc";
            this.cbotipodoc.Size = new System.Drawing.Size(685, 21);
            this.cbotipodoc.TabIndex = 1;
            this.cbotipodoc.Click += new System.EventHandler(this.cbotipodoc_Click);
            this.cbotipodoc.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.cbotipodoc_KeyPress);
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Location = new System.Drawing.Point(4, 119);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(118, 13);
            this.label12.TabIndex = 116;
            this.label12.Text = "Tipo de Documento";
            // 
            // cbofornecedor
            // 
            this.cbofornecedor.FormattingEnabled = true;
            this.cbofornecedor.Location = new System.Drawing.Point(9, 84);
            this.cbofornecedor.Name = "cbofornecedor";
            this.cbofornecedor.Size = new System.Drawing.Size(970, 21);
            this.cbofornecedor.TabIndex = 0;
            this.cbofornecedor.SelectionChangeCommitted += new System.EventHandler(this.cbofornecedor_SelectionChangeCommitted);
            this.cbofornecedor.Click += new System.EventHandler(this.cbofornecedor_Click);
            this.cbofornecedor.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.cbofornecedor_KeyPress);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(7, 69);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(71, 13);
            this.label6.TabIndex = 84;
            this.label6.Text = "Fornecedor";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(719, 119);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(70, 13);
            this.label7.TabIndex = 71;
            this.label7.Text = "Dt.Emissao";
            // 
            // mskemissao
            // 
            this.mskemissao.Location = new System.Drawing.Point(722, 135);
            this.mskemissao.Mask = "00/00/0000";
            this.mskemissao.Name = "mskemissao";
            this.mskemissao.Size = new System.Drawing.Size(83, 20);
            this.mskemissao.TabIndex = 2;
            this.mskemissao.ValidatingType = typeof(System.DateTime);
            this.mskemissao.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.mskemissao_KeyPress);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(6, 22);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(46, 13);
            this.label4.TabIndex = 52;
            this.label4.Text = "Código";
            // 
            // txtcodigo
            // 
            this.txtcodigo.Enabled = false;
            this.txtcodigo.Location = new System.Drawing.Point(6, 38);
            this.txtcodigo.Name = "txtcodigo";
            this.txtcodigo.Size = new System.Drawing.Size(85, 20);
            this.txtcodigo.TabIndex = 51;
            // 
            // BtnSair
            // 
            this.BtnSair.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BtnSair.Image = global::Prj_Cientifica.Properties.Resources.enter_32;
            this.BtnSair.ImageAlign = System.Drawing.ContentAlignment.TopCenter;
            this.BtnSair.Location = new System.Drawing.Point(931, 490);
            this.BtnSair.Name = "BtnSair";
            this.BtnSair.Size = new System.Drawing.Size(64, 57);
            this.BtnSair.TabIndex = 23;
            this.BtnSair.Text = "Sair";
            this.BtnSair.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.BtnSair.UseVisualStyleBackColor = true;
            this.BtnSair.Click += new System.EventHandler(this.BtnSair_Click);
            // 
            // BtnNovo
            // 
            this.BtnNovo.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BtnNovo.Image = global::Prj_Cientifica.Properties.Resources.add_circle_blue_32;
            this.BtnNovo.ImageAlign = System.Drawing.ContentAlignment.TopCenter;
            this.BtnNovo.Location = new System.Drawing.Point(793, 490);
            this.BtnNovo.Name = "BtnNovo";
            this.BtnNovo.Size = new System.Drawing.Size(60, 57);
            this.BtnNovo.TabIndex = 25;
            this.BtnNovo.Text = "Novo";
            this.BtnNovo.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.BtnNovo.UseVisualStyleBackColor = true;
            this.BtnNovo.Click += new System.EventHandler(this.BtnNovo_Click);
            // 
            // BtnRemover
            // 
            this.BtnRemover.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BtnRemover.Image = global::Prj_Cientifica.Properties.Resources.blue_trash_32;
            this.BtnRemover.ImageAlign = System.Drawing.ContentAlignment.TopCenter;
            this.BtnRemover.Location = new System.Drawing.Point(859, 490);
            this.BtnRemover.Name = "BtnRemover";
            this.BtnRemover.Size = new System.Drawing.Size(66, 57);
            this.BtnRemover.TabIndex = 26;
            this.BtnRemover.Text = "Excluir";
            this.BtnRemover.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.BtnRemover.UseVisualStyleBackColor = true;
            this.BtnRemover.Click += new System.EventHandler(this.BtnRemover_Click);
            // 
            // btnCadDoc
            // 
            this.btnCadDoc.Image = global::Prj_Cientifica.Properties.Resources.EditDocument_245;
            this.btnCadDoc.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnCadDoc.Location = new System.Drawing.Point(771, 19);
            this.btnCadDoc.Name = "btnCadDoc";
            this.btnCadDoc.Size = new System.Drawing.Size(208, 36);
            this.btnCadDoc.TabIndex = 258;
            this.btnCadDoc.Text = "Cadastrar Tipo de Documento";
            this.btnCadDoc.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnCadDoc.UseVisualStyleBackColor = true;
            this.btnCadDoc.Click += new System.EventHandler(this.btnCadDoc_Click);
            // 
            // btnanexar
            // 
            this.btnanexar.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnanexar.ForeColor = System.Drawing.Color.Black;
            this.btnanexar.Image = global::Prj_Cientifica.Properties.Resources.clips2;
            this.btnanexar.ImageAlign = System.Drawing.ContentAlignment.TopLeft;
            this.btnanexar.Location = new System.Drawing.Point(817, 225);
            this.btnanexar.Name = "btnanexar";
            this.btnanexar.Size = new System.Drawing.Size(162, 54);
            this.btnanexar.TabIndex = 183;
            this.btnanexar.Text = "Anexar Arquivo";
            this.btnanexar.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnanexar.UseVisualStyleBackColor = true;
            this.btnanexar.Click += new System.EventHandler(this.btnanexar_Click);
            // 
            // btnPesquisar
            // 
            this.btnPesquisar.Image = global::Prj_Cientifica.Properties.Resources._7938_16x16;
            this.btnPesquisar.Location = new System.Drawing.Point(97, 36);
            this.btnPesquisar.Name = "btnPesquisar";
            this.btnPesquisar.Size = new System.Drawing.Size(32, 23);
            this.btnPesquisar.TabIndex = 53;
            this.btnPesquisar.UseVisualStyleBackColor = true;
            this.btnPesquisar.Click += new System.EventHandler(this.btnPesquisar_Click);
            // 
            // ViewDocFornecedor
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1009, 567);
            this.Controls.Add(this.groupBox1);
            this.Name = "ViewDocFornecedor";
            this.Text = "Documentos Fornecedor";
            this.Load += new System.EventHandler(this.ViewDocFornecedor_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.Grid)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.DataGridView Grid;
        private System.Windows.Forms.Button btnanexar;
        private System.Windows.Forms.TextBox txtdiasaviso;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtobs;
        private System.Windows.Forms.Label label30;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.MaskedTextBox mskdtvalidade;
        private System.Windows.Forms.ComboBox cbotipodoc;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.ComboBox cbofornecedor;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.MaskedTextBox mskemissao;
        private System.Windows.Forms.Button btnPesquisar;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox txtcodigo;
        private System.Windows.Forms.Button BtnSair;
        private System.Windows.Forms.Button BtnRemover;
        private System.Windows.Forms.Button BtnNovo;
        private System.Windows.Forms.Button btnCadDoc;
        private System.Windows.Forms.TextBox txtdiasvenc;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.ListBox listarq;
    }
}