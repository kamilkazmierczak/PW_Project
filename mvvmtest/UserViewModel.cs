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

        public IUser getUser()
        {
            return _user;
        }

        public UserViewModel(IUser user)
        {
            _user = user;
        }

        public UserViewModel()
        {
            IDAO dao = (IDAO)LateBinding.GetDAOConstructor().Invoke(new object[] { });
            IUser user = dao.CreateNewUser();
            _user = user;
        }

        public string Name
        {
            get { return _user.Name; }
            set
            {
                _user.Name = value;
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
