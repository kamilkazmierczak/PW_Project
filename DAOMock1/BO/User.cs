using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Kazmierczak.Languer.Interfaces;
using System.ComponentModel.DataAnnotations;

namespace Kazmierczak.Languer.DAO.BO
{
    public class User : IUser
    {
        public IEnumerable<IDictionary> DictionariesList
        {
            get;
            set;
        }

        public string Name
        {
            get;
            set;
        }

        [Key]
        public int UserID
        {
            get;
            set;
        }

        //public void addUserDictionary(IDictionary dictionary)
        //{
        //    foreach (var dic in DictionariesList)
        //    {
        //        if (dictionary.Name == dic.Name)
        //        {

        //        }else
        //        {
        //            (List<Dictionary>)DictionariesList.add
        //        }
        //    }
        //}
    }
}
