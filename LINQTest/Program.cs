using Cars.DB_1;
using Cars.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LINQTest
{
    class Program
    {
        static void Main(string[] args)
        {
            var zm1 = new { Name = "Lesław", Age = 20 };
            var zm2 = new { Name = "Lesław", Age = 20 };
            
            if(zm1.Equals(zm2))
                Console.WriteLine("takie same");
            else
                Console.WriteLine("inne");

            Parking parking = new Parking();
            List<IProducer> producers = parking.GetAllProducers();
            List<ICar> cars = parking.GetAllCars();

            foreach (var p in producers)
            {
                Console.WriteLine("{0} {1}", p.Id, p.Name);
            }
            Console.WriteLine("________________________");

            foreach (var c in cars)
            {
                Console.WriteLine("{0} {1} {2}", c.ProducerId, c.Name, c.ProdYear);
            }
            Console.WriteLine("________________________");


            var list = from car in cars
                       select car;

            foreach (var c in list)
            {
                Console.WriteLine("{0} {1} {2}", c.ProducerId, c.Name, c.ProdYear);
            }
            Console.WriteLine("________________________");

            list = from car in cars
                   where car.ProdYear > 2005
                   select car;

            foreach (var c in list)
            {
                Console.WriteLine("{0} {1} {2}", c.ProducerId, c.Name, c.ProdYear);
            }
            Console.WriteLine("________________________");

            cars[3].ProdYear = 2008;
            foreach (var c in list)
            {
                Console.WriteLine("{0} {1} {2}", c.ProducerId, c.Name, c.ProdYear);
            }
            Console.WriteLine("________________________");

            var list2 = from car in cars
                        join prod in producers on car.ProducerId equals prod.Id
                        select new { car.Name, car.ProdYear, ProducerName=prod.Name };

            foreach (var c in list2)
            {
                Console.WriteLine("{0} {1} {2}", c.Name, c.ProdYear, c.ProducerName);
            }
            Console.WriteLine("________________________");

            var carProd = from prod in producers
                          join car in cars on prod.Id equals car.ProducerId into _cars
                          from car in _cars.DefaultIfEmpty()
                          select new { ProdName = prod.Name, CarName = (car == null) ? "no cars" : car.Name };

            foreach (var c in carProd)
            {
                Console.WriteLine(c);
            }
            Console.WriteLine("________________________");
        }
    }
}
