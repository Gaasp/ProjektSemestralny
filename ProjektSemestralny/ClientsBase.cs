using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjektSemestralny
{
    class ClientsBase
    {
        public List<Klienci> kliencis { get; set; }
        public ClientsBase()
        {
            kliencis = GetClientsBase();
        }

        public List<Klienci> GetClientsBase()
        {
            List<Klienci> listOfClients = new List<Klienci>();
            using (SqlConnection conn = new SqlConnection(Properties.Settings.Default.HotelConnectionString))
            {
                if(conn == null)
                {
                    throw new Exception("Connection String is Null. Set the value of Connection String in ProjektSemestralny->Properties-?Settings.settings");
                }
                SqlCommand query = new SqlCommand("SELECT  * from Klienci", conn);
                conn.Open();
                SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(query);
                DataTable dataTable = new DataTable();
                sqlDataAdapter.Fill(dataTable);

                foreach(DataRow row in dataTable.Rows)
                {
                    Klienci k = new Klienci();
                    k.id_Klienta = (int)row["id"];
                    k.imie = row["imię"].ToString();
                    k.nazwisko = row["nazwisko"].ToString();
                    k.pesel = (float)row["pesel"];
                    k.telefon = (float)row["telefon"];
                    k.id_zaplaty = (int)row["id_zaplaty"];

                    listOfClients.Add(k);
                }
                return listOfClients;
            }
        }
    }
}
