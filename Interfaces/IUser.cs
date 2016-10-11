using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kazmierczak.Languer.Interfaces
{
    public interface IUser
    {
        int UserID { get; set; }
        string Name { get; set; }

        //IDictionary Dictionary { get; set; }
        //List<IDictionary> Dictionaries { get; set; }
        //void addUserDictionary(IDictionary dictionary);

    }
}
