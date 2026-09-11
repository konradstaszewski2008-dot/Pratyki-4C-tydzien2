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

namespace zadanie3
{
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void textBox_TextChanged(object sender, System.Windows.Controls.TextChangedEventArgs e)
        {
            Przelicz();
        }

        private void comboBox_SelectionChanged(object sender, System.Windows.Controls.SelectionChangedEventArgs e)
        {
            Przelicz();
        }

        private void Przelicz()
        {
            double liczba;

           
            if (!double.TryParse(textBox.Text, out liczba))
            {
                wynik.Text = "";
                return;
            }

            if (comboBox.SelectedIndex == 0)
            {
               
                wynik.Text = (liczba * 0.621371).ToString("0.00");
            }
            else if (comboBox.SelectedIndex == 1)
            {
             
                wynik.Text = (liczba * 1.60934).ToString("0.00");
            }
            else if (comboBox.SelectedIndex == 2)
            {
             
                wynik.Text = (liczba * 2.20462).ToString("0.00");
            }
            else if (comboBox.SelectedIndex == 3)
            {
                
                wynik.Text = (liczba * 0.453592).ToString("0.00");
            }
            else if (comboBox.SelectedIndex == 4)
            {
               
                wynik.Text = (liczba * 9 / 5 + 32).ToString("0.00");
            }
            else if (comboBox.SelectedIndex == 5)
            {
               
                wynik.Text = ((liczba - 32) * 5 / 9).ToString("0.00");
            }
        }
    }
}
