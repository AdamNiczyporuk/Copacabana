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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace WpfApp1
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        RejestrSędziów rejestrSędziów = new RejestrSędziów();
        public MainWindow()
        {
            InitializeComponent();
            Sędzia s1 = new Sędzia("Janek", "Kowalski"), s2 = new Sędzia("Zbugniew", "chuj"), s3 = new Sędzia("pies", "siurek");
            rejestrSędziów.DodajSędziego(s1);
            rejestrSędziów.DodajSędziego(s2);
            rejestrSędziów.DodajSędziego(s3);
        }
        private void ZobaczSędziów(object sender, RoutedEventArgs e)
        {
            OknoObsługiSędziów noweOkno = new OknoObsługiSędziów(rejestrSędziów);
            noweOkno.ShowDialog();
        }
    }
}
