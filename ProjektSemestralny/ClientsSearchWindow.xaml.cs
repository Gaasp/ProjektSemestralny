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
    /// Logika interakcji dla klasy ClientsSearchWindow.xaml
    /// </summary>
    public partial class ClientsSearchWindow : Window
    {
      
        ClientsView ClientsV;
        Frame Frame;
        public ClientsSearchWindow()
        {
            InitializeComponent();
        }
        public ClientsSearchWindow(Frame frame, ClientsView clientsV)
        {
            InitializeComponent();
            this.Frame = frame;
            this.ClientsV = clientsV;

            this.Loaded += SearchPage_Loaded;
            EditBtn.IsEnabled = false;
            DelBtn.IsEnabled = false;
            searchBox.IsEnabled = false;
        }

        private void SearchPage_Loaded(object sender, RoutedEventArgs e)
        {
            searchBox.Focusable = true;
            Keyboard.Focus(searchBox);
        }

        private void Search_Click(object sender, RoutedEventArgs e)
        {
            if (searchBox.Text == "")
            {
                // WarningSearchLabel.Visibility = Visibility.Visible;
                return;
            }

            // WarningSearchLabel.Visibility = Visibility.Hidden;
            //gridTable.DataContext = ClientsV.searchRepo(searchBox.Text);
            // gridTable.Columns[0].Visibility = Visibility.Hidden;        // Hides the first column i.e. ID


        }
        DataTable dt = new DataTable("Klienci");
        private void searchButton_Click(object sender, RoutedEventArgs e)
        {
            SqlConnection connection = new SqlConnection(Properties.Settings.Default.HotelConnectionString);
            try
            {
                connection.Open();
                string query = "SELECT id_Klienta,imie,nazwisko,pesel,telefon FROM Klienci";
                SqlCommand createCommand = new SqlCommand(query, connection);
                createCommand.ExecuteNonQuery();

                using (SqlDataAdapter dataApp = new SqlDataAdapter("SELECT * FROM Klienci", connection))
                {

                    dataApp.Fill(dt);
                    gridTable.ItemsSource = dt.DefaultView;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Message", MessageBoxButton.OK, MessageBoxImage.Error);
            }

            searchBox.IsEnabled = true;
           
           
           
        }
        private void dataTable_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (gridTable.SelectedCells.Count == 0)
            {
                EditBtn.IsEnabled = false;
                DelBtn.IsEnabled = false;
                return;
            }
            EditBtn.IsEnabled = true;
            DelBtn.IsEnabled = true;
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {

        }

        private void searchBox_TextChanged(object sender, TextChangedEventArgs e)
        {

        }

        private void e(object sender, KeyEventArgs e)
        {

        }

        private void searchBox_TextChanged_1(object sender, TextChangedEventArgs e)
        {
            DataView dataView = new DataView(dt);
            dataView.RowFilter = string.Format("imie LIKE '%{0}%'", searchBox.Text);
            gridTable.ItemsSource = dataView;
           
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
    }
}
