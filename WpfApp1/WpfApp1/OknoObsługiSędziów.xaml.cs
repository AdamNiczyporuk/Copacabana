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
    /// Interaction logic for OknoObsługiSędziów.xaml
    /// </summary>
    
    public partial class OknoObsługiSędziów : Window
    {
        private Rozgrywki rozgrywki;
        public RejestrSędziów rejestrSędziów;
        public OknoObsługiSędziów(Rozgrywki rozgrywki)
        {
            InitializeComponent();
            this.rozgrywki = rozgrywki;
            rejestrSędziów = rozgrywki.Sędziowie;
            this.rejestrSędziów = rejestrSędziów;
            
            ListaSędziów.ItemsSource = rejestrSędziów.GetListaSędziów();
            
        }

        private void UsuńSędziego(object sender, RoutedEventArgs e)
        {
            
            Sędzia UsuwanySędzia = (Sędzia)ListaSędziów.SelectedItem;
            if (UsuwanySędzia != null)
            {
                rejestrSędziów.UsunSędziego(UsuwanySędzia.Id);
                ListaSędziów.Items.Refresh();
            }
            else return;
        }

        private void DodajSędziego(object sender, RoutedEventArgs e)
        {
            if(ImieNowegoSędziego.Text!=""&& NazwiskoNowegoSędziego.Text!="")
            {
                Sędzia nowySędzia = new Sędzia(ImieNowegoSędziego.Text,NazwiskoNowegoSędziego.Text);
                rejestrSędziów.DodajSędziego(nowySędzia);
                ListaSędziów .Items.Refresh();
                ImieNowegoSędziego.Text = NazwiskoNowegoSędziego.Text = "";
            }
        }
    }
}
