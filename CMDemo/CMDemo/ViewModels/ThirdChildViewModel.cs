using Caliburn.Micro;
using CMDemo.Models;
using System;

namespace CMDemo.ViewModels
{
    public class ThirdChildViewModel : Screen
    {
        public ThirdChildViewModel(PersonModel personModel)
        {
            _person = personModel;
            _person.FirstName = "thirdchild";
        }

        public void UpdateThis()
        {
             _person = (PersonModel)IoC.GetInstance(typeof(PersonModel), null);
            NotifyOfPropertyChange(nameof(Person));
             Console.WriteLine(_person);
        }

        private PersonModel _person;

        public PersonModel Person
        {
            get { return _person; }
            set { _person = value; }
        }

    }
}