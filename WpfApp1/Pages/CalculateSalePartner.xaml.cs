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
    /// Логика взаимодействия для CalculateSalePartner.xaml
    /// </summary>
    public partial class CalculateSalePartner : Window
    {
        YPMasterPolBDEntities dbContext = new YPMasterPolBDEntities();
        public CalculateSalePartner()
        {
            InitializeComponent();
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {           
                var partnersWithSales = dbContext.PartnerProducts.GroupBy(pp => pp.IDPartners).Select(g => new{PartnerID = g.Key,SalesCount = g.Count()}).ToList();
                var partnersWithDiscounts = partnersWithSales.Select(p => new{PartnerID = p.PartnerID,SalesCount = p.SalesCount,Discount = CalculateDiscount(p.SalesCount)}).ToList();
                partnerDataGrid.ItemsSource = partnersWithDiscounts;           
        }
        public int CalculateDiscount(int salesCount)
        {
            if (salesCount == 1)
                return 0;
            else if (salesCount >= 3)
                return 5;
            else if (salesCount >= 5)
                return 10;
            return 0;
        }
    }
}
