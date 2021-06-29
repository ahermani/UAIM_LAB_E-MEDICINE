using ModelClassLibrary;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ZsutPw.Patterns.WindowsApplication.Model
{
    public class PatientDto
    {
        public Guid Id { get; set; }
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
