using System;
using System.Collections.Generic;
using System.Data.Entity.Migrations;
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

namespace HelpAct
{
    /// <summary>
    /// Логика взаимодействия для formUserSupportAddUser.xaml
    /// </summary>
    public partial class formUserSupportAddUser : Window
    {
        int id_Offise;
        int id_Cabinet;
        int id_Workplase;
        int id_role;
        string messege;

        public formUserSupportAddUser()
        {
            InitializeComponent();
        }

        private void bt_close_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void cb_offices_Loaded(object sender, RoutedEventArgs e)
        {
            cb_offices.ItemsSource = Connect.DataBase.Offices.ToList().Select(tb => tb.Adress_office).ToList();
        }

        private void cb_offices_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if((sender as ComboBox).Text != "")
            {
                (sender as ComboBox).Text = "";
            }

            id_Offise = convert.adresOfficeToID(Convert.ToString((sender as ComboBox).SelectedItem));

            if (id_Offise != 0)
            {
                List<String> list = Connect.DataBase.Office_rooms.ToList().Where(tb => tb.ID_office == id_Offise).OrderBy(tb => tb.Cabinet_office).Select(tb => tb.Cabinet_office).ToList();
                if (list.Count > 0)
                {
                    cb_workplace.IsEnabled = true;
                    sourseComboBox("cb_workplace", list);
                }
                else
                {
                    MessageBox.Show("Возникла ошибка: не найдены комнаты");
                    (sender as ComboBox).Text = "";
                }
            }
            else
            {
                MessageBox.Show("Возникла ошибка");
            }

        }

        private void cb_workplace_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if ((sender as ComboBox).Text != "")
            {
                (sender as ComboBox).Text = "";
            }
            id_Cabinet = convert.cabinetToID(Convert.ToString((sender as ComboBox).SelectedItem), id_Offise);

            if (id_Cabinet != 0)
            {
                List<String> list = Connect.DataBase.Workplace.ToList().Where(tb => tb.ID_user == null && tb.ID_office_room == id_Cabinet).OrderBy(tb => tb.Number_workplace).Select(tb => tb.Number_workplace).ToList();

                if (list.Count > 0)
                {
                    cb_work.IsEnabled = true;
                    sourseComboBox("cb_work", list);
                }
                else
                {
                    MessageBox.Show("Возникла ошибка: не найдены рабочие места");
                    (sender as ComboBox).Text = "";
                }
            }
            else
            {
                MessageBox.Show("Возникла ошибка");
            }
        }

        private void cb_work_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            id_Workplase = convert.workplaceToID(Convert.ToString((sender as ComboBox).SelectedItem), id_Cabinet);
        }

        private void sourseComboBox(string nameCB, List<string> list)
        {
            ComboBox box = (ComboBox)this.FindName(nameCB);

            if (box != null)
            {
                if (box.Items.Count > 0)
                {
                    box.Items.Clear();
                    box.ItemsSource = null;
                }

                box.ItemsSource = list;
            }

        }
        private void cb_roles_Loaded(object sender, RoutedEventArgs e)
        {
            cb_roles.ItemsSource = Connect.DataBase.Roles.ToList().Select(tb => tb.Name_role).ToList();
        }

        private void bt_add_Click(object sender, RoutedEventArgs e)
        {
            if(check())
            {
                //новый пользователь
                Users newUser = new Users()
                {
                    ID_user = 1,
                    Surname = tbx_Surname.Text,
                    Name = tbx_Name.Text,
                    Patronymic = tbx_Patronymic.Text,
                    Birthday = Convert.ToDateTime(dp_DB.Text),
                    Email = txt_email.Text,
                    Phone = txt_phone.Text
                };

                Connect.DataBase.Users.Add(newUser);
                Connect.DataBase.SaveChanges();
                Connect.DataBase = new Entities();

                int id_User = convert.userToIdUser(newUser);
                int id_Role =convert.roleToID(cb_roles.Text);
                string _Login = checkRegestration.newLogin(newUser);

                //Аккаунт для пользователя
                Data_users newData_User = new Data_users()
                {
                    id_data_user = 1,
                    Login = _Login,
                    Password = "",
                    ID_role_user = id_Role,
                    ID_user = id_User
                };
                Connect.DataBase.Data_users.Add(newData_User);

                //Рабочее место
                Workplace newWorkplace = new Workplace()
                {
                    ID_workplace = id_Workplase,
                    ID_office_room = id_Cabinet,
                    ID_user = id_User,
                    Number_workplace = cb_work.Text
                };
                Connect.DataBase.Workplace.AddOrUpdate(newWorkplace);

                //применение изменений
                Connect.DataBase.SaveChanges();
                Connect.DataBase = new Entities();
                //код для отправки заявки на технику


                MessageBox.Show($"Данные для входа нового пользователя\n\nЛогин: {newData_User.Login}\nПароль: {newData_User.Password}");
            }
            else
            {
                MessageBox.Show(messege.ToString());
            }
        }

        private bool check()
        {
            bool flag = true;
            messege = "При регестрации возникли следующие ошибки:\n\n";

            
            if (!checkRegestration.check_Name(tbx_Surname.Text))
            {
                messege += "- Некорректно введенна ФАМИЛИЯ\n";
                flag = false;
            }
            if (!checkRegestration.check_Name(tbx_Name.Text))
            {
                messege += "- Некорректно введенно ИМЯ\n";
                flag = false;
            }
            if (!checkRegestration.check_Name(tbx_Patronymic.Text))
            {
                messege += "- Некорректно введенно ОТЧЕСТВО\n";
                flag = false;
            }
            if(!checkRegestration.check_Age(dp_DB.Text))
            {
                messege += "- Некорректно введенна ДАТА РОЖДЕНИЯ\n";
                flag = false;
            }
            if (!checkRegestration.check_NumberPhone(txt_phone.Text))
            {
                messege += "- Некорректно введенна ТЕЛЕФОН\n";
                flag = false;
            }
            if (!checkRegestration.check_Email(txt_email.Text))
            {
                messege += "- Некорректно введенна ПОЧТА\n";
                flag = false;
            }

            return flag;
        }
    }
}
