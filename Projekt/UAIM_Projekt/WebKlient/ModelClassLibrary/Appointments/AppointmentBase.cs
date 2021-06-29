namespace ModelClassLibrary.Appointments
{
    using System;
    using System.Collections.Generic;
    
    public class AppointmentBase
    {
        public AppointmentBase(Guid creatorId, State state, DateTime appointmentDate,
            Guid patientId, Guid doctorId, List<Guid> treatmentIds, string note)
        {
            CreatorId = creatorId;
            State = state;
            AppointmentDate = appointmentDate;
            PatientId = patientId;
            DoctorId = doctorId;
            TreatmentIds = treatmentIds ?? throw new ArgumentNullException(nameof(treatmentIds));
            Note = note ?? throw new ArgumentNullException(nameof(note));
        }
        public AppointmentBase() { }
        public Guid CreatorId { get; set; }
        
        public State State { get; set; }
        
        public DateTime AppointmentDate { get; set; }
        
        public Guid PatientId { get; set; }
        
        public Guid DoctorId { get; set; }
        
        public List<Guid> TreatmentIds { get; set; }
        
        public string Note { get; set; }
    }
}