using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IMDB
{
    internal class Filmek
    {
        public Filmek(string sor)
        {
            //helyezes;cim;mufaj;leiras;rendezo;szinesz;ev;hossz;ertekeles;szavazat
            string[] dbok = sor.Split(';');
            
            Helyezes = int.Parse(dbok[0]);
            Cim = dbok[1];
            Mufaj = dbok[2];
            Leiras = dbok[3];
            Rendezo = dbok[4];
            Szineszek = dbok[5];
            Ev = int.Parse(dbok[6]);
            Hossz = int.Parse(dbok[7]);
            Ertekeles = float.Parse(dbok[8]);
            Szavazat = int.Parse(dbok[9]);


   


        }

        public int Helyezes { get ; private set; }
        public string Cim { get ; private set; }
        public string Mufaj { get ; private set; }
        public string Leiras { get ; private set; }
        public string Rendezo { get ; private set; }
        public string Szineszek { get ; private set; }
        public int Ev { get ; private set; }
        public int Hossz { get ; private set; }
        public float Ertekeles { get ; private set; }
        public int Szavazat { get ; private set; }


        public string KeresMufaj(string mufajnev)
        {
            string[] felbontas= Mufaj.Split(',');
            foreach (var i in felbontas)
            {
                if (i == mufajnev)
                {
                    return i;
                }
            }
            return "";

            
        }
    }
}
