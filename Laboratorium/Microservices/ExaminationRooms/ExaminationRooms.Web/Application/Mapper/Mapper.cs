namespace ExaminationRooms.Web.Application.Mapper
{
    using ExaminationRooms.Domain.ExaminationRoomAggregate;
    using ExaminationRooms.Web.Application.Dtos;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;
    using Zsut.Patterns.CSharp;

    public static class Mapper
    {
        public static ExaminationRoomDto Map(this ExaminationRoom examinationRoom)
        {
            if (examinationRoom == null)
                return null;

            return new ExaminationRoomDto
            {
                Number = examinationRoom.Number,
                Certifications = examinationRoom?.Certifications.Select(s => s.Type)
            };
        }

        public static DoctorDto Map(this Doctor doctor)
        {
            if (doctor == null)
                return null;

            return new DoctorDto
            {
                Specializations = doctor?.Specializations.Select(s => s.Number.ToString()),
                Wage = doctor.Wage,
                Name = doctor.Name,
                Surname = doctor.Surname
            };
        }

    }
}
