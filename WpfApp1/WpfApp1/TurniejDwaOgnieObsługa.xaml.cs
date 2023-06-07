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
    /// Interaction logic for TurniejDwaOgnieObsługa.xaml
    /// </summary>
    public partial class TurniejDwaOgnieObsługa : Window
    {

        private Rozgrywki rozgrywki;
        private List<Mecz> mecze;
        private TabelaWyników tabelaWyników;
        private Turniej turniej;
        private List<Mecz> półfinały = new List<Mecz>();

        public TurniejDwaOgnieObsługa(Rozgrywki rozgrywki)
        {
            InitializeComponent();
            this.rozgrywki = rozgrywki;
            mecze = rozgrywki.TurniejDwaOgnie.mecze;
            tabelaWyników = rozgrywki.TurniejDwaOgnie.tabelaWyników;
            turniej = rozgrywki.TurniejDwaOgnie;
            ListaMeczy.ItemsSource = mecze;
            ListaWyników.ItemsSource = tabelaWyników.Wyniki;
            ListaPółfinały.ItemsSource = półfinały;

        }
        private void DodajMecz(object sender, RoutedEventArgs e)
        {
            if(półfinały.Count > 0) { return; }
            DlgMecz noweOkno = new DlgMecz(rozgrywki, rozgrywki.DrużynyDwaOgnie,turniej);

            noweOkno.ShowDialog();

            ListaMeczy.Items.Refresh();
            ListaWyników.Items.Refresh();
            wynikMeczu.Visibility = Visibility.Visible;

        }
        private void UstawWynikMeczu(object sender, RoutedEventArgs e)
        {
            if (ListaMeczy.SelectedItem == null || (ListaMeczy.SelectedItem as Mecz).CzyZakończony())
            {
                return;
            }
            DlgWynikMeczu noweokno = new DlgWynikMeczu(ListaMeczy.SelectedItem as Mecz, turniej);
            noweokno.ShowDialog();
            turniej.UstawWynikiMeczu(noweokno.mecz.Id, noweokno.Wynik1, noweokno.Wynik2);
            ListaMeczy.Items.Refresh();
            ListaWyników.Items.Refresh();

        }
        private void GenerujMecze(object sender, RoutedEventArgs e)
        {
            if (półfinały.Count > 0) { return; }
            turniej.GenerujRozgrywki(rozgrywki.Sędziowie);
            ListaMeczy.Items.Refresh();
            ListaWyników.Items.Refresh();
            wynikMeczu.Visibility = Visibility.Visible;
        }
        private void GenerujPółfinały(object sender, RoutedEventArgs e)
        {
            if (turniej.CzyWszytskieRozegrane() && półfinały.Count < 2)
            {
                turniej.GenerujPółfinały(rozgrywki.Sędziowie);
                półfinały.Add(turniej.półfinał1);
                półfinały.Add(turniej.półfinał2);
                ListaPółfinały.Items.Refresh();
                wynikPófinału.Visibility = Visibility.Visible;
            }
        }

        private void GenerujFinał(object sender, RoutedEventArgs e)
        {
            if (turniej.półfinał1 != null && turniej.półfinał1.CzyZakończony() && turniej.półfinał2.CzyZakończony())
            {
                turniej.GenerujFinały(rozgrywki.Sędziowie);
                finał.Items.Add(turniej.finał);
                wynikFinału.Visibility = Visibility.Visible;
            }
        }

        private void UstawWynikPółfinału(object sender, RoutedEventArgs e)
        {
            if (ListaPółfinały.SelectedItem == null || (ListaPółfinały.SelectedItem as Mecz).CzyZakończony())
            {
                return;
            }
            DlgWynikMeczu noweokno = new DlgWynikMeczu(ListaPółfinały.SelectedItem as Mecz, turniej);
            noweokno.ShowDialog();
            turniej.UstawWynikMeczuFinałowego(noweokno.mecz, noweokno.Wynik1, noweokno.Wynik2);
            ListaPółfinały.Items.Refresh();
        }

        private void UstawWynikFinału(object sender, RoutedEventArgs e)
        {
            if (finał.SelectedItem == null || (finał.SelectedItem as Mecz).CzyZakończony())
            {
                return;
            }
            DlgWynikMeczu noweokno = new DlgWynikMeczu(finał.SelectedItem as Mecz, turniej);
            noweokno.ShowDialog();
            turniej.UstawWynikMeczuFinałowego(noweokno.mecz, noweokno.Wynik1, noweokno.Wynik2);
            finał.Items.Refresh();
            if (noweokno.Wynik1 > noweokno.Wynik2)
            {
                zwycięzca.Text = noweokno.mecz.Drużyna1.ToString();
            }
            else if (noweokno.Wynik1 < noweokno.Wynik2)
                zwycięzca.Text = noweokno.mecz.Drużyna2.ToString();
            else
            {
                zwycięzca.Text = "Remis...";
            }
        }
        private void Zamykanie(object sender, RoutedEventArgs e)
        {
            Close();
        }

        private void TextBox_TextChanged(object sender, TextChangedEventArgs e)
        {

        }
    }
}
