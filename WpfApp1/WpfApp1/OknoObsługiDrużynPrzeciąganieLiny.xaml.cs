using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace WpfApp1
{
    /// <summary>
    /// Logika interakcji dla klasy OknoObsługiDrużynPrzeciąganieLiny.xaml
    /// </summary>
    public partial class OknoObsługiDrużynPrzeciąganieLiny : Window
    {
        Rozgrywki rozgrywki;
        RejestrDrużyn rejestrDrużynPrzeciąganieLiny;
        public OknoObsługiDrużynPrzeciąganieLiny(Rozgrywki rozgrywki)
        {
            InitializeComponent();
            this.rozgrywki = rozgrywki;
            rejestrDrużynPrzeciąganieLiny = rozgrywki.DrużynyPrzeciąganieLiny;
            ListaDrużyn.ItemsSource = rejestrDrużynPrzeciąganieLiny.GetListaDrużyn();
        }

        private void NowaDrużyna(object sender, RoutedEventArgs e)
        {
            if (nazwaZespołu.Text == "") return;
            string nazwa = nazwaZespołu.Text;
            DrużynaPrzeciąganieLiny nowaDrużyna = new DrużynaPrzeciąganieLiny(nazwa);
            rejestrDrużynPrzeciąganieLiny.DodajDrużyne(nowaDrużyna);
            ListaDrużyn.Items.Refresh();
            nazwaZespołu.Text = "";
        }

        private void UsuńDrużyne(object sender, RoutedEventArgs e)
        {
            if (ListaDrużyn.SelectedItem == null) return;

            Drużyna usuwanaDrużyna = ListaDrużyn.SelectedItem as Drużyna;
            rejestrDrużynPrzeciąganieLiny.UsuńDrużyne(usuwanaDrużyna.Id);
            ListaDrużyn.Items.Refresh();
        }
        private void Zamykanie(object sender, RoutedEventArgs e)
        {
            Close();
        }
        private void RozpocznijTurniej(object sender, RoutedEventArgs e)
        {
            if (rejestrDrużynPrzeciąganieLiny.IlośćDrużyn() < 4)
            {
                wiadomość.Text = "Dodaj przynajmniej 4 drużyny aby przejśc do organizacji rozgrywek.";
                return;
            }

            wiadomość.Text = "";
            rozgrywki.RozpocznijTurniejPrzeciąganieLiny();
            TurniejPrzeciąganieLinyObsługa noweOkno = new TurniejPrzeciąganieLinyObsługa(rozgrywki);
            noweOkno.ShowDialog();
        }
    }
}
