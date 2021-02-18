
using System.Windows;
using System.Windows.Controls;


namespace ProjektSemestralny
{
    /// <summary>
    /// Logika interakcji dla klasy MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public ClientsView ClientsV { get; set; }
        public MainWindow()
        {
            InitializeComponent();
           
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {

           
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
           
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            ClientsSearchWindow clientsSearchWindow = new ClientsSearchWindow();
            clientsSearchWindow.Show(); 
        }

        private void Add_Click(object sender, RoutedEventArgs e)
        {
            AddClientWindow addClientWindow = new AddClientWindow();
            addClientWindow.Show();
        }

        private void Button_Click_2(object sender, RoutedEventArgs e)
        {
            AddPersonelWindow addPersonelWindow = new AddPersonelWindow();
            addPersonelWindow.Show();
        }

        private void Button_Click_3(object sender, RoutedEventArgs e)
        {
            PersonelSearchWindow personelSearchWindow = new PersonelSearchWindow();
            personelSearchWindow.Show();
        }

        private void Button_Click_4(object sender, RoutedEventArgs e)
        {

        }

        private void Button_Click_5(object sender, RoutedEventArgs e)
        {
            reservationWindow reservationWindow = new reservationWindow();
            reservationWindow.Show();
        }

        private void zamknij_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
    }
}
