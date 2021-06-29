using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using PatientDataMicroservice.DTO;
using ModelClassLibrary;
using XMLDatabase;

namespace PatientDataMicroservice.DAO
{
    public class DaoPatientXMLAsync : IDaoPatientAsync
    {

        private readonly ISerializer<Patient> _serializer;

        public DaoPatientXMLAsync()
        {
            _serializer = new PatientSerializer();
        }

        public async Task<IEnumerable<Patient>> GetAllAsync()
        {
            return await Task.Run(() => _serializer.Deserialize());
        }

        public async Task<Patient> GetByIdAsync(Guid id)
        {
            return await Task.Run(() =>
            {
                Patient patient = _serializer.Deserialize().FirstOrDefault(patient => patient.Id.Equals(id));
                if (patient == default(Patient)) return null;
                return patient;
            });
        }

        public async Task<Patient> AppendAsync(PatientDTO pat)
        {
            return await Task.Run(() =>
            {
               Patient obj = new Patient(Guid.NewGuid(), pat.Name, pat.Surname, pat.Birthday, pat.Gender, pat.PhoneNumber, pat.Email, pat.Pesel, pat.RegistrationDate,  pat.BloodType, pat.IsActive);
               var patients = _serializer.Deserialize().Append(obj).ToList();
                _serializer.Serialize(patients);
                return obj;
            });
        }

        public async Task<IEnumerable<Patient>> DeleteAsync(Guid id)
        {
            return await Task.Run(() =>
            {
                var patient = _serializer.Deserialize().ToList();
                if (patient.RemoveAll(x => x.Id == id) == 0)
                    return null;
                else
                {
                    _serializer.Serialize(patient);
                    return patient;
                }
            });
        }

        public async Task<Patient> UpdateAsync(Guid id, PatientDTO pat)
        {
            return await Task.Run(() =>
            {
                var patients = _serializer.Deserialize().ToList();
                var patientId = patients.FindIndex(x => x.Id == id);
                if (patientId == -1) return null;
                else
                {
                    Patient obj = new Patient(id, pat.Name, pat.Surname, pat.Birthday, pat.Gender, pat.PhoneNumber, pat.Email, pat.Pesel, pat.RegistrationDate, pat.BloodType, pat.IsActive);
                    patients[patientId] = obj;
                    _serializer.Serialize(patients);
                    return patients[patientId];
                }
            });
        }

    }
}