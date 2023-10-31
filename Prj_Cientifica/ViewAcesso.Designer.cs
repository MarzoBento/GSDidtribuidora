namespace Prj_Cientifica
{
    partial class ViewAcesso
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            this.label1 = new System.Windows.Forms.Label();
            this.cbousuario = new System.Windows.Forms.ComboBox();
            this.label6 = new System.Windows.Forms.Label();
            this.cbomenu = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.cboopcoes = new System.Windows.Forms.ComboBox();
            this.cbopermissao = new System.Windows.Forms.ComboBox();
            this.label4 = new System.Windows.Forms.Label();
            this.cboempresa = new System.Windows.Forms.ComboBox();
            this.label5 = new System.Windows.Forms.Label();
            this.griditens = new System.Windows.Forms.DataGridView();
            this.button1 = new System.Windows.Forms.Button();
            this.btnBusca = new System.Windows.Forms.Button();
            this.BtnSalvar = new System.Windows.Forms.Button();
            this.btnSair = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.griditens)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(192)))));
            this.label1.Location = new System.Drawing.Point(170, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(520, 25);
            this.label1.TabIndex = 123;
            this.label1.Text = "Controle de Permissões de Usuários do Sistema";
            // 
            // cbousuario
            // 
            this.cbousuario.FormattingEnabled = true;
            this.cbousuario.Location = new System.Drawing.Point(9, 40);
            this.cbousuario.Name = "cbousuario";
            this.cbousuario.Size = new System.Drawing.Size(775, 21);
            this.cbousuario.TabIndex = 124;
            this.cbousuario.Click += new System.EventHandler(this.cbousuario_Click);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(192)))));
            this.label6.Location = new System.Drawing.Point(6, 24);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(62, 16);
            this.label6.TabIndex = 125;
            this.label6.Text = "Usuário";
            // 
            // cbomenu
            // 
            this.cbomenu.FormattingEnabled = true;
            this.cbomenu.Items.AddRange(new object[] {
            "Cadastro",
            "Painel",
            "Documentos",
            "Processos Licitatórios",
            "Gerar Cotações",
            "Retorno de Cotações",
            "Formação de Preços",
            "Proposta",
            "Realinhamento de Proposta",
            "Concorrentes",
            "Mapa de Preços",
            "Empenho",
            "Entrega"});
            this.cbomenu.Location = new System.Drawing.Point(9, 88);
            this.cbomenu.Name = "cbomenu";
            this.cbomenu.Size = new System.Drawing.Size(291, 21);
            this.cbomenu.TabIndex = 126;
            this.cbomenu.Click += new System.EventHandler(this.cbomenu_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(192)))));
            this.label2.Location = new System.Drawing.Point(6, 72);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(45, 16);
            this.label2.TabIndex = 127;
            this.label2.Text = "Menu";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(192)))));
            this.label3.Location = new System.Drawing.Point(303, 72);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(62, 16);
            this.label3.TabIndex = 128;
            this.label3.Text = "Opções";
            // 
            // cboopcoes
            // 
            this.cboopcoes.FormattingEnabled = true;
            this.cboopcoes.Location = new System.Drawing.Point(306, 88);
            this.cboopcoes.Name = "cboopcoes";
            this.cboopcoes.Size = new System.Drawing.Size(278, 21);
            this.cboopcoes.TabIndex = 129;
            this.cboopcoes.Click += new System.EventHandler(this.cboopcoes_Click);
            // 
            // cbopermissao
            // 
            this.cbopermissao.FormattingEnabled = true;
            this.cbopermissao.Items.AddRange(new object[] {
            "SIM",
            "NAO"});
            this.cbopermissao.Location = new System.Drawing.Point(590, 88);
            this.cbopermissao.Name = "cbopermissao";
            this.cbopermissao.Size = new System.Drawing.Size(194, 21);
            this.cbopermissao.TabIndex = 131;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(192)))));
            this.label4.Location = new System.Drawing.Point(587, 72);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(82, 16);
            this.label4.TabIndex = 130;
            this.label4.Text = "Permissao";
            // 
            // cboempresa
            // 
            this.cboempresa.FormattingEnabled = true;
            this.cboempresa.Location = new System.Drawing.Point(9, 143);
            this.cboempresa.Name = "cboempresa";
            this.cboempresa.Size = new System.Drawing.Size(775, 21);
            this.cboempresa.TabIndex = 132;
            this.cboempresa.Click += new System.EventHandler(this.cboempresa_Click);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(192)))));
            this.label5.Location = new System.Drawing.Point(6, 124);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(70, 16);
            this.label5.TabIndex = 133;
            this.label5.Text = "Empresa";
            // 
            // griditens
            // 
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.griditens.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.griditens.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.griditens.DefaultCellStyle = dataGridViewCellStyle2;
            this.griditens.Location = new System.Drawing.Point(3, 187);
            this.griditens.Margin = new System.Windows.Forms.Padding(2);
            this.griditens.Name = "griditens";
            this.griditens.RowTemplate.Height = 24;
            this.griditens.Size = new System.Drawing.Size(1085, 472);
            this.griditens.TabIndex = 256;
            this.griditens.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.griditens_CellClick);
            // 
            // button1
            // 
            this.button1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button1.Image = global::Prj_Cientifica.Properties.Resources.EditDocument_24;
            this.button1.ImageAlign = System.Drawing.ContentAlignment.TopLeft;
            this.button1.Location = new System.Drawing.Point(790, 133);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(298, 39);
            this.button1.TabIndex = 258;
            this.button1.Text = "Conceder  as mesmas  Permissões";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // btnBusca
            // 
            this.btnBusca.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnBusca.ForeColor = System.Drawing.Color.Black;
            this.btnBusca.Image = global::Prj_Cientifica.Properties.Resources._7938_32x321;
            this.btnBusca.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnBusca.Location = new System.Drawing.Point(790, 30);
            this.btnBusca.Name = "btnBusca";
            this.btnBusca.Size = new System.Drawing.Size(298, 39);
            this.btnBusca.TabIndex = 257;
            this.btnBusca.Text = "Visualizar Permissões de Usuário";
            this.btnBusca.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnBusca.UseVisualStyleBackColor = true;
            this.btnBusca.Click += new System.EventHandler(this.btnBusca_Click);
            // 
            // BtnSalvar
            // 
            this.BtnSalvar.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BtnSalvar.Image = global::Prj_Cientifica.Properties.Resources.floppy_32;
            this.BtnSalvar.ImageAlign = System.Drawing.ContentAlignment.TopLeft;
            this.BtnSalvar.Location = new System.Drawing.Point(790, 78);
            this.BtnSalvar.Name = "BtnSalvar";
            this.BtnSalvar.Size = new System.Drawing.Size(298, 39);
            this.BtnSalvar.TabIndex = 122;
            this.BtnSalvar.Text = "Adicionar Permissão ao Usuário";
            this.BtnSalvar.UseVisualStyleBackColor = true;
            this.BtnSalvar.Click += new System.EventHandler(this.BtnSalvar_Click);
            // 
            // btnSair
            // 
            this.btnSair.BackColor = System.Drawing.SystemColors.Highlight;
            this.btnSair.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSair.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.btnSair.Image = global::Prj_Cientifica.Properties.Resources.enter_322;
            this.btnSair.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnSair.Location = new System.Drawing.Point(952, 664);
            this.btnSair.Name = "btnSair";
            this.btnSair.Size = new System.Drawing.Size(136, 57);
            this.btnSair.TabIndex = 312;
            this.btnSair.Text = "Sair";
            this.btnSair.UseVisualStyleBackColor = false;
            this.btnSair.Click += new System.EventHandler(this.btnSair_Click);
            // 
            // ViewAcesso
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1092, 730);
            this.Controls.Add(this.btnSair);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.btnBusca);
            this.Controls.Add(this.griditens);
            this.Controls.Add(this.cboempresa);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.cbopermissao);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.cboopcoes);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.cbomenu);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.cbousuario);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.BtnSalvar);
            this.Name = "ViewAcesso";
            this.Text = "Controle de Acesso do Usuário";
            ((System.ComponentModel.ISupportInitialize)(this.griditens)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Button BtnSalvar;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox cbousuario;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.ComboBox cbomenu;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.ComboBox cboopcoes;
        private System.Windows.Forms.ComboBox cbopermissao;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.ComboBox cboempresa;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.DataGridView griditens;
        private System.Windows.Forms.Button btnBusca;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button btnSair;
    }
}