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
        }

        public void UpdateThis()
        {
             _person = (PersonModel)IoC.GetInstance(typeof(PersonModel), null);
            NotifyOfPropertyChange(nameof(Person));
        }

        private PersonModel _person;

        public PersonModel Person
        {
            get { return _person; }
            set 
            { 
                _person = value;
            }
        }




    }
}