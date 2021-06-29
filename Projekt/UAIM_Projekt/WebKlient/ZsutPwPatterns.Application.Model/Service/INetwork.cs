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
    using ZsutPwPatterns.Application.Model;

    public interface INetwork
  {
        List<DoctorDto> GetAllDoctors();
        List<TreatmentDto> GetAllTreatments();
        DoctorDto GetDoctor(string id);
        PatientDto GetPatient(string id);
        AppointmentDto GetAppointment(string id);
        PatientDto UpdatePatient(string id, PatientDto patient);

        AppointmentDto UpdateAppointment(string id, AppointmentDto appointment);
        AppointmentDto AddAppointment(AppointmentDto appointment, string patientId);
        List<AppointmentDto> GetDoctorAppointments(string id, DateTime? from, DateTime? to);
        List<AppointmentDto> GetPatientAppointments(string id, DateTime? from, DateTime? to);
    }
}
