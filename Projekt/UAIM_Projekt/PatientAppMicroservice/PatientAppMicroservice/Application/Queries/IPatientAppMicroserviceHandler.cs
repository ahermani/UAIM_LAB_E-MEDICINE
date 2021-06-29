namespace PatientAppMicroservice.Application.Queries
{
    using ModelClassLibrary;
    using PatientAppMicroservice.Dtos;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;

    public interface IPatientAppMicroserviceHandler
    {
        Task<List<Doctor>> GetAllDoctors();
        Task<List<TreatmentDto>> GetAllTreatments();
        Task<Doctor> GetDoctorById(Guid id);
        Task<Appointment> GetAppointmentById(Guid id);
        Task<TreatmentDto> GetTreatmentById(Guid id);
        Task<Patient> GetPatientById(Guid id);
        Task<Patient> UpdatePatient(Guid id, PatientDto patient);
        Task<Appointment> UpdateAppointment(Guid id, AppointmentDto appointment);
        Task<Appointment> PostAppointment(AppointmentDto appointment);
        Task<List<Appointment>> GetPatientAppointmentsInFrame(Guid id, DateTime from, DateTime to);
        Task<List<Appointment>> GetDoctorsAppointmentsInFrame(Guid id, DateTime from, DateTime to);



    }
}
