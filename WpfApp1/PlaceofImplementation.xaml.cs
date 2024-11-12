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
    /// Логика взаимодействия для PlaceofImplementation.xaml
    /// </summary>
    public partial class PlaceofImplementation : Window
    {
        YPMasterPolBDEntities BDMasterPolEntities =new YPMasterPolBDEntities();
        public PlaceofImplementation()
        {
            InitializeComponent();
            Place.ItemsSource= BDMasterPolEntities.MestaSales.ToList();
        }

        private void Button_Click1(object sender, RoutedEventArgs e)
        {
            AddPlace addPlace = new AddPlace();
            addPlace.Show();
        }
    }
}
