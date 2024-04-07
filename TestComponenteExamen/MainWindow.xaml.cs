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

namespace TestComponenteExamen
{
    /// <summary>
    /// Lógica de interacción para MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            int longerSize = 0;
            textBox.Text = "";
            foreach (string item in componente.ItemsListBox)
            {
                if (longerSize <= item.Length)
                {
                    longerSize = item.Length;
                }
            }
            //get maxSize

            List<string> list = new List<string>();
            foreach (string item in componente.ItemsListBox)
            {
                if (longerSize == item.Length)
                {
                    list.Add(item);
                }
            }
            //get all items that matches maxSize

            foreach (string item in list)
            {
                textBox.Text = textBox.Text +" "+ item;
            }
            //show items
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
        //show image
    }
}
