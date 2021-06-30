//===============================================================================
//
// PlaZa System Platform
//
//===============================================================================
//
// Warsaw University of Technology
// Computer Networks and Services Division
// Copyright © 2020 PlaZa Creators
// All rights reserved.
//
//===============================================================================

namespace ZsutPw.Patterns.Application.Model
{
  using System;
  using System.Collections.Generic;
  using System.Diagnostics;
  using System.Linq;
  using System.Threading.Tasks;

  using System.Net.Http;
    using ZsutPwPatterns.Application.Model;
    using System.Web;

    public class NetworkClient : INetwork
  {
    private readonly ServiceClient serviceClient;

    public NetworkClient( string serviceHost, int servicePort )
    {
      Debug.Assert( condition: !String.IsNullOrEmpty( serviceHost ) && servicePort > 0 );

      this.serviceClient = new ServiceClient( serviceHost, servicePort );
    }

        public List<DoctorDto> GetAllDoctors()
        {
            string callUri = "doctors";

            List<DoctorDto> doctors = (this.serviceClient.CallWebService<DoctorDto[]>(HttpMethod.Get, callUri)).ToList<DoctorDto>();

            return doctors;
        }

        public List<TreatmentDto> GetAllTreatments()
        {
            string callUri = "treatments";

            List<TreatmentDto> treatments = (this.serviceClient.CallWebService<TreatmentDto[]>(HttpMethod.Get, callUri)).ToList<TreatmentDto>();

            return treatments;
        }
        public TreatmentDto GetTreatment(string id)
        {
            string callUri = "treatments/" + id;

            TreatmentDto treatment = (this.serviceClient.CallWebService<TreatmentDto>(HttpMethod.Get, callUri));

            return treatment;
        }

        public DoctorDto GetDoctor(string id)
        {
            string callUri = "doctors/" + id;

            DoctorDto doctor = (this.serviceClient.CallWebService<DoctorDto>(HttpMethod.Get, callUri));

            return doctor;
        }

        public PatientDto GetPatient(string id)
        {
            string callUri = "patients/" + id;

            PatientDto patient = (this.serviceClient.CallWebService<PatientDto>(HttpMethod.Get, callUri));

            return patient;
        }

        public AppointmentDto GetAppointment(string id)
        {
            string callUri = "appointments/" + id;

            AppointmentDto appointment = (this.serviceClient.CallWebService<AppointmentDto>(HttpMethod.Get, callUri));

            return appointment;
        }
        public PatientDto UpdatePatient(string id, PatientDto editedPatient)
        {
            string callUri = "patients/" + id;

            PatientDto patient = (this.serviceClient.CallWebService<PatientDto>(HttpMethod.Put, callUri, editedPatient));

            return patient;
        }

        public AppointmentDto UpdateAppointment(string id, AppointmentDto editedAppointment)
        {
            string callUri = "appointments/" + id;

            AppointmentDto appointment = (this.serviceClient.CallWebService<AppointmentDto>(HttpMethod.Put, callUri, editedAppointment));

            return appointment;
        }

        public AppointmentDto AddAppointment(AppointmentDto newAppointment, String patientId)
        {
            string callUri = "appointments";
            newAppointment.CreationDate = DateTime.Now;
            newAppointment.PatientId = new Guid(patientId);
            newAppointment.CreatorId = new Guid(patientId);
            AppointmentDto appointment = (this.serviceClient.CallWebService<AppointmentDto>(HttpMethod.Post, callUri, newAppointment));

            return appointment;
        }

        public List<AppointmentDto> GetDoctorAppointments(string id, DateTime? from, DateTime? to)
        {
            string callUri = "doctors/" + id + "/appointments" + ((from != null && from != DateTime.MinValue) ? "?from=" + HttpUtility.UrlEncode(from?.ToString("yyyy-MM-ddTHH:mm:ss")) : "") + ((to != null && to != DateTime.MinValue) ? "&to=" + HttpUtility.UrlEncode(to?.ToString("yyyy-MM-ddTHH:mm:ss")) : "");

            List<AppointmentDto> appointments = (this.serviceClient.CallWebService<AppointmentDto[]>(HttpMethod.Get, callUri)).ToList<AppointmentDto>();

            return appointments;
        }

        public List<AppointmentDto> GetPatientAppointments(string id, DateTime? from, DateTime? to)
        {
            string callUri = "patients/" + id + "/appointments" + ((from != null && from != DateTime.MinValue) ? "?from=" + HttpUtility.UrlEncode(from?.ToString("yyyy-MM-ddTHH:mm:ss")) : "") + ((to != null && to != DateTime.MinValue) ? "&to=" + HttpUtility.UrlEncode(to?.ToString("yyyy-MM-ddTHH:mm:ss")) : "");

            List<AppointmentDto> appointments = (this.serviceClient.CallWebService<AppointmentDto[]>(HttpMethod.Get, callUri)).ToList<AppointmentDto>();

            return appointments;
        }
    }
}
