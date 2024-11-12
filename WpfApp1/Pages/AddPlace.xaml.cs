using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.Remoting.Contexts;
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
    /// Логика взаимодействия для AddPlace.xaml
    /// </summary>
    public partial class AddPlace : Window
    {
        YPMasterPolBDEntities BDMasterPolEntities =new YPMasterPolBDEntities();
        public AddPlace()
        {
            InitializeComponent();
            var TypeSale = BDMasterPolEntities.TypeMestaSales.Select(p => p.Name).ToList();
            Type.ItemsSource = TypeSale;

        }

        private void Button_Click1(object sender, RoutedEventArgs e)
        {
            try
            {
                MestaSale mestaSale = new MestaSale();
                //mestaSale.ID=Convert.ToInt32(IDPlace.Text);
                mestaSale.Name=Namess.Text;
                var typeId = BDMasterPolEntities.TypeMestaSales.Where(tp => tp.Name == Type.Text).Select(tp => tp.ID).FirstOrDefault();
                mestaSale.IDTypeMestaSale = typeId;


                BDMasterPolEntities.MestaSales.Add(mestaSale);
                BDMasterPolEntities.SaveChanges();
                MessageBox.Show("Создано успешно!");
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
