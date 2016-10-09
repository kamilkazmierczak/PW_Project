using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Kazmierczak.Languer.Interfaces;

namespace Kazmierczak.Languer.UI
{
    public class UserViewModel : ObservableObject
    {
        private IUser _user;

        public UserViewModel(IUser user)
        {
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
