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
using System.Xml.Linq;
using System.Linq;



namespace zadanie9
{
        public partial class MainWindow : Window
        {
            XDocument xml;
            int numer = 0;
            int punkty = 0;

            public MainWindow()
            {
                InitializeComponent();

                xml = XDocument.Load("pytania.xml");
                PokazPytanie();
            }

            void PokazPytanie()
            {
                var p = xml.Descendants("pytanie").ElementAt(numer);

                pytanie.Text = p.Element("tresc").Value;
                odpA.Content = p.Element("a").Value;
                odpB.Content = p.Element("b").Value;
                odpC.Content = p.Element("c").Value;
                odpD.Content = p.Element("d").Value;
            }

            private void Nastepne_Click(object sender, RoutedEventArgs e)
            {
                var p = xml.Descendants("pytanie").ElementAt(numer);

                string odpowiedz = "";

                if (odpA.IsChecked == true) odpowiedz = "A";
                if (odpB.IsChecked == true) odpowiedz = "B";
                if (odpC.IsChecked == true) odpowiedz = "C";
                if (odpD.IsChecked == true) odpowiedz = "D";

                if (odpowiedz == p.Element("poprawna").Value)
                    punkty++;

                numer++;

                if (numer < xml.Descendants("pytanie").Count())
                {
                    odpA.IsChecked = false;
                    odpB.IsChecked = false;
                    odpC.IsChecked = false;
                    odpD.IsChecked = false;

                    PokazPytanie();
                }
                else
                {
                    pytanie.Text = "Koniec quizu!";
                    odpA.Visibility = Visibility.Hidden;
                    odpB.Visibility = Visibility.Hidden;
                    odpC.Visibility = Visibility.Hidden;
                    odpD.Visibility = Visibility.Hidden;

                    wynik.Text = "Wynik: " + punkty + " / " +
                                 xml.Descendants("pytanie").Count();

                    ((Button)sender).IsEnabled = false;
                }
            }
        }
    }
