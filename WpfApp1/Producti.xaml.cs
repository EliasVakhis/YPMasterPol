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
    /// Логика взаимодействия для Producti.xaml
    /// </summary>
    public partial class Producti : Window
    {
        YPMasterPolBDEntities BDMasterPolEntities =new YPMasterPolBDEntities();
        public Producti()
        {
            InitializeComponent();
            ProductList.ItemsSource= BDMasterPolEntities.Products.ToList();
        }

        private void Product_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            EditProduct EditProduct = new EditProduct();
            Product Productii = ProductList.SelectedItem as Product;
            EditProduct.ID = Productii.ID;
            EditProduct.Show();
        }

        private void application_Click(object sender, RoutedEventArgs e)
        {
            AddProduct addProduct = new AddProduct();
            addProduct.Show();
        }
    }
}
