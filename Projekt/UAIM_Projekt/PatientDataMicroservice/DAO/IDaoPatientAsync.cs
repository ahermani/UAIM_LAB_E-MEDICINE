namespace PatientDataMicroservice.DAO
{
    using System;
    using System.Collections.Generic;
    using System.Threading.Tasks;
    using PatientDataMicroservice.DTO;
    using ModelClassLibrary;

    public interface IDaoPatientAsync : IDaoBaseAsync<Patient>
    {
        public Task<Patient> AppendAsync(PatientDTO obj);
        public Task<Patient> UpdateAsync(Guid id, PatientDTO obj);
    }
}