using CsvHelper;
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

namespace InformeDesdeCSV
{
    public partial class Form1 : Form
    {
        String path;
        List<DatosCSV> listaLineas = new List<DatosCSV>(); 


        public Form1()
        {
            InitializeComponent();
        }

        private void abrirSelecc_Click_1(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog1 = new OpenFileDialog
            {
                Filter = "Archivos CSV (*.csv)|*.csv",
                Title = "Seleccionar archivo CSV"
            };

            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                path = openFileDialog1.FileName;
            }
        }

        private void LeerArchivoCSV(string filePath)
        {
            listaLineas.Clear();

            string[] lineas = File.ReadAllLines(filePath);

            for (int i = 1; i < lineas.Length; i++)
            {
                string[] columnas = lineas[i].Split(',');

                if (columnas.Length >= 6)
                {
                    DatosCSV cabecera = new DatosCSV
                    {
                        LevelType = columnas[0],
                        Code = columnas[1],
                        CatalogType = columnas[2],
                        Name = columnas[3],
                        Description = columnas[4],
                        SourceLink = columnas[5]
                    };

                    listaLineas.Add(cabecera);

                }
                else
                {
                    Console.WriteLine("La fila {0} no tiene suficientes columnas.", i);
                }
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(path))
            {
                LeerArchivoCSV(path);
                Form2 frm = new Form2(listaLineas);
                frm.Show();
            }
            else
            {
                MessageBox.Show("Por favor, seleccione un archivo CSV primero.");
            }
        }

    }

  
}
