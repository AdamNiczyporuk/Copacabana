using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WpfApp1
{
    public class WynikDrużyny
    {
        public int IdDrużyny { get; private set; }
        public string NazwaDrużyny { get; private set; }
        public int Wygrane { get; private set; }
        public int Porazki { get; private set; }
        public int Remisy { get; private set; }

    }
    public class TabelaWyników
    {
        public List<WynikDrużyny> Wyniki { get; private set; }
    }
}
