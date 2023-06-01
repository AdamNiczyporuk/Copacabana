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
    }
}
