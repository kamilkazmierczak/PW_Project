using Kazmierczak.Languer.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kazmierczak.Languer.DAO
{
    public class DAO : IDAO
    {
        private List<IProducer> _producers;
        private List<ICar> _cars;
        //
        private List<IUser> _users;

        public DAO()
        {
            _users = new List<IUser>()
            {
                new BO.User() {UserID=1,Name="Kamil" },
                new BO.User() {UserID=2,Name="Patryk" },
                new BO.User() {UserID=3,Name="Roger" }
            };


            _producers = new List<IProducer>()
            {
                new BO.Producer() {ProducerID=1, Name="Volkswagen"},
                new BO.Producer() {ProducerID=2, Name="Audi"},
                new BO.Producer() {ProducerID=3, Name="Opel"}
            };

            _cars = new List<ICar>()
            {
                new BO.Car() {CarID=1, Name="Polo", Producer=_producers[0], ProdYear=2010, Color="Black", Price=1243},
                new BO.Car() {CarID=2, Name="Passat", Producer=_producers[0], ProdYear=2008, Color="Pink", Price=2243},
                new BO.Car() {CarID=3, Name="Golf", Producer=_producers[0], ProdYear=2014, Color="White",Price=3243},
                new BO.Car() {CarID=4, Name="A4", Producer=_producers[1], ProdYear=2005, Color="Black", Price=1243},
                new BO.Car() {CarID=5, Name="A6", Producer=_producers[1], ProdYear=2007, Color="Red", Price=1233},
                new BO.Car() {CarID=6, Name="Astra", Producer=_producers[2], ProdYear=2012, Color="Brown", Price=4343},
                new BO.Car() {CarID=7, Name="Corsa", Producer=_producers[2], ProdYear=2014, Color="Black", Price=2412},
            };
        }

        public IEnumerable<IProducer> GetAllProducers()
        {
            return _producers;
        }

        public IEnumerable<ICar> GetAllCars()
        {
            return _cars;
        }

        public IEnumerable<IUser> GetAllUsers()
        {
            return _users;
        }


        public ICar CreateNewCar()
        {
            return new BO.Car();
        }

        public void AddCar(ICar car)
        {
            _cars.Add(car);
        }

        public IUser CreateNewUser()
        {
            return new BO.User();
        }

        public void AddUser(IUser user)
        {
            _users.Add(user);
        }
    }
}
