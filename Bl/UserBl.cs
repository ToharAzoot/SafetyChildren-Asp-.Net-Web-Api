using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dal;
using Dto;

namespace Bl
{
    public class UserBl
    {
        public static bool Regiater(UsrDto user)
        {
            Users u = UsrDto.Todal(user);
            return UserDal.Register(u);
        }

        public static bool AddUser(UsrDto us)
        {
            using (kindergardenEntities db = new kindergardenEntities())
            {
                Users poDal = UsrDto.Todal(us);
                int id = 0;
                id+= UserDal.AddUser(poDal);
                if (id != 0)
                    return true;
            }
            return false;
        }
        public static bool UpdateUser(UsrDto us)
        {
            using (kindergardenEntities db = new kindergardenEntities())
            {
                bool id = false;
                Users poDal = UsrDto.Todal(us);
                string v = us.childId;
                if (poDal.UserName != null && poDal.Password != null )
                    id = UserDal.UpdateUser(poDal,v);
                return id;

            }
            return false;
        }
        public static Users Getallpropertyd(string id)
        {
            using (kindergardenEntities db = new kindergardenEntities())
            {
                Users pass = UserDal.Getallpropertyd(id);
                return pass;
            }
        }
    }
}
