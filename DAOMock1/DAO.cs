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

        //public IEnumerable<IDictionary> GetAllDictionaries()
        //{
        //    //using (var context = new DataContext())
        //    //{
        //    //    return Enumerable.Cast<IDictionary>(context.Dictionaries).ToList();
        //    //}
        //}

        public IDictionary CreateNewDictionary()
        {
            return new BO.Dictionary();
        }

        public void addDictionary(IDictionary dictionary)
        {
            var currentUser = CurrentOptions.CurrentUser;


            using (var context = new DataContext())
            {
                var query = context.Users.SingleOrDefault(x => x.UserID == currentUser.UserID);
                if (query != null)
                {
                    var dictionariesIDs = context.Dictionaries.Select(x => x.DictionaryID);
                    dictionary.DictionaryID = dictionariesIDs == null ? dictionariesIDs.Max() + 1 : 1;
                    query.Dictionaries.Add((Dictionary)dictionary);
                    context.SaveChanges();
                }
            }

            //var d1 = new Dictionary();
            //d1.


            //using (var context = new DataContext())
            //{
            //    var query = context.Users.SingleOrDefault(x => x.UserID == 1);
            //    if (query != null)
            //    {
            //        foreach (var item in query.Dictionaries)
            //        {
            //            Console.WriteLine("Dictionary Name: " + item.Name);
            //        }
            //    }
            //}


            //var user1 = new User();
            //user1.UserID = 222;
            //user1.Name = "Test2";

            //var d1 = new Dictionary();
            //d1.DictionaryID = 321;
            //d1.Name = "d2";


            //user1.Dictionaries.Add(d1);

            //using (var context = new DataContext())
            //{
            //    context.Users.Add(user1);
            //    context.SaveChanges();
            //}



            //using (var context = new DataContext())
            //{
            //    var query = context.Users.SingleOrDefault(x => x.UserID == currentUser.UserID);
            //    if (query != null)
            //    {
            //        //User user = new User();
            //        //var dictionariesIDs = context.Dictionaries.Select(x => x.DictionaryID);
            //        //dictionary.DictionaryID = dictionariesIDs == null ? dictionariesIDs.Max() + 1 : 1;
            //        //user.DictionariesList.Add(dictionary);
            //        //dictionary.DictionaryID = 222;
            //        //dictionary.
            //        var d1 = new Dictionary();
            //        d1.DictionaryID = 1;
            //        d1.Name = "d1";

            //        //var d2 = new Dictionary();
            //        //d2.DictionaryID = 2;
            //        //d2.Name = "d2";

            //        query.Dictionaries.Add(d1);


            //        //query.Dictionaries.Add(dictionary as Dictionary);


            //        //query.Name = "ratatatt";
            //        int length = query.Dictionaries.Count();
            //        context.SaveChanges();
            //        Console.WriteLine("Dodalem do usera" + query.Name + "slownik" + query.Dictionaries[0].Name);
            //    }
            //}



            //using (var context = new DataContext())
            //{
            //    var query = context.Users.SingleOrDefault(x => x.UserID == currentUser.UserID);
            //    if (query != null)
            //    {
            //        foreach (var item in query.Dictionaries)
            //        {
            //            Console.WriteLine("DictionaryID: "+item.DictionaryID+" Name: "+item.Name);
            //        }
            //    }
            //}



        }
    }
}
