using ComponenteRelojCompleto;
using System;
using System.Collections.Generic;
using System.ComponentModel;
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

namespace ProyectoRelojDigital
{
    /// <summary>
    /// Lógica de interacción para MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            UserControl1 u = new UserControl1();
            reloj.Horas=10;
            reloj.Minutos = 15;
        }

        private void Reloj_PreviewMouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            // Cambiar el estado de IsPressed y actualizar la hora
            reloj.Horas = 10;
            reloj.Minutos = 15;
        }

        private void reloj_Loaded(object sender, RoutedEventArgs e)
        {
            // Código relacionado con la carga del reloj
        }
    }
}
