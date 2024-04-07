using Microsoft.Reporting.WinForms;
using Npgsql;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Npgsql;
using System.Collections;


namespace InformeDatosCSVDesdeDataBase
{
    public partial class Form1 : Form
    {


        private DataSet1 dataSet1 = new DataSet1();
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            CargarDatos();
            reportViewer1.RefreshReport();
        }

        public void CargarDatos()
        {
            NpgsqlConnection conn = new NpgsqlConnection("Host=localhost;Port=5432;Username=postgres;Password=alvaro;Database=InformeBaseDatosCSV");
            conn.Open();

            string query = "SELECT * FROM datoscsv";
            NpgsqlCommand cmd = new NpgsqlCommand(query, conn);

            NpgsqlDataReader reader = cmd.ExecuteReader();

            List<DatosCSV> listDatos = new List<DatosCSV>();

            while(reader.Read())
            {
                DatosCSV datos = new DatosCSV();
                datos.LevelType = reader["leveltype"].ToString();
                datos.Code = reader["code"].ToString();
                datos.CatalogType = reader["catalogType"].ToString();
                datos.Name = reader["name"].ToString();
                datos.Description = reader["description"].ToString();
                datos.SourceLink = reader["sourceLink"].ToString();

                listDatos.Add(datos);
            }

            DataTable dt = new DataTable();
            dt.Columns.Add("LevelType", typeof(string));
            dt.Columns.Add("Code", typeof(string));
            dt.Columns.Add("CatalogType", typeof(string));
            dt.Columns.Add("Name", typeof(string));
            dt.Columns.Add("Description", typeof(string));
            dt.Columns.Add("SourceLink", typeof(string));

            foreach (var item in listDatos)
            {
                dt.Rows.Add(item.LevelType, item.Code, item.CatalogType, item.Name, item.Description, item.SourceLink);
            }


            ReportDataSource dataSource = new ReportDataSource("DataSet1", dt);
            reportViewer1.LocalReport.DataSources.Clear();
            reportViewer1.LocalReport.DataSources.Add(dataSource);
            reportViewer1.RefreshReport();

            conn.Close();
        }

    }
}
