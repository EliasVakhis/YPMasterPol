using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Security.Policy;
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
    /// Логика взаимодействия для AddAplication.xaml
    /// </summary>
    public partial class AddAplication : Window
    {
        YPMasterPolBDEntities BDMasterPolEntities =new YPMasterPolBDEntities();
        public ObservableCollection<ZakazProduct> zakazProductss = new ObservableCollection<ZakazProduct>();
        public int idPartner;
        private static int LastSelectionStart;
        private static string LastText;
        public AddAplication()
        {
            InitializeComponent();
            var productNames = BDMasterPolEntities.Products.Select(p => p.Name).ToList();
            Tovar.ItemsSource = productNames;
            ApplicationDataGrid.ItemsSource = zakazProductss;
        }
        private void GoToPayment(object sender, RoutedEventArgs e)
        {
            try
            {
                var applicationPartner = BDMasterPolEntities.ZakazProducts.Where(x => x.partner_id == idPartner);
                Zakaz zakaz = new Zakaz();
                zakaz.IDUser = idPartner;
                zakaz.Quantity = applicationPartner.Select(x => x.Quantity).Sum();
                zakaz.Summ = Math.Round(Convert.ToDouble(applicationPartner.Select(x => x.Summ).Sum()), 2);
                zakaz.Date = DateTime.Now;
                bool isChecked = CheckBox.IsChecked ?? false;
                zakaz.PredOpalata = isChecked;
                var zakaz1 = BDMasterPolEntities.Zakazs.Add(zakaz);
                foreach (var item in zakazProductss)
                {
                    item.IDZakaz = zakaz1.ID;
                    BDMasterPolEntities.ZakazProducts.Add(item);
                }

                BDMasterPolEntities.SaveChanges();
                zakazProductss.Clear();
                MessageBox.Show("Заказ отправлен");
            }
            catch (Exception ex)
            {
                MessageBox.Show($"{ex.Message}");
                throw;
            }

        }

        private void Add_application(object sender, RoutedEventArgs e)
        {
            try
            {
                ZakazProduct zakazProduct = new ZakazProduct();
                string comboBox = Tovar.Text;
                var idProduct = BDMasterPolEntities.Products.Where(p => p.Name == comboBox).Select(p => p.ID).FirstOrDefault();
                zakazProduct.IDProduct = idProduct;
                zakazProduct.Quantity = Convert.ToInt32(Quantity.Text);
                zakazProduct.Summ = Math.Round(float.Parse(Summ.Text), 2);
                zakazProduct.partner_id = idPartner;
                zakazProductss.Add(zakazProduct);
                MessageBox.Show("Заявка успешно добавлена");               
            }
            catch (Exception ex)
            {
                MessageBox.Show("Ошибка добавления заявки " + ex);
                throw;
            }
        }

        private void Quantity_SelectionChanged(object sender, RoutedEventArgs e)
        {
            LastSelectionStart = Quantity.SelectionStart;
            if (Quantity.Text != "")
            {
                string comboBox = Tovar.Text;
                var product =
                    BDMasterPolEntities.Products.FirstOrDefault(p => p.Name == comboBox);

                Summ.Text = (product.MinPricePartner * Convert.ToInt32(Quantity.Text)).ToString();
            }
        }

        private void Quantity_TextChanged(object sender, TextChangedEventArgs e)
        {
            if (Quantity.Text.Length > 0)
            {
                if (!Int32.TryParse(Quantity.Text, out int Int))
                {
                    Quantity.Text = LastText;
                    Quantity.SelectionStart = LastSelectionStart;
                }
                else LastText = Quantity.Text;
            }
            else LastText = "";
        }

      

        private void CancelOrder_Click(object sender, RoutedEventArgs e)
        {
            var selectedOrder = ApplicationDataGrid.SelectedItem as ZakazProduct;
            if (selectedOrder != null)
            {
                zakazProductss.Remove(selectedOrder);
            }
        }
    }
}
