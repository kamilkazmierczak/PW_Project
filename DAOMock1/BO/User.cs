using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Kazmierczak.Languer.Interfaces;

namespace Kazmierczak.Languer.DAO.BO
{
    public class User : IUser
    {
        public string Name
        {
            get;
            set;
        }

        public int UserID
        {
            get;
            set;
        }
    }
}
