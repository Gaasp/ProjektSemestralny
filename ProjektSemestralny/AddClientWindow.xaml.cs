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
        public AddClientWindow()
        {
            InitializeComponent();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            Klienci klienci = new Klienci();
            klienci.imie = NameTextBox.Text.ToString();
            klienci.nazwisko = LastNameTextBox.Text.ToString();
            klienci.pesel = int.Parse(peselTextBox.Text);
            klienci.telefon = float.Parse(phoneTextBox.Text);
            
        }
    }
}
