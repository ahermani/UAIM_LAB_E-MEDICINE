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

namespace ZsutPw.Patterns.Application.Controller
{
  using System;
  using System.Collections.Generic;
  using System.Diagnostics;
  using System.Linq;
  using System.Threading.Tasks;

  using System.ComponentModel;
  using System.Windows.Input;

  using ZsutPw.Patterns.Application.Model;

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

    Task SearchAllDoctorsAsync( );
        Task SearchAllTreatmentsAsync();
        Task SearchDoctorIdAsync();
        Task SearchPatientIdAsync();
        Task SearchAppointmentIdAsync();
        Task SearchDoctorAppointmentsAsync();
        Task UpdatePatientAsync();
        Task AddAppointmentAsync();
        Task UpdateAppointmentAsync();
        Task SearchPatientAppointmentsAsync();



        Task ShowListAsync( );

    Task ShowMapAsync( );
  }
}
