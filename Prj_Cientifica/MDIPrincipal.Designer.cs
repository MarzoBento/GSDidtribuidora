namespace Prj_Cientifica
{
    partial class MDIPrincipal
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MDIPrincipal));
            this.statusStrip = new System.Windows.Forms.StatusStrip();
            this.toolStripStatusLabel = new System.Windows.Forms.ToolStripStatusLabel();
            this.toolTip = new System.Windows.Forms.ToolTip(this.components);
            this.menuStrip = new System.Windows.Forms.MenuStrip();
            this.PainelMenu = new System.Windows.Forms.ToolStripMenuItem();
            this.cadastroMenu = new System.Windows.Forms.ToolStripMenuItem();
            this.docMenu = new System.Windows.Forms.ToolStripMenuItem();
            this.ProcessoMenu = new System.Windows.Forms.ToolStripMenuItem();
            this.GerarCotacaoMenu = new System.Windows.Forms.ToolStripMenuItem();
            this.RetornoCotacaoMenu = new System.Windows.Forms.ToolStripMenuItem();
            this.FormacaoMenu = new System.Windows.Forms.ToolStripMenuItem();
            this.PropostaMenu = new System.Windows.Forms.ToolStripMenuItem();
            this.RealinhadaPropostaMenu = new System.Windows.Forms.ToolStripMenuItem();
            this.MapaMenu = new System.Windows.Forms.ToolStripMenuItem();
            this.EmpenhoMenu = new System.Windows.Forms.ToolStripMenuItem();
            this.EntregaMenu = new System.Windows.Forms.ToolStripMenuItem();
            this.RelMenu = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.statusStrip.SuspendLayout();
            this.menuStrip.SuspendLayout();
            this.SuspendLayout();
            // 
            // statusStrip
            // 
            this.statusStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripStatusLabel});
            this.statusStrip.Location = new System.Drawing.Point(0, 431);
            this.statusStrip.Name = "statusStrip";
            this.statusStrip.Size = new System.Drawing.Size(1318, 22);
            this.statusStrip.TabIndex = 2;
            this.statusStrip.Text = "StatusStrip";
            this.statusStrip.ItemClicked += new System.Windows.Forms.ToolStripItemClickedEventHandler(this.statusStrip_ItemClicked);
            // 
            // toolStripStatusLabel
            // 
            this.toolStripStatusLabel.Name = "toolStripStatusLabel";
            this.toolStripStatusLabel.Size = new System.Drawing.Size(39, 17);
            this.toolStripStatusLabel.Text = "Status";
            // 
            // menuStrip
            // 
            this.menuStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.PainelMenu,
            this.cadastroMenu,
            this.docMenu,
            this.ProcessoMenu,
            this.GerarCotacaoMenu,
            this.RetornoCotacaoMenu,
            this.FormacaoMenu,
            this.PropostaMenu,
            this.RealinhadaPropostaMenu,
            this.MapaMenu,
            this.EmpenhoMenu,
            this.EntregaMenu,
            this.RelMenu,
            this.toolStripMenuItem1});
            this.menuStrip.Location = new System.Drawing.Point(0, 0);
            this.menuStrip.Name = "menuStrip";
            this.menuStrip.Size = new System.Drawing.Size(1318, 71);
            this.menuStrip.TabIndex = 0;
            this.menuStrip.Text = "MenuStrip";
            // 
            // PainelMenu
            // 
            this.PainelMenu.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.PainelMenu.ForeColor = System.Drawing.Color.Blue;
            this.PainelMenu.Image = ((System.Drawing.Image)(resources.GetObject("PainelMenu.Image")));
            this.PainelMenu.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.PainelMenu.Name = "PainelMenu";
            this.PainelMenu.ShowShortcutKeys = false;
            this.PainelMenu.Size = new System.Drawing.Size(120, 67);
            this.PainelMenu.Text = "Painel de Controle";
            this.PainelMenu.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.PainelMenu.Click += new System.EventHandler(this.PainelMenu_Click);
            // 
            // cadastroMenu
            // 
            this.cadastroMenu.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cadastroMenu.ForeColor = System.Drawing.Color.Blue;
            this.cadastroMenu.Image = ((System.Drawing.Image)(resources.GetObject("cadastroMenu.Image")));
            this.cadastroMenu.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.cadastroMenu.Name = "cadastroMenu";
            this.cadastroMenu.Size = new System.Drawing.Size(72, 67);
            this.cadastroMenu.Text = "Cadastros";
            this.cadastroMenu.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            // 
            // docMenu
            // 
            this.docMenu.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.docMenu.ForeColor = System.Drawing.Color.Blue;
            this.docMenu.Image = ((System.Drawing.Image)(resources.GetObject("docMenu.Image")));
            this.docMenu.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.docMenu.Name = "docMenu";
            this.docMenu.Size = new System.Drawing.Size(90, 67);
            this.docMenu.Text = "Documentos";
            this.docMenu.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            // 
            // ProcessoMenu
            // 
            this.ProcessoMenu.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ProcessoMenu.ForeColor = System.Drawing.Color.Blue;
            this.ProcessoMenu.Image = ((System.Drawing.Image)(resources.GetObject("ProcessoMenu.Image")));
            this.ProcessoMenu.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.ProcessoMenu.Name = "ProcessoMenu";
            this.ProcessoMenu.Size = new System.Drawing.Size(122, 67);
            this.ProcessoMenu.Text = "Cadastrar Licitação";
            this.ProcessoMenu.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.ProcessoMenu.Click += new System.EventHandler(this.ProcessoMenu_Click);
            // 
            // GerarCotacaoMenu
            // 
            this.GerarCotacaoMenu.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.GerarCotacaoMenu.ForeColor = System.Drawing.Color.Blue;
            this.GerarCotacaoMenu.Image = ((System.Drawing.Image)(resources.GetObject("GerarCotacaoMenu.Image")));
            this.GerarCotacaoMenu.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.GerarCotacaoMenu.Name = "GerarCotacaoMenu";
            this.GerarCotacaoMenu.Size = new System.Drawing.Size(98, 67);
            this.GerarCotacaoMenu.Text = "Gerar Cotação";
            this.GerarCotacaoMenu.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.GerarCotacaoMenu.Click += new System.EventHandler(this.GerarCotacaoMenu_Click);
            // 
            // RetornoCotacaoMenu
            // 
            this.RetornoCotacaoMenu.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.RetornoCotacaoMenu.ForeColor = System.Drawing.Color.Blue;
            this.RetornoCotacaoMenu.Image = ((System.Drawing.Image)(resources.GetObject("RetornoCotacaoMenu.Image")));
            this.RetornoCotacaoMenu.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.RetornoCotacaoMenu.Name = "RetornoCotacaoMenu";
            this.RetornoCotacaoMenu.Size = new System.Drawing.Size(135, 67);
            this.RetornoCotacaoMenu.Text = "Retorno de Cotações";
            this.RetornoCotacaoMenu.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.RetornoCotacaoMenu.Click += new System.EventHandler(this.toolStripMenuItem1_Click);
            // 
            // FormacaoMenu
            // 
            this.FormacaoMenu.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FormacaoMenu.ForeColor = System.Drawing.Color.Blue;
            this.FormacaoMenu.Image = ((System.Drawing.Image)(resources.GetObject("FormacaoMenu.Image")));
            this.FormacaoMenu.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.FormacaoMenu.Name = "FormacaoMenu";
            this.FormacaoMenu.Size = new System.Drawing.Size(130, 67);
            this.FormacaoMenu.Text = "Formação de Preços";
            this.FormacaoMenu.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            // 
            // PropostaMenu
            // 
            this.PropostaMenu.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.PropostaMenu.ForeColor = System.Drawing.Color.Blue;
            this.PropostaMenu.Image = ((System.Drawing.Image)(resources.GetObject("PropostaMenu.Image")));
            this.PropostaMenu.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.PropostaMenu.Name = "PropostaMenu";
            this.PropostaMenu.Size = new System.Drawing.Size(68, 67);
            this.PropostaMenu.Text = "Proposta";
            this.PropostaMenu.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.PropostaMenu.Click += new System.EventHandler(this.PropostaMenu_Click);
            // 
            // RealinhadaPropostaMenu
            // 
            this.RealinhadaPropostaMenu.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.RealinhadaPropostaMenu.ForeColor = System.Drawing.Color.Blue;
            this.RealinhadaPropostaMenu.Image = ((System.Drawing.Image)(resources.GetObject("RealinhadaPropostaMenu.Image")));
            this.RealinhadaPropostaMenu.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.RealinhadaPropostaMenu.Name = "RealinhadaPropostaMenu";
            this.RealinhadaPropostaMenu.Size = new System.Drawing.Size(103, 67);
            this.RealinhadaPropostaMenu.Text = "Realinhamento";
            this.RealinhadaPropostaMenu.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            // 
            // MapaMenu
            // 
            this.MapaMenu.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.MapaMenu.ForeColor = System.Drawing.Color.Blue;
            this.MapaMenu.Image = ((System.Drawing.Image)(resources.GetObject("MapaMenu.Image")));
            this.MapaMenu.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.MapaMenu.Name = "MapaMenu";
            this.MapaMenu.Size = new System.Drawing.Size(106, 67);
            this.MapaMenu.Text = "Mapa de Preços";
            this.MapaMenu.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            // 
            // EmpenhoMenu
            // 
            this.EmpenhoMenu.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.EmpenhoMenu.ForeColor = System.Drawing.Color.Blue;
            this.EmpenhoMenu.Image = ((System.Drawing.Image)(resources.GetObject("EmpenhoMenu.Image")));
            this.EmpenhoMenu.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.EmpenhoMenu.Name = "EmpenhoMenu";
            this.EmpenhoMenu.Size = new System.Drawing.Size(71, 67);
            this.EmpenhoMenu.Text = "Empenho";
            this.EmpenhoMenu.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            // 
            // EntregaMenu
            // 
            this.EntregaMenu.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.EntregaMenu.ForeColor = System.Drawing.Color.Blue;
            this.EntregaMenu.Image = ((System.Drawing.Image)(resources.GetObject("EntregaMenu.Image")));
            this.EntregaMenu.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.EntregaMenu.Name = "EntregaMenu";
            this.EntregaMenu.Size = new System.Drawing.Size(62, 67);
            this.EntregaMenu.Text = "Entrega";
            this.EntregaMenu.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            // 
            // RelMenu
            // 
            this.RelMenu.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.RelMenu.ForeColor = System.Drawing.Color.Blue;
            this.RelMenu.Image = ((System.Drawing.Image)(resources.GetObject("RelMenu.Image")));
            this.RelMenu.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.RelMenu.Name = "RelMenu";
            this.RelMenu.Size = new System.Drawing.Size(75, 67);
            this.RelMenu.Text = "Relatórios";
            this.RelMenu.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            // 
            // toolStripMenuItem1
            // 
            this.toolStripMenuItem1.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.toolStripMenuItem1.ForeColor = System.Drawing.Color.Blue;
            this.toolStripMenuItem1.Image = ((System.Drawing.Image)(resources.GetObject("toolStripMenuItem1.Image")));
            this.toolStripMenuItem1.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.toolStripMenuItem1.Name = "toolStripMenuItem1";
            this.toolStripMenuItem1.Size = new System.Drawing.Size(60, 67);
            this.toolStripMenuItem1.Text = "Sair";
            this.toolStripMenuItem1.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.toolStripMenuItem1.Click += new System.EventHandler(this.toolStripMenuItem1_Click_1);
            // 
            // MDIPrincipal
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1318, 453);
            this.Controls.Add(this.statusStrip);
            this.Controls.Add(this.menuStrip);
            this.IsMdiContainer = true;
            this.MainMenuStrip = this.menuStrip;
            this.Name = "MDIPrincipal";
            this.Text = "Sistema de Gestão de Licitações";
            this.Load += new System.EventHandler(this.MDIPrincipal_Load);
            this.statusStrip.ResumeLayout(false);
            this.statusStrip.PerformLayout();
            this.menuStrip.ResumeLayout(false);
            this.menuStrip.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }
        #endregion

        private System.Windows.Forms.StatusStrip statusStrip;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabel;
        private System.Windows.Forms.ToolTip toolTip;
        private System.Windows.Forms.MenuStrip menuStrip;
        private System.Windows.Forms.ToolStripMenuItem cadastroMenu;
        public System.Windows.Forms.ToolStripMenuItem PainelMenu;
        private System.Windows.Forms.ToolStripMenuItem docMenu;
        private System.Windows.Forms.ToolStripMenuItem ProcessoMenu;
        private System.Windows.Forms.ToolStripMenuItem GerarCotacaoMenu;
        private System.Windows.Forms.ToolStripMenuItem RetornoCotacaoMenu;
        private System.Windows.Forms.ToolStripMenuItem PropostaMenu;
        private System.Windows.Forms.ToolStripMenuItem RealinhadaPropostaMenu;
        private System.Windows.Forms.ToolStripMenuItem FormacaoMenu;
        private System.Windows.Forms.ToolStripMenuItem RelMenu;
        private System.Windows.Forms.ToolStripMenuItem MapaMenu;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem EmpenhoMenu;
        private System.Windows.Forms.ToolStripMenuItem EntregaMenu;
    }
}



