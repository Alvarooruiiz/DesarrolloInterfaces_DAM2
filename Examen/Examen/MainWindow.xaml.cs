using Microsoft.VisualBasic;
using System;
using System.Collections.ObjectModel;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;

namespace CalculadoraSalarioNeto
{
    public partial class MainWindow : Window
    {
        public ObservableCollection<string> list = new ObservableCollection<string>();
        private const int EdadJubilacionEspaña = 65;

        public MainWindow()
        {
            InitializeComponent();
            list.Add("Euro");
            list.Add("Dolar");
            list.Add("Libra");
            list.Add("Yen");
            list.Add("Franco Suizo");
            this.cbPrincipal.ItemsSource = list;

        }

        private void TextBox_PreviewTextInput(object sender, TextCompositionEventArgs e)
        {
            // Verificar si el texto ingresado es numérico o una coma decimal
            if (!char.IsDigit(e.Text, 0) && e.Text != ",")
            {
                e.Handled = true; // No permitir la entrada de caracteres no numéricos
            }

            // Verificar si ya hay una coma decimal en el texto
            var textBox = sender as TextBox;
            if (e.Text == "," && textBox.Text.Contains(","))
            {
                e.Handled = true; // No permitir más de una coma decimal
            }
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            if (!(rbEfectivo.IsChecked == true || rbTransferencia.IsChecked == true || rbTarjeta.IsChecked == true))
            {
                MessageBox.Show("Seleccione un método de pago.", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }

            // Validar que se haya seleccionado al menos un CheckBox
            if (!(cbEuro.IsChecked == true || cbDolar.IsChecked == true || cbLibra.IsChecked == true || cbYen.IsChecked == true || cbFrancoSuizo.IsChecked == true))
            {
                MessageBox.Show("Seleccione al menos una moneda.", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }

            // Obtener el valor seleccionado en cbPrincipal
            string monedaBase = cbPrincipal.SelectedItem as string;

            // Validar que se haya seleccionado una moneda base
            if (string.IsNullOrEmpty(monedaBase))
            {
                MessageBox.Show("Seleccione una moneda base.", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }

            // Verificar si se seleccionó una moneda base
            if (monedaBase != null)
            {
                // Obtener el importe y verificar si es un número válido
                if (double.TryParse(tbImporte.Text, out double importe))
                {
                    // Construir el mensaje que se mostrará en tbFinal
                    StringBuilder resultado = new StringBuilder();

                    // Verificar qué checkboxes están activados y realizar los cálculos correspondientes
                    double descuento = cbClienteHabitual.IsChecked == true ? 0.25 : 0;
                    double comision = 0;

                    // Verificar el método de pago seleccionado
                    if ((bool)rbEfectivo.IsChecked)
                    {
                        comision = 0.01;
                        resultado.AppendLine($"Método de pago: Efectivo (Comisión: {comision * 100}%)");
                    }
                    else if ((bool)rbTransferencia.IsChecked)
                    {
                        comision = 0.02;
                        resultado.AppendLine($"Método de pago: Transferencia (Comisión: {comision * 100}%)");
                    }
                    else if ((bool)rbTarjeta.IsChecked)
                    {
                        comision = 0.03;
                        resultado.AppendLine($"Método de pago: Tarjeta (Comisión: {comision * 100}%)");
                    }

                    switch (monedaBase)
                    {
                        case "Euro":
                            if ((bool)cbEuro.IsChecked)
                            {
                                resultado.AppendLine($"Cambio a Euro: {CalcularCambio(importe, 1 - descuento, comision):C2}");
                            }
                            if ((bool)cbDolar.IsChecked)
                            {
                                resultado.AppendLine($"Cambio a Dólar: {CalcularCambio(importe, 0.92 * (1 - descuento), comision):C2}");
                            }
                            if ((bool)cbLibra.IsChecked)
                            {
                                resultado.AppendLine($"Cambio a Libra: {CalcularCambio(importe, 1.14 * (1 - descuento), comision):C2}");
                            }
                            if ((bool)cbYen.IsChecked)
                            {
                                resultado.AppendLine($"Cambio a Yen: {CalcularCambio(importe, 0.01 * (1 - descuento), comision):C2}");
                            }
                            if ((bool)cbFrancoSuizo.IsChecked)
                            {
                                resultado.AppendLine($"Cambio a Franco Suizo: {CalcularCambio(importe, 1.04 * (1 - descuento), comision):C2}");
                            }
                            break;
                        case "Dolar":
                            if ((bool)cbEuro.IsChecked)
                            {
                                resultado.AppendLine($"Cambio a Euro: {CalcularCambio(importe, 1.09 * (1 - descuento), comision):C2}");
                            }
                            if ((bool)cbDolar.IsChecked)
                            {
                                resultado.AppendLine($"Cambio a Dólar: {CalcularCambio(importe, 1 - descuento, comision):C2}");
                            }
                            if ((bool)cbLibra.IsChecked)
                            {
                                resultado.AppendLine($"Cambio a Libra: {CalcularCambio(importe, 1.25 * (1 - descuento), comision):C2}");
                            }
                            if ((bool)cbYen.IsChecked)
                            {
                                resultado.AppendLine($"Cambio a Yen: {CalcularCambio(importe, 0.01 * (1 - descuento), comision):C2}");
                            }
                            if ((bool)cbFrancoSuizo.IsChecked)
                            {
                                resultado.AppendLine($"Cambio a Franco Suizo: {CalcularCambio(importe, 1.13 * (1 - descuento), comision):C2}");
                            }
                            break;
                        case "Libra":
                            if ((bool)cbEuro.IsChecked)
                            {
                                resultado.AppendLine($"Cambio a Euro: {CalcularCambio(importe, 0.88 - descuento, comision):C2}");
                            }
                            if ((bool)cbDolar.IsChecked)
                            {
                                resultado.AppendLine($"Cambio a Dólar: {CalcularCambio(importe, 0.8 * (1 - descuento), comision):C2}");
                            }
                            if ((bool)cbLibra.IsChecked)
                            {
                                resultado.AppendLine($"Cambio a Libra: {CalcularCambio(importe, 1 * (1 - descuento), comision):C2}");
                            }
                            if ((bool)cbYen.IsChecked)
                            {
                                resultado.AppendLine($"Cambio a Yen: {CalcularCambio(importe, 0.01 * (1 - descuento), comision):C2}");
                            }
                            if ((bool)cbFrancoSuizo.IsChecked)
                            {
                                resultado.AppendLine($"Cambio a Franco Suizo: {CalcularCambio(importe, 0.91 * (1 - descuento), comision):C2}");
                            }
                            break;
                        case "Yen":
                            if ((bool)cbEuro.IsChecked)
                            {
                                resultado.AppendLine($"Cambio a Euro: {CalcularCambio(importe, 162.68 - descuento, comision):C2}");
                            }
                            if ((bool)cbDolar.IsChecked)
                            {
                                resultado.AppendLine($"Cambio a Dólar: {CalcularCambio(importe, 148.93 * (1 - descuento), comision):C2}");
                            }
                            if ((bool)cbLibra.IsChecked)
                            {
                                resultado.AppendLine($"Cambio a Libra: {CalcularCambio(importe, 185.88 * (1 - descuento), comision):C2}");
                            }
                            if ((bool)cbYen.IsChecked)
                            {
                                resultado.AppendLine($"Cambio a Yen: {CalcularCambio(importe, 1 * (1 - descuento), comision):C2}");
                            }
                            if ((bool)cbFrancoSuizo.IsChecked)
                            {
                                resultado.AppendLine($"Cambio a Franco Suizo: {CalcularCambio(importe, 168.37 * (1 - descuento), comision):C2}");
                            }
                            break;
                        case "Franco Suizo":
                            if ((bool)cbEuro.IsChecked)
                            {
                                resultado.AppendLine($"Cambio a Euro: {CalcularCambio(importe, 0.97 - descuento, comision):C2}");
                            }
                            if ((bool)cbDolar.IsChecked)
                            {
                                resultado.AppendLine($"Cambio a Dólar: {CalcularCambio(importe, 0.88 * (1 - descuento), comision):C2}");
                            }
                            if ((bool)cbLibra.IsChecked)
                            {
                                resultado.AppendLine($"Cambio a Libra: {CalcularCambio(importe, 1.1 * (1 - descuento), comision):C2}");
                            }
                            if ((bool)cbYen.IsChecked)
                            {
                                resultado.AppendLine($"Cambio a Yen: {CalcularCambio(importe, 0.01 * (1 - descuento), comision):C2}");
                            }
                            if ((bool)cbFrancoSuizo.IsChecked)
                            {
                                resultado.AppendLine($"Cambio a Franco Suizo: {CalcularCambio(importe, 1 * (1 - descuento), comision):C2}");
                            }
                            break;
                        default:
                            break;
                    }

                    // Mostrar el resultado en tbFinal
                    tbFinal.Text = resultado.ToString();
                }
                else
                {
                    MessageBox.Show("Ingrese un importe válido.", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                }
            }
            else
            {
                MessageBox.Show("Seleccione una moneda base.", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        private double CalcularCambio(double importe, double tipoCambio, double comision)
        {
            // Calcular el importe final para la moneda de destino con la comisión
            double importeFinal = importe * tipoCambio * (1 + comision);

            return importeFinal;
        }
    }
}
