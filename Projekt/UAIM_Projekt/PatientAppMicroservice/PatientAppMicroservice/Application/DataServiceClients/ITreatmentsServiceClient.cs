namespace PatientAppMicroservice.DataServiceClients
{
    using ModelClassLibrary;
    using PatientAppMicroservice.Dtos;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;


    public interface ITreatmentsServiceClient
    {
        Task<IEnumerable<TreatmentDto>> GetAllTreatmentsAsync();
        Task<TreatmentDto> GetTreatmentByIdAsync(Guid id);
    }
}
