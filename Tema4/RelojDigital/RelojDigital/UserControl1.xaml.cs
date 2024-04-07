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

namespace RelojDigital
{
    /// <summary>
    /// Lógica de interacción para UserControl1.xaml
    /// </summary>
    public partial class UserControl1 : UserControl
    {
        SolidColorBrush negro = new SolidColorBrush(Colors.Black);
        SolidColorBrush gris = new SolidColorBrush(Colors.LightGray);
        private bool isPressed = false;

        public UserControl1()
        {
            InitializeComponent();
        }

        public void pintarNum(int num)
        {
            switch (num)
            {
                case 0:
                    paloA.Fill = negro;
                    paloB.Fill = negro;
                    paloBD.Fill = negro;
                    paloBI.Fill = negro;
                    paloC.Fill = gris;
                    paloAD .Fill = negro;
                    paloAI .Fill = negro;
                    break;
                case 1:
                    paloA.Fill = gris;
                    paloB.Fill = gris;
                    paloBD.Fill = negro;
                    paloBI.Fill = gris;
                    paloC.Fill = gris;
                    paloAD.Fill = negro;
                    paloAI.Fill = gris;
                    break;
                case 2:
                    paloA.Fill = negro;
                    paloB.Fill = negro;
                    paloBD.Fill = gris;
                    paloBI.Fill = negro;
                    paloC.Fill = negro;
                    paloAD.Fill = negro;
                    paloAI.Fill = gris;
                    break;
                case 3:
                    paloA.Fill = negro;
                    paloB.Fill = negro;
                    paloBD.Fill = negro;
                    paloBI.Fill = gris;
                    paloC.Fill = negro;
                    paloAD.Fill = negro;
                    paloAI.Fill = gris;
                    break;
                case 4:
                    paloA.Fill = gris;
                    paloB.Fill = gris;
                    paloBD.Fill = negro;
                    paloBI.Fill = gris;
                    paloC.Fill = negro;
                    paloAD.Fill = negro;
                    paloAI.Fill = negro;
                    break;
                case 5:
                    paloA.Fill = negro;
                    paloAI.Fill = negro;
                    paloAD.Fill = gris;
                    paloC.Fill = negro;
                    paloB.Fill = negro;
                    paloBD.Fill = negro;
                    paloBI.Fill = gris;
                    break;
                case 6:
                    paloA.Fill = negro;
                    paloAI.Fill = negro;
                    paloAD.Fill = gris;
                    paloC.Fill = negro;
                    paloB.Fill = negro;
                    paloBD.Fill = negro;
                    paloBI.Fill = negro;
                    break;
                case 7:
                    paloA.Fill = negro;
                    paloAI.Fill = gris;
                    paloAD.Fill = negro;
                    paloC.Fill = gris;
                    paloB.Fill = gris;
                    paloBD.Fill = negro;
                    paloBI.Fill = gris;
                    break;
                case 8:
                    paloA.Fill = negro;
                    paloAI.Fill = negro;
                    paloAD.Fill = negro;
                    paloC.Fill = negro;
                    paloB.Fill = negro;
                    paloBD.Fill = negro;
                    paloBI.Fill = negro;
                    break;
                case 9:
                    paloA.Fill = negro;
                    paloAI.Fill = negro;
                    paloAD.Fill = negro;
                    paloC.Fill = negro;
                    paloB.Fill = gris;
                    paloBD.Fill = negro;
                    paloBI.Fill = gris;
                    break;
            }
        }

        public void cambiarColor(SolidColorBrush color)
        {

        }

    }
}
