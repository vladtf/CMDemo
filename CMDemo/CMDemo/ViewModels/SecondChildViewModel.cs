using Caliburn.Micro;
using CMDemo.Models;

namespace CMDemo.ViewModels
{
    public class SecondChildViewModel : Screen
    {

        #region Private fiels
        private PersonModel _person;
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

        public SecondChildViewModel()
        {
        }


    }
}