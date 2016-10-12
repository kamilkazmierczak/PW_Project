using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Kazmierczak.Languer.Interfaces;
using System.ComponentModel;
using System.Windows;

namespace Kazmierczak.Languer.UI
{
    public class StatisticsWindowViewModel : ObservableObject, IPageViewModel
    {

        private DictionaryListViewModel _dictionaryListViewModel;
        private StatisticsShowViewModel _statisticsShowViewModel;

        public StatisticsWindowViewModel()
        {
            #if DEBUG
            if (DesignerProperties.GetIsInDesignMode(new DependencyObject())) return;
            #endif

            _statisticsShowViewModel = new StatisticsShowViewModel();
            _dictionaryListViewModel = new DictionaryListViewModel();
        }


        public StatisticsShowViewModel StatisticsShowViewModel
        {
            get { return _statisticsShowViewModel; }
            set
            {
                _statisticsShowViewModel = value;
                RaisePropertyChanged("StatisticsShowViewModel");
            }
        }

        public DictionaryListViewModel DictionaryListViewModel
        {
            get { return _dictionaryListViewModel; }
            set
            {
                _dictionaryListViewModel = value;
                RaisePropertyChanged("DictionaryListViewModel");
            }
        }

      
        public string Name
        {
            get
            {
                return "Statistics";
            }
        }
    }
}
