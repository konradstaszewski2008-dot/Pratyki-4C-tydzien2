using System;
using System.Windows;
using System.Windows.Controls;

namespace zadanie1
{
    public partial class MainWindow : Window
    {
        double pierwszaLiczba = 0;
        string dzialanie = "";

        public MainWindow()
        {
            InitializeComponent();
        }

        private void Przycisk_Click(object sender, RoutedEventArgs e)
        {
            Button przycisk = (Button)sender;
            string tekst = przycisk.Content.ToString();

         
            if (tekst == "0" || tekst == "1" || tekst == "2" ||
                tekst == "3" || tekst == "4" || tekst == "5" ||
                tekst == "6" || tekst == "7" || tekst == "8" ||
                tekst == "9")
            {
                if (wyswietlacz.Text == "0")
                    wyswietlacz.Text = tekst;
                else
                    wyswietlacz.Text += tekst;
            }

          
            else if (tekst == "C")
            {
                wyswietlacz.Text = "0";
                pierwszaLiczba = 0;
                dzialanie = "";
            }

          
            else if (tekst == "+" || tekst == "-" ||
                     tekst == "*" || tekst == "/")
            {
                pierwszaLiczba = double.Parse(wyswietlacz.Text);
                dzialanie = tekst;
                wyswietlacz.Text = "0";
            }

            else if (tekst == "=")
            {
                double drugaLiczba = double.Parse(wyswietlacz.Text);
                double wynik = 0;

                if (dzialanie == "+")
                    wynik = pierwszaLiczba + drugaLiczba;

                else if (dzialanie == "-")
                    wynik = pierwszaLiczba - drugaLiczba;

                else if (dzialanie == "*")
                    wynik = pierwszaLiczba * drugaLiczba;

                else if (dzialanie == "/")
                {
                    if (drugaLiczba == 0)
                    {
                        wyswietlacz.Text = "Nie można dzielić przez 0";
                        return;
                    }

                    wynik = pierwszaLiczba / drugaLiczba;
                }

                wyswietlacz.Text = wynik.ToString();
            }
        }
    }
}