using Caliburn.Micro;
using CMDemo.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CMDemo.ViewModels
{
    public class ThirdChildViewModel : Screen
    {
        public ThirdChildViewModel(PersonModel personModel)
        {
            _person = personModel;
        }

        private PersonModel _person;

        public PersonModel Person
        {
            get { return _person; }
            set 
            {
                _person = value;
                NotifyOfPropertyChange(nameof(Person));
            }
        }

        

    }
}
