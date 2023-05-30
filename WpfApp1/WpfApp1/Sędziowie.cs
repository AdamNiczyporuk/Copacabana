using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WpfApp1
{
    public class Sędzia
    {
        private static int generatorID = 0;
        public string Imie { get; private set; }
        public string Nazwisko { get; private set; }
        public int Id { get; private set; }
        Sędzia(string imie, string nazwisko)
        {
            Imie = imie;
            Nazwisko = nazwisko;
            Id = GenerujId();
        }
        private int GenerujId()
        {
            return generatorID++;
        }

    }
    public class RejestrSędziów
    {
        private List<Sędzia> sędziowie;
        public RejestrSędziów()
        {
            sędziowie = new List<Sędzia>();
        }
        public void DodajSędziego(Sędzia sędzia)
        {
            sędziowie.Add(sędzia);
        }
        public Sędzia GetSędzia(int id)
        {
            if (sędziowie.Any(s => s.Id == id))
            {
                return sędziowie.Find(s => s.Id == id);
            }
            return null;
        }
        public List<Sędzia> GetListaSędziów()
        {
            return sędziowie;
        }
        public void UsunSędziego(int id)
        {
            sędziowie.Remove(sędziowie.Find(s => s.Id == id));
        }
    }

}

