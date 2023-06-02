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
            return $"{NazwaDrużyny,-15} {Wygrane,-3} {Remisy,-3} {Porazki,-3} {Punkty,-3}";
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
            switch (mecz.Wynik) 
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
