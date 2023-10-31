namespace Prj_Cientifica
{
    partial class ViewDecrecimo
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
            this.txtdecrescimo = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.button1 = new System.Windows.Forms.Button();
            this.btnDecrecimo = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // txtdecrescimo
            // 
            this.txtdecrescimo.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtdecrescimo.Location = new System.Drawing.Point(123, 40);
            this.txtdecrescimo.Name = "txtdecrescimo";
            this.txtdecrescimo.Size = new System.Drawing.Size(130, 26);
            this.txtdecrescimo.TabIndex = 0;
            this.txtdecrescimo.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtdecrescimo_KeyPress);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.SystemColors.HotTrack;
            this.label1.Location = new System.Drawing.Point(94, 8);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(185, 20);
            this.label1.TabIndex = 1;
            this.label1.Text = "Informe o Decréscimo";
            // 
            // button1
            // 
            this.button1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button1.ForeColor = System.Drawing.Color.Maroon;
            this.button1.Image = global::Prj_Cientifica.Properties.Resources.error;
            this.button1.ImageAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.button1.Location = new System.Drawing.Point(332, 88);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(58, 38);
            this.button1.TabIndex = 2;
            this.button1.Text = "Fechar";
            this.button1.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // btnDecrecimo
            // 
            this.btnDecrecimo.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnDecrecimo.ForeColor = System.Drawing.SystemColors.MenuHighlight;
            this.btnDecrecimo.Image = global::Prj_Cientifica.Properties.Resources.xxx037_642;
            this.btnDecrecimo.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnDecrecimo.Location = new System.Drawing.Point(81, 82);
            this.btnDecrecimo.Name = "btnDecrecimo";
            this.btnDecrecimo.Size = new System.Drawing.Size(216, 44);
            this.btnDecrecimo.TabIndex = 1;
            this.btnDecrecimo.Text = "Aplicar Decréscimo";
            this.btnDecrecimo.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnDecrecimo.UseVisualStyleBackColor = true;
            this.btnDecrecimo.Click += new System.EventHandler(this.btnDecrecimo_Click);
            // 
            // ViewDecrecimo
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(393, 129);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.btnDecrecimo);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.txtdecrescimo);
            this.Name = "ViewDecrecimo";
            this.Text = "Alterar Preços por % Decréscimo";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox txtdecrescimo;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btnDecrecimo;
        private System.Windows.Forms.Button button1;
    }
}