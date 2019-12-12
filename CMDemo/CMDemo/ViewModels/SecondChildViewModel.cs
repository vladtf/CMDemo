using Caliburn.Micro;
using CMDemo.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CMDemo.ViewModels
{
    public class SecondChildViewModel:Screen
    {
        public SecondChildViewModel()
        {
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

    }
}
