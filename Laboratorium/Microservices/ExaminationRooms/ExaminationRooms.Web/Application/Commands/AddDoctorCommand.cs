namespace ExaminationRooms.Web.Application.Commands
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;
    using Zsut.Patterns.CSharp;

    //wykorzystujemy interfejs wskaźnikowy ICommand do jawnego wskazania, że dana klasa jest komendą
    public class AddDoctorCommand : ICommand
    {
        public string Name { get; set; }
        public string Surname { get; set; }
        public string Pesel { get; set; }
        public String Gender { get; set; }
        public double Wage { get; set; }
        public IEnumerable<int> Specializations { get; set; }
    }
}
