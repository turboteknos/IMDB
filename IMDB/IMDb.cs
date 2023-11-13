using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IMDB
{
    static class IMDb
    {
        static List<Filmek> film = new();
        public static void Feladatok()
        {
            FajlBeolvas("imdb_filmek.csv");
            FeladatKiir(1,film.Count.ToString()+"db film található");
            FeladatKiir(2,"Adja meg a rendező nevét:");
            string rendezo = Console.ReadLine();
            Feladat2(rendezo);
            FeladatKiir(3, $"{Feladat3()}");
           
         
            FeladatKiir(4, $"Ennyi időt kéne eltölteni Christopher Nolan filmek nézésével: {Feladat4()}");
            FeladatKiir(5, "A legjobb 1000-ben lévő akció film:");
            Feladat5();
            FeladatKiir(6, "Add meg a műfajt:");
            string mufaj = Console.ReadLine();
            Feladat6(mufaj);
            
        }

        

        static void FajlBeolvas(string fajlnev)
        {

            var sor = File.ReadLines(fajlnev).Skip(1);
            foreach( var f in sor)
            {
                film.Add(new Filmek(f));
            }
        }
        //static void FajlBeolvas2(string fajlnev)
        //{
        //    FileStream fajl=new FileStream(fajlnev,FileMode.Open);
        //    StreamReader sr = new StreamReader(fajl, Encoding.UTF8 );
        //    sr.ReadLine();
        //    while (!sr.EndOfStream)
        //    {
        //        film.Add(new Filmek(sr.ReadLine()));
        //    }

        //}


        static void FeladatKiir(byte fszam, string szoveg="")
        {
            Console.ForegroundColor = ConsoleColor.Green;
            Console.Write($"{fszam}. Feladat:");
            Console.ResetColor();

            Console.WriteLine(szoveg);

        }

        static void Feladat2(string rendezo)
        {
            var r = film.Where(x => x.Rendezo == rendezo).Select(x => new { x.Cim, x.Ev });
            foreach (var i in r)
            {
                Console.WriteLine($"{i.Cim} ({i.Ev})");
            }
        }
        static string Feladat3()
        {
            var westernLegjobb=film.Where(film => film.KeresMufaj("Western") == "Western").OrderByDescending(film => film.Ertekeles).First();

            return($"3. Feladat: A legjobb Western film: {westernLegjobb.Cim}");
        }

        static string Feladat4()
        {
            //HH:MM
            var osszIdo = film.Where(film => film.Rendezo == "Christopher Nolan").Sum(film => film.Hossz);
            return $"{osszIdo/60}:{osszIdo%60}";

        }

        static void Feladat5()
        {
            
            var akcio = film.Where(film => film.KeresMufaj("Action") == "Action").OrderByDescending(film=>film.Ertekeles).Take(1000);

            foreach (var i in akcio)
            {
                Console.WriteLine($"{i.Cim} ({i.Ertekeles})");
            }
            Console.WriteLine($"Darabszám: {akcio.Count()}");

        }

        static void Feladat6(string mufaj)
        {
            var toplista = film.Where(film => film.KeresMufaj(mufaj) == mufaj).Select(x=> new {x.Cim, x.Rendezo,x.Ev,x.Ertekeles}).OrderByDescending(film => film.Ertekeles);
            foreach (var i in toplista)
            {
                Console.WriteLine($"{i.Cim} ({i.Rendezo}), {i.Ev}, {i.Ertekeles}");
            }
        }
    }
}
