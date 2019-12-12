namespace CMDemo.Models
{
    public class PersonModel
    {
        //A model that keeps the information about a person.
        public string FirstName { get; set; }

        public string LastName { get; set; }

        public PersonModel person
        {
            get
            {
                PersonModel model = new PersonModel { FirstName = "Vlad", LastName = "Tf" };
                return model;
            }
    }
}
}