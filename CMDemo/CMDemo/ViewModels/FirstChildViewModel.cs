using Caliburn.Micro;
using CMDemo.Models;

namespace CMDemo.ViewModels
{
    public class FirstChildViewModel : Screen
    {

        #region Private fiels
        private PersonModel _personModel;
        #endregion
        #region Public fields
        public PersonModel PersonModel
        {
            get { return _personModel; }
        }
        #endregion

        //Gets the selected person from shellview
        public FirstChildViewModel(PersonModel personModel)
        {
            _personModel = personModel;
        }


    }
}