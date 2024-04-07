using System.Collections.Generic;
using System.Collections.Specialized;
using System.Linq;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Input;
using System.Windows.Media;

namespace BibliotecaCalculadora
{
    public partial class UserControl1 : UserControl
    {
        public List<object> ElementosListBox
        {
            get { return listBox.Items.Cast<object>().ToList(); }
        }

        // Propiedades para establecer el número máximo de elementos del ListBox, el número máximo de caracteres del TextBox y el color de fondo del Slider
        public int MaxElementosListBox { get; set; }
        public int MaxCaracteresTextBox { get; set; }
        public Brush ColorFondoSlider { get; set; }




        // Constructor
        public UserControl1()
        {
            InitializeComponent();
            // Manejar el evento KeyDown del TextBox
            textBox.KeyDown += TextBox_KeyDown;
            // Manejar el evento MouseDoubleClick del ListBox
            listBox.MouseDoubleClick += ListBox_MouseDoubleClick;

            // Establecer el rango del Slider
            slider.Minimum = 0;
            slider.Maximum = MaxElementosListBox;

            // Suscribir al evento CollectionChanged del ListBox
            ((INotifyCollectionChanged)listBox.Items).CollectionChanged += ListBoxItems_CollectionChanged;
        }

        // Método para limpiar el contenido del TextBox
        public void LimpiarTextBox()
        {
            textBox.Text = string.Empty;
            textBox.Background = Brushes.White; // Restablecer el color del TextBox
            textBox.IsEnabled = true; // Habilitar la entrada de datos en el TextBox
        }

        // Método para agregar un elemento al ListBox
        public void AgregarElementoListBox(object elemento)
        {
            listBox.Items.Add(elemento);
        }

        // Método para eliminar un elemento del ListBox
        public void EliminarElementoListBox(object elemento)
        {
            listBox.Items.Remove(elemento);
        }

        // Método para vaciar el ListBox
        public void LimpiarListBox()
        {
            listBox.Items.Clear();
        }

        // Manejar el evento KeyDown del TextBox
        private void TextBox_KeyDown(object sender, KeyEventArgs e)
        {
            // Verificar si la tecla presionada es Enter
            if (e.Key == Key.Enter)
            {
                // Agregar el texto al ListBox
                AgregarElementoListBox(textBox.Text);
                ActualizarSlider();

                // Verificar si el ListBox ha alcanzado su capacidad máxima
                if (listBox.Items.Count >= MaxElementosListBox)
                {
                    // Cambiar el color del TextBox a rojo
                    textBox.Background = Brushes.Red;
                    // Deshabilitar la entrada de datos en el TextBox
                    textBox.IsEnabled = false;
                    textBox.Text = string.Empty;
                }
                else
                {
                    // Limpiar el TextBox
                    LimpiarTextBox();
                }

                // Indicar que el evento ha sido manejado
                e.Handled = true;
            }
        }
        public string ObtenerPalabraMasLarga()
        {
            string palabraMasLarga = "";

            if (listBox.Items != null)
            {
                foreach (string elemento in listBox.Items)
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

        private void ActualizarSlider()
        {
            slider.Value = listBox.Items.Count;

            if (listBox.Items.Count == MaxElementosListBox)
            {
                textBox.Background = Brushes.Red;
                textBox.IsEnabled = false;
            }
            else
            {
                textBox.Background = Brushes.White;
                textBox.IsEnabled = true;
            }
        }

        // Manejar el evento MouseDoubleClick del ListBox
        private void ListBox_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            // Obtener el elemento seleccionado en el ListBox
            object elemento = listBox.SelectedItem;
            // Verificar si se seleccionó un elemento
            if (elemento != null)
            {
                // Eliminar el elemento seleccionado del ListBox
                EliminarElementoListBox(elemento);
                // Actualizar el valor del Slider con el número de elementos actuales del ListBox
                slider.Value = listBox.Items.Count;
                // Restablecer el color del TextBox a blanco
                textBox.Background = Brushes.White;
                // Habilitar la entrada de datos en el TextBox
                textBox.IsEnabled = true;
                // Indicar que el evento ha sido manejado
                e.Handled = true;
            }
        }



        // Manejar el evento CollectionChanged del ListBox
        private void ListBoxItems_CollectionChanged(object sender, NotifyCollectionChangedEventArgs e)
        {
            // Actualizar el valor del Slider con el número de elementos actuales del ListBox
            slider.Value = listBox.Items.Count;

            // Verificar si el número de elementos del ListBox ha alcanzado el límite máximo
            if (listBox.Items.Count >= MaxElementosListBox)
            {
                // Cambiar el color del TextBox a rojo
                textBox.Background = Brushes.Red;
                // Deshabilitar la entrada de datos en el TextBox
                textBox.IsEnabled = false;
            }
        }

        // Manejar el evento TextChanged del TextBox
        private void textBox_TextChanged(object sender, TextChangedEventArgs e)
        {
            // Verificar si el texto ingresado excede el límite de caracteres
            if (textBox.Text.Length > MaxCaracteresTextBox)
            {
                // Truncar el texto para que no exceda el límite de caracteres
                textBox.Text = textBox.Text.Substring(0, MaxCaracteresTextBox);
                // Posicionar el cursor al final del texto
                textBox.SelectionStart = textBox.Text.Length;
            }
        }

        private void slider_ValueChanged(object sender, RoutedPropertyChangedEventArgs<double> e)
        {

        }
    }
}
