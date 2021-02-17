using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjektSemestralny
{
    public class ClientsBase
    {
        public List<Klienci> klienciBase { get; set; }
        public ClientsBase()
        {
            klienciBase = GetClientsBase();
        }

        public List<Klienci> GetClientsBase()
        {
            List<Klienci> listOfClients = new List<Klienci>();
            using (SqlConnection conn = new SqlConnection(Properties.Settings.Default.HotelConnectionString))
            {
                if (conn == null)
                {
                    throw new Exception("Connection String is Null. Set the value of Connection String in ProjektSemestralny->Properties-?Settings.settings");
                }
                SqlCommand query = new SqlCommand("SELECT * from Klienci", conn);
                conn.Open();
                SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(query);
                DataTable dataTable = new DataTable();
                sqlDataAdapter.Fill(dataTable);

                foreach (DataRow row in dataTable.Rows)
                {
                    Klienci k = new Klienci();
                    k.Id_Klienta = (int)row["id_Klienta"];
                    k.Imie = row["imie"].ToString();
                    k.Nazwisko = row["nazwisko"].ToString();
                    k.Pesel = float.Parse(row["pesel"].ToString());
                    k.Telefon = float.Parse(row["telefon"].ToString());
                    k.Id_zaplaty = (int)row["id_zaplaty"];

                    listOfClients.Add(k);
                }
                return listOfClients;
            }

        }
        public List<Klienci> GetMovieRepoSearch(string searchQuery)
        {
            List<Klienci> listOfClients = new List<Klienci>();
            using (SqlConnection conn = new SqlConnection(Properties.Settings.Default.HotelConnectionString))
            {
                if (conn == null)
                {
                    throw new Exception("Connection String is Null. Set the value of Connection String in ProjektSemestralny->Properties-?Settings.settings");
                }
                SqlCommand query = new SqlCommand("retRecords", conn);
                conn.Open();
                query.CommandType = CommandType.StoredProcedure;
                SqlParameter param = new SqlParameter("TitlePhrase", SqlDbType.VarChar);
                param.Value = searchQuery;
                query.Parameters.Add(param);

                SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(query);
                DataTable dataTable = new DataTable();
                sqlDataAdapter.Fill(dataTable);

                foreach (DataRow row in dataTable.Rows)
                {
                    Klienci k = new Klienci();
                    k.Id_Klienta = (int)row["Id_klienta"];
                    k.Imie = row["Imie"].ToString();
                    k.Nazwisko = row["Nazwisko"].ToString();
                    k.Pesel = float.Parse(row["Pesel"].ToString());
                    k.Telefon = float.Parse(row["Telefon"].ToString());
                    k.Id_zaplaty = (int)row["Id_zaplaty"];
                    listOfClients.Add(k);
                }
                return listOfClients;
            }
        }
        public void addNewRecord(Klienci klienci)
        {
            using (SqlConnection conn = new SqlConnection(Properties.Settings.Default.HotelConnectionString))
            {
                if (conn == null)
                {
                    throw new Exception("Connection String is Null. Set the value of Connection String in ProjektSemestralny->Properties-?Settings.settings");
                }
                else if (klienci == null)
                    throw new Exception("The passed argument 'movieRecord' is null");

                SqlCommand query = new SqlCommand("addRecord", conn);
                conn.Open();
                query.CommandType = CommandType.StoredProcedure;
                SqlParameter param1 = new SqlParameter("pImie", SqlDbType.VarChar);
                SqlParameter param2 = new SqlParameter("pNazwisko", SqlDbType.VarChar);
                SqlParameter param3 = new SqlParameter("pPesel", SqlDbType.Float);
                SqlParameter param4 = new SqlParameter("pTelefon", SqlDbType.Float);

                param1.Value = klienci.Imie;
                param2.Value = klienci.Nazwisko;
                param3.Value = klienci.Pesel;
                param4.Value = klienci.Telefon;

                query.Parameters.Add(param1);
                query.Parameters.Add(param2);
                query.Parameters.Add(param3);
                query.Parameters.Add(param4);

                query.ExecuteNonQuery();
            }
        }
        public void DelRecord(int id)
        {
            using (SqlConnection conn = new SqlConnection(Properties.Settings.Default.HotelConnectionString))
            {
                if (conn == null)
                {
                    throw new Exception("Connection String is Null. Set the value of Connection String in ProjektSemestralny->Properties-?Settings.settings");
                }

                SqlCommand query = new SqlCommand("deleteRecord", conn);
                conn.Open();
                query.CommandType = CommandType.StoredProcedure;
                SqlParameter param1 = new SqlParameter("pId", SqlDbType.Int);
                param1.Value = id;
                query.Parameters.Add(param1);

                query.ExecuteNonQuery();
            }
        }
        public void UpdateRecord(Klienci klienci)
        {
            using (SqlConnection conn = new SqlConnection(Properties.Settings.Default.HotelConnectionString))
            {
                if (conn == null)
                {
                    throw new Exception("Connection String is Null. Set the value of Connection String in MovieCatalog->Properties-?Settings.settings");
                }

                SqlCommand query = new SqlCommand("updateRecord", conn);
                conn.Open();
                query.CommandType = CommandType.StoredProcedure;
                SqlParameter param1 = new SqlParameter("pId", SqlDbType.Int);
                SqlParameter param2 = new SqlParameter("pTitle", SqlDbType.VarChar);
                SqlParameter param3 = new SqlParameter("pReleaseYear", SqlDbType.Int);
                SqlParameter param4 = new SqlParameter("pGenre", SqlDbType.VarChar);
                SqlParameter param5 = new SqlParameter("pDuration", SqlDbType.Int);

                param1.Value = klienci.Id_Klienta;
                param2.Value = klienci.Imie;
                param3.Value = klienci.Nazwisko;
                param4.Value = klienci.Pesel;
                param5.Value = klienci.Telefon;

                query.Parameters.Add(param1);
                query.Parameters.Add(param2);
                query.Parameters.Add(param3);
                query.Parameters.Add(param4);
                query.Parameters.Add(param5);

                query.ExecuteNonQuery();
            }
        }
    }
}
