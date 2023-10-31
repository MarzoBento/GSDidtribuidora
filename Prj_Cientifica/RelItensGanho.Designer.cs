namespace Prj_Cientifica
{
    partial class RelItensGanho
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
            this.View_GanhouBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.DtGanhou = new Prj_Cientifica.DtGanhou();
            this.reportViewer1 = new Microsoft.Reporting.WinForms.ReportViewer();
            this.View_GanhouTableAdapter = new Prj_Cientifica.DtGanhouTableAdapters.View_GanhouTableAdapter();
            ((System.ComponentModel.ISupportInitialize)(this.View_GanhouBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.DtGanhou)).BeginInit();
            this.SuspendLayout();
            // 
            // View_GanhouBindingSource
            // 
            this.View_GanhouBindingSource.DataMember = "View_Ganhou";
            this.View_GanhouBindingSource.DataSource = this.DtGanhou;
            // 
            // DtGanhou
            // 
            this.DtGanhou.DataSetName = "DtGanhou";
            this.DtGanhou.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // reportViewer1
            // 
            reportDataSource1.Name = "DtGanhou";
            reportDataSource1.Value = this.View_GanhouBindingSource;
            this.reportViewer1.LocalReport.DataSources.Add(reportDataSource1);
            this.reportViewer1.LocalReport.ReportEmbeddedResource = "Prj_Cientifica.RptGanho.rdlc";
            this.reportViewer1.Location = new System.Drawing.Point(-3, -2);
            this.reportViewer1.Name = "reportViewer1";
            this.reportViewer1.ServerReport.BearerToken = null;
            this.reportViewer1.Size = new System.Drawing.Size(1143, 854);
            this.reportViewer1.TabIndex = 2;
            // 
            // View_GanhouTableAdapter
            // 
            this.View_GanhouTableAdapter.ClearBeforeFill = true;
            // 
            // RelItensGanho
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1141, 852);
            this.Controls.Add(this.reportViewer1);
            this.Name = "RelItensGanho";
            this.Text = "Relatórios de Itens Ganho";
            this.Load += new System.EventHandler(this.RelItensGanho_Load);
            ((System.ComponentModel.ISupportInitialize)(this.View_GanhouBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.DtGanhou)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private Microsoft.Reporting.WinForms.ReportViewer reportViewer1;
        private System.Windows.Forms.BindingSource View_GanhouBindingSource;
        private DtGanhou DtGanhou;
        private DtGanhouTableAdapters.View_GanhouTableAdapter View_GanhouTableAdapter;
    }
}