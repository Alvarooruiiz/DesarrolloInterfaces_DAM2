namespace InformeDatosCSVDesdeDataBase
{
    partial class Form1
    {
        /// <summary>
        /// Variable del diseñador necesaria.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Limpiar los recursos que se estén usando.
        /// </summary>
        /// <param name="disposing">true si los recursos administrados se deben desechar; false en caso contrario.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Código generado por el Diseñador de Windows Forms

        /// <summary>
        /// Método necesario para admitir el Diseñador. No se puede modificar
        /// el contenido de este método con el editor de código.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.informeBaseDatosCSVDataSetBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.informeBaseDatosCSVDataSet = new InformeDatosCSVDesdeDataBase.InformeBaseDatosCSVDataSet();
            this.reportViewer1 = new Microsoft.Reporting.WinForms.ReportViewer();
            ((System.ComponentModel.ISupportInitialize)(this.informeBaseDatosCSVDataSetBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.informeBaseDatosCSVDataSet)).BeginInit();
            this.SuspendLayout();
            // 
            // informeBaseDatosCSVDataSetBindingSource
            // 
            this.informeBaseDatosCSVDataSetBindingSource.DataSource = this.informeBaseDatosCSVDataSet;
            this.informeBaseDatosCSVDataSetBindingSource.Position = 0;
            // 
            // informeBaseDatosCSVDataSet
            // 
            this.informeBaseDatosCSVDataSet.DataSetName = "InformeBaseDatosCSVDataSet";
            this.informeBaseDatosCSVDataSet.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // reportViewer1
            // 
            this.reportViewer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.reportViewer1.LocalReport.ReportEmbeddedResource = "InformeDatosCSVDesdeDataBase.Reports.Report1.rdlc";
            this.reportViewer1.Location = new System.Drawing.Point(0, 0);
            this.reportViewer1.Name = "reportViewer1";
            this.reportViewer1.ServerReport.BearerToken = null;
            this.reportViewer1.Size = new System.Drawing.Size(800, 450);
            this.reportViewer1.TabIndex = 0;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.reportViewer1);
            this.Name = "Form1";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.Form1_Load);
            ((System.ComponentModel.ISupportInitialize)(this.informeBaseDatosCSVDataSetBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.informeBaseDatosCSVDataSet)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private Microsoft.Reporting.WinForms.ReportViewer reportViewer1;
        private System.Windows.Forms.BindingSource informeBaseDatosCSVDataSetBindingSource;
        private InformeBaseDatosCSVDataSet informeBaseDatosCSVDataSet;
    }
}

