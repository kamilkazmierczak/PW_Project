using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Kazmierczak.Languer.Interfaces;
using System.Windows.Input;
using System.ComponentModel;
using System.Windows;

namespace Kazmierczak.Languer.UI
{
    public class WordShowViewModel : ObservableObject
    {
        //private WordViewModel _newWord;
        private IDAO _dao;


        public WordShowViewModel()
        {
            #if DEBUG
            if (DesignerProperties.GetIsInDesignMode(new DependencyObject())) return;
            #endif

            _dao = new DAO.DAO();
            //NewWord = new WordViewModel();

            _confirmWordCommand = new RelayCommand(param => this.ConfirmWord());
        }


        private RelayCommand _confirmWordCommand;

        public ICommand ConfirmWordCommand
        {
            get { return _confirmWordCommand; }
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
