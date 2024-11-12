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
    /// Логика взаимодействия для Master.xaml
    /// </summary>
    public partial class Master : Window
    {
        YPMasterPolBDEntities BDMasterPolEntities =new YPMasterPolBDEntities();
        public Master()
        {
            InitializeComponent();
            application.ItemsSource=BDMasterPolEntities.Zakazs.ToList();
        }

    

   

        private void application_SelectedCellsChanged(object sender, SelectedCellsChangedEventArgs e)
        {
            ZakazMaster zzmaster = new ZakazMaster();
            Zakaz selectedUser = application.SelectedItem as Zakaz;
            zzmaster.ID = selectedUser.ID;
            zzmaster.Show();
        }
    }
}
