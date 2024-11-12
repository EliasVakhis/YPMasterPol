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
using System.Windows.Media.Media3D;
using System.Windows.Shapes;

namespace WpfApp1
{
    /// <summary>
    /// Логика взаимодействия для EditProduct.xaml
    /// </summary>
    public partial class EditProduct : Window
    {
        public int ID;
        YPMasterPolBDEntities BDMasterPolEntities = new YPMasterPolBDEntities();
        public EditProduct()
        {
            InitializeComponent();
            var ProductType = BDMasterPolEntities.TypeProducts.Select(p => p.TypeProduct1).ToList();
            IDTypeProduct.ItemsSource = ProductType;
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            var product = BDMasterPolEntities.Products.Where(x => x.ID == ID).FirstOrDefault();
            Names.Text = product.Name.ToString();
            IDTypeProduct.SelectedItem = BDMasterPolEntities.TypeProducts.Where(tp => tp.ID == product.IDTypeProduct).Select(tp => tp.TypeProduct1).FirstOrDefault();
            Info.Text = product.Info.ToString();
            Sebestoim.Text = product.Sebestoim.ToString();
            MinPricePartner.Text = product.MinPricePartner.ToString();
            Size.Text = product.Size.ToString();
            Weiqht.Text = product.Weight.ToString();
            WeiqhtUpakov.Text = product.WeightUpakov.ToString();
            Sertificate.Text = product.Sertificate.ToString();
            NumberStandart.Text = product.NumberStandart.ToString();
            TimeIzgotov.Text = product.TimeIzgotov.ToString();

            //string put = Environment.CurrentDirectory.ToString();
            //put = put.Remove(put.Length - 10, 10);

            //string Put = put + product.Image;
            //LogotipeImg.Source = new BitmapImage(new Uri(Put));
        }

        private void Button_Click2(object sender, RoutedEventArgs e)
        {
            try
            {
                var product = BDMasterPolEntities.Products.Where(x => x.ID == ID).FirstOrDefault();
                product.Name = Names.Text;
                var typeId = BDMasterPolEntities.TypeProducts.Where(tp => tp.TypeProduct1 == IDTypeProduct.Text).Select(tp => tp.ID).FirstOrDefault();
                product.IDTypeProduct = typeId;
                product.Info = Info.Text;
                product.Sebestoim = Convert.ToDouble(Sebestoim.Text);
                product.MinPricePartner = Convert.ToDouble(MinPricePartner.Text);
                product.Size = Size.Text;
                product.Weight = Weiqht.Text;
                product.WeightUpakov = WeiqhtUpakov.Text;
                product.Sertificate = Sertificate.Text;
                product.NumberStandart = NumberStandart.Text;
                product.TimeIzgotov = TimeIzgotov.Text;
                BDMasterPolEntities.SaveChanges();
                MessageBox.Show("Изменения сохранены");
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
