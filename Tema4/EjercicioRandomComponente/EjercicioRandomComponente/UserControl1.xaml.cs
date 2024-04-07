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

namespace EjercicioRandomComponente
{

    public partial class UserControl1 : UserControl
    {
        private double scaleFactor = 1.0;

        public UserControl1()
        {
            InitializeComponent();
        }
        public void SetImage(string imagePath)
        {
            imageControl.Source = new BitmapImage(new Uri(imagePath));
        }

        public void SetText(string text)
        {
            textLabel.Content = text;
        }

        private void CustomComponent_MouseWheel(object sender, MouseWheelEventArgs e)
        {
            scaleFactor += e.Delta > 0 ? 0.1 : -0.1;

            imageControl.Width =+ 10;
            imageControl.Height =- 10;
        }
    }
}
