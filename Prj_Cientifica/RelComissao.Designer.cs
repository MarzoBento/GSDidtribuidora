namespace Prj_Cientifica
{
    partial class RelComissao
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
            this.DtComissao = new Prj_Cientifica.DtComissao();
            this.View_ComissaoBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.View_ComissaoTableAdapter = new Prj_Cientifica.DtComissaoTableAdapters.View_ComissaoTableAdapter();
            ((System.ComponentModel.ISupportInitialize)(this.DtComissao)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.View_ComissaoBindingSource)).BeginInit();
            this.SuspendLayout();
            // 
            // reportViewer1
            // 
            reportDataSource1.Name = "DtComissao";
            reportDataSource1.Value = this.View_ComissaoBindingSource;
            this.reportViewer1.LocalReport.DataSources.Add(reportDataSource1);
            this.reportViewer1.LocalReport.ReportEmbeddedResource = "Prj_Cientifica.RptComissao.rdlc";
            this.reportViewer1.Location = new System.Drawing.Point(-1, 2);
            this.reportViewer1.Name = "reportViewer1";
            this.reportViewer1.ServerReport.BearerToken = null;
            this.reportViewer1.Size = new System.Drawing.Size(758, 854);
            this.reportViewer1.TabIndex = 2;
            // 
            // DtComissao
            // 
            this.DtComissao.DataSetName = "DtComissao";
            this.DtComissao.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // View_ComissaoBindingSource
            // 
            this.View_ComissaoBindingSource.DataMember = "View_Comissao";
            this.View_ComissaoBindingSource.DataSource = this.DtComissao;
            // 
            // View_ComissaoTableAdapter
            // 
            this.View_ComissaoTableAdapter.ClearBeforeFill = true;
            // 
            // RelComissao
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(759, 857);
            this.Controls.Add(this.reportViewer1);
            this.Name = "RelComissao";
            this.Text = "Relatório de Comissão";
            this.Load += new System.EventHandler(this.RelComissao_Load);
            ((System.ComponentModel.ISupportInitialize)(this.DtComissao)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.View_ComissaoBindingSource)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private Microsoft.Reporting.WinForms.ReportViewer reportViewer1;
        private System.Windows.Forms.BindingSource View_ComissaoBindingSource;
        private DtComissao DtComissao;
        private DtComissaoTableAdapters.View_ComissaoTableAdapter View_ComissaoTableAdapter;
    }
}