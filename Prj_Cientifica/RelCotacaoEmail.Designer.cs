namespace Prj_Cientifica
{
    partial class RelCotacaoEmail
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
            this.reportViewer1 = new Microsoft.Reporting.WinForms.ReportViewer();
            this.DtCotacaoEmail = new Prj_Cientifica.DtCotacaoEmail();
            this.View_Cotacao_EmailBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.View_Cotacao_EmailTableAdapter = new Prj_Cientifica.DtCotacaoEmailTableAdapters.View_Cotacao_EmailTableAdapter();
            ((System.ComponentModel.ISupportInitialize)(this.DtCotacaoEmail)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.View_Cotacao_EmailBindingSource)).BeginInit();
            this.SuspendLayout();
            // 
            // reportViewer1
            // 
            reportDataSource1.Name = "DtCotacaoEmail";
            reportDataSource1.Value = this.View_Cotacao_EmailBindingSource;
            this.reportViewer1.LocalReport.DataSources.Add(reportDataSource1);
            this.reportViewer1.LocalReport.ReportEmbeddedResource = "Prj_Cientifica.RptCotacaoEmail.rdlc";
            this.reportViewer1.Location = new System.Drawing.Point(2, -1);
            this.reportViewer1.Name = "reportViewer1";
            this.reportViewer1.ServerReport.BearerToken = null;
            this.reportViewer1.Size = new System.Drawing.Size(1102, 732);
            this.reportViewer1.TabIndex = 1;
            // 
            // DtCotacaoEmail
            // 
            this.DtCotacaoEmail.DataSetName = "DtCotacaoEmail";
            this.DtCotacaoEmail.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // View_Cotacao_EmailBindingSource
            // 
            this.View_Cotacao_EmailBindingSource.DataMember = "View_Cotacao_Email";
            this.View_Cotacao_EmailBindingSource.DataSource = this.DtCotacaoEmail;
            // 
            // View_Cotacao_EmailTableAdapter
            // 
            this.View_Cotacao_EmailTableAdapter.ClearBeforeFill = true;
            // 
            // RelCotacaoEmail
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1106, 733);
            this.Controls.Add(this.reportViewer1);
            this.Name = "RelCotacaoEmail";
            this.Text = "Reatório de Cotacao";
            this.Load += new System.EventHandler(this.RelCotacaoEmail_Load);
            ((System.ComponentModel.ISupportInitialize)(this.DtCotacaoEmail)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.View_Cotacao_EmailBindingSource)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private Microsoft.Reporting.WinForms.ReportViewer reportViewer1;
        private System.Windows.Forms.BindingSource View_Cotacao_EmailBindingSource;
        private DtCotacaoEmail DtCotacaoEmail;
        private DtCotacaoEmailTableAdapters.View_Cotacao_EmailTableAdapter View_Cotacao_EmailTableAdapter;
    }
}