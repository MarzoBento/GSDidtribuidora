namespace Prj_Cientifica
{
    partial class RelRealinhamentoProposta
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
            this.View_RealinhamentoPropostaBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.DtRealinhamento = new Prj_Cientifica.DtRealinhamento();
            this.View_RealinhamentoPropostaTableAdapter = new Prj_Cientifica.DtRealinhamentoTableAdapters.View_RealinhamentoPropostaTableAdapter();
            ((System.ComponentModel.ISupportInitialize)(this.View_RealinhamentoPropostaBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.DtRealinhamento)).BeginInit();
            this.SuspendLayout();
            // 
            // reportViewer1
            // 
            reportDataSource1.Name = "DtRealinhamento";
            reportDataSource1.Value = this.View_RealinhamentoPropostaBindingSource;
            this.reportViewer1.LocalReport.DataSources.Add(reportDataSource1);
            this.reportViewer1.LocalReport.ReportEmbeddedResource = "Prj_Cientifica.RptRealinhamentoProp.rdlc";
            this.reportViewer1.Location = new System.Drawing.Point(0, 0);
            this.reportViewer1.Name = "reportViewer1";
            this.reportViewer1.ServerReport.BearerToken = null;
            this.reportViewer1.Size = new System.Drawing.Size(820, 864);
            this.reportViewer1.TabIndex = 1;
            // 
            // View_RealinhamentoPropostaBindingSource
            // 
            this.View_RealinhamentoPropostaBindingSource.DataMember = "View_RealinhamentoProposta";
            this.View_RealinhamentoPropostaBindingSource.DataSource = this.DtRealinhamento;
            // 
            // DtRealinhamento
            // 
            this.DtRealinhamento.DataSetName = "DtRealinhamento";
            this.DtRealinhamento.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // View_RealinhamentoPropostaTableAdapter
            // 
            this.View_RealinhamentoPropostaTableAdapter.ClearBeforeFill = true;
            // 
            // RelRealinhamentoProposta
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(824, 864);
            this.Controls.Add(this.reportViewer1);
            this.Name = "RelRealinhamentoProposta";
            this.Text = "Realinhamento de Proposta";
            this.Load += new System.EventHandler(this.RelRealinhamentoProposta_Load);
            ((System.ComponentModel.ISupportInitialize)(this.View_RealinhamentoPropostaBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.DtRealinhamento)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.BindingSource View_RealinhamentoPropostaBindingSource;
        private DtRealinhamento DtRealinhamento;
        private DtRealinhamentoTableAdapters.View_RealinhamentoPropostaTableAdapter View_RealinhamentoPropostaTableAdapter;
        private Microsoft.Reporting.WinForms.ReportViewer reportViewer1;
    }
}