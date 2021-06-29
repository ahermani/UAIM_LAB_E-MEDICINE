namespace ExaminationRooms.Web.Application.Dtos
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;

    public class DoctorDto
    {
        public String Name { get; set; }
        public String Surname { get; set; }
        public IEnumerable<string> Specializations { get; set; }
        public double Wage { get; set; }


    }
}
