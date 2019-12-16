using Caliburn.Micro;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CMDemo.Helpers
{
    public class EventAggregatorHelper
    {
        public static IEventAggregator Event { 
            get 
            {
                return (IEventAggregator) IoC.GetInstance(typeof(IEventAggregator),null);
            }
            set { }
        }
    }
}
