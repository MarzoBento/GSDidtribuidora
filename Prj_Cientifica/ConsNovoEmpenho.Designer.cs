﻿namespace Prj_Cientifica
{
    partial class ConsNovoEmpenho
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
            this.label1 = new System.Windows.Forms.Label();
            this.BtnSair = new System.Windows.Forms.Button();
            this.BtnLimpar = new System.Windows.Forms.Button();
            this.DtGConsulta = new System.Windows.Forms.DataGridView();
            this.txtpesquisa = new System.Windows.Forms.TextBox();
            this.chkedital = new System.Windows.Forms.RadioButton();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.DtGConsulta)).BeginInit();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.chkedital);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.BtnSair);
            this.groupBox1.Controls.Add(this.BtnLimpar);
            this.groupBox1.Controls.Add(this.DtGConsulta);
            this.groupBox1.Controls.Add(this.txtpesquisa);
            this.groupBox1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox1.ForeColor = System.Drawing.Color.Black;
            this.groupBox1.Location = new System.Drawing.Point(12, 12);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(964, 429);
            this.groupBox1.TabIndex = 8;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Consultar Edital";
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
            // 
            // DtGConsulta
            // 
            this.DtGConsulta.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.DtGConsulta.Location = new System.Drawing.Point(6, 76);
            this.DtGConsulta.Name = "DtGConsulta";
            this.DtGConsulta.Size = new System.Drawing.Size(949, 275);
            this.DtGConsulta.TabIndex = 4;
            this.DtGConsulta.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.DtGConsulta_CellClick);
            // 
            // txtpesquisa
            // 
            this.txtpesquisa.Location = new System.Drawing.Point(6, 48);
            this.txtpesquisa.Name = "txtpesquisa";
            this.txtpesquisa.Size = new System.Drawing.Size(949, 22);
            this.txtpesquisa.TabIndex = 2;
            this.txtpesquisa.TextChanged += new System.EventHandler(this.txtpesquisa_TextChanged);
            // 
            // chkedital
            // 
            this.chkedital.AutoSize = true;
            this.chkedital.Location = new System.Drawing.Point(153, 21);
            this.chkedital.Name = "chkedital";
            this.chkedital.Size = new System.Drawing.Size(124, 20);
            this.chkedital.TabIndex = 13;
            this.chkedital.TabStop = true;
            this.chkedital.Text = "Numero Edital";
            this.chkedital.UseVisualStyleBackColor = true;
            // 
            // ConsNovoEmpenho
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(979, 443);
            this.Controls.Add(this.groupBox1);
            this.Name = "ConsNovoEmpenho";
            this.Text = "Novo Empenho";
            this.Load += new System.EventHandler(this.ConsNovoEmpenho_Load);
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
        private System.Windows.Forms.RadioButton chkedital;
    }
}