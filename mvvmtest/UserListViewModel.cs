using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Kazmierczak.Languer.Interfaces;
using System.Collections.ObjectModel;
using System.Windows.Input;
using Kazmierczak.Languer.DAO;

namespace Kazmierczak.Languer.UI
{
    public class UserListViewModel : ObservableObject
    {
        private ObservableCollection<UserViewModel> _users;
        private UserViewModel _editedUser;
        private UserViewModel _selectedItem;
        private IDAO _dao;

        public UserListViewModel()
        {
            _users = new ObservableCollection<UserViewModel>();
            _dao = new DAO.DAO(); // moze byc late binding, wydzielic do osobnej klasy i pobranie z niej obiektu dostepu do danych
            GetAllUsers();

            //IUser user = _dao.CreateNewUser();
            //UserViewModel uvm = new UserViewModel(user);
            EditedUser = new UserViewModel();

            _saveNewUserCommand = new RelayCommand(param => this.SaveUser());
        }

       
        private RelayCommand _saveNewUserCommand;
        //private ICommand _saveNewUserCommand; //dla add bylo RelayComamnd a nie ICommand

        public ICommand SaveNewUserCommand
        {
            get { return _saveNewUserCommand; }
        }

        public UserViewModel SelectedItem
        {
            get { return _selectedItem; }
            set
            {
                _selectedItem = value;
                CurrentOptions.CurrentUser = _selectedItem.getUser();
                RaisePropertyChanged("SelectedItem");
            }
        }

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

            //IUser user = _dao.CreateNewUser();
            //UserViewModel uvm = new UserViewModel(user);
            //EditedUser = uvm;
            UserViewModel newUser = new UserViewModel();
            newUser.Name = _editedUser.Name;
            newUser.UserID = _editedUser.UserID;
            Users.Add(newUser);
            _dao.AddUser(newUser.getUser());
            EditedUser = new UserViewModel();

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
