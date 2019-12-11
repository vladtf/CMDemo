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

        public FirstChildViewModel(PersonModel personModel)
        {
            this.personModel = personModel;
        }

        private PersonModel personModel;

        public PersonModel PersonModel
        {
            get { return personModel; }
        }

    }
}
