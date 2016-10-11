using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Kazmierczak.Languer.Interfaces;
using System.ComponentModel.DataAnnotations;

namespace Kazmierczak.Languer.DAO.BO
{
    public class Word : IWord
    {
        [Key]
        public int WordID { get; set; }

        public int Correct {get; set; }
        public int Incorrect { get; set; }
        public string OriginName { get; set; }
        public string SecondName { get; set; }

        public virtual Dictionary Dictionary { get; set; }
    }
}
