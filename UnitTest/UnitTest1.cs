using HelpAct;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Text.RegularExpressions;

namespace UnitTest
{
    public class UnitTest1
    {
        [TestMethod]
        public void PhoneInputTest()
        {
            Users user = new Users();
            user.Phone = "89078636843";
            Assert.IsNotNull(user.Phone);
        }

        [TestMethod]
        public void UserPasswordLoginTest()
        {
            Data_users en = new Data_users();
            en.Password = "1";
            en.Login = "Админ";
            Assert.Equals(en.Password, en.Login);
        }
        [TestMethod]
        public void PatronymicIsNotNullTest()
        {
            Users user = new Users();
            user.Patronymic = "Константинович";
            Assert.IsNotNull(user.Patronymic);
        }
        [TestMethod]
        public void AdminPasswordLoginTest()
        {
            Event_Managers en = new Event_Managers();
            en.Password = "Admin";
            en.Login = "Admin";
            Assert.Equal(en.Login, en.Password);
        }
        [TestMethod]
        public void EmailCheckTest()
        {
            Users user = new Users();
            user.Email = "serovaae@green.com";
            Assert.("@", en.E_mail);
        }

        [TestMethod]
        public void PasswordInputTest()
        {
            Users en = new Users();
            Regex password = new Regex("^(?=.*[0-9])(?=.*[a-z])(?=.*[A-Z])[0-9 a-z A-Z]{6,}$");
            en.Password = "Dimacyber2020";
            Assert.Matches(password, en.Password);
        }
        [TestMethod]
        public void FIOInputTest()
        {
            User_registration en = new User_registration();
            Regex FIO = new Regex("^[А-Я]{1}[а-я].+ [А-Я]{1}[а-я].+ [А-Я]{1}[а-я].+");
            en.FIO = "Кудряшов Дмитрий";
            Assert.DoesNotMatch(FIO, en.FIO);
        }
    }
}
