using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
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

namespace ComponenteRelojCompleto
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

        // Propiedades para horas y minutos
        private int horas;
        public int Horas
        {
            get { return horas; }
            set
            {
                if (horas != value)
                {
                    horas = value;
                    ActualizarHora();
                }
            }
        }

        private int LimitarValorHoras(int valor)
        {
            return Math.Max(0, Math.Min(24, valor));
        }private int LimitarValorMinutos(int valor)
        {
            return Math.Max(0, Math.Min(60, valor));
        }

        private int minutos;
        public int Minutos
        {
            get { return minutos; }
            set
            {
                if (minutos != value)
                {
                    minutos = value;
                    ActualizarHora();
                }
            }
        }




        // Método para pintar la hora cuando se actualizan las propiedades
        private void ActualizarHora()
        {
            Horas = LimitarValorHoras(Horas);
            Minutos = LimitarValorMinutos(Minutos);

            int digHoras1 = Horas / 10;
            int digHoras2 = Horas % 10;
            int digMin1 = Minutos / 10;
            int digMin2 = Minutos % 10;

            hora1.pintarNum(digHoras1);
            hora2.pintarNum(digHoras2);
            min1.pintarNum(digMin1);
            min2.pintarNum(digMin2);
        }
    }
}
