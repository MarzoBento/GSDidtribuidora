namespace Prj_Cientifica
{
    partial class RelOrgao
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
            this.View_OrgaoBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.DtOrgao = new Prj_Cientifica.DtOrgao();
            this.reportViewer1 = new Microsoft.Reporting.WinForms.ReportViewer();
            this.View_OrgaoTableAdapter = new Prj_Cientifica.DtOrgaoTableAdapters.View_OrgaoTableAdapter();
            ((System.ComponentModel.ISupportInitialize)(this.View_OrgaoBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.DtOrgao)).BeginInit();
            this.SuspendLayout();
            // 
            // View_OrgaoBindingSource
            // 
            this.View_OrgaoBindingSource.DataMember = "View_Orgao";
            this.View_OrgaoBindingSource.DataSource = this.DtOrgao;
            // 
            // DtOrgao
            // 
            this.DtOrgao.DataSetName = "DtOrgao";
            this.DtOrgao.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // reportViewer1
            // 
            reportDataSource1.Name = "DtOrgao";
            reportDataSource1.Value = this.View_OrgaoBindingSource;
            this.reportViewer1.LocalReport.DataSources.Add(reportDataSource1);
            this.reportViewer1.LocalReport.ReportEmbeddedResource = "Prj_Cientifica.RptOrgao.rdlc";
            this.reportViewer1.Location = new System.Drawing.Point(3, 1);
            this.reportViewer1.Name = "reportViewer1";
            this.reportViewer1.ServerReport.BearerToken = null;
            this.reportViewer1.Size = new System.Drawing.Size(755, 854);
            this.reportViewer1.TabIndex = 1;
            // 
            // View_OrgaoTableAdapter
            // 
            this.View_OrgaoTableAdapter.ClearBeforeFill = true;
            // 
            // RelOrgao
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(762, 854);
            this.Controls.Add(this.reportViewer1);
            this.Name = "RelOrgao";
            this.Text = "Orgãos";
            this.Load += new System.EventHandler(this.RelOrgao_Load);
            ((System.ComponentModel.ISupportInitialize)(this.View_OrgaoBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.DtOrgao)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private Microsoft.Reporting.WinForms.ReportViewer reportViewer1;
        private System.Windows.Forms.BindingSource View_OrgaoBindingSource;
        private DtOrgao DtOrgao;
        private DtOrgaoTableAdapters.View_OrgaoTableAdapter View_OrgaoTableAdapter;
    }
}