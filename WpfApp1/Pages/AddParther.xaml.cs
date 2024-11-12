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
    /// Логика взаимодействия для AddParther.xaml
    /// </summary>
    public partial class AddParther : Window
    {
        YPMasterPolBDEntities BDMasterPolEntities =new YPMasterPolBDEntities();
        public AddParther()
        {
            InitializeComponent();
            var ParterTypeName = BDMasterPolEntities.TypePartners.Select(p => p.Name).ToList();
            Type.ItemsSource = ParterTypeName;
        }

        private void Button_Click2(object sender, RoutedEventArgs e)
        {
            try
            {
                PartnerAndPostavchik partnerAndPostavchik = new PartnerAndPostavchik();
                partnerAndPostavchik.ID = Convert.ToInt32(IDPart.Text);
                partnerAndPostavchik.Name= Names.Text;
                var typeId = BDMasterPolEntities.TypePartners.Where(tp => tp.Name == Type.Text).Select(tp => tp.ID).FirstOrDefault();
                partnerAndPostavchik.ID_Type = typeId;                
                partnerAndPostavchik.Director= Director.Text;
                partnerAndPostavchik.Email = Email.Text;
                partnerAndPostavchik.PhoneNumber = PhoneNumber.Text;
                partnerAndPostavchik.YurAdress = YurAdress.Text;
                partnerAndPostavchik.INN = INN.Text;
                partnerAndPostavchik.Raiting= Convert.ToInt32(Raiting.Text);
                BDMasterPolEntities.PartnerAndPostavchiks.Add(partnerAndPostavchik);
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
