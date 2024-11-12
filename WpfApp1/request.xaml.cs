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
    /// Логика взаимодействия для request.xaml
    /// </summary>
    public partial class request : Window
    {
        YPMasterPolBDEntities BDMasterPolEntities =new YPMasterPolBDEntities();
        public request()
        {
            InitializeComponent();
            application.ItemsSource = BDMasterPolEntities.Zakazs.ToList();
        }

        private void Place_Click(object sender, RoutedEventArgs e)
        {
           AddAplication addAplication = new AddAplication();
           addAplication.Show();
        }
    }
}
