using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel.DataAnnotations;
using System.Configuration;
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


namespace GridPanel
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window

    {



        private ObservableCollection<TextItem> textItems = new ObservableCollection<TextItem>();
        private bool isEditMode = false;
        private TextItem editingItem;
        private TextItem currentEditingItem = null;
        private double altura=1.45;
        private int numHijos;
        public MainWindow()
        {
            InitializeComponent();
            dataGrid.ItemsSource = textItems;

        }

        public class TextItem
        {
            public string Nombre { get; set; }
            public string Apellido { get; set; }
            public string Direccion { get; set; }
            public int NumHijos { get; set; }

            public DateTime Fecha { get; set; }

            public double Altura { get; set; }

           
        }
        private void DataGrid_SelectionChanged(object sender, System.Windows.Controls.SelectionChangedEventArgs e)
        {
            if (isEditMode)
            {
                if (dataGrid.SelectedItem != null)
                {
                    currentEditingItem = (TextItem)dataGrid.SelectedItem;
                    txtNombre.Text = currentEditingItem.Nombre;
                    txtApellido.Text = currentEditingItem.Apellido;
                    txtDireccion.Text = currentEditingItem.Direccion;
                    sliderNumHijos.Value = currentEditingItem.NumHijos;
                    tbAltura.Text = currentEditingItem.Altura.ToString();
                    DateTime fecha = DateTime.Now;  

                    isEditMode = true;
                    btnAddEdit.Content = "Editar";
                }
            }
            
        }

        private void AddEdit_Click(object sender, RoutedEventArgs e)
        {
            string nombre = txtNombre.Text;
            string apellido = txtApellido.Text;
            string direccion = txtDireccion.Text;
            int numHijos = (int)sliderNumHijos.Value;
            DateTime fecha = datePicker.SelectedDate ?? DateTime.MinValue; // Obtener la fecha del DatePicker
            double altura = double.Parse(tbAltura.Text);
            


            if (string.IsNullOrWhiteSpace(nombre) || string.IsNullOrWhiteSpace(apellido) || string.IsNullOrWhiteSpace(direccion))
            {
                errorTextBlock.Text = "Por favor, rellena todos los campos.";
            }
            else
            {



                TreeViewItem nuevoNodo = new TreeViewItem();
                nuevoNodo.Header = nombre;
                nuevoNodo.Items.Add(listBoxNombresHijos.ItemsSource);
                foreach (var item in listBoxNombresHijos.Items)
                {
                    if (item is string nombreHijo)
                    {
                        nuevoNodo.Items.Add(item);
                    }

                }

                // Agregar el nodo de la persona al TreeView
                treeView.Items.Add(nuevoNodo);



                if (isEditMode && currentEditingItem != null)
                {
                    currentEditingItem.Nombre = nombre;
                    currentEditingItem.Apellido = apellido;
                    currentEditingItem.Direccion = direccion;
                    currentEditingItem.NumHijos = numHijos;
                    currentEditingItem.Fecha = fecha; 
                    currentEditingItem.Altura = altura;
                    

                    isEditMode = false;
                    btnAddEdit.Content = "Añadir";
                    
                }
                else
                {
                    textItems.Add(new TextItem
                    {
                        Nombre = nombre,
                        Apellido = apellido,
                        Direccion = direccion,
                        NumHijos = numHijos,
                        Altura = altura,
                        Fecha = fecha, // Asignar la fecha

                    });


                    

                }

                
                txtApellido.Clear();
                txtDireccion.Clear();
                sliderNumHijos.Value = 0; // Restablecer el Slider
                tbAltura.Clear();
                errorTextBlock.Text = "";
                datePicker.SelectedDate = null; // Restablecer el DatePicker
                listBoxNombresHijos.Items.Clear();
                currentEditingItem = null;
            }
            
        }

        private void btnEdit_Click(object sender, RoutedEventArgs e)
        {
            if (dataGrid.SelectedItem != null)
            {
                int selectedIndex = dataGrid.SelectedIndex;
                if (selectedIndex >= 0 && selectedIndex < textItems.Count)
                {
                    textItems[selectedIndex].Nombre = txtNombre.Text;
                    textItems[selectedIndex].Apellido = txtApellido.Text;
                    textItems[selectedIndex].Direccion = txtDireccion.Text;
                    textItems[selectedIndex].Altura = double.Parse(tbAltura.Text);
                    textItems[selectedIndex].NumHijos = (int)sliderNumHijos.Value;
                    textItems[selectedIndex].Fecha = datePicker.SelectedDate ?? DateTime.MinValue;

                    txtApellido.Clear();
                    txtDireccion.Clear();
                    tbAltura.Clear();
                    datePicker.SelectedDate = null; ;

                    btnAddEdit.Content = "Añadir";
                    isEditMode = false;
                    dataGrid.Items.Refresh();
                }
            }
            else
            {
                MessageBox.Show("Por favor, seleccione un registro para editar.", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        

        

        private void AgregarHijo_Click(object sender, RoutedEventArgs e)
        {
            string nombreHijo = txtNombreHijo.Text;
            int numHijos = (int)sliderNumHijos.Value;

            if (!string.IsNullOrWhiteSpace(nombreHijo) && listBoxNombresHijos.Items.Count < numHijos)
            {
                listBoxNombresHijos.Items.Add(nombreHijo);

                txtNombreHijo.Clear();


            }
        }


        private void Delete_Click(object sender, RoutedEventArgs e)
        {
            if (dataGrid.SelectedItem != null)
            {
                var selectedTextItem = (TextItem)dataGrid.SelectedItem;
                textItems.Remove(selectedTextItem);
            }
        }

        private void Reset_Click(object sender, RoutedEventArgs e)
        {
            textItems.Clear();
        }

        private void CheckBox_Checked(object sender, RoutedEventArgs e)
        {
            if (cbHijos.IsChecked == true)
            {
                sliderNumHijos.Visibility = Visibility.Visible;
            }
            else
            {
                sliderNumHijos.Visibility = Visibility.Collapsed;
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

        
    }
}


