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
    /// Логика взаимодействия для ReceiptOfMaterials.xaml
    /// </summary>
    public partial class ReceiptOfMaterials : Window
    {
        YPMasterPolBDEntities BDMasterPolEntities =new YPMasterPolBDEntities();
        public ReceiptOfMaterials()
        {
            InitializeComponent();
        }
        private void Material_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            AddMaterial addMaterial = new AddMaterial();
            Material selectedUser = Materialii.SelectedItem as Material;
            addMaterial.ID = selectedUser.ID;
            Environment.Exit(0);
            addMaterial.Show();
        }

        private void OpenAddMaterial_Click(object sender, RoutedEventArgs e)
        {
            AddMaterial addMaterial = new AddMaterial();
            addMaterial.Show();
        }
    }
}