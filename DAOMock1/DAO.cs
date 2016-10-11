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

        public IEnumerable<IDictionary> GetAllDictionaries()
        {
            using (var context = new DataContext())
            {
                return Enumerable.Cast<IDictionary>(context.Dictionaries).ToList();
            }
        }

        public IDictionary CreateNewDictionary()
        {
            return new BO.Dictionary();
        }

        public void addDictionary(IDictionary dictionary)
        {
            var currentUser = CurrentOptions.CurrentUser;

            using (var context = new DataContext())
            {
                //var query = context.Users.Select(x => x.UserID == currentUser.UserID);
                //var user = (IUser)query.First<User>();
                var query = context.Users.Where(x => x.UserID == currentUser.UserID);
                User user = new User();
                try{
                    user = query.FirstOrDefault<User>();
                }catch (Exception){
                    Console.WriteLine("User not found");
                    return;
                }

                var dictionariesIDs = context.Dictionaries.Select(x => x.DictionaryID);
                dictionary.DictionaryID = dictionariesIDs == null ? dictionariesIDs.Max() + 1 : 1;

                //Console.WriteLine(dictionary.Name);
                
                user.DictionariesList.Add(dictionary);
              

                //Console.WriteLine("wybrales");
                //Console.WriteLine(user.Name);

                //Console.WriteLine(user.);
                //user.UserID = usersIDs == null ? usersIDs.Max() + 1 : 1;
                //context.Users.Add(user as User);
                //context.SaveChanges();
            }

            //using (var context = new DataContext())
            //{
            //    var dictionariesIDs = context.Dictionaries.Select(x => x.DictionaryID);
            //    dictionary.DictionaryID = dictionariesIDs == null ? dictionariesIDs.Max() + 1 : 1;
            //    context.Dictionaries.Add(dictionary as Dictionary);
            //    context.SaveChanges();
            //}
        }
    }
}
