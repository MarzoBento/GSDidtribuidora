namespace Prj_Cientifica
{
    partial class ViewProdutosMaisVendidos
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
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea1 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.Legend legend1 = new System.Windows.Forms.DataVisualization.Charting.Legend();
            System.Windows.Forms.DataVisualization.Charting.Series series1 = new System.Windows.Forms.DataVisualization.Charting.Series();
            System.Windows.Forms.DataVisualization.Charting.Title title1 = new System.Windows.Forms.DataVisualization.Charting.Title();
            this.chart1 = new System.Windows.Forms.DataVisualization.Charting.Chart();
            this.btnBusca = new System.Windows.Forms.Button();
            this.dtfim = new System.Windows.Forms.DateTimePicker();
            this.label2 = new System.Windows.Forms.Label();
            this.mskdtfim = new System.Windows.Forms.MaskedTextBox();
            this.dtini = new System.Windows.Forms.DateTimePicker();
            this.label7 = new System.Windows.Forms.Label();
            this.mskdtini = new System.Windows.Forms.MaskedTextBox();
            this.viewMaisVendidosBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.dtMaisVendidosBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.dtMaisVendidos = new Prj_Cientifica.DtMaisVendidos();
            this.view_Mais_VendidosTableAdapter = new Prj_Cientifica.DtMaisVendidosTableAdapters.View_Mais_VendidosTableAdapter();
            ((System.ComponentModel.ISupportInitialize)(this.chart1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.viewMaisVendidosBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dtMaisVendidosBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dtMaisVendidos)).BeginInit();
            this.SuspendLayout();
            // 
            // chart1
            // 
            chartArea1.Name = "ChartArea1";
            this.chart1.ChartAreas.Add(chartArea1);
            this.chart1.DataSource = this.viewMaisVendidosBindingSource;
            legend1.Name = "Legend1";
            this.chart1.Legends.Add(legend1);
            this.chart1.Location = new System.Drawing.Point(12, 52);
            this.chart1.Name = "chart1";
            series1.ChartArea = "ChartArea1";
            series1.ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.FastLine;
            series1.IsValueShownAsLabel = true;
            series1.Legend = "Legend1";
            series1.Name = "Series1";
            series1.XValueMember = "nome";
            series1.YValueMembers = "QtdeProduto";
            this.chart1.Series.Add(series1);
            this.chart1.Size = new System.Drawing.Size(942, 576);
            this.chart1.TabIndex = 0;
            this.chart1.Text = "chart1";
            title1.Name = "Produtos Com mais Saidas";
            this.chart1.Titles.Add(title1);
            // 
            // btnBusca
            // 
            this.btnBusca.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.btnBusca.Location = new System.Drawing.Point(243, 3);
            this.btnBusca.Name = "btnBusca";
            this.btnBusca.Size = new System.Drawing.Size(72, 43);
            this.btnBusca.TabIndex = 163;
            this.btnBusca.UseVisualStyleBackColor = true;
            this.btnBusca.Click += new System.EventHandler(this.btnBusca_Click);
            // 
            // dtfim
            // 
            this.dtfim.Location = new System.Drawing.Point(218, 26);
            this.dtfim.Name = "dtfim";
            this.dtfim.Size = new System.Drawing.Size(19, 20);
            this.dtfim.TabIndex = 162;
            this.dtfim.ValueChanged += new System.EventHandler(this.dtfim_ValueChanged);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.label2.Location = new System.Drawing.Point(126, 10);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(83, 13);
            this.label2.TabIndex = 161;
            this.label2.Text = "Período Final";
            // 
            // mskdtfim
            // 
            this.mskdtfim.Location = new System.Drawing.Point(129, 26);
            this.mskdtfim.Mask = "00/00/0000";
            this.mskdtfim.Name = "mskdtfim";
            this.mskdtfim.Size = new System.Drawing.Size(83, 20);
            this.mskdtfim.TabIndex = 160;
            this.mskdtfim.ValidatingType = typeof(System.DateTime);
            // 
            // dtini
            // 
            this.dtini.Location = new System.Drawing.Point(107, 26);
            this.dtini.Name = "dtini";
            this.dtini.Size = new System.Drawing.Size(19, 20);
            this.dtini.TabIndex = 159;
            this.dtini.ValueChanged += new System.EventHandler(this.dtini_ValueChanged);
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.label7.Location = new System.Drawing.Point(15, 10);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(90, 13);
            this.label7.TabIndex = 158;
            this.label7.Text = "Período Inicial";
            // 
            // mskdtini
            // 
            this.mskdtini.Location = new System.Drawing.Point(18, 26);
            this.mskdtini.Mask = "00/00/0000";
            this.mskdtini.Name = "mskdtini";
            this.mskdtini.Size = new System.Drawing.Size(83, 20);
            this.mskdtini.TabIndex = 157;
            this.mskdtini.ValidatingType = typeof(System.DateTime);
            // 
            // viewMaisVendidosBindingSource
            // 
            this.viewMaisVendidosBindingSource.DataMember = "View_Mais Vendidos";
            this.viewMaisVendidosBindingSource.DataSource = this.dtMaisVendidosBindingSource;
            // 
            // dtMaisVendidosBindingSource
            // 
            this.dtMaisVendidosBindingSource.DataSource = this.dtMaisVendidos;
            this.dtMaisVendidosBindingSource.Position = 0;
            // 
            // dtMaisVendidos
            // 
            this.dtMaisVendidos.DataSetName = "DtMaisVendidos";
            this.dtMaisVendidos.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // view_Mais_VendidosTableAdapter
            // 
            this.view_Mais_VendidosTableAdapter.ClearBeforeFill = true;
            // 
            // ViewProdutosMaisVendidos
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(959, 649);
            this.Controls.Add(this.btnBusca);
            this.Controls.Add(this.dtfim);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.mskdtfim);
            this.Controls.Add(this.dtini);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.mskdtini);
            this.Controls.Add(this.chart1);
            this.Name = "ViewProdutosMaisVendidos";
            this.Text = "Produtos Mais Vendidos";
            this.Load += new System.EventHandler(this.ViewProdutosMaisVendidos_Load);
            ((System.ComponentModel.ISupportInitialize)(this.chart1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.viewMaisVendidosBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dtMaisVendidosBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dtMaisVendidos)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataVisualization.Charting.Chart chart1;
        private System.Windows.Forms.Button btnBusca;
        private System.Windows.Forms.DateTimePicker dtfim;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.MaskedTextBox mskdtfim;
        private System.Windows.Forms.DateTimePicker dtini;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.MaskedTextBox mskdtini;
        private System.Windows.Forms.BindingSource dtMaisVendidosBindingSource;
        private DtMaisVendidos dtMaisVendidos;
        private System.Windows.Forms.BindingSource viewMaisVendidosBindingSource;
        private DtMaisVendidosTableAdapters.View_Mais_VendidosTableAdapter view_Mais_VendidosTableAdapter;
    }
}