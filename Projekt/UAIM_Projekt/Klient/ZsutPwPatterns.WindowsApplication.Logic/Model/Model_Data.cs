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
    using System.ComponentModel;
    using System.Linq;
  using System.Text;
  using System.Threading.Tasks;

  public partial class Model : IData
  {
    public List<DoctorDto> AllDoctorsList
    {
      get { return this.allDoctorsList; }
      private set
      {
        this.allDoctorsList = value;

        this.RaisePropertyChanged("AllDoctorsList");
      }
    }
    private List<DoctorDto> allDoctorsList = new List<DoctorDto>( );

        public List<TreatmentDto> AllTreatmentsList
        {
            get { return this.allTreatmentsList; }
            private set
            {
                this.allTreatmentsList = value;

                this.RaisePropertyChanged("AllTreatmentsList");
            }
        }
        private List<TreatmentDto> allTreatmentsList = new List<TreatmentDto>();


        public List<AppointmentDto> DoctorAppointmentsList
        {
            get { return this.doctorAppointmentsList; }
            private set
            {
                this.doctorAppointmentsList = value;

                this.RaisePropertyChanged("DoctorAppointmentsList");
            }
        }
        private List<AppointmentDto> doctorAppointmentsList = new List<AppointmentDto>();

        public List<AppointmentDto> PatientAppointmentsList
        {
            get { return this.patientAppointmentsList; }
            private set
            {
                this.patientAppointmentsList = value;

                this.RaisePropertyChanged("PatientAppointmentsList");
            }
        }
        private List<AppointmentDto> patientAppointmentsList = new List<AppointmentDto>();


        public DoctorDto SelectedDoctor
    {
      get { return this.selectedDoctor; }
      set
      {
        this.selectedDoctor = value;

        this.RaisePropertyChanged("SelectedDoctor");
      }
    }
        private DoctorDto selectedDoctor;

        public AppointmentDto AppointmentToAdd
        {
            get { return this.appointmentToAdd; }
            set
            {
                this.appointmentToAdd = value;

                this.RaisePropertyChanged("AppointmentToAdd");
            }
        }
        private AppointmentDto appointmentToAdd;

        public TreatmentDto SelectedTreatment
        {
            get { return this.selectedTreatment; }
            set
            {
                this.selectedTreatment = value;

                this.RaisePropertyChanged("SelectedTreatment");
            }
        }
        private TreatmentDto selectedTreatment;
        public DoctorDto Doctor
        {
            get { return this.doctor; }
            set
            {
                this.doctor = value;

                this.RaisePropertyChanged("Doctor");
            }
        }
        private DoctorDto doctor;

        public PatientDto Patient
        {
            get { return this.patient; }
            set
            {
                this.patient = value;

                this.RaisePropertyChanged("Patient");
            }
        }
        private PatientDto patient;

        public PatientDto EditedPatient
        {
            get { return this.editedPatient; }
            set
            {
                this.editedPatient = value;

                this.RaisePropertyChanged("EditedPatient");
            }
        }
        private PatientDto editedPatient;

        public String SearchId
        {
            get { return this.searchId; }
            set
            {
                this.searchId = value;
                this.RaisePropertyChanged("SearchId");
            }
        }
        private String searchId;

        public String PatientId
        {
            get { return this.patientId; }
            set
            {
                this.patientId = value;
                this.RaisePropertyChanged("PatientId");
            }
        }
        private String patientId;

        public DateTime? From
        {
            get { return this.from; }
            set
            {
                this.from = value;
                this.RaisePropertyChanged("From");
            }
        }
        private DateTime? from;

        public DateTime? To
        {
            get { return this.to; }
            set
            {
                this.to = value;
                this.RaisePropertyChanged("To");
            }
        }
        private DateTime? to;

        public AppointmentDto SelectedAppointment
        {
            get { return this.selectedAppointment; }
            set
            {
                this.selectedAppointment = value;
                this.RaisePropertyChanged("SelectedAppointment");
            }
        }
        private AppointmentDto selectedAppointment;


        public AppointmentDto Appointment
        {
            get { return this.appointment; }
            set
            {
                this.appointment = value;
                this.RaisePropertyChanged("Appointment");
            }
        }
        private AppointmentDto appointment;

        public AppointmentDto EditedAppointment
        {
            get { return this.editedAppointment; }
            set
            {
                this.editedAppointment = value;
                this.RaisePropertyChanged("EditedAppointment");
            }
        }
        private AppointmentDto editedAppointment;
    }
}
