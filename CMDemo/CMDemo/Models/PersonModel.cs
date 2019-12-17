namespace CMDemo.Models
{
    public class PersonModel
    {
        //A model that keeps the information about a person.
        public string FirstName { get; set; }

        public string LastName { get; set; }

        public string FullName
        {
            get
            {
                return FirstName + " " + LastName;
            }
        }
    }
}