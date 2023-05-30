using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WpfApp1
{
    /* Mecze w DwaOgnie oraz w PrzeciąganieLiny będą tworzone jako obiekty Mecz*/
    public class Mecz
    {
        static int generatorId = 0;
        public Drużyna Drużyna1 { get; private set; }
        public Drużyna Drużyna2 { get; private set; }
        public Sędzia SędziaGłówny { get; private set; }

        // Wynik '0' oznacza że mecz nie został jeszcze rozegrany
        // Wynik '1' oznacza że wygrała Drużyna1
        // Wynik '2' oznacza że wygrała Drużyna2
        
        public char Wynik { get;  set; }
        public int Id { get; private set; }
        
        public Mecz(Drużyna drużyna1, Drużyna drużyna2, Sędzia sędziaGłówny)
        {
            Drużyna1 = drużyna1;
            Drużyna2 = drużyna2;
            SędziaGłówny = sędziaGłówny;
            Wynik = '0';
        }
        public bool CzyZakończony()
        {
            return Wynik != '0';
        }
        


    }
    public class MeczSiatkówki : Mecz
    {
        public Sędzia SędziaPomocniczy1 { get; private set; }
        public Sędzia SędziaPomocniczy2 { get; private set; }

        public MeczSiatkówki(Sędzia sędziaPomocniczy1, Sędzia sędziaPomocniczy2,Drużyna drużyna1, Drużyna drużyna2, Sędzia sędziaGłówny)
            :base(drużyna1,drużyna2,sędziaGłówny)
        {
            SędziaPomocniczy1 = sędziaPomocniczy1;
            SędziaPomocniczy2 = sędziaPomocniczy2;
        }
    }
}

