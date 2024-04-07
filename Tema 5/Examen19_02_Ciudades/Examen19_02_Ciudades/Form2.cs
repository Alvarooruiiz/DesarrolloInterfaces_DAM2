using Microsoft.Reporting.WinForms;
using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Examen19_02_Ciudades
{
    public partial class Form2 : Form
    {
        private List<Ciudades> lista;
        String zonaHoraria;
        public Form2(List<Ciudades> lista, String zonaHoraria)
        {
            InitializeComponent();
            this.lista = lista;
            this.zonaHoraria = zonaHoraria;
        }

        private void Form2_Load(object sender, EventArgs e)
        {

            DataTable dataTable = new DataTable();
            dataTable.Columns.Add("name", typeof(string));
            dataTable.Columns.Add("latitude", typeof(string));
            dataTable.Columns.Add("longitude", typeof(string));
            dataTable.Columns.Add("population", typeof(string));
            dataTable.Columns.Add("timezone", typeof(string));

            foreach (var item in lista)
            {
                dataTable.Rows.Add(item.name, item.latitude, item.longitude, item.population, item.timezone);
            }

            var dataSource = new ReportDataSource("DataSet1", dataTable);
            reportViewer1.LocalReport.DataSources.Clear();
            reportViewer1.LocalReport.DataSources.Add(dataSource);
            
            

            this.reportViewer1.LocalReport.SetParameters(new Microsoft.Reporting.WinForms.ReportParameter("ReportParameterTitulo", zonaHoraria));
            reportViewer1.RefreshReport();
        }


    }
}
