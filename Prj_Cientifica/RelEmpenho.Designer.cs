namespace Prj_Cientifica
{
    partial class RelEmpenho
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
            this.View_EmpenhoBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.DtEmpenho = new Prj_Cientifica.DtEmpenho();
            this.View_EmpenhoTableAdapter = new Prj_Cientifica.DtEmpenhoTableAdapters.View_EmpenhoTableAdapter();
            ((System.ComponentModel.ISupportInitialize)(this.View_EmpenhoBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.DtEmpenho)).BeginInit();
            this.SuspendLayout();
            // 
            // View_EmpenhoBindingSource
            // 
            this.View_EmpenhoBindingSource.DataMember = "View_Empenho";
            this.View_EmpenhoBindingSource.DataSource = this.DtEmpenho;
            // 
            // DtEmpenho
            // 
            this.DtEmpenho.DataSetName = "DtEmpenho";
            this.DtEmpenho.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;

            // 
            // reportViewer1
            // 
            reportDataSource1.Name = "DtEmpenho";
            reportDataSource1.Value = this.View_EmpenhoBindingSource;
            this.reportViewer1.LocalReport.DataSources.Add(reportDataSource1);
            this.reportViewer1.LocalReport.ReportEmbeddedResource = "Prj_Cientifica.RptEmpenho.rdlc";
            this.reportViewer1.Location = new System.Drawing.Point(0, -1);
            this.reportViewer1.Name = "reportViewer1";
            //this.reportViewer1.ServerReport.BearerToken = null;
            this.reportViewer1.Size = new System.Drawing.Size(640, 854);
            this.reportViewer1.TabIndex = 0;
            this.reportViewer1.Load += new System.EventHandler(this.reportViewer1_Load);
             // 
            // View_EmpenhoTableAdapter
            // 
            this.View_EmpenhoTableAdapter.ClearBeforeFill = true;
            // 
            // RelEmpenho
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(642, 853);
            this.Controls.Add(this.reportViewer1);
            this.Name = "RelEmpenho";
            this.Text = "Relatório de Empenho";
            this.Load += new System.EventHandler(this.RelEmpenho_Load);
            ((System.ComponentModel.ISupportInitialize)(this.View_EmpenhoBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.DtEmpenho)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion


        private System.Windows.Forms.BindingSource View_EmpenhoBindingSource;
        private DtEmpenho DtEmpenho;
        private DtEmpenhoTableAdapters.View_EmpenhoTableAdapter View_EmpenhoTableAdapter;
        private Microsoft.Reporting.WinForms.ReportViewer reportViewer1;
    }
}