using System;
using System.Collections.Generic;
using System.IO;
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
    /// Логика взаимодействия для AddProduct.xaml
    /// </summary>
    public partial class AddProduct : Window
    {
        YPMasterPolBDEntities BDMasterPolEntities=new YPMasterPolBDEntities();
        public AddProduct()
        {
            InitializeComponent();
            var ParterTypeName = BDMasterPolEntities.TypeProducts.Select(p => p.TypeProduct1).ToList();
            IDTypeProduct.ItemsSource = ParterTypeName;
        }

        private void Button_Click2(object sender, RoutedEventArgs e)
        {
            try
            {
                Product Addproduct = new Product();
                Addproduct.ID= Convert.ToInt32(IDTovar.Text);
                Addproduct.Name = Names.Text;
                var typeId = BDMasterPolEntities.TypePartners.Where(tp => tp.Name == IDTypeProduct.Text).Select(tp => tp.ID).FirstOrDefault();
                Addproduct.IDTypeProduct = typeId;
                Addproduct.Info= Info.Text;
                Addproduct.Sertificate = Sertificate.Text;
                Addproduct.NumberStandart= NumberStandart.Text;
                Addproduct.TimeIzgotov = TimeIzgotov.Text;
                Addproduct.WeightUpakov = WeiqhtUpakov.Text;
                Addproduct.Weight = Weiqht.Text;
                Addproduct.Size = Size.Text;
                Addproduct.MinPricePartner = Convert.ToInt32(MinPricePartner.Text);
                BDMasterPolEntities.Products.Add(Addproduct);
                BDMasterPolEntities.SaveChanges();
                MessageBox.Show("Успешно успешно");
                this.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
                throw;
            }
        }
    }
}
