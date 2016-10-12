using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Kazmierczak.Languer.Interfaces;
using Kazmierczak.Languer.DAO;
using System.Collections.ObjectModel;
using System.Windows.Input;
using System.ComponentModel;
using System.Windows;

namespace Kazmierczak.Languer.UI
{
    public class DictionaryListViewModel : ObservableObject
    {
        private ObservableCollection<DictionaryViewModel> _dictionaries;
        private DictionaryViewModel _newDictionary;
        private DictionaryViewModel _selectedDictionary;
        private WordInsertViewModel _wordInsertViewModel;
        private IDAO _dao;

        public DictionaryListViewModel()
        {
            #if DEBUG
            if (DesignerProperties.GetIsInDesignMode(new DependencyObject())) return;
            #endif

            _wordInsertViewModel = new WordInsertViewModel();

            _dictionaries = new ObservableCollection<DictionaryViewModel>();
            _dao = (IDAO)LateBinding.GetDAOConstructor().Invoke(new object[] { });
            GetAllDictionaries();
            NewDictionary = new DictionaryViewModel();
            
            _saveNewDictionaryCommand = new RelayCommand(param => this.SaveDictionary());
        }

        public WordInsertViewModel WordInsertViewModel
        {
            get { return _wordInsertViewModel; }
            set
            {
                _wordInsertViewModel = value;
                RaisePropertyChanged("WordInsertViewModel");
            }
        }


        private RelayCommand _saveNewDictionaryCommand;

        public ICommand SaveNewDictionaryCommand
        {
            get { return _saveNewDictionaryCommand; }
        }

        public DictionaryViewModel SelectedDictionary
        {
            get { return _selectedDictionary; }
            set
            {
                _selectedDictionary = value;
                CurrentOptions.CurrentDictionary = _selectedDictionary.getDictionary();
                RaisePropertyChanged("SelectedDictionary");
            }
        }

        public DictionaryViewModel NewDictionary
        {
            get { return _newDictionary; }
            set
            {
                _newDictionary = value;
                RaisePropertyChanged("NewDictionary");
            }
        }

        private void SaveDictionary()
        {
            if (CurrentOptions.CurrentUser!=null)
            {
                DictionaryViewModel newDictionary = new DictionaryViewModel();
                newDictionary.Name = _newDictionary.Name;
                newDictionary.DictionaryID = _newDictionary.DictionaryID;
                Dictionaries.Add(newDictionary);
                _dao.addDictionary(newDictionary.getDictionary());
                NewDictionary = new DictionaryViewModel();
            }


        }

        private void GetAllDictionaries()
        {
            if (_dao.GetAllDictionaries() != null)
            {
                foreach (var c in _dao.GetAllDictionaries())
                {
                    _dictionaries.Add(new DictionaryViewModel(c));
                }
            }
          
        }

        public ObservableCollection<DictionaryViewModel> Dictionaries
        {
            get { return _dictionaries; }
            set
            {
                _dictionaries = value;
                RaisePropertyChanged("Dictionaries");
            }
        }
    }
}
