namespace Prj_Cientifica
{
    partial class ConsFornecedorItem
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
            this.griditens = new System.Windows.Forms.DataGridView();
            this.GridFor = new System.Windows.Forms.DataGridView();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.griditens)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.GridFor)).BeginInit();
            this.SuspendLayout();
            // 
            // griditens
            // 
            this.griditens.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.griditens.Location = new System.Drawing.Point(12, 34);
            this.griditens.Name = "griditens";
            this.griditens.Size = new System.Drawing.Size(954, 210);
            this.griditens.TabIndex = 5;
            this.griditens.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.griditens_CellClick);
            // 
            // GridFor
            // 
            this.GridFor.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.GridFor.Location = new System.Drawing.Point(12, 288);
            this.GridFor.Name = "GridFor";
            this.GridFor.Size = new System.Drawing.Size(954, 241);
            this.GridFor.TabIndex = 6;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(420, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(165, 24);
            this.label1.TabIndex = 7;
            this.label1.Text = "Itens da Cotação";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(420, 261);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(142, 24);
            this.label2.TabIndex = 8;
            this.label2.Text = "Fornecedores";
            // 
            // ConsFornecedorItem
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(975, 594);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.GridFor);
            this.Controls.Add(this.griditens);
            this.Name = "ConsFornecedorItem";
            this.Text = "Consultar Fornecedor Por Item";
            ((System.ComponentModel.ISupportInitialize)(this.griditens)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.GridFor)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView griditens;
        private System.Windows.Forms.DataGridView GridFor;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
    }
}