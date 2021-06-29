namespace PatientAppMicroservice.DataServiceClients
{
    using ModelClassLibrary;
    using PatientAppMicroservice.Dtos;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;


    public interface IDoctorsServiceClient
    {
        Task<IEnumerable<Doctor>> GetAllDoctorsAsync();
        Task<Doctor> GetDoctorByIdAsync(Guid id);
    }
}
