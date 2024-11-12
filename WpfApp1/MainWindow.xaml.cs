using System;
using System.Collections.Generic;
using System.Data.Entity;
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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace WpfApp1
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        YPMasterPolBDEntities bDMasterPolEntities = new YPMasterPolBDEntities();
        public MainWindow()
        {
            InitializeComponent();       
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            string login=textboxlogin.Text;
            string password = textboxpassword.Text;
            var user= bDMasterPolEntities.Users.Where(x=> x.Login==login&& x.Password==password).FirstOrDefault();
            try
            {
                if(textboxlogin.Text!=null|| textboxpassword.Text!=null|| user.Login == null|| user.Password == null)
                {
                    if (user.Login == login && user.Password == password)
                    {

                        Session session = new Session
                        {
                            IDUser = user.ID,
                            DateEntry = DateTime.Now,
                            DateExit = DateTime.UtcNow
                        };
                        bDMasterPolEntities.Sessions.Add(session);
                        bDMasterPolEntities.SaveChanges();
                        if (user.HeathStatus == true)
                        {
                            // Пользователь - Менеджер
                            if (user.IDRole == 2)
                            {
                                MessageBox.Show("Вы успешно авторизовались!");
                                Manager manager = new Manager();
                                manager.Show();
                            }
                            // Пользователь - Поставщик
                            if (user.IDRole == 3)
                            {
                                MessageBox.Show("Вы успешно авторизовались!!");
                                AddAplication addAplication = new AddAplication();
                                addAplication.idPartner = user.ID;
                                addAplication.Show();
                            }
                            // Пользователь - Аналитик
                            if (user.IDRole == 4)
                            {
                                MessageBox.Show("Вы успешно авторизовались!");
                                Analitik analitik = new Analitik();
                                analitik.Show();
                            }
                            // Пользователь - Мастер
                            if (user.IDRole == 5)
                            {

                                MessageBox.Show("Вы успешно авторизовались!");
                                Master master = new Master();
                                master.Show();
                            }
                            // Пользователь - Кадры
                            if (user.IDRole == 6)
                            {
                                MessageBox.Show("Вы успешно авторизовались!");
                                Users userss = new Users();
                                userss.Show();
                            }
                        }
                        else
                        {
                            MessageBox.Show("Вы не подходите по состоянию здоровья, доступ запрещен!");
                        }
                    }
                }
                else
                {
                    MessageBox.Show("Не все поля заполнены! Проверьте данные ещё раз");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
                throw;
            }
            

        }
    }
}
