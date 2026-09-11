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

namespace zadanie10
{
  
        public partial class MainWindow : Window
        {
            Brush kolor = Brushes.Black;
            Point start;

            public MainWindow()
            {
                InitializeComponent();
            }

            private void Canvas_MouseDown(object sender, MouseButtonEventArgs e)
            {
                start = e.GetPosition(canvas);
            }

            private void Canvas_MouseMove(object sender, MouseEventArgs e)
            {
                if (e.LeftButton == MouseButtonState.Pressed)
                {
                    Point koniec = e.GetPosition(canvas);

                    Line linia = new Line();
                    linia.X1 = start.X;
                    linia.Y1 = start.Y;
                    linia.X2 = koniec.X;
                    linia.Y2 = koniec.Y;
                    linia.Stroke = kolor;
                    linia.StrokeThickness = double.Parse(grubosc.Text);

                    canvas.Children.Add(linia);

                    start = koniec;
                }
            }

            private void Czarny_Click(object sender, RoutedEventArgs e)
            {
                kolor = Brushes.Black;
            }

            private void Czerwony_Click(object sender, RoutedEventArgs e)
            {
                kolor = Brushes.Red;
            }

            private void Niebieski_Click(object sender, RoutedEventArgs e)
            {
                kolor = Brushes.Blue;
            }

            private void Wyczysc_Click(object sender, RoutedEventArgs e)
            {
                canvas.Children.Clear();
            }
        }
    }
