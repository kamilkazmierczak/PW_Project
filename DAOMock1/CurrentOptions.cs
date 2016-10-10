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
