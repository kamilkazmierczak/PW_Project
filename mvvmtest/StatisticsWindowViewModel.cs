using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Kazmierczak.Languer.Interfaces;

namespace Kazmierczak.Languer.UI
{
    public class StatisticsWindowViewModel : ObservableObject, IPageViewModel
    {

        public string Name
        {
            get
            {
                return "Statistics";
            }
        }
    }
}
