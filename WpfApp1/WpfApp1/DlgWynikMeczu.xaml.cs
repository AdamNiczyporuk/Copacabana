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
    /// Interaction logic for DlgWynikMeczu.xaml
    /// </summary>
    public partial class DlgWynikMeczu : Window
    {
        Mecz mecz;
        Turniej turniej;
        public DlgWynikMeczu(Mecz mecz,Turniej turniej)
        {
            InitializeComponent();
            this.mecz = mecz;
            this.turniej = turniej;
        }

        private void UstawWynikMeczu(object sender, RoutedEventArgs e)
        {
            if (wynikGospodarzy.Text == "" && wynikGości.Text == "")
            {
                return;
            }
            else if (int.TryParse(wynikGospodarzy.Text, out int wynikDrużyny1)
                && int.TryParse(wynikGości.Text, out int wynikDrużyny2))
            {
                turniej.UstawWynikiMeczu(mecz.Id, wynikDrużyny1, wynikDrużyny2);
                Close();
            }
            else
            {
                message.Text = "Zły format wyniku...";
                return;
            }
        }
    }
}
