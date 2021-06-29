namespace PatientAppMicroservice.DataServiceClients
{
    using ModelClassLibrary;
    using PatientAppMicroservice.Dtos;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;

    public interface IAppointmentsServiceClient
    {
        Task<IEnumerable<Appointment>> GetAllAppointmentsAsync();
        Task<Appointment> GetAppointmentByIdAsync(Guid id);

        Task<Appointment> UpdateAppointmentAsync(Guid id, AppointmentDto appointment);
        Task<Appointment> PostAppointmentAsync(AppointmentDto appointment);
        Task<IEnumerable<Appointment>> GetPatientAppointmentsInFrameAsync(Guid id, DateTime from, DateTime to);
        Task<IEnumerable<Appointment>> GetDoctorsAppointmentsInFrameAsync(Guid id, DateTime from, DateTime to);

    }
}
