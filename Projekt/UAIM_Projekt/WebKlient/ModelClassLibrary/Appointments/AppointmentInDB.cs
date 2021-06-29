namespace ModelClassLibrary.Appointments
{
    using System;
    using System.Collections.Generic;
    using System.Xml.Serialization;
    
    public class AppointmentInDB : AppointmentBase
    {
        public AppointmentInDB(Guid id, Guid creatorId, State state, DateTime creationDate, DateTime appointmentDate,
            Guid patientId, Guid doctorId, List<Guid> treatmentIds, string note) : base(creatorId, state, appointmentDate,
            patientId, doctorId, treatmentIds, note)
        {
            Id = id;
            CreationDate = creationDate;
        }
        public AppointmentInDB():base() { }


        public Guid Id { get; set; }
        public DateTime CreationDate { get; set; }

        public static AppointmentInDB fromAppointmentBase(AppointmentBase doc){
            return new AppointmentInDB(Guid.NewGuid(),doc.CreatorId,doc.State,DateTime.UtcNow,doc.AppointmentDate,doc.PatientId,doc.DoctorId,doc.TreatmentIds,doc.Note);
        }
        public static AppointmentInDB fromAppointmentBase(AppointmentBase doc, DateTime creationDate){
            return new AppointmentInDB(Guid.NewGuid(),doc.CreatorId,doc.State,creationDate,doc.AppointmentDate,doc.PatientId,doc.DoctorId,doc.TreatmentIds,doc.Note);
        }
    }
}