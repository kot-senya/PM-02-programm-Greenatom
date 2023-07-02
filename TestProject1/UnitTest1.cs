using HelpAct;
using System.Text.RegularExpressions;

namespace TestProject1
{
    public class UnitTest1
    {
            [Fact]
            public void PhoneInputTest()
            {
                Users user = new Users();
                user.Phone = "89078636843";
                Assert.NotNull(user.Phone);
            }
            [Fact]
            public void PasswordLoginTesttwo()
            {
                Data_users en = new Data_users();
                en.Password = "1";
                en.Login = "Админ";
                Assert.DoesNotContain(en.Password, en.Login);
            }
            [Fact]
            public void PasswordLoginTest()
            {
                Software en = new Software();
                en.Name_software = "Skype";
                Assert.NotNull(en.Name_software);
            }
            [Fact]
            public void PatronymicIsNotNullTest()
            {
                Users user = new Users();
                user.Patronymic = "Константинович";
                Assert.NotNull(user.Patronymic);
            }
            [Fact]
            public void EmailCheckTest()
            {
                Users users = new Users();
                users.Email = "serovaae@green.com";
                Assert.Contains("@", users.Email);
            }
            [Fact]
            public void EmailIsNotNullTest()
            {
                Users users = new Users();
                users.Email = "serovaae@green.com";
                Assert.NotNull(users.Email);
            }
            [Fact]
            public void NameRoleIsNotNullTest()
            {
                Roles ap = new Roles();
                ap.Name_role = "Обычный пользователь";
                Assert.NotNull(ap.Name_role);
            }
    }
}