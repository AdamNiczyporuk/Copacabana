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
    /// Interaction logic for TurniejSiatkówka.xaml
    /// </summary>
    public partial class TurniejSiatkówka : Window
    {
        List<MeczSiatkówki> mecze;
        TabelaWyników tabelaWyników;
        public TurniejSiatkówka()
        {
            InitializeComponent();
            ListaMeczy.ItemsSource = mecze;
            ListaWyników.ItemsSource = tabelaWyników.Wyniki;
        }
    }
}
