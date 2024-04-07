using Microsoft.Reporting.WinForms;
using Newtonsoft.Json;
using RestSharp;
using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace InformeApi
{
    public partial class Form1 : Form
    {
        private List<Producto> frases = new List<Producto>();

        public Form1()
        {
            InitializeComponent();
        }
        private void Form1_Load(object sender, EventArgs e)
        {
            cargarApiRest();


            String valorParametroTitulo = "Titulo crack";

            this.reportViewer1.LocalReport.SetParameters(new Microsoft.Reporting.WinForms.ReportParameter("ReportParameter1", valorParametroTitulo));
            reportViewer1.RefreshReport();
        }

        public void cargarApiRest()
        {
            RestClient client = new RestClient("https://fakestoreapi.com");
            RestRequest request = new RestRequest("/products", Method.Get);
            RestResponse response = client.Execute(request);

            if (response.IsSuccessful)
            {
                // Deserializar la respuesta JSON en una lista de objetos Producto
                List<Producto> listaProductos = JsonConvert.DeserializeObject<List<Producto>>(response.Content);

                // Crear un DataSet y un DataTable para los datos
                DataSet dataSet = new DataSet();
                DataTable dataTable = new DataTable();

                // Agregar columnas al DataTable
                dataTable.Columns.Add("Id", typeof(string));
                dataTable.Columns.Add("Title", typeof(string));
                dataTable.Columns.Add("Price", typeof(double));
                dataTable.Columns.Add("Description", typeof(string));
                dataTable.Columns.Add("Category", typeof(string));

                // Agregar filas al DataTable con los datos de los productos
                foreach (var producto in listaProductos)
                {
                    dataTable.Rows.Add(producto.Id, producto.Title, producto.Price, producto.Description, producto.Category);
                }

                reportViewer1.LocalReport.DataSources.Clear();

                // Crear un origen de datos para el informe
                ReportDataSource dataSource = new ReportDataSource("DataSet1", dataTable);

                // Agregar el origen de datos al visor de informes (assumiendo que estás usando un ReportViewer)
                this.reportViewer1.LocalReport.DataSources.Add(dataSource);

                // Actualizar el informe
                this.reportViewer1.RefreshReport();
            }
            else
            {
                // Manejar la situación en la que la solicitud no fue exitosa
                MessageBox.Show("La solicitud HTTP no fue exitosa. Código de estado: " + response.StatusCode);
            }

        }



        /* private void Form1_Load(object sender, EventArgs e)
         {
             RestClient client = new RestClient("https://fakestoreapi.com/products/");
             RestRequest request = new RestRequest((Method.Get).ToString());
             RestResponse response = client.Execute(request);

             // Verifica si la solicitud fue exitosa
             if (response.IsSuccessful)
             {
                 try
                 {
                     // Deserializa la respuesta JSON en una lista de objetos Producto
                     List<Producto> productos = Newtonsoft.Json.JsonConvert.DeserializeObject<List<Producto>>(response.Content);

                     // Ahora la lista 'productos' contiene los datos de los productos obtenidos de la API.
                     // Puedes usar esta lista como desees, como mostrar los productos en una tabla o cualquier otra cosa.

                     // Ejemplo de impresión de títulos de productos en la consola:
                     foreach (Producto producto in productos)
                     {
                         Console.WriteLine($"Id: {producto.Id}, Título: {producto.Title}, Precio: {producto.Price}");
                     }
                 }
                 catch (Exception ex)
                 {
                     // Manejo de errores durante la deserialización
                     Console.WriteLine($"Error al deserializar la respuesta JSON: {ex.Message}");
                 }
             }
             else
             {
                 // Manejo de errores en caso de que la solicitud no sea exitosa
                 Console.WriteLine($"Error: {response.StatusCode}");
             }
         }*/


        /*
        private async void Form1_Load(object sender, EventArgs e)
        {
            await MostrarProductosEnReportViewer();
            this.reportViewer1.RefreshReport();
        }

        private async Task MostrarProductosEnReportViewer()
        {
            // Crea un cliente HttpClient
            var client = new HttpClient();

            try
            {
                // Realiza la solicitud HTTP GET a la API
                HttpResponseMessage response = await client.GetAsync("https://fakestoreapi.com/products/");

                // Asegúrate de que la solicitud fue exitosa
                response.EnsureSuccessStatusCode();

                // Lee el contenido de la respuesta como una cadena
                string responseBody = await response.Content.ReadAsStringAsync();

                // Deserializa la respuesta JSON en una lista de productos
                List<Producto> productos = Newtonsoft.Json.JsonConvert.DeserializeObject<List<Producto>>(responseBody);

                // Configura el origen de datos del ReportViewer
                var reportDataSource = new ReportDataSource("DataSetProductos", productos);
                reportViewer1.LocalReport.DataSources.Add(reportDataSource);

                // Refresca el informe para mostrar los datos
                reportViewer1.RefreshReport();
            }
            catch (HttpRequestException ex)
            {
                // Maneja los errores de la solicitud HTTP
                MessageBox.Show($"Error al realizar la solicitud HTTP: {ex.Message}");
            }
        }*/
    }
}
