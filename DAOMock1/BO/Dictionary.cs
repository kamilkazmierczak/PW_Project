using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Kazmierczak.Languer.Interfaces;
using System.ComponentModel.DataAnnotations;

namespace Kazmierczak.Languer.DAO.BO
{
    public class Dictionary : IDictionary
    {
        [Key]
        public int DictionaryID { get; set; }

        public string Name { get; set; }
        public List<IWord> WordsList { get; set; }
    }
}
