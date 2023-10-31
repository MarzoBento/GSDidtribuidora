namespace Prj_Cientifica
{
    partial class Map_de_Preço_por_Itens
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
            Microsoft.Reporting.WinForms.ReportDataSource reportDataSource2 = new Microsoft.Reporting.WinForms.ReportDataSource();
            this.reportViewer1 = new Microsoft.Reporting.WinForms.ReportViewer();
            this.DtMapaPrecoItens = new Prj_Cientifica.DtMapaPrecoItens();
            this.View_Mapa_de_Preco_por_ItemBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.View_Mapa_de_Preco_por_ItemTableAdapter = new Prj_Cientifica.DtMapaPrecoItensTableAdapters.View_Mapa_de_Preco_por_ItemTableAdapter();
            ((System.ComponentModel.ISupportInitialize)(this.DtMapaPrecoItens)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.View_Mapa_de_Preco_por_ItemBindingSource)).BeginInit();
            this.SuspendLayout();
            // 
            // reportViewer1
            // 
            reportDataSource2.Name = "DtMapaPrecoItens";
            reportDataSource2.Value = this.View_Mapa_de_Preco_por_ItemBindingSource;
            this.reportViewer1.LocalReport.DataSources.Add(reportDataSource2);
            this.reportViewer1.LocalReport.ReportEmbeddedResource = "Prj_Cientifica.RptMapa_por_Item.rdlc";
            this.reportViewer1.Location = new System.Drawing.Point(2, 3);
            this.reportViewer1.Name = "reportViewer1";
            this.reportViewer1.ServerReport.BearerToken = null;
            this.reportViewer1.Size = new System.Drawing.Size(777, 854);
            this.reportViewer1.TabIndex = 3;
            // 
            // DtMapaPrecoItens
            // 
            this.DtMapaPrecoItens.DataSetName = "DtMapaPrecoItens";
            this.DtMapaPrecoItens.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // View_Mapa_de_Preco_por_ItemBindingSource
            // 
            this.View_Mapa_de_Preco_por_ItemBindingSource.DataMember = "View_Mapa_de_Preco_por_Item";
            this.View_Mapa_de_Preco_por_ItemBindingSource.DataSource = this.DtMapaPrecoItens;
            // 
            // View_Mapa_de_Preco_por_ItemTableAdapter
            // 
            this.View_Mapa_de_Preco_por_ItemTableAdapter.ClearBeforeFill = true;
            // 
            // Map_de_Preço_por_Itens
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(782, 858);
            this.Controls.Add(this.reportViewer1);
            this.Name = "Map_de_Preço_por_Itens";
            this.Text = "Mapa de Preço por Itens";
            this.Load += new System.EventHandler(this.Map_de_Preço_por_Itens_Load);
            ((System.ComponentModel.ISupportInitialize)(this.DtMapaPrecoItens)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.View_Mapa_de_Preco_por_ItemBindingSource)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private Microsoft.Reporting.WinForms.ReportViewer reportViewer1;
        private System.Windows.Forms.BindingSource View_Mapa_de_Preco_por_ItemBindingSource;
        private DtMapaPrecoItens DtMapaPrecoItens;
        private DtMapaPrecoItensTableAdapters.View_Mapa_de_Preco_por_ItemTableAdapter View_Mapa_de_Preco_por_ItemTableAdapter;
    }
}