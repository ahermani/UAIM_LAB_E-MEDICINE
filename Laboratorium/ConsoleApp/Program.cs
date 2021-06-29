namespace ConsoleApp
{
    using System;
    using System.Diagnostics;
    using Zsut.Patterns.CSharp;

    public class Program
    {
        public static void Main(string[] args)
        {
            IPersonRepository personRepository = new PersonRepository() as IPersonRepository;
            Debug.Assert(condition: personRepository != null);

            foreach (var person in personRepository.Find(PersonGender.Male))
            {

                string personDescription = person.GetDescription();

                Console.WriteLine("Person description = {0};", personDescription);
            }
            Console.ReadLine();
        }
    }
}
