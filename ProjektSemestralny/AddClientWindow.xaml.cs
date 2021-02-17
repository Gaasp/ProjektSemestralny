using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace ProjektSemestralny
{
    /// <summary>
    /// Logika interakcji dla klasy AddClientWindow.xaml
    /// </summary>
    public partial class AddClientWindow : Window
    {
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
            Klienci klienci = new Klienci();
            klienci.Imie = NameTextBox.Text.ToString();
            klienci.Nazwisko = LastNameTextBox.Text.ToString();
            klienci.Pesel = int.Parse(peselTextBox.Text);
            klienci.Telefon = float.Parse(phoneTextBox.Text);

            clientsV.AddRecordToRepo(klienci);
        }
    }
}
