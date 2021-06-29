namespace ExaminationRoomsSelector.Web.Application.Queries
{
    using ModelClassLibrary;
    using PatientAppMicroservice.Application.Queries;
    using PatientAppMicroservice.DataServiceClients;
    using PatientAppMicroservice.Dtos;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Reflection;
    using System.Threading.Tasks;

    public class PatientAppMicroserviceQueryHandler : IPatientAppMicroserviceHandler
    {
        private readonly IPatientsServiceClient patientsServiceClient;
        private readonly IDoctorsServiceClient doctorsServiceClient;
        private readonly IAppointmentsServiceClient appointmentsServiceClient;
        private readonly ITreatmentsServiceClient treatmentsServiceClient;

        public PatientAppMicroserviceQueryHandler(IPatientsServiceClient patientsServiceClient, IDoctorsServiceClient doctorsServiceClient, IAppointmentsServiceClient appointmentsServiceClient, ITreatmentsServiceClient treatmentsServiceClient)
        {
            this.patientsServiceClient = patientsServiceClient;
            this.doctorsServiceClient = doctorsServiceClient;
            this.appointmentsServiceClient = appointmentsServiceClient;
            this.treatmentsServiceClient = treatmentsServiceClient;
        }
        public async Task<List<Doctor>> GetAllDoctors()
        {
           return (await doctorsServiceClient.GetAllDoctorsAsync()).ToList();
        }
        private bool IsAnyNullOrEmpty(object myObject)
        {
            foreach (PropertyInfo pi in myObject.GetType().GetProperties())
            {
                if (pi.PropertyType == typeof(string))
                {
                    string value = (string)pi.GetValue(myObject);
                    if (string.IsNullOrEmpty(value))
                    {
                        return true;
                    }
                }
            }
            return false;
        }

        public async Task<Doctor> GetDoctorById(Guid id)
        {
            Doctor doc = await doctorsServiceClient.GetDoctorByIdAsync(id);
            if (IsAnyNullOrEmpty(doc)) return null;

            return doc;
        }
        public async Task<Appointment> GetAppointmentById(Guid id)
        {
            Appointment app = await appointmentsServiceClient.GetAppointmentByIdAsync(id);
            if (IsAnyNullOrEmpty(app)) return null;

            return app;
        }

        public async Task<List<Appointment>> GetDoctorsAppointmentsInFrame(Guid id, DateTime from, DateTime to)
        {
            return (await appointmentsServiceClient.GetDoctorsAppointmentsInFrameAsync(id,from,to)).ToList();
        }

        public async Task<Patient> GetPatientById(Guid id)
        {
            Patient patient = await patientsServiceClient.GetPatientByIdAsync(id);
            if (IsAnyNullOrEmpty(patient)) return null;
            
            return patient;
        }

        public async Task<Patient> UpdatePatient(Guid id, PatientDto patient)
        {
            Patient p = await patientsServiceClient.UpdatePatientAsync(id, patient);
            if (IsAnyNullOrEmpty(p)) return null;
            return p;
        }

        public async Task<Appointment> UpdateAppointment(Guid id, AppointmentDto appointment)
        {
            Appointment app = await appointmentsServiceClient.UpdateAppointmentAsync(id, appointment);
            if (IsAnyNullOrEmpty(app)) return null;
            return app;
        }

        public async Task<Appointment> PostAppointment(AppointmentDto appointment)
        {
            return await appointmentsServiceClient.PostAppointmentAsync(appointment);
        }

        public async Task<List<TreatmentDto>> GetAllTreatments()
        {
            return (await treatmentsServiceClient.GetAllTreatmentsAsync()).ToList();
        }

        public async Task<TreatmentDto> GetTreatmentById(Guid id)
        {
            TreatmentDto treatment = await treatmentsServiceClient.GetTreatmentByIdAsync(id);
            if (IsAnyNullOrEmpty(treatment)) return null;

            return treatment;
        }

        public async Task<List<Appointment>> GetPatientAppointmentsInFrame(Guid id, DateTime from, DateTime to)
        {
            return (await appointmentsServiceClient.GetPatientAppointmentsInFrameAsync(id, from, to)).ToList();
        }

    }
}

