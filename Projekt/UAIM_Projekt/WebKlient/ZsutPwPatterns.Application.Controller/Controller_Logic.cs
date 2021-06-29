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

  using System.Windows.Input;

  public partial class Controller : IController
  {
    public ApplicationState CurrentState
    {
      get { return this.currentState; }
      set
      {
        this.currentState = value;

        this.RaisePropertyChanged( "CurrentState" );
      }
    }
    private ApplicationState currentState = ApplicationState.List;

        public ICommand SearchAllDoctorsCommand { get; private set; }
        public ICommand SearchAllTreatmentsCommand { get; private set; }
        public ICommand SearchDoctorIdCommand { get; private set; }
        public ICommand SearchAppointmentIdCommand { get; private set; }
        public ICommand SearchPatientIdCommand { get; private set; }
        public ICommand UpdatePatientCommand { get; private set; }
        public ICommand UpdateAppointmentCommand { get; private set; }
        public ICommand AddAppointmentCommand { get; private set; }
        public ICommand SearchDoctorAppointmentsCommand { get; private set; }
        public ICommand SearchPatientAppointmentsCommand { get; private set; }

        public ICommand ShowListCommand { get; private set; }

    public ICommand ShowMapCommand { get; private set; }

        private void SearchAllDoctors()
        {
            this.Model.LoadAllDoctorsList();
        }
        private void SearchAllTreatments()
        {
            this.Model.LoadAllTreatmentsList();
        }
        private void SearchDoctorAppointments()
        {
            this.Model.LoadDoctorAppointments();
        }

        private void SearchPatientAppointments()
        {
            this.Model.LoadPatientAppointments();
        }
        private void SearchDoctorId()
        {
            this.Model.LoadDoctorId();
        }

        private void SearchAppointmentId()
        {
            this.Model.LoadAppointmentId();
        }

        private void SearchPatientId()
        {
            this.Model.LoadPatientId();
        }
        private void UpdatePatient()
        {
            this.Model.LoadUpdatePatient();
        }
        private void UpdateAppointment()
        {
            this.Model.LoadUpdateAppointment();
        }
        private void AddAppointment()
        {
            this.Model.LoadAddAppointment();
        }


        public async Task SearchAllDoctorsAsync()
        {
            await Task.Run(() => this.SearchAllDoctors());
        }
        public async Task SearchAllTreatmentsAsync()
        {
            await Task.Run(() => this.SearchAllTreatments());
        }
        public async Task SearchDoctorAppointmentsAsync()
        {
            await Task.Run(() => this.SearchDoctorAppointments());
        }
        public async Task SearchPatientAppointmentsAsync()
        {
            await Task.Run(() => this.SearchPatientAppointments());
        }
        public async Task SearchDoctorIdAsync()
        {
            await Task.Run(() => this.SearchDoctorId());
        }
        public async Task SearchAppointmentIdAsync()
        {
            await Task.Run(() => this.SearchAppointmentId());
        }
        public async Task SearchPatientIdAsync()
        {
            await Task.Run(() => this.SearchPatientId());
        }
        public async Task UpdatePatientAsync()
        {
            await Task.Run(() => this.UpdatePatient());
        }
        public async Task UpdateAppointmentAsync()
        {
            await Task.Run(() => this.UpdateAppointment());
        }
        public async Task AddAppointmentAsync()
        {
            await Task.Run(() => this.AddAppointment());
        }


        public async Task ShowListAsync( )
    {
      await Task.Run( ( ) => this.ShowList( ) );
    }

    public async Task ShowMapAsync( )
    {
      await Task.Run( ( ) => this.ShowMap( ) );
    }

    private void ShowList( )
    {
      switch( this.CurrentState )
      {
        case ApplicationState.List:
          break;

        default:
          this.CurrentState = ApplicationState.List;
          break;
      }
    }

    private void ShowMap( )
    {
      switch( this.CurrentState )
      {
        case ApplicationState.Map:
          break;

        default:
          this.CurrentState = ApplicationState.Map;
          break;
      }
    }
  }
}
