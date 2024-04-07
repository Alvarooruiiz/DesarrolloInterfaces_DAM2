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

namespace ComponenteExamenRecuperacion
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

        private int numMaxLista;
        private int numMaxCarac;
        private SolidColorBrush color;
        private ObservableCollection<string> palabras;

        public int NumMaxLista { get => numMaxLista; set => numMaxLista = value; }
        public int NumMaxCarac { get => numMaxCarac; set => numMaxCarac = value; }
        public SolidColorBrush Color { get => color; set => color = value; }


        private void TbTexto_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Enter)
            {
                if (lbLista.Items.Count < NumMaxLista)
                {
                    String texto = tbTexto.Text;
                    if (texto.Length <= NumMaxCarac)
                    {
                        lbLista.Items.Add(texto);
                        tbTexto.Clear();
                        MostrarParpadeoImagen();
                    }
                    else
                    {
                        MessageBox.Show($"El texto no debe exceder {NumMaxCarac} caracteres.", "Advertencia");
                    }
                }

                ActualizarSlider();
            }
        }

        private void lbLista_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            ActualizarSlider();
        }

        private void ActualizarSlider()
        {
            slider.Value = lbLista.Items.Count;

            if (lbLista.Items.Count == NumMaxLista)
            {
                tbTexto.Background = Brushes.Red;
                tbTexto.IsEnabled = false;
            }
            else
            {
                tbTexto.Background = Brushes.White;
                tbTexto.IsEnabled = true;
            }
        }

        private void btnEliminar_Click(object sender, RoutedEventArgs e)
        {
            if (lbLista.SelectedItem != null)
            {
                palabras.Remove(lbLista.SelectedItem.ToString());
                ActualizarSlider();

            }
            lbLista.Items.Clear();
            lbLista.Items.Refresh();
        }


        public ObservableCollection<string> ObtenerElementosListBox()
        {
            return palabras;

        }

        public string ObtenerPalabraMasLarga()
        {
            string palabraMasLarga = "";

            if (lbLista.Items != null)
            {
                foreach (string elemento in lbLista.Items)
                {
                    if (elemento.Length > palabraMasLarga.Length)
                    {
                        palabraMasLarga = elemento;
                    }
                }

                return palabraMasLarga;
            }
            else
            {
                return "Error";
            }
        }


        private void MostrarParpadeoImagen()
        {
            
        }

        private void ListBox_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Delete)
            {
                if (lbLista.SelectedItem != null)
                {
                    palabras.Remove(lbLista.SelectedItem.ToString());
                    ActualizarSlider();
                    lbLista.Items.Refresh();

                }
            }
        }

    }
}
