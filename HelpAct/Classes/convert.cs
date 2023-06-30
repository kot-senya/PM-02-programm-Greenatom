using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HelpAct
{
    public class convert
    {
        public static Users idUserToUser (int id)
        {
            Users user = null;

            List<Users> users = Connect.DataBase.Users.ToList().Where(tb => tb.ID_user == id).ToList();

            if (users.Count > 0)
            {
                user = users[0];
            }

            return user;
        }

        public static string UserToRoleUser(string login, string password)
        {
            string role = null;

            List<Data_users> list = Connect.DataBase.Data_users.ToList().Where(tb => tb.Login == login && tb.Password == password).ToList();

            if (list.Count > 0)
            {
                List<Roles> roles = Connect.DataBase.Roles.ToList().Where(tb => tb.ID_role_user == list[0].ID_role_user).ToList();
                role = roles[0].Name_role;
            }

            return role;
        }

    }
}
