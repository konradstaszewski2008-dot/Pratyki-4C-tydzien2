using System;
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
using System.Windows.Forms;

namespace zadanie6
{
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }
        private void WybierzFolder_Click(object sender, RoutedEventArgs e)
            {
                var okno = new System.Windows.Forms.FolderBrowserDialog();

                if (okno.ShowDialog() == System.Windows.Forms.DialogResult.OK)
                {
                    string folder = okno.SelectedPath;

                    listaObrazow.Items.Clear();

                    string[] pliki = Directory.GetFiles(folder);

                    foreach (string plik in pliki)
                    {
                        string rozszerzenie = Path.GetExtension(plik).ToLower();

                    if (rozszerzenie == ".jpg" ||
                        rozszerzenie == ".jpeg" ||
    
                        rozszerzenie == ".png" ||
                        rozszerzenie == ".bmp")
                    {
                            BitmapImage obraz = new BitmapImage();

                            obraz.BeginInit();
                            obraz.UriSource = new System.Uri(plik);
                            obraz.DecodePixelWidth = 100;
                            obraz.CacheOption = BitmapCacheOption.OnLoad;
                            obraz.EndInit();

                            listaObrazow.Items.Add(obraz);
                        }
                    }
                }
            }

            private void ListaObrazow_SelectionChanged(
                object sender,
                SelectionChangedEventArgs e)
            {
                if (listaObrazow.SelectedItem != null)
                {
                    BitmapImage wybranyObraz =
                        (BitmapImage)listaObrazow.SelectedItem;

                    duzyObraz.Source = wybranyObraz;
                }
            }
        }
    }

