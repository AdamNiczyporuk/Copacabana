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
    /// Interaction logic for DlgMeczSiatkówki.xaml
    /// </summary>
    
    public partial class DlgMeczSiatkówki : Window
    {
        Rozgrywki rozgrywki;
        public DlgMeczSiatkówki(Rozgrywki rozgrywki, RejestrDrużyn drużyny)
        {
            
            InitializeComponent();
            this.rozgrywki=rozgrywki;
            drużyna2.ItemsSource = drużyny.GetListaDrużyn();
            drużyna1.ItemsSource = drużyny.GetListaDrużyn();
            sędziaGłówny.ItemsSource = rozgrywki.Sędziowie.GetListaSędziów();
            sędziaPomocniczy1.ItemsSource = rozgrywki.Sędziowie.GetListaSędziów();
            sędziaPomocniczy2.ItemsSource = rozgrywki.Sędziowie.GetListaSędziów();

        }

        private void DodajMecz(object sender, RoutedEventArgs e)
        {
            if(drużyna1.SelectedItem!=null && drużyna2.SelectedItem!=null && drużyna1.SelectedItem!=drużyna2.SelectedItem)
            {
                if(sędziaGłówny.SelectedItem!=null && sędziaPomocniczy1.SelectedItem!= null && sędziaPomocniczy2.SelectedItem != null)
                {
                    if(sędziaPomocniczy1.SelectedItem == sędziaPomocniczy2.SelectedItem || sędziaGłówny.SelectedItem == sędziaPomocniczy1.SelectedItem
                        || sędziaPomocniczy2.SelectedItem == sędziaGłówny.SelectedItem)
                    {
                        message.Text = "Ustaw różnych sędziów...";
                        return;
                    }
                    else
                    {
                        
                        Sędzia główny = sędziaGłówny.SelectedItem as Sędzia;
                        Sędzia pomocniczy1 = sędziaPomocniczy1.SelectedItem as Sędzia;
                        Sędzia pomocniczy2 = sędziaPomocniczy2.SelectedItem as Sędzia;
                        Drużyna druzyna1 = drużyna1.SelectedItem as Drużyna;
                        Drużyna druzyna2 = drużyna2.SelectedItem as Drużyna;
                        MeczSiatkówki nowyMecz = new MeczSiatkówki(pomocniczy1, pomocniczy2, druzyna1, druzyna2, główny);
                        rozgrywki.TurniejSiatkówki.DodajMecz(nowyMecz);
                        
                        Close();
                    }
                }
                else
                {
                    message.Text = "Nie wybrano wszytkich sędziów...";
                    return;
                }
            }else
            { 
                message.Text = "Nie wybrano drużyn...";
                return;

            }
        }
    }
}
