using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
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

namespace ExamenCamionero_04_12
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private ObservableCollection<string> ruta1;
        private ObservableCollection<string> ruta2;
        private ObservableCollection<string> ciudadesFiltradas;
        private ObservableCollection<string> ciudadesFiltradas2;
        public ObservableCollection<string> ciudadesSeleccionadas { get; set; }
        public ObservableCollection<string> ciudadesSeleccionadas2 { get; set; }


        public MainWindow()
        {
            InitializeComponent();
            ruta1 = new ObservableCollection<string> { "Malaga", "Granada", "Jaen", "Ciudad Real", "Toledo", "Madrid", "Guadalajara", "Zaragoza", "Lerida", "Barcelona" };
            ciudadesFiltradas = new ObservableCollection<string>(ruta1);
            comboBox.ItemsSource = ciudadesFiltradas;
            ruta2 = new ObservableCollection<string> { "Malaga", "Sevilla", "Mérida", "Cáceres", "Salamanca", "Zamora", "Orense", "Pontevedra", "Santiago", "Coruña" };
            ciudadesFiltradas2 = new ObservableCollection<string>(ruta2);
            comboBox2.ItemsSource = ciudadesFiltradas2;

            // Inicializa la colección de ciudades seleccionadas
            ciudadesSeleccionadas = new ObservableCollection<string>();
            // Enlaza el ListBox a la colección de ciudades seleccionadas
            selectedCitiesListBox.ItemsSource = ciudadesSeleccionadas;
            // Inicializa la colección de ciudades seleccionadas
            ciudadesSeleccionadas2 = new ObservableCollection<string>();
            // Enlaza el ListBox a la colección de ciudades seleccionadas
            selectedCitiesListBox2.ItemsSource = ciudadesSeleccionadas2;
        }

        

        public string obtenerTipoRuta()
        {
            String tipoRuta;
            if ((bool)rbTipoA.IsChecked)
            {
                tipoRuta = "TipoA";
            }
            else
            {
                tipoRuta = "TipoB";
            }

            if((bool)rbTipoB.IsChecked)
            {
                tipoRuta = "TipoB";
            }
            else
            {
                tipoRuta = "Tipo1";
            }

            return tipoRuta;
        }

        private void btnCalcular_Click(object sender, RoutedEventArgs e)
        {
            StringBuilder resultado = new StringBuilder();
            int total=0;
            int nocturnidad = 500;
            int precioRuta = 0;
            int numParadas=0;
            bool remolque = false;
           

            if (!(rbAceite.IsChecked == true || rbFruta.IsChecked == true || rbMercancias.IsChecked == true))
            {
                MessageBox.Show("Seleccione el tipo de mercancia.", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }
            if (!(rbTipoA.IsChecked == true || rbTipoB.IsChecked == true))
            {
                MessageBox.Show("Seleccione el tipo de trayecto.", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }
            if(ciudadesSeleccionadas.Count == 0 && ciudadesSeleccionadas2.Count==0)
            {
                MessageBox.Show("Seleccione las paradas", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }

            if ((bool)cbRemolque.IsChecked)
            {
                resultado.AppendLine("LLeva remolque");
                remolque = true;
            }


            if ((bool)cbNocturnidad.IsChecked){
                total += 500;
                resultado.AppendLine("Tiene nocturnidad");


            } else if((bool)rbAceite.IsChecked){
                if (remolque == true)
                {
                    precioRuta = 1500;
                }
                else
                {
                    precioRuta = 1000;
                }    
                resultado.AppendLine("El cargamento transportado es aceite: " + precioRuta + "€");
            }
            else if((bool)rbFruta.IsChecked){
                if (remolque == true)
                {
                    precioRuta = 1800;
                }
                else
                {
                    precioRuta = 1200;
                }
                resultado.AppendLine("El cargamento transportado es fruta: " + precioRuta + "€");
            }
            else if((bool)rbMercancias.IsChecked){
                if (remolque == true)
                {
                    precioRuta = 3000;
                }
                else
                {
                    precioRuta = 2000;
                }
                resultado.AppendLine("El cargamento transportado son mercancias peligrosas: " + precioRuta + "€");
            }


            if ((bool)rbTipoA.IsChecked)
            {
                numParadas = ciudadesSeleccionadas.Count;
                resultado.AppendLine("Ruta tipo A");
                resultado.AppendLine("Ha realizado " + numParadas + " paradas");
            }

            if ((bool)rbTipoB.IsChecked)
            {
                numParadas = ciudadesSeleccionadas2.Count;
                resultado.AppendLine("Ruta tipo B");
                resultado.AppendLine("Ha realizado " + numParadas + " paradas");
                total += numParadas * 100;
            }

            total += precioRuta;
            resultado.AppendLine("El total es de " + total + "€");
            tbResultado.Text = resultado.ToString();

            
            

            
        }

   
        //Ruta 1

        private void ComboBox_TextChanged(object sender, TextChangedEventArgs e)
        {
            ObservableCollection<string> ruta = ruta1;
            string searchTerm = searchBox.Text.ToLower();
            ciudadesFiltradas.Clear();

            foreach (var ciudad in ruta)
            {
                if (ciudad.ToLower().Contains(searchTerm))
                {
                    ciudadesFiltradas.Add(ciudad);
                }
            }
            comboBox.IsDropDownOpen = ciudadesFiltradas.Any(); // Abre el ComboBox si hay coincidencias
        }

        private void ComboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            string ciudadSeleccionada = comboBox.SelectedItem as string;
            if (!string.IsNullOrEmpty(ciudadSeleccionada))
            {
                // Añade la ciudad seleccionada a la colección
                ciudadesSeleccionadas.Add(ciudadSeleccionada);
                searchBox.Clear();
            }
        }

        //Ruta 2
        private void ComboBox_TextChanged2(object sender, TextChangedEventArgs e)
        {
            string searchTerm = searchBox2.Text.ToLower();
            ciudadesFiltradas2.Clear();

            foreach (var ciudad in ruta2)
            {
                if (ciudad.ToLower().Contains(searchTerm))
                {
                    ciudadesFiltradas2.Add(ciudad);
                }
            }

            comboBox2.IsDropDownOpen = ciudadesFiltradas2.Any(); // Abre el ComboBox si hay coincidencias
        }

        private void ComboBox_SelectionChanged2(object sender, SelectionChangedEventArgs e)
        {
            string ciudadSeleccionada2 = comboBox2.SelectedItem as string;
            if (!string.IsNullOrEmpty(ciudadSeleccionada2))
            {
                // Añade la ciudad seleccionada a la colección
                ciudadesSeleccionadas2.Add(ciudadSeleccionada2);
                searchBox2.Clear();
            }
        }

        private void rbTipoA_Checked(object sender, RoutedEventArgs e)
        {
            searchBox.Visibility = Visibility.Visible;
            comboBox.Visibility = Visibility.Visible;
            searchBox2.Visibility = Visibility.Hidden;
            comboBox2.Visibility = Visibility.Hidden;
            selectedCitiesListBox.Visibility = Visibility.Visible;
            selectedCitiesListBox2.Visibility = Visibility.Hidden;
        }

        private void rbTipoB_Checked(object sender, RoutedEventArgs e)
        {
            searchBox.Visibility = Visibility.Hidden;
            comboBox.Visibility = Visibility.Hidden;
            searchBox2.Visibility = Visibility.Visible;
            comboBox2.Visibility = Visibility.Visible;
            selectedCitiesListBox.Visibility = Visibility.Hidden;
            selectedCitiesListBox2.Visibility = Visibility.Visible;
        }
    }
}



