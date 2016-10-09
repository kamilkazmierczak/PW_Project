using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Kazmierczak.Languer.Interfaces;

namespace Kazmierczak.Languer.UI
{
    public class HomeViewModel : INotifyPropertyChanged, IPageViewModel
    {
        public string Name
        {
            get
            {
                return "Home Page";
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
    }
}
