using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using DoctorsDataMicroservice.DTO;
using ModelClassLibrary;
using XMLDatabase;

namespace DoctorsDataMicroservice.DAO
{
    public class DaoDoctorXMLAsync : IDaoDoctorAsync
    {

        private readonly ISerializer<Doctor> _serializer;

        public DaoDoctorXMLAsync()
        {
            _serializer = new DoctorSerializer();
        }

        public async Task<IEnumerable<Doctor>> GetAllAsync()
        {
            return await Task.Run(() => _serializer.Deserialize());
        }

        public async Task<Doctor> GetByIdAsync(Guid id)
        {
            return await Task.Run(() =>
            {
                return _serializer.Deserialize().FirstOrDefault(doctor => doctor.Id.Equals(id));
            });
        }

        public async Task<Doctor> AppendAsync(DoctorDTO doc)
        {
            return await Task.Run(() =>
            {
               Doctor obj = new Doctor(Guid.NewGuid(), doc.Name, doc.Surname, doc.Birthday, doc.Gender, doc.PhoneNumber, doc.Email, doc.Specialization, doc.Room);
               var doctors = _serializer.Deserialize().Append(obj).ToList();
                _serializer.Serialize(doctors);
                return obj;
            });
        }

        public async Task<IEnumerable<Doctor>> DeleteAsync(Guid id)
        {
            return await Task.Run(() =>
            {
                var doctors = _serializer.Deserialize().ToList();
                doctors.RemoveAll(x => x.Id == id);
                _serializer.Serialize(doctors);
                return doctors;
            });
        }

        public async Task<Doctor> UpdateAsync(Guid id, DoctorDTO doc)
        {
            return await Task.Run(() =>
            {
                var doctors = _serializer.Deserialize().ToList();
                var doctorId = doctors.FindIndex(x => x.Id == id);
                Doctor obj = new Doctor(id, doc.Name, doc.Surname, doc.Birthday, doc.Gender, doc.PhoneNumber, doc.Email, doc.Specialization, doc.Room);
                doctors[doctorId] = obj;
                _serializer.Serialize(doctors);
                return doctors[doctorId];
            });
        }

        public async Task<IEnumerable<Doctor>> GetAllBySpecialization(int id)
        {
            return await Task.Run(() => _serializer.Deserialize()
               .Where(
                   doctor => doctor.Specialization.Contains(id))
            );
        }
    }
}