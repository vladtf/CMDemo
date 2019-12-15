using Caliburn.Micro;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CMDemo.Helpers
{
    public class ContainerHelper
    {
        public static void RegisterInstance(object implementation)
        {
            SimpleContainer _container = (SimpleContainer)IoC.GetInstance(typeof(SimpleContainer), null);

            Type type = implementation.GetType();

            _container.UnregisterHandler(type, null);
            _container.RegisterInstance(type, null, implementation);
        }

    }
}
