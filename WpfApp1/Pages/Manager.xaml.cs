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
    /// Логика взаимодействия для Manager.xaml
    /// </summary>
    public partial class Manager : Window
    {
        YPMasterPolBDEntities bDMasterPolEntities = new YPMasterPolBDEntities();
        public Manager()
        {
            InitializeComponent();
            Partner.ItemsSource = bDMasterPolEntities.PartnerAndPostavchiks.ToList();
            //var partners = bDMasterPolEntities.PartnerAndPostavchik.Select(p => new
            //{
            //    p.ID,
            //    p.Name,
            //    TypeName = bDMasterPolEntities.TypePartners.Where(tp => tp.ID == p.ID_Type).Select(tp => tp.Name).FirstOrDefault(), // Получаем имя типа
            //    p.Director,
            //    p.Email,
            //    p.PhoneNumber,
            //    p.YurAdress,
            //    p.INN,
            //    p.Raiting
            //}).ToList();
            //Partner.ItemsSource = partners;
        }

        private void addPartner_Click(object sender, RoutedEventArgs e)
        {
            AddParther addPartner = new AddParther();
            addPartner.Show();
        }

        private void Partner_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            EditPartner editPartner = new EditPartner();
            PartnerAndPostavchik selectedUser = Partner.SelectedItem as PartnerAndPostavchik;
            editPartner.ID = selectedUser.ID;
            editPartner.Show();
        }

        private void application_Click(object sender, RoutedEventArgs e)
        {
            request request =new request();
            request.Show();
        }

        private void Place_Click(object sender, RoutedEventArgs e)
        {
            PlaceofImplementation placeofImplementation = new PlaceofImplementation();
            placeofImplementation.Show();
        }

        private void Product_Click(object sender, RoutedEventArgs e)
        {
            Producti product=new Producti();
            product.Show();
        }

        private void sale_Click(object sender, RoutedEventArgs e)
        {
            SaleParther sale = new SaleParther();
            sale.Show();
        }

        private void Material_Click(object sender, RoutedEventArgs e)
        {
            ReceiptOfMaterials receiptOfMaterials = new ReceiptOfMaterials();
            receiptOfMaterials.Show();

        }

        private void calculate_discount(object sender, RoutedEventArgs e)
        {
            CalculateSalePartner calculateSalePartner = new CalculateSalePartner();
            calculateSalePartner.Show();            
        }
     
    }
}
