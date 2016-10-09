using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Kazmierczak.Languer.Interfaces;
using Kazmierczak.Languer.DAO;

namespace Kazmierczak.Languer.UI
{
    public class UserViewModel : ObservableObject
    {
        private IUser _user;

        public UserViewModel(IUser user)
        {
            _user = user;
        }

        public UserViewModel()
        {
            //moja teoria na razie nie dziala to saveUser bez addUser
            IDAO dao = new DAO.DAO();
            IUser user = dao.CreateNewUser();
            _user = user;
        }

        public string Name
        {
            get { return _user.Name; }
            set
            {
                _user.Name = value;
                Console.WriteLine(_user.Name);
                Console.WriteLine("x");
                RaisePropertyChanged("Name");
            }
        }

        public int UserID
        {
            get { return _user.UserID; }
            set
            {
                _user.UserID = value;
                RaisePropertyChanged("UserID");
            }
        }

    }
}
