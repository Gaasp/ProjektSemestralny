using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
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
    /// Logika interakcji dla klasy PersonelSearchWindow.xaml
    /// </summary>
    public partial class PersonelSearchWindow : Window
    {
        public PersonelSearchWindow()
        {
            InitializeComponent();
            search_TextBox.IsEnabled = false;
        }
        DataTable dt = new DataTable("Personel");
        private void searchButton_Click(object sender, RoutedEventArgs e)
        {
            SqlConnection connection = new SqlConnection(Properties.Settings.Default.HotelConnectionString);
            try
            {
                connection.Open();
                string query = "SELECT imie,nazwisko,stanowisko,telefon FROM Personel";
                SqlCommand createCommand = new SqlCommand(query, connection);
                createCommand.ExecuteNonQuery();
                search_TextBox.IsEnabled = true;
                using (SqlDataAdapter dataApp = new SqlDataAdapter("SELECT * FROM Personel", connection))
                {

                    dataApp.Fill(dt);
                    dataGrid.ItemsSource = dt.DefaultView;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Message", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void search_TextBox_TextChanged(object sender, TextChangedEventArgs e)
        {
            DataView dataView = new DataView(dt);
            dataView.RowFilter = string.Format("imie LIKE '%{0}%'", search_TextBox.Text);
            dataGrid.ItemsSource = dataView;
        }
    }
}
