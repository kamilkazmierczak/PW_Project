using Kazmierczak.Languer.UI.Properties;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace Kazmierczak.Languer.UI
{
    public static class AssemblyLoader
    {
        private static readonly ConstructorInfo _daoConstructor;

        static AssemblyLoader()
        {

            Assembly daoAssembly = Assembly.LoadFrom(new Settings().DAO);
            _daoConstructor = daoAssembly.GetTypes().FirstOrDefault(x => x.Name == "DAO").GetConstructor(new Type[] { });
        }

        public static ConstructorInfo GetDAOConstructor()
        {
            return _daoConstructor;
        }
    }
}
