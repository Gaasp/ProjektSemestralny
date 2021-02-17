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
            gridTable.DataContext = ClientsV.searchRepo(searchBox.Text);
           // gridTable.Columns[0].Visibility = Visibility.Hidden;        // Hides the first column i.e. ID

            if (gridTable.SelectedCells.Count == 0)         // Disanle the Edit and Delete Button if no row selected
            {
                EditBtn.IsEnabled = false;
                DelBtn.IsEnabled = false;
            }
            else
            {
                EditBtn.IsEnabled = true;
                DelBtn.IsEnabled = true;
            }
        }

        private void searchButton_Click(object sender, RoutedEventArgs e)
        {
            if (searchBox.Text == "")
            {
                // WarningSearchLabel.Visibility = Visibility.Visible;
                return;
            }

            // WarningSearchLabel.Visibility = Visibility.Hidden;
            gridTable.DataContext = ClientsV.searchRepo(searchBox.Text);
            gridTable.Columns[0].Visibility = Visibility.Hidden;
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
    }
}
