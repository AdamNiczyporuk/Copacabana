using System;
using System.Collections.Generic;
using System.Dynamic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Documents;
using System.Windows.Media.Animation;

namespace WpfApp1
{
    public class Turniej
    {
       
        public Mecz półfinał1 { get; private set; }
        public Mecz półfinał2 { get; private set; }
        public Mecz finał { get; private set; }
        public List<Mecz> mecze { get; private set; }
        // Nie potrzebne
        //protected static int Id = 0;


        public List<Drużyna> drużyny { get; private set; }
        //Wyjebać Generuj ID z Turnieju na UML
        public TabelaWyników tabelaWyników { get; private set; }
        public Turniej(RejestrDrużyn rejestrDrużyn)
        {
            mecze = new List<Mecz>();
            drużyny = rejestrDrużyn.GetListaDrużyn();
            tabelaWyników = new TabelaWyników(drużyny);
        }
        public Mecz GetMecz(int id)
        {
            return mecze.Find(mecz => mecz.Id == id);

        }

        public bool CzyWszytskieRozegrane()
        {
            bool czyRozegrane = mecze.All(mecz => mecz.CzyZakończony());
            if (czyRozegrane) { return true; }// wszytskie rozegrane
            else { return false; }//Nie wszytskei rozegrane 

        }
        public void GenerujPółfinały(RejestrSędziów rejestsędziów)
        {
            
               
               
                int IDdrużyna1 =tabelaWyników.Wyniki[0].IdDrużyny;
                int IDdrużyna2 =tabelaWyników.Wyniki[1].IdDrużyny;
                int IDdrużyna3 =tabelaWyników.Wyniki[2].IdDrużyny;
                int IDdrużyna4 =tabelaWyników.Wyniki[3].IdDrużyny;
                Drużyna drużyna1 = drużyny.Find(drużyna => drużyna.Id == IDdrużyna1);
                Drużyna drużyna2 = drużyny.Find(drużyna => drużyna.Id == IDdrużyna2);
                Drużyna drużyna3 = drużyny.Find(drużyna => drużyna.Id == IDdrużyna3);
                Drużyna drużyna4 = drużyny.Find(drużyna => drużyna.Id == IDdrużyna4);
                List<Sędzia> sędziowie = rejestsędziów.GetListaSędziów();
                Random random = new Random();
                int losowyIndex = random.Next(sędziowie.Count-1);
                Sędzia sędzia1 = sędziowie[losowyIndex];
                Sędzia sędzia2 = sędziowie[losowyIndex];


                półfinał1 = new Mecz(drużyna1, drużyna3, sędzia1);
                półfinał2 = new Mecz(drużyna2, drużyna4, sędzia2);


  


        }
        public void GenerujFinały()
        {

                
                
                int IDdrużyna1 = tabelaWyników.Wyniki [0].IdDrużyny;
                int IDdrużyna2 = tabelaWyników.Wyniki [1].IdDrużyny;

                Drużyna drużyna1 = drużyny.Find(drużyna => drużyna.Id == IDdrużyna1);
                Drużyna drużyna2 = drużyny.Find(drużyna => drużyna.Id == IDdrużyna2);

                RejestrSędziów rejestsędziów = new RejestrSędziów();
                List<Sędzia> sędziowie = rejestsędziów.GetListaSędziów();
                Random random = new Random();
                int losowyIndex = random.Next(sędziowie.Count);
                Sędzia sędzia = sędziowie[losowyIndex];

                finał = new Mecz(drużyna1, drużyna2, sędzia);


            
        }
        public void GenerujRozgrywki()
        {
            
            RejestrSędziów rejestsędziów = new RejestrSędziów();
            List<Sędzia> sędziowie = rejestsędziów.GetListaSędziów();
            Random random = new Random();
            int losowyIndex = random.Next(sędziowie.Count);



            for (int i = 0; i < drużyny.Count -1 ; i++)
            {
                for (int j = i; j < drużyny.Count; j++)
                {
                    Sędzia sędzia = sędziowie[losowyIndex];
                    mecze.Add(new Mecz(drużyny[i], drużyny[j], sędzia));
                }

            }
        }
        public void UstawWynikiMeczu(int id,int wynikDrużyny1,int wynikDrużyny2)
        {
            Mecz szukany = GetMecz(id);
            szukany.UstawWynik(wynikDrużyny1, wynikDrużyny2);
            tabelaWyników.Aktualizuj(szukany);
        }
        public void DodajMecz(Mecz mecz)
        {
            mecze.Add(mecz);
        }


    }
}
