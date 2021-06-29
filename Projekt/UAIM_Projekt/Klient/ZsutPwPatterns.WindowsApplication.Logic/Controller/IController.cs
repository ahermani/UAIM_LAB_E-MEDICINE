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

namespace ZsutPw.Patterns.WindowsApplication.Controller
{
  using System;
  using System.Collections.Generic;
  using System.Diagnostics;
  using System.Linq;
  using System.Threading.Tasks;

  using System.ComponentModel;
  using System.Windows.Input;

  using ZsutPw.Patterns.WindowsApplication.Model;

  public interface IController : INotifyPropertyChanged
  {
    IModel Model { get; }

    ApplicationState CurrentState { get; }

    ICommand SearchAllDoctorsCommand { get; }
        ICommand SearchAllTreatmentsCommand { get; }

        ICommand SearchDoctorIdCommand { get; }
        ICommand SearchPatientIdCommand { get; }
        ICommand SearchAppointmentIdCommand { get; }

        ICommand SearchDoctorAppointmentsCommand { get; }

        ICommand SearchPatientAppointmentsCommand { get; }
        ICommand UpdatePatientCommand { get; }
        ICommand UpdateAppointmentCommand { get; }
        ICommand AddAppointmentCommand { get; }

        ICommand ShowListCommand { get; }

    ICommand ShowMapCommand { get; }
  }
}
