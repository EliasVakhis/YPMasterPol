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
    /// Логика взаимодействия для AddMaterial.xaml
    /// </summary>
    public partial class AddMaterial : Window
    {
        public int ID;
        YPMasterPolBDEntities bd = new YPMasterPolBDEntities();
        public AddMaterial()
        {
            InitializeComponent();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {

        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            ListPrihod.ItemsSource = bd.UpdateStorages.ToList();
            ListMaterial.ItemsSource = bd.Materials.ToList();
        }

        private void AddPostMat_Click(object sender, RoutedEventArgs e)
        {
            Material material = ListMaterial.SelectedItem as Material;
            UpdateStorage updateStorage = new UpdateStorage();
            updateStorage.IDMaterial = material.ID;
            updateStorage.DateUpdate = DateTime.Now;
            updateStorage.Qunatity = Convert.ToInt32(QuantityUpdate.Text);
            bd.UpdateStorages.Add(updateStorage);
            bd.SaveChanges();

            ListPrihod.ItemsSource = bd.UpdateStorages.ToList();

        }
    }
}
