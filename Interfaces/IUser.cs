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
        IEnumerable<IDictionary> DictionariesList { get; set; }
    }
}
