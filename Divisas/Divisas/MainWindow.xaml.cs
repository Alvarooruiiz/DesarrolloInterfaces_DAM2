using System;
using System.Collections.ObjectModel;
using System.Linq;
using System.Windows;
using System.Windows.Controls;

namespace Divisas
{
    public partial class MainWindow : Window
    {
        private ObservableCollection<string> ciudades;
        private ObservableCollection<string> ciudadesFiltradas;
        public ObservableCollection<string> SelectedCities { get; set; }

        public MainWindow()
        {
            InitializeComponent();
            ciudades = new ObservableCollection<string> { "Nueva York", "Los Ángeles", "Chicago", "Miami", "San Francisco", "Seattle", "Boston" };
            ciudadesFiltradas = new ObservableCollection<string>(ciudades);
            comboBox.ItemsSource = ciudadesFiltradas;

            // Inicializa la colección de ciudades seleccionadas
            SelectedCities = new ObservableCollection<string>();
            // Enlaza el ListBox a la colección de ciudades seleccionadas
            selectedCitiesListBox.ItemsSource = SelectedCities;
        }

        private void ComboBox_TextChanged(object sender, TextChangedEventArgs e)
        {
            string searchTerm = searchBox.Text.ToLower();
            ciudadesFiltradas.Clear();

            foreach (var ciudad in ciudades)
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
                SelectedCities.Add(ciudadSeleccionada);
            }
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            SelectedCities.Clear();
        }
    }
}