using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;

namespace ProjektSemestralny
{
    class ClientsView
    {
       public ObservableCollection<Klienci> kliencis { get; set; }
        private ClientsBase clientsBase { get; set; }

        public ClientsView()
        {
            clientsBase = new ClientsBase();
            kliencis = new ObservableCollection<Klienci>(clientsBase.kliencis);
            kliencis.CollectionChanged += Klienci_CollectionChanged;
        }

        public List<Klienci> searchBase(string searchQuery)
        {
            if(searchQuery =="*"||searchQuery==" ")
                throw new Exception("Warning: Symbols such as '*' or whitespace are not acceptable");
            List<Klienci> KliencList = (from tempKlienci in kliencis
                                        where tempKlienci.imie.Contains(searchQuery)
                                        select tempKlienci).ToList();
            return KliencList;
        }
        public void AddRecordToRepo(Klienci klienci)
        {
            if (klienci == null)
                throw new ArgumentNullException("Error: The argument is Null");
            kliencis.Add(klienci);
        }

        /*
         * Function: Delete Records from Collection and Database
         */
        public void DeleteRecordFromRepo(int id)
        {
            if (id < 0)
                throw new Exception("Record ID must be non-negative");

            int index = 0;
            while (index < kliencis.Count)
            {
                if (kliencis[index].id_Klienta == id)
                {
                    kliencis.RemoveAt(index);
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
            if (klienci.id_Klienta < 0)
                throw new Exception("Error: ID cannot be negative");

            int index = 0;
            while (index < kliencis.Count)
            {
                if (kliencis[index].id_Klienta == klienci.id_Klienta)
                {
                    kliencis[index] = klienci;
                    break;
                }
                index++;
            }
        }
        private void Klienci_CollectionChanged(object sender, System.Collections.Specialized.NotifyCollectionChangedEventArgs e)
        {
            if (e.Action == System.Collections.Specialized.NotifyCollectionChangedAction.Add)
            {
                int newIndex = e.NewStartingIndex;
               // clientsBase.addNewRecord(kliencis[newIndex]);
            }
            else if (e.Action == System.Collections.Specialized.NotifyCollectionChangedAction.Remove)
            {
                List<Klienci> tempListOfRemovedItems = e.OldItems.OfType<Klienci>().ToList();
                //MovieRepository.DelRecord(tempListOfRemovedItems[0].Id);
            }
            else if (e.Action == System.Collections.Specialized.NotifyCollectionChangedAction.Replace)
            {
                List<Klienci> tempListOfMovies = e.NewItems.OfType<Klienci>().ToList();
               // MovieRepository.UpdateRecord(tempListOfMovies[0]);      // As the IDs are unique, only one row will be effected hence first index only
            }
        }
    }
}
