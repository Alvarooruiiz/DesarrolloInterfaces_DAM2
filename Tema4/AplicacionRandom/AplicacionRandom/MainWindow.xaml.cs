using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using static AplicacionRandom.MainWindow;

namespace AplicacionRandom
{
    /// <summary>
    /// Lógica de interacción para MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        public class CsvHeader
        {
            public string LevelType { get; set; }
            public string Code { get; set; }
            public string CatalogType { get; set; }
            public string Name { get; set; }
            public string Description { get; set; }
            public string SourceLink { get; set; }
        }

        private List<CsvHeader> LeerCabeceraCsv(string filePath)
        {
            List<CsvHeader> headers = new List<CsvHeader>();

            using (var reader = new StreamReader(filePath))
            using (var csv = new CsvReader(reader, System.Globalization.CultureInfo.CurrentCulture))
            {
                csv.Read();
                csv.ReadHeader();

                CsvHeader header = csv.GetRecord<CsvHeader>();
                headers.Add(header);
            }

            return headers;
        }

        private void OpenImageDialog(object sender, RoutedEventArgs e)
        {
            OpenFileDialog openFileDialog1 = new OpenFileDialog
            {
                Filter = "Archivos CSV (*.csv)|*.csv",
                Title = "Seleccionar archivo CSV"
            };

            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                string filePath = openFileDialog1.FileName;

                List<CsvHeader> headers = LeerCabeceraCsv(filePath);

                // Aquí puedes usar la lista 'headers' como desees
                // Por ejemplo, puedes mostrar la cabecera en un MessageBox

                string mensajeCabecera = "Cabecera del archivo CSV:\n";

                foreach (var header in headers)
                {
                    mensajeCabecera += $"{header.Column1}, {header.Column2}\n";
                }

                MessageBox.Show(mensajeCabecera);
            }
            }
        }

        
    }
}
