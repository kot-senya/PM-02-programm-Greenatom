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

        public static int userToIdUser (Users user)
        {
            int id = 0;
            List<Users> list = Connect.DataBase.Users.ToList().Where(tb => tb.Surname == user.Surname && tb.Name == user.Name && tb.Patronymic == user.Patronymic && tb.Email == user.Email && tb.Phone == user.Phone).ToList();
             
            if (list.Count > 0)
            {
                id = list[0].ID_user;
            }

            return id;
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

        public static int roleToID(string role)
        {
            int id = 0;

            List<Roles> list = Connect.DataBase.Roles.ToList().Where(tb => tb.Name_role == role).ToList();

            if (list.Count > 0)
            {
                id = list[0].ID_role_user;
            }
            return id;
        }

        public static int adresOfficeToID (string adress)
        {
            int id = 0;

            List<Offices> list = Connect.DataBase.Offices.ToList().Where(tb => tb.Adress_office == adress).ToList();

            if(list.Count > 0)
            {
                id = list[0].ID_office;
            }
            return id;
        }

        public static int cabinetToID (string cabinet, int id_office)
        {
            int id = 0;

            List<Office_rooms> list = Connect.DataBase.Office_rooms.ToList().Where(tb => tb.Cabinet_office == cabinet && tb.ID_office == id_office).ToList();

            if (list.Count > 0)
            {
                id = list[0].ID_office_room;
            }

            return id;
        }

        public static int workplaceToID(string workplace, int id_cabinet)
        {
            int id = 0;

            List<Workplace> list = Connect.DataBase.Workplace.ToList().Where(tb => tb.Number_workplace == workplace && tb.ID_office_room == id_cabinet).ToList();

            if (list.Count > 0)
            {
                id = list[0].ID_workplace;
            }

            return id;
        }
    }
}
