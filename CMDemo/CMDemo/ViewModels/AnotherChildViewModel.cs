using Caliburn.Micro;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CMDemo.ViewModels
{
    class AnotherChildViewModel : Screen
    {
        private readonly IEventAggregator _eventAggregator;
        public AnotherChildViewModel(IEventAggregator eventAggregator)
        {
            _eventAggregator = eventAggregator;
        }

        public void Show()
        {
            _eventAggregator.PublishOnUIThread("Hello from Page");
        }
    }
}
