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
    /// Logika interakcji dla klasy reservationWindow.xaml
    /// </summary>
    public partial class reservationWindow : Window
    {
        public reservationWindow()
        {
            InitializeComponent();
        }
        DataTable dt = new DataTable("Rezerwacje");
        private void Button_Click(object sender, RoutedEventArgs e)
        {

        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {

        }

        private void Button_Click_2(object sender, RoutedEventArgs e)
        {
            SqlConnection connection = new SqlConnection(Properties.Settings.Default.HotelConnectionString);
            try
            {
                connection.Open();
                string query = "SELECT id_rezerwacji,id_klienta,data_rezerwacji,id_pokoju FROM Rezerwacje";
                SqlCommand createCommand = new SqlCommand(query, connection);
                createCommand.ExecuteNonQuery();

                using (SqlDataAdapter dataApp = new SqlDataAdapter("SELECT * FROM Rezerwacje", connection))
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

        private void search_TextBox_TextChanged(object sender, TextChangedEventArgs e)
        {
            DataView dataView = new DataView(dt);
            dataView.RowFilter = "Convert(id_pokoju, 'System.String') LIKE '" + search_TextBox.Text + "%'";
            dataGrid.ItemsSource = dataView;
        }

        private void Button_Click_3(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
    }
}
