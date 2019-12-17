using Caliburn.Micro;
using System;

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