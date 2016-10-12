using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Kazmierczak.Languer.Interfaces;
using System.Windows.Input;
using System.ComponentModel;
using System.Windows;
using System.Collections.ObjectModel;

namespace Kazmierczak.Languer.UI
{
    public class WordShowViewModel : ObservableObject
    {
        //private WordViewModel _newWord;
        private ObservableCollection<WordViewModel> _words;
        private WordViewModel _currentWord;
        //private DictionaryViewModel _selectedDictionary;
        private IDAO _dao;
        private int? _currentWordIndex;


        public WordShowViewModel()
        {
            #if DEBUG
            if (DesignerProperties.GetIsInDesignMode(new DependencyObject())) return;
            #endif

            _currentWordIndex = null;
            _dao = new DAO.DAO();
            _words = new ObservableCollection<WordViewModel>();
            GetAllWordsForDictionary();
            _currentWord = new WordViewModel();

            //NewWord = new WordViewModel();
            _startStudyCommand = new RelayCommand(param => this.StartStudy());
            _confirmWordCommand = new RelayCommand(param => this.ConfirmWord());
        }


        private RelayCommand _confirmWordCommand;

        public ICommand ConfirmWordCommand
        {
            get { return _confirmWordCommand; }
        }

        private RelayCommand _startStudyCommand;

        public ICommand StartStudyCommand
        {
            get { return _startStudyCommand; }
        }


        private void GetAllWordsForDictionary()
        {
            _currentWordIndex = 0;
            if (_dao.GetAllWordsForDictionary() !=null)
            {
                foreach (var c in _dao.GetAllWordsForDictionary())
                {
                    Console.WriteLine(c.OriginName+";"+c.SecondName);
                    _words.Add(new WordViewModel(c));
                }
            }
        }

        public ObservableCollection<WordViewModel> Words
        {
            get { return _words; }
            set
            {
                _words = value;
                RaisePropertyChanged("Words");
            }
        }

        public WordViewModel CurrentWord
        {
            get
            {
                Console.WriteLine("GETcurrentWord: "+_currentWord.OriginName);
                return _currentWord;
            }
            set
            {
                Console.WriteLine("SETcurrentWord: " + value.OriginName);
                _currentWord = value;
                RaisePropertyChanged("CurrentWord");
            }
        }

        private void StartStudy()
        {
            Console.WriteLine("Start Study");
            GetAllWordsForDictionary();
            if (_currentWordIndex != null){
                CurrentWord = _words.ElementAt((int)_currentWordIndex);
                CurrentWord.SecondName = "";
            }
           
        }

        private void ConfirmWord()
        {
            Console.WriteLine("CONFIRM WORD");

            if (_currentWord.SecondName == _words.ElementAt((int)_currentWordIndex).SecondName)
            {//correct
                Console.WriteLine("Typed: "+_currentWord.SecondName);
                Console.WriteLine("Original: " + _words.ElementAt((int)_currentWordIndex).SecondName);
                Console.WriteLine("CORRECT");
            }
            else
            {//incorrect
                Console.WriteLine("Typed: " + _currentWord.SecondName);
                Console.WriteLine("Original: " + _words.ElementAt((int)_currentWordIndex).SecondName);
                Console.WriteLine("INCORRECT");
            }

            _currentWordIndex++;
            if (_words.Count > _currentWordIndex)
            {//next word

                CurrentWord = _words.ElementAt((int)_currentWordIndex);
                CurrentWord.SecondName = "";
            }
            else
            {
                Console.WriteLine("Przejrzane wszystkie wyrazy");
            }
            

            //UserViewModel newUser = new UserViewModel();
            //newUser.Name = _editedUser.Name;
            //newUser.UserID = _editedUser.UserID;
            //Users.Add(newUser);
            //_dao.AddUser(newUser.getUser());
            //EditedUser = new UserViewModel();

            //WordViewModel newWord = new WordViewModel();
            //newWord.OriginName = _newWord.OriginName;
            //newWord.SecondName = _newWord.SecondName;
            //newWord.Incorrect = _newWord.Incorrect;
            //newWord.Correct = _newWord.Correct;
            //newWord.WordID = _newWord.WordID;

            //_dao.addWord(newWord.getWord());
            //NewWord = new WordViewModel();
        }
    }
}
