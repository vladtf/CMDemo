using CMDemo.Models;

namespace CMDemo.Helpers
{
    internal class PersonModelSetter
    {
        public static void Swap(PersonModel newPerson, PersonModel oldPerson)
        {
            newPerson.FirstName = oldPerson.FirstName;
            newPerson.LastName = oldPerson.LastName;
        }
    }
}