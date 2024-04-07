using Microsoft.Reporting.WinForms;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace InformeDesdeCSV
{
    public partial class Form2 : Form
    {
        private List<DatosCSV> lista;

        public Form2(List<DatosCSV> lista)
        {
            InitializeComponent();
            this.lista = lista;
        }

        private void Form2_Load(object sender, EventArgs e)
        {
            DataTable dataTable = new DataTable();
            dataTable.Columns.Add("LevelType", typeof(string));
            dataTable.Columns.Add("Code", typeof(string));
            dataTable.Columns.Add("CatalogType", typeof(string));
            dataTable.Columns.Add("Name", typeof(string));
            dataTable.Columns.Add("Description", typeof(string));
            dataTable.Columns.Add("SourceLink", typeof(string));

            // Agregar los datos de la lista al DataTable
            foreach (var item in lista)
            {
                dataTable.Rows.Add(item.LevelType, item.Code, item.CatalogType, item.Name, item.Description, item.SourceLink);
            }

            // Establecer el DataTable como origen de datos del informe
            var dataSource = new ReportDataSource("DataSet1", dataTable);
            reportViewer1.LocalReport.DataSources.Clear();
            reportViewer1.LocalReport.DataSources.Add(dataSource);

            // Refrescar el informe
            reportViewer1.RefreshReport();
        }
    }
}
