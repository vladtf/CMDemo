using Caliburn.Micro;
using CMDemo.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CMDemo.ViewModels
{
    public class FirstChildViewModel:Screen
    {

        //Gets the selected person from shellview
        public FirstChildViewModel(PersonModel personModel)
        {
            _personModel = personModel;
        }

        private PersonModel _personModel;

        public PersonModel PersonModel
        {
            get { return _personModel; }
        }

    }
}
