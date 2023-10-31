namespace Prj_Cientifica
{
    partial class RelMapa
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
            this.View_Mapa_de_PrecoBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.DtMapaPreco = new Prj_Cientifica.DtMapaPreco();
            this.View_Mapa_de_PrecoTableAdapter = new Prj_Cientifica.DtMapaPrecoTableAdapters.View_Mapa_de_PrecoTableAdapter();
            ((System.ComponentModel.ISupportInitialize)(this.View_Mapa_de_PrecoBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.DtMapaPreco)).BeginInit();
            this.SuspendLayout();
            // 
            // reportViewer1
            // 
            reportDataSource1.Name = "DtMapaPreco";
            reportDataSource1.Value = this.View_Mapa_de_PrecoBindingSource;
            this.reportViewer1.LocalReport.DataSources.Add(reportDataSource1);
            this.reportViewer1.LocalReport.ReportEmbeddedResource = "Prj_Cientifica.RptMapaPreco.rdlc";
            this.reportViewer1.Location = new System.Drawing.Point(1, 2);
            this.reportViewer1.Name = "reportViewer1";
            this.reportViewer1.ServerReport.BearerToken = null;
            this.reportViewer1.Size = new System.Drawing.Size(777, 854);
            this.reportViewer1.TabIndex = 2;
            // 
            // View_Mapa_de_PrecoBindingSource
            // 
            this.View_Mapa_de_PrecoBindingSource.DataMember = "View_Mapa_de_Preco";
            this.View_Mapa_de_PrecoBindingSource.DataSource = this.DtMapaPreco;
            // 
            // DtMapaPreco
            // 
            this.DtMapaPreco.DataSetName = "DtMapaPreco";
            this.DtMapaPreco.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // View_Mapa_de_PrecoTableAdapter
            // 
            this.View_Mapa_de_PrecoTableAdapter.ClearBeforeFill = true;
            // 
            // RelMapa
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(779, 856);
            this.Controls.Add(this.reportViewer1);
            this.Name = "RelMapa";
            this.Text = "Relatório de Mapa de Preços";
            this.Load += new System.EventHandler(this.RelMapa_Load);
            ((System.ComponentModel.ISupportInitialize)(this.View_Mapa_de_PrecoBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.DtMapaPreco)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private Microsoft.Reporting.WinForms.ReportViewer reportViewer1;
        private System.Windows.Forms.BindingSource View_Mapa_de_PrecoBindingSource;
        private DtMapaPreco DtMapaPreco;
        private DtMapaPrecoTableAdapters.View_Mapa_de_PrecoTableAdapter View_Mapa_de_PrecoTableAdapter;
    }
}