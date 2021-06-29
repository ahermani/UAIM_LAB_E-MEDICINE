namespace ZsutPw.Patterns.WindowsApplication.Model
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;

    public class DoctorDto
    {
        public double Wage { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
        public IEnumerable<string> Specializations { get; set; }

    }
};

