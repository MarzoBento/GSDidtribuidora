    namespace Prj_Cientifica
{
    partial class RelRetFornecedor
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
            this.View_RetFornecedorBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.DtRetFornecedor = new Prj_Cientifica.DtRetFornecedor();
            this.View_RetCotacaoTableAdapter = new Prj_Cientifica.DtRetFornecedorTableAdapters.View_RetCotacaoTableAdapter();
            this.reportViewer1 = new Microsoft.Reporting.WinForms.ReportViewer();
            ((System.ComponentModel.ISupportInitialize)(this.View_RetFornecedorBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.DtRetFornecedor)).BeginInit();
            this.SuspendLayout();
            // 
            // View_RetFornecedorBindingSource
            // 
            this.View_RetFornecedorBindingSource.DataMember = "View_RetCotacao";
            this.View_RetFornecedorBindingSource.DataSource = this.DtRetFornecedor;
            // 
            // DtRetFornecedor
            // 
            this.DtRetFornecedor.DataSetName = "DtRetFornecedor";
            this.DtRetFornecedor.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // View_RetCotacaoTableAdapter
            // 
            this.View_RetCotacaoTableAdapter.ClearBeforeFill = true;
            // 
            // reportViewer1
            // 
            reportDataSource1.Name = "DtRetFornecedor";
            reportDataSource1.Value = this.View_RetFornecedorBindingSource;
            this.reportViewer1.LocalReport.DataSources.Add(reportDataSource1);
            this.reportViewer1.LocalReport.ReportEmbeddedResource = "Prj_Cientifica.RptRetornoFornecedor.rdlc";
            this.reportViewer1.Location = new System.Drawing.Point(1, 1);
            this.reportViewer1.Name = "reportViewer1";
            this.reportViewer1.ServerReport.BearerToken = null;
            this.reportViewer1.Size = new System.Drawing.Size(1088, 734);
            this.reportViewer1.TabIndex = 1;
            // 
            // RelRetFornecedor
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1092, 738);
            this.Controls.Add(this.reportViewer1);
            this.Name = "RelRetFornecedor";
            this.Text = "Retorno de Preços de Fornecedores";
            this.Load += new System.EventHandler(this.RelRetFornecedor_Load);
            ((System.ComponentModel.ISupportInitialize)(this.View_RetFornecedorBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.DtRetFornecedor)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private Microsoft.Reporting.WinForms.ReportViewer reportViewer1;
        private System.Windows.Forms.BindingSource View_RetFornecedorBindingSource;
        private DtRetFornecedor DtRetFornecedor;
        private DtRetFornecedorTableAdapters.View_RetCotacaoTableAdapter View_RetCotacaoTableAdapter;
       
    }
}