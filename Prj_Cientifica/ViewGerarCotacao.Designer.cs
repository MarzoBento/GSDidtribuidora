namespace Prj_Cientifica
{
    partial class ViewGerarCotacao
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
            this.chkTodos = new System.Windows.Forms.CheckBox();
            this.label8 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.GridFor = new System.Windows.Forms.DataGridView();
            this.label6 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.griditens = new System.Windows.Forms.DataGridView();
            this.cbolicitacao = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.button3 = new System.Windows.Forms.Button();
            this.button1 = new System.Windows.Forms.Button();
            this.pictureBox3 = new System.Windows.Forms.PictureBox();
            this.pictureBox2 = new System.Windows.Forms.PictureBox();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.BtnCotar = new System.Windows.Forms.Button();
            this.btnPesquisar = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.BtnGerarForn = new System.Windows.Forms.Button();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.GridFor)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.griditens)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.button3);
            this.groupBox1.Controls.Add(this.button1);
            this.groupBox1.Controls.Add(this.chkTodos);
            this.groupBox1.Controls.Add(this.pictureBox3);
            this.groupBox1.Controls.Add(this.pictureBox2);
            this.groupBox1.Controls.Add(this.pictureBox1);
            this.groupBox1.Controls.Add(this.BtnCotar);
            this.groupBox1.Controls.Add(this.label8);
            this.groupBox1.Controls.Add(this.label7);
            this.groupBox1.Controls.Add(this.GridFor);
            this.groupBox1.Controls.Add(this.label6);
            this.groupBox1.Controls.Add(this.label5);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.btnPesquisar);
            this.groupBox1.Controls.Add(this.griditens);
            this.groupBox1.Controls.Add(this.button2);
            this.groupBox1.Controls.Add(this.cbolicitacao);
            this.groupBox1.Controls.Add(this.BtnGerarForn);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.groupBox1.Location = new System.Drawing.Point(3, 3);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(1214, 672);
            this.groupBox1.TabIndex = 4;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Gerar Cotações";
            // 
            // chkTodos
            // 
            this.chkTodos.AutoSize = true;
            this.chkTodos.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.chkTodos.ForeColor = System.Drawing.SystemColors.Highlight;
            this.chkTodos.Location = new System.Drawing.Point(9, 276);
            this.chkTodos.Name = "chkTodos";
            this.chkTodos.Size = new System.Drawing.Size(151, 20);
            this.chkTodos.TabIndex = 366;
            this.chkTodos.Text = "Selecionar Todos";
            this.chkTodos.UseVisualStyleBackColor = true;
            this.chkTodos.CheckedChanged += new System.EventHandler(this.chkTodos_CheckedChanged);
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label8.Location = new System.Drawing.Point(407, 274);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(276, 20);
            this.label8.TabIndex = 283;
            this.label8.Text = "Itens do Fornecedor Selecionado";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.Location = new System.Drawing.Point(216, 64);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(333, 16);
            this.label7.TabIndex = 282;
            this.label7.Text = "Fornecedores com pelo menos 1 item do edital";
            // 
            // GridFor
            // 
            this.GridFor.AllowUserToAddRows = false;
            this.GridFor.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.GridFor.Location = new System.Drawing.Point(8, 82);
            this.GridFor.Margin = new System.Windows.Forms.Padding(2);
            this.GridFor.Name = "GridFor";
            this.GridFor.RowTemplate.Height = 24;
            this.GridFor.Size = new System.Drawing.Size(758, 189);
            this.GridFor.TabIndex = 281;
            this.GridFor.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.GridFor_CellClick);
            this.GridFor.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.GridFor_CellContentClick);
            this.GridFor.CellMouseClick += new System.Windows.Forms.DataGridViewCellMouseEventHandler(this.GridFor_CellMouseClick);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(673, 19);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(46, 13);
            this.label6.TabIndex = 280;
            this.label6.Text = "Cliente";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(374, 19);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(80, 13);
            this.label5.TabIndex = 279;
            this.label5.Text = "Nr. Processo";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(485, 19);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(86, 13);
            this.label4.TabIndex = 278;
            this.label4.Text = "Data Abertura";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(256, 19);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(80, 13);
            this.label3.TabIndex = 277;
            this.label3.Text = "Nr. Licitação";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(73, 19);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(72, 13);
            this.label2.TabIndex = 276;
            this.label2.Text = "Modalidade";
            // 
            // griditens
            // 
            this.griditens.AllowUserToAddRows = false;
            this.griditens.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.griditens.Location = new System.Drawing.Point(0, 296);
            this.griditens.Margin = new System.Windows.Forms.Padding(2);
            this.griditens.Name = "griditens";
            this.griditens.RowTemplate.Height = 24;
            this.griditens.Size = new System.Drawing.Size(1209, 301);
            this.griditens.TabIndex = 274;
            this.griditens.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.griditens_CellClick);
            // 
            // cbolicitacao
            // 
            this.cbolicitacao.Enabled = false;
            this.cbolicitacao.FormattingEnabled = true;
            this.cbolicitacao.Location = new System.Drawing.Point(6, 35);
            this.cbolicitacao.Name = "cbolicitacao";
            this.cbolicitacao.Size = new System.Drawing.Size(1043, 21);
            this.cbolicitacao.TabIndex = 59;
            this.cbolicitacao.SelectionChangeCommitted += new System.EventHandler(this.cbolicitacao_SelectionChangeCommitted);
            this.cbolicitacao.Click += new System.EventHandler(this.cbolicitacao_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(6, 19);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(39, 13);
            this.label1.TabIndex = 23;
            this.label1.Text = "Edital";
            // 
            // button3
            // 
            this.button3.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button3.Image = global::Prj_Cientifica.Properties.Resources._1287527_message_email_contact_mail_inbox_icon;
            this.button3.ImageAlign = System.Drawing.ContentAlignment.TopLeft;
            this.button3.Location = new System.Drawing.Point(377, 607);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(441, 59);
            this.button3.TabIndex = 369;
            this.button3.Text = "Enviar Solicitação de Preços p/Fornecedor  por E-mail";
            this.button3.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.button3.UseVisualStyleBackColor = true;
            this.button3.Click += new System.EventHandler(this.button3_Click);
            // 
            // button1
            // 
            this.button1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.button1.Image = global::Prj_Cientifica.Properties.Resources._3827994_business_cash_management_money_icon;
            this.button1.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.button1.Location = new System.Drawing.Point(965, 604);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(244, 35);
            this.button1.TabIndex = 367;
            this.button1.Text = "Consultar Ultimos Preços";
            this.button1.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // pictureBox3
            // 
            this.pictureBox3.Image = global::Prj_Cientifica.Properties.Resources.iconfinder_spray_medical_hands_gestures_medication_5859226;
            this.pictureBox3.Location = new System.Drawing.Point(939, 215);
            this.pictureBox3.Name = "pictureBox3";
            this.pictureBox3.Size = new System.Drawing.Size(100, 71);
            this.pictureBox3.SizeMode = System.Windows.Forms.PictureBoxSizeMode.CenterImage;
            this.pictureBox3.TabIndex = 287;
            this.pictureBox3.TabStop = false;
            // 
            // pictureBox2
            // 
            this.pictureBox2.Image = global::Prj_Cientifica.Properties.Resources.iconfinder__medicine_medication_pill_medical_healthcare_5928534;
            this.pictureBox2.Location = new System.Drawing.Point(774, 215);
            this.pictureBox2.Name = "pictureBox2";
            this.pictureBox2.Size = new System.Drawing.Size(71, 71);
            this.pictureBox2.SizeMode = System.Windows.Forms.PictureBoxSizeMode.CenterImage;
            this.pictureBox2.TabIndex = 286;
            this.pictureBox2.TabStop = false;
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = global::Prj_Cientifica.Properties.Resources.iconfinder_010___Medication_pills_tablets_prescription_coronavirus_5991790_1_;
            this.pictureBox1.Location = new System.Drawing.Point(1126, 219);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(78, 67);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.CenterImage;
            this.pictureBox1.TabIndex = 285;
            this.pictureBox1.TabStop = false;
            // 
            // BtnCotar
            // 
            this.BtnCotar.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.BtnCotar.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BtnCotar.Image = global::Prj_Cientifica.Properties.Resources.xxx037_64;
            this.BtnCotar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.BtnCotar.Location = new System.Drawing.Point(774, 158);
            this.BtnCotar.Name = "BtnCotar";
            this.BtnCotar.Size = new System.Drawing.Size(430, 55);
            this.BtnCotar.TabIndex = 284;
            this.BtnCotar.Text = "Cotar Item ";
            this.BtnCotar.UseVisualStyleBackColor = false;
            this.BtnCotar.Click += new System.EventHandler(this.BtnCotar_Click);
            // 
            // btnPesquisar
            // 
            this.btnPesquisar.Image = global::Prj_Cientifica.Properties.Resources.Search_Zoom_Magnifiyng_Find_321;
            this.btnPesquisar.Location = new System.Drawing.Point(1055, 19);
            this.btnPesquisar.Name = "btnPesquisar";
            this.btnPesquisar.Size = new System.Drawing.Size(50, 39);
            this.btnPesquisar.TabIndex = 275;
            this.btnPesquisar.UseVisualStyleBackColor = true;
            this.btnPesquisar.Click += new System.EventHandler(this.btnPesquisar_Click);
            // 
            // button2
            // 
            this.button2.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button2.Image = global::Prj_Cientifica.Properties.Resources._7938_32x322;
            this.button2.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.button2.Location = new System.Drawing.Point(774, 110);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(428, 42);
            this.button2.TabIndex = 62;
            this.button2.Text = "Pesquisar por Produto";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // BtnGerarForn
            // 
            this.BtnGerarForn.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BtnGerarForn.Image = global::Prj_Cientifica.Properties.Resources.free_37_32;
            this.BtnGerarForn.ImageAlign = System.Drawing.ContentAlignment.TopLeft;
            this.BtnGerarForn.Location = new System.Drawing.Point(771, 62);
            this.BtnGerarForn.Name = "BtnGerarForn";
            this.BtnGerarForn.Size = new System.Drawing.Size(429, 42);
            this.BtnGerarForn.TabIndex = 56;
            this.BtnGerarForn.Text = "Gerar Solicitação de Preços p/Fornecedor  Selec";
            this.BtnGerarForn.UseVisualStyleBackColor = true;
            this.BtnGerarForn.Click += new System.EventHandler(this.BtnGerarForn_Click);
            // 
            // ViewGerarCotacao
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1215, 676);
            this.Controls.Add(this.groupBox1);
            this.Name = "ViewGerarCotacao";
            this.Text = "Gerar Cotações";
            this.Load += new System.EventHandler(this.ViewGerarCotacao_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.GridFor)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.griditens)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.ComboBox cbolicitacao;
        private System.Windows.Forms.Button BtnGerarForn;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.DataGridView griditens;
        private System.Windows.Forms.Button btnPesquisar;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.DataGridView GridFor;
        private System.Windows.Forms.Button BtnCotar;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.PictureBox pictureBox2;
        private System.Windows.Forms.PictureBox pictureBox3;
        private System.Windows.Forms.CheckBox chkTodos;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button button3;
    }
}