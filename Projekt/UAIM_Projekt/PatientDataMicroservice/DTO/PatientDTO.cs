using ModelClassLibrary;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PatientDataMicroservice.DTO
{
    public class PatientDTO
    {
        public string Name { get; set; }

        public string Surname { get; set; }

        public DateTime Birthday { get; set; }

        public Gender Gender { get; set; }

        public string PhoneNumber { get; set; }

        public string Email { get; set; }

        public string Pesel { get; set; }

        public DateTime RegistrationDate { get; set; }

        public Blood BloodType { get; set; }

        public bool IsActive { get; set; }
    }
}
