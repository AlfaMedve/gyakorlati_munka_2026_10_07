using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace gyakorlati_munka
{
    internal class Program
    {
        static List<Jatekok> jatek_adatok = new List<Jatekok>();

        static void Main(string[] args)
        {
            AdatBeolvas();
            //AdatKiir(); 
            //feladat1();
            //feladat2();
            //feladat3();
            //feladat4();
            //feladat5();
            //feladat6();
            //feladat7();
            //feladat8();
            //feladat9();
            //feladat10();
            //feladat11();
            //feladat12();

            Console.ReadLine();
        }
        //-------------------------------------------------------------------------------------------------------
        private static void feladat12()
        {
            Console.WriteLine("\n12. feladat");
            jatek_adatok
                .Where(x => x.Típus.ToLower() == "action")
                .OrderByDescending(x => x.Ertekeles)
                .Select(x => new { x.Nev, x.Ev, x.Ertekeles })
                .ToList()
                .ForEach(x => Console.WriteLine($"{x.Nev,-40}  {x.Ev,-10}  Értékelés: {x.Ertekeles}"));
        }
        //-------------------------------------------------------------------------------------------------------
        private static void feladat11()
        {
            Console.WriteLine("Nem ment!");
        }
        private static void feladat10()
        {
            Console.WriteLine("Nem ment!");
        }
        //-------------------------------------------------------------------------------------------------------
        private static void feladat9()
        {
            Console.WriteLine("Nem ment!");
        }
        //-------------------------------------------------------------------------------------------------------
        private static void feladat8()
        {
            Console.WriteLine("\n8. feladat");
            var legjobbPlatform = jatek_adatok
                .GroupBy(x => x.Platform)
                .Select(x => new { Platform = x.Key, Atlag = x.Average(y => y.Ertekeles) })
                .OrderByDescending(x => x.Atlag)
                .FirstOrDefault();

            if (legjobbPlatform != null)
            {
                Console.WriteLine($"A legmagasabb átlagos értékelésü platform: {legjobbPlatform.Platform} {legjobbPlatform.Atlag} pon");
            }
        }
        //-------------------------------------------------------------------------------------------------------
        private static void feladat7()
        {
            Console.WriteLine("\n7. feladat");
            double atlagErtekeles = jatek_adatok
                .Average(x => x.Ertekeles);
            Console.WriteLine($"A játékok átlagos értékelése: {atlagErtekeles} pont");
        }
        //-------------------------------------------------------------------------------------------------------
        private static void feladat6()
        {
            Console.WriteLine("\n6. feladat");

            var legnepszerubbTipus = jatek_adatok
                .GroupBy(x => x.Típus)
                .OrderByDescending(x => x.Count())
                .FirstOrDefault();

            if (legnepszerubbTipus != null)
            {
                Console.WriteLine($"A legtöbb játék  {legnepszerubbTipus.Key} típusbol van: {legnepszerubbTipus.Count()} db");
            }
        }
        //-------------------------------------------------------------------------------------------------------
        private static void feladat5()
        {
            Console.WriteLine("\n5. feladat");
            jatek_adatok
                .GroupBy(x => x.Platform)
                .ToList()
                .ForEach(w => Console.WriteLine($"{w.Key}: {w.Count()} db jatek"));
        }
        //-------------------------------------------------------------------------------------------------------
        private static void feladat4()
        {
            Console.WriteLine("\n4. feladat");
            jatek_adatok
                .OrderByDescending(x => x.Ertekeles)
                .Take(10)
                .ToList()
                .ForEach(w => Console.WriteLine($"{w.Nev,-25} - Értékelés: {w.Ertekeles}"));
        }
        //-------------------------------------------------------------------------------------------------------
        private static void feladat3()
        {
            Console.WriteLine("\n3. feladat");
            jatek_adatok
                .OrderByDescending(x => x.Ev)
                .ToList()
                .ForEach(x => Console.WriteLine($"{x.Ev,-5}: {x.Nev}"));
        }
        //-------------------------------------------------------------------------------------------------------
        private static void feladat2()
        {
            Console.WriteLine("\n2. feladat");

            jatek_adatok
                .Where(x => x.Platform.ToLower() == "nintendo switch" && x.Ev > 2015 && x.Ertekeles >= 8)
                .ToList()
                .ForEach(w => Console.WriteLine($"{w.Nev,-40} {w.Ev} - Értékelés: {w.Ertekeles}"));
        }
        //-------------------------------------------------------------------------------------------------------
        private static void feladat1()
        {
            Console.WriteLine("1. feladat");
            jatek_adatok
                .Where(x => x.Ertekeles >= 9)
                .ToList()
                .ForEach(w => Console.WriteLine($"{w.Nev,-40} - Értékelés: {w.Ertekeles}"));
        }
        //-------------------------------------------------------------------------------------------------------
        private static void AdatKiir()
        {
            foreach (var item in jatek_adatok)
            {
                Console.WriteLine(item.Nev);
            }
        }
        //-------------------------------------------------------------------------------------------------------
        private static void AdatBeolvas()
        {
            try
            {
                jatek_adatok = File.ReadAllLines("jatekok.csv")
                    .Skip(1)
                    .Select(sor => sor.Split(';'))
                    .Select(adat => new Jatekok(
                        adat[0],
                        adat[1],
                        adat[2],
                        int.Parse(adat[3]),
                        double.Parse(adat[4])
                    ))
                    .ToList();
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Hiba! : {ex.Message}");
            }
        }
        //-------------------------------------------------------------------------------------------------------
    }
}
