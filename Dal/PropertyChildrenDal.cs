using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dal
{
    public class PropertyChildrenDal
    {
        public static List<Class1> GetAllChildren()
        {
            using (kindergardenEntities db = new kindergardenEntities())
            {

                List<int?> Children = db.empGetChildIdSp().ToList();
                List<string> temp = new List<string>();
                foreach (int? c in Children)
                    temp.Add(Convert.ToString(c));
                List<Class1> podto = new List<Class1>();
                foreach (string c in temp)
                    podto.Add(new Class1(c));
                return podto;

            }
        }
        public static string GetUser(string id)
        {
            using (kindergardenEntities db = new kindergardenEntities())
            {

                string name = db.empGetUserSp(id).FirstOrDefault();
                return name;
            }
        }
        public static string GetChild(string id)
        {
            using (kindergardenEntities db = new kindergardenEntities())
            {
                string pass=null;
                pass=db.empGetChildSp(id).FirstOrDefault();
                return pass;
            }
        }
        public static bool Checkifthereislike(string id)
        {
            using (kindergardenEntities db = new kindergardenEntities())
            {
                int id_check = Int32.Parse(id);

                Children f = db.Children.Find(id_check);
                if (f == null)
                    return false;
                else
                    return true;
            }
        }
        public static Children Getallpropertyc(string id)
        {
            using (kindergardenEntities db = new kindergardenEntities())
            {
                int id_check = Int32.Parse(id);
               Children c = db.Children.Find(id_check);
                return c;
            }
        }
        public static bool AddChildren(Children ch)
        {
            using (kindergardenEntities db = new kindergardenEntities())
            {
                //create here the child with the right information
                //-----------------------------------------------
                db.Children.Add(ch);
                int iduser=db.Users.Max(i => i.UserId);
                Users u = db.Users.Find(iduser);
                Connections f = new Connections();
                f.ChildId = Convert.ToString(ch.ChildId);
                f.UserId = Convert.ToString(u.UserId);
                db.Connections.Add(f);
                DailyAlerts d = new DailyAlerts();
                d.ChildId = ch.ChildId;
                d.AvgTime = TimeSpan.Parse("0");
                d.IsComing_ = false;
                d.IsMissing_ = false;
                db.DailyAlerts.Add(d);
                db.SaveChanges();
                return true;
            }
        }
        public static bool UpdateChildren(Children ch)
        {
            using (kindergardenEntities db = new kindergardenEntities())
            {
                Children f=db.Children.Find(ch.ChildId);
                db.Children.Remove(f);
                db.Children.Add(ch);
                db.SaveChanges();
                return true;
            }
            return true;
        }
    }
}
