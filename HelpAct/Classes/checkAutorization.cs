using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HelpAct
{
    public class checkAutorization
    {
        public static bool input(string login, string password, out Users user) 
        {
            bool flag = false;
            user = new Users();

            List<Data_users> list = Connect.DataBase.Data_users.ToList().Where(tb => tb.Login == login && tb.Password == password).ToList();

            if (list.Count > 0)
            {
                user = convert.idUserToUser((int)list[0].ID_user);
                flag = true;
            }

            return flag;
        }
    }
}
