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
    /// Interaction logic for WitajWNaPlażyCopacabana.xaml
    /// </summary>
    public partial class WitajWNaPlażyCopacabana : Window
    {
        public WitajWNaPlażyCopacabana()
        {
            InitializeComponent();
        }

        private void OtwórzMainWindow(object sender, RoutedEventArgs e)
        {
            MainWindow mainWindow = new MainWindow();   
            mainWindow.Show();
            Close();  
        }
        private void Zamykanie(object sender, RoutedEventArgs e)
        {
            Close();
        }
        private void Opis(object sender, RoutedEventArgs e)
        {
            OpisAplikacji opisAplikacji = new OpisAplikacji();  
            opisAplikacji.Show(); 
        }
    }
}
