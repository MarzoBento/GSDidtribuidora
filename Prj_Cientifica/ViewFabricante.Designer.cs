namespace Prj_Cientifica
{
    partial class ViewFabricante
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
            this.cbocidade = new System.Windows.Forms.ComboBox();
            this.label6 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.txtfantasia = new System.Windows.Forms.TextBox();
            this.label20 = new System.Windows.Forms.Label();
            this.maskcnpj = new System.Windows.Forms.MaskedTextBox();
            this.BtnSair = new System.Windows.Forms.Button();
            this.BtnRemover = new System.Windows.Forms.Button();
            this.BtnSalvar = new System.Windows.Forms.Button();
            this.BtnNovo = new System.Windows.Forms.Button();
            this.btnPesquisar = new System.Windows.Forms.Button();
            this.label4 = new System.Windows.Forms.Label();
            this.txtcodigo = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.txtnome = new System.Windows.Forms.TextBox();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.cbocidade);
            this.groupBox1.Controls.Add(this.label6);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.txtfantasia);
            this.groupBox1.Controls.Add(this.label20);
            this.groupBox1.Controls.Add(this.maskcnpj);
            this.groupBox1.Controls.Add(this.BtnSair);
            this.groupBox1.Controls.Add(this.BtnRemover);
            this.groupBox1.Controls.Add(this.BtnSalvar);
            this.groupBox1.Controls.Add(this.BtnNovo);
            this.groupBox1.Controls.Add(this.btnPesquisar);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Controls.Add(this.txtcodigo);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.txtnome);
            this.groupBox1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.groupBox1.Location = new System.Drawing.Point(3, 0);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(631, 289);
            this.groupBox1.TabIndex = 7;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Cadastro de Fabricante";
            // 
            // cbocidade
            // 
            this.cbocidade.FormattingEnabled = true;
            this.cbocidade.Location = new System.Drawing.Point(6, 177);
            this.cbocidade.Name = "cbocidade";
            this.cbocidade.Size = new System.Drawing.Size(617, 21);
            this.cbocidade.TabIndex = 112;
            this.cbocidade.Click += new System.EventHandler(this.cbocidade_Click);
            this.cbocidade.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.cbocidade_KeyPress);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(6, 161);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(46, 13);
            this.label6.TabIndex = 113;
            this.label6.Text = "Cidade";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(145, 116);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(91, 13);
            this.label2.TabIndex = 111;
            this.label2.Text = "Nome Fantasia";
            // 
            // txtfantasia
            // 
            this.txtfantasia.Location = new System.Drawing.Point(148, 130);
            this.txtfantasia.Name = "txtfantasia";
            this.txtfantasia.Size = new System.Drawing.Size(475, 20);
            this.txtfantasia.TabIndex = 110;
            this.txtfantasia.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtfantasia_KeyPress);
            // 
            // label20
            // 
            this.label20.AutoSize = true;
            this.label20.Location = new System.Drawing.Point(4, 116);
            this.label20.Name = "label20";
            this.label20.Size = new System.Drawing.Size(32, 13);
            this.label20.TabIndex = 109;
            this.label20.Text = "Cnpj";
            // 
            // maskcnpj
            // 
            this.maskcnpj.Location = new System.Drawing.Point(6, 130);
            this.maskcnpj.Mask = "00.000.000/0000-00";
            this.maskcnpj.Name = "maskcnpj";
            this.maskcnpj.Size = new System.Drawing.Size(136, 20);
            this.maskcnpj.TabIndex = 108;
            this.maskcnpj.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.maskcnpj_KeyPress);
            // 
            // BtnSair
            // 
            this.BtnSair.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BtnSair.Image = global::Prj_Cientifica.Properties.Resources.enter_32;
            this.BtnSair.ImageAlign = System.Drawing.ContentAlignment.TopCenter;
            this.BtnSair.Location = new System.Drawing.Point(216, 218);
            this.BtnSair.Name = "BtnSair";
            this.BtnSair.Size = new System.Drawing.Size(64, 57);
            this.BtnSair.TabIndex = 58;
            this.BtnSair.Text = "Sair";
            this.BtnSair.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.BtnSair.UseVisualStyleBackColor = true;
            this.BtnSair.Click += new System.EventHandler(this.BtnSair_Click);
            // 
            // BtnRemover
            // 
            this.BtnRemover.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BtnRemover.Image = global::Prj_Cientifica.Properties.Resources.blue_trash_32;
            this.BtnRemover.ImageAlign = System.Drawing.ContentAlignment.TopCenter;
            this.BtnRemover.Location = new System.Drawing.Point(144, 218);
            this.BtnRemover.Name = "BtnRemover";
            this.BtnRemover.Size = new System.Drawing.Size(66, 57);
            this.BtnRemover.TabIndex = 57;
            this.BtnRemover.Text = "Excluir";
            this.BtnRemover.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.BtnRemover.UseVisualStyleBackColor = true;
            this.BtnRemover.Click += new System.EventHandler(this.BtnRemover_Click);
            // 
            // BtnSalvar
            // 
            this.BtnSalvar.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BtnSalvar.Image = global::Prj_Cientifica.Properties.Resources.floppy_32;
            this.BtnSalvar.ImageAlign = System.Drawing.ContentAlignment.TopCenter;
            this.BtnSalvar.Location = new System.Drawing.Point(73, 218);
            this.BtnSalvar.Name = "BtnSalvar";
            this.BtnSalvar.Size = new System.Drawing.Size(65, 57);
            this.BtnSalvar.TabIndex = 55;
            this.BtnSalvar.Text = "Salvar";
            this.BtnSalvar.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.BtnSalvar.UseVisualStyleBackColor = true;
            this.BtnSalvar.Click += new System.EventHandler(this.BtnSalvar_Click);
            // 
            // BtnNovo
            // 
            this.BtnNovo.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BtnNovo.Image = global::Prj_Cientifica.Properties.Resources.add_circle_blue_32;
            this.BtnNovo.ImageAlign = System.Drawing.ContentAlignment.TopCenter;
            this.BtnNovo.Location = new System.Drawing.Point(7, 218);
            this.BtnNovo.Name = "BtnNovo";
            this.BtnNovo.Size = new System.Drawing.Size(60, 57);
            this.BtnNovo.TabIndex = 56;
            this.BtnNovo.Text = "Novo";
            this.BtnNovo.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.BtnNovo.UseVisualStyleBackColor = true;
            this.BtnNovo.Click += new System.EventHandler(this.BtnNovo_Click);
            // 
            // btnPesquisar
            // 
            this.btnPesquisar.Image = global::Prj_Cientifica.Properties.Resources._7938_16x16;
            this.btnPesquisar.Location = new System.Drawing.Point(97, 37);
            this.btnPesquisar.Name = "btnPesquisar";
            this.btnPesquisar.Size = new System.Drawing.Size(32, 23);
            this.btnPesquisar.TabIndex = 54;
            this.btnPesquisar.UseVisualStyleBackColor = true;
            this.btnPesquisar.Click += new System.EventHandler(this.btnPesquisar_Click);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(6, 21);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(46, 13);
            this.label4.TabIndex = 52;
            this.label4.Text = "Código";
            // 
            // txtcodigo
            // 
            this.txtcodigo.Enabled = false;
            this.txtcodigo.Location = new System.Drawing.Point(6, 37);
            this.txtcodigo.Name = "txtcodigo";
            this.txtcodigo.Size = new System.Drawing.Size(85, 20);
            this.txtcodigo.TabIndex = 51;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(6, 74);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(82, 13);
            this.label1.TabIndex = 23;
            this.label1.Text = "Razão Social";
            // 
            // txtnome
            // 
            this.txtnome.Location = new System.Drawing.Point(6, 88);
            this.txtnome.Name = "txtnome";
            this.txtnome.Size = new System.Drawing.Size(618, 20);
            this.txtnome.TabIndex = 16;
            this.txtnome.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtnome_KeyPress);
            // 
            // ViewFabricante
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(638, 291);
            this.Controls.Add(this.groupBox1);
            this.Name = "ViewFabricante";
            this.Text = "Cadstro de Fabricante";
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Button BtnSair;
        private System.Windows.Forms.Button BtnRemover;
        private System.Windows.Forms.Button BtnSalvar;
        private System.Windows.Forms.Button BtnNovo;
        private System.Windows.Forms.Button btnPesquisar;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox txtcodigo;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtnome;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label20;
        private System.Windows.Forms.MaskedTextBox maskcnpj;
        private System.Windows.Forms.ComboBox cbocidade;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox txtfantasia;
    }
}