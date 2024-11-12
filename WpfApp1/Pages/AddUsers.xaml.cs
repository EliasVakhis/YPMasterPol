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
    /// Логика взаимодействия для AddUsers.xaml
    /// </summary>
    public partial class AddUsers : Window
    {
        YPMasterPolBDEntities BDMasterPolEntities = new YPMasterPolBDEntities();
        public AddUsers()
        {
            InitializeComponent();
            var Role = BDMasterPolEntities.Roles.Select(p => p.Name).ToList();
            RolesComboboxUS.ItemsSource = Role;
            var Partherr = BDMasterPolEntities.PartnerAndPostavchiks.Select(p => p.Name).ToList();
            IDPartnerUS.ItemsSource = Partherr;
        }
     
 

        private void SaveEditUser(object sender, RoutedEventArgs e)
        {
            try
            {
                User User = new User();
                User.FIO = FIOUS.Text;
                var typeId = BDMasterPolEntities.PartnerAndPostavchiks.Where(tp => tp.Name == IDPartnerUS.Text).Select(tp => tp.ID).FirstOrDefault();
                User.IDPartner = typeId;
                var typeId2 = BDMasterPolEntities.Roles.Where(tp => tp.Name == RolesComboboxUS.Text).Select(tp => tp.ID).FirstOrDefault();
                User.IDPartner = typeId2;
                User.Passport = PassportUS.Text;
                User.Email = EmailUS.Text;
                User.BankRecvesit = BankRecvesitUS.Text;
                User.Login = LoginUS.Text;
                User.Password = PasswordUS.Text;
                User.NumberPhone = NumberPhoneUS.Text;
                User.Family = FamilyUS.IsChecked;
                User.HeathStatus = HealthUS.IsChecked;
                BDMasterPolEntities.Users.Add(User);
                BDMasterPolEntities.SaveChanges();
                MessageBox.Show("Изменения сохранены");
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
