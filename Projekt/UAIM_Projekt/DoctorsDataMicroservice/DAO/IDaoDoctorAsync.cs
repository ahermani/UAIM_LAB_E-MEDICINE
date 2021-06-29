namespace DoctorsDataMicroservice.DAO
{
    using System;
    using System.Collections.Generic;
    using System.Threading.Tasks;
    using DoctorsDataMicroservice.DTO;
    using ModelClassLibrary;

    public interface IDaoDoctorAsync : IDaoBaseAsync<Doctor>
    {
        public Task<IEnumerable<Doctor>> GetAllBySpecialization(int id);
        public Task<Doctor> AppendAsync(DoctorDTO obj);
        public Task<Doctor> UpdateAsync(Guid id, DoctorDTO obj);
    }
}