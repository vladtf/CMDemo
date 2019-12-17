using Caliburn.Micro;

namespace CMDemo.Helpers
{
    public class EventAggregatorHelper
    {
        public static IEventAggregator Event
        {
            get
            {
                return (IEventAggregator)IoC.GetInstance(typeof(IEventAggregator), null);
            }
            set { }
        }
    }
}