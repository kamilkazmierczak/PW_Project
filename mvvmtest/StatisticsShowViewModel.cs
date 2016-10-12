using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using Kazmierczak.Languer.Interfaces;

namespace Kazmierczak.Languer.UI
{
    public class StatisticsShowViewModel : ObservableObject
    {
        private DictionaryViewModel _selectedDictionary;
        private string _correctPercentage;
        private string _incorrectPercentage;
        private IDAO _dao;

        public StatisticsShowViewModel()
        {
            #if DEBUG
            if (DesignerProperties.GetIsInDesignMode(new DependencyObject())) return;
            #endif

            _dao = (IDAO)AssemblyLoader.GetDAOConstructor().Invoke(new object[] { });
            _correctPercentage = "";
            _incorrectPercentage = "";

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

        private void calculatePercentagesForSelectedDictionary()
        {
            decimal correctPercentage = _dao.GetCorrectAnswerPercentage(_selectedDictionary.getDictionary());
            decimal incorrectPercentage = 100 - correctPercentage;

            CorrectPercentage = correctPercentage.ToString("#.##") + "%";
            IncorrectPercentage = incorrectPercentage.ToString("#.##") + "%";

            if (correctPercentage == -1){
                correctPercentage = 0;
                incorrectPercentage = 0;
            }

            if (correctPercentage == 0)
                CorrectPercentage = "0%";

            if (incorrectPercentage == 0)
                IncorrectPercentage = "0%";



        }

        public DictionaryViewModel SelectedDictionary
        {
            get { return _selectedDictionary; }
            set
            {
                _selectedDictionary = value;
                Console.WriteLine("HOHOHO"+_selectedDictionary.Name);
                calculatePercentagesForSelectedDictionary();
                RaisePropertyChanged("SelectedDictionary");
            }
        }
    }
}
