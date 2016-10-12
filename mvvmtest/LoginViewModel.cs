using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Kazmierczak.Languer.Interfaces;

namespace Kazmierczak.Languer.UI
{
    public class LoginViewModel : ObservableObject, IPageViewModel
    {

        public string Name
        {
            get
            {
                return "Login Page";
            }
        }
    }
}
