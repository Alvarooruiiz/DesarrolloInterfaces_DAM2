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

namespace CambioDeDivisas
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
        
    {
        private String metodoPago;
        public MainWindow()
        {
            InitializeComponent();
        }

        private void btAccion_Click(object sender, RoutedEventArgs e)
        {
            // Verificar si al menos un RadioButton está seleccionado
            if (!(rbEuro.IsChecked == true || rbDolar.IsChecked == true || rbLibra.IsChecked == true || rbYen.IsChecked == true || rbFrancoSuizo.IsChecked == true))
            {
                MessageBox.Show("Seleccione el tipo de divisa antes de realizar el cálculo.");
                return;
            }
            

            // Obtener el tipo de divisa seleccionado
            string tipoDivisa = ObtenerTipoDivisaSeleccionado();

            // Obtener las divisas para el intercambio seleccionadas
            string[] divisasSeleccionadas = ObtenerDivisasSeleccionadas();

            // Obtener el método de pago seleccionado
            ObtenerMetodoPago();

            // Validar que se haya seleccionado un método de pago
            if (string.IsNullOrEmpty(metodoPago))
            {
                MessageBox.Show("Seleccione un método de pago antes de realizar el cálculo.");
                return;
            }

            // Obtener si el cliente es habitual
            bool? esClienteHabitualNullable = (cmbClienteHabitual.SelectedItem as ComboBoxItem)?.Content.ToString() == "Sí";

            // Validar que se haya seleccionado si el cliente es o no habitual
            if (!esClienteHabitualNullable.HasValue)
            {
                MessageBox.Show("Seleccione si el cliente es habitual antes de realizar el cálculo.");
                return;
            }

            bool esClienteHabitual = esClienteHabitualNullable.Value;

            // Obtener el monto introducido en el TextBox
            if (!decimal.TryParse(txtMonto.Text, out decimal montoOriginal))
            {
                MessageBox.Show("Ingrese un monto válido.");
                return;
            }

            // Calcular el cambio para cada divisa seleccionada
            Dictionary<string, decimal> cambios = new Dictionary<string, decimal>();
            foreach (string divisa in divisasSeleccionadas)
            {
                decimal cambio = CalcularCambio(divisa, tipoDivisa, montoOriginal, ObtenerComision(), esClienteHabitual);
                cambios.Add(divisa, cambio);
            }

            // Mostrar el mensaje con los resultados
            MostrarResultado(cambios, tipoDivisa);

        }

        private void ObtenerMetodoPago()
        {
            if (rbEfectivo.IsChecked == true)
            {
                metodoPago = "Efectivo";
            }
            else if (rbTransferencia.IsChecked == true)
            {
                metodoPago = "Transferencia";
            }
            else if (rbTarjeta.IsChecked == true)
            {
                metodoPago = "Tarjeta";
            }
            else
            {
                metodoPago = string.Empty;
            }
        }

        private string ObtenerTipoDivisaSeleccionado()
        {
            if (rbEuro.IsChecked == true) return "Euro";
            if (rbDolar.IsChecked == true) return "Dólar";
            if (rbLibra.IsChecked == true) return "Libra";
            if (rbYen.IsChecked == true) return "Yen";
            if (rbFrancoSuizo.IsChecked == true) return "Franco Suizo";

            return string.Empty;
        }

        private string[] ObtenerDivisasSeleccionadas()
        {
            var divisasSeleccionadas = new System.Collections.Generic.List<string>();

            if (chkEuro.IsChecked == true) divisasSeleccionadas.Add("Euro");
            if (chkDolar.IsChecked == true) divisasSeleccionadas.Add("Dólar");
            if (chkLibra.IsChecked == true) divisasSeleccionadas.Add("Libra");
            if (chkYen.IsChecked == true) divisasSeleccionadas.Add("Yen");
            if (chkFrancoSuizo.IsChecked == true) divisasSeleccionadas.Add("Franco Suizo");

            return divisasSeleccionadas.ToArray();
        }

        private decimal ObtenerComision()
        {
            if (rbEfectivo.IsChecked == true) return 0.01m; // 1%
            if (rbTransferencia.IsChecked == true) return 0.02m; // 2%
            if (rbTarjeta.IsChecked == true) return 0.03m; // 3%

            return 0m; // Sin comisión por defecto
        }

        private decimal CalcularCambio(string divisaDestino, string divisaOrigen, decimal montoOriginal, decimal comision, bool esClienteHabitual)
        {
            decimal tasaDeCambio = ObtenerTasaDeCambio(divisaDestino, divisaOrigen);

            // Calcular el monto sin comisión
            decimal montoSinComision = montoOriginal * tasaDeCambio;

            // Aplicar la comisión según el método de pago
            decimal montoConComision = AplicarComision(montoSinComision, comision);

            // Aplicar descuento para clientes habituales
            if (esClienteHabitual)
            {
                montoConComision = AplicarDescuentoClienteHabitual(montoConComision);
            }

            return montoConComision;
        }

        private decimal ObtenerTasaDeCambio(string divisaDestino, string divisaOrigen)
        {
           

            
            Dictionary<string, decimal> tasasDeCambio = new Dictionary<string, decimal>
    {
        { "Euro", 1.0m },
        { "Dólar", 1.09m },
        { "Libra", 0.88m },
        { "Yen", 162.68m },
        { "Franco Suizo", 0.97m }   
    };

            if (tasasDeCambio.ContainsKey(divisaDestino) && tasasDeCambio.ContainsKey(divisaOrigen))
            {
                decimal tasaDestino = tasasDeCambio[divisaDestino];
                decimal tasaOrigen = tasasDeCambio[divisaOrigen];

                // Devolver la tasa de cambio relativa entre las dos divisas
                return tasaDestino / tasaOrigen;
            }

            // En caso de que las divisas no estén en la lista de tasas de cambio
            return 0m;
        }

        private decimal AplicarComision(decimal monto, decimal comision)
        {
            // Aplicar la comisión al monto
            return monto + (monto * comision);
        }

        private decimal AplicarDescuentoClienteHabitual(decimal monto)
        {
            // Aplicar un descuento ficticio para clientes habituales
            return monto * 0.95m; // Descuento del 5%
        }

        private void MostrarResultado(Dictionary<string, decimal> cambios, string tipoDivisa)
        {
            if (cambios.Count == 0)
            {
                MessageBox.Show("Seleccione al menos una divisa para el intercambio.");
                return;
            }

            string mensaje = $"Cambio calculado para {tipoDivisa}:\n";

            foreach (var cambio in cambios)
            {
                mensaje += $"{cambio.Key}: {cambio.Value.ToString("N2")}\n";
            }

            MessageBox.Show(mensaje);
        }

    }
}
