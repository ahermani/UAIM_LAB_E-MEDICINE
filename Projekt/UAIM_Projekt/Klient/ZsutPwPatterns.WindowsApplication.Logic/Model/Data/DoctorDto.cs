namespace ZsutPw.Patterns.WindowsApplication.Model
{
    using ModelClassLibrary;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;

    public class DoctorDto
    {
        public Guid Id { get; set; }
        public string Name { get; set; }

        public string Surname { get; set; }

        public DateTime Birthday { get; set; }

        public Gender Gender { get; set; }

        public string PhoneNumber { get; set; }

        public string Email { get; set; }
        public List<int> Specialization { get; set; }

        public string Room { get; set; }


    }
};

