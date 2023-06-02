using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WpfApp1
{
    public class Rozgrywki
    {
        public Turniej TurniejSiatkówki { get; private set; }
        public Turniej TurniejDwaOgnie { get; private set; }
        public Turniej TurniejPrzeciąganieLiny { get; private set; }
        public RejestrSędziów Sędziowie {get; private set;}
        public RejestrDrużyn DrużynySiatkówka { get; private set;}
        public RejestrDrużyn DrużynyDwaOgnie { get; private set;}
        public RejestrDrużyn DrużynyPrzeciąganieLiny { get; private set;}
        public Rozgrywki()
        {
            Sędziowie = new RejestrSędziów();
            DrużynySiatkówka = new RejestrDrużyn();
            DrużynyDwaOgnie = new RejestrDrużyn();
            DrużynyPrzeciąganieLiny = new RejestrDrużyn();
            
        }
        public void RozpocznijTurniejSiatkówki()
        {
            TurniejSiatkówki = new Turniej(DrużynySiatkówka);
        }
    }
}
