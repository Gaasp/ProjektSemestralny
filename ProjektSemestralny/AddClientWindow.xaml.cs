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
    /// Logika interakcji dla klasy AddClientWindow.xaml
    /// </summary>
    public partial class AddClientWindow : Window
    {
        DataTable dt = new DataTable("Klienci");
        ClientsView clientsV;
        Frame Frame;
        public AddClientWindow()
        {
            InitializeComponent();
        }
        public AddClientWindow(Frame frame, ClientsView clientsView)
        {
            InitializeComponent();
            this.Frame = frame;
            this.clientsV = clientsView;
        }
        private void Button_Click(object sender, RoutedEventArgs e)
        {
            //Klienci klienci = new Klienci();
            //klienci.Imie = imieTextBox.Text.ToString();
            //klienci.Nazwisko = nazwiskoTextBox.Text.ToString();
            //klienci.Pesel = int.Parse(peselTextBox.Text);
            //klienci.Telefon = float.Parse(telefonTextBox.Text);

            //clientsV.AddRecordToRepo(klienci);
            SqlConnection connection = new SqlConnection(Properties.Settings.Default.HotelConnectionString);
            try
            {
                connection.Open();
                string query = "insert into Klienci (imie, nazwisko, pesel, telefon, id_zaplaty) values('" + this.imieTextBox.Text +"','"+this.nazwiskoTextBox.Text+"','"+this.peselTextBox.Text+"','"+this.telefonTextBox.Text+"','"+this.sposob_zaplaty_TextBox.Text+"')";
                SqlCommand createCommand = new SqlCommand(query, connection);
                createCommand.ExecuteNonQuery();
                MessageBox.Show("Klient został Dodany");
                connection.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Message", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }
    }
}
