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
using static System.Net.Mime.MediaTypeNames;

namespace ProyectoExamen29_01
{

    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            
        }

        private void tbnAdd_Click(object sender, RoutedEventArgs e)
        {
            string palabraMasLarga = componente.ObtenerPalabraMasLarga();
            tbTexto.Text = palabraMasLarga;
            
        }

        private async void componente_ListBoxSizeChanged(object sender, EventArgs e)
        {
            image.Visibility = Visibility.Visible;
            await Task.Delay(500);
            image.Visibility = Visibility.Collapsed;
            await Task.Delay(500);
            image.Visibility = Visibility.Visible;
            await Task.Delay(500);
            image.Visibility = Visibility.Collapsed;
            await Task.Delay(250);
            image.Visibility = Visibility.Visible;
            await Task.Delay(250);
            image.Visibility = Visibility.Collapsed;
        }
    }

}
