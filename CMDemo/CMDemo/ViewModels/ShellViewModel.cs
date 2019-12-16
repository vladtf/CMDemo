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
    public class ShellViewModel : Conductor<object>,IHandle<string>
    {

        //Variables that we won't be changed/got directly ( only by using seters of geters).
        private string _firstName = "Will";
        private string _lastName;

        private BindableCollection<PersonModel> _people = new BindableCollection<PersonModel>();

        private PersonModel _selectedPerson;

        private ThirdChildViewModel _thirdChild;

        private readonly IEventAggregator _eventAggregator;

        public ShellViewModel(ThirdChildViewModel thirdChildViewModel, PersonModel personModel, IEventAggregator eventAggregator)
        {
            _thirdChild = thirdChildViewModel;
            _selectedPerson = personModel;

            //Adds new items to list people
            People.Add(new PersonModel { FirstName = "Will", LastName = "Smith" });
            People.Add(new PersonModel { FirstName = "Sue", LastName = "Johnes" });
            People.Add(new PersonModel { FirstName = "Robert", LastName = "Jackson" });

            _eventAggregator = eventAggregator;
            _eventAggregator.Subscribe(this);

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


        //Events binded to buttons
        public void LoadPageOne()
        {
            ActivateItem(new FirstChildViewModel(SelectedPerson));
        }

        public void LoadPageTwo()
        {
            ActivateItem(null);
            SecondChildViewModel _secondChild = IoC.Get<SecondChildViewModel>();
            _secondChild.Person = SelectedPerson;
            ActivateItem(_secondChild);
        }

        public void LoadPageThree()
        {
            ActivateItem(_thirdChild);
        }

        public void LoadAnotherPage()
        {
            AnotherChildViewModel anotherChildViewModel = (AnotherChildViewModel)IoC.GetInstance(typeof(AnotherChildViewModel), null);
            ActivateItem(anotherChildViewModel);
        }
        public void PeopleSelecting()
        {
            ContainerHelper.RegisterInstance(_selectedPerson);
            _thirdChild.UpdateThis();
        }

        //a void method using lambda expression
        //public void ShowMessage() => MessageBox.Show("Using lambda expression.");


        //For debugging container features.
        public void ShowMessage()
        {

            //SimpleContainer simpleContainer = (SimpleContainer)IoC.GetInstance(typeof(SimpleContainer), null);

            //PersonModel personModel3 = (PersonModel)IoC.GetInstance(typeof(PersonModel), null);

            //personModel3.FirstName = "3";

            //personModel3 = (PersonModel)IoC.GetInstance(typeof(PersonModel), null);

            //PersonModel personModel1 = new PersonModel { FirstName = "asdtg1" };
            //PersonModel personModel2 = new PersonModel { FirstName = "asdtg2" };

            //ContainerHelper.RegisterInstance(personModel1);
            //ContainerHelper.RegisterInstance(personModel2);
            //////simpleContainer.BuildUp(personModel1);
            ////simpleContainer.RegisterInstance(typeof(PersonModel), "person", personModel1);
            ////simpleContainer.UnregisterHandler(typeof(PersonModel), "person");
            ////simpleContainer.RegisterInstance(typeof(PersonModel), "person", personModel2);
            //PersonModel personMode4 = (PersonModel) IoC.GetInstance(typeof(PersonModel),null);
            Console.WriteLine();
        }

        public void Handle(string message)
        {
            MessageBox.Show(message);
        }
    }
}