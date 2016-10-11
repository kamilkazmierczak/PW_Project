using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Kazmierczak.Languer.Interfaces;
using Kazmierczak.Languer.DAO.BO;

namespace Kazmierczak.Languer.UI
{
    public class WordViewModel : ObservableObject
    {
        private IWord _word;

        public IWord getWord()
        {
            return _word;
        }

        public WordViewModel(IWord word)
        {
            _word = word;
        }

        public WordViewModel()
        {
            IDAO dao = new DAO.DAO();
            IWord word = dao.CreateNewWord();
            _word = word;
        }

        public int WordID
        {
            get { return _word.WordID; }
            set
            {
                _word.WordID = value;
                RaisePropertyChanged("WordID");
            }
        }

        public int Correct
        {
            get { return _word.Correct; }
            set
            {
                _word.Correct = value;
                RaisePropertyChanged("Correct");
            }
        }
        public int Incorrect
        {
            get { return _word.Incorrect; }
            set
            {
                _word.Incorrect = value;
                RaisePropertyChanged("Incorrect");
            }
        }
        public string OriginName
        {
            get { return _word.OriginName; }
            set
            {
                _word.OriginName = value;
                RaisePropertyChanged("OriginName");
            }
        }
        public string SecondName
        {
            get { return _word.SecondName; }
            set
            {
                _word.SecondName = value;
                RaisePropertyChanged("SecondName");
            }
        }
    }
}
