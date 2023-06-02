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
    /// Interaction logic for OknoObsługiDrużynSiatkówki.xaml
    /// </summary>
    public partial class OknoObsługiDrużynSiatkówki : Window
    {
        RejestrDrużyn rejestrDrużynSiatkówki;
        public OknoObsługiDrużynSiatkówki(RejestrDrużyn rejestr)
        {
            InitializeComponent();
            rejestrDrużynSiatkówki = rejestr;
            ListaDrużyn.ItemsSource = rejestrDrużynSiatkówki.GetListaDrużyn();
        }

        private void NowaDrużyna(object sender, RoutedEventArgs e)
        {
            if (nazwaZespołu.Text == "") return;
            string nazwa = nazwaZespołu.Text;
            DrużynaSiatkówka nowaDrużyna = new DrużynaSiatkówka(nazwa);
            rejestrDrużynSiatkówki.DodajDrużyne(nowaDrużyna);
            ListaDrużyn.Items.Refresh();
            nazwaZespołu.Text = "";
        }

        private void UsuńDrużyne(object sender, RoutedEventArgs e)
        {
            if (ListaDrużyn.SelectedItem == null) return;

            DrużynaSiatkówka usuwanaDrużyna = ListaDrużyn.SelectedItem as DrużynaSiatkówka;
            rejestrDrużynSiatkówki.UsuńDrużyne(usuwanaDrużyna.Id);
            ListaDrużyn.Items.Refresh();
        }

        private void RozpocznijTurniej(object sender, RoutedEventArgs e)
        {
            if (rejestrDrużynSiatkówki.IlośćDrużyn() < 4)
            {
                wiadomość.Text = "Dodaj przynajmniej 4 drużyny aby przejśc do organizacji rozgrywek.";
                return;
            }
           
            wiadomość.Text = "";
            
        }
    }
}
