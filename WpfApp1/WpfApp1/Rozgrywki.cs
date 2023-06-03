using System;
using System.Collections.Generic;
using System.Diagnostics.Eventing.Reader;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace WpfApp1
{
    public class NieZnalezionoPlikuException : Exception { }
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
        public void RozpocznijTurniejDwaOgnie()
        {
            TurniejDwaOgnie = new Turniej(DrużynyDwaOgnie);
        }
        public void RozpocznijTurniejPrzeciąganieLiny()
        {
            TurniejPrzeciąganieLiny = new Turniej(DrużynyPrzeciąganieLiny);
        }
        public void ZapiszDrużyny(RejestrDrużyn rejestrDrużyn, string nazwaPliku)
        {
            
            string sciezka = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "StanSystemu", nazwaPliku);
            string ucietyTekst = sciezka.Substring(0, sciezka.IndexOf("\\bin\\"));
            ucietyTekst += "\\StanSystemu\\"+nazwaPliku;
            string path = ucietyTekst;
            using (StreamWriter streamWriter = new StreamWriter(path))
            {
                if (streamWriter != null)
                {
                    foreach (Drużyna d in rejestrDrużyn.GetListaDrużyn())
                    {
                        streamWriter.WriteLine(d);
                    }
                }
                else
                {
                    throw new NieZnalezionoPlikuException();
                }
            }
        }
        public void WczytajDrużyny(RejestrDrużyn rejestrDrużyn, string nazwaPliku)
        {
            string sciezka = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "StanSystemu", nazwaPliku);
            string ucietyTekst = sciezka.Substring(0, sciezka.IndexOf("\\bin\\"));
            ucietyTekst += "\\StanSystemu\\" + nazwaPliku;
            string path = ucietyTekst;
            using (StreamReader streamReader = new StreamReader(path))
            {
                if (streamReader != null)
                {
                    while (streamReader.EndOfStream != true)
                    {
                        rejestrDrużyn.DodajDrużyne(new Drużyna(streamReader.ReadLine()));
                    }
                }
                else throw new NieZnalezionoPlikuException();
            }
        }
        public void ZapiszSędziów(string nazwaPliku)
        {
            string sciezka = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "StanSystemu", nazwaPliku);
            string ucietyTekst = sciezka.Substring(0, sciezka.IndexOf("\\bin\\"));
            ucietyTekst += "\\StanSystemu\\" + nazwaPliku;
            string path = ucietyTekst;
            using (StreamWriter streamWriter = new StreamWriter(path))
            { if (streamWriter != null)
                {
                    foreach (Sędzia s in Sędziowie.GetListaSędziów())
                    {
                        streamWriter.WriteLine(s.Imie);
                        streamWriter.WriteLine(s.Nazwisko);

                    }
                }
                else throw new NieZnalezionoPlikuException();
            }
        }
        public void WczytajSędziów(string nazwaPliku)
        {
            string sciezka = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "StanSystemu", nazwaPliku);
            string ucietyTekst = sciezka.Substring(0, sciezka.IndexOf("\\bin\\"));
            ucietyTekst += "\\StanSystemu\\" + nazwaPliku;
            string path = ucietyTekst;
            using (StreamReader streamReader=new StreamReader(path))
            {
                if (streamReader != null)
                {
                    while (streamReader.EndOfStream != true)
                    {
                        Sędziowie.DodajSędziego(new Sędzia(streamReader.ReadLine(), streamReader.ReadLine()));
                    }
                }
                else throw new NieZnalezionoPlikuException();
            }
        }
        public void ZapiszStan()
        {
            ZapiszDrużyny(DrużynyDwaOgnie, "DrużynyDwaOgnie.txt");
            ZapiszDrużyny(DrużynySiatkówka, "DrużynySiatkówki.txt");
            ZapiszDrużyny(DrużynyPrzeciąganieLiny, "DrużynyPrzeciąganieLiny.txt");
            ZapiszSędziów("Sędziowie.txt");
        }
        public void WczytajStan()
        {
            WczytajDrużyny(DrużynyDwaOgnie, "DrużynyDwaOgnie.txt");
            WczytajDrużyny(DrużynySiatkówka, "DrużynySiatkówki.txt");
            WczytajDrużyny(DrużynyPrzeciąganieLiny, "DrużynyPrzeciąganieLiny.txt");
            WczytajSędziów("Sędziowie.txt");
        }
    }
}
