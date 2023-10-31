namespace Prj_Cientifica
{
    partial class ViewConcederPermissoes
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
            this.cbousuarioatual = new System.Windows.Forms.ComboBox();
            this.label6 = new System.Windows.Forms.Label();
            this.cbousuariopermitir = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.btnConceder = new System.Windows.Forms.Button();
            this.BtnSair = new System.Windows.Forms.Button();
            this.BtnNovo = new System.Windows.Forms.Button();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.btnConceder);
            this.groupBox1.Controls.Add(this.cbousuariopermitir);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.cbousuarioatual);
            this.groupBox1.Controls.Add(this.label6);
            this.groupBox1.Controls.Add(this.BtnSair);
            this.groupBox1.Controls.Add(this.BtnNovo);
            this.groupBox1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox1.ForeColor = System.Drawing.Color.MediumBlue;
            this.groupBox1.Location = new System.Drawing.Point(12, 12);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(556, 260);
            this.groupBox1.TabIndex = 4;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Conceder Permissões";
            this.groupBox1.Enter += new System.EventHandler(this.groupBox1_Enter);
            // 
            // cbousuarioatual
            // 
            this.cbousuarioatual.FormattingEnabled = true;
            this.cbousuarioatual.Location = new System.Drawing.Point(8, 47);
            this.cbousuarioatual.Name = "cbousuarioatual";
            this.cbousuarioatual.Size = new System.Drawing.Size(507, 21);
            this.cbousuarioatual.TabIndex = 126;
            this.cbousuarioatual.Click += new System.EventHandler(this.cbousuarioatual_Click);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(192)))));
            this.label6.Location = new System.Drawing.Point(7, 31);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(83, 13);
            this.label6.TabIndex = 127;
            this.label6.Text = "Usuário Atual";
            // 
            // cbousuariopermitir
            // 
            this.cbousuariopermitir.FormattingEnabled = true;
            this.cbousuariopermitir.Location = new System.Drawing.Point(8, 112);
            this.cbousuariopermitir.Name = "cbousuariopermitir";
            this.cbousuariopermitir.Size = new System.Drawing.Size(507, 21);
            this.cbousuariopermitir.TabIndex = 128;
            this.cbousuariopermitir.Click += new System.EventHandler(this.cbousuariopermitir_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(192)))));
            this.label1.Location = new System.Drawing.Point(7, 96);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(107, 13);
            this.label1.TabIndex = 129;
            this.label1.Text = "Usuário a Permitir";
            // 
            // btnConceder
            // 
            this.btnConceder.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnConceder.Image = global::Prj_Cientifica.Properties.Resources.iconfinder_General_Office_38_3592827;
            this.btnConceder.ImageAlign = System.Drawing.ContentAlignment.TopLeft;
            this.btnConceder.Location = new System.Drawing.Point(105, 148);
            this.btnConceder.Name = "btnConceder";
            this.btnConceder.Size = new System.Drawing.Size(283, 39);
            this.btnConceder.TabIndex = 259;
            this.btnConceder.Text = "Conceder as Mesmas Permissões";
            this.btnConceder.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnConceder.UseVisualStyleBackColor = true;
            this.btnConceder.Click += new System.EventHandler(this.btnConceder_Click);
            // 
            // BtnSair
            // 
            this.BtnSair.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BtnSair.Image = global::Prj_Cientifica.Properties.Resources.enter_32;
            this.BtnSair.ImageAlign = System.Drawing.ContentAlignment.TopLeft;
            this.BtnSair.Location = new System.Drawing.Point(472, 211);
            this.BtnSair.Name = "BtnSair";
            this.BtnSair.Size = new System.Drawing.Size(78, 43);
            this.BtnSair.TabIndex = 58;
            this.BtnSair.Text = "Sair";
            this.BtnSair.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.BtnSair.UseVisualStyleBackColor = true;
            this.BtnSair.Click += new System.EventHandler(this.BtnSair_Click);
            // 
            // BtnNovo
            // 
            this.BtnNovo.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BtnNovo.Image = global::Prj_Cientifica.Properties.Resources.add_circle_blue_32;
            this.BtnNovo.ImageAlign = System.Drawing.ContentAlignment.TopLeft;
            this.BtnNovo.Location = new System.Drawing.Point(379, 213);
            this.BtnNovo.Name = "BtnNovo";
            this.BtnNovo.Size = new System.Drawing.Size(87, 41);
            this.BtnNovo.TabIndex = 56;
            this.BtnNovo.Text = "Novo";
            this.BtnNovo.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.BtnNovo.UseVisualStyleBackColor = true;
            this.BtnNovo.Click += new System.EventHandler(this.BtnNovo_Click);
            // 
            // ViewConcederPermissoes
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(574, 279);
            this.Controls.Add(this.groupBox1);
            this.Name = "ViewConcederPermissoes";
            this.Text = "Concessão de Permissões";
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Button BtnSair;
        private System.Windows.Forms.Button BtnNovo;
        private System.Windows.Forms.ComboBox cbousuariopermitir;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox cbousuarioatual;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Button btnConceder;
    }
}