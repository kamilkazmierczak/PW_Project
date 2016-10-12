using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace Kazmierczak.Languer.UI
{
    public class StatisticsShowViewModel : ObservableObject
    {
        private DictionaryViewModel _selectedDictionary;
        private string _correctPercentage;
        private string _incorrectPercentage;

        public StatisticsShowViewModel()
        {
            #if DEBUG
            if (DesignerProperties.GetIsInDesignMode(new DependencyObject())) return;
            #endif

            _correctPercentage = "A";
            _incorrectPercentage = "B";

        }

        public string CorrectPercentage
        {
            get { return _correctPercentage; }
            set
            {
                _correctPercentage = value;
                RaisePropertyChanged("CorrectPercentage");
            }
        }

        public string IncorrectPercentage
        {
            get { return _incorrectPercentage; }
            set
            {
                _incorrectPercentage = value;
                RaisePropertyChanged("IncorrectPercentage");
            }
        }

        public DictionaryViewModel SelectedDictionary
        {
            get { return _selectedDictionary; }
            set
            {
                _selectedDictionary = value;
                Console.WriteLine("HOHOHO"+_selectedDictionary.Name);
                RaisePropertyChanged("SelectedDictionary");
            }
        }
    }
}
