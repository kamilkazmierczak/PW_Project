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
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;

namespace Kazmierczak.Languer.UI
{
    public class WordShowViewModel : ObservableObject
    {
        //private WordViewModel _newWord;
        //private ObservableCollection<WordViewModel> _words;
        private WordViewModel _currentWord;
        //private DictionaryViewModel _selectedDictionary;
        private IDAO _dao;
        private int? _currentWordIndex;

        private List<WordViewModel> _words;


        public WordShowViewModel()
        {
            #if DEBUG
            if (DesignerProperties.GetIsInDesignMode(new DependencyObject())) return;
            #endif

            _currentWordIndex = null;
            _dao = new DAO.DAO();
            //_words = new ObservableCollection<WordViewModel>();
            _words = new List<WordViewModel>();
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

        private void copyWord(WordViewModel source, WordViewModel dest)
        {
            dest.WordID = source.WordID;
            dest.Correct = source.Correct;
            dest.Incorrect = source.Incorrect;
            dest.OriginName = source.OriginName;
            dest.SecondName = "";
        }

        private void StartStudy()
        {
            Console.WriteLine("Start Study");
            GetAllWordsForDictionary();
            if (_currentWordIndex != null){
                copyWord(_words.ElementAt((int)_currentWordIndex), CurrentWord);
            }
           
        }

        private void ConfirmWord()
        {
            Console.WriteLine("CONFIRM WORD");

            if (_currentWord.SecondName == _words.ElementAt((int)_currentWordIndex).SecondName)
            {//correct
                Console.WriteLine("Typed: " + _currentWord.SecondName);
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
                copyWord(_words.ElementAt((int)_currentWordIndex), CurrentWord);
            }
            else
            {
                Console.WriteLine("Przejrzane wszystkie wyrazy");
            }
           
        }
    }
}
