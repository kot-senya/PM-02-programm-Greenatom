using System;
using System.Collections.Generic;
using System.Data.Entity.Migrations;
using System.Linq;
using System.Runtime.Remoting.Messaging;
using System.Security.Policy;
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

namespace HelpAct.pages
{
    /// <summary>
    /// Логика взаимодействия для ChangeProfile.xaml
    /// </summary>
    public partial class ChangeProfile : Page
    {
        Users meme;
        string role;
        int idRole;
        string messege;
        public ChangeProfile(Users user, string role)
        {
            meme = user;
            this.role = role;
            idRole = convert.roleToID(role);
            InitializeComponent();
            initData();
        }

        private void initData()
        {
            txt_Surname.Text = meme.Surname;
            txt_Name.Text = meme.Name;
            txt_Patronymic.Text = meme.Patronymic;
            txt_Email.Text = meme.Email;
            txt_Phone.Text = meme.Phone;

            Data_users data = Connect.DataBase.Data_users.ToList().Where(tb => tb.ID_user == meme.ID_user && tb.ID_role_user == idRole).ToList()[0];

            txt_Login.Text = data.Login;
            pbox_Pass.Password = data.Password;
            pbox_rePass.Password = data.Password;
        }
        private void btn_change_Click(object sender, RoutedEventArgs e)
        {
            if (checkData())
            {
                Users user = new Users()
                {
                    ID_user = meme.ID_user,
                    Surname = txt_Surname.Text,
                    Name = txt_Name.Text,
                    Patronymic = txt_Patronymic.Text,
                    Birthday = meme.Birthday,
                    Email = txt_Email.Text,
                    Phone = txt_Phone.Text
                };
                Data_users data = Connect.DataBase.Data_users.ToList().Where(tb => tb.ID_user == meme.ID_user && tb.ID_role_user == idRole).ToList()[0];
                data.Login = txt_Login.Text;
                data.Password = pbox_Pass.Password;

                Connect.DataBase.Users.AddOrUpdate(user);
                Connect.DataBase.Data_users.AddOrUpdate(data);
                Connect.DataBase.SaveChanges();
                Connect.DataBase = new Entities();

                switch (role)
                {
                    case ("Обычный пользователь"):
                        {
                            NavigationService.Navigate(new uUserMainPage(user));
                        }
                        break;
                    case ("Поддержка пользователей"):
                        {
                            NavigationService.Navigate(new uUserSapportPersonalAccount(user));
                        }
                        break;
                    case ("ИТ-актив"):
                        {
                            NavigationService.Navigate(new uITactivPersonalAccount(user));
                        }
                        break;
                    default:
                        {
                            MessageBox.Show("Возникла ошибка при входе");
                        }
                        break;
                }
            }
            else
            {
                MessageBox.Show("Возникла ошибка");
            }
        }
        private bool checkData()
        {
            bool flag = true;
            messege = "При изменении данных возникли следующие ошибки:\n\n";


            if (!checkRegestration.check_Name(txt_Surname.Text))
            {
                messege += "- Некорректно введенна ФАМИЛИЯ\n";
                flag = false;
            }
            if (!checkRegestration.check_Name(txt_Name.Text))
            {
                messege += "- Некорректно введенно ИМЯ\n";
                flag = false;
            }
            if (!checkRegestration.check_Name(txt_Patronymic.Text))
            {
                messege += "- Некорректно введенно ОТЧЕСТВО\n";
                flag = false;
            }
            if (!checkRegestration.check_Email(txt_Email.Text))
            {
                messege += "- Некорректно введенна ПОЧТА\n";
                flag = false;
            }
            if (!checkRegestration.check_Login(txt_Login.Text))
            {
                messege += "- Некорректно введенн ЛОГИН\n";
                flag = false;
            }
            if (pbox_Pass.Password != pbox_rePass.Password)
            {
                messege += "- Некорректно введенн ПАРОЛЬ\n";
                flag = false;
            }
            return flag;
        }

        private void btn_close_Click(object sender, RoutedEventArgs e)
        {
            switch (role)
            {
                case ("Обычный пользователь"):
                    {
                        NavigationService.Navigate(new uUserMainPage(meme));
                    }
                    break;
                case ("Поддержка пользователей"):
                    {
                        NavigationService.Navigate(new uUserSapportPersonalAccount(meme));
                    }
                    break;
                case ("ИТ-актив"):
                    {
                        NavigationService.Navigate(new uITactivPersonalAccount(meme));
                    }
                    break;
                default:
                    {
                        MessageBox.Show("Возникла ошибка при входе");
                    }
                    break;
            }
        }
    }
}
