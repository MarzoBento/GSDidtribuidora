namespace Prj_Cientifica
{
    partial class ViewPropostaRealinhada
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
            this.components = new System.ComponentModel.Container();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            this.label1 = new System.Windows.Forms.Label();
            this.cbolicitacao = new System.Windows.Forms.ComboBox();
            this.griditens = new System.Windows.Forms.DataGridView();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.cbocliente = new System.Windows.Forms.ComboBox();
            this.label7 = new System.Windows.Forms.Label();
            this.panel2 = new System.Windows.Forms.Panel();
            this.labTotal = new System.Windows.Forms.Label();
            this.panel3 = new System.Windows.Forms.Panel();
            this.label10 = new System.Windows.Forms.Label();
            this.cboDadosBancario = new System.Windows.Forms.ComboBox();
            this.label8 = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.chknaoganhou = new System.Windows.Forms.CheckBox();
            this.chkganhou = new System.Windows.Forms.CheckBox();
            this.label44 = new System.Windows.Forms.Label();
            this.txttotalitens = new System.Windows.Forms.TextBox();
            this.chkTodos = new System.Windows.Forms.CheckBox();
            this.label19 = new System.Windows.Forms.Label();
            this.txtpesquisa = new System.Windows.Forms.TextBox();
            this.checkNaoImprimirTodos = new System.Windows.Forms.CheckBox();
            this.checkImprimirTodos = new System.Windows.Forms.CheckBox();
            this.listarq = new System.Windows.Forms.ListBox();
            this.btnEmpenho = new System.Windows.Forms.Button();
            this.btnExtrair = new System.Windows.Forms.Button();
            this.button4 = new System.Windows.Forms.Button();
            this.label13 = new System.Windows.Forms.Label();
            this.mskdata = new System.Windows.Forms.MaskedTextBox();
            this.cmbstatus = new System.Windows.Forms.ComboBox();
            this.label12 = new System.Windows.Forms.Label();
            this.txtobs = new System.Windows.Forms.TextBox();
            this.label11 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.Grid = new System.Windows.Forms.DataGridView();
            this.rbt3casas = new System.Windows.Forms.RadioButton();
            this.rbt2casas = new System.Windows.Forms.RadioButton();
            this.rbt4casas = new System.Windows.Forms.RadioButton();
            this.btnSair = new System.Windows.Forms.Button();
            this.btnImprimir_Itens = new System.Windows.Forms.Button();
            this.BtnImprimirProposta = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.button1 = new System.Windows.Forms.Button();
            this.btnSalvar = new System.Windows.Forms.Button();
            this.btnPesquisar = new System.Windows.Forms.Button();
            this.toolTip1 = new System.Windows.Forms.ToolTip(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.griditens)).BeginInit();
            this.panel2.SuspendLayout();
            this.panel3.SuspendLayout();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.Grid)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(8, 18);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(39, 13);
            this.label1.TabIndex = 23;
            this.label1.Text = "Edital";
            // 
            // cbolicitacao
            // 
            this.cbolicitacao.Enabled = false;
            this.cbolicitacao.FormattingEnabled = true;
            this.cbolicitacao.Location = new System.Drawing.Point(11, 34);
            this.cbolicitacao.Name = "cbolicitacao";
            this.cbolicitacao.Size = new System.Drawing.Size(673, 21);
            this.cbolicitacao.TabIndex = 59;
            this.cbolicitacao.SelectionChangeCommitted += new System.EventHandler(this.cbolicitacao_SelectionChangeCommitted);
            this.cbolicitacao.Click += new System.EventHandler(this.cbolicitacao_Click);
            // 
            // griditens
            // 
            this.griditens.AllowUserToAddRows = false;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Microsoft Sans Serif", 6F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.griditens.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
            this.griditens.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.griditens.Location = new System.Drawing.Point(8, 218);
            this.griditens.Margin = new System.Windows.Forms.Padding(2);
            this.griditens.Name = "griditens";
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Microsoft Sans Serif", 6F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.griditens.RowsDefaultCellStyle = dataGridViewCellStyle2;
            this.griditens.RowTemplate.Height = 24;
            this.griditens.Size = new System.Drawing.Size(1334, 334);
            this.griditens.TabIndex = 274;
            this.griditens.MultiSelectChanged += new System.EventHandler(this.griditens_MultiSelectChanged);
            this.griditens.CellBeginEdit += new System.Windows.Forms.DataGridViewCellCancelEventHandler(this.griditens_CellBeginEdit);
            this.griditens.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.griditens_CellClick);
            this.griditens.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.griditens_CellContentClick);
            this.griditens.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.griditens_CellDoubleClick);
            this.griditens.CellEndEdit += new System.Windows.Forms.DataGridViewCellEventHandler(this.griditens_CellEndEdit);
            this.griditens.CellEnter += new System.Windows.Forms.DataGridViewCellEventHandler(this.griditens_CellEnter);
            this.griditens.CellMouseClick += new System.Windows.Forms.DataGridViewCellMouseEventHandler(this.griditens_CellMouseClick);
            this.griditens.CellValidated += new System.Windows.Forms.DataGridViewCellEventHandler(this.griditens_CellValidated);
            this.griditens.CellValueChanged += new System.Windows.Forms.DataGridViewCellEventHandler(this.griditens_CellValueChanged);
            this.griditens.CurrentCellDirtyStateChanged += new System.EventHandler(this.griditens_CurrentCellDirtyStateChanged);
            this.griditens.DataError += new System.Windows.Forms.DataGridViewDataErrorEventHandler(this.griditens_DataError);
            this.griditens.EditingControlShowing += new System.Windows.Forms.DataGridViewEditingControlShowingEventHandler(this.griditens_EditingControlShowing);
            this.griditens.Enter += new System.EventHandler(this.griditens_Enter);
            this.griditens.KeyDown += new System.Windows.Forms.KeyEventHandler(this.griditens_KeyDown);
            this.griditens.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.griditens_KeyPress);
            this.griditens.Validated += new System.EventHandler(this.griditens_Validated);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(75, 18);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(72, 13);
            this.label2.TabIndex = 276;
            this.label2.Text = "Modalidade";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(258, 18);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(73, 13);
            this.label3.TabIndex = 277;
            this.label3.Text = "Nr. Liitação";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(487, 18);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(86, 13);
            this.label4.TabIndex = 278;
            this.label4.Text = "Data Abertura";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(376, 18);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(80, 13);
            this.label5.TabIndex = 279;
            this.label5.Text = "Nr. Processo";
            // 
            // cbocliente
            // 
            this.cbocliente.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbocliente.FormattingEnabled = true;
            this.cbocliente.Location = new System.Drawing.Point(11, 75);
            this.cbocliente.Name = "cbocliente";
            this.cbocliente.Size = new System.Drawing.Size(673, 21);
            this.cbocliente.TabIndex = 288;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(11, 59);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(46, 13);
            this.label7.TabIndex = 289;
            this.label7.Text = "Cliente";
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.Color.LightBlue;
            this.panel2.Controls.Add(this.labTotal);
            this.panel2.Controls.Add(this.panel3);
            this.panel2.Location = new System.Drawing.Point(1107, 559);
            this.panel2.Margin = new System.Windows.Forms.Padding(2);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(208, 74);
            this.panel2.TabIndex = 296;
            // 
            // labTotal
            // 
            this.labTotal.AutoSize = true;
            this.labTotal.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labTotal.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.labTotal.Location = new System.Drawing.Point(73, 34);
            this.labTotal.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.labTotal.Name = "labTotal";
            this.labTotal.Size = new System.Drawing.Size(60, 24);
            this.labTotal.TabIndex = 0;
            this.labTotal.Text = "00,00";
            // 
            // panel3
            // 
            this.panel3.BackColor = System.Drawing.Color.Blue;
            this.panel3.Controls.Add(this.label10);
            this.panel3.Location = new System.Drawing.Point(0, 0);
            this.panel3.Margin = new System.Windows.Forms.Padding(2);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(208, 32);
            this.panel3.TabIndex = 295;
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label10.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.label10.Location = new System.Drawing.Point(36, 0);
            this.label10.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(102, 16);
            this.label10.TabIndex = 0;
            this.label10.Text = "Total Produto";
            // 
            // cboDadosBancario
            // 
            this.cboDadosBancario.FormattingEnabled = true;
            this.cboDadosBancario.Location = new System.Drawing.Point(11, 119);
            this.cboDadosBancario.Name = "cboDadosBancario";
            this.cboDadosBancario.Size = new System.Drawing.Size(673, 21);
            this.cboDadosBancario.TabIndex = 312;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(11, 103);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(103, 13);
            this.label8.TabIndex = 313;
            this.label8.Text = "Dados Bancários";
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.chknaoganhou);
            this.groupBox1.Controls.Add(this.chkganhou);
            this.groupBox1.Controls.Add(this.label44);
            this.groupBox1.Controls.Add(this.txttotalitens);
            this.groupBox1.Controls.Add(this.chkTodos);
            this.groupBox1.Controls.Add(this.label19);
            this.groupBox1.Controls.Add(this.txtpesquisa);
            this.groupBox1.Controls.Add(this.checkNaoImprimirTodos);
            this.groupBox1.Controls.Add(this.checkImprimirTodos);
            this.groupBox1.Controls.Add(this.listarq);
            this.groupBox1.Controls.Add(this.btnEmpenho);
            this.groupBox1.Controls.Add(this.btnExtrair);
            this.groupBox1.Controls.Add(this.button4);
            this.groupBox1.Controls.Add(this.label13);
            this.groupBox1.Controls.Add(this.mskdata);
            this.groupBox1.Controls.Add(this.cmbstatus);
            this.groupBox1.Controls.Add(this.label12);
            this.groupBox1.Controls.Add(this.txtobs);
            this.groupBox1.Controls.Add(this.label11);
            this.groupBox1.Controls.Add(this.label9);
            this.groupBox1.Controls.Add(this.Grid);
            this.groupBox1.Controls.Add(this.rbt3casas);
            this.groupBox1.Controls.Add(this.griditens);
            this.groupBox1.Controls.Add(this.rbt2casas);
            this.groupBox1.Controls.Add(this.rbt4casas);
            this.groupBox1.Controls.Add(this.label8);
            this.groupBox1.Controls.Add(this.cboDadosBancario);
            this.groupBox1.Controls.Add(this.btnSair);
            this.groupBox1.Controls.Add(this.btnImprimir_Itens);
            this.groupBox1.Controls.Add(this.BtnImprimirProposta);
            this.groupBox1.Controls.Add(this.button2);
            this.groupBox1.Controls.Add(this.button1);
            this.groupBox1.Controls.Add(this.btnSalvar);
            this.groupBox1.Controls.Add(this.panel2);
            this.groupBox1.Controls.Add(this.label7);
            this.groupBox1.Controls.Add(this.cbocliente);
            this.groupBox1.Controls.Add(this.label5);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.btnPesquisar);
            this.groupBox1.Controls.Add(this.cbolicitacao);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.groupBox1.Location = new System.Drawing.Point(3, 3);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(1347, 635);
            this.groupBox1.TabIndex = 7;
            this.groupBox1.TabStop = false;
            this.groupBox1.Enter += new System.EventHandler(this.groupBox1_Enter);
            // 
            // chknaoganhou
            // 
            this.chknaoganhou.AutoSize = true;
            this.chknaoganhou.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.chknaoganhou.ForeColor = System.Drawing.SystemColors.Highlight;
            this.chknaoganhou.Location = new System.Drawing.Point(672, 155);
            this.chknaoganhou.Name = "chknaoganhou";
            this.chknaoganhou.Size = new System.Drawing.Size(129, 24);
            this.chknaoganhou.TabIndex = 427;
            this.chknaoganhou.Text = "Não Ganhou";
            this.chknaoganhou.UseVisualStyleBackColor = true;
            this.chknaoganhou.CheckedChanged += new System.EventHandler(this.chknaoganhou_CheckedChanged);
            // 
            // chkganhou
            // 
            this.chkganhou.AutoSize = true;
            this.chkganhou.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.chkganhou.ForeColor = System.Drawing.SystemColors.Highlight;
            this.chkganhou.Location = new System.Drawing.Point(574, 155);
            this.chkganhou.Name = "chkganhou";
            this.chkganhou.Size = new System.Drawing.Size(92, 24);
            this.chkganhou.TabIndex = 426;
            this.chkganhou.Text = "Ganhou";
            this.chkganhou.UseVisualStyleBackColor = true;
            this.chkganhou.CheckedChanged += new System.EventHandler(this.chkganhou_CheckedChanged);
            // 
            // label44
            // 
            this.label44.AutoSize = true;
            this.label44.Location = new System.Drawing.Point(1241, 173);
            this.label44.Name = "label44";
            this.label44.Size = new System.Drawing.Size(86, 13);
            this.label44.TabIndex = 423;
            this.label44.Text = "Total de Itens";
            // 
            // txttotalitens
            // 
            this.txttotalitens.Enabled = false;
            this.txttotalitens.Location = new System.Drawing.Point(1234, 193);
            this.txttotalitens.Name = "txttotalitens";
            this.txttotalitens.Size = new System.Drawing.Size(108, 20);
            this.txttotalitens.TabIndex = 422;
            this.txttotalitens.Text = "0";
            this.txttotalitens.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // chkTodos
            // 
            this.chkTodos.AutoSize = true;
            this.chkTodos.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.chkTodos.ForeColor = System.Drawing.SystemColors.Highlight;
            this.chkTodos.Location = new System.Drawing.Point(401, 155);
            this.chkTodos.Name = "chkTodos";
            this.chkTodos.Size = new System.Drawing.Size(167, 24);
            this.chkTodos.TabIndex = 421;
            this.chkTodos.Text = "Selecionar Todos";
            this.chkTodos.UseVisualStyleBackColor = true;
            this.chkTodos.CheckedChanged += new System.EventHandler(this.chkTodos_CheckedChanged_1);
            // 
            // label19
            // 
            this.label19.AutoSize = true;
            this.label19.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label19.ForeColor = System.Drawing.SystemColors.Highlight;
            this.label19.Location = new System.Drawing.Point(13, 191);
            this.label19.Name = "label19";
            this.label19.Size = new System.Drawing.Size(134, 20);
            this.label19.TabIndex = 420;
            this.label19.Text = "Pesquisar Itens";
            // 
            // txtpesquisa
            // 
            this.txtpesquisa.Location = new System.Drawing.Point(169, 193);
            this.txtpesquisa.Name = "txtpesquisa";
            this.txtpesquisa.Size = new System.Drawing.Size(1054, 20);
            this.txtpesquisa.TabIndex = 419;
            this.txtpesquisa.TextChanged += new System.EventHandler(this.txtpesquisa_TextChanged);
            // 
            // checkNaoImprimirTodos
            // 
            this.checkNaoImprimirTodos.AutoSize = true;
            this.checkNaoImprimirTodos.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.checkNaoImprimirTodos.ForeColor = System.Drawing.SystemColors.Highlight;
            this.checkNaoImprimirTodos.Location = new System.Drawing.Point(251, 155);
            this.checkNaoImprimirTodos.Name = "checkNaoImprimirTodos";
            this.checkNaoImprimirTodos.Size = new System.Drawing.Size(144, 24);
            this.checkNaoImprimirTodos.TabIndex = 418;
            this.checkNaoImprimirTodos.Text = "Não Imprimir ?";
            this.checkNaoImprimirTodos.UseVisualStyleBackColor = true;
            this.checkNaoImprimirTodos.CheckedChanged += new System.EventHandler(this.checkNaoImprimirTodos_CheckedChanged);
            // 
            // checkImprimirTodos
            // 
            this.checkImprimirTodos.AutoSize = true;
            this.checkImprimirTodos.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.checkImprimirTodos.ForeColor = System.Drawing.SystemColors.Highlight;
            this.checkImprimirTodos.Location = new System.Drawing.Point(136, 155);
            this.checkImprimirTodos.Name = "checkImprimirTodos";
            this.checkImprimirTodos.Size = new System.Drawing.Size(112, 24);
            this.checkImprimirTodos.TabIndex = 417;
            this.checkImprimirTodos.Text = "Imprimir  ?";
            this.checkImprimirTodos.UseVisualStyleBackColor = true;
            this.checkImprimirTodos.CheckedChanged += new System.EventHandler(this.checkImprimirTodos_CheckedChanged);
            // 
            // listarq
            // 
            this.listarq.FormattingEnabled = true;
            this.listarq.Location = new System.Drawing.Point(1026, 587);
            this.listarq.Name = "listarq";
            this.listarq.Size = new System.Drawing.Size(44, 30);
            this.listarq.TabIndex = 400;
            this.listarq.Visible = false;
            // 
            // btnEmpenho
            // 
            this.btnEmpenho.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnEmpenho.Image = global::Prj_Cientifica.Properties.Resources.empenho;
            this.btnEmpenho.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnEmpenho.Location = new System.Drawing.Point(792, 14);
            this.btnEmpenho.Name = "btnEmpenho";
            this.btnEmpenho.Size = new System.Drawing.Size(240, 39);
            this.btnEmpenho.TabIndex = 399;
            this.btnEmpenho.Text = "Informações do Empenho";
            this.btnEmpenho.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnEmpenho.UseVisualStyleBackColor = true;
            this.btnEmpenho.Click += new System.EventHandler(this.btnEmpenho_Click);
            // 
            // btnExtrair
            // 
            this.btnExtrair.ForeColor = System.Drawing.Color.Blue;
            this.btnExtrair.Image = global::Prj_Cientifica.Properties.Resources.zip;
            this.btnExtrair.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnExtrair.Location = new System.Drawing.Point(897, 82);
            this.btnExtrair.Name = "btnExtrair";
            this.btnExtrair.Size = new System.Drawing.Size(135, 43);
            this.btnExtrair.TabIndex = 398;
            this.btnExtrair.Text = "Extrair Doc";
            this.btnExtrair.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnExtrair.UseVisualStyleBackColor = true;
            this.btnExtrair.Click += new System.EventHandler(this.btnExtrair_Click);
            // 
            // button4
            // 
            this.button4.ForeColor = System.Drawing.Color.Blue;
            this.button4.Image = global::Prj_Cientifica.Properties.Resources.EditDocument_244;
            this.button4.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.button4.Location = new System.Drawing.Point(779, 85);
            this.button4.Name = "button4";
            this.button4.Size = new System.Drawing.Size(112, 40);
            this.button4.TabIndex = 397;
            this.button4.Text = "Adicionar Doc";
            this.button4.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.button4.UseVisualStyleBackColor = true;
            this.button4.Click += new System.EventHandler(this.button4_Click);
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Location = new System.Drawing.Point(687, 80);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(34, 13);
            this.label13.TabIndex = 396;
            this.label13.Text = "Data";
            // 
            // mskdata
            // 
            this.mskdata.Location = new System.Drawing.Point(690, 96);
            this.mskdata.Mask = "00/00/0000";
            this.mskdata.Name = "mskdata";
            this.mskdata.Size = new System.Drawing.Size(83, 20);
            this.mskdata.TabIndex = 395;
            this.mskdata.ValidatingType = typeof(System.DateTime);
            // 
            // cmbstatus
            // 
            this.cmbstatus.FormattingEnabled = true;
            this.cmbstatus.Items.AddRange(new object[] {
            "SOLICITADO CANCELAMENTO",
            "CANCELAMENTO DEFERIDO",
            "CANCELAMENTO INDEFERIDO",
            "SOLICITADO REALINHAMENTO",
            "REALINHAMENTO DEFERIDO",
            "REALINHAMENTO INDEFERIDO",
            "SOLICITADO TROCA DE MARCA COM REALINHAMENTO/REVISÃO DE PREÇO",
            "TROCA DE MARCA COM REALINHAMENTO/REVISÃO DE PREÇO DEFERIDO",
            "TROCA DE MARCA COM REALINHAMENTO/REVISÃO DE PREÇO INDEFERIDO",
            "SOLICITADO TROCA DE MARCA",
            "TROCA DE MARCA DEFERIDO",
            "TROCA DE MARACA INDEFERIDO"});
            this.cmbstatus.Location = new System.Drawing.Point(690, 59);
            this.cmbstatus.Name = "cmbstatus";
            this.cmbstatus.Size = new System.Drawing.Size(342, 21);
            this.cmbstatus.TabIndex = 381;
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label12.Location = new System.Drawing.Point(687, 42);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(99, 15);
            this.label12.TabIndex = 380;
            this.label12.Text = "Status do Item";
            // 
            // txtobs
            // 
            this.txtobs.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtobs.Location = new System.Drawing.Point(675, 573);
            this.txtobs.Multiline = true;
            this.txtobs.Name = "txtobs";
            this.txtobs.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.txtobs.Size = new System.Drawing.Size(345, 54);
            this.txtobs.TabIndex = 379;
            this.txtobs.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label11.Location = new System.Drawing.Point(672, 557);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(134, 15);
            this.label11.TabIndex = 378;
            this.label11.Text = "Observação do Item";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label9.ForeColor = System.Drawing.SystemColors.Highlight;
            this.label9.Location = new System.Drawing.Point(1074, 11);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(224, 16);
            this.label9.TabIndex = 377;
            this.label9.Text = "Documentos de Realinhamento";
            // 
            // Grid
            // 
            this.Grid.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.Grid.Location = new System.Drawing.Point(1038, 30);
            this.Grid.Name = "Grid";
            this.Grid.Size = new System.Drawing.Size(304, 133);
            this.Grid.TabIndex = 376;
            this.Grid.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.Grid_CellClick);
            this.Grid.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.Grid_CellDoubleClick);
            // 
            // rbt3casas
            // 
            this.rbt3casas.AutoSize = true;
            this.rbt3casas.Location = new System.Drawing.Point(0, 162);
            this.rbt3casas.Name = "rbt3casas";
            this.rbt3casas.Size = new System.Drawing.Size(125, 17);
            this.rbt3casas.TabIndex = 317;
            this.rbt3casas.TabStop = true;
            this.rbt3casas.Text = "3 Casas Decimais";
            this.rbt3casas.UseVisualStyleBackColor = true;
            this.rbt3casas.Visible = false;
            this.rbt3casas.CheckedChanged += new System.EventHandler(this.rbt3casas_CheckedChanged);
            // 
            // rbt2casas
            // 
            this.rbt2casas.AutoSize = true;
            this.rbt2casas.Location = new System.Drawing.Point(-2, 146);
            this.rbt2casas.Name = "rbt2casas";
            this.rbt2casas.Size = new System.Drawing.Size(125, 17);
            this.rbt2casas.TabIndex = 316;
            this.rbt2casas.TabStop = true;
            this.rbt2casas.Text = "2 Casas Decimais";
            this.rbt2casas.UseVisualStyleBackColor = true;
            this.rbt2casas.Visible = false;
            this.rbt2casas.CheckedChanged += new System.EventHandler(this.rbt2casas_CheckedChanged);
            // 
            // rbt4casas
            // 
            this.rbt4casas.AutoSize = true;
            this.rbt4casas.Location = new System.Drawing.Point(5, 173);
            this.rbt4casas.Name = "rbt4casas";
            this.rbt4casas.Size = new System.Drawing.Size(125, 17);
            this.rbt4casas.TabIndex = 315;
            this.rbt4casas.TabStop = true;
            this.rbt4casas.Text = "4 Casas Decimais";
            this.rbt4casas.UseVisualStyleBackColor = true;
            this.rbt4casas.Visible = false;
            this.rbt4casas.CheckedChanged += new System.EventHandler(this.rbt4casas_CheckedChanged);
            // 
            // btnSair
            // 
            this.btnSair.BackColor = System.Drawing.SystemColors.Highlight;
            this.btnSair.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSair.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.btnSair.Image = global::Prj_Cientifica.Properties.Resources._2739118_door_entrance_exit_icon5;
            this.btnSair.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnSair.Location = new System.Drawing.Point(437, 577);
            this.btnSair.Name = "btnSair";
            this.btnSair.Size = new System.Drawing.Size(111, 42);
            this.btnSair.TabIndex = 311;
            this.btnSair.Text = "Sair";
            this.btnSair.UseVisualStyleBackColor = false;
            this.btnSair.Click += new System.EventHandler(this.btnSair_Click);
            // 
            // btnImprimir_Itens
            // 
            this.btnImprimir_Itens.BackColor = System.Drawing.SystemColors.Highlight;
            this.btnImprimir_Itens.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnImprimir_Itens.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.btnImprimir_Itens.Image = global::Prj_Cientifica.Properties.Resources._226565_printer_icon4;
            this.btnImprimir_Itens.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnImprimir_Itens.Location = new System.Drawing.Point(287, 575);
            this.btnImprimir_Itens.Name = "btnImprimir_Itens";
            this.btnImprimir_Itens.Size = new System.Drawing.Size(144, 44);
            this.btnImprimir_Itens.TabIndex = 310;
            this.btnImprimir_Itens.Text = "Proposta Item";
            this.btnImprimir_Itens.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnImprimir_Itens.UseVisualStyleBackColor = false;
            this.btnImprimir_Itens.Click += new System.EventHandler(this.btnImprimir_Itens_Click);
            // 
            // BtnImprimirProposta
            // 
            this.BtnImprimirProposta.BackColor = System.Drawing.SystemColors.Highlight;
            this.BtnImprimirProposta.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BtnImprimirProposta.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.BtnImprimirProposta.Image = global::Prj_Cientifica.Properties.Resources._226565_printer_icon4;
            this.BtnImprimirProposta.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.BtnImprimirProposta.Location = new System.Drawing.Point(142, 575);
            this.BtnImprimirProposta.Name = "BtnImprimirProposta";
            this.BtnImprimirProposta.Size = new System.Drawing.Size(139, 44);
            this.BtnImprimirProposta.TabIndex = 309;
            this.BtnImprimirProposta.Text = "Proposta Lote";
            this.BtnImprimirProposta.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.BtnImprimirProposta.UseVisualStyleBackColor = false;
            this.BtnImprimirProposta.Click += new System.EventHandler(this.BtnImprimirProposta_Click);
            // 
            // button2
            // 
            this.button2.Image = global::Prj_Cientifica.Properties.Resources.EditDocument_243;
            this.button2.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.button2.Location = new System.Drawing.Point(919, 122);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(113, 32);
            this.button2.TabIndex = 299;
            this.button2.Text = "Editar Marca";
            this.button2.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Visible = false;
            // 
            // button1
            // 
            this.button1.Image = global::Prj_Cientifica.Properties.Resources.search_20;
            this.button1.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.button1.Location = new System.Drawing.Point(800, 122);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(113, 32);
            this.button1.TabIndex = 298;
            this.button1.Text = "Localizar Item";
            this.button1.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Visible = false;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // btnSalvar
            // 
            this.btnSalvar.BackColor = System.Drawing.SystemColors.Highlight;
            this.btnSalvar.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSalvar.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.btnSalvar.Image = global::Prj_Cientifica.Properties.Resources.floppy_321;
            this.btnSalvar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnSalvar.Location = new System.Drawing.Point(14, 575);
            this.btnSalvar.Name = "btnSalvar";
            this.btnSalvar.Size = new System.Drawing.Size(122, 44);
            this.btnSalvar.TabIndex = 297;
            this.btnSalvar.Text = "Gravar";
            this.btnSalvar.UseVisualStyleBackColor = false;
            this.btnSalvar.Click += new System.EventHandler(this.btnSalvar_Click);
            // 
            // btnPesquisar
            // 
            this.btnPesquisar.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnPesquisar.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(192)))));
            this.btnPesquisar.Image = global::Prj_Cientifica.Properties.Resources._48796_search_icon;
            this.btnPesquisar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnPesquisar.Location = new System.Drawing.Point(690, 9);
            this.btnPesquisar.Name = "btnPesquisar";
            this.btnPesquisar.Size = new System.Drawing.Size(96, 34);
            this.btnPesquisar.TabIndex = 275;
            this.btnPesquisar.Text = "Buscar";
            this.btnPesquisar.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnPesquisar.UseVisualStyleBackColor = true;
            this.btnPesquisar.Click += new System.EventHandler(this.btnPesquisar_Click);
            // 
            // toolTip1
            // 
            this.toolTip1.Draw += new System.Windows.Forms.DrawToolTipEventHandler(this.toolTip1_Draw);
            // 
            // ViewPropostaRealinhada
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1351, 647);
            this.Controls.Add(this.groupBox1);
            this.Name = "ViewPropostaRealinhada";
            this.Text = "Realinhamento de Proposta";
            this.Load += new System.EventHandler(this.ViewPropostaRealinhada_Load);
            ((System.ComponentModel.ISupportInitialize)(this.griditens)).EndInit();
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.panel3.ResumeLayout(false);
            this.panel3.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.Grid)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox cbolicitacao;
        private System.Windows.Forms.DataGridView griditens;
        private System.Windows.Forms.Button btnPesquisar;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.ComboBox cbocliente;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Label labTotal;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Button btnSalvar;
        private System.Windows.Forms.Button BtnImprimirProposta;
        private System.Windows.Forms.Button btnImprimir_Itens;
        private System.Windows.Forms.Button btnSair;
        private System.Windows.Forms.ComboBox cboDadosBancario;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.RadioButton rbt2casas;
        private System.Windows.Forms.RadioButton rbt4casas;
        private System.Windows.Forms.RadioButton rbt3casas;
        private System.Windows.Forms.ToolTip toolTip1;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.DataGridView Grid;
        private System.Windows.Forms.TextBox txtobs;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.ComboBox cmbstatus;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.MaskedTextBox mskdata;
        private System.Windows.Forms.Button btnExtrair;
        private System.Windows.Forms.Button button4;
        private System.Windows.Forms.Button btnEmpenho;
        private System.Windows.Forms.ListBox listarq;
        private System.Windows.Forms.CheckBox checkNaoImprimirTodos;
        private System.Windows.Forms.CheckBox checkImprimirTodos;
        private System.Windows.Forms.Label label19;
        private System.Windows.Forms.TextBox txtpesquisa;
        private System.Windows.Forms.CheckBox chkTodos;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Label label44;
        private System.Windows.Forms.TextBox txttotalitens;
        private System.Windows.Forms.CheckBox chkganhou;
        private System.Windows.Forms.CheckBox chknaoganhou;
    }
}