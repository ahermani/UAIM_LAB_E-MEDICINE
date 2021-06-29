using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Zsut.Patterns.CSharp;

namespace ExaminationRooms.Domain.ExaminationRoomAggregate
{
    public interface IDoctorRepository
    {
        IEnumerable<Doctor> GetAll();
        IEnumerable<Doctor> GetBySpecialityNumber(int specialityNumber);
        void AddDoctor(Doctor doctor);
    }
}
