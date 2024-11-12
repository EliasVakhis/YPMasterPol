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
    /// Логика взаимодействия для AddSale.xaml
    /// </summary>
    public partial class AddSale : Window
    {
        YPMasterPolBDEntities BDMasterPolEntities =new YPMasterPolBDEntities();
        public AddSale()
        {
            InitializeComponent();
            var Producti = BDMasterPolEntities.Products.Select(p => p.Name).ToList();
            IDProduct.ItemsSource = Producti;
            var Partner = BDMasterPolEntities.PartnerAndPostavchiks.Select(p => p.Name).ToList();
            IDPartners.ItemsSource = Partner;
            var ParterTypeName = BDMasterPolEntities.MestaSales.Select(p => p.Name).ToList();
            IDMestaSaleeee.ItemsSource = ParterTypeName;
        }

        private void Button_Click1(object sender, RoutedEventArgs e)
        {
            try
            {
                PartnerProduct partnerproduct = new PartnerProduct();

                partnerproduct.ID = Convert.ToInt32(ID.Text);




                var typeId = BDMasterPolEntities.TypeProducts.Where(tp => tp.TypeProduct1 == IDProduct.Text).Select(tp => tp.ID).FirstOrDefault();
                partnerproduct.IDProduct = typeId;
                var part = BDMasterPolEntities.TypePartners.Where(tp => tp.Name == IDPartners.Text).Select(tp => tp.ID).FirstOrDefault();
                partnerproduct.IDPartners = part;
                partnerproduct.QunatityProduct = Convert.ToInt32(QuanatityProducti.Text);
                partnerproduct.Summ =Convert.ToDouble(Summ.Text);
                partnerproduct.DateSale = DataSaleee.SelectedDate;
                var Mesto = BDMasterPolEntities.MestaSales.Where(tp => tp.Name == IDMestaSaleeee.Text).Select(tp => tp.ID).FirstOrDefault();
                partnerproduct.IDPartners = Mesto;
                BDMasterPolEntities.PartnerProducts.Add(partnerproduct);

                BDMasterPolEntities.SaveChanges();
                MessageBox.Show("Создано успешно");
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
