using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace HelpAct
{
    internal class checkRegestration
    {
        static Regex checkName = new Regex(@"^[А-я ,.'-]+$");
        static Regex checkEmail = new Regex(@"^\S+@\S+\.\S+$");
        static Regex checkNumberPhone = new Regex(@"^(8)\d{10}$");

        public static bool check_Name(string value)
        {
            bool flag = false;

            if (checkName.IsMatch(value))
            {
                flag = true;
            }

            return flag;
        }

        public static bool check_Email(string value)
        {
            bool flag = false;

            List<Users> list = Connect.DataBase.Users.ToList().Where(tb => tb.Email == value).ToList();//проверка на оригинальность

            if (checkEmail.IsMatch(value) && list.Count == 0)
            {
                flag = true;
            }

            return flag;
        }

        public static bool check_NumberPhone(string value)
        {
            bool flag = false;

            List<Users> list = Connect.DataBase.Users.ToList().Where(tb => tb.Phone == value).ToList();//проверка на оригинальность

            if (checkNumberPhone.IsMatch(value) && list.Count == 0)
            {
                flag = true;
            }

            return flag;
        }

        public static bool check_Age(string value)
        {
            bool flag = false;

            if (value != "")
            {
                DateTime date = Convert.ToDateTime(value);
                double difference = (DateTime.Today - date).TotalDays / 365;

                if (difference > 18)
                {
                    flag = true;
                }
            }

            return flag;
        }
    
        public static string newLogin(Users user)
        {
            string login = null;
            string proba = user.Surname + user.Name[0] + user.Patronymic[0];

            if(check_Login(proba))
            {
                login = proba;
            }
            else
            {
                proba += user.ID_user;
            }
            return login;
        }
        public static bool check_Login(string value)
        {
            bool flag = false;
            List<Data_users> list = Connect.DataBase.Data_users.ToList().Where(tb => tb.Login ==  value).ToList();

            if(list.Count == 0)
            {
                flag = true;
            }
            return flag;
        }
    }
}
