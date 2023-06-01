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
    internal class Turniej
    {
        private string Nazwa;
        protected Mecz półfinał1 { get; private set; }
        protected Mecz półfinał2 { get; private set; }
        protected Mecz finał { get; private set; }
        protected List<Mecz> mecze { get; private set; }
        // Nie potrzebne
        //protected static int Id = 0;


        protected List<Drużyna> drużyny { get; private set; }
        //Wyjebać Generuj ID z Turnieju na UML
        public Turniej(string nazwa)
        {
            Nazwa = nazwa;
        }
        public Mecz GetMecz(int id)
        {
            return mecze.Find(mecz => mecz.Id == id);

        }

        public int CzyWszytskieRozegrane()
        {
            bool czyRozegrane = mecze.All(mecz => mecz.CzyZakończony());
            if (czyRozegrane) { return 1; }// wszytskie rozegrane
            else { return 0; }//Nie wszytskei rozegrane 

        }
        public void GenerujPółfinały()
        {
            if (CzyWszytskieRozegrane() == 1)
            {
                TabelaWyników tabela = new TabelaWyników();
                List<WynikDrużyny> wyniki = tabela.Wyniki;
                wyniki.Sort();
                wyniki.Reverse();
                int IDdrużyna1 = wyniki[0].IdDrużyny;
                int IDdrużyna2 = wyniki[1].IdDrużyny;
                int IDdrużyna3 = wyniki[2].IdDrużyny;
                int IDdrużyna4 = wyniki[3].IdDrużyny;
                Drużyna drużyna1 = drużyny.Find(drużyna => drużyna.Id == IDdrużyna1);
                Drużyna drużyna2 = drużyny.Find(drużyna => drużyna.Id == IDdrużyna2);
                Drużyna drużyna3 = drużyny.Find(drużyna => drużyna.Id == IDdrużyna3);
                Drużyna drużyna4 = drużyny.Find(drużyna => drużyna.Id == IDdrużyna4);
                RejestrSędziów rejestsędziów = new RejestrSędziów();
                List<Sędzia> sędziowie = rejestsędziów.GetListaSędziów();
                Random random = new Random();
                int losowyIndex = random.Next(sędziowie.Count);
                Sędzia sędzia1 = sędziowie[losowyIndex];
                Sędzia sędzia2 = sędziowie[losowyIndex];


                półfinał1 = new Mecz(drużyna1, drużyna3, sędzia1);
                półfinał2 = new Mecz(drużyna2, drużyna4, sędzia2);



            }
            else
            { return; }// W Wpf trzeba dodac komunikat ze nie wszytskie mecze zostały rozegrane       


        }
        public void GenerujFinały()
        {
            if (CzyWszytskieRozegrane() == 1)
            {
                TabelaWyników tabela = new TabelaWyników();
                List<WynikDrużyny> wyniki = tabela.Wyniki;
                wyniki.Sort();
                wyniki.Reverse();
                int IDdrużyna1 = wyniki[0].IdDrużyny;
                int IDdrużyna2 = wyniki[1].IdDrużyny;

                Drużyna drużyna1 = drużyny.Find(drużyna => drużyna.Id == IDdrużyna1);
                Drużyna drużyna2 = drużyny.Find(drużyna => drużyna.Id == IDdrużyna2);

                RejestrSędziów rejestsędziów = new RejestrSędziów();
                List<Sędzia> sędziowie = rejestsędziów.GetListaSędziów();
                Random random = new Random();
                int losowyIndex = random.Next(sędziowie.Count);
                Sędzia sędzia = sędziowie[losowyIndex];



                finał = new Mecz(drużyna1, drużyna2, sędzia);


            }
        }
        public void GenerujRozgrywki()
        {
            RejestrDrużyn tabeladrużyn = new RejestrDrużyn();
            List<Drużyna> drużyny = tabeladrużyn.GetListaDrużyn();
            RejestrSędziów rejestsędziów = new RejestrSędziów();
            List<Sędzia> sędziowie = rejestsędziów.GetListaSędziów();
            Random random = new Random();
            int losowyIndex = random.Next(sędziowie.Count);



            for (int i = 0; i < drużyny.Count - 1; i++)
            {
                for (int j = 1; j < drużyny.Count; j++)
                {
                    Sędzia sędzia = sędziowie[losowyIndex];
                    mecze.Add(new Mecz(drużyny[i], drużyny[j], sędzia));
                }

            }
        }
        public void UstawWynikiMeczu(int id)
        {
            Mecz szukany = GetMecz(id);
            //szukany.Wynik // nie wiem jak to settować
    }


    }
}
