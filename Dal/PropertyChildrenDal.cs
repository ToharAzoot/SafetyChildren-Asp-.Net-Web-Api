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

                //List<string> Children = db.empGetChildIdSp().ToList();
                List<Class1> podto = new List<Class1>();
                //foreach (string c in Children)
                //    podto.Add(new Class1(c));
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

                Children f = db.Children.Find(id);
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
               Children c = db.Children.Find(id);
                return c;
            }
        }
        public static bool AddChildren(Children ch)
        {
            using (kindergardenEntities db = new kindergardenEntities())
            {
                db.Children.Add(ch);
                int iduser=db.Users.Max(i => i.UserId);
                Users u = db.Users.Find(iduser);
<<<<<<< HEAD
                Connections f = new Connections();
                f.ChildId = ch.ChildId.ToString();
                f.UserId = u.Password;
                db.Connections.Add(f);
                DailyAlerts d = new DailyAlerts();
                d.ChildId = ch.ChildId;
                d.AvgTime = TimeSpan.Parse("0");
                d.IsComing_ = false;
                d.IsMissing_ = false;
                db.DailyAlerts.Add(d);
=======
                //Connections f = new Connections(ch.ChildId, u.Password);
                //db.Connections.Add(f);
                //DailyAlerts d = new DailyAlerts(ch.ChildId,TimeSpan.Parse("0"), false, false,);
                //db.DailyAlerts.Add(d);
>>>>>>> 2c906bf0ffcd851696f6620f21c1b31830e30866
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
