namespace Zsut.Patterns.CSharp
{
    using System.Collections.Generic;
    using System.Linq;

    public class PersonRepository : IPersonRepository
    {
        #region Properties and Fields

        private readonly Person[] people = new Person[]
        {
      //new Patient( "Jan","Nowak","00000000002",PersonGender.Male,1 ),
      //new Doctor("Adam","Kowalski","00000000000",PersonGender.Male,5000.00,"Lekarz"),
      //new Doctor("Aleksandra","Kowalska","00000000001",PersonGender.Female,5000.00,"Lekarz")
        };

        #endregion


        #region Methods

        public Person[] Find(PersonGender gender)
        {
            IList<Person> foundPeople = people.Where(s => s.Gender == gender).ToList();

            return foundPeople.ToArray();
        }

        #endregion
    }
}
