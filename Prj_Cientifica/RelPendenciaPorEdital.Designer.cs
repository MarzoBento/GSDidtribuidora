namespace Prj_Cientifica
{
    partial class RelPendenciaPorEdital
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
            this.View_PendenciasPorEdiraBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.DtPendenciasPorEdital = new Prj_Cientifica.DtPendenciasPorEdital();
            this.View_PendenciasPorEditalTableAdapter = new Prj_Cientifica.DtPendenciasPorEditalTableAdapters.View_PendenciasTableAdapter();
            this.reportViewer1 = new Microsoft.Reporting.WinForms.ReportViewer();
            ((System.ComponentModel.ISupportInitialize)(this.View_PendenciasPorEdiraBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.DtPendenciasPorEdital)).BeginInit();
            this.SuspendLayout();
            // 
            // View_PendenciasPorEdiraBindingSource
            // 
            this.View_PendenciasPorEdiraBindingSource.DataMember = "View_Pendencias";
            this.View_PendenciasPorEdiraBindingSource.DataSource = this.DtPendenciasPorEdital;
            // 
            // DtPendenciasPorEdital
            // 
            this.DtPendenciasPorEdital.DataSetName = "DtPendenciasPorEdital";
            this.DtPendenciasPorEdital.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // View_PendenciasPorEditalTableAdapter
            // 
            this.View_PendenciasPorEditalTableAdapter.ClearBeforeFill = true;
            // 
            // reportViewer1
            // 
            reportDataSource1.Name = "DtPendenciasPorEdital";
            reportDataSource1.Value = this.View_PendenciasPorEdiraBindingSource;
            this.reportViewer1.LocalReport.DataSources.Add(reportDataSource1);
            this.reportViewer1.LocalReport.ReportEmbeddedResource = "Prj_Cientifica.RptPendenciaPorEdital.rdlc";
            this.reportViewer1.Location = new System.Drawing.Point(2, 3);
            this.reportViewer1.Name = "reportViewer1";
            this.reportViewer1.ServerReport.BearerToken = null;
            this.reportViewer1.Size = new System.Drawing.Size(683, 862);
            this.reportViewer1.TabIndex = 0;
            // 
            // RelPendenciaPorEdital
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(683, 858);
            this.Controls.Add(this.reportViewer1);
            this.Name = "RelPendenciaPorEdital";
            this.Text = "Relatório de Pendêcias";
            this.Load += new System.EventHandler(this.RelPendenciaPorEdital_Load);
            ((System.ComponentModel.ISupportInitialize)(this.View_PendenciasPorEdiraBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.DtPendenciasPorEdital)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.BindingSource View_PendenciasPorEdiraBindingSource;
        private DtPendenciasPorEdital DtPendenciasPorEdital;
        private DtPendenciasPorEditalTableAdapters.View_PendenciasTableAdapter View_PendenciasPorEditalTableAdapter;
        private Microsoft.Reporting.WinForms.ReportViewer reportViewer1;
    }
}