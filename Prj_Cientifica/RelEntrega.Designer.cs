namespace Prj_Cientifica
{
    partial class RelEntrega
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
            this.View_EntregaBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.DtEntrega = new Prj_Cientifica.DtEntrega();
            this.reportViewer1 = new Microsoft.Reporting.WinForms.ReportViewer();
            this.View_EntregaTableAdapter = new Prj_Cientifica.DtEntregaTableAdapters.View_EntregaTableAdapter();
            ((System.ComponentModel.ISupportInitialize)(this.View_EntregaBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.DtEntrega)).BeginInit();
            this.SuspendLayout();
            // 
            // View_EntregaBindingSource
            // 
            this.View_EntregaBindingSource.DataMember = "View_Entrega";
            this.View_EntregaBindingSource.DataSource = this.DtEntrega;
            // 
            // DtEntrega
            // 
            this.DtEntrega.DataSetName = "DtEntrega";
            this.DtEntrega.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // reportViewer1
            // 
            reportDataSource1.Name = "DtEntrega";
            reportDataSource1.Value = this.View_EntregaBindingSource;
            this.reportViewer1.LocalReport.DataSources.Add(reportDataSource1);
            this.reportViewer1.LocalReport.ReportEmbeddedResource = "Prj_Cientifica.RptEntrega.rdlc";
            this.reportViewer1.Location = new System.Drawing.Point(2, 1);
            this.reportViewer1.Name = "reportViewer1";
            this.reportViewer1.ServerReport.BearerToken = null;
            this.reportViewer1.Size = new System.Drawing.Size(1084, 854);
            this.reportViewer1.TabIndex = 1;
            // 
            // View_EntregaTableAdapter
            // 
            this.View_EntregaTableAdapter.ClearBeforeFill = true;
            // 
            // RelEntrega
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1089, 856);
            this.Controls.Add(this.reportViewer1);
            this.Name = "RelEntrega";
            this.Text = "Relatório de Entrega";
            this.Load += new System.EventHandler(this.RelEntrega_Load);
            ((System.ComponentModel.ISupportInitialize)(this.View_EntregaBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.DtEntrega)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.BindingSource View_EntregaBindingSource;
        private DtEntrega DtEntrega;
        private DtEntregaTableAdapters.View_EntregaTableAdapter View_EntregaTableAdapter;
        private Microsoft.Reporting.WinForms.ReportViewer reportViewer1;
    }
}