using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kazmierczak.Languer.Interfaces
{
    public interface IDictionary
    {
        int DictionaryID { get; set; }
        string Name { get; set; }
        //List<IUser> Users { get; set; }
    }
}
