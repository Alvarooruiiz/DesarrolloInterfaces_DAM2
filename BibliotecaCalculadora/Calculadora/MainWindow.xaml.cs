using BibliotecaCalculadora;
using System;
using System.Linq;
using System.Windows;
using System.Windows.Controls;

namespace Calculadora
{
    public partial class MainWindow : Window
    {
        private UserControl1 userControl1;

        public MainWindow()
        {
            InitializeComponent();
            userControl1 = new UserControl1(); // Asigna la instancia de UserControl1 a userControl1
            SizeChanged += MainWindow_SizeChanged;
            button.Click += Button_Click; // Asocia el controlador de eventos Button_Click con el evento Click del botón
        }


        private void MainWindow_SizeChanged(object sender, SizeChangedEventArgs e)
        {
            if (userControl1 != null)
            {
                double newWidth = e.NewSize.Width;
                double newHeight = e.NewSize.Height;

                // Ajusta el tamaño y la posición de UserControl1
                userControl1.Width = newWidth * 0.8;
                userControl1.Height = newHeight * 0.8;
                userControl1.Margin = new Thickness(newWidth * 0.1, newHeight * 0.1, 0, 0);
            }
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            String palabra = componente.ObtenerPalabraMasLarga();
            texboxLongitud.Text = palabra;
        }

        private void texboxLongitud_TextChanged(object sender, System.Windows.Controls.TextChangedEventArgs e)
        {

        }

        private void UserControl1_Loaded(object sender, RoutedEventArgs e)
        {


        }
    }
}
