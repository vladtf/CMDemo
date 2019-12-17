using Caliburn.Micro;
using CMDemo.Models;

namespace CMDemo.ViewModels
{
    public class SecondChildViewModel : Screen
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
            }
        }
    }
}