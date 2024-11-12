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
    /// Логика взаимодействия для SaleParther.xaml
    /// </summary>
    public partial class SaleParther : Window
    {
        YPMasterPolBDEntities bDMasterPolEntities = new YPMasterPolBDEntities();
        public SaleParther()
        {
            InitializeComponent();
            SalePartheri.ItemsSource= bDMasterPolEntities.PartnerProducts.ToList();
        }

        private void sale_Click(object sender, RoutedEventArgs e)
        {
            AddSale sale = new AddSale();
            sale.Show();
        }

        private void SalePartheri_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }

        private void SalePartheri_SelectionChanged_1(object sender, SelectionChangedEventArgs e)
        {

        }
    }
}
