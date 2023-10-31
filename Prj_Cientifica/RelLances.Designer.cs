namespace Prj_Cientifica
{
    partial class RelLances
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
            this.View_LancamentoEditaisBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.DtPropostaLancamentos = new Prj_Cientifica.DtPropostaLancamentos();
            this.View_PropostaLancamentosTableAdapter = new Prj_Cientifica.DtPropostaLancamentosTableAdapters.View_PropostaLancamentosTableAdapter();
            this.reportViewer1 = new Microsoft.Reporting.WinForms.ReportViewer();
            ((System.ComponentModel.ISupportInitialize)(this.View_LancamentoEditaisBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.DtPropostaLancamentos)).BeginInit();
            this.SuspendLayout();
            // 
            // View_PropostaBindingSource
            // 
            this.View_LancamentoEditaisBindingSource.DataMember = "View_PropostaLancamentos";
            this.View_LancamentoEditaisBindingSource.DataSource = this.DtPropostaLancamentos;
            // 
            // DtProposta
            // 
            this.DtPropostaLancamentos.DataSetName = "DtPropostaLancamentos";
            this.DtPropostaLancamentos.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // View_PropostaTableAdapter
            // 
            this.View_PropostaLancamentosTableAdapter.ClearBeforeFill = true;
            // 
            // reportViewer1
            // 
            reportDataSource1.Name = "DtPropostaLancamentos";
            reportDataSource1.Value = this.View_LancamentoEditaisBindingSource;
            this.reportViewer1.LocalReport.DataSources.Add(reportDataSource1);
            this.reportViewer1.LocalReport.ReportEmbeddedResource = "Prj_Cientifica.RptLances.rdlc";
            this.reportViewer1.Location = new System.Drawing.Point(2, 1);
            this.reportViewer1.Name = "reportViewer1";
            this.reportViewer1.ServerReport.BearerToken = null;
            this.reportViewer1.Size = new System.Drawing.Size(770, 854);
            this.reportViewer1.TabIndex = 1;
            // 
            // RelLances
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(773, 858);
            this.Controls.Add(this.reportViewer1);
            this.Name = "RelLances";
            this.Text = "Lances";
            this.Load += new System.EventHandler(this.RelLances_Load);
            ((System.ComponentModel.ISupportInitialize)(this.View_LancamentoEditaisBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.DtPropostaLancamentos)).EndInit();
            this.ResumeLayout(false);

        }


        #endregion
        private System.Windows.Forms.BindingSource View_LancamentoEditaisBindingSource;
        private DtPropostaLancamentos DtPropostaLancamentos;
        private DtPropostaLancamentosTableAdapters.View_PropostaLancamentosTableAdapter View_PropostaLancamentosTableAdapter;
        private Microsoft.Reporting.WinForms.ReportViewer reportViewer1;
    }
}