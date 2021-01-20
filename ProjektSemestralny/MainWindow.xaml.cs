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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace ProjektSemestralny
{
    /// <summary>
    /// Logika interakcji dla klasy MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {

            ProjektSemestralny.HotelDataSet hotelDataSet = ((ProjektSemestralny.HotelDataSet)(this.FindResource("hotelDataSet")));
            // Załaduj dane do tabeli Klienci. Możesz modyfikować ten kod w razie potrzeby.
            ProjektSemestralny.HotelDataSetTableAdapters.KlienciTableAdapter hotelDataSetKlienciTableAdapter = new ProjektSemestralny.HotelDataSetTableAdapters.KlienciTableAdapter();
            hotelDataSetKlienciTableAdapter.Fill(hotelDataSet.Klienci);
            System.Windows.Data.CollectionViewSource klienciViewSource = ((System.Windows.Data.CollectionViewSource)(this.FindResource("klienciViewSource")));
            klienciViewSource.View.MoveCurrentToFirst();
        }
    }
}
