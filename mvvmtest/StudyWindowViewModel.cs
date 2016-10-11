using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Kazmierczak.Languer.Interfaces;
using System.ComponentModel;
using System.Windows;

namespace Kazmierczak.Languer.UI
{
    public class StudyWindowViewModel : ObservableObject, IPageViewModel
    {

        //private WordInsertViewModel _wordInsertViewModel;
        private UserListViewModel _userListViewModel;
        private WordShowViewModel _wordShowViewModel;
        //private IDAO _dao;

        public StudyWindowViewModel()
        {
            #if DEBUG
            if (DesignerProperties.GetIsInDesignMode(new DependencyObject())) return;
            #endif

            _wordShowViewModel = new WordShowViewModel();
            _userListViewModel = new UserListViewModel();
        }

        public WordShowViewModel WordShowViewModel
        {
            get { return _wordShowViewModel; }
            set
            {
                _wordShowViewModel = value;
                RaisePropertyChanged("WordShowViewModel");
            }
        }

        public UserListViewModel UserListViewModel
        {
            get { return _userListViewModel; }
            set
            {
                _userListViewModel = value;
                RaisePropertyChanged("UserListViewModel");
            }
        }


        public string Name
        {
            get
            {
                return "Study";
            }
        }
    }
}
