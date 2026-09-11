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

namespace zadanie2
{
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void Dodaj_Click(object sender, RoutedEventArgs e)
        {
            if (poleZadania.Text != "")
            {
                listaZadan.Items.Add(poleZadania.Text);

                poleZadania.Text = "";
            }
        }

      
        private void Usun_Click(object sender, RoutedEventArgs e)
        {
            if (listaZadan.SelectedItem != null)
            {
                listaZadan.Items.Remove(listaZadan.SelectedItem);
            }
        }
    }
}