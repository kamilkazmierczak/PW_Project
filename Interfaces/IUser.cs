using System;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Kazmierczak.Languer;
using System.Collections.Generic;
//using Kazmierczak.Languer.DAO;

namespace Kazmierczak.Languer.Interfaces
{
    public interface IUser
    {
        int UserID { get; set; }
        string Name { get; set; }

    }
}
