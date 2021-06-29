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

namespace ZsutPw.Patterns.WindowsApplication.Model
{
  using System;
  using System.Collections.Generic;
  using System.Linq;
  using System.Text;
  using System.Threading.Tasks;

  public interface IOperations
  {
    void LoadAllDoctorsList( );
        void LoadAllTreatmentsList();
        void LoadDoctorId();
    void LoadPatientId();
        void LoadAppointmentId();
        void LoadUpdatePatient();
        void LoadUpdateAppointment();
        void LoadAddAppointment();
        void LoadDoctorAppointments();
        void LoadPatientAppointments();
    }
}
