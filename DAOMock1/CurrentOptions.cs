using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Kazmierczak.Languer.Interfaces;

namespace Kazmierczak.Languer.DAO
{
    public static class CurrentOptions
    {
        private static IUser _currentUser;
        private static IDictionary _currentDictionary;
        public static bool _logged;

        public static IDictionary CurrentDictionary
        {
            get
            {
                return _currentDictionary;
            }
            set
            {
                _currentDictionary = value;
                Console.Write("CurrentDictionary = ");
                Console.WriteLine(_currentDictionary.DictionaryID + _currentDictionary.Name);
            }
        }

        public static IUser CurrentUser
        {
            get
            {
                return _currentUser;
            }
            set
            {
                _currentUser = value;
                Console.Write("CurrentUser = ");
                Console.WriteLine(_currentUser.UserID + _currentUser.Name);
            }
        }
    }
}
