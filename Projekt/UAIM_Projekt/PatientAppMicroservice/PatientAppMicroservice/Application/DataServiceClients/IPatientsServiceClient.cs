namespace PatientAppMicroservice.DataServiceClients
{
    using ModelClassLibrary;
    using PatientAppMicroservice.Dtos;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;

    public interface IPatientsServiceClient
    {
        Task<IEnumerable<Patient>> GetAllPatientsAsync();
        Task<Patient> GetPatientByIdAsync(Guid id);
        Task<Patient> UpdatePatientAsync(Guid id, PatientDto patient);
    }
}
