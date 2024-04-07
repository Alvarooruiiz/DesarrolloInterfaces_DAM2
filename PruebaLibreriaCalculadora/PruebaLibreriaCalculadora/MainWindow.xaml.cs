using PrimerComponenteLibreria;
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

namespace PruebaLibreriaCalculadora
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            lbl.("Chema");
            lbl.("Joselu");
        }


        private void TextBox_TextChanged(object sender, TextChangedEventArgs e)
        {
            
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            if (int.TryParse(tb_num1.Text, out int num1) && int.TryParse(tb_num2.Text, out int num2))
            {
                Calculadora c = new Calculadora();

                int resultado = c.suma(num1, num2);

                tb_resultado.Text = resultado.ToString();

            }
            
        }

        UserControl userControl = new UserControl();

        private void lbl_Loaded(object sender, RoutedEventArgs e)
        {

        }
    }
}
