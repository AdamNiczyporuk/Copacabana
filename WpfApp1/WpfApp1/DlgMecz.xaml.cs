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
    /// Interaction logic for DlgMecz.xaml
    /// </summary>
    public partial class DlgMecz : Window
    {
        Rozgrywki rozgrywki;
        Turniej turniej;
        public DlgMecz(Rozgrywki rozgrywki, RejestrDrużyn drużyny,Turniej turniej)
        {
            InitializeComponent();
            this.rozgrywki = rozgrywki;
            drużyna2.ItemsSource = drużyny.GetListaDrużyn();
            drużyna1.ItemsSource = drużyny.GetListaDrużyn();
            sędziaGłówny.ItemsSource = rozgrywki.Sędziowie.GetListaSędziów();
            this.turniej = turniej;
        }
        private void DodajMecz(object sender, RoutedEventArgs e)
        {
            if (drużyna1.SelectedItem != null && drużyna2.SelectedItem != null && drużyna1.SelectedItem != drużyna2.SelectedItem)
            {
                if (sędziaGłówny.SelectedItem == null )
                {

                    message.Text = "Nie wybrano sędziego...";
                    return;
                }
                else
                {

                        Sędzia główny = sędziaGłówny.SelectedItem as Sędzia;
                       
                        Drużyna druzyna1 = drużyna1.SelectedItem as Drużyna;
                        Drużyna druzyna2 = drużyna2.SelectedItem as Drużyna;
                        Mecz nowyMecz = new Mecz( druzyna1, druzyna2, główny);
                        turniej.DodajMecz(nowyMecz);

                        Close();
                }
                
               
            }
            else
            {
                message.Text = "Nie wybrano drużyn...";
                return;

            }
        }
    }
}
