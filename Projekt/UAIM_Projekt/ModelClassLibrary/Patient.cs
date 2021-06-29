using System;
using System.Xml.Serialization;

namespace ModelClassLibrary
{
    public class Patient : Person
    {
        public Patient(Guid id, string name, string surname, DateTime birthday, Gender gender, string phoneNumber, string email, string pesel, DateTime registrationDate, Blood bloodType, bool isActive) : base(id, name, surname, birthday, gender, phoneNumber, email)
        {
            Pesel = pesel;
            RegistrationDate = registrationDate;
            BloodType = bloodType;
            IsActive = isActive;
        }

        public Patient() {}
        
        
        public string Pesel { get; set; }
        
        public DateTime RegistrationDate { get; set; }
        
        public Blood BloodType { get; set; }
        
        public bool IsActive { get; set; }
    }
}