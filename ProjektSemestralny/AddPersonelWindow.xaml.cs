using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using System.Data.SqlClient;

namespace ProjektSemestralny
{
    /// <summary>
    /// Logika interakcji dla klasy AddPersonelWindow.xaml
    /// </summary>
    public partial class AddPersonelWindow : Window
    {
        public AddPersonelWindow()
        {
            InitializeComponent();
        }

        private void TextBox_TextChanged(object sender, TextChangedEventArgs e)
        {

        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            SqlConnection connection = new SqlConnection(Properties.Settings.Default.HotelConnectionString);
            try
            {
                connection.Open();
                string query = "insert into Personel (imie, nazwisko, stanowisko, telefon) values('" + this.imie_TextBox.Text + "','" + this.nazwisko_TextBox.Text +"','"+this.stanowisko_TextBox1.Text+"','" + this.telefon_TextBox.Text + "')";
                SqlCommand createCommand = new SqlCommand(query, connection);
                createCommand.ExecuteNonQuery();
                MessageBox.Show("Personel został Dodany");
                connection.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Message", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
    }
}
