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
            _saveNewUserCommand = new RelayCommand(param => this.SaveUser());
        }

        public ICommand AddUserCommand
        {
            get { return _addUserCommand; } // wlasciwosc tylko do odczytu
        }

        private void AddUserToList()
        {
            IUser user = _dao.CreateNewUser();
            //user.Name = "ratata";
            //user.UserID = 44;
            UserViewModel uvm = new UserViewModel(user);
            EditedUser = uvm;
            //Console.WriteLine("dodalem");
            //_dao.AddUser(user);
            //Users.Add(uvm);
        }

        //WTF
        private RelayCommand _saveNewUserCommand;
        //private ICommand _saveNewUserCommand; //dla add bylo RelayComamnd a nie ICommand

        public ICommand SaveNewUserCommand
        {
            get { return _saveNewUserCommand; }
        }

        private UserViewModel _editedUser;

        public UserViewModel EditedUser
        {
            get { return _editedUser; }
            set
            {
                _editedUser = value;
                RaisePropertyChanged("EditedUser");
            }
        }

        private void SaveUser()
        {
            //_users.Add(_editedUser); // normalnie zapisać też do DAO
            //_dao.AddUser(_editedUser);
            Users.Add(_editedUser);
        }
        //end WTF


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
