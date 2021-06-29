namespace ExaminationRooms.Web.Application.Queries
{
    using ExaminationRooms.Domain.ExaminationRoomAggregate;
    using ExaminationRooms.Web.Application.Dtos;
    using ExaminationRooms.Web.Application.Mapper;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;
    using Zsut.Patterns.CSharp;

    public class DoctorQueriesHandler : IDoctorQueriesHandler
    {
        private readonly IDoctorRepository doctorRepository;

        public DoctorQueriesHandler(IDoctorRepository doctorRepository)
        {
            this.doctorRepository = doctorRepository;
        }

        public IEnumerable<DoctorDto> GetAll()
        {
            return doctorRepository.GetAll().Select(ld => ld.Map());
        }

        public IEnumerable<DoctorDto> GetBySpecialityNumber(int specialityNumber)
        {
            return doctorRepository.GetBySpecialityNumber(specialityNumber).Select(ld => ld.Map());
        }
    }
}
