using Caliburn.Micro;
using CMDemo.Models;
using System;
using System.Collections;
using System.Collections.Generic;

namespace CMDemo.ViewModels
{
    public class ShellViewModel : Conductor<object>
    {

        //Variables that we won't be changed/got directly ( only by using seters of geters).
        private string _firstName = "Will";
        private string _lastName;
        private PersonModel personModel;
        private BindableCollection<PersonModel> _people = new BindableCollection<PersonModel>();

        private PersonModel _person;

        private SecondChildViewModel _secondChildViewModel;
        public ShellViewModel(PersonModel personModel,SecondChildViewModel secondChildViewModel)
        {
            _person = personModel;

            //Adds new items to list people
            People.Add(new PersonModel { FirstName = "Will", LastName = "Smith" });
            People.Add(new PersonModel { FirstName = "Sue", LastName = "Johnes" });
            People.Add(new PersonModel { FirstName = "Robert", LastName = "Jackson" });

            //get from containter secondChildview
            _secondChildViewModel = secondChildViewModel;
        }

        //Binded to FirstName textbox.
        public string FirstName
        {
            get
            {
                return _firstName;
            }
            set
            {
                _firstName = value;
                NotifyOfPropertyChange(() => FirstName);
                NotifyOfPropertyChange(() => FullName);
            }
        }


        //Binded to LastName textbox.
        public string LastName
        {
            get
            {
                return _lastName;
            }
            set
            {
                _lastName = value;
                NotifyOfPropertyChange(() => LastName);
                NotifyOfPropertyChange(() => FullName);
            }
        }


        //Binded to FullName textblock.
        public string FullName
        {
            get
            {
                return $"{FirstName} {LastName}";
            }
        }

        //A list that can be binded to WPF controls
        public BindableCollection<PersonModel> People
        {
            get { return _people; }
            set { _people = value; }
        }


        //Binded to selected item form ComboBox.
        public PersonModel SelectedPerson
        {
            get { return personModel; }
            set 
            { 
                personModel = value;
                NotifyOfPropertyChange(() => SelectedPerson);
                NotifyOfPropertyChange(() => _secondChildViewModel.Person);
            }
        }


        //Explicitly check if button "CAN" be clicked, only if there are text to clear from textboxes. Below are different ways of implementation. (also with lambda expression =>).
        //public bool CanClearText(string firstName, string lastName) => !String.IsNullOrWhiteSpace(firstName) && !String.IsNullOrWhiteSpace(lastName);
        public bool CanClearText(string firstName, string lastName)
        {
            //return !String.IsNullOrWhiteSpace(firstName) || !String.IsNullOrWhiteSpace(lastName);

            if(String.IsNullOrWhiteSpace(firstName) && String.IsNullOrWhiteSpace(lastName))
            {
                return false;
            }
            else
            {
                return true;
            }
        }

        //Triggers on button name="ClearText" click
        public void ClearText(string firstName, string lastName)
        {
            FirstName = "";
            LastName = "";
        }


        //Events binded to buttons "LoadPageOne" and "LoadPageTwo"
        public void LoadPageOne()
        {
            ActivateItem(new FirstChildViewModel(SelectedPerson));
        }

        public void LoadPageTwo()
        {
            _secondChildViewModel.Person = SelectedPerson;
            ActivateItem(_secondChildViewModel);
        }

    }
}