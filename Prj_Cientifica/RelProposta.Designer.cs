namespace Prj_Cientifica
{
    partial class RelProposta
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
            this.View_PropostaBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.DtProposta = new Prj_Cientifica.DtProposta();
            this.View_PropostaTableAdapter = new Prj_Cientifica.DtPropostaTableAdapters.View_PropostaTableAdapter();
            this.reportViewer1 = new Microsoft.Reporting.WinForms.ReportViewer();
            ((System.ComponentModel.ISupportInitialize)(this.View_PropostaBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.DtProposta)).BeginInit();
            this.SuspendLayout();
            // 
            // View_PropostaBindingSource
            // 
            this.View_PropostaBindingSource.DataMember = "View_Proposta";
            this.View_PropostaBindingSource.DataSource = this.DtProposta;
            // 
            // DtProposta
            // 
            this.DtProposta.DataSetName = "DtProposta";
            this.DtProposta.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // View_PropostaTableAdapter
            // 
            this.View_PropostaTableAdapter.ClearBeforeFill = true;
            // 
            // reportViewer1
            // 
            reportDataSource1.Name = "DtProposta";
            reportDataSource1.Value = this.View_PropostaBindingSource;
            this.reportViewer1.LocalReport.DataSources.Add(reportDataSource1);
            this.reportViewer1.LocalReport.ReportEmbeddedResource = "Prj_Cientifica.RptProp.rdlc";
            this.reportViewer1.Location = new System.Drawing.Point(3, 1);
            this.reportViewer1.Name = "reportViewer1";
            this.reportViewer1.ServerReport.BearerToken = null;
            this.reportViewer1.Size = new System.Drawing.Size(758, 854);
            this.reportViewer1.TabIndex = 0;
            // 
            // RelProposta
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(761, 858);
            this.Controls.Add(this.reportViewer1);
            this.Name = "RelProposta";
            this.Text = "Gerar Proposta (Relatório)";
            this.Load += new System.EventHandler(this.RelProposta_Load);
            ((System.ComponentModel.ISupportInitialize)(this.View_PropostaBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.DtProposta)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.BindingSource View_PropostaBindingSource;
        private DtProposta DtProposta;
        private DtPropostaTableAdapters.View_PropostaTableAdapter View_PropostaTableAdapter;
        private Microsoft.Reporting.WinForms.ReportViewer reportViewer1;
    }
}