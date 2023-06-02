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
    /// Logika interakcji dla klasy OknoObsługiDrużynDwaOgnie.xaml
    /// </summary>
    public partial class OknoObsługiDrużynDwaOgnie : Window
    {

        Rozgrywki rozgrywki;
        RejestrDrużyn rejestrDrużynDwaOgnie;
        public OknoObsługiDrużynDwaOgnie(Rozgrywki rozgrywki)
        {
            InitializeComponent();
            this.rozgrywki = rozgrywki;
            rejestrDrużynDwaOgnie = rozgrywki.DrużynyDwaOgnie;
            ListaDrużyn.ItemsSource = rejestrDrużynDwaOgnie.GetListaDrużyn();
        }


        private void NowaDrużyna(object sender, RoutedEventArgs e)
        {
            if (nazwaZespołu.Text == "") return;
            string nazwa = nazwaZespołu.Text;
            DrużynaDwaOgnie nowaDrużyna = new DrużynaDwaOgnie(nazwa);
            rejestrDrużynDwaOgnie.DodajDrużyne(nowaDrużyna);
            ListaDrużyn.Items.Refresh();
            nazwaZespołu.Text = "";
        }

        private void UsuńDrużyne(object sender, RoutedEventArgs e)
        {
            if (ListaDrużyn.SelectedItem == null) return;

            DrużynaDwaOgnie usuwanaDrużyna = ListaDrużyn.SelectedItem as DrużynaDwaOgnie;
            rejestrDrużynDwaOgnie.UsuńDrużyne(usuwanaDrużyna.Id);
            ListaDrużyn.Items.Refresh();
        }
        private void Zamykanie(object sender, RoutedEventArgs e)
        {
            Close();
        }

        private void RozpocznijTurniej(object sender, RoutedEventArgs e)
        {

        }
    }
}
