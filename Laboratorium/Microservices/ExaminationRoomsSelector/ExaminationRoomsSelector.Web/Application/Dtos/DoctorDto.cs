namespace ExaminationRoomsSelector.Web.Application.Dtos
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

        public DoctorDto(string name, string surname, double wage, IEnumerable<string> specializations)
        {
            Name = name;
            Surname = surname;
            Wage = wage;
            Specializations = specializations;
        }


    }
};

