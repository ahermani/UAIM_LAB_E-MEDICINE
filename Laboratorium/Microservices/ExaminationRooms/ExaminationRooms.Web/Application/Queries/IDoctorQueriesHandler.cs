namespace ExaminationRooms.Web.Application.Queries
{
    using ExaminationRooms.Web.Application.Dtos;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;

    public interface IDoctorQueriesHandler
    {
        IEnumerable<DoctorDto> GetAll();
        IEnumerable<DoctorDto> GetBySpecialityNumber(int specialityNumber);
    }
}
