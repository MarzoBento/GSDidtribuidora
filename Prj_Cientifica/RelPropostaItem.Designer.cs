namespace Prj_Cientifica
{
    partial class RelPropostaItem
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
            this.View_PropostaItemBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.DtPropostaItem = new Prj_Cientifica.DtPropostaItem();
            this.View_PropostaItemTableAdapter = new Prj_Cientifica.DtPropostaItemTableAdapters.View_PropostaItemTableAdapter();
            this.reportViewer1 = new Microsoft.Reporting.WinForms.ReportViewer();
            ((System.ComponentModel.ISupportInitialize)(this.View_PropostaItemBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.DtPropostaItem)).BeginInit();
            this.SuspendLayout();
            // 
            // View_PropostaItemBindingSource
            // 
            this.View_PropostaItemBindingSource.DataMember = "View_PropostaItem";
            this.View_PropostaItemBindingSource.DataSource = this.DtPropostaItem;
            // 
            // DtPropostaItem
            // 
            this.DtPropostaItem.DataSetName = "DtPropostaItem";
            this.DtPropostaItem.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // View_PropostaItemTableAdapter
            // 
            this.View_PropostaItemTableAdapter.ClearBeforeFill = true;
            // 
            // reportViewer1
            // 
            reportDataSource1.Name = "DtPropostaItem";
            reportDataSource1.Value = this.View_PropostaItemBindingSource;
            this.reportViewer1.LocalReport.DataSources.Add(reportDataSource1);
            this.reportViewer1.LocalReport.ReportEmbeddedResource = "Prj_Cientifica.RptPropostaItem.rdlc";
            this.reportViewer1.Location = new System.Drawing.Point(0, 1);
            this.reportViewer1.Name = "reportViewer1";
            this.reportViewer1.ServerReport.BearerToken = null;
            this.reportViewer1.Size = new System.Drawing.Size(758, 854);
            this.reportViewer1.TabIndex = 1;
            this.reportViewer1.Load += new System.EventHandler(this.reportViewer1_Load);
            // 
            // RelPropostaItem
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(760, 855);
            this.Controls.Add(this.reportViewer1);
            this.Name = "RelPropostaItem";
            this.Text = "(Gerar Proposta Item) Relatóriode Proposta por Item";
            this.Load += new System.EventHandler(this.RelPropostaItem_Load);
            ((System.ComponentModel.ISupportInitialize)(this.View_PropostaItemBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.DtPropostaItem)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.BindingSource View_PropostaItemBindingSource;
        private DtPropostaItem DtPropostaItem;
        private DtPropostaItemTableAdapters.View_PropostaItemTableAdapter View_PropostaItemTableAdapter;
        private Microsoft.Reporting.WinForms.ReportViewer reportViewer1;
    }
}