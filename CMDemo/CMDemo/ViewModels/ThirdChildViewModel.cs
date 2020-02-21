using Caliburn.Micro;
using CMDemo.Models;

namespace CMDemo.ViewModels
{
    public class ThirdChildViewModel : Screen
    {

        #region Private fiels
        #endregion

        #region Public fields
        public PersonModel Person
        {
            get { return _person; }
            set
            {
                _person = value;
            }
        }
        #endregion

        private PersonModel _person;

        public ThirdChildViewModel(PersonModel personModel)
        {
            _person = personModel;
        }

        public void UpdateThis()
        {
            _person = (PersonModel)IoC.GetInstance(typeof(PersonModel), null);
            NotifyOfPropertyChange(nameof(Person));
        }


    }
}