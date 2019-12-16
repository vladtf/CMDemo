using Caliburn.Micro;
using CMDemo.Models;
using System;

namespace CMDemo.ViewModels
{
    public class ThirdChildViewModel : Screen
    {
        public ThirdChildViewModel(PersonModel personModel, ToUpdate toUpdate)
        {
            _toUpdate = toUpdate;
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

        private ToUpdate _toUpdate;


        public bool NeedUpdate
        {
            get { return _toUpdate.NeedUpdate; }
            set 
            { 
                _toUpdate.NeedUpdate = value;
                if (value)
                    UpdateThis();
            }
        }



    }
}