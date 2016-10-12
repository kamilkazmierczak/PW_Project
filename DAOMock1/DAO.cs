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

        public IWord CreateNewWord()
        {
            return new BO.Word();
        }

        public decimal GetCorrectAnswerPercentage(IDictionary dictionary)
        {
            int correct = 0;
            int incorrect = 0;
            Console.WriteLine("Getting percentage (dao)");
            using (var context = new DataContext())
            {
                var query = context.Dictionaries.SingleOrDefault(x => x.DictionaryID == dictionary.DictionaryID);
                if (query != null)
                {
                    foreach (var item in query.Words)
                    {
                        Console.WriteLine(item.OriginName+";"+item.SecondName);
                        correct += item.Correct;
                        incorrect += item.Incorrect;
                    }
                }
            }
            decimal val = (decimal)(correct + incorrect) == 0 ? -1 : ((decimal)correct / (decimal)(correct + incorrect)) * 100;
            return val;
        }


        public void updateWord(IWord word, bool correct)
        {
            Console.WriteLine("Updating word");
            using (var context = new DataContext())
            {
                var query = context.Words.SingleOrDefault(x => x.WordID == word.WordID);
                if (query != null)
                {
                    if (correct)
                    {
                        query.Correct++;
                    }else
                    {
                        query.Incorrect++;
                    }
                    context.Words.Attach(query);
                    context.Entry(query).State = System.Data.Entity.EntityState.Modified;
                    context.SaveChanges();
                }
            }
        }


        public void addWord(IWord word)
        {
            Console.WriteLine("Adding Word");
            Console.WriteLine(word.OriginName + word.SecondName);
            //Adding word to dictionary (WORKS)
            int currentDictionaryID = CurrentOptions.CurrentDictionary.DictionaryID;
            Console.WriteLine("Current dictionary ID = " + currentDictionaryID);
            using (var context = new DataContext())
            {
                var query = context.Dictionaries.SingleOrDefault(x => x.DictionaryID == currentDictionaryID);
                if (query != null)
                {
                    var wordsIDs = context.Words.Select(x => x.WordID);
                    word.WordID = wordsIDs == null ? wordsIDs.Max() + 1 : 1;
                    query.Words.Add((Word)word);
                    context.SaveChanges();
                }
            }
        }

        public IEnumerable<IDictionary> GetAllDictionaries()
        {
            try{
                int currentUserID = CurrentOptions.CurrentUser.UserID;
                using (var context = new DataContext())
                {
                    var query = context.Users.SingleOrDefault(x => x.UserID == currentUserID);
                    return Enumerable.Cast<IDictionary>(query.Dictionaries).ToList();
                }
            }
            catch (Exception){
                Console.WriteLine("User was not selected");
            }
            return null;
        }

        public IEnumerable<IWord> GetAllWordsForDictionary()
        {
            try
            {
                int currentDictionaryID = CurrentOptions.CurrentDictionary.DictionaryID;
                using (var context = new DataContext())
                {
                    var query = context.Dictionaries.SingleOrDefault(x => x.DictionaryID == currentDictionaryID);
                    return Enumerable.Cast<IWord>(query.Words).ToList();
                }
            }
            catch (Exception){
                Console.WriteLine("Dictionary was not selected");
            }
            return null;
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
                var query = context.Users.SingleOrDefault(x => x.UserID == currentUser.UserID);
                if (query != null)
                {
                    var dictionariesIDs = context.Dictionaries.Select(x => x.DictionaryID);
                    dictionary.DictionaryID = dictionariesIDs == null ? dictionariesIDs.Max() + 1 : 1;
                    query.Dictionaries.Add((Dictionary)dictionary);
                    context.SaveChanges();
                }
            }

        }


    }
}
