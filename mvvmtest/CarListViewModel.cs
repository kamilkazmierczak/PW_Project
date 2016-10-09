using Kazmierczak.Languer.Interfaces;
using Kazmierczak.Languer.DAO;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Data;
using System.Windows.Input;

namespace Kazmierczak.Languer.UI
{
    public class CarListViewModel : INotifyPropertyChanged,IPageViewModel
    {
        private ObservableCollection<CarViewModel> _cars;
        private IDAO _dao;

        private RelayCommand _addCarCommand;

        public ObservableCollection<CarViewModel> Cars
        {
            get { return _cars; }
            set
            {
                _cars = value;
                RaisePropertyChanged("Cars");
            }
        }

        public CarListViewModel()
        {
            _cars = new ObservableCollection<CarViewModel>();
            _dao = new DAO.DAO(); // moze byc late binding, wydzielic do osobnej klasy i pobranie z niej obiektu dostepu do danych
            _view = (ListCollectionView)CollectionViewSource.GetDefaultView(_cars);
            FilterData = "";
            GetAllCars();

            _addCarCommand = new RelayCommand(param => this.AddCarToList());
            _saveNewCarCommand = new RelayCommand(param => this.SaveCar(), // bo argument to delegat Action
                                                  param => this.CanSaveCar());
            _filterDataCommand = new RelayCommand(param => this.DoFilterData());
            _groupCarsCommand = new RelayCommand(param => this.GroupByPrice());
        }

        private void GetAllCars()
        {
            foreach (var c in _dao.GetAllCars())
            {
                _cars.Add(new CarViewModel(c));
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;
        
        private void RaisePropertyChanged(string propertyName)
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
            }
        }

        public ICommand AddCarCommand
        {
            get { return _addCarCommand; } // wlasciwosc tylko do odczytu
        }

        private void AddCarToList()
        {
            ICar car = _dao.CreateNewCar();
            CarViewModel cvm = new CarViewModel(car);
            //_dao.AddCar(car);
            //Cars.Add(cvm);
            EditedCar = cvm; // nie dodajemy do listy jeszcze
        }

        // osobna komenda do tworzenia i zapisywania
        private ICommand _saveNewCarCommand;

        public ICommand SaveNewCarCommand
        {
            get { return _saveNewCarCommand; }
        }

        private CarViewModel _editedCar;

        public CarViewModel EditedCar
        {
            get { return _editedCar; }
            set
            {
                _editedCar = value;
                RaisePropertyChanged("EditedCar");
            }
        }

        private void SaveCar()
        {
            _cars.Add(_editedCar); // normalnie zapisać też do DAO
        }

        private bool CanSaveCar()
        {
            if (EditedCar == null)
                return false;

            if (EditedCar.HasErrors)
                return false;

            return true;
        }



        // filtrowanie

        private RelayCommand _filterDataCommand;

        public RelayCommand FilterDataCommand
        {
            get { return _filterDataCommand; }
        }

        private ListCollectionView _view;

        private string _filterData;

        public string FilterData
        {
            get { return _filterData; }
            set
            {
                _filterData = value;
                RaisePropertyChanged("FilterData");
            }
        }

        private void DoFilterData()
        {
            if(FilterData.Length > 0)
            {
                _view.Filter = (c) => ((CarViewModel)c).Name.Contains(FilterData);
            }
            else // wylacz wszystkie filtry
            {
                _view.Filter = null;
            }
        }

        // grupowanie
        private RelayCommand _groupCarsCommand;

        public RelayCommand GroupCarsCommand
        {
            get { return _groupCarsCommand; }
        }

        public string Name
        {
            get
            {
                return "CarList";
            }
        }

        private void GroupByPrice()
        {
            _view.SortDescriptions.Add(new SortDescription("Price", ListSortDirection.Ascending));
            _view.GroupDescriptions.Add(new PropertyGroupDescription("Price"));
        }
    }
}
