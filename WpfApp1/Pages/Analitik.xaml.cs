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
    /// Логика взаимодействия для Analitik.xaml
    /// </summary>
    public partial class Analitik : Window
    {
        YPMasterPolBDEntities bDMasterPolEntities =new YPMasterPolBDEntities();
        public Analitik()
        {
            InitializeComponent();
            SalePartheri.ItemsSource = bDMasterPolEntities.PartnerProducts.ToList();
            application.ItemsSource = bDMasterPolEntities.Zakazs.ToList();
            ProductList.ItemsSource = bDMasterPolEntities.Products.ToList();
            Place.ItemsSource = bDMasterPolEntities.MestaSales.ToList();
            Partner.ItemsSource = bDMasterPolEntities.PartnerAndPostavchiks.ToList();
            ListPrihod.ItemsSource = bDMasterPolEntities.UpdateStorages.ToList();
            Materialii.ItemsSource=bDMasterPolEntities.Materials.ToList();
            Userii.ItemsSource = bDMasterPolEntities.Users.ToList();
        }

        private void period_Click(object sender, RoutedEventArgs e)
        {
            var startDate = StartDate.SelectedDate; 
            var endDate = EndDate.SelectedDate;
            SalePartheri.ItemsSource = bDMasterPolEntities.PartnerProducts.Where(pp => pp.DateSale >= startDate && pp.DateSale <= endDate).ToList();
        }

        private void TextBox_TextChanged(object sender, TextChangedEventArgs e)
        {
            var FIO= FioTextBox.Text;
            Userii.ItemsSource=bDMasterPolEntities.Users.Where(x=>x.FIO==FIO).ToList();
        }
    }
}
