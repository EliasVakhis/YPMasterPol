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
    /// Логика взаимодействия для EditPartner.xaml
    /// </summary>
    public partial class EditPartner : Window
    {
        public int ID;
        YPMasterPolBDEntities BDMasterPolEntities =new YPMasterPolBDEntities();

        public EditPartner()
        {
            InitializeComponent();
            var ParterTypeName = BDMasterPolEntities.TypePartners.Select(p => p.Name).ToList();
            Type.ItemsSource = ParterTypeName;
        
        }
        private void Button_Click(object sender, RoutedEventArgs e)
        {
            var parther = BDMasterPolEntities.PartnerAndPostavchiks.Where(x => x.ID == ID).FirstOrDefault();
            Names.Text = parther.Name.ToString();
            Type.SelectedItem = BDMasterPolEntities.TypePartners.Where(tp => tp.ID == parther.ID_Type).Select(tp => tp.Name).FirstOrDefault();
            Director.Text = parther.Director.ToString();
            Email.Text = parther.Email.ToString();
            PhoneNumber.Text = parther.PhoneNumber.ToString();
            YurAdress.Text = parther.YurAdress.ToString();
            INN.Text = parther.INN.ToString();
            Raiting.Text = parther.Raiting.ToString();

            string put = Environment.CurrentDirectory.ToString();
            put = put.Remove(put.Length - 10, 10);

            string Put = put + parther.Logotipe;
            LogotipeImg.Source = new BitmapImage(new Uri(Put));
        }

        private void Button_Click2(object sender, RoutedEventArgs e)
        {
            try
            {
                //MessageBox.Show(Type.Text);
                var parther = BDMasterPolEntities.PartnerAndPostavchiks.Where(x => x.ID == ID).FirstOrDefault();
                parther.Name = Names.Text;
                var typeId = BDMasterPolEntities.TypePartners.Where(tp => tp.Name == Type.Text).Select(tp => tp.ID).FirstOrDefault();
                parther.ID_Type = typeId; 
                parther.Director = Director.Text;
                parther.Email = Email.Text;
                parther.PhoneNumber = PhoneNumber.Text;
                parther.YurAdress = YurAdress.Text;
                parther.INN = INN.Text;
                parther.Raiting = Convert.ToInt32(Raiting.Text);
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
