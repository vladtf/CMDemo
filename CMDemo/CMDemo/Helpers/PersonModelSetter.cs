using CMDemo.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CMDemo.Helpers
{
    class PersonModelSetter
    {
        public static void Swap(PersonModel newPerson, PersonModel oldPerson )
        {
            newPerson.FirstName = oldPerson.FirstName;
            newPerson.LastName = oldPerson.LastName;
        }
    }
}
