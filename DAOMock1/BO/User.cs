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
        public int UserID { get; set; }
        public string Name { get; set; }

        public User()
        {
            Dictionaries = new List<Dictionary>();
        }

        public virtual List<Dictionary> Dictionaries { get; set; }
    }
}
