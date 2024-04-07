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

namespace ComponenteExamen29_01
{
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
        public event EventHandler ListBoxSizeChanged;

        public int NumMaxLista { get => numMaxLista; set => numMaxLista = value; }
        public int NumMaxCarac { get => numMaxCarac; set => numMaxCarac = value; }
        public SolidColorBrush Color { get => color; set => color = value; }
        public ObservableCollection<string> Palabras { get => palabras; set => palabras = value; }
        
        private void tbTexto_KeyDown(object sender, KeyEventArgs e)
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
                        this.ListBoxSizeChanged(sender, e);
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
            slider.Maximum = NumMaxLista;
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
                Palabras.Remove(lbLista.SelectedItem.ToString());
                ActualizarSlider();

            }
            lbLista.Items.Clear();
            lbLista.Items.Refresh();
        }


        public ObservableCollection<string> ObtenerElementosListBox()
        {
            return Palabras;

        }

        public string ObtenerPalabraMasLarga()
        {
            string palabraMasLarga = "";

            if(lbLista.Items != null)
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

        public void EliminarElementoListBox(object elemento)
        {
            lbLista.Items.Remove(elemento);
        }

        private void ListBox_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            // Obtener el elemento seleccionado en el ListBox
            object elemento = lbLista.SelectedItem;
            // Verificar si se seleccionó un elemento
            if (elemento != null)
            {
                // Eliminar el elemento seleccionado del ListBox
                EliminarElementoListBox(elemento);
                // Actualizar el valor del Slider con el número de elementos actuales del ListBox
                slider.Value = lbLista.Items.Count;
                // Restablecer el color del TextBox a blanco
                tbTexto.Background = Brushes.White;
                // Habilitar la entrada de datos en el TextBox
                tbTexto.IsEnabled = true;
                // Indicar que el evento ha sido manejado
                e.Handled = true;
            }
        }



        private void MostrarParpadeoImagen()
        {
            image.Visibility = Visibility.Visible;

            Task.Delay(2000).ContinueWith(_ =>
            {
                Dispatcher.Invoke(() => image.Visibility = Visibility.Hidden);
            });
        }

        private void lbLista_SelectionChanged_1(object sender, SelectionChangedEventArgs e)
        {

        }
    }
}
