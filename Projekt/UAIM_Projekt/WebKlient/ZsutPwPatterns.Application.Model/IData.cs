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
  using System.Linq;
  using System.Text;
  using System.Threading.Tasks;

  using System.ComponentModel;
    using ZsutPwPatterns.Application.Model;

    public interface IData : INotifyPropertyChanged
  {
        List<DoctorDto> AllDoctorsList { get; }
        List<TreatmentDto> AllTreatmentsList { get; }
        List<TreatmentDto> SelectedAppointmentTreatments { get;}

        List<AppointmentDto> DoctorAppointmentsList { get; }
        List<AppointmentDto> PatientAppointmentsList { get; }
        String SearchId { get; set; }
        String PatientId { get; set; }
        DateTime? From { get; set; }
        DateTime? To { get; set; }
        DoctorDto SelectedDoctor { get; set; }
        DoctorDto Doctor { get; }
        PatientDto Patient { get; set; }
        AppointmentDto Appointment { get; set; }
        PatientDto EditedPatient { get; set; }
        AppointmentDto SelectedAppointment { get; set; }
        AppointmentDto AppointmentToAdd { get; set; }
        AppointmentDto EditedAppointment { get; set; }
        TreatmentDto SelectedTreatment { get; set; }
        TreatmentDto Treatment { get; set; }
    }
}
