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

namespace CalculadoraSalarioNeto
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void CalcularSalarioNeto_Click(object sender, RoutedEventArgs e)
        {
            // Obtener valores de la interfaz
            double salarioBruto = Convert.ToDouble(txtSalarioBruto.Text);
            int edad = Convert.ToInt32(txtEdad.Text);
            int numeroPagas = rb12Pagas.IsChecked ?? false ? 12 : 14;
            string situacionFamiliar = (cmbSituacionFamiliar.SelectedItem as ComboBoxItem)?.Content.ToString();
            bool tieneDiscapacidad = tglDiscapacidad.IsChecked ?? false;
            bool movilidadGeografica = tglMovilidadGeografica.IsChecked ?? false;

            // Aplicar descuentos y bonificaciones
            if (salarioBruto <= 15000)
                salarioBruto *= 0.92; // -8%
            else if (salarioBruto > 15000 && salarioBruto <= 30000)
                salarioBruto *= 0.85; // -15%

            if (edad >= 50)
                salarioBruto *= 0.98; // -2%
            else if (edad >= 20 && edad < 50)
                salarioBruto *= 1.01; // +1%

            if (situacionFamiliar == "Soltero")
                salarioBruto *= 1.02; // +2%
            else if (situacionFamiliar == "Viudo")
                salarioBruto *= 0.98; // -2%
            else if (situacionFamiliar == "Divorciado")
                salarioBruto *= 0.99; // -1%

            if (tieneDiscapacidad)
                salarioBruto *= 0.95; // -5%

            if (movilidadGeografica)
                salarioBruto *= 0.99; // -1%

            // Calcular salario neto
            double salarioNeto = salarioBruto / numeroPagas;

            // Mostrar resultado
            MessageBox.Show($"Salario Neto Mensual: {salarioNeto:C}");
        }

        private void tglDiscapacidad_Checked(object sender, RoutedEventArgs e)
        {

        }

        private void TextBox_GotFocus(object sender, RoutedEventArgs e)
        {
            // Cambiar el color de fondo al obtener el foco
            if (sender is TextBox textBox)
            {
                textBox.Background = new SolidColorBrush(Colors.Orange); // Cambia el color a tu preferencia
            }
        }

        private void TextBox_LostFocus(object sender, RoutedEventArgs e)
        {
            // Restaurar el color de fondo al perder el foco
            if (sender is TextBox textBox)
            {
                textBox.Background = new SolidColorBrush(Colors.White); // Cambia el color a tu preferencia
            }
        }
    }
}
