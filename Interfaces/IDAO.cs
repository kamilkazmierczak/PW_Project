using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kazmierczak.Languer.Interfaces
{
    public interface IDAO
    {
        IEnumerable<IUser> GetAllUsers();
        IEnumerable<IDictionary> GetAllDictionaries();
        IEnumerable<IWord> GetAllWordsForDictionary();
        IEnumerable<IWord> GetCustomWordsForDictionary(decimal percent);

        IUser CreateNewUser();
        void AddUser(IUser user);

        IDictionary CreateNewDictionary();
        void addDictionary(IDictionary dictionary);

        IWord CreateNewWord();
        void addWord(IWord word);
        void updateWord(IWord word,bool correct);

        decimal GetCorrectAnswerPercentage(IDictionary dictionary);
    }
}
