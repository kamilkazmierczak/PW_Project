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

        public StatisticsShowViewModel()
        {
            #if DEBUG
            if (DesignerProperties.GetIsInDesignMode(new DependencyObject())) return;
            #endif


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
