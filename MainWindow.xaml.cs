using Microsoft.Win32;
using System.Text;
using System.IO;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;


namespace Zadanie5
{

    public partial class MainWindow : Window
    {
        string plik = "";
        public MainWindow()
        {
            InitializeComponent();
        }
    private void Nowy_Click(object sender, RoutedEventArgs e)
            {
                tekst.Text = "";
                plik = "";
            }

            private void Otworz_Click(object sender, RoutedEventArgs e)
            {
                OpenFileDialog okno = new OpenFileDialog();

                if (okno.ShowDialog() == true)
                {
                    tekst.Text = File.ReadAllText(okno.FileName);
                    plik = okno.FileName;
                }
            }

            private void Zapisz_Click(object sender, RoutedEventArgs e)
            {
                if (plik == "")
                {
                    ZapiszJako_Click(sender, e);
                }
                else
                {
                    File.WriteAllText(plik, tekst.Text);
                }
            }

            private void ZapiszJako_Click(object sender, RoutedEventArgs e)
            {
                SaveFileDialog okno = new SaveFileDialog();

                if (okno.ShowDialog() == true)
                {
                    File.WriteAllText(okno.FileName, tekst.Text);
                    plik = okno.FileName;
                }
            }

            private void Zamknij_Click(object sender, RoutedEventArgs e)
            {
                Close();
            }
        }
    }
