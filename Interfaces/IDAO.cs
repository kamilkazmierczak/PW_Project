using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kazmierczak.Languer.Interfaces
{
    public interface IDAO
    {
        IEnumerable<IProducer> GetAllProducers();
        IEnumerable<ICar> GetAllCars();

        ICar CreateNewCar();
        void AddCar(ICar car);
    }
}
