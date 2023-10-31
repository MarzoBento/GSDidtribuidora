namespace Prj_Cientifica
{
    partial class ViewAdicionaItens
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
            this.DtGConsulta = new System.Windows.Forms.DataGridView();
            this.label2 = new System.Windows.Forms.Label();
            this.txtpesquisa = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.BtnAdd = new System.Windows.Forms.Button();
            this.BtnSair = new System.Windows.Forms.Button();
            this.chkprincipio = new System.Windows.Forms.RadioButton();
            this.chkProduto = new System.Windows.Forms.RadioButton();
            this.rbtcodigo = new System.Windows.Forms.RadioButton();
            this.chkmarca = new System.Windows.Forms.RadioButton();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            ((System.ComponentModel.ISupportInitialize)(this.DtGConsulta)).BeginInit();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // DtGConsulta
            // 
            this.DtGConsulta.AllowUserToAddRows = false;
            this.DtGConsulta.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.DtGConsulta.Location = new System.Drawing.Point(10, 78);
            this.DtGConsulta.Margin = new System.Windows.Forms.Padding(2);
            this.DtGConsulta.Name = "DtGConsulta";
            this.DtGConsulta.RowTemplate.Height = 24;
            this.DtGConsulta.Size = new System.Drawing.Size(1822, 441);
            this.DtGConsulta.TabIndex = 340;
            this.DtGConsulta.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.DtGConsulta_CellClick);
            this.DtGConsulta.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.DtGConsulta_CellContentClick);
            this.DtGConsulta.CellEndEdit += new System.Windows.Forms.DataGridViewCellEventHandler(this.DtGConsulta_CellEndEdit);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.Color.Blue;
            this.label2.Location = new System.Drawing.Point(820, 56);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(241, 20);
            this.label2.TabIndex = 341;
            this.label2.Text = "Pesquisar Itens para o Edital";
            // 
            // txtpesquisa
            // 
            this.txtpesquisa.Location = new System.Drawing.Point(383, 34);
            this.txtpesquisa.Name = "txtpesquisa";
            this.txtpesquisa.Size = new System.Drawing.Size(1439, 20);
            this.txtpesquisa.TabIndex = 0;
            this.txtpesquisa.TextChanged += new System.EventHandler(this.txtpesquisa_TextChanged_1);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.Blue;
            this.label1.Location = new System.Drawing.Point(389, 11);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(129, 20);
            this.label1.TabIndex = 343;
            this.label1.Text = "Pesquisar Item";
            // 
            // BtnAdd
            // 
            this.BtnAdd.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BtnAdd.Image = global::Prj_Cientifica.Properties.Resources._6578917_broom_clean_cleaning_housekeeping_icon2;
            this.BtnAdd.ImageAlign = System.Drawing.ContentAlignment.TopCenter;
            this.BtnAdd.Location = new System.Drawing.Point(1677, 524);
            this.BtnAdd.Name = "BtnAdd";
            this.BtnAdd.Size = new System.Drawing.Size(85, 57);
            this.BtnAdd.TabIndex = 345;
            this.BtnAdd.Text = "Limpar";
            this.BtnAdd.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.BtnAdd.UseVisualStyleBackColor = true;
            this.BtnAdd.Click += new System.EventHandler(this.BtnAdd_Click);
            // 
            // BtnSair
            // 
            this.BtnSair.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BtnSair.Image = global::Prj_Cientifica.Properties.Resources._2739118_door_entrance_exit_icon4;
            this.BtnSair.ImageAlign = System.Drawing.ContentAlignment.TopCenter;
            this.BtnSair.Location = new System.Drawing.Point(1768, 524);
            this.BtnSair.Name = "BtnSair";
            this.BtnSair.Size = new System.Drawing.Size(64, 57);
            this.BtnSair.TabIndex = 344;
            this.BtnSair.Text = "Sair";
            this.BtnSair.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.BtnSair.UseVisualStyleBackColor = true;
            this.BtnSair.Click += new System.EventHandler(this.BtnSair_Click_1);
            // 
            // chkprincipio
            // 
            this.chkprincipio.AutoSize = true;
            this.chkprincipio.ForeColor = System.Drawing.Color.Blue;
            this.chkprincipio.Location = new System.Drawing.Point(117, 34);
            this.chkprincipio.Name = "chkprincipio";
            this.chkprincipio.Size = new System.Drawing.Size(109, 17);
            this.chkprincipio.TabIndex = 346;
            this.chkprincipio.TabStop = true;
            this.chkprincipio.Text = "Principío Ativo";
            this.chkprincipio.UseVisualStyleBackColor = true;
            // 
            // chkProduto
            // 
            this.chkProduto.AutoSize = true;
            this.chkProduto.ForeColor = System.Drawing.Color.Blue;
            this.chkProduto.Location = new System.Drawing.Point(26, 33);
            this.chkProduto.Name = "chkProduto";
            this.chkProduto.Size = new System.Drawing.Size(69, 17);
            this.chkProduto.TabIndex = 347;
            this.chkProduto.TabStop = true;
            this.chkProduto.Text = "Produto";
            this.chkProduto.UseVisualStyleBackColor = true;
            // 
            // rbtcodigo
            // 
            this.rbtcodigo.AutoSize = true;
            this.rbtcodigo.ForeColor = System.Drawing.Color.Blue;
            this.rbtcodigo.Location = new System.Drawing.Point(242, 34);
            this.rbtcodigo.Name = "rbtcodigo";
            this.rbtcodigo.Size = new System.Drawing.Size(64, 17);
            this.rbtcodigo.TabIndex = 348;
            this.rbtcodigo.TabStop = true;
            this.rbtcodigo.Text = "Código";
            this.rbtcodigo.UseVisualStyleBackColor = true;
            // 
            // chkmarca
            // 
            this.chkmarca.AutoSize = true;
            this.chkmarca.ForeColor = System.Drawing.Color.Blue;
            this.chkmarca.Location = new System.Drawing.Point(312, 33);
            this.chkmarca.Name = "chkmarca";
            this.chkmarca.Size = new System.Drawing.Size(60, 17);
            this.chkmarca.TabIndex = 349;
            this.chkmarca.TabStop = true;
            this.chkmarca.Text = "Marca";
            this.chkmarca.UseVisualStyleBackColor = true;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.chkmarca);
            this.groupBox1.Controls.Add(this.rbtcodigo);
            this.groupBox1.Controls.Add(this.chkProduto);
            this.groupBox1.Controls.Add(this.chkprincipio);
            this.groupBox1.Controls.Add(this.BtnSair);
            this.groupBox1.Controls.Add(this.BtnAdd);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.txtpesquisa);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.DtGConsulta);
            this.groupBox1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox1.Location = new System.Drawing.Point(1, 3);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(1837, 595);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Adicionar Itens ao Edital";
            // 
            // ViewAdicionaItens
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1850, 598);
            this.Controls.Add(this.groupBox1);
            this.Name = "ViewAdicionaItens";
            this.Text = "Adicionar Itens ao Edital";
            this.Load += new System.EventHandler(this.ViewAdicionaItens_Load);
            ((System.ComponentModel.ISupportInitialize)(this.DtGConsulta)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView DtGConsulta;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtpesquisa;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button BtnAdd;
        private System.Windows.Forms.Button BtnSair;
        private System.Windows.Forms.RadioButton chkprincipio;
        private System.Windows.Forms.RadioButton chkProduto;
        private System.Windows.Forms.RadioButton rbtcodigo;
        private System.Windows.Forms.RadioButton chkmarca;
        private System.Windows.Forms.GroupBox groupBox1;
    }
}