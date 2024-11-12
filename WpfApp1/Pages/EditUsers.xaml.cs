using System;
using System.Collections.Generic;
using System.IO;
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
    /// Логика взаимодействия для EditUsers.xaml
    /// </summary>
    public partial class EditUsers : Window
    {
        public int ID;
        YPMasterPolBDEntities BDMasterPolEntities =new YPMasterPolBDEntities();
        public EditUsers()
        {
            InitializeComponent();
            var Role = BDMasterPolEntities.Roles.Select(p => p.Name).ToList();
            RolesComboboxUS.ItemsSource = Role;
            var Partherr = BDMasterPolEntities.PartnerAndPostavchiks.Select(p => p.Name).ToList();
            IDPartnerUS.ItemsSource = Partherr;
        }

        private void Grid_Loaded(object sender, RoutedEventArgs e)
        {
            var parther = BDMasterPolEntities.Users.Where(x => x.ID == ID).FirstOrDefault();
            FIOUS.Text = parther.FIO.ToString();
            RolesComboboxUS.SelectedItem = BDMasterPolEntities.Roles.Where(tp => tp.ID == parther.IDRole).Select(tp => tp.Name).FirstOrDefault();
            IDPartnerUS.SelectedItem = BDMasterPolEntities.PartnerAndPostavchiks.Where(tp => tp.ID == parther.ID).Select(tp => tp.Name).FirstOrDefault();
            DateUS.Text= parther.DateBrtithday.ToString();
            PassportUS.Text=parther.Passport.ToString();
            BankRecvesitUS.Text=parther.BankRecvesit.ToString();
            NumberPhoneUS.Text=parther.NumberPhone.ToString();
            EmailUS.Text=parther.Email.ToString();
            LoginUS.Text=parther.Login.ToString();
            PasswordUS.Text=parther.Password.ToString();
            FamilyUS.IsChecked= parther.Family;
            HealthUS.IsChecked = parther.HeathStatus;
            
        }

        private void SaveEditUser(object sender, RoutedEventArgs e)
        {
            try
            {
 
                    var User = BDMasterPolEntities.Users.Where(x => x.ID == ID).FirstOrDefault();
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
                    User.Family=FamilyUS.IsChecked;
                    User.HeathStatus = HealthUS.IsChecked;
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
