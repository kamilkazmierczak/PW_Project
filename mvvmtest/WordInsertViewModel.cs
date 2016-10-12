using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Kazmierczak.Languer.DAO;
using Kazmierczak.Languer.Interfaces;
using System.ComponentModel;
using System.Windows;
using System.Windows.Input;

namespace Kazmierczak.Languer.UI
{
    public class WordInsertViewModel : ObservableObject
    {
        private WordViewModel _newWord;
        private IDAO _dao;

        public WordInsertViewModel()
        {
            #if DEBUG
            if (DesignerProperties.GetIsInDesignMode(new DependencyObject())) return;
            #endif

            _dao = (IDAO)AssemblyLoader.GetDAOConstructor().Invoke(new object[] { });
            NewWord = new WordViewModel();
            
            _saveNewWordCommand = new RelayCommand(param => this.SaveWord());

        }

        private RelayCommand _saveNewWordCommand;

        public ICommand SaveNewWordCommand
        {
            get { return _saveNewWordCommand; }
        }

        private void SaveWord()
        {
            if (CurrentOptions.CurrentUser!=null)
            {
                WordViewModel newWord = new WordViewModel();
                newWord.OriginName = _newWord.OriginName;
                newWord.SecondName = _newWord.SecondName;
                newWord.Incorrect = _newWord.Incorrect;
                newWord.Correct = _newWord.Correct;
                newWord.WordID = _newWord.WordID;

                _dao.addWord(newWord.getWord());
                NewWord = new WordViewModel();
            }

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
    }
}
