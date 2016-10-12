using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Kazmierczak.Languer.Interfaces;
using System.Collections.ObjectModel;
using System.Windows.Input;
using Kazmierczak.Languer.DAO;
using System.ComponentModel;
using System.Windows;

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
            #if DEBUG
            if (DesignerProperties.GetIsInDesignMode(new DependencyObject())) return;
            #endif

            _users = new ObservableCollection<UserViewModel>();
            _dao = (IDAO)AssemblyLoader.GetDAOConstructor().Invoke(new object[] { });
            GetAllUsers();

            EditedUser = new UserViewModel();

            _saveNewUserCommand = new RelayCommand(param => this.SaveUser());
        }

       
        private RelayCommand _saveNewUserCommand;

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
                CurrentOptions._logged = true;
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
            UserViewModel newUser = new UserViewModel();
            newUser.Name = _editedUser.Name;
            newUser.UserID = _editedUser.UserID;
            Users.Add(newUser);
            _dao.AddUser(newUser.getUser());
            EditedUser = new UserViewModel();
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
