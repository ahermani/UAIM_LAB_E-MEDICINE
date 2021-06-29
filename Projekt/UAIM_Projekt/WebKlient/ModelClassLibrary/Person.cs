using System.Xml.Serialization;

namespace ModelClassLibrary
{
    using System;

    public abstract class Person
    {
        public Person(Guid id, string name, string surname, DateTime birthday, Gender gender, string phoneNumber,
            string email)
        {
            Id = id;
            Name = name ?? throw new ArgumentNullException(nameof(name));
            Surname = surname ?? throw new ArgumentNullException(nameof(surname));
            Birthday = birthday;
            Gender = gender;
            PhoneNumber = phoneNumber ?? throw new ArgumentNullException(nameof(phoneNumber));
            Email = email ?? throw new ArgumentNullException(nameof(email));
        }
        
        public Person() {}

        
        public Guid Id { get; set; }
        
        public string Name { get; set; }
        
        public string Surname { get; set; }
        
        public DateTime Birthday { get; set; }
        
        public Gender Gender { get; set; }
        
        public string PhoneNumber { get; set; }
        
        public string Email { get; set; }
    }
}