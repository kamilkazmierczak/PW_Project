using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using Kazmierczak.Languer.Interfaces;


namespace Kazmierczak.Languer.UI
{
    public class ApplicationViewModel : ObservableObject
    {
        private ICommand _changePageCommand;
        private IPageViewModel _currentPageViewModel;
        private List<IPageViewModel> _pageViewModels;


        public ApplicationViewModel()
        {
            //all pages
            PageViewModels.Add(new HomeViewModel());
            PageViewModels.Add(new CarListViewModel());
            PageViewModels.Add(new LoginViewModel());
            PageViewModels.Add(new DictionaryWindowViewModel());
            PageViewModels.Add(new StudyWindowViewModel());
            PageViewModels.Add(new StatisticsWindowViewModel());

            CurrentPageViewModel = PageViewModels[0];           
        }

        #region Properties / Commands
        public List<IPageViewModel> PageViewModels
        {
            get
            {
                if (_pageViewModels == null)
                    _pageViewModels = new List<IPageViewModel>();

                return _pageViewModels;
            }
        }

        public IPageViewModel CurrentPageViewModel
        {
            get
            {
                return _currentPageViewModel;
            }
            set
            {
                if (_currentPageViewModel != value)
                {
                    _currentPageViewModel = value;
                    RaisePropertyChanged("CurrentPageViewModel");
                }
            }
        }

        public ICommand ChangePageCommand
        {
            get
            {
                if (_changePageCommand == null)
                {
                    _changePageCommand = new RelayCommand(
                        p => ChangeViewModel((IPageViewModel)p),
                        p => p is IPageViewModel);
                }

                return _changePageCommand;
            }
        }
        #endregion

        #region Methods
        private void ChangeViewModel(IPageViewModel viewModel)
        {
            if (!PageViewModels.Contains(viewModel))
                PageViewModels.Add(viewModel);

            CurrentPageViewModel = PageViewModels
                .FirstOrDefault(vm => vm == viewModel);
        }
        #endregion

    }
}
