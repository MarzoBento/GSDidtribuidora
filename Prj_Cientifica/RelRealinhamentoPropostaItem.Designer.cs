namespace Prj_Cientifica
{
    partial class RelRealinhamentoPropostaItem
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
            this.DtRealinhamentoItem = new Prj_Cientifica.DtRealinhamentoItem();
            this.View_RealinhamentoPropostaItemBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.View_RealinhamentoPropostaItemTableAdapter = new Prj_Cientifica.DtRealinhamentoItemTableAdapters.View_RealinhamentoPropostaItemTableAdapter();
            ((System.ComponentModel.ISupportInitialize)(this.DtRealinhamentoItem)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.View_RealinhamentoPropostaItemBindingSource)).BeginInit();
            this.SuspendLayout();
            // 
            // reportViewer1
            // 
            reportDataSource1.Name = "DtRealinhamentoItem";
            reportDataSource1.Value = this.View_RealinhamentoPropostaItemBindingSource;
            this.reportViewer1.LocalReport.DataSources.Add(reportDataSource1);
            this.reportViewer1.LocalReport.ReportEmbeddedResource = "Prj_Cientifica.RptRealinhamentoPropostaItem.rdlc";
            this.reportViewer1.Location = new System.Drawing.Point(0, 2);
            this.reportViewer1.Name = "reportViewer1";
            this.reportViewer1.ServerReport.BearerToken = null;
            this.reportViewer1.Size = new System.Drawing.Size(792, 864);
            this.reportViewer1.TabIndex = 2;
            // 
            // DtRealinhamentoItem
            // 
            this.DtRealinhamentoItem.DataSetName = "DtRealinhamentoItem";
            this.DtRealinhamentoItem.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // View_RealinhamentoPropostaItemBindingSource
            // 
            this.View_RealinhamentoPropostaItemBindingSource.DataMember = "View_RealinhamentoPropostaItem";
            this.View_RealinhamentoPropostaItemBindingSource.DataSource = this.DtRealinhamentoItem;
            // 
            // View_RealinhamentoPropostaItemTableAdapter
            // 
            this.View_RealinhamentoPropostaItemTableAdapter.ClearBeforeFill = true;
            // 
            // RelRealinhamentoPropostaItem
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(798, 870);
            this.Controls.Add(this.reportViewer1);
            this.Name = "RelRealinhamentoPropostaItem";
            this.Text = "Relatório de Proposta por Item";
            this.Load += new System.EventHandler(this.RelRealinhamentoPropostaItem_Load);
            ((System.ComponentModel.ISupportInitialize)(this.DtRealinhamentoItem)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.View_RealinhamentoPropostaItemBindingSource)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private Microsoft.Reporting.WinForms.ReportViewer reportViewer1;
        private System.Windows.Forms.BindingSource View_RealinhamentoPropostaItemBindingSource;
        private DtRealinhamentoItem DtRealinhamentoItem;
        private DtRealinhamentoItemTableAdapters.View_RealinhamentoPropostaItemTableAdapter View_RealinhamentoPropostaItemTableAdapter;
    }
}