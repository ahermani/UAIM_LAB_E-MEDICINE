namespace ModelClassLibrary
{
    using System;
    using System.Collections.Generic;
    using System.Xml.Serialization;
    
    public class Appointment
    {
        public Appointment(Guid id, Guid creatorId, State state, DateTime creationDate, DateTime appointmentDate,
            Guid patientId, Guid doctorId, List<Guid> treatmentIds, string note)
        {
            Id = id;
            CreatorId = creatorId;
            State = state;
            CreationDate = creationDate;
            AppointmentDate = appointmentDate;
            PatientId = patientId;
            DoctorId = doctorId;
            TreatmentIds = treatmentIds ?? throw new ArgumentNullException(nameof(treatmentIds));
            Note = note ?? throw new ArgumentNullException(nameof(note));
        }
        
        public Appointment() {}

        
        public Guid Id { get; set; }
        
        public Guid CreatorId { get; set; }
        
        public State State { get; set; }
        
        public DateTime CreationDate { get; set; }
        
        public DateTime AppointmentDate { get; set; }
        
        public Guid PatientId { get; set; }
        
        public Guid DoctorId { get; set; }
        
        public List<Guid> TreatmentIds { get; set; }
        
        public string Note { get; set; }
    }
}