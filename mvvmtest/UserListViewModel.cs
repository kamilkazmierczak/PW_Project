using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Kazmierczak.Languer.Interfaces;
using System.Collections.ObjectModel;
using System.Windows.Input;

namespace Kazmierczak.Languer.UI
{
    public class UserListViewModel : ObservableObject
    {
        private ObservableCollection<UserViewModel> _users;
        private IDAO _dao;
        private RelayCommand _addUserCommand;

        public UserListViewModel()
        {
            _users = new ObservableCollection<UserViewModel>();
            _dao = new DAO.DAO(); // moze byc late binding, wydzielic do osobnej klasy i pobranie z niej obiektu dostepu do danych
            GetAllUsers();

            _addUserCommand = new RelayCommand(param => this.AddUserToList());
        }

        public ICommand AddUserCommand
        {
            get { return _addUserCommand; } // wlasciwosc tylko do odczytu
        }

        private void AddUserToList()
        {
            IUser user = _dao.CreateNewUser();
            user.Name = "ratata";
            user.UserID = 44;
            UserViewModel uvm = new UserViewModel(user);
            _dao.AddUser(user);
            Users.Add(uvm);
        }

        private void GetAllUsers()
        {
            foreach (var c in _dao.GetAllUsers())
            {
                _users.Add(new UserViewModel(c));
            }
        }

        public ObservableCollection<UserViewModel> Users
        {
            get { return _users; }
            set
            {
                _users = value;
                RaisePropertyChanged("Users");
            }
        }

    }
}
