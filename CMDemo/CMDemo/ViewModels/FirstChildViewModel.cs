using Caliburn.Micro;
using CMDemo.Models;

namespace CMDemo.ViewModels
{
    public class FirstChildViewModel : Screen
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