using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WpfApp1
{
    public class Mecz
    {
        static int generatorId = 0;
        public Drużyna Drużyna1 { get; private set; }
        public Drużyna Drużyna2 { get; private set; }
        public Sędzia SędziaGłówny { get; private set; }
        public string wynik { get; set; }
        public int Id { get; private set; }
        protected bool Rozegrany = false;


    }
}

