using System;
using System.Collections.Generic;
using System.Data;
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
using System.Xml.Linq;

namespace HelpAct
{
    /// <summary>
    /// Логика взаимодействия для formUserSupportDeleteUser.xaml
    /// </summary>
    public partial class formUserSupportDeleteUser : Window
    {
        public formUserSupportDeleteUser()
        {
            InitializeComponent();
        }

        private void bt_close_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
        //загрузка данных
        private void cb_role_Loaded(object sender, RoutedEventArgs e)
        {
            List<String> s = Connect.DataBase.Roles.ToList().Select(tb => tb.Name_role).ToList();
            addValue("cb_role", s);
        }
        private void cb_user_Loaded(object sender, RoutedEventArgs e)
        {
            List<String> s = Connect.DataBase.Users.ToList().Select(tb => tb.Surname + " " + tb.Name + " " + tb.Patronymic).ToList();
            addValue("cb_user", s);
        }

        //добавление данных в combobox
        private void addValue(string name, List<String> list)
        {
            ComboBox box = (ComboBox)this.FindName(name);
            box.Items.Clear();
            box.ItemsSource = null;
            for (int i = 0; i < list.Count; i++)
            {
                box.Items.Add(list[i]);
            }
        }

        //обработка изменения роли
        private void cb_role_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            try
            {
                //выборка данных
                string name_role = (sender as ComboBox).SelectedItem as string;
                List<Roles> r = Connect.DataBase.Roles.ToList().Where(tb => tb.Name_role == name_role).ToList();
                if (r.Count > 0)
                { 
                    List<Data_users> id = Connect.DataBase.Data_users.ToList().Where(tb => tb.ID_role_user == r[0].ID_role_user).ToList();
                    List<Users> users = Connect.DataBase.Users.ToList();
                    List<String> s = new List<string>();
                    foreach (Users tb in users)
                    {
                        for (int i = 0; i < id.Count; i++)
                        {
                            if (tb.ID_user == id[i].ID_user)
                            {
                                s.Add(tb.Surname + " " + tb.Name + " " + tb.Patronymic);
                            }
                        }
                    }
                    //новые данные в комбобоксе
                    addValue("cb_user", s);
                    //очистка от старых
                    cb_user.Text = "";
                    b_info.Visibility = Visibility.Hidden;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }


        }

        //обработка изменения пользователя
        private void cb_user_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            //подстановка роли по ФИО
            if (cb_role.Text == "")
            {
                try
                {
                    string fullname = (sender as ComboBox).SelectedItem as string;
                    if (fullname != null)
                    {
                        string[] name = fullname.Split(' ');
                        List<String> s = Connect.DataBase.View_User.ToList().Where(tb => tb.Surname == name[0] && tb.Name == name[1] && tb.Patronymic == name[2]).Select(tb => tb.Name_role).ToList();
                        cb_role.Text = s[0];
                        cb_user.Text = fullname;
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }

            try
            {
                if ((sender as ComboBox).SelectedItem as string != null)
                {
                    //вывод данных о пользователе
                    b_info.Visibility = Visibility.Visible;

                    string[] uname = Convert.ToString((sender as ComboBox).SelectedItem).Split(' ');
                    List<View_User> list = Connect.DataBase.View_User.ToList().Where(tb => tb.Surname == uname[0] && tb.Name == uname[1] && tb.Patronymic == uname[2]).ToList();
                    tbk_name.Text = Convert.ToString((sender as ComboBox).SelectedItem);
                    tbk_dateofbirtd.Text = Convert.ToString(list[0].Birthday).Split(' ')[0];
                    tbk_phone.Text = list[0].Phone;
                    tbk_email.Text = list[0].Email;
                    tbk_workplace.Text = "";
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        //очищение полей ввода
        private void ckb_clear_Checked(object sender, RoutedEventArgs e)
        {
            cb_role.Text = "";
            cb_user.Text = "";
            b_info.Visibility = Visibility.Hidden;
            cb_user_Loaded(null, null);
            ckb_clear.IsChecked = false;
        }
    }
}
