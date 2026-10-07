using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace gyakorlati_munka
{
    internal class Jatekok
    {
        public Jatekok(string nev, string típus, string platform, int ev, double ertekeles)
        {
            Nev = nev;
            Típus = típus;
            Platform = platform;
            Ev = ev;
            Ertekeles = ertekeles;
        }

        //Neve;Típus;Platform;Kiadás éve;Felhasználói értékelés
        public string Nev { get; set; }
        public string Típus { get; set; }
        public string Platform { get; set; }
        public int Ev { get; set; }
        public double Ertekeles { get; set; }
    }
}
