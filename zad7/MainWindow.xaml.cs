using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Windows.Threading;
using System;



namespace zadanie7
{

    public partial class MainWindow : Window
    {
        DispatcherTimer timer = new DispatcherTimer();
        public MainWindow()
        {
            InitializeComponent();

            timer.Interval = TimeSpan.FromSeconds(1);
            timer.Tick += Zegar;
            timer.Start();
        }
        private void Zegar(object sender, EventArgs e)
            {
                DateTime teraz = DateTime.Now;

                
                czas.Text = teraz.ToLongTimeString();

               
                godzina.RenderTransform =
                    new RotateTransform(teraz.Hour * 30 + teraz.Minute * 0.5, 125, 125);

                minuta.RenderTransform =
                    new RotateTransform(teraz.Minute * 6, 125, 125);

                sekunda.RenderTransform =
                    new RotateTransform(teraz.Second * 6, 125, 125);
            }
        }
    }
