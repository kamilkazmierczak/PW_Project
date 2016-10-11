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
        private IDAO _dao;




        private WordInsertViewModel _wordInsertViewModel;

        public WordInsertViewModel WordInsertViewModel
        {
            get { return _wordInsertViewModel; }
            set
            {
                _wordInsertViewModel = value;
                RaisePropertyChanged("WordInsertViewModel");
            }
        }



        public DictionaryListViewModel()
        {
            #if DEBUG
            if (DesignerProperties.GetIsInDesignMode(new DependencyObject())) return;
            #endif

            //delete this
            _wordInsertViewModel = new WordInsertViewModel();

            _dictionaries = new ObservableCollection<DictionaryViewModel>();
            _dao = new DAO.DAO();
            GetAllDictionaries();
            NewDictionary = new DictionaryViewModel();
            
            _saveNewDictionaryCommand = new RelayCommand(param => this.SaveDictionary());
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
            DictionaryViewModel newDictionary = new DictionaryViewModel();
            newDictionary.Name = _newDictionary.Name;
            newDictionary.DictionaryID = _newDictionary.DictionaryID;
            Dictionaries.Add(newDictionary);
            _dao.addDictionary(newDictionary.getDictionary());
            NewDictionary = new DictionaryViewModel();

        }

        private void GetAllDictionaries()
        {
            foreach (var c in _dao.GetAllDictionaries())
            {
                _dictionaries.Add(new DictionaryViewModel(c));
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
