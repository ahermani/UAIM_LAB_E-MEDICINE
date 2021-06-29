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

  using ZsutPw.Patterns.WindowsApplication.Model;
  using ZsutPw.Patterns.WindowsApplication.Utilities;

  public partial class Controller : PropertyContainerBase, IController
  {
    public IModel Model { get; private set; }

    public Controller( IEventDispatcher dispatcher, IModel model ) : base( dispatcher )
    {
              this.Model = model;

              this.SearchAllDoctorsCommand = new ControllerCommand( this.SearchAllDoctors );
            this.SearchAllTreatmentsCommand = new ControllerCommand(this.SearchAllTreatments);

            this.SearchDoctorIdCommand = new ControllerCommand(this.SearchDoctorId);
            this.SearchAppointmentIdCommand = new ControllerCommand(this.SearchAppointmentId);
            this.SearchPatientIdCommand = new ControllerCommand(this.SearchPatientId);
            this.UpdatePatientCommand = new ControllerCommand(this.UpdatePatient);
            this.UpdateAppointmentCommand = new ControllerCommand(this.UpdateAppointment);
            this.AddAppointmentCommand = new ControllerCommand(this.AddAppointment);
            this.SearchDoctorAppointmentsCommand = new ControllerCommand(this.SearchDoctorAppoitnments);
            this.SearchPatientAppointmentsCommand = new ControllerCommand(this.SearchPatientAppoitnments);

            this.ShowListCommand = new ControllerCommand( this.ShowList );

      this.ShowMapCommand = new ControllerCommand( this.ShowMap );
    }
  }
}
