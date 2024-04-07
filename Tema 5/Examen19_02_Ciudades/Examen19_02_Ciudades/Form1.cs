using Microsoft.Reporting.WinForms;
using Npgsql;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Examen19_02_Ciudades
{
    public partial class Form1 : Form
    {

        List<Ciudades> listDatos = new List<Ciudades>();
        String zonaHoraria;


        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            cargarDatos();
        }

        public void cargarDatos()
        {
            NpgsqlConnection conn = new NpgsqlConnection("Host=localhost;Port=5432;Username=postgres;Password=alvaro;Database=EEUU");
            conn.Open();

            string query = "SELECT * FROM \"Ciudades\"";
            NpgsqlCommand cmd = new NpgsqlCommand(query, conn);

            NpgsqlDataReader reader = cmd.ExecuteReader();

            

            while (reader.Read())
            {
                Ciudades datos = new Ciudades();
                datos.name = reader["name"].ToString();
                datos.latitude = reader["latitude"].ToString();
                datos.longitude = reader["longitude"].ToString();
                datos.population = reader["population"].ToString();
                datos.timezone = reader["timezone"].ToString();

                listDatos.Add(datos);
            }

            DataTable dt = new DataTable();
            dt.Columns.Add("name", typeof(string));
            dt.Columns.Add("latitude", typeof(string));
            dt.Columns.Add("longitude", typeof(string));
            dt.Columns.Add("population", typeof(string));
            dt.Columns.Add("timezone", typeof(string));

            foreach (var item in listDatos)
            {
                dt.Rows.Add(item.name, item.latitude, item.longitude, item.population, item.timezone);
            }


            ReportDataSource dataSource = new ReportDataSource("DataSet1", dt);


            conn.Close();
        }

       


        private void button1_Click(object sender, EventArgs e)
        {
            if (radioButton1.Checked)
            {
                zonaHoraria = "Nueva York";
            }
            else if (radioButton2.Checked)
            {
                zonaHoraria = "Los Angeles";
            }
            else if (radioButton3.Checked)
            {
                zonaHoraria = "Chicago";
            }
            else
            {
                zonaHoraria = "";
            }
            cargarDatos();
            Form2 frm = new Form2(listDatos, zonaHoraria);
            frm.Show();
        }
    }
    
}
