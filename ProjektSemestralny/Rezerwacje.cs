using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjektSemestralny
{
    class Rezerwacje
    {
        public int Id_rezerwacji { get; set; }
        public int Id_klienta { get; set; }
        public float Data_rezerwacji { get; set; }
        public int Id_pokoju { get; set; }
    }
}
