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
    using ZsutPwPatterns.Application.Model;

    public partial class Model : IOperations
  {
        public void LoadAllDoctorsList()
        {
            /* AT
            this.LoadNodesTask( );
            */
            Task.Run(() => this.LoadAllDoctorsTask()).Wait();
        }

        private void LoadAllDoctorsTask()
        {
            INetwork networkClient = NetworkClientFactory.GetNetworkClient();

            try
            {
                List<DoctorDto> doctors = networkClient.GetAllDoctors();

                this.AllDoctorsList = doctors;
            }
            catch (Exception)
            {
            }
        }

        public void LoadAllTreatmentsList()
        {
            /* AT
            this.LoadNodesTask( );
            */
            Task.Run(() => this.LoadAllTreatmentsTask());
        }

        private void LoadAllTreatmentsTask()
        {
            INetwork networkClient = NetworkClientFactory.GetNetworkClient();

            try
            {
                List<TreatmentDto> treatments = networkClient.GetAllTreatments();

                this.AllTreatmentsList = treatments;
            }
            catch (Exception)
            {
            }
        }
        public void LoadTreatmentId()
        {
            Task.Run(() => this.LoadTreatmentIdTask()).Wait();
        }

        private void LoadTreatmentIdTask()
        {
            INetwork networkClient = NetworkClientFactory.GetNetworkClient();

            try
            {
                TreatmentDto treatment = networkClient.GetTreatment(this.SearchId);

                this.Treatment = treatment;
            }
            catch (Exception)
            {
            }
        }

        public void LoadDoctorId()
        {
            /* AT
            this.LoadNodesTask( );
            */
            Task.Run(() => this.LoadDoctorIdTask()).Wait();
        }

        private void LoadDoctorIdTask()
        {
            INetwork networkClient = NetworkClientFactory.GetNetworkClient();

            try
            {
                DoctorDto doctor = networkClient.GetDoctor(this.SearchId);

                this.Doctor = doctor;
            }
            catch (Exception)
            {
            }
        }


        public void LoadDoctorAppointments()
        {
            /* AT
            this.LoadNodesTask( );
            */
            Task.Run(() => this.LoadDoctorAppointmentsTask());
        }

        private void LoadDoctorAppointmentsTask()
        {
            INetwork networkClient = NetworkClientFactory.GetNetworkClient();

            try
            {
                List<AppointmentDto> appointments = networkClient.GetDoctorAppointments(this.SelectedDoctor.Id.ToString(), this.From, this.To);

                this.DoctorAppointmentsList = appointments;
            }
            catch (Exception)
            {
            }
        }

        public void LoadPatientAppointments()
        {
            /* AT
            this.LoadNodesTask( );
            */
            Task.Run(() => this.LoadPatientAppointmentsTask());
        }

        private void LoadPatientAppointmentsTask()
        {
            INetwork networkClient = NetworkClientFactory.GetNetworkClient();

            try
            {
                List<AppointmentDto> appointments = networkClient.GetPatientAppointments(this.PatientId, this.From, this.To);

                this.PatientAppointmentsList = appointments;
                this.AppointmentToAdd = new AppointmentDto();

            }
            catch (Exception)
            {
            }
        }

        public void LoadPatientId()
        {
            /* AT
            this.LoadNodesTask( );
            */
            this.LoadPatientIdTask();
        }

        private void LoadPatientIdTask()
        {
            INetwork networkClient = NetworkClientFactory.GetNetworkClient();

            try
            {
                PatientDto patient = networkClient.GetPatient(this.PatientId);

                this.Patient = patient;
                this.EditedPatient = patient;
            }
            catch (Exception)
            {
            }
        }

        public void LoadAppointmentId()
        {
            /* AT
            this.LoadNodesTask( );
            */
            Task.Run(() => this.LoadAppointmentIdTask());
        }

        private void LoadAppointmentIdTask()
        {
            INetwork networkClient = NetworkClientFactory.GetNetworkClient();

            try
            {
                AppointmentDto appointment = networkClient.GetAppointment(this.SearchId);

                this.Appointment = appointment;
                this.EditedAppointment = appointment;
            }
            catch (Exception)
            {
            }
        }

        public void LoadUpdatePatient()
        {
            /* AT
            this.LoadNodesTask( );
            */
            Task.Run(() => this.LoadUpdatePatientTask());
        }

        private void LoadUpdatePatientTask()
        {
            INetwork networkClient = NetworkClientFactory.GetNetworkClient();

            try
            {
                PatientDto patient = networkClient.UpdatePatient(this.PatientId, this.EditedPatient);

                this.Patient = patient;
            }
            catch (Exception)
            {
            }
        }


        public void LoadUpdateAppointment()
        {
            /* AT
            this.LoadNodesTask( );
            */
            Task.Run(() => this.LoadUpdateAppointmentTask());
        }

        private void LoadUpdateAppointmentTask()
        {
            INetwork networkClient = NetworkClientFactory.GetNetworkClient();

            try
            {
                AppointmentDto appointment = networkClient.UpdateAppointment(this.SelectedAppointment.Id.ToString(), this.SelectedAppointment);

                this.Appointment = appointment;
            }
            catch (Exception)
            {
            }
        }


        public void LoadAddAppointment()
        {
            /* AT
            this.LoadNodesTask( );
            */
            Task.Run(() => this.LoadAddAppointmentTask());
        }

        private void LoadAddAppointmentTask()
        {
            INetwork networkClient = NetworkClientFactory.GetNetworkClient();

            try
            {
                AppointmentDto appointment = networkClient.AddAppointment(this.AppointmentToAdd, this.PatientId);

                this.AppointmentToAdd = appointment;
            }
            catch (Exception)
            {
            }
        }
    }
}
