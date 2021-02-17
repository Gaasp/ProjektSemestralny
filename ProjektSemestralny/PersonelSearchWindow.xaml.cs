using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
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
    /// Logika interakcji dla klasy PersonelSearchWindow.xaml
    /// </summary>
    public partial class PersonelSearchWindow : Window
    {
        public PersonelSearchWindow()
        {
            InitializeComponent();
        }
        DataTable dt = new DataTable("Klienci");
        private void searchButton_Click(object sender, RoutedEventArgs e)
        {
            SqlConnection connection = new SqlConnection(Properties.Settings.Default.HotelConnectionString);
            try
            {
                connection.Open();
                string query = "SELECT imie,nazwisko,stanowisko,telefon FROM Personel";
                SqlCommand createCommand = new SqlCommand(query, connection);
                createCommand.ExecuteNonQuery();

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
    }
}
