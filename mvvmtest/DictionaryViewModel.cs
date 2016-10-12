using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Kazmierczak.Languer.Interfaces;
using Kazmierczak.Languer.DAO;

namespace Kazmierczak.Languer.UI
{
    public class DictionaryViewModel : ObservableObject
    {
        private IDictionary _dictionary;

        public IDictionary getDictionary()
        {
            return _dictionary;
        }

        public DictionaryViewModel(IDictionary dictionary)
        {
            _dictionary = dictionary;
        }

        public DictionaryViewModel()
        {
            IDAO dao = (IDAO)LateBinding.GetDAOConstructor().Invoke(new object[] { });
            IDictionary dictionary = dao.CreateNewDictionary();
            _dictionary = dictionary;
        }



        public string Name
        {
            get { return _dictionary.Name; }
            set
            {
                _dictionary.Name = value;
                RaisePropertyChanged("Name");
            }
        }

        public int DictionaryID
        {
            get { return _dictionary.DictionaryID; }
            set
            {
                _dictionary.DictionaryID = value;
                RaisePropertyChanged("DictionaryID");
            }
        }
    }
}
