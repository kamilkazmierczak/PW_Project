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
        private IDAO _dao;


        public WordShowViewModel()
        {
            #if DEBUG
            if (DesignerProperties.GetIsInDesignMode(new DependencyObject())) return;
            #endif

            _dao = new DAO.DAO();
            _words = new ObservableCollection<WordViewModel>();
            GetAllWordsForDictionary();
            
            
            //NewWord = new WordViewModel();

            _confirmWordCommand = new RelayCommand(param => this.ConfirmWord());
        }


        private RelayCommand _confirmWordCommand;

        public ICommand ConfirmWordCommand
        {
            get { return _confirmWordCommand; }
        }


        private void GetAllWordsForDictionary()
        {
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


        private void ConfirmWord()
        {
            Console.WriteLine("CONFIRM WORD");
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
