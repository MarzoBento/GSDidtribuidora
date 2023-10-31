namespace Prj_Cientifica
{
    partial class RelGerarCotacao
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
            Microsoft.Reporting.WinForms.ReportDataSource reportDataSource1 = new Microsoft.Reporting.WinForms.ReportDataSource();
            this.View_GerarCotacaoBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.DtGerarCotacao = new Prj_Cientifica.DtGerarCotacao();
            this.View_GerarCotacaoTableAdapter = new Prj_Cientifica.DtGerarCotacaoTableAdapters.View_GerarCotacaoTableAdapter();
            this.reportViewer1 = new Microsoft.Reporting.WinForms.ReportViewer();
            ((System.ComponentModel.ISupportInitialize)(this.View_GerarCotacaoBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.DtGerarCotacao)).BeginInit();
            this.SuspendLayout();
            // 
            // View_GerarCotacaoBindingSource
            // 
            this.View_GerarCotacaoBindingSource.DataMember = "View_GerarCotacao";
            this.View_GerarCotacaoBindingSource.DataSource = this.DtGerarCotacao;
            // 
            // DtGerarCotacao
            // 
            this.DtGerarCotacao.DataSetName = "DtGerarCotacao";
            this.DtGerarCotacao.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // View_GerarCotacaoTableAdapter
            // 
            this.View_GerarCotacaoTableAdapter.ClearBeforeFill = true;
            // 
            // reportViewer1
            // 
            reportDataSource1.Name = "DtGerarCotacao";
            reportDataSource1.Value = this.View_GerarCotacaoBindingSource;
            this.reportViewer1.LocalReport.DataSources.Add(reportDataSource1);
            this.reportViewer1.LocalReport.ReportEmbeddedResource = "Prj_Cientifica.RptGerarProposta.rdlc";
            this.reportViewer1.Location = new System.Drawing.Point(-1, 2);
            this.reportViewer1.Name = "reportViewer1";
            this.reportViewer1.ServerReport.BearerToken = null;
            this.reportViewer1.Size = new System.Drawing.Size(1102, 732);
            this.reportViewer1.TabIndex = 0;
            // 
            // RelGerarCotacao
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1101, 738);
            this.Controls.Add(this.reportViewer1);
            this.Name = "RelGerarCotacao";
            this.Text = "Gerar Cotação";
            this.Load += new System.EventHandler(this.RelGerarCotacao_Load);
            ((System.ComponentModel.ISupportInitialize)(this.View_GerarCotacaoBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.DtGerarCotacao)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

       
        private System.Windows.Forms.BindingSource View_GerarCotacaoBindingSource;
        private DtGerarCotacao DtGerarCotacao;
        private DtGerarCotacaoTableAdapters.View_GerarCotacaoTableAdapter View_GerarCotacaoTableAdapter;
        private Microsoft.Reporting.WinForms.ReportViewer reportViewer1;
    }
}