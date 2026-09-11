using Microsoft.Data.Sqlite;
using System.Data;
using System.Reflection.Emit;
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


namespace zadanie8
{
   
    public partial class MainWindow : Window
    {
            string polaczenie = "Data Source=kontakty.db";

            public MainWindow()
            {
                InitializeComponent();
                Baza();
                Wczytaj();
            }

            void Baza()
            {
                using var con = new SqliteConnection(polaczenie);
                con.Open();

                var cmd = con.CreateCommand();
                cmd.CommandText =
                    "CREATE TABLE IF NOT EXISTS Kontakty (" +
                    "Id INTEGER PRIMARY KEY AUTOINCREMENT," +
                    "Imie TEXT, Telefon TEXT, Email TEXT)";

                cmd.ExecuteNonQuery();
            }

            void Wczytaj()
            {
                using var con = new SqliteConnection(polaczenie);
                con.Open();

                var cmd = con.CreateCommand();
                cmd.CommandText = "SELECT * FROM Kontakty";

                DataTable tabelaDanych = new DataTable();

                using var reader = cmd.ExecuteReader();
                tabelaDanych.Load(reader);

                tabela.ItemsSource = tabelaDanych.DefaultView;
            }

            private void Dodaj_Click(object sender, RoutedEventArgs e)
            {
                using var con = new SqliteConnection(polaczenie);
                con.Open();

                var cmd = con.CreateCommand();
                cmd.CommandText =
                    "INSERT INTO Kontakty (Imie, Telefon, Email) " +
                    "VALUES ($imie, $telefon, $email)";

                cmd.Parameters.AddWithValue("$imie", imie.Text);
                cmd.Parameters.AddWithValue("$telefon", telefon.Text);
                cmd.Parameters.AddWithValue("$email", email.Text);

                cmd.ExecuteNonQuery();

                Wczytaj();
            }

            private void Usun_Click(object sender, RoutedEventArgs e)
            {
                if (tabela.SelectedItem == null)
                    return;

                DataRowView wiersz = (DataRowView)tabela.SelectedItem;

                using var con = new SqliteConnection(polaczenie);
                con.Open();

                var cmd = con.CreateCommand();
                cmd.CommandText = "DELETE FROM Kontakty WHERE Id = $id";
                cmd.Parameters.AddWithValue("$id", wiersz["Id"]);

                cmd.ExecuteNonQuery();

                Wczytaj();
            }

            private void Edytuj_Click(object sender, RoutedEventArgs e)
            {
                if (tabela.SelectedItem == null)
                    return;

                DataRowView wiersz = (DataRowView)tabela.SelectedItem;

                using var con = new SqliteConnection(polaczenie);
                con.Open();

                var cmd = con.CreateCommand();
                cmd.CommandText =
                    "UPDATE Kontakty SET Imie=$imie, Telefon=$telefon, Email=$email " +
                    "WHERE Id=$id";

                cmd.Parameters.AddWithValue("$imie", imie.Text);
                cmd.Parameters.AddWithValue("$telefon", telefon.Text);
                cmd.Parameters.AddWithValue("$email", email.Text);
                cmd.Parameters.AddWithValue("$id", wiersz["Id"]);

                cmd.ExecuteNonQuery();

                Wczytaj();
            }

            private void tabela_SelectionChanged(object sender,
                System.Windows.Controls.SelectionChangedEventArgs e)
            {
                if (tabela.SelectedItem == null)
                    return;

                DataRowView wiersz = (DataRowView)tabela.SelectedItem;

                imie.Text = wiersz["Imie"].ToString();
                telefon.Text = wiersz["Telefon"].ToString();
                email.Text = wiersz["Email"].ToString();
            }
        }
    }
