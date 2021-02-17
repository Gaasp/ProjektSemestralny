using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;

namespace ProjektSemestralny
{
    public class ClientsView
    {
        public ObservableCollection<Klienci> clients { get; set; }
        private ClientsBase ClientsBase { get; set; }

        public ClientsView()
        {
            ClientsBase = new ClientsBase();
            clients = new ObservableCollection<Klienci>(ClientsBase.klienciBase);
            clients.CollectionChanged += Klienci_CollectionChanged;
        }

        /*
      * Function: Search for the query string in Movies Collection
      * Saves time and resources by searching in Collection in memory
      * rather than in database
      */
        public List<Klienci> searchRepo(string searchQuery)
        {
            if (searchQuery == "*" || searchQuery == " ")
                throw new Exception("Warning: Symbols such as '*' or whitespace are not acceptable");

            List<Klienci> KlienciList =
                (from tempKlienci in clients
                 where tempKlienci.Imie.Contains(searchQuery)
                 select tempKlienci).ToList();
            return KlienciList;
        }

        /*
       * Function: Add Record to Collection and Database
       */
        public void AddRecordToRepo(Klienci klienci)
        {
            if (klienci == null)
                throw new ArgumentNullException("Error: The argument is Null");
            clients.Add(klienci);
        }

        /*
         * Function: Delete Records from Collection and Database
         */
        public void DeleteRecordFromRepo(int id)
        {
            if (id < 0)
                throw new Exception("Record ID must be non-negative");

            int index = 0;
            while (index < clients.Count)
            {
                if (clients[index].Id_Klienta == id)
                {
                    clients.RemoveAt(index);
                    break;
                }
                index++;
            }
        }

        /*
         * Function: Updates the Object in Collection
         * with refernce to the id
         */
        public void UpdateRecordInRepo(Klienci klienci)
        {
            if (klienci.Id_Klienta < 0)
                throw new Exception("Error: ID cannot be negative");

            int index = 0;
            while (index < clients.Count)
            {
                if (clients[index].Id_Klienta == klienci.Id_Klienta)
                {
                    clients[index] = klienci;
                    break;
                }
                index++;
            }
        }

        /*
       * Event Handler: Handles the CollectionChanged event of ObservableCollection
       * Updates the Database if any change is made to the Movies Collection
       * Thus removes unncecessary burden of accessing Database
       */
        private void Klienci_CollectionChanged(object sender, System.Collections.Specialized.NotifyCollectionChangedEventArgs e)
        {
            if (e.Action == System.Collections.Specialized.NotifyCollectionChangedAction.Add)
            {
                int newIndex = e.NewStartingIndex;
                ClientsBase.addNewRecord(clients[newIndex]);
            }
            else if (e.Action == System.Collections.Specialized.NotifyCollectionChangedAction.Remove)
            {
                List<Klienci> tempListOfRemovedItems = e.OldItems.OfType<Klienci>().ToList();
                ClientsBase.DelRecord(tempListOfRemovedItems[0].Id_Klienta);
                //MovieRepository.DelRecord(tempListOfRemovedItems[0].Id);
            }
            else if (e.Action == System.Collections.Specialized.NotifyCollectionChangedAction.Replace)
            {
                List<Klienci> tempListOfMovies = e.NewItems.OfType<Klienci>().ToList();
                ClientsBase.UpdateRecord(tempListOfMovies[0]);
                // MovieRepository.UpdateRecord(tempListOfMovies[0]);      // As the IDs are unique, only one row will be effected hence first index only
            }
        }
    }
}
