using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WpfApp1
{
    public class WynikDrużyny
    {
        public int IdDrużyny { get; private set; }
        public string NazwaDrużyny { get; private set; }
        public int Wygrane { get;  set; }
        public int Porazki { get;  set; }
        public int Remisy { get;  set; }
        public int Punkty { get
            {
                return Wygrane*3+Remisy;
            } }
        public WynikDrużyny(Drużyna drużyna)
        {
            IdDrużyny = drużyna.Id;
            NazwaDrużyny = drużyna.Nazwa;
            Wygrane = 0;
            Porazki = 0;
            Remisy = 0;
        }
        public override string ToString()
        {
            int ilośćPotrzebnychSpacji = 25 - NazwaDrużyny.Length;
            string l=NazwaDrużyny;
            for(int i=0;i<ilośćPotrzebnychSpacji;i++)
            {
                l += " ";
            }
            l += Wygrane.ToString().PadLeft(5) + Remisy.ToString().PadLeft(5) + Porazki.ToString().PadLeft(5) + Punkty.ToString().PadLeft(5);
            //return $"{NazwaDrużyny,25} {Wygrane,5} {Remisy,5} {Porazki,5} {Punkty,5}";
           
            return l;
        }

    }
    public class TabelaWyników
    {
        public List<WynikDrużyny> Wyniki { get; private set; }
        public TabelaWyników(List<Drużyna> ListaDrużyn)
        {
            Wyniki = new List<WynikDrużyny>();
            foreach (Drużyna d in ListaDrużyn)
            {
                WynikDrużyny wynik = new WynikDrużyny(d);
                Wyniki.Add(wynik);
            }
        }
        public WynikDrużyny GetWynikDrużyny(int id)
        {
            return Wyniki.Find(w => w.IdDrużyny == id);
        }
        public void Aktualizuj(Mecz mecz)
        {
            WynikDrużyny wynikDrużyny1 = GetWynikDrużyny(mecz.Drużyna1.Id);
            WynikDrużyny wynikDrużyny2 = GetWynikDrużyny(mecz.Drużyna2.Id);
            switch (mecz.Rezultat) 
            {
                case '0':
                    break;
                case '1':
                    wynikDrużyny1.Wygrane += 1;
                    wynikDrużyny2.Porazki += 1;
                    break;
                case '2':
                    wynikDrużyny2.Wygrane += 1;
                    wynikDrużyny1.Porazki += 1;
                    break;
                case '3':
                    wynikDrużyny1.Remisy += 1;
                    wynikDrużyny2.Remisy += 1;
                    break;

            }
            Wyniki.Sort((wynikDrużyny1,wynikDrużyny2)=>wynikDrużyny1.Punkty.CompareTo(wynikDrużyny2.Punkty));
            Wyniki.Reverse();
        }
    }
}
