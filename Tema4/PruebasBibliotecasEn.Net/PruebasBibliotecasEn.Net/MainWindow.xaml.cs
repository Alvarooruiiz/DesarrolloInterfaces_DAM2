using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
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

namespace PruebasBibliotecasEn.Net
{
    /// <summary>
    /// Lógica de interacción para MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {

        private bool pausa = false;
        public MainWindow()
        {
            InitializeComponent();
            
            
            string valor = "Alvaro";
            valor = control.ContenidoLabel;

        }


        private void Button_Click(object sender, RoutedEventArgs e)
        {
            string contenidoTB = control.TextoTextBox;

            int valor= int.Parse(contenidoTB);
            
            if(valor >= 0 && valor <101)
            {
                control.pintar(valor);
                control.ContenidoLabel = valor.ToString() + "%";
            }
        }


        private async void btn_Avanzar_Click(object sender, RoutedEventArgs e)
        {
            pausa= false;
            if (!String.IsNullOrEmpty(tb_milisegundos.Text))
            {
                btn_Avanzar.IsEnabled = false;
                btn_Actualizar.IsEnabled = false;
                int sleep = int.Parse(tb_milisegundos.Text);
                btn_Avanzar.IsEnabled = false;

                if (sleep > 0)
                {
                    try
                    {
                        int i = 0;

                        control.pintar(0);
                        for (i = 0; i < 100; i++)
                        {
                            control.pintar(i + 1);
                            control.ContenidoLabel = i.ToString() + "%";
                            await Task.Delay(sleep);
                            if (pausa)
                            {
                                break;
                            }
                        }
                        
                    }
                    finally
                    {
                        btn_Avanzar.IsEnabled = true;
                        btn_Actualizar.IsEnabled = true;
                    }
                }
                else
                {
                    MessageBoxResult result = System.Windows.MessageBox.Show("Mensaje de Alerta", "El número de tiempo de espera no es válido", MessageBoxButton.OKCancel);
                }
            }
            else
            {
                MessageBoxResult result = System.Windows.MessageBox.Show("Mensaje de Alerta", "Introduzca el tiempo de espera", MessageBoxButton.OKCancel);
            }

        }


        private void btn_Pausa_Click(object sender, RoutedEventArgs e)
        {
            pausa = !pausa;
        }

        
    }
}
