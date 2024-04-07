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

namespace ComponenteCronometro
{
    /// <summary>
    /// Interaction logic for UserControl1.xaml
    /// </summary>
    public partial class UserControl1 : UserControl
    {

        private int minutos = 0;
        private int segundos = 0;
        private bool parado = true;
        private bool started = false;

        private int anguloManecilla = 0;

        public UserControl1()
        {
            InitializeComponent();
        }

        public int Minutos
        {
            get
            {
                return this.minutos;
            }
            set
            {
                minutos = value;
                timer.Content = minutos + ":" + segundos;
                this.started = false;
                this.parado = true;
            }
        }

        public int Segundos
        {
            get
            {
                return this.segundos;
            }
            set
            {
                if (value < 60 && value > 0)
                {
                    segundos = value;
                    setManecilla();
                    timer.Content = minutos + ":" + segundos;
                    this.started = false;
                    this.parado = true;
                }
            }
        }

        public bool Start
        {
            get
            {
                return this.started;
            }
            set
            {
                if (value == true) {
                    parado = false;
                    setManecilla();
                    StartAsync(true);
                } else
                {
                    parado = true;
                }
            }
        }

        public async Task StartAsync(bool value)
        {
            if (value)
            {

                this.started = true;
                this.parado = false;


                int vueltasSegundos = this.segundos;

                for (int i = 0; i < vueltasSegundos; i++)
                {
                    await Task.Delay(1000);
                    segundos--;
                    avanzarManecilla();
                    timer.Content = minutos + ":" + segundos;
                    if (parado)
                    {
                        return;
                    }
                }

                minutos--;

                int vueltasMinutos = minutos;

                for (int i = 0; i < vueltasMinutos; i++)
                {
                    segundos = 60;
                    for (int j = 1; j < 60; j++)
                    {
                        await Task.Delay(1000);
                        segundos--;
                        avanzarManecilla();
                        timer.Content = minutos + ":" + segundos;
                        if (parado)
                        {
                            return;
                        }
                    }
                    minutos--;
                    timer.Content = minutos + ":" + segundos;
                }

                if (vueltasMinutos >= 0)
                {
                    segundos = 60;
                    for (int i = 0; i < 60; i++)
                    {
                        await Task.Delay(1000);
                        segundos--;
                        avanzarManecilla();
                        timer.Content = minutos + ":" + segundos;
                    }
                }
            }
        }

        private void avanzarManecilla()
        {
            if (anguloManecilla == 360)
            {
                anguloManecilla = 0;
            }
            anguloManecilla += 6;
            ((RotateTransform)((TransformGroup)manecilla.RenderTransform).Children[2]).Angle = anguloManecilla;
        }

        private void setManecilla()
        {
            anguloManecilla = 360 - (this.segundos * 6);
            ((RotateTransform)((TransformGroup)manecilla.RenderTransform).Children[2]).Angle = anguloManecilla;
        }



    }

}
