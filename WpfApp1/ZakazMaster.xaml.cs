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
    /// Логика взаимодействия для ZakazMaster.xaml
    /// </summary>
    public partial class ZakazMaster : Window
    {
        public int ID;
        YPMasterPolBDEntities BDMasterPolEntities =new YPMasterPolBDEntities();
        public ZakazMaster()
        {
            InitializeComponent();
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            var ZakazMaterial = BDMasterPolEntities.ZakazProducts.Where(x => x.ID == ID).FirstOrDefault();
            MaterialName.Text=ZakazMaterial.Product.Name;
            QuantityMaterial.Text=ZakazMaterial.Quantity.ToString();
            var Material=BDMasterPolEntities.Materials.Where(x=>x.Name== ZakazMaterial.Product.Name).FirstOrDefault();
           
            if(Material!=null)
            {
                QuantityStorage.Text = Material.QunatityStorage.ToString();
                if (ZakazMaterial.Quantity > Material.QunatityStorage)
                {
                    ButtZakaz.Visibility = Visibility.Hidden;
                    ZakazAdd.Visibility = Visibility.Hidden;
                }
                else
                {
                    ZakazAdd.Text = Convert.ToString(-1 * (ZakazMaterial.Quantity - Material.QunatityStorage));
                }
            }
            else
            {
                MessageBox.Show("Материала не существует!");
                this.Close();
            }
           

        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            MessageBox.Show("Материал заказан!");
        }
    }
}
