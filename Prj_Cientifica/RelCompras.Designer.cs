namespace Prj_Cientifica
{
    partial class RelCompras
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
            this.View_ComprasBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.DtCompras= new Prj_Cientifica.DtCompras();
            this.View_ComprasTableAdapter = new Prj_Cientifica.DtComprasTableAdapters.View_ComprasTableAdapter();
            this.reportViewer1 = new Microsoft.Reporting.WinForms.ReportViewer();
            ((System.ComponentModel.ISupportInitialize)(this.View_ComprasBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.DtCompras)).BeginInit();
            this.SuspendLayout();
            // 
            // View_PropostaBindingSource
            // 
            this.View_ComprasBindingSource.DataMember = "View_Compras";
            this.View_ComprasBindingSource.DataSource = this.DtCompras;
            // 
            // DtProposta
            // 
            this.DtCompras.DataSetName = "DtCompras";
            this.DtCompras.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // View_PropostaTableAdapter
            // 
            this.View_ComprasTableAdapter.ClearBeforeFill = true;
            // 
            // reportViewer1
            // 
            reportDataSource1.Name = "DtCompras";
            reportDataSource1.Value = this.View_ComprasBindingSource;
            this.reportViewer1.LocalReport.DataSources.Add(reportDataSource1);
            this.reportViewer1.LocalReport.ReportEmbeddedResource = "Prj_Cientifica.Rptvendas.rdlc";
            this.reportViewer1.Location = new System.Drawing.Point(2, 1);
            this.reportViewer1.Name = "reportViewer1";
            this.reportViewer1.ServerReport.BearerToken = null;
            this.reportViewer1.Size = new System.Drawing.Size(758, 854);
            this.reportViewer1.TabIndex = 1;
            // 
            // RelCompras
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(761, 857);
            this.Controls.Add(this.reportViewer1);
            this.Name = "RelCompras";
            this.Text = "Relatório de Compras";
            this.Load += new System.EventHandler(this.RelCompras_Load);
            ((System.ComponentModel.ISupportInitialize)(this.View_ComprasBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.DtCompras)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.BindingSource View_ComprasBindingSource;
        private DtCompras DtCompras;
        private DtComprasTableAdapters.View_ComprasTableAdapter View_ComprasTableAdapter;
        private Microsoft.Reporting.WinForms.ReportViewer reportViewer1;
    }
}