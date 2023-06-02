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
        public TurnieSiatkówkiObsługa(Rozgrywki rozgrywki)
        {
            InitializeComponent();
            
            
            this.rozgrywki = rozgrywki;
            mecze = rozgrywki.TurniejSiatkówki.mecze;
            tabelaWyników = rozgrywki.TurniejSiatkówki.tabelaWyników;
        }
    }
}
