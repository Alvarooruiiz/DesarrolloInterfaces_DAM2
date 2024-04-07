using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Media;

namespace GridPanel
{
    public partial class MainWindow : Window
    {
        private ObservableCollection<Persona> personas = new ObservableCollection<Persona>();
        private bool modoEdicion = false;
        private bool modoEdicionHijos = true;
        private double altura = 1.45;
        private List<String> nuevosNombresHijos = new List<string>(); 


        public MainWindow()
        {
            InitializeComponent();
            dataGrid.ItemsSource = personas;
            sliderNumHijos.ValueChanged += SliderNumHijos_ValueChanged;

        }



        private void AñadirEditar_Click(object sender, RoutedEventArgs e)
        {
            if (modoEdicion)
            {
                // Modo "Editar"
                if (dataGrid.SelectedItem is Persona selectedPersona)
                {
                    string nombre = tbNombre.Text;
                    string apellidos = tbApellidos.Text;
                    string direccion = tbDireccion.Text;
                    DateTime fecha = datePicker.SelectedDate ?? DateTime.MinValue;
                    double altura;

                    if (!double.TryParse(tbAltura.Text, out altura))
                    {
                        MessageBox.Show("Por favor, ingrese una altura válida.");
                        return;
                    }

                    int numeroHijos = (int)sliderNumHijos.Value;

                    if (string.IsNullOrWhiteSpace(nombre) || string.IsNullOrWhiteSpace(apellidos) || string.IsNullOrWhiteSpace(direccion) ||
                        fecha == DateTime.MinValue || lbHijos.Items.Count != numeroHijos)
                    {
                        MessageBox.Show("Por favor, complete todos los campos y asegúrese de que el número de hijos coincida.");
                        return;
                    }

                    selectedPersona.Nombre = nombre;
                    selectedPersona.Apellidos = apellidos;
                    selectedPersona.Direccion = direccion;
                    selectedPersona.Fecha = fecha;
                    selectedPersona.Altura = altura;
                    selectedPersona.NumHijos = numeroHijos;

                    // Restaura el botón y los TextBox
                    btnAñadirEditar.Content = "Añadir";
                    limpiarTB();
                    tbNombreHijo.Clear();
                    TreeViewItem nuevoNodo = new TreeViewItem();
                    nuevoNodo.Header = nombre;
                    nuevoNodo.Items.Add(lbHijos.ItemsSource);

                    foreach (var item in lbHijos.Items)
                    {
                        if (item is string nombreHijo)
                        {
                            nuevoNodo.Items.Add(item);
                        }
                    }



                    foreach (var item in lbHijos.Items)
                    {
                        if (item is string nombreHijo)
                        {
                            nuevosNombresHijos.Add(nombreHijo);  // Agregar los nombres de los hijos a la nueva lista
                        }
                    }

                    modoEdicion = false;
                    modoEdicionHijos = true;
                    dataGrid.SelectedItem = null;

                    // Actualizar datagrid
                    dataGrid.Items.Refresh();
                    lbHijos.Items.Refresh();
                }
                else
                {
                    MessageBox.Show("Por favor, seleccione un elemento para editar.");
                }
            }
            else
            {
                // Modo "Añadir"
                string nombre = tbNombre.Text;
                string apellidos = tbApellidos.Text;
                string direccion = tbDireccion.Text;
                DateTime fecha = datePicker.SelectedDate ?? DateTime.MinValue;
                double altura;

                if (!double.TryParse(tbAltura.Text, out altura))
                {
                    MessageBox.Show("Por favor, ingrese una altura válida.");
                    return;
                }

                int numeroHijos = (int)sliderNumHijos.Value;

                if (string.IsNullOrWhiteSpace(nombre) || string.IsNullOrWhiteSpace(apellidos) || string.IsNullOrWhiteSpace(direccion) ||
                    fecha == DateTime.MinValue || lbHijos.Items.Count != numeroHijos)
                {
                    MessageBox.Show("Por favor, complete todos los campos y asegúrese de que el número de hijos coincida.");
                    return;
                }

                TreeViewItem nuevoNodo = new TreeViewItem();
                nuevoNodo.Header = nombre;
                nuevoNodo.Items.Add(lbHijos.ItemsSource);

                foreach (var item in lbHijos.Items)
                {
                    if (item is string nombreHijo)
                    {
                        nuevoNodo.Items.Add(item);
                    }
                }

                

                foreach (var item in lbHijos.Items)
                {
                    if (item is string nombreHijo)
                    {
                        nuevosNombresHijos.Add(nombreHijo);  // Agregar los nombres de los hijos a la nueva lista
                    }
                }

                // Limpiar el ListBox antes de agregar los nuevos nombres de hijos
                lbHijos.Items.Clear();
                lbHijos.Items.Refresh();



                // Agregar el nodo de la persona al TreeView
                tvHijos.Items.Add(nuevoNodo);

                personas.Add(new Persona { Nombre = nombre, Apellidos = apellidos, Direccion = direccion, Fecha = fecha, Altura = altura, NumHijos = numeroHijos });
                limpiarTB();
            }
        }
        private void lbHijos_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (lbHijos.SelectedItem is string nombreHijoSeleccionado)
            {
                tbNombreHijo.Text = nombreHijoSeleccionado;
                modoEdicionHijos = false;
            }
            else
            {
                tbNombreHijo.Text = string.Empty;
            }
            ActualizarTreeView();
            lbHijos.Items.Refresh();
        }

        private void ActualizarTreeView()
        {
            tvHijos.Items.Clear();
            foreach (var persona in personas)
            {
                TreeViewItem nodoPersona = new TreeViewItem();
                nodoPersona.Header = persona.Nombre;

                foreach (var nombreHijo in lbHijos.Items)
                {
                    nodoPersona.Items.Add(new TreeViewItem { Header = nombreHijo });
                }

                tvHijos.Items.Add(nodoPersona);
            }
        }

        private void btnAgregarActualizarHijos_Click(object sender, RoutedEventArgs e)
        {
            if(modoEdicionHijos)
            {
                string nombreHijo = tbNombreHijo.Text;
                int numHijos = (int)sliderNumHijos.Value;

                if (!string.IsNullOrWhiteSpace(nombreHijo) && lbHijos.Items.Count < numHijos)
                {
                    lbHijos.Items.Add(nombreHijo);

                    tbNombreHijo.Clear();
                }
                lbHijos.Items.Refresh();
            }
            else
            {   
                string nuevoNombreHijo = tbNombreHijo.Text;
                if (!string.IsNullOrWhiteSpace(nuevoNombreHijo) && lbHijos.SelectedItem != null)
                {
                    int indiceSeleccionado = lbHijos.SelectedIndex;
                    lbHijos.Items[indiceSeleccionado] = nuevoNombreHijo;
                }
                lbHijos.Items.Refresh();
            }
            
        }


        private void DataGrid_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (dataGrid.SelectedItem is Persona selectedPersona)
            {
                // Al seleccionar un elemento del DataGrid, habilita el modo "Editar"
                btnAñadirEditar.Content = "Editar";

                tvHijos.Items.Clear();
                tbNombre.Text = selectedPersona.Nombre;
                tbApellidos.Text = selectedPersona.Apellidos;
                tbDireccion.Text = selectedPersona.Direccion;
                datePicker.SelectedDate = selectedPersona.Fecha;
                tbAltura.Text = selectedPersona.Altura.ToString();
                sliderNumHijos.Value = selectedPersona.NumHijos;
                foreach (var nombreHijo in nuevosNombresHijos)
                {
                    lbHijos.Items.Add(nombreHijo);
                }
                lbHijos.Items.Refresh();

                ActualizarTreeView(selectedPersona);


                modoEdicionHijos = false;
                modoEdicion = true;
            }
        }

        private void ActualizarTreeView(Persona persona)
        {
            TreeViewItem nodoPersona = new TreeViewItem();
            nodoPersona.Header = persona.Nombre;

            foreach (var nombreHijo in lbHijos.Items)
            {
                nodoPersona.Items.Add(new TreeViewItem { Header = nombreHijo });
            }

            tvHijos.Items.Add(nodoPersona);
        }

        private void Reset_Click(object sender, RoutedEventArgs e)
        {
            if (modoEdicion)
            {
                modoEdicion = false;
                limpiarTB();
                btnAñadirEditar.Content = "Añadir";
                dataGrid.SelectedItem = null;
            }
            else
            {
                limpiarTB();
            }
        }

        private void Eliminar_Click(object sender, RoutedEventArgs e)
        {
            if (dataGrid.SelectedItem != null)
            {
                var selectedTextItem = (Persona)dataGrid.SelectedItem;
                personas.Remove(selectedTextItem);
                limpiarTB();
            }
        }


        private void cbTieneHijo_Checked(object sender, RoutedEventArgs e)
        {
            if (cbTieneHijo.IsChecked == true)
            {
                sliderNumHijos.Visibility = Visibility.Visible;
                tvHijos.Visibility = Visibility.Visible;
                tbNombreHijo.Visibility = Visibility.Visible;
                lbHijos.Visibility = Visibility.Visible;
                btnAgregarActualizarHijos.Visibility = Visibility.Visible;
                tbNHijos.Visibility = Visibility.Visible;
            }
            else
            {
                sliderNumHijos.Visibility = Visibility.Hidden;
                tvHijos.Visibility = Visibility.Hidden;
                tbNombreHijo.Visibility = Visibility.Hidden;
                lbHijos.Visibility = Visibility.Hidden;
                btnAgregarActualizarHijos.Visibility = Visibility.Hidden;
                tbNHijos.Visibility = Visibility.Hidden;
            }

            
        }

        private void btnDisminuirAltura_Click(object sender, RoutedEventArgs e)
        {
            if (altura > 0.65) // Verifica el mínimo (0.65).
            {
                altura -= 0.01;
                altura = Math.Round(altura, 2); // Redondear a dos decimales.
                UpdateAlturaText();
            }
        }

        private void btnAumentarAltura_Click(object sender, RoutedEventArgs e)
        {
            if (altura < 2.30) // Verifica el máximo (2.30).
            {
                altura += 0.01;
                altura = Math.Round(altura, 2); // Redondear a dos decimales.
                UpdateAlturaText();
            }
        }

        private void UpdateAlturaText()
        {
            tbAltura.Text = altura.ToString();
        }

        private void SliderNumHijos_ValueChanged(object sender, RoutedPropertyChangedEventArgs<double> e)
        {
            // Actualizar el contenido del TextBlock con el valor actual del Slider
            tbNHijos.Text = e.NewValue.ToString();
        }


        private void TextBox_GotFocus(object sender, RoutedEventArgs e)
        {
            // Cambiar el color de fondo al obtener el foco
            if (sender is TextBox textBox)
            {
                textBox.Background = new SolidColorBrush(Colors.LightBlue); // Cambia el color a tu preferencia
            }
        }

        private void TextBox_LostFocus(object sender, RoutedEventArgs e)
        {
            // Restaurar el color de fondo al perder el foco
            if (sender is TextBox textBox)
            {
                textBox.Background = new SolidColorBrush(Colors.White); // Cambia el color a tu preferencia
            }
        }

        public void limpiarTB()
        {
            tbNombre.Clear();
            tbApellidos.Clear();
            tbDireccion.Clear();
            datePicker.SelectedDate = null;
            tbAltura.Clear();
            sliderNumHijos.Value = 0;
            lbHijos.Items.Clear();
            tbNombreHijo.Clear();
        }
        private void CambiarColor_Click(object sender, RoutedEventArgs e)
        {
            // Obtén la opción de color seleccionada
            if (sender is MenuItem menuItem)
            {
                string colorName = menuItem.Header.ToString();
                switch (colorName)
                {
                    case "Verde":
                        // Cambia el color de fondo a rojo
                        this.Background = Brushes.LightGreen;
                        break;
                    case "Cyan":
                        // Cambia el color de fondo a azul
                        this.Background = Brushes.LightCyan;
                        break;
                    case "Blanco":
                        // Cambia el color de fondo a blanco
                        this.Background = Brushes.White;
                        break;

                }
            }
        }

        private void VaciarLista_Click(object sender, RoutedEventArgs e)
        {
            personas.Clear();
        }
    }




    public class Persona
    {
        public string Nombre { get; set; }
        public string Apellidos { get; set; }
        public string Direccion { get; set; }
        public DateTime Fecha { get; set; }
        public double Altura { get; set; }
        public int NumHijos { get; set; }

    }

    
}