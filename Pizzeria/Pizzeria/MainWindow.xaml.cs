using System;
using System.Collections.Generic;
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

namespace Pizzeria
{
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            string[] opciones = { "Opción 1", "Opción 2", "Opción 3" };

            foreach (string opcion in opciones)
            {
                RadioButton radioButton = new RadioButton();
                radioButton.Content = opcion;
                radioButton.GroupName = "ImageSelection";
                radioButton.Checked += RadioButton_Checked;
                Bebidas.Children.Add(radioButton);
            }
        }

        

        private void ResetButton_Click(object sender, RoutedEventArgs e)
        {
            foreach (UIElement element in Ingredientes.Children)
            {
                if (element is CheckBox checkBox)
                {
                    checkBox.IsChecked = false;
                }
            }

            foreach (UIElement element in Masa.Children)
            {
                if (element is RadioButton radioButton)
                {
                    radioButton.IsChecked = false;
                }
            }

            foreach (UIElement element in Bebidas.Children)
            {
                if (element is RadioButton radioButton)
                {
                    radioButton.IsChecked = false;
                }
            }

            tb_mensaje.Text = "";
        
        }

        private string ObtenerSeleccionCheckBoxes(StackPanel grupo)
        {
            StringBuilder seleccionados = new StringBuilder();

            foreach (UIElement elemento in grupo.Children)
            {
                if (elemento is CheckBox checkBox && checkBox.IsChecked == true)
                {
                    if (seleccionados.Length > 0)
                    {
                        seleccionados.Append(", ");
                    }
                    seleccionados.Append(checkBox.Content);
                }
            }

            if (seleccionados.Length == 0)
            {
                return "Ninguno seleccionado";
            }
            return seleccionados.ToString();
        }

        private string ObtenerSeleccionRadioButon(StackPanel grupo)
        {
            foreach (UIElement element in grupo.Children)
            {
                if (element is RadioButton radioButton && radioButton.IsChecked == true)
                {
                    return radioButton.Content.ToString();
                }
            }
            return "Ninguno seleccionado";
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            string ingredientesSeleccionados = "Ingredientes seleccionados:\n" + ObtenerSeleccionCheckBoxes(Ingredientes);


            string tipoMasaSeleccionada = "Tipo de masa seleccionada: " + ObtenerSeleccionRadioButon(Masa);


            string bebidaSeleccionada = "Bebida seleccionada: " + ObtenerSeleccionRadioButon(Bebidas);


            string mensaje = ingredientesSeleccionados + "\n" + tipoMasaSeleccionada + "\n" + bebidaSeleccionada;
            tb_mensaje.Text = mensaje;

        }





        private void RadioButton_Checked(object sender, RoutedEventArgs e)
        {
            RadioButton radioButton = sender as RadioButton;
            if (radioButton.Content.ToString() == "Opción 1")
            {
                BebidasImages.Source = new BitmapImage(new Uri("C:\\Users\\alvar\\OneDrive\\Escritorio\\Cocacola.jpg"));
            }
            else if (radioButton.Content.ToString() == "Opción 2")
            {
                BebidasImages.Source = new BitmapImage(new Uri("C:\\Users\\alvar\\OneDrive\\Escritorio\\fanta.jpg"));
            }
            else if (radioButton.Content.ToString() == "Opción 3")
            {
                BebidasImages.Source = new BitmapImage(new Uri("C:\\Users\\alvar\\OneDrive\\Escritorio\\nestea.jpg"));

            }
        }
    }
}


