
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
    }
}
