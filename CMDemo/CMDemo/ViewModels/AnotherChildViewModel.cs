using Caliburn.Micro;
using CMDemo.EventAggregatorMessages;
using CMDemo.Models;
using System;

namespace CMDemo.ViewModels
{
    public class AnotherChildViewModel : Conductor<Object>, IHandle<PersonModel>,IHandle<NavigateToMessage>
    {
        private readonly IEventAggregator _eventAggregator;

        public AnotherChildViewModel(IEventAggregator eventAggregator, PersonModel personModel, FirstChildViewModel firstChildViewModel, ThirdChildViewModel thirdChildViewModel)
        {
            _eventAggregator = eventAggregator;
            _eventAggregator.Subscribe(this);
            _person = personModel;
            _thirdChildViewModel = thirdChildViewModel;
        }

        public void Handle(PersonModel message)
        {
            Person = message;
            NavigateToMessage navigateToMessage = new NavigateToMessage(NavigateToEnum.AnotherChildView);
            _eventAggregator.PublishOnUIThread(navigateToMessage);
        }

        private PersonModel _person;
        private readonly ThirdChildViewModel _thirdChildViewModel;

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

        public void Handle(NavigateToMessage message)
        {
            if (message.NavigateToEnum == NavigateToEnum.ThirdChildView)
                ActivateItem(_thirdChildViewModel);

        }

        //Creating bugs, need to fix.

        ////protected override void OnDeactivate(bool close)
        ////{
        ////    _eventAggregator.Unsubscribe(this);
        ////}
    }
}