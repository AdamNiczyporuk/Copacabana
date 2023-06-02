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
    /// Interaction logic for TurnieSiatkówkiObsługa.xaml
    /// </summary>
    public partial class TurnieSiatkówkiObsługa : Window
    {
        private Rozgrywki rozgrywki;
        private List<Mecz> mecze;
        private TabelaWyników tabelaWyników;
        private Turniej turniej;
        public TurnieSiatkówkiObsługa(Rozgrywki rozgrywki)
        {
            InitializeComponent();
            
            
            this.rozgrywki = rozgrywki;
            mecze = rozgrywki.TurniejSiatkówki.mecze;
            tabelaWyników = rozgrywki.TurniejSiatkówki.tabelaWyników;
            turniej = rozgrywki.TurniejSiatkówki;
            ListaMeczy.ItemsSource = mecze;
            
        }

        private void DodajMecz(object sender, RoutedEventArgs e)
        {
            DlgMeczSiatkówki noweOkno = new DlgMeczSiatkówki(rozgrywki, rozgrywki.DrużynySiatkówka);

            noweOkno.ShowDialog();
            
            ListaMeczy.Items.Refresh();
        }

        private void UstawWynikMeczu(object sender, RoutedEventArgs e)
        {
            if((ListaMeczy.SelectedItem as Mecz).Rezultat!='0')
            {
                return;
            }
            DlgWynikMeczu noweokno = new DlgWynikMeczu(ListaMeczy.SelectedItem as Mecz, turniej);
            noweokno.ShowDialog();
            ListaMeczy.Items.Refresh();

        }
    }
}
