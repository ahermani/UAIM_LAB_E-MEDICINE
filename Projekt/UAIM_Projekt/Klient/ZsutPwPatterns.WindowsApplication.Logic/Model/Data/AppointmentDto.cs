namespace ZsutPw.Patterns.WindowsApplication.Model
{
    using ModelClassLibrary;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    public class AppointmentDto
    {
        public Guid Id { get; set; }
        public Guid CreatorId { get; set; }

        public State State { get; set; }

        public DateTime? CreationDate { get; set; }

        public DateTime? AppointmentDate { get; set; }

        public Guid PatientId { get; set; }

        public Guid DoctorId { get; set; }

        public List<Guid> TreatmentIds { get; set; }

        public string Note { get; set; }
    }
}
