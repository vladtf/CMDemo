using Caliburn.Micro;
using CMDemo.EventAggregatorMessages;
using CMDemo.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CMDemo.ViewModels
{
    public class AnotherChildViewModel : Screen, IHandle<PersonModel>
    {
        private readonly IEventAggregator _eventAggregator;
        public AnotherChildViewModel(IEventAggregator eventAggregator, PersonModel personModel, FirstChildViewModel firstChildViewModel)
        {

            _eventAggregator = eventAggregator;
            _eventAggregator.Subscribe(this);
            _person = personModel;
        }

        public void Handle(PersonModel message)
        {
            Person = message;
            NavigateToAnotherView navigateToMessage = new NavigateToAnotherView();
            _eventAggregator.PublishOnUIThread(navigateToMessage);
        }

        private PersonModel _person;

        public PersonModel Person
        {
            get { return _person; }
            set 
            { 
                _person = value;
                NotifyOfPropertyChange(() => Person);
            }
        }


        public void Show()
        {
            Console.WriteLine();
        }

        protected override void OnActivate()
        {
            //_eventAggregator.PublishOnUIThread("Hello from Page");
        }

        //Creating bugs, need to fix.

        ////protected override void OnDeactivate(bool close)
        ////{
        ////    _eventAggregator.Unsubscribe(this);
        ////}

    }
}
