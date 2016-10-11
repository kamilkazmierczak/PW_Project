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
        private WordViewModel _newWord;
        private IDAO _dao;

        public DictionaryListViewModel()
        {
            #if DEBUG
            if (DesignerProperties.GetIsInDesignMode(new DependencyObject())) return;
            #endif

            _dictionaries = new ObservableCollection<DictionaryViewModel>();
            _dao = new DAO.DAO();
            GetAllDictionaries();
            NewDictionary = new DictionaryViewModel();
            NewWord = new WordViewModel();

            _saveNewDictionaryCommand = new RelayCommand(param => this.SaveDictionary());
            _saveNewWordCommand = new RelayCommand(param => this.SaveWord());
        }

        private RelayCommand _saveNewWordCommand;

        public ICommand SaveNewWordCommand
        {
            get { return _saveNewWordCommand; }
        }

        private void SaveWord()
        {
            WordViewModel newWord = new WordViewModel();
            newWord.OriginName = _newWord.OriginName;
            newWord.SecondName = _newWord.SecondName;
            newWord.Incorrect = _newWord.Incorrect;
            newWord.Correct = _newWord.Correct;
            newWord.WordID = _newWord.WordID;

            _dao.addWord(newWord.getWord());
            //Dictionaries.Add(newDictionary);
            //_dao.addDictionary(newDictionary.getDictionary());
            //NewDictionary = new DictionaryViewModel();

        }

        public WordViewModel NewWord
        {
            get { return _newWord; }
            set
            {
                _newWord = value;
                RaisePropertyChanged("NewWord");
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
