using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjektSemestralny
{
    class Rezerwacje
    {
        public int id_rezerwacji { get; set; }
        public int id_klienta { get; set; }
        public float data_rezerwacji { get; set; }
        public int data_pokoju { get; set; }
    }
}
