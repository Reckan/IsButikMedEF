using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataClass
{
    public class Bestilling
    {
        public int Id { get; set; }
        public int Antal { get; set; }
        public Vare Vare { get; set; }
        public string Bemærkninger { get; set; }
    }
}
