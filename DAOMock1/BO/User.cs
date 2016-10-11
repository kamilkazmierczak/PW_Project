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

        [Key]
        public int UserID
        {
            get;
            set;
        }

        public virtual List<Dictionary> Dictionaries
        {
            get;
            set;
        }

        public User()
        {
            Dictionaries = new List<Dictionary>();
        }

        //connection to Dictionary
        //public int DictionaryID { get; set; }
        //public virtual Dictionary Dictionary { get; set; }

        //public virtual List<IDictionary> Dictionaries
        //{
        //    get;
        //    set;
        //}



        public string Name
        {
            get;
            set;
        }





        //public User()
        //{
        //    Dictionaries = new List<IDictionary>();
        //}

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
