using Kazmierczak.Languer.DAO.BO;
using Kazmierczak.Languer.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kazmierczak.Languer.DAO
{
    public class DAO : IDAO
    {

        public DAO()
        {       
        }


        public IEnumerable<IUser> GetAllUsers()
        {
            using(var context = new DataContext())
            {
                return Enumerable.Cast<IUser>(context.Users).ToList();
            }
        }


        public ICar CreateNewCar()
        {
            return new BO.Car();
        }


        public IUser CreateNewUser()
        {
            return new BO.User();
        }

        public void AddUser(IUser user)
        {
            using (var context = new DataContext())
            {
                var usersIDs = context.Users.Select(x => x.UserID);
                user.UserID = usersIDs == null ? usersIDs.Max() + 1 : 1;
                context.Users.Add(user as User);
                context.SaveChanges();
            }
        }
    }
}
