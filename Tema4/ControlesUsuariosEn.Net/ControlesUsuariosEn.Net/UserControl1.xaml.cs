using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Emit;
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

namespace ControlesUsuariosEn.Net
{
    /// <summary>
    /// Lógica de interacción para UserControl1.xaml
    /// </summary>
    public partial class UserControl1 : UserControl
    {
        public UserControl1()
        {
            InitializeComponent();
        }


        public string ContenidoLabel
        {
            get { return label.Content.ToString(); }
            set { label.Content = value; }
        }

        public string TextoTextBox
        {
            get { return textBox_Numero.Text; }
            set { textBox_Numero.Text = value; }
        }

        public void pintar(int valor)
        {
            int max =(int) barra.ActualWidth;
            progreso.Width = valor *max/100;

        }

        public int getTamRect()
        {
            return (int)progreso.Width;
        }

        
        private void textBox_TextChanged(object sender, TextChangedEventArgs e)
        {
            int longitudTexto = textBox_Texto.Text.Length;

            if (longitudTexto > 100)
            {
                MessageBoxResult result = System.Windows.MessageBox.Show("has llegado al máximo de caracteres", "Error", MessageBoxButton.OKCancel);

            }
            else
            {
                //progreso_Texto.pintar(longitudTexto);
            }
        }

        
    }
}
