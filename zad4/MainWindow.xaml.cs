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

namespace zadanie4
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
        InitializeComponent();
        }

            private void Zarejestruj_Click(object sender, RoutedEventArgs e)
            {
                komunikat.Text = "";

                if (imie.Text == "")
                    komunikat.Text = "Podaj imię";

                else if (nazwisko.Text == "")
                    komunikat.Text = "Podaj nazwisko";

                else if (email.Text == "" || !email.Text.Contains("@"))
                    komunikat.Text = "Podaj poprawny e-mail";

                else if (haslo.Password == "")
                    komunikat.Text = "Podaj hasło";

                else if (haslo.Password != haslo2.Password)
                    komunikat.Text = "Hasła nie są takie same";

                else if (regulamin.IsChecked != true)
                    komunikat.Text = "Zaakceptuj regulamin";

                else
                    komunikat.Text = "Rejestracja poprawna!";
            }
        }
    }
