using Autofac;
using Caliburn.Micro;
using CMDemo.Helpers;
using CMDemo.Models;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Windows;

namespace CMDemo.ViewModels
{
    public class ShellViewModel : Conductor<object>
    {

        //Variables that we won't be changed/got directly ( only by using seters of geters).
        private string _firstName = "Will";
        private string _lastName;

        private BindableCollection<PersonModel> _people = new BindableCollection<PersonModel>();

        private PersonModel _selectedPerson;

        public ShellViewModel()
        {

            //Adds new items to list people
            People.Add(new PersonModel { FirstName = "Will", LastName = "Smith" });
            People.Add(new PersonModel { FirstName = "Sue", LastName = "Johnes" });
            People.Add(new PersonModel { FirstName = "Robert", LastName = "Jackson" });

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
                NotifyOfPropertyChange(nameof(FullName));
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
            get { return _selectedPerson; }
            set
            {
                _selectedPerson = value;
                IoC.GetInstance(typeof(PersonModel), "");
                NotifyOfPropertyChange(() => SelectedPerson);
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
            ActivateItem(null);
            SecondChildViewModel secondChild = (SecondChildViewModel)IoC.GetInstance(typeof(SecondChildViewModel), "");
            secondChild.Person = SelectedPerson;
            ActivateItem(secondChild);
        }

        public void LoadPageThree()
        {
            ThirdChildViewModel thirdChild = (ThirdChildViewModel) IoC.GetInstance(typeof(ThirdChildViewModel), null);
            ActivateItem(thirdChild);
        }


        //a void method using lambda expression
        //public void ShowMessage() => MessageBox.Show("Using lambda expression.");

        public void ShowMessage()
        {

            SimpleContainer simpleContainer = (SimpleContainer)IoC.GetInstance(typeof(SimpleContainer), null);

            PersonModel personModel1 = new PersonModel { FirstName = "asdtg1" };
            PersonModel personModel2 = new PersonModel { FirstName = "asdtg2" };

            ContainerHelper.RegisterInstance(typeof(PersonModel), personModel1);
            ContainerHelper.RegisterInstance(typeof(PersonModel), personModel2);
            ////simpleContainer.BuildUp(personModel1);
            //simpleContainer.RegisterInstance(typeof(PersonModel), "person", personModel1);
            //simpleContainer.UnregisterHandler(typeof(PersonModel), "person");
            //simpleContainer.RegisterInstance(typeof(PersonModel), "person", personModel2);
            PersonModel personModel = (PersonModel) IoC.GetInstance(typeof(PersonModel),null);
            Console.WriteLine();
        }



    }
}