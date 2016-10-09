using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kazmierczak.Languer.Interfaces
{
    public interface IProducer
    {
        int ProducerID { get; set; }
        string Name { get; set; }

    }
}
