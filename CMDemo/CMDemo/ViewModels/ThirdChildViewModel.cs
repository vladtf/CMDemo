using Caliburn.Micro;
using CMDemo.Models;
using System;

namespace CMDemo.ViewModels
{
    public class ThirdChildViewModel : Screen
    {
        public ThirdChildViewModel()
        {
        }

        private PersonModel _person = (PersonModel) IoC.GetInstance(typeof(PersonModel),"");


        public void UpdateThis()
        {
            Console.WriteLine(_person);
        }

        //public string FirstName
        //{
        //    get { return _person.FirstName; }
        //    set
        //    {
        //        _person.FirstName = value;
        //        NotifyOfPropertyChange(()=>FirstName);
        //    }
        //}

        //public string LastName
        //{
        //    get { return _person.LastName; }
        //    set 
        //    { 
        //        _person.FirstName = value;
        //        NotifyOfPropertyChange(LastName);
        //    }
        //}
    }
}